namespace QLBANSACH
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnDangNhap = new Button();
            lblThongBao = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(524, 108);
            txtUserName.Margin = new Padding(2);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Nhập username";
            txtUserName.Size = new Size(167, 27);
            txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(524, 170);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Nhập password";
            txtPassword.Size = new Size(167, 27);
            txtPassword.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.RoyalBlue;
            btnDangNhap.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = SystemColors.ButtonHighlight;
            btnDangNhap.Location = new Point(534, 234);
            btnDangNhap.Margin = new Padding(2);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(132, 32);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Location = new Point(258, 266);
            lblThongBao.Margin = new Padding(2, 0, 2, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(0, 20);
            lblThongBao.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(401, 329);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(448, 108);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 27);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(448, 170);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 27);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Algerian", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(524, 15);
            label1.Name = "label1";
            label1.Size = new Size(152, 53);
            label1.TabIndex = 7;
            label1.Text = "LOGIN";
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblThongBao);
            Controls.Add(btnDangNhap);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Margin = new Padding(2);
            Name = "DangNhap";
            Size = new Size(755, 332);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnDangNhap;
        private Label lblThongBao;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
    }
}
