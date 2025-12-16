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
            txtUserName.Location = new Point(852, 215);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Nhập username";
            txtUserName.Size = new Size(269, 39);
            txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(852, 314);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Nhập password";
            txtPassword.Size = new Size(269, 39);
            txtPassword.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.RoyalBlue;
            btnDangNhap.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = SystemColors.ButtonHighlight;
            btnDangNhap.Location = new Point(868, 416);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(214, 51);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.ForeColor = Color.Red;
            lblThongBao.Location = new Point(717, 488);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(0, 32);
            lblThongBao.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(-11, 0);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(652, 675);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(728, 215);
            pictureBox2.Margin = new Padding(5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 43);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(728, 314);
            pictureBox3.Margin = new Padding(5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(67, 43);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(717, 50);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(490, 85);
            label1.TabIndex = 7;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
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
            Name = "DangNhap";
            Size = new Size(1227, 685);
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
