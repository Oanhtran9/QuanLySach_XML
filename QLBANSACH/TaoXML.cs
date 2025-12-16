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
        string strCon = @"Server=192.168.2.35,1433;Database=QLYBANSACH;User Id=sa;Password=Ly@12062005;Encrypt=False; Connection Timeout=120;";
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


        public void Them(string fileXML, string xmlNode)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileXML);

            XmlDocumentFragment frag = doc.CreateDocumentFragment();
            frag.InnerXml = xmlNode;

            doc.DocumentElement.AppendChild(frag);
            doc.Save(fileXML);
        }


        public void Xoa(string fileXML, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileXML);

            XmlNode node = doc.SelectSingleNode(xpath);
            if (node != null)
            {
                doc.DocumentElement.RemoveChild(node);
                doc.Save(fileXML);
            }
        }



        public void Sua(string fileXML, string xpath, string innerXml, string nodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileXML);

            XmlNode oldNode = doc.SelectSingleNode(xpath);
            if (oldNode == null) return;

            XmlElement newNode = doc.CreateElement(nodeName);
            newNode.InnerXml = innerXml;

            oldNode.ParentNode.ReplaceChild(newNode, oldNode);
            doc.Save(fileXML);
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
            DataTable dt = loadDataGridView(_FileXML);
            int soMoi = 1;

            if (dt != null && dt.Rows.Count > 0)
            {
                // Lấy cột ID, giả sử nó là kiểu số (INT)
                if (dt.Columns.Contains(tenCot))
                {
                    var maxId = dt.AsEnumerable()
                                   .Max(row => row[tenCot] == DBNull.Value ? 0 : Convert.ToInt32(row[tenCot]));
                    soMoi = maxId + 1;
                }
            }
            // Trả về ID số để lưu vào XML (và sau này là DB nếu không dùng IDENTITY)
            // Nếu dùng IDENTITY (như NhanSu), ID này chỉ dùng để ghi XML
            return soMoi.ToString();
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
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // 🔥 Hiển thị lỗi SQL chi tiết
                MessageBox.Show($"Lỗi SQL khi thực thi:\n{ex.Message}\nCâu lệnh: {sql}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Ném lại lỗi để Form quản lý nhân sự biết
            }
        }

        public void Them_Database(string tenBang, string _FileXML)
        {
            try
            {
                DataTable table = loadDataGridView(_FileXML);
                if (table == null || table.Rows.Count == 0) return;

                int dong = table.Rows.Count - 1;

                // Xây dựng danh sách cột (bỏ cột đầu tiên - IDENTITY)
                string danhSachCot = "";
                for (int j = 1; j < table.Columns.Count; j++)
                {
                    danhSachCot += table.Columns[j].ColumnName + ",";
                }
                danhSachCot = danhSachCot.TrimEnd(',');

                // Xây dựng chuỗi giá trị (bỏ giá trị cột đầu tiên)
                string danhSachGiaTri = "";
                for (int j = 1; j < table.Columns.Count; j++)
                {
                    // Lấy giá trị từ dòng mới nhất trong DataTable
                    string value = table.Rows[dong][j].ToString().Trim();

                    // Xử lý kiểu dữ liệu: Nếu là NVARCHAR/STRING, thêm N'...'
                    // Đối với bài tập này, chúng ta sẽ coi tất cả các cột sau ID là STRING
                    danhSachGiaTri += "N'" + value.Replace("'", "''") + "',";
                }
                danhSachGiaTri = danhSachGiaTri.TrimEnd(',');

                string sql = $"INSERT INTO {tenBang} ({danhSachCot}) VALUES ({danhSachGiaTri})";

                exCuteNonQuery(sql); // Gọi hàm thực thi SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm vào Database ({tenBang}): {ex.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // Chỉ cần điều kiện WHERE, không cần vòng lặp
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