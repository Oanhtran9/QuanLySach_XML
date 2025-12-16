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
            // 1. Lấy form 'App' chính
            // Chúng ta cần nó để gọi hàm LoadDataFromXml
            if (this.ParentForm is Form1 mainForm)
            {
                try
                {
                    // 2. Tải các bảng dữ liệu cần thiết từ XML
                    DataTable dtHoaDon = mainForm.LoadDataFromXml("HoaDon");
                    DataTable dtChiTiet = mainForm.LoadDataFromXml("ChiTietHoaDon");
                    DataTable dtSach = mainForm.LoadDataFromXml("Sach");

                    // 3. Tính toán các thống kê đơn giản

                    // --- Tổng doanh thu ---
                    // Tính tổng cột 'TongTien' trong bảng HoaDon
                    decimal tongDoanhThu = dtHoaDon.AsEnumerable()
                    .Sum(row => Convert.ToDecimal(row["TongTien"]));
                    lblTongDoanhThu.Text = $"{tongDoanhThu:N0} VNĐ";

                    // --- Tổng số đơn hàng ---
                    // Đếm số dòng trong bảng HoaDon
                    int tongDonHang = dtHoaDon.AsEnumerable().Count();
                    lblTongDonHang.Text = tongDonHang.ToString();

                    // 4. Tính toán thống kê phức tạp: Top sách bán chạy
                    // Dùng LINQ
                    var topSach = dtChiTiet.AsEnumerable()
                        .GroupBy(row => Convert.ToInt32(row["MaSach"])) // Dùng Convert
                        .Select(group => new
                        {
                            MaSach = group.Key,
                            TongSoLuong = group.Sum(row => Convert.ToInt32(row["SoLuong"])) // Sửa ở đây
                        })
                        .OrderByDescending(x => x.TongSoLuong)
                        .Take(5)
                        .Join(dtSach.AsEnumerable(),
                              ct => ct.MaSach,
                              s => Convert.ToInt32(s["MaSach"]), // Sửa luôn ở đây
                              (ct, s) => new
                              {
                                  TenSach = s.Field<string>("TenSach"),
                                  DaBan = ct.TongSoLuong
                              })
                        .ToList();

                    // 5. Hiển thị kết quả lên DataGridView
                    dgvTopSach.DataSource = topSach;

                    // Đổi tên cột cho đẹp
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
