namespace QLBANSACH
{
    partial class QuanLyKhach
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
            label1 = new Label();
            txtTenKH = new TextBox();
            txtSDT = new TextBox();
            txtDiaChi = new TextBox();
            btnLamMoi = new Button();
            btnThem = new Button();
            btnSua = new Button();
            dgvKhachHang = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTK = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            btnTK = new Button();
            btnHienThi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(253, 15);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(218, 31);
            label1.TabIndex = 0;
            label1.Text = "Quản lý khách hàng";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(91, 67);
            txtTenKH.Margin = new Padding(2, 2, 24, 2);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.PlaceholderText = "Tên khách hàng";
            txtTenKH.Size = new Size(157, 27);
            txtTenKH.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(362, 67);
            txtSDT.Margin = new Padding(2, 2, 24, 2);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "Số điện thoại";
            txtSDT.Size = new Size(121, 27);
            txtSDT.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(599, 65);
            txtDiaChi.Margin = new Padding(2, 2, 24, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Địa chỉ";
            txtDiaChi.Size = new Size(121, 27);
            txtDiaChi.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(112, 22);
            btnLamMoi.Margin = new Padding(2, 2, 24, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 27);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(219, 22);
            btnThem.Margin = new Padding(2, 2, 24, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 27);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(6, 22);
            btnSua.Margin = new Padding(2, 2, 24, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 27);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.BackgroundColor = SystemColors.Control;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(0, 186);
            dgvKhachHang.Margin = new Padding(2);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 62;
            dgvKhachHang.Size = new Size(755, 143);
            dgvKhachHang.TabIndex = 7;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 72);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 8;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 70);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 9;
            label3.Text = "SDT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(524, 72);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 10;
            label4.Text = "Địa chỉ:";
            // 
            // txtTK
            // 
            txtTK.Location = new Point(23, 23);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(166, 27);
            txtTK.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHienThi);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(btnLamMoi);
            panel1.Location = new Point(13, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 62);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnTK);
            panel2.Controls.Add(txtTK);
            panel2.Location = new Point(438, 120);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 63);
            panel2.TabIndex = 14;
            // 
            // btnTK
            // 
            btnTK.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTK.Location = new Point(195, 21);
            btnTK.Name = "btnTK";
            btnTK.Size = new Size(94, 29);
            btnTK.TabIndex = 12;
            btnTK.Text = "Tìm kiếm";
            btnTK.UseVisualStyleBackColor = true;
            btnTK.Click += btnTK_Click;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(322, 21);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(94, 29);
            btnHienThi.TabIndex = 7;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            // 
            // QuanLyKhach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvKhachHang);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSDT);
            Controls.Add(txtTenKH);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "QuanLyKhach";
            Size = new Size(755, 332);
            Load += QuanLyKhach_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private Button btnLamMoi;
        private Button btnThem;
        private Button btnSua;
        private DataGridView dgvKhachHang;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTK;
        private Panel panel1;
        private Panel panel2;
        private Button btnTK;
        private Button btnHienThi;
    }
}
