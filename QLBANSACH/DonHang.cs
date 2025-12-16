using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class DonHang : UserControl
    {
        private Form1 mainForm;
        private DataTable dtHoaDon;
        private DataTable dtChiTietHoaDon;
        private DataTable dtSach;
        private DataTable dtNhanSu;
        private DataTable dtKhachHang;
        private DataTable dtCurrentDetails = new DataTable();

        public DonHang()
        {
            InitializeComponent();
        }

        private void QuanLyDonHang_Load(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1)
            {
                this.mainForm = (Form1)this.ParentForm;
                LoadData();
            }

            // Gán các sự kiện sau khi controls đã được tải
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            btnThemChiTiet.Click += btnThemChiTiet_Click;
            btnThanhToan.Click += btnThanhToan_Click; // Thanh toán
            dgvChiTiet.CellContentClick += dgvChiTiet_CellContentClick; // Xử lý nút xóa chi tiết
        }

        private void LoadData()
        {
            try
            {
                // Tải dữ liệu từ XML (Giữ nguyên)
                dtHoaDon = mainForm.LoadDataFromXml("HoaDon");
                dtChiTietHoaDon = mainForm.LoadDataFromXml("ChiTietHoaDon");
                dtSach = mainForm.LoadDataFromXml("Sach");
                dtNhanSu = mainForm.LoadDataFromXml("NhanSu");
                dtKhachHang = mainForm.LoadDataFromXml("KhachHang");

                // Cấu hình ComboBox (Giữ nguyên)
                cbKhachHang.DataSource = dtKhachHang;
                cbKhachHang.DisplayMember = "TenKhachHang";
                cbKhachHang.ValueMember = "MaKhachHang";

                cbNhanSu.DataSource = dtNhanSu;
                cbNhanSu.DisplayMember = "HoTen";
                cbNhanSu.ValueMember = "MaNhanSu";

                cbSach.DataSource = dtSach;
                cbSach.DisplayMember = "TenSach";
                cbSach.ValueMember = "MaSach";

                // Khởi tạo bảng chi tiết tạm thời
                TaoCauTrucChiTietTam();

                // Thiết lập trạng thái ban đầu
                ResetForm();

                // Gán sự kiện cho ComboBox Sách (Đảm bảo chỉ gán một lần)
                cbSach.SelectedIndexChanged -= cbSach_SelectedIndexChanged;
                cbSach.SelectedIndexChanged += cbSach_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void TaoCauTrucChiTietTam()
        {
            dtCurrentDetails.Columns.Clear();
            dtCurrentDetails.Columns.Add("MaSach", typeof(int));
            dtCurrentDetails.Columns.Add("TenSach", typeof(string));
            dtCurrentDetails.Columns.Add("SoLuong", typeof(int));
            dtCurrentDetails.Columns.Add("DonGia", typeof(decimal));
            dtCurrentDetails.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = dtCurrentDetails;

            // Thêm cột nút xóa
            if (dgvChiTiet.Columns["colXoaChiTiet"] == null)
            {
                DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                btnXoa.Name = "colXoaChiTiet";
                btnXoa.HeaderText = "Xóa";
                btnXoa.Text = "Xóa";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvChiTiet.Columns.Add(btnXoa);
            }

            dgvChiTiet.Columns["MaSach"].Visible = false;
            dgvChiTiet.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["colXoaChiTiet"].Width = 60;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ResetForm()
        {
            // lblNgayLap và lblTongTien phải khớp với tên trong Designer.cs
            lblNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblTongTien.Text = "0 VNĐ";
            dtCurrentDetails.Clear();

            if (cbKhachHang.Items.Count > 0) cbKhachHang.SelectedIndex = 0;
            if (cbNhanSu.Items.Count > 0) cbNhanSu.SelectedIndex = 0;
            if (cbSach.Items.Count > 0) cbSach.SelectedIndex = 0;

            txtSoLuong.Clear();
            txtDonGia.Clear();

            // Thiết lập trạng thái ban đầu
            btnTaoHoaDon.Enabled = true;
            btnThanhToan.Enabled = false;
            btnThemChiTiet.Enabled = false;
        }

        private void cbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSach.SelectedValue != null && cbSach.SelectedValue != DBNull.Value)
            {
                try
                {
                    int maSach = Convert.ToInt32(cbSach.SelectedValue);
                    DataRow sachRow = dtSach.Select($"MaSach = {maSach}").FirstOrDefault();

                    if (sachRow != null)
                    {
                        // Hiển thị Đơn giá và Tồn kho (nếu cần)
                        txtDonGia.Text = Convert.ToDecimal(sachRow["GiaBan"]).ToString("N0");
                        // Gợi ý: lblTonKho.Text = sachRow["SoLuongTon"].ToString();
                    }
                }
                catch (Exception)
                {
                    // Lỗi khi DataBinding đang chạy
                }
            }
        }

        private void CapNhatTongTienTam()
        {
            decimal tongTien = 0;
            if (dtCurrentDetails.Rows.Count > 0)
            {
                tongTien = dtCurrentDetails.AsEnumerable()
                    .Sum(row => Convert.ToDecimal(row["ThanhTien"]));
            }
            lblTongTien.Text = $"{tongTien:N0} VNĐ";
        }

        // === XỬ LÝ NÚT TẠO HÓA ĐƠN ===
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            LoadData(); // Tải lại dữ liệu (để lấy tồn kho mới nhất)
            ResetForm();

            btnTaoHoaDon.Enabled = false;
            btnThemChiTiet.Enabled = true;

            MessageBox.Show("Đã khởi tạo hóa đơn mới. Bắt đầu thêm sách.", "Thông báo");
        }

        // === XỬ LÝ NÚT THÊM CHI TIẾT (button1) ===
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cbSach.SelectedValue == null) return;

            int maSach = Convert.ToInt32(cbSach.SelectedValue);
            int soLuong;
            decimal donGia;

            // 1. Kiểm tra đầu vào
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Loại bỏ dấu chấm, phẩy trước khi parse (cho format N0)
            string donGiaText = txtDonGia.Text.Replace(".", "").Replace(",", "");
            if (!decimal.TryParse(donGiaText, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Kiểm tra tồn kho
            DataRow sachRow = dtSach.Select($"MaSach = {maSach}").FirstOrDefault();
            int tonKho = Convert.ToInt32(sachRow["SoLuongTon"]);
            DataRow existingDetail = dtCurrentDetails.Select($"MaSach = {maSach}").FirstOrDefault();

            int soLuongHienTai = (existingDetail != null) ? Convert.ToInt32(existingDetail["SoLuong"]) : 0;
            int soLuongMoi = soLuongHienTai + soLuong;

            if (soLuongMoi > tonKho)
            {
                MessageBox.Show($"Tổng số lượng sách '{cbSach.Text}' yêu cầu ({soLuongMoi}) vượt quá tồn kho hiện tại ({tonKho}).", "Lỗi tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Thêm hoặc cập nhật vào bảng tạm
            if (existingDetail != null)
            {
                existingDetail["SoLuong"] = soLuongMoi;
                existingDetail["ThanhTien"] = soLuongMoi * donGia;
            }
            else
            {
                DataRow newDetailRow = dtCurrentDetails.NewRow();
                newDetailRow["MaSach"] = maSach;
                newDetailRow["TenSach"] = cbSach.Text;
                newDetailRow["SoLuong"] = soLuong;
                newDetailRow["DonGia"] = donGia;
                newDetailRow["ThanhTien"] = soLuong * donGia;
                dtCurrentDetails.Rows.Add(newDetailRow);
            }

            // 4. Cập nhật Tổng tiền và trạng thái
            CapNhatTongTienTam();
            btnThanhToan.Enabled = true;

            // Làm mới ô nhập
            txtSoLuong.Clear();
        }

        // === XỬ LÝ NÚT THANH TOÁN (btnHoanThanh) ===
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtCurrentDetails.Rows.Count == 0) return;

            try
            {
                // ... (Logic tìm Mã HD mới, Thêm Hóa Đơn mới vào dtHoaDon)
                int maHDMoi = (dtHoaDon.Rows.Count > 0) ? dtHoaDon.AsEnumerable().Max(row => Convert.ToInt32(row["MaHoaDon"])) + 1 : 1;
                decimal tongTien = dtCurrentDetails.AsEnumerable().Sum(row => Convert.ToDecimal(row["ThanhTien"]));

                DataRow newHDRow = dtHoaDon.NewRow();
                newHDRow["MaHoaDon"] = maHDMoi;
                newHDRow["MaKhachHang"] = cbKhachHang.SelectedValue;
                newHDRow["MaNhanSu"] = cbNhanSu.SelectedValue;
                newHDRow["NgayLap"] = DateTime.Now;
                newHDRow["TongTien"] = tongTien;
                dtHoaDon.Rows.Add(newHDRow);

                // ... (Thêm Chi Tiết Hóa Đơn vào dtChiTietHoaDon và CẬP NHẬT TỒN KHO)
                int maCTMax = (dtChiTietHoaDon.Rows.Count > 0) ? dtChiTietHoaDon.AsEnumerable().Max(row => Convert.ToInt32(row["MaCT"])) : 0;

                foreach (DataRow detailRow in dtCurrentDetails.Rows)
                {
                    maCTMax++;
                    DataRow newCTRow = dtChiTietHoaDon.NewRow();
                    newCTRow["MaCT"] = maCTMax;
                    newCTRow["MaHoaDon"] = maHDMoi;
                    newCTRow["MaSach"] = detailRow["MaSach"];
                    newCTRow["SoLuong"] = detailRow["SoLuong"];
                    newCTRow["DonGia"] = detailRow["DonGia"];
                    dtChiTietHoaDon.Rows.Add(newCTRow);

                    // CẬP NHẬT TỒN KHO
                    int maSach = Convert.ToInt32(detailRow["MaSach"]);
                    int soLuongBan = Convert.ToInt32(detailRow["SoLuong"]);
                    DataRow sachRow = dtSach.Select($"MaSach = {maSach}").FirstOrDefault();
                    if (sachRow != null)
                    {
                        sachRow["SoLuongTon"] = Convert.ToInt32(sachRow["SoLuongTon"]) - soLuongBan;
                    }
                }

                // 5. LƯU CẢ 3 BẢNG ĐÃ THAY ĐỔI VÀO XML
                mainForm.SaveDataToXml(dtHoaDon, "HoaDon");
                mainForm.SaveDataToXml(dtChiTietHoaDon, "ChiTietHoaDon");
                mainForm.SaveDataToXml(dtSach, "Sach");

                MessageBox.Show($"Tạo hóa đơn {maHDMoi} thành công!\nTổng tiền: {tongTien:N0} VNĐ", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 6. Reset form và trạng thái nút 
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn tất hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === XỬ LÝ NÚT XÓA CHI TIẾT TẠM THỜI (dgvChiTiet) ===
        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra có phải là cột "Xóa" và là hàng dữ liệu hợp lệ không
            if (e.ColumnIndex == dgvChiTiet.Columns["colXoaChiTiet"].Index && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvChiTiet.Rows[e.RowIndex];
                    int maSach = Convert.ToInt32(row.Cells["MaSach"].Value);
                    string tenSach = row.Cells["TenSach"].Value.ToString();

                    var confirm = MessageBox.Show($"Bạn có muốn xóa sách '{tenSach}' khỏi hóa đơn này?",
                                                 "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        DataRow rowToDelete = dtCurrentDetails.Select($"MaSach = {maSach}").FirstOrDefault();
                        if (rowToDelete != null)
                        {
                            dtCurrentDetails.Rows.Remove(rowToDelete);
                        }

                        CapNhatTongTienTam();
                        // Tắt Hoàn thành nếu không còn chi tiết nào
                        btnThanhToan.Enabled = dtCurrentDetails.Rows.Count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa chi tiết: " + ex.Message, "Lỗi");
                }
            }
        }

        // Cần giữ lại hai hàm này nếu bạn có nó trong Designer.cs
        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbNhanSu_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            if (dtCurrentDetails.Rows.Count == 0) return;

            // Khởi tạo các biến cần thiết trước khi try/catch
            int maHDMoi = 0;
            decimal tongTien = 0;
            DateTime ngayLap = DateTime.Now;
            // RẤT QUAN TRỌNG: Tạo bản sao dữ liệu chi tiết để truyền đi
            DataTable detailsToDisplay = dtCurrentDetails.Copy();

            try
            {
                // 1. Lấy Mã HD mới và Tổng tiền
                maHDMoi = (dtHoaDon.Rows.Count > 0) ? dtHoaDon.AsEnumerable().Max(row => Convert.ToInt32(row["MaHoaDon"])) + 1 : 1;
                tongTien = detailsToDisplay.AsEnumerable().Sum(row => Convert.ToDecimal(row["ThanhTien"]));

                // Lấy thông tin Tên Khách hàng và Tên Nhân viên
                string tenKhachHang = cbKhachHang.Text;
                string tenNhanSu = cbNhanSu.Text;

                // 2. Thêm Hóa Đơn mới vào dtHoaDon (Giữ nguyên)
                DataRow newHDRow = dtHoaDon.NewRow();
                newHDRow["MaHoaDon"] = maHDMoi;
                newHDRow["MaKhachHang"] = cbKhachHang.SelectedValue;
                newHDRow["MaNhanSu"] = cbNhanSu.SelectedValue;
                newHDRow["NgayLap"] = ngayLap;
                newHDRow["TongTien"] = tongTien;
                dtHoaDon.Rows.Add(newHDRow);

                // 3. Thêm Chi Tiết Hóa Đơn và CẬP NHẬT TỒN KHO (Giữ nguyên)
                int maCTMax = (dtChiTietHoaDon.Rows.Count > 0) ? dtChiTietHoaDon.AsEnumerable().Max(row => Convert.ToInt32(row["MaCT"])) : 0;

                foreach (DataRow detailRow in detailsToDisplay.Rows)
                {
                    maCTMax++;
                    DataRow newCTRow = dtChiTietHoaDon.NewRow();
                    newCTRow["MaCT"] = maCTMax;
                    newCTRow["MaHoaDon"] = maHDMoi;
                    newCTRow["MaSach"] = detailRow["MaSach"];
                    newCTRow["SoLuong"] = detailRow["SoLuong"];
                    newCTRow["DonGia"] = detailRow["DonGia"];
                    dtChiTietHoaDon.Rows.Add(newCTRow);

                    // CẬP NHẬT TỒN KHO
                    int maSach = Convert.ToInt32(detailRow["MaSach"]);
                    int soLuongBan = Convert.ToInt32(detailRow["SoLuong"]);
                    DataRow sachRow = dtSach.Select($"MaSach = {maSach}").FirstOrDefault();
                    if (sachRow != null)
                    {
                        sachRow["SoLuongTon"] = Convert.ToInt32(sachRow["SoLuongTon"]) - soLuongBan;
                    }
                }

                // 4. LƯU CẢ 3 BẢNG ĐÃ THAY ĐỔI VÀO XML
                mainForm.SaveDataToXml(dtHoaDon, "HoaDon");
                mainForm.SaveDataToXml(dtChiTietHoaDon, "ChiTietHoaDon");
                mainForm.SaveDataToXml(dtSach, "Sach");

                MessageBox.Show($"Tạo hóa đơn {maHDMoi} thành công!\nTổng tiền: {tongTien:N0} VNĐ", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // =========================================================
                // === BỔ SUNG: HIỂN THỊ HÓA ĐƠN VỪA TẠO TRÊN FORM2 ===
                // =========================================================
                try
                {
                    // Gọi Form2 và truyền tất cả dữ liệu cần thiết
                    Form2 viewer = new Form2(
                        maHDMoi,
                        tenKhachHang,
                        tenNhanSu,
                        ngayLap,
                        detailsToDisplay, // Truyền bảng chi tiết đã sao chép
                        tongTien
                    );
                    viewer.ShowDialog(); // Hiển thị Form dưới dạng Dialog
                }
                catch (Exception exDisplay)
                {
                    MessageBox.Show($"Lỗi khi hiển thị hóa đơn: {exDisplay.Message}", "Lỗi hiển thị");
                }
                // =========================================================

                // 5. Reset form và trạng thái nút
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn tất hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}