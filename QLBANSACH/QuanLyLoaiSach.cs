using QLBANSACH;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class QuanLyLoaiSach : UserControl
    {
        // === 1. KHAI BÁO BIẾN TOÀN CỤC ===

        private Form1 mainForm; // Form cha (Form1)
        private DataTable dtTheLoai; // Bảng dữ liệu Thể Loại
        private DataTable dtSach; // Bảng Sách (để kiểm tra ràng buộc)
        private string tableName = "TheLoaiSach"; // Tên tệp XML
        private int maTL_HienTai = 0; // Mã của hàng đang chọn

        public QuanLyLoaiSach()
        {
            InitializeComponent();
        }

        private void QuanLyLoaiSach_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                // Lấy Form cha (chỉ gán 1 lần)
                if (this.mainForm == null)
                {
                    this.mainForm = (Form1)this.ParentForm;
                }

                // Tải dữ liệu từ XML
                this.dtTheLoai = mainForm.LoadDataFromXml(tableName);
                this.dtSach = mainForm.LoadDataFromXml("Sach"); // Tải bảng Sách

                // Gán nguồn cho DataGridView
                dgvTheLoaiSach.DataSource = this.dtTheLoai;

                // === THÊM CỘT XÓA (NẾU CHƯA CÓ) ===
                if (dgvTheLoaiSach.Columns["colXoa"] == null)
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "colXoa";
                    btnXoa.HeaderText = "Hành động";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvTheLoaiSach.Columns.Add(btnXoa);
                }

                // (Tùy chọn) Đặt lại tên cột cho đẹp
                dgvTheLoaiSach.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
                dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";

                // (Tùy chọn) Tự động dãn cột
                dgvTheLoaiSach.Columns["TenTheLoai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTheLoaiSach.Columns["MaTheLoai"].Width = 120;
                dgvTheLoaiSach.Columns["colXoa"].Width = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu {tableName}: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTheLoaiSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoaiSach.CurrentRow != null && dgvTheLoaiSach.CurrentRow.Index >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvTheLoaiSach.CurrentRow;

                    // 1. Lấy MaTheLoai, lưu vào biến toàn cục
                    this.maTL_HienTai = Convert.ToInt32(row.Cells["MaTheLoai"].Value);

                    // 2. Gán dữ liệu lên TextBox
                    txtTenTheLoaiSach.Text = row.Cells["TenTheLoai"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi chọn hàng: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa trắng ô
            txtTenTheLoaiSach.Text = "";

            // Reset mã đang chọn
            this.maTL_HienTai = 0;

            // Bỏ chọn trên DataGridView
            dgvTheLoaiSach.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Lấy và kiểm tra dữ liệu
            string tenTL = txtTenTheLoaiSach.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Tìm MaTheLoai mới (Max + 1)
                int maTLMoi = 1;
                if (this.dtTheLoai.Rows.Count > 0)
                {
                    maTLMoi = this.dtTheLoai.AsEnumerable()
                                    .Max(row => Convert.ToInt32(row["MaTheLoai"])) + 1;
                }

                // 3. Tạo hàng mới và thêm vào DataTable
                DataRow newRow = this.dtTheLoai.NewRow();
                newRow["MaTheLoai"] = maTLMoi;
                newRow["TenTheLoai"] = tenTL;
                this.dtTheLoai.Rows.Add(newRow);

                // 4. Lưu vào tệp TheLoaiSach.xml
                this.mainForm.SaveDataToXml(this.dtTheLoai, tableName);

                // 5. Tải lại DataGridView
                LoadDataGrid();

                MessageBox.Show("Thêm thể loại mới thành công!", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 6. Làm mới các ô nhập
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thể loại: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn thể loại chưa
            if (this.maTL_HienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn một thể loại từ danh sách để sửa.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy và kiểm tra dữ liệu
            string tenTL = txtTenTheLoaiSach.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Tìm hàng cần cập nhật trong DataTable
                DataRow rowToUpdate = this.dtTheLoai.Select($"MaTheLoai = {this.maTL_HienTai}").FirstOrDefault();

                if (rowToUpdate != null)
                {
                    // 4. Cập nhật dữ liệu
                    rowToUpdate["TenTheLoai"] = tenTL;

                    // 5. Lưu vào tệp TheLoaiSach.xml
                    this.mainForm.SaveDataToXml(this.dtTheLoai, tableName);

                    // 6. Tải lại DataGridView
                    LoadDataGrid();

                    MessageBox.Show("Cập nhật thể loại thành công!", "Hoàn tất",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 7. Làm mới các ô nhập
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thể loại: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTheLoaiSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem có nhấn vào cột button "colXoa" không
            if (e.ColumnIndex == dgvTheLoaiSach.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                // 2. Lấy MaTheLoai từ hàng được nhấn
                int maTL = Convert.ToInt32(dgvTheLoaiSach.Rows[e.RowIndex].Cells["MaTheLoai"].Value);
                string tenTL = dgvTheLoaiSach.Rows[e.RowIndex].Cells["TenTheLoai"].Value.ToString();

                // 3. Hỏi xác nhận
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thể loại '{tenTL}'?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.No) return;

                try
                {
                    // 4. === KIỂM TRA RÀNG BUỘC (QUAN TRỌNG) ===
                    // Kiểm tra xem thể loại này có sách nào không
                    bool daCoSach = this.dtSach.AsEnumerable()
                                        .Any(row => Convert.ToInt32(row["MaTheLoai"]) == maTL);

                    if (daCoSach)
                    {
                        MessageBox.Show("Không thể xóa thể loại này!\nThể loại đã được gán cho sách trong hệ thống.", "Lỗi ràng buộc",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 5. Tìm hàng trong dtTheLoai và Xóa
                    DataRow rowToUpdate = this.dtTheLoai.Select($"MaTheLoai = {maTL}").FirstOrDefault();
                    if (rowToUpdate != null)
                    {
                        this.dtTheLoai.Rows.Remove(rowToUpdate);
                    }

                    // 6. Lưu thay đổi vào tệp TheLoaiSach.xml
                    this.mainForm.SaveDataToXml(this.dtTheLoai, tableName);

                    // 7. Tải lại DataGridView
                    LoadDataGrid();

                    MessageBox.Show("Đã xóa thể loại thành công.", "Hoàn tất",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 8. Làm mới các ô nhập
                    btnLamMoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa thể loại: {ex.Message}", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}