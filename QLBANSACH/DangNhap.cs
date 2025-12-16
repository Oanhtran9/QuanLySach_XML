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
    public partial class DangNhap : UserControl
    {
        public event EventHandler LoginSuccess;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Text;

            if (UserSession.DangNhap(user, pass))
            {
                // 2. Nếu đăng nhập thành công, phát sự kiện (raise event)
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Nếu thất bại, hiển thị thông báo
                lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
