using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class TaiKhoan : UserControl
    {
        private Form1 mainForm;
        private DataTable dtTaiKhoan;
        private string tableName = "TaiKhoan";
        private int maTK_HienTai = 0;
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            label1.Text = "Tên đăng nhập:";
            label2.Text = "Mật khẩu hiện tại:";
            label3.Text = "Mật khẩu mới:";
            label4.Text = "Nhập lại MK mới:";
            txtMKHienTai.PasswordChar = '*';
            txtMKMoi.PasswordChar = '*';
            txtNhapLai.PasswordChar = '*';
            txtTenDangNhap.ReadOnly = true;

            LoadData();
        }
        private void LoadData()
        {
            try
            {
                if (mainForm == null)
                    mainForm = (Form1)this.ParentForm;

                dtTaiKhoan = mainForm.LoadDataFromXml(tableName);
                if (dtTaiKhoan == null)
                {
                    MessageBox.Show("Không có dữ liệu tài khoản trong file XML.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                FormatTaiKhoanData();
                DataTable dtHienThi;
                if (UserSession.VaiTro != null && UserSession.VaiTro.ToLower() == "admin")
                {
                    dtHienThi = dtTaiKhoan;
                }
                else
                {
                    var rows = dtTaiKhoan.AsEnumerable()
                        .Where(r => r["TenDangNhap"].ToString().Equals(UserSession.TenDangNhap, StringComparison.OrdinalIgnoreCase));

                    if (rows.Any())
                        dtHienThi = rows.CopyToDataTable();
                    else
                    {
                        dtHienThi = dtTaiKhoan.Clone();
                        MessageBox.Show("Không tìm thấy tài khoản cá nhân trong danh sách dữ liệu.", "Lỗi dữ liệu",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                lstNguoiDung.DataSource = dtHienThi;
                lstNguoiDung.DisplayMember = "DisplayMember";
                lstNguoiDung.ValueMember = "MaTK";

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu {tableName}: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Định dạng hiển thị danh sách tài khoản
        private void FormatTaiKhoanData()
        {
            if (!dtTaiKhoan.Columns.Contains("DisplayMember"))
                dtTaiKhoan.Columns.Add("DisplayMember", typeof(string));

            foreach (DataRow row in dtTaiKhoan.Rows)
            {
                row["DisplayMember"] = $"{row["HoTen"]} | {row["VaiTro"]} | ({row["TenDangNhap"]})";
            }
        }

        // 🔹 Xóa các ô nhập
        private void ClearInputFields()
        {
            maTK_HienTai = 0;
            txtTenDangNhap.Clear();
            txtMKHienTai.Clear();
            txtMKMoi.Clear();
            txtNhapLai.Clear();
            lstNguoiDung.ClearSelected();
        }

        // 🔹 Khi chọn tài khoản trong danh sách
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lstNguoiDung.SelectedValue != null)
            {
                try
                {
                    maTK_HienTai = Convert.ToInt32(lstNguoiDung.SelectedValue);
                    DataRow row = dtTaiKhoan.AsEnumerable()
                        .FirstOrDefault(r => Convert.ToInt32(r["MaTK"]) == maTK_HienTai);

                    if (row != null)
                    {
                        txtTenDangNhap.Text = row["TenDangNhap"].ToString();
                        txtMKHienTai.Clear();
                        txtMKMoi.Clear();
                        txtNhapLai.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn tài khoản: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 🔹 Cập nhật mật khẩu
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (maTK_HienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mkHienTai = txtMKHienTai.Text.Trim();
            string mkMoi = txtMKMoi.Text.Trim();
            string nhapLai = txtNhapLai.Text.Trim();

            if (string.IsNullOrEmpty(mkHienTai) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(nhapLai))
            {
                MessageBox.Show("Các trường mật khẩu không được để trống.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mkMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mkMoi != nhapLai)
            {
                MessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRow rowToUpdate = dtTaiKhoan.AsEnumerable()
                    .FirstOrDefault(r => Convert.ToInt32(r["MaTK"]) == maTK_HienTai);

                if (rowToUpdate != null)
                {
                    string mkCu = rowToUpdate["MatKhau"].ToString();
                    if (mkCu != mkHienTai)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi xác thực",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    rowToUpdate["MatKhau"] = mkMoi;
                    mainForm.SaveDataToXml(dtTaiKhoan, tableName);

                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Hoàn tất",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản để cập nhật.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tài khoản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstNguoiDung_DoubleClick(object sender, EventArgs e)
        {
            btnChon_Click(sender, e);
        }
        private void lstNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
