using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class Form1 : Form
    {
        // Nếu SQL Server chạy trên cùng máy tính đang chạy ứng dụng
        string connectionString = @"Server=192.168.2.35,1433;Database=QLYBANSACH;User Id=sa;Password=Ly@12062005;Encrypt=False; Connection Timeout=120;";
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
            // Xóa tất cả các control cũ đang có trong panel
            panelContent.Controls.Clear();

            // Thêm UserControl mới vào panel
            panelContent.Controls.Add(uc);

            // Cho UserControl fill đầy panel
            uc.Dock = DockStyle.Fill;
        }

        private void CapNhatTrangThaiMenu()
        {
            bool daDangNhap = UserSession.DaDangNhap;

            // Nếu chưa đăng nhập → ẩn toàn bộ
            mnuQuanLy.Enabled = daDangNhap;
            thốngKêToolStripMenuItem.Enabled = daDangNhap;
            quảnLýToolStripMenuItem.Enabled = daDangNhap;
            tàiKhoảnToolStripMenuItem1.Enabled = daDangNhap;
            chuyểnĐổiXMLToolStripMenuItem.Enabled = daDangNhap;

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
            // 1. Tạo control đăng nhập
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
                // Tạo DataSet mới chỉ để bọc DataTable
                DataSet dataSet = new DataSet(tableName + "Data");

                // Quan trọng: Phải copy cấu trúc và dữ liệu
                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = tableName; // Đặt tên bảng bên trong DataSet

                dataSet.Tables.Add(dtCopy);

                // Ghi đè tệp XML
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

                    // Lặp qua từng bảng trong danh sách "cha trước"
                    foreach (string tableName in tablesParentFirst)
                    {
                        // 1. Lấy dữ liệu từ SQL
                        string query = $"SELECT * FROM {tableName}";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                        // 2. Tạo DataSet MỚI cho mỗi bảng
                        DataSet dataSet = new DataSet(tableName + "Data");
                        adapter.Fill(dataSet, tableName); // Đặt tên Bảng bên trong DataSet

                        // 3. Xác định đường dẫn tệp (vd: .../bin/Debug/Sach.xml)
                        string filePath = Path.Combine(appPath, $"{tableName}.xml");

                        // 4. Ghi đè tệp XML
                        dataSet.WriteXml(filePath, XmlWriteMode.WriteSchema);

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
                "CẢNH BÁO: Hành động này sẽ XÓA SẠCH dữ liệu SQL Server và thay thế bằng dữ liệu từ XML.\nBạn có chắc chắn?",
                "Xác nhận",
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

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Transaction = transaction;

                    // ===== 1. TẮT CONSTRAINT + TRIGGER =====
                    cmd.CommandText = "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DISABLE TRIGGER trg_CapNhatTongTien ON ChiTietHoaDon";
                    cmd.ExecuteNonQuery();

                    // ===== 2. XÓA DỮ LIỆU (CON → CHA) =====
                    foreach (string table in tablesChildFirst)
                    {
                        cmd.CommandText = $"DELETE FROM {table}";
                        cmd.ExecuteNonQuery();
                    }

                    // ===== 3. NHẬP DỮ LIỆU (CHA → CON) =====
                    foreach (string table in tablesParentFirst)
                    {
                        string filePath = Path.Combine(appPath, $"{table}.xml");
                        DataSet ds = new DataSet();
                        ds.ReadXml(filePath);
                        DataTable dt = ds.Tables[0];

                        using (SqlBulkCopy bulk = new SqlBulkCopy(
                            conn,
                            SqlBulkCopyOptions.KeepIdentity,
                            transaction))
                        {
                            bulk.DestinationTableName = table;
                            bulk.BulkCopyTimeout = 300;

                            foreach (DataColumn col in dt.Columns)
                                bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                            bulk.WriteToServer(dt);
                        }
                    }

                    // ===== 4. RESEED IDENTITY =====
                    foreach (var kv in primaryKeyColumns)
                    {
                        cmd.CommandText = $"SELECT ISNULL(MAX({kv.Value}),0) FROM {kv.Key}";
                        long maxId = Convert.ToInt64(cmd.ExecuteScalar());
                        cmd.CommandText = $"DBCC CHECKIDENT ('{kv.Key}', RESEED, {maxId})";
                        cmd.ExecuteNonQuery();
                    }

                    // ===== 5. BẬT LẠI CONSTRAINT + TRIGGER =====
                    cmd.CommandText = "EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "ENABLE TRIGGER trg_CapNhatTongTien ON ChiTietHoaDon";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("✔ Nhập XML → SQL thành công!", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                try { transaction?.Rollback(); } catch { }
                MessageBox.Show("❌ Lỗi nhập XML:\n" + ex.Message);
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