
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
    public partial class QuanLySach : UserControl
    {
        private Form1 mainForm;
        private DataTable dtSach;
        private DataTable dtChiTiet;

        private int maSachHienTai = 0;

        public QuanLySach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void LoadDataGrid()
        {
            if (this.ParentForm is Form1)
            {
                this.mainForm = (Form1)this.ParentForm;
            }
            else
            {
                if (this.mainForm == null)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy form chính.");
                    return;
                }
            }

            try
            {
                this.dtSach = mainForm.LoadDataFromXml("Sach");
                this.dtChiTiet = mainForm.LoadDataFromXml("ChiTietHoaDon");
                DataTable dtTheLoai = mainForm.LoadDataFromXml("TheLoaiSach");
                DataTable dtTacGia = mainForm.LoadDataFromXml("TacGia");

                if (cbTheLoai.DataSource == null)
                {
                    cbTheLoai.DataSource = dtTheLoai;
                    cbTheLoai.DisplayMember = "TenTheLoai";
                    cbTheLoai.ValueMember = "MaTheLoai";
                }
                if (cbTacGia.DataSource == null)
                {
                    cbTacGia.DataSource = dtTacGia;
                    cbTacGia.DisplayMember = "TenTacGia";
                    cbTacGia.ValueMember = "MaTacGia";
                }

                var query = from sach in this.dtSach.AsEnumerable()
                            join theloai in dtTheLoai.AsEnumerable()
                                on Convert.ToInt32(sach["MaTheLoai"]) equals Convert.ToInt32(theloai["MaTheLoai"])
                            join tacgia in dtTacGia.AsEnumerable()
                                on Convert.ToInt32(sach["MaTacGia"]) equals Convert.ToInt32(tacgia["MaTacGia"])
                            select new
                            {
                                MaSach = Convert.ToInt32(sach["MaSach"]),
                                MaTheLoai = Convert.ToInt32(sach["MaTheLoai"]),
                                MaTacGia = Convert.ToInt32(sach["MaTacGia"]),
                                TenSach = sach.Field<string>("TenSach"),
                                TenTheLoai = theloai.Field<string>("TenTheLoai"),
                                TenTacGia = tacgia.Field<string>("TenTacGia"),
                                GiaBan = Convert.ToDecimal(sach["GiaBan"]),
                                SoLuongTon = Convert.ToInt32(sach["SoLuongTon"])
                            };

                dgvSach.DataSource = query.ToList();

                if (dgvSach.Columns["colXoa"] == null)
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "colXoa";
                    btnXoa.HeaderText = "Hành động";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvSach.Columns.Add(btnXoa);
                }

                dgvSach.Columns["MaSach"].Visible = false;
                dgvSach.Columns["MaTheLoai"].Visible = false;
                dgvSach.Columns["MaTacGia"].Visible = false;

                dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvSach.Columns["TenTheLoai"].HeaderText = "Thể Loại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSach.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                int maSach = Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value);
                string tenSach = dgvSach.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();

                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sách '{tenSach}'?\n\n(LƯU Ý: Mọi chi tiết hóa đơn liên quan cũng sẽ bị xóa.)",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        DataRow[] chiTietRows = this.dtChiTiet.Select($"MaSach = {maSach}");
                        foreach (var row in chiTietRows)
                        {
                            this.dtChiTiet.Rows.Remove(row);
                        }

                        DataRow sachRow = this.dtSach.Select($"MaSach = {maSach}").FirstOrDefault();
                        if (sachRow != null)
                        {
                            this.dtSach.Rows.Remove(sachRow);
                        }

                        this.mainForm.SaveDataToXml(this.dtChiTiet, "ChiTietHoaDon");
                        this.mainForm.SaveDataToXml(this.dtSach, "Sach");

                        MessageBox.Show("Đã xóa sách thành công.", "Hoàn tất",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow != null && dgvSach.CurrentRow.Index >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvSach.CurrentRow;
                    this.maSachHienTai = Convert.ToInt32(row.Cells["MaSach"].Value);
                    txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                    txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                    txtSoLuong.Text = row.Cells["SoLuongTon"].Value.ToString();
                    cbTheLoai.SelectedValue = row.Cells["MaTheLoai"].Value;
                    cbTacGia.SelectedValue = row.Cells["MaTacGia"].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi chọn hàng: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.maSachHienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ danh sách để sửa.", "Chưa chọn sách",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSach = txtTenSach.Text.Trim();
            if (string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Tên sách không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbTheLoai.SelectedValue == null || cbTacGia.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại và tác giả.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maTheLoai = Convert.ToInt32(cbTheLoai.SelectedValue);
            int maTacGia = Convert.ToInt32(cbTacGia.SelectedValue);

            decimal giaBan;
            int soLuongTon;
            if (!decimal.TryParse(txtGiaBan.Text, out giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập số dương.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ. Vui lòng nhập số nguyên dương.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataRow rowToUpdate = this.dtSach.Select($"MaSach = {this.maSachHienTai}").FirstOrDefault();

                if (rowToUpdate != null)
                {
                    rowToUpdate["TenSach"] = tenSach;
                    rowToUpdate["MaTheLoai"] = maTheLoai;
                    rowToUpdate["MaTacGia"] = maTacGia;
                    rowToUpdate["GiaBan"] = giaBan;
                    rowToUpdate["SoLuongTon"] = soLuongTon;

                    this.mainForm.SaveDataToXml(this.dtSach, "Sach");

                    LoadDataGrid();

                    MessageBox.Show("Cập nhật sách thành công!", "Hoàn tất",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách để cập nhật. Vui lòng tải lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            cbTheLoai.SelectedIndex = -1;
            cbTacGia.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenSach = txtTenSach.Text.Trim();
            if (string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Tên sách không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbTheLoai.SelectedValue == null || cbTacGia.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại và tác giả.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maTheLoai = Convert.ToInt32(cbTheLoai.SelectedValue);
            int maTacGia = Convert.ToInt32(cbTacGia.SelectedValue);

            decimal giaBan;
            if (!decimal.TryParse(txtGiaBan.Text, out giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soLuongTon;
            if (!int.TryParse(txtSoLuong.Text, out soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int maSachMoi = 1;
                if (this.dtSach.Rows.Count > 0)
                {
                    maSachMoi = this.dtSach.AsEnumerable()
                                    .Max(row => Convert.ToInt32(row["MaSach"])) + 1;
                }

                DataRow newRow = this.dtSach.NewRow();

                newRow["MaSach"] = maSachMoi;
                newRow["TenSach"] = tenSach;
                newRow["MaTheLoai"] = maTheLoai;
                newRow["MaTacGia"] = maTacGia;
                newRow["GiaBan"] = giaBan;
                newRow["SoLuongTon"] = soLuongTon;

                this.dtSach.Rows.Add(newRow);

                this.mainForm.SaveDataToXml(this.dtSach, "Sach");

                LoadDataGrid();

                MessageBox.Show("Thêm sách mới thành công!", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenSach.Text = "";
                txtGiaBan.Text = "";
                txtSoLuong.Text = "";
                cbTheLoai.SelectedIndex = -1;
                cbTacGia.SelectedIndex = -1;
                this.maSachHienTai = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
