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

        // 1. TẠO HÀM MỚI NÀY
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
                // Tải các bảng dữ liệu
                this.dtSach = mainForm.LoadDataFromXml("Sach");
                this.dtChiTiet = mainForm.LoadDataFromXml("ChiTietHoaDon");
                DataTable dtTheLoai = mainForm.LoadDataFromXml("TheLoaiSach");
                DataTable dtTacGia = mainForm.LoadDataFromXml("TacGia");

                // === MỚI: Nạp dữ liệu cho 2 ComboBox ===
                // Chỉ nạp nếu chưa có
                if (cbTheLoai.DataSource == null)
                {
                    cbTheLoai.DataSource = dtTheLoai;
                    cbTheLoai.DisplayMember = "TenTheLoai"; // Hiển thị tên
                    cbTheLoai.ValueMember = "MaTheLoai";   // Giá trị thực là Mã
                }
                if (cbTacGia.DataSource == null)
                {
                    cbTacGia.DataSource = dtTacGia;
                    cbTacGia.DisplayMember = "TenTacGia";
                    cbTacGia.ValueMember = "MaTacGia";
                }
                // ======================================

                // 3. Dùng LINQ để JOIN (Thêm MaTheLoai và MaTacGia vào select)
                var query = from sach in this.dtSach.AsEnumerable()
                            join theloai in dtTheLoai.AsEnumerable()
                                on Convert.ToInt32(sach["MaTheLoai"]) equals Convert.ToInt32(theloai["MaTheLoai"])
                            join tacgia in dtTacGia.AsEnumerable()
                                on Convert.ToInt32(sach["MaTacGia"]) equals Convert.ToInt32(tacgia["MaTacGia"])
                            select new
                            {
                                MaSach = Convert.ToInt32(sach["MaSach"]),

                                // === MỚI: Thêm 2 cột Mã này để ComboBox có thể chọn ===
                                MaTheLoai = Convert.ToInt32(sach["MaTheLoai"]),
                                MaTacGia = Convert.ToInt32(sach["MaTacGia"]),
                                // ================================================

                                TenSach = sach.Field<string>("TenSach"),
                                TenTheLoai = theloai.Field<string>("TenTheLoai"),
                                TenTacGia = tacgia.Field<string>("TenTacGia"),
                                GiaBan = Convert.ToDecimal(sach["GiaBan"]),
                                SoLuongTon = Convert.ToInt32(sach["SoLuongTon"])
                            };

                // 4. Đổ kết quả vào DataGridView
                dgvSach.DataSource = query.ToList();

                // 5. Thêm cột Button Xóa (giữ nguyên)
                if (dgvSach.Columns["colXoa"] == null)
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "colXoa";
                    btnXoa.HeaderText = "Hành động";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvSach.Columns.Add(btnXoa);
                }

                // 6. Đặt lại tên cột và ẨN CÁC CỘT MÃ
                dgvSach.Columns["MaSach"].Visible = false;

                // === MỚI: Ẩn 2 cột Mã ===
                dgvSach.Columns["MaTheLoai"].Visible = false;
                dgvSach.Columns["MaTacGia"].Visible = false;
                // ========================

                dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvSach.Columns["TenTheLoai"].HeaderText = "Thể Loại";
                // ... (các cột khác giữ nguyên)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            // Chỉ cần gọi hàm tải dữ liệu
            LoadDataGrid();
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem có nhấn vào cột button "colXoa" không
            // và phải là hàng có dữ liệu (e.RowIndex >= 0)
            if (e.ColumnIndex == dgvSach.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                // 2. Lấy MaSach từ hàng được nhấn (cột này đã bị ẩn)
                int maSach = Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value);
                string tenSach = dgvSach.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();

                // 3. Hỏi xác nhận
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách '{tenSach}'?\n\n(LƯU Ý: Mọi chi tiết hóa đơn liên quan cũng sẽ bị xóa.)",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        // --- 4. Xóa các chi tiết hóa đơn liên quan (bảng con) ---
                        // Lấy tất cả hàng trong dtChiTiet có MaSach này
                        DataRow[] chiTietRows = this.dtChiTiet.Select($"MaSach = {maSach}");

                        // Xóa chúng
                        foreach (var row in chiTietRows)
                        {
                            this.dtChiTiet.Rows.Remove(row);
                        }

                        // --- 5. Xóa sách (bảng cha) ---
                        DataRow sachRow = this.dtSach.Select($"MaSach = {maSach}").FirstOrDefault();
                        if (sachRow != null)
                        {
                            this.dtSach.Rows.Remove(sachRow);
                        }

                        // --- 6. LƯU thay đổi vào tệp XML ---
                        // Phải lưu cả 2 tệp
                        this.mainForm.SaveDataToXml(this.dtChiTiet, "ChiTietHoaDon");
                        this.mainForm.SaveDataToXml(this.dtSach, "Sach");

                        MessageBox.Show("Đã xóa sách thành công.", "Hoàn tất",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataGrid(); // Tải lại dữ liệu sau khi xóa
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
            // Kiểm tra xem có hàng nào đang được chọn không (CurrentRow)
            // và nó không phải là hàng tiêu đề (Index >= 0)
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

            // 2. Lấy và kiểm tra (validate) dữ liệu từ các control
            string tenSach = txtTenSach.Text.Trim();
            if (string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Tên sách không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra ComboBox
            if (cbTheLoai.SelectedValue == null || cbTacGia.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại và tác giả.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maTheLoai = Convert.ToInt32(cbTheLoai.SelectedValue);
            int maTacGia = Convert.ToInt32(cbTacGia.SelectedValue);

            // Kiểm tra số
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
                // 3. Tìm hàng (DataRow) cần cập nhật trong DataTable 'dtSach'
                // (dtSach là biến toàn cục chứa dữ liệu từ Sach.xml)
                DataRow rowToUpdate = this.dtSach.Select($"MaSach = {this.maSachHienTai}").FirstOrDefault();

                if (rowToUpdate != null)
                {
                    // 4. Cập nhật các giá trị mới cho DataRow
                    rowToUpdate["TenSach"] = tenSach;
                    rowToUpdate["MaTheLoai"] = maTheLoai;
                    rowToUpdate["MaTacGia"] = maTacGia;
                    rowToUpdate["GiaBan"] = giaBan;
                    rowToUpdate["SoLuongTon"] = soLuongTon;

                    // 5. Lưu DataTable 'dtSach' vào lại tệp Sach.xml
                    this.mainForm.SaveDataToXml(this.dtSach, "Sach");

                    // 6. Tải lại DataGridView để hiển thị dữ liệu mới
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
            // 1. Lấy và kiểm tra (validate) dữ liệu từ các control
            // (Giống hệt code của btnSua_Click)
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
                // 2. Tìm MaSach LỚN NHẤT hiện có và + 1
                // (dtSach là biến toàn cục chứa dữ liệu từ Sach.xml)
                int maSachMoi = 1; // Giá trị mặc định nếu bảng rỗng
                if (this.dtSach.Rows.Count > 0)
                {
                    // Dùng LINQ để tìm ID lớn nhất
                    maSachMoi = this.dtSach.AsEnumerable()
                                    .Max(row => Convert.ToInt32(row["MaSach"])) + 1;
                }

                // 3. Tạo một hàng (DataRow) mới dựa trên cấu trúc của dtSach
                DataRow newRow = this.dtSach.NewRow();

                // 4. Gán giá trị cho hàng mới
                newRow["MaSach"] = maSachMoi;
                newRow["TenSach"] = tenSach;
                newRow["MaTheLoai"] = maTheLoai;
                newRow["MaTacGia"] = maTacGia;
                newRow["GiaBan"] = giaBan;
                newRow["SoLuongTon"] = soLuongTon;

                // 5. Thêm hàng mới vào DataTable 'dtSach' (trong bộ nhớ)
                this.dtSach.Rows.Add(newRow);

                // 6. Lưu DataTable 'dtSach' vào lại tệp Sach.xml
                this.mainForm.SaveDataToXml(this.dtSach, "Sach");

                // 7. Tải lại DataGridView để hiển thị dữ liệu mới
                LoadDataGrid();

                MessageBox.Show("Thêm sách mới thành công!", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 8. (Tùy chọn) Xóa trắng các ô nhập liệu
                txtTenSach.Text = "";
                txtGiaBan.Text = "";
                txtSoLuong.Text = "";
                cbTheLoai.SelectedIndex = -1; // Bỏ chọn
                cbTacGia.SelectedIndex = -1; // Bỏ chọn
                this.maSachHienTai = 0; // Reset mã sách đang chọn
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
