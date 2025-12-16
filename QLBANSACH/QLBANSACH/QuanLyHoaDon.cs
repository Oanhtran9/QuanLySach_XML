using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBANSACH
{
    public partial class QuanLyHoaDon : UserControl
    {
        private Form1 mainForm;

        private DataTable dtHoaDon;
        private DataTable dtChiTiet;
        private DataTable dtSach;
        private DataTable dtKhachHang;
        private TaoXML taoXML = new TaoXML();

        public QuanLyHoaDon()
        {
            InitializeComponent();
            this.Load += QuanLyHoaDon_Load;
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            if (mainForm == null)
                mainForm = this.FindForm() as Form1;

            LoadAllData();
            FormatGrids();
            btnTim.Click += BtnTim_Click;
            btnXemTatCa.Click += BtnXemTatCa_Click;
            dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;
        }
        private void LoadAllData()
        {
            dtHoaDon = mainForm.LoadDataFromXml("HoaDon") ?? new DataTable();
            dtChiTiet = mainForm.LoadDataFromXml("ChiTietHoaDon") ?? new DataTable();
            dtSach = mainForm.LoadDataFromXml("Sach") ?? new DataTable();
            dtKhachHang = mainForm.LoadDataFromXml("KhachHang") ?? new DataTable();

            dgvHoaDon.DataSource = dtHoaDon;
            dgvHoaDon.ClearSelection();
            dgvChiTiet.DataSource = null;
        }
        private void FormatGrids()
        {
            dgvHoaDon.AutoGenerateColumns = true;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvChiTiet.AutoGenerateColumns = true;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private DataTable JoinChiTietHoaDon(int maHD)
        {
            var query =
            from ct in dtChiTiet.AsEnumerable()
            where Convert.ToInt32(ct["MaHoaDon"]) == maHD
            join s in dtSach.AsEnumerable()
                on Convert.ToInt32(ct["MaSach"]) equals Convert.ToInt32(s["MaSach"])
            join hd in dtHoaDon.AsEnumerable()
                on Convert.ToInt32(ct["MaHoaDon"]) equals Convert.ToInt32(hd["MaHoaDon"])
            join kh in dtKhachHang.AsEnumerable()
                on Convert.ToInt32(hd["MaKhachHang"]) equals Convert.ToInt32(kh["MaKhachHang"])
            select new
            {
                MaCT = ct["MaCT"],
                MaHoaDon = ct["MaHoaDon"],
                MaSach = ct["MaSach"],
                TenSach = s["TenSach"],
                TenKhachHang = kh["TenKhachHang"],
                SoLuong = ct["SoLuong"],
                DonGia = ct["DonGia"],
                ThanhTien =
                    Convert.ToInt32(ct["SoLuong"]) * Convert.ToDecimal(ct["DonGia"])
            };
            DataTable result = new DataTable();
            result.Columns.Add("MaCT");
            result.Columns.Add("MaHoaDon");
            result.Columns.Add("MaSach");
            result.Columns.Add("TenSach");
            result.Columns.Add("TenKhachHang");
            result.Columns.Add("SoLuong");
            result.Columns.Add("DonGia");
            result.Columns.Add("ThanhTien");

            foreach (var r in query)
            {
                result.Rows.Add(
                    r.MaCT, r.MaHoaDon, r.MaSach,
                    r.TenSach, r.TenKhachHang,
                    r.SoLuong, r.DonGia, r.ThanhTien
                );
            }

            return result;
        }
        private void DgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null || dgvHoaDon.CurrentRow.DataBoundItem == null)
            {
                dgvChiTiet.DataSource = null;
                return;
            }

            int maHD = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
            dgvChiTiet.DataSource = JoinChiTietHoaDon(maHD);
        }
        private void BtnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim().ToLower();
            DataSet dsKH = new DataSet();
            dsKH.ReadXml(Application.StartupPath + "\\KhachHang.xml");
            DataTable dtKH = dsKH.Tables[0];
            var khMatch = dtKH.AsEnumerable()
                .Where(r =>
                    r["MaKhachHang"].ToString().ToLower().Contains(keyword) ||
                    r["TenKhachHang"].ToString().ToLower().Contains(keyword)
                ).Select(r => r["MaKhachHang"].ToString())
                .ToList();
            DataSet dsHD = new DataSet();
            dsHD.ReadXml(Application.StartupPath + "\\HoaDon.xml");
            DataTable dtHD = dsHD.Tables[0];

            var hd1 = dtHD.AsEnumerable()
                .Where(r => r["MaHoaDon"].ToString().ToLower().Contains(keyword));
            var hd2 = dtHD.AsEnumerable()
                .Where(r => khMatch.Contains(r["MaKhachHang"].ToString()));
            var kq = hd1.Union(hd2);

            if (!kq.Any())
            {
                dgvHoaDon.DataSource = null;
                dgvChiTiet.DataSource = null;
                MessageBox.Show("Không tìm thấy!");
                return;
            }

            dgvHoaDon.DataSource = kq.CopyToDataTable();
        }
        private void BtnXemTatCa_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            dgvHoaDon.DataSource = dtHoaDon;
            dgvChiTiet.DataSource = null;
        }

        private void btnXemTatCa_Click_1(object sender, EventArgs e)
        {

        }
    }
}
