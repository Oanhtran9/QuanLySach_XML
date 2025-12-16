using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class QuanLyNhanSu : UserControl
    {
        private TaoXML Fxml = new TaoXML();

        private const string XML_FILE_NHANSU = "NhanSu.xml";
        private const string PRIMARY_KEY = "MaNhanSu";
        private const string PREFIX_MA = "NS";
        private string MaNhanSuHienTai = ""; 
        public QuanLyNhanSu()
        {
            InitializeComponent();
            SetupControls();
            LoadDataGrid();
            SetButtonsState(true);
        }

        private string GetFullXmlPath() => Application.StartupPath + XML_FILE_NHANSU;

        // Khởi tạo control
        private void SetupControls()
        {
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new string[] { "Bán hàng", "Kho", "Thu ngân", "Quản lý kho", "Kế toán" });
            cboChucVu.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;

            if (Controls.Find("txtMaNhanSu", true).FirstOrDefault() is TextBox txtMa)
            {
                txtMa.Enabled = false;
                txtMa.Text = TaoMaTuDong();
            }
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnHienThi.Click += btnHienThi_Click;
            dgvNhanSu.CellClick += dgvNhanSu_CellClick;
        }
        private string TaoMaTuDong()
        {
            return Fxml.txtMa(PREFIX_MA, XML_FILE_NHANSU, PRIMARY_KEY);
        }
        private void LoadDataGrid()
        {
            try
            {
                DataTable dt = Fxml.loadDataGridView(XML_FILE_NHANSU);
                dgvNhanSu.DataSource = dt;

                // Header
                if (dgvNhanSu.Columns.Contains("MaNhanSu")) dgvNhanSu.Columns["MaNhanSu"].HeaderText = "Mã NS";
                if (dgvNhanSu.Columns.Contains("HoTen")) dgvNhanSu.Columns["HoTen"].HeaderText = "Họ Tên";
                if (dgvNhanSu.Columns.Contains("ChucVu")) dgvNhanSu.Columns["ChucVu"].HeaderText = "Chức vụ";
                if (dgvNhanSu.Columns.Contains("SoDienThoai")) dgvNhanSu.Columns["SoDienThoai"].HeaderText = "SĐT";
                if (dgvNhanSu.Columns.Contains("DiaChi")) dgvNhanSu.Columns["DiaChi"].HeaderText = "Địa chỉ";
                if (dgvNhanSu.Columns.Contains("NgayVaoLam")) dgvNhanSu.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
                if (dgvNhanSu.Columns.Contains("Luong")) dgvNhanSu.Columns["Luong"].HeaderText = "Lương";

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa dữ liệu trên control
        private void ClearInputFields()
        {
            if (Controls.Find("txtHoTen", true).FirstOrDefault() is TextBox t1) t1.Clear();
            if (Controls.Find("txtDiaChi", true).FirstOrDefault() is TextBox t2) t2.Clear();
            if (Controls.Find("txtSDT", true).FirstOrDefault() is TextBox t3) t3.Clear();
            if (Controls.Find("txtLuong", true).FirstOrDefault() is TextBox t4) t4.Clear();

            cboChucVu.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;
            MaNhanSuHienTai = "";

            if (Controls.Find("txtMaNhanSu", true).FirstOrDefault() is TextBox txtMa)
                txtMa.Text = TaoMaTuDong();
        }
        private void SetButtonsState(bool isAdding)
        {
            btnThem.Enabled = isAdding;
            btnSua.Enabled = !isAdding;
            btnXoa.Enabled = !isAdding;
        }
        private bool ValidateInput()
        {
            var txtHoTen = Controls.Find("txtHoTen", true).FirstOrDefault() as TextBox;
            var txtSDT = Controls.Find("txtSDT", true).FirstOrDefault() as TextBox;
            var txtLuong = Controls.Find("txtLuong", true).FirstOrDefault() as TextBox;

            if (txtHoTen == null || txtSDT == null || txtLuong == null)
            {
                MessageBox.Show("Thiếu control nhập liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên, SĐT và Lương.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string luongStr = txtLuong.Text.Replace(",", "").Replace(".", "");
            if (!decimal.TryParse(luongStr, out _))
            {
                MessageBox.Show("Lương phải là số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private string BuildNhanSuXml(string maNV, string hoTen, string chucVu, string sdt, string diaChi, DateTime ngayVaoLam, string luong)
        {
            string ngay = ngayVaoLam.ToString("yyyy-MM-ddTHH:mm:ss+07:00");
            return $@"
                <NhanSu>
                  <MaNhanSu>{maNV}</MaNhanSu>
                  <HoTen>{System.Security.SecurityElement.Escape(hoTen)}</HoTen>
                  <ChucVu>{System.Security.SecurityElement.Escape(chucVu)}</ChucVu>
                  <SoDienThoai>{System.Security.SecurityElement.Escape(sdt)}</SoDienThoai>
                  <DiaChi>{System.Security.SecurityElement.Escape(diaChi)}</DiaChi>
                  <NgayVaoLam>{ngay}</NgayVaoLam>
                  <Luong>{System.Security.SecurityElement.Escape(luong)}</Luong>
                </NhanSu>";
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maNV = (Controls.Find("txtMaNhanSu", true).FirstOrDefault() as TextBox)?.Text ?? TaoMaTuDong();

            if (Fxml.KiemTra(XML_FILE_NHANSU, PRIMARY_KEY, maNV))
            {
                MessageBox.Show($"Mã nhân sự {maNV} đã tồn tại.", "Lỗi trùng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var hoTen = (Controls.Find("txtHoTen", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "";
            var chucVu = cboChucVu.SelectedItem?.ToString() ?? "";
            var sdt = (Controls.Find("txtSDT", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "";
            var diaChi = (Controls.Find("txtDiaChi", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "";
            var ngay = dtpNgayVaoLam.Value;
            var luong = (Controls.Find("txtLuong", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "0";

            string xml = BuildNhanSuXml(maNV, hoTen, chucVu, sdt, diaChi, ngay, luong);
            Fxml.Them(GetFullXmlPath(), xml);

            MessageBox.Show("Thêm nhân sự thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataGrid();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaNhanSuHienTai))
            {
                MessageBox.Show("Chọn nhân sự cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            var hoTen = (Controls.Find("txtHoTen", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "";
            var chucVu = cboChucVu.SelectedItem?.ToString() ?? "";
            var sdt = (Controls.Find("txtSDT", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "";
            var diaChi = (Controls.Find("txtDiaChi", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "";
            var ngay = dtpNgayVaoLam.Value;
            var luong = (Controls.Find("txtLuong", true).FirstOrDefault() as TextBox)?.Text.Trim() ?? "0";

            string innerXml = $@"
            <MaNhanSu>{MaNhanSuHienTai}</MaNhanSu>
            <HoTen>{System.Security.SecurityElement.Escape(hoTen)}</HoTen>
            <ChucVu>{System.Security.SecurityElement.Escape(chucVu)}</ChucVu>
            <SoDienThoai>{System.Security.SecurityElement.Escape(sdt)}</SoDienThoai>
            <DiaChi>{System.Security.SecurityElement.Escape(diaChi)}</DiaChi>
            <NgayVaoLam>{ngay:yyyy-MM-ddTHH:mm:ss+07:00}</NgayVaoLam>
            <Luong>{System.Security.SecurityElement.Escape(luong)}</Luong>";

            string xpath1 = $"/NhanSuData/NhanSu[MaNhanSu='{MaNhanSuHienTai}']";
            string xpath2 = $"/NewDataSet/NhanSu[MaNhanSu='{MaNhanSuHienTai}']";

            try { Fxml.sua(GetFullXmlPath(), xpath1, innerXml, "NhanSu"); }
            catch { Fxml.sua(GetFullXmlPath(), xpath2, innerXml, "NhanSu"); }

            MessageBox.Show("Cập nhật nhân sự thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataGrid();
            SetButtonsState(true);
            ClearInputFields();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaNhanSuHienTai))
            {
                MessageBox.Show("Chọn nhân sự cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa nhân sự {MaNhanSuHienTai}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string xpath1 = $"/NhanSuData/NhanSu[MaNhanSu='{MaNhanSuHienTai}']";
                string xpath2 = $"/NewDataSet/NhanSu[MaNhanSu='{MaNhanSuHienTai}']";

                try { Fxml.xoa(GetFullXmlPath(), xpath1); }
                catch { Fxml.xoa(GetFullXmlPath(), xpath2); }

                MessageBox.Show("Xóa nhân sự thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGrid();
                SetButtonsState(true);
                ClearInputFields();
            }
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            SetButtonsState(true);
            ClearInputFields();
        }
        private void dgvNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvNhanSu.Rows.Count <= e.RowIndex) return;

            var row = dgvNhanSu.Rows[e.RowIndex];

            MaNhanSuHienTai = row.Cells["MaNhanSu"]?.Value?.ToString() ?? "";
            if (Controls.Find("txtMaNhanSu", true).FirstOrDefault() is TextBox txtMa) txtMa.Text = MaNhanSuHienTai;

            if (Controls.Find("txtHoTen", true).FirstOrDefault() is TextBox txtHo) txtHo.Text = row.Cells["HoTen"]?.Value?.ToString() ?? "";
            cboChucVu.SelectedItem = row.Cells["ChucVu"]?.Value?.ToString() ?? cboChucVu.Items[0];
            if (Controls.Find("txtSDT", true).FirstOrDefault() is TextBox txtS) txtS.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? "";
            if (Controls.Find("txtDiaChi", true).FirstOrDefault() is TextBox txtD) txtD.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? "";
            if (Controls.Find("txtLuong", true).FirstOrDefault() is TextBox txtL) txtL.Text = row.Cells["Luong"]?.Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["NgayVaoLam"]?.Value?.ToString(), out DateTime ngay))
                dtpNgayVaoLam.Value = ngay;
            else dtpNgayVaoLam.Value = DateTime.Now;

            SetButtonsState(false);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click_1(object sender, EventArgs e)
        {

        }
    }
}
