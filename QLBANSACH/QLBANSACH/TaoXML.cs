using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
namespace QLBANSACH
{
    public class TaoXML
    {
        string strCon = "Data Source=DESKTOP-J950OOK\\SQLEXPRESS;Initial Catalog=QLBANSACH;User ID=sa;Password=975125;";

        public void taoXML(string sql, string bang, string _FileXML)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable(bang);
            ad.Fill(dt);
            // Ghi ra XML cùng với schema
            dt.WriteXml(Application.StartupPath + _FileXML, XmlWriteMode.WriteSchema);
        }

        public DataTable loadDataGridView(string _FileXML)
        {
            DataTable dt = new DataTable();

            string FilePath = _FileXML;
            if (!Path.IsPathRooted(FilePath))
                FilePath = Path.Combine(Application.StartupPath, _FileXML);

            if (!File.Exists(FilePath))
            {
                MessageBox.Show($"File không tồn tại: {FilePath}");
                return dt; 
            }

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(FilePath);

                if (dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables[0].Copy();
                }
                else
                {
                    MessageBox.Show("Tệp XML không chứa bảng dữ liệu nào: " + FilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc tệp XML: " + ex.Message + "\nFile: " + FilePath);
            }

            return dt;
        }


        public void Them(string FileXML, string xml)
        {
            try
            {
                XmlTextReader textread = new XmlTextReader(FileXML);
                XmlDocument doc = new XmlDocument();
                doc.Load(textread);
                textread.Close();
                XmlNode currNode;
                XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
                docFrag.InnerXml = xml;
                currNode = doc.DocumentElement;
                currNode.InsertAfter(docFrag, currNode.LastChild);
                doc.Save(FileXML);
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
        }

        public void xoa(string _FileXML, string xml)
        {
            try
            {
                string fileName = Application.StartupPath + _FileXML;
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode nodeCu = doc.SelectSingleNode(xml);
                doc.DocumentElement.RemoveChild(nodeCu);
                doc.Save(fileName);
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
        }

        public void sua(string FileXML, string sql, string xml, string bang)
        {
            XmlTextReader reader = new XmlTextReader(FileXML);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldValue;
            XmlElement root = doc.DocumentElement;
            oldValue = root.SelectSingleNode(sql);
            XmlElement newValue = doc.CreateElement(bang);
            newValue.InnerXml = xml;
            root.ReplaceChild(newValue, oldValue);
            doc.Save(FileXML);
        }

        public DataTable TimKiem(string fileXML, string keyword, params string[] fields)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Application.StartupPath + fileXML);

            if (ds.Tables.Count == 0)
                return null;

            DataTable dt = ds.Tables[0];
            string kw = keyword.Trim().ToLower();
            if (kw == "")
                return dt;
            var rows = dt.AsEnumerable()
                .Where(row =>
                    fields.Any(col =>
                        dt.Columns.Contains(col) &&
                        row[col].ToString().ToLower().Contains(kw)
                    )
                );

            return rows.Any() ? rows.CopyToDataTable() : null;
        }


        public string LayGiaTri(string duongDan, string truongA, string giaTriA, string truongB)
        {
            string giatriB = "";
            DataTable dt = new DataTable();
            dt = loadDataGridView(duongDan);
            int soDongNhanVien = dt.Rows.Count;
            for (int i = 0; i < soDongNhanVien; i++)
            {
                if (dt.Rows[i][truongA].ToString().Trim().Equals(giaTriA))
                {
                    giatriB = dt.Rows[i][truongB].ToString();
                    return giatriB;
                }
            }
            return giatriB;
        }

        public bool KiemTra(string _FileXML, string truongKiemTra, string giaTriKiemTra)
        {
            DataTable dt = new DataTable();
            dt = loadDataGridView(_FileXML);
            dt.DefaultView.RowFilter = truongKiemTra + " ='" + giaTriKiemTra + "'";
            if (dt.DefaultView.Count > 0)
                return true;
            return false;
        }


        public string txtMa(string tienTo, string _FileXML, string tenCot)
        {
            string txtMa = "";
            DataTable dt = new DataTable();
            dt = loadDataGridView(_FileXML);
            int dem = dt.Rows.Count;
            if (dem == 0)
            {
                txtMa = tienTo + "001";//HD001
            }
            else
            {
                string lastCode = dt.Rows[dem - 1][tenCot].ToString().Trim();
                int duoi;
                if (lastCode.Length >= 5 && int.TryParse(lastCode.Substring(2, 3), out duoi))
                {
                    duoi += 1;
                }
                else
                {
                    duoi = 1;
                }

                string duoiString = duoi.ToString("D3"); 
                txtMa = tienTo + duoiString;
            }
            return txtMa;
        }
        public bool KTMa(string _FileXML, string cotMa, string ma)
        {
            bool kt = true;
            DataTable dt = new DataTable();
            dt = loadDataGridView(_FileXML);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][cotMa].ToString().Trim().Equals(ma))
                {
                    kt = false;
                    break;
                }
            }
            return kt;
        }

        public void exCuteNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
        }

        public void Them_Database(string tenBang, string _FileXML)
        {
            string duongDan = _FileXML;
            DataTable table = loadDataGridView(duongDan);
            int dong = table.Rows.Count - 1;
            string sql = "insert into " + tenBang + " values(";
            for (int j = 0; j < table.Columns.Count - 1; j++)
            {
                sql += "N'" + table.Rows[dong][j].ToString().Trim() + "',";
            }
            sql += "N'" + table.Rows[dong][table.Columns.Count - 1].ToString().Trim() + "'";
            sql += ")";
            exCuteNonQuery(sql);
        }

        public void Sua_Database(string tenBang, string _FileXML, string tenCot, string giaTri)
        {
            string duongDan = _FileXML;
            DataTable table = loadDataGridView(duongDan);
            int dong = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][tenCot].ToString().Trim() == giaTri)
                { dong = i; }
            }
            if (dong > -1)
            {
                string sql = "update " + tenBang + " set ";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += table.Columns[j].ToString() + " = N'" + table.Rows[dong][j].ToString().Trim() + "', ";
                }
                sql += table.Columns[table.Columns.Count - 1].ToString() + " = N'" + table.Rows[dong][table.Columns.Count - 1].ToString().Trim() + "' ";
                sql += "where " + tenCot + "= '" + giaTri + "'";
                exCuteNonQuery(sql);
            }
        }

        public void Xoa_Database(string _FileXML, string tenCot, string giaTri, string tenBang)
        {
            string duongDan = _FileXML;
            DataTable table = loadDataGridView(duongDan);
            int dong = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][tenCot].ToString().Trim() == giaTri)
                { dong = i; }
            }
            if (dong > -1)
            {
                string sql = "delete from " + tenBang + " where ";
                sql += tenCot + " = '" + giaTri + "'";
                exCuteNonQuery(sql);
            }
        }

        public void CapNhapTungBang(string tenBang, string _FileXML)
        {
            string duongDan = _FileXML;
            DataTable table = loadDataGridView(duongDan);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "insert into " + tenBang + " values(";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += "N'" + table.Rows[i][j].ToString().Trim() + "',";
                }
                sql += "N'" + table.Rows[i][table.Columns.Count - 1].ToString().Trim() + "'";
                sql += ")";
                exCuteNonQuery(sql);
            }

        }

        public void TimKiemXSLT(string data, string tenFileXML, string tenfileXSLT)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("" + tenfileXSLT + ".xslt");
            XsltArgumentList argList = new XsltArgumentList();
            argList.AddParam("Data", "", data);
            XmlWriter writer = XmlWriter.Create("" + tenFileXML + ".html");
            xslt.Transform(new XPathDocument("" + tenFileXML + ".xml"), argList, writer);
            writer.Close();
            System.Diagnostics.Process.Start("" + tenFileXML + ".html");
        }
    }
}