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
    public partial class ThongKe : UserControl
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 mainForm)
            {
                try
                {
                    DataTable dtHoaDon = mainForm.LoadDataFromXml("HoaDon");
                    DataTable dtChiTiet = mainForm.LoadDataFromXml("ChiTietHoaDon");
                    DataTable dtSach = mainForm.LoadDataFromXml("Sach");

                    decimal tongDoanhThu = dtHoaDon.AsEnumerable()
                    .Sum(row => Convert.ToDecimal(row["TongTien"]));
                    lblTongDoanhThu.Text = $"{tongDoanhThu:N0} VNĐ";
                    int tongDonHang = dtHoaDon.AsEnumerable().Count();
                    lblTongDonHang.Text = tongDonHang.ToString();
                    
                    var topSach = dtChiTiet.AsEnumerable()
                        .GroupBy(row => Convert.ToInt32(row["MaSach"])) 
                        .Select(group => new
                        {
                            MaSach = group.Key,
                            TongSoLuong = group.Sum(row => Convert.ToInt32(row["SoLuong"])) 
                        })
                        .OrderByDescending(x => x.TongSoLuong)
                        .Take(5)
                        .Join(dtSach.AsEnumerable(),
                              ct => ct.MaSach,
                              s => Convert.ToInt32(s["MaSach"]),
                              (ct, s) => new
                              {
                                  TenSach = s.Field<string>("TenSach"),
                                  DaBan = ct.TongSoLuong
                              })
                        .ToList();
                    dgvTopSach.DataSource = topSach;
                    if (dgvTopSach.Columns.Count >= 2)
                    {
                        dgvTopSach.Columns["TenSach"].HeaderText = "Tên Sách";
                        dgvTopSach.Columns["DaBan"].HeaderText = "Đã Bán (Cuốn)";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thống kê từ XML: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không thể kết nối với Form chính!");
            }
        }

        private void dgvTopSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
