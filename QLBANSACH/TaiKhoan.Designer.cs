namespace QLBANSACH
{
    partial class TaiKhoan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstNguoiDung = new ListBox();
            btnChon = new Button();
            btnCapNhat = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTenDangNhap = new TextBox();
            txtMKHienTai = new TextBox();
            txtMKMoi = new TextBox();
            txtNhapLai = new TextBox();
            SuspendLayout();
            // 
            // lstNguoiDung
            // 
            lstNguoiDung.FormattingEnabled = true;
            lstNguoiDung.Location = new Point(107, 22);
            lstNguoiDung.Margin = new Padding(5, 5, 5, 5);
            lstNguoiDung.Name = "lstNguoiDung";
            lstNguoiDung.Size = new Size(1005, 164);
            lstNguoiDung.TabIndex = 0;
            // 
            // btnChon
            // 
            btnChon.BackColor = SystemColors.GradientActiveCaption;
            btnChon.Location = new Point(150, 230);
            btnChon.Margin = new Padding(5, 5, 5, 5);
            btnChon.Name = "btnChon";
            btnChon.Size = new Size(153, 46);
            btnChon.TabIndex = 1;
            btnChon.Text = "Chọn";
            btnChon.UseVisualStyleBackColor = false;
            btnChon.Click += btnChon_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = SystemColors.GradientActiveCaption;
            btnCapNhat.Location = new Point(873, 216);
            btnCapNhat.Margin = new Padding(5, 5, 5, 5);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(153, 46);
            btnCapNhat.TabIndex = 2;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 315);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(179, 32);
            label1.TabIndex = 3;
            label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 400);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(207, 32);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu hiện tại:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(655, 315);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(168, 32);
            label3.TabIndex = 5;
            label3.Text = "Mật khẩu mới:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(655, 400);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(216, 32);
            label4.TabIndex = 6;
            label4.Text = "Nhập lại Mật khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(322, 310);
            txtTenDangNhap.Margin = new Padding(5, 5, 5, 5);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(201, 39);
            txtTenDangNhap.TabIndex = 7;
            // 
            // txtMKHienTai
            // 
            txtMKHienTai.Location = new Point(322, 395);
            txtMKHienTai.Margin = new Padding(5, 5, 5, 5);
            txtMKHienTai.Name = "txtMKHienTai";
            txtMKHienTai.Size = new Size(201, 39);
            txtMKHienTai.TabIndex = 8;
            // 
            // txtMKMoi
            // 
            txtMKMoi.Location = new Point(873, 310);
            txtMKMoi.Margin = new Padding(5, 5, 5, 5);
            txtMKMoi.Name = "txtMKMoi";
            txtMKMoi.Size = new Size(201, 39);
            txtMKMoi.TabIndex = 9;
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(873, 395);
            txtNhapLai.Margin = new Padding(5, 5, 5, 5);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(201, 39);
            txtNhapLai.TabIndex = 10;
            // 
            // TaiKhoan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            Controls.Add(txtNhapLai);
            Controls.Add(txtMKMoi);
            Controls.Add(txtMKHienTai);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCapNhat);
            Controls.Add(btnChon);
            Controls.Add(lstNguoiDung);
            Margin = new Padding(5, 5, 5, 5);
            Name = "TaiKhoan";
            Size = new Size(1227, 685);
            Load += TaiKhoan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstNguoiDung;
        private Button btnChon;
        private Button btnCapNhat;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTenDangNhap;
        private TextBox txtMKHienTai;
        private TextBox txtMKMoi;
        private TextBox txtNhapLai;
    }
}
