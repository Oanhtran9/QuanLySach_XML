using System;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class Form2 : Form
    {
        public Form2(int maHoaDon, string khachHang, string nhanVien, DateTime ngayLap, DataTable detailsTable, decimal tongTien)
        {
            InitializeComponent();

            this.Text = $"Hóa đơn Bán sách #{maHoaDon}";

            try
            {
                lblMaHD.Text = maHoaDon.ToString();
                lblNgayLap.Text = ngayLap.ToString("dd/MM/yyyy HH:mm:ss");
                lblKhachHang.Text = khachHang;
                lblNhanVien.Text = nhanVien;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Lỗi: Không tìm thấy một hoặc nhiều controls (Label) trên Form2. Vui lòng kiểm tra lại tên biến.");
                return;
            }
            dgvInvoiceDetails.DataSource = detailsTable;

            if (dgvInvoiceDetails.Columns.Contains("MaSach"))
            {
                dgvInvoiceDetails.Columns["MaSach"].Visible = false;
            }
            dgvInvoiceDetails.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvInvoiceDetails.Columns["SoLuong"].HeaderText = "SL";
            dgvInvoiceDetails.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvInvoiceDetails.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            dgvInvoiceDetails.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvInvoiceDetails.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvInvoiceDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceDetails.ReadOnly = true;
            lblTongTienCuoi.Text = $"{tongTien:N0} VNĐ";
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}