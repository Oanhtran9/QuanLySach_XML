using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-J950OOK\\SQLEXPRESS;Initial Catalog=QLBANSACH;User ID=sa;Password=975125;";
        private List<string> tablesParentFirst = new List<string>
        {
            "TheLoaiSach",
            "TacGia",
            "KhachHang",
            "NhanSu",
            "TaiKhoan",
            "Sach",
            "HoaDon",
            "ChiTietHoaDon"
        };

        private List<string> tablesChildFirst = new List<string>
            {
                "ChiTietHoaDon",
                "HoaDon",
                "Sach",
                "TaiKhoan",
                "NhanSu",
                "KhachHang",
                "TacGia",
                "TheLoaiSach"
            };

        private Dictionary<string, string> primaryKeyColumns = new Dictionary<string, string>
            {
                { "TheLoaiSach", "MaTheLoai" },
                { "TacGia", "MaTacGia" },
                { "KhachHang", "MaKhachHang" },
                { "NhanSu", "MaNhanSu" },
                { "TaiKhoan", "MaTK" },
                { "Sach", "MaSach" },
                { "HoaDon", "MaHoaDon" },
                { "ChiTietHoaDon", "MaCT" }
            };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CapNhatTrangThaiMenu();
            TrangChu tc = new TrangChu();
            LoadControl(tc);
        }

        private void LoadControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void CapNhatTrangThaiMenu()
        {
            bool daDangNhap = UserSession.DaDangNhap;
            mnuQuanLy.Enabled = daDangNhap;
            thốngKêToolStripMenuItem.Enabled = daDangNhap;
            quảnLýToolStripMenuItem.Enabled = daDangNhap;
            tàiKhoảnToolStripMenuItem1.Enabled = daDangNhap;
            chuyểnĐổiXMLToolStripMenuItem.Enabled= daDangNhap;

            đăngNhậpToolStripMenuItem.Visible = !daDangNhap;
            đăngXuấtToolStripMenuItem.Visible = daDangNhap;

            if (!daDangNhap)
                return;
            if (UserSession.VaiTro == "Admin")
            {
                mnuQuanLy.Enabled = true;
                quảnLýToolStripMenuItem.Enabled = true;
                sáchToolStripMenuItem.Enabled = true;
                loạiToolStripMenuItem.Enabled = true;
                mnuQLSACH.Enabled = true;
                mnuQLKHACHHANG.Enabled = true;
                thốngKêToolStripMenuItem.Enabled = true;
                tàiKhoảnToolStripMenuItem1.Enabled = true;
                mnuChuyenDoiSqlSangXml.Enabled = true;
                mnuChuyenDoiXmlSangSql.Enabled = true;
                chuyểnĐổiXMLToolStripMenuItem.Enabled = true;
            }
            else if (UserSession.VaiTro == "NhanVien")
            {
                mnuQuanLy.Enabled = true;
                quảnLýToolStripMenuItem.Enabled = true;
                chuyểnĐổiXMLToolStripMenuItem.Enabled = false;
                mnuChuyenDoiXmlSangSql.Enabled = false;
                thốngKêToolStripMenuItem.Enabled = false;
                mnuQLKHACHHANG.Enabled = true;
                tàiKhoảnToolStripMenuItem1.Enabled = true;
                mnuQLSACH.Enabled = false;
            }
        }

        private void mnuTrangChu_Click(object sender, EventArgs e)
        {
            LoadControl(new TrangChu());
        }
        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap uc = new DangNhap();
            uc.LoginSuccess += DangNhap_LoginSuccess;
            LoadControl(uc);
        }

        private void DangNhap_LoginSuccess(object sender, EventArgs e)
        {
            CapNhatTrangThaiMenu();
            LoadControl(new TrangChu());
        }
        private string GetAppPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        public DataTable LoadDataFromXml(string tableName)
        {
            string filePath = Path.Combine(GetAppPath(), $"{tableName}.xml");
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"[LoadDataFromXml] File không tồn tại:\n{filePath}");
                    return new DataTable(); 
                }

                DataSet dataSet = new DataSet();
                dataSet.ReadXml(filePath);

                if (dataSet.Tables.Count == 0)
                {
                    MessageBox.Show($"[LoadDataFromXml] File có nhưng không có bảng: {filePath}");
                    return new DataTable();
                }

                var dt = dataSet.Tables[0].Copy();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nghiêm trọng khi đọc tệp {tableName}.xml: {ex.Message}");
                return new DataTable();
            }
        }

        public void SaveDataToXml(DataTable dt, string tableName)
        {
            string filePath = Path.Combine(GetAppPath(), $"{tableName}.xml");
            try
            { 
                DataSet dataSet = new DataSet(tableName + "Data");
                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = tableName;
                dataSet.Tables.Add(dtCopy);
                dataSet.WriteXml(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nghiêm trọng khi lưu tệp {tableName}.xml: {ex.Message}");
            }
        }

        private void XuatSQLSangXML()
        {
            try
            {
                string appPath = GetAppPath(); // Lấy đường dẫn bin/Debug

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (string tableName in tablesParentFirst)
                    {
                        string query = $"SELECT * FROM {tableName}";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        DataSet dataSet = new DataSet(tableName + "Data");
                        adapter.Fill(dataSet, tableName); 
                        string filePath = Path.Combine(appPath, $"{tableName}.xml");
                        dataSet.WriteXml(filePath);
                    }
                }

                MessageBox.Show($"Đã xuất {tablesParentFirst.Count} bảng ra các tệp XML tại:\n{appPath}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất SQL sang XML: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhapXMLVaoSQL()
        {
            var confirmResult = MessageBox.Show(
                "CẢNH BÁO: Hành động này sẽ XÓA SẠCH dữ liệu SQL Server và thay thế bằng dữ liệu từ các tệp XML trong thư mục chương trình.\n\nBạn có chắc chắn muốn tiếp tục?",
                "Xác nhận Nhập",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            string appPath = GetAppPath(); 
            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        foreach (string tableName in tablesChildFirst)
                        {
                            cmd.CommandText = $"DELETE FROM {tableName}";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (string tableName in tablesParentFirst)
                    {
                        string filePath = Path.Combine(appPath, $"{tableName}.xml");

                        if (!File.Exists(filePath))
                        {
                            throw new FileNotFoundException($"Không tìm thấy tệp bắt buộc: {tableName}.xml");
                        }
                        DataSet ds = new DataSet();
                        ds.ReadXml(filePath);
                        DataTable dt = ds.Tables[0]; 
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, transaction))
                        {
                            bulkCopy.DestinationTableName = tableName;
                            bulkCopy.WriteToServer(dt);
                        }
                    }
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        foreach (string tableName in primaryKeyColumns.Keys)
                        {
                            cmd.CommandText = $"SELECT ISNULL(MAX({primaryKeyColumns[tableName]}), 0) FROM {tableName}";
                            long maxId = Convert.ToInt64(cmd.ExecuteScalar());
                            cmd.CommandText = $"DBCC CHECKIDENT ('{tableName}', RESEED, {maxId})";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Nhập dữ liệu từ các tệp XML vào SQL Server thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                try { transaction?.Rollback(); } catch { }
                MessageBox.Show("Có lỗi khi nhập XML vào SQL (Mọi thay đổi đã được hoàn tác):\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuChuyenDoiSqlSangXml_Click(object sender, EventArgs e)
        {
            XuatSQLSangXML();
        }

        private void mnuChuyenDoiXmlSangSql_Click(object sender, EventArgs e)
        {
            NhapXMLVaoSQL();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSession.DangXuat();
            CapNhatTrangThaiMenu();
            LoadControl(new TrangChu());
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap uc = new DangNhap();
            uc.LoginSuccess += DangNhap_LoginSuccess;
            LoadControl(uc);
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadControl(new TaiKhoan());
        }

        private void mnuQLSACH_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyNhanSu());
        }

        private void mnuQLKHACHHANG_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyKhach());
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLySach());
        }

        private void loạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyLoaiSach());
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadControl(new DonHang());
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadControl(new ThongKe());
        }

        private void chuyểnĐổiXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyHoaDon());
        }
    }
}
