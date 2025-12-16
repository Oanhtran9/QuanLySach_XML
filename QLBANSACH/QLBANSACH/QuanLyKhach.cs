using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class QuanLyKhach : UserControl
    {
        private TaoXML taoXml = new TaoXML();

        private Form1 mainForm;
        private DataTable dtKhachHang;
        private DataTable dtHoaDon;

        private string tableName = "KhachHang";
        private string fileXML = "KhachHang.xml";

        private int maKH_HienTai = 0;

        public QuanLyKhach()
        {
            InitializeComponent();
        }

        private void QuanLyKhach_Load(object sender, EventArgs e)
        {
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTK.Click += btnTK_Click;

            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;

            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            if (mainForm == null) mainForm = (Form1)this.ParentForm;

            dtKhachHang = taoXml.loadDataGridView(fileXML);
            dtHoaDon = mainForm.LoadDataFromXml("HoaDon");

            dgvKhachHang.DataSource = dtKhachHang;

            if (dgvKhachHang.Columns["colXoa"] == null)
            {
                DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                btnXoa.Name = "colXoa";
                btnXoa.Text = "Xóa";
                btnXoa.HeaderText = "Hành động";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvKhachHang.Columns.Add(btnXoa);
            }

            btnLamMoi_Click(null, null);
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;

            try
            {
                DataGridViewRow r = dgvKhachHang.CurrentRow;

                maKH_HienTai = Convert.ToInt32(r.Cells["MaKhachHang"].Value);
                txtTenKH.Text = r.Cells["TenKhachHang"].Value.ToString();
                txtSDT.Text = r.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
            }
            catch { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            maKH_HienTai = 0;

            dgvKhachHang.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string dc = txtDiaChi.Text.Trim();

            if (ten == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống");
                return;
            }

            int maMoi = 1;
            if (dtKhachHang.Rows.Count > 0)
                maMoi = dtKhachHang.AsEnumerable().Max(r => r.Field<int>("MaKhachHang")) + 1;

            string xml =
                $"<KhachHang>" +
                $"<MaKhachHang>{maMoi}</MaKhachHang>" +
                $"<TenKhachHang>{ten}</TenKhachHang>" +
                $"<SoDienThoai>{sdt}</SoDienThoai>" +
                $"<DiaChi>{dc}</DiaChi>" +
                $"</KhachHang>";

            taoXml.Them(fileXML, xml);

            LoadDataGrid();
            MessageBox.Show("Thêm khách hàng thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maKH_HienTai == 0)
            {
                MessageBox.Show("Hãy chọn khách hàng!");
                return;
            }

            string ten = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string dc = txtDiaChi.Text.Trim();

            string xPath = $"//KhachHang[MaKhachHang='{maKH_HienTai}']";

            string xmlMoi =
                $"<MaKhachHang>{maKH_HienTai}</MaKhachHang>" +
                $"<TenKhachHang>{ten}</TenKhachHang>" +
                $"<SoDienThoai>{sdt}</SoDienThoai>" +
                $"<DiaChi>{dc}</DiaChi>";

            taoXml.sua(fileXML, xPath, xmlMoi, "KhachHang");

            LoadDataGrid();
            MessageBox.Show("Sửa thành công!");
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvKhachHang.Columns["colXoa"].Index || e.RowIndex < 0) return;

            int ma = Convert.ToInt32(dgvKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value);

            if (dtHoaDon.AsEnumerable().Any(r => r.Field<int>("MaKhachHang") == ma))
            {
                MessageBox.Show("Không thể xóa khách hàng đã có hóa đơn!");
                return;
            }

            string xPath = $"//KhachHang[MaKhachHang='{ma}']";
            taoXml.xoa(fileXML, xPath);

            LoadDataGrid();
            MessageBox.Show("Đã xóa!");
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string kw = txtTK.Text.Trim().ToLower();

            if (kw == "")
            {
                LoadDataGrid();
                return;
            }

            var rows = dtKhachHang.AsEnumerable()
                .Where(r =>
                    r["TenKhachHang"].ToString().ToLower().Contains(kw) ||
                    r["MaKhachHang"].ToString() == kw);

            if (rows.Any())
                dgvKhachHang.DataSource = rows.CopyToDataTable();
            else
                MessageBox.Show("Không tìm thấy!");
        }
    }
}
