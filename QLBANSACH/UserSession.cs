using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace QLBANSACH
{
    public static class UserSession
    {
        public static string TenDangNhap { get; private set; }
        public static string HoTen { get; private set; }
        public static string VaiTro { get; private set; }
        public static bool DaDangNhap { get; private set; }
        private static string GetXmlPath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.xml");
        }

        // 🔹 Hàm đăng nhập kiểm tra trong TaiKhoan.xml
        public static bool DangNhap(string username, string password)
        {
            try
            {
                string filePath = GetXmlPath("TaiKhoan");

                // Kiểm tra file có tồn tại không
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Không tìm thấy file TaiKhoan.xml! Vui lòng xuất XML từ SQL trước.",
                        "Lỗi XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Đọc file XML vào DataSet
                DataSet ds = new DataSet();
                ds.ReadXml(filePath);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Tệp TaiKhoan.xml không chứa dữ liệu hợp lệ!",
                        "Lỗi XML", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                DataTable dt = ds.Tables[0];

                // Tìm dòng khớp username + password
                DataRow[] rows = dt.Select($"TenDangNhap = '{username.Replace("'", "''")}' AND MatKhau = '{password.Replace("'", "''")}'");

                if (rows.Length > 0)
                {
                    // Nếu đăng nhập thành công
                    DataRow user = rows[0];
                    TenDangNhap = user["TenDangNhap"].ToString();
                    HoTen = user["HoTen"].ToString();
                    VaiTro = user["VaiTro"].ToString();
                    DaDangNhap = true;
                    return true;
                }
                else
                {
                    // Sai tài khoản hoặc mật khẩu
                    DaDangNhap = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc XML: " + ex.Message, "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 🔹 Hàm đăng xuất
        public static void DangXuat()
        {
            TenDangNhap = null;
            HoTen = null;
            VaiTro = null;
            DaDangNhap = false;
        }
    }
}
