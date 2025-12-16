using QLBANSACH;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class QuanLyLoaiSach : UserControl
    {

        private Form1 mainForm; 
        private DataTable dtTheLoai;
        private DataTable dtSach; 
        private string tableName = "TheLoaiSach";
        private int maTL_HienTai = 0; 

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
                if (this.mainForm == null)
                {
                    this.mainForm = (Form1)this.ParentForm;
                }
                this.dtTheLoai = mainForm.LoadDataFromXml(tableName);
                this.dtSach = mainForm.LoadDataFromXml("Sach"); 
                dgvTheLoaiSach.DataSource = this.dtTheLoai;
                if (dgvTheLoaiSach.Columns["colXoa"] == null)
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "colXoa";
                    btnXoa.HeaderText = "Hành động";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvTheLoaiSach.Columns.Add(btnXoa);
                }
                dgvTheLoaiSach.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
                dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
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
                    this.maTL_HienTai = Convert.ToInt32(row.Cells["MaTheLoai"].Value);
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
            this.maTL_HienTai = 0;
            dgvTheLoaiSach.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenTL = txtTenTheLoaiSach.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            { 
                int maTLMoi = 1;
                if (this.dtTheLoai.Rows.Count > 0)
                {
                    maTLMoi = this.dtTheLoai.AsEnumerable()
                                    .Max(row => Convert.ToInt32(row["MaTheLoai"])) + 1;
                }
                DataRow newRow = this.dtTheLoai.NewRow();
                newRow["MaTheLoai"] = maTLMoi;
                newRow["TenTheLoai"] = tenTL;
                this.dtTheLoai.Rows.Add(newRow);
                this.mainForm.SaveDataToXml(this.dtTheLoai, tableName);
                LoadDataGrid();

                MessageBox.Show("Thêm thể loại mới thành công!", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.maTL_HienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn một thể loại từ danh sách để sửa.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenTL = txtTenTheLoaiSach.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRow rowToUpdate = this.dtTheLoai.Select($"MaTheLoai = {this.maTL_HienTai}").FirstOrDefault();

                if (rowToUpdate != null)
                {
                    rowToUpdate["TenTheLoai"] = tenTL;
                    this.mainForm.SaveDataToXml(this.dtTheLoai, tableName);
                    LoadDataGrid();

                    MessageBox.Show("Cập nhật thể loại thành công!", "Hoàn tất",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (e.ColumnIndex == dgvTheLoaiSach.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                int maTL = Convert.ToInt32(dgvTheLoaiSach.Rows[e.RowIndex].Cells["MaTheLoai"].Value);
                string tenTL = dgvTheLoaiSach.Rows[e.RowIndex].Cells["TenTheLoai"].Value.ToString();
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thể loại '{tenTL}'?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.No) return;

                try
                {
                    bool daCoSach = this.dtSach.AsEnumerable()
                                        .Any(row => Convert.ToInt32(row["MaTheLoai"]) == maTL);

                    if (daCoSach)
                    {
                        MessageBox.Show("Không thể xóa thể loại này!\nThể loại đã được gán cho sách trong hệ thống.", "Lỗi ràng buộc",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRow rowToUpdate = this.dtTheLoai.Select($"MaTheLoai = {maTL}").FirstOrDefault();
                    if (rowToUpdate != null)
                    {
                        this.dtTheLoai.Rows.Remove(rowToUpdate);
                    }
                    this.mainForm.SaveDataToXml(this.dtTheLoai, tableName);
                    LoadDataGrid();

                    MessageBox.Show("Đã xóa thể loại thành công.", "Hoàn tất",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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