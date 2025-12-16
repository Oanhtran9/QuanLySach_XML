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
            btnHienThi = new Button();
            panel2 = new Panel();
            btnTK = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(411, 24);
            label1.Name = "label1";
            label1.Size = new Size(356, 50);
            label1.TabIndex = 0;
            label1.Text = "Quản lý khách hàng";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(148, 107);
            txtTenKH.Margin = new Padding(3, 3, 39, 3);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.PlaceholderText = "Tên khách hàng";
            txtTenKH.Size = new Size(253, 39);
            txtTenKH.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(588, 107);
            txtSDT.Margin = new Padding(3, 3, 39, 3);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "Số điện thoại";
            txtSDT.Size = new Size(194, 39);
            txtSDT.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(973, 104);
            txtDiaChi.Margin = new Padding(3, 3, 39, 3);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Địa chỉ";
            txtDiaChi.Size = new Size(194, 39);
            txtDiaChi.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(182, 35);
            btnLamMoi.Margin = new Padding(3, 3, 39, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(146, 43);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(356, 35);
            btnThem.Margin = new Padding(3, 3, 39, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 43);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(10, 35);
            btnSua.Margin = new Padding(3, 3, 39, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 43);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.BackgroundColor = SystemColors.ButtonHighlight;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(3, 324);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 62;
            dgvKhachHang.Size = new Size(1227, 339);
            dgvKhachHang.TabIndex = 7;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 115);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 32);
            label2.TabIndex = 8;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(486, 112);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 32);
            label3.TabIndex = 9;
            label3.Text = "SDT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(852, 115);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(92, 32);
            label4.TabIndex = 10;
            label4.Text = "Địa chỉ:";
            // 
            // txtTK
            // 
            txtTK.Location = new Point(37, 37);
            txtTK.Margin = new Padding(5, 5, 5, 5);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(267, 39);
            txtTK.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(btnHienThi);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(btnLamMoi);
            panel1.Location = new Point(21, 194);
            panel1.Margin = new Padding(5, 5, 5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(681, 99);
            panel1.TabIndex = 13;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(523, 34);
            btnHienThi.Margin = new Padding(5, 5, 5, 5);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(153, 46);
            btnHienThi.TabIndex = 7;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Linen;
            panel2.Controls.Add(btnTK);
            panel2.Controls.Add(txtTK);
            panel2.Location = new Point(712, 192);
            panel2.Margin = new Padding(5, 5, 5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(496, 101);
            panel2.TabIndex = 14;
            // 
            // btnTK
            // 
            btnTK.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTK.Location = new Point(317, 34);
            btnTK.Margin = new Padding(5, 5, 5, 5);
            btnTK.Name = "btnTK";
            btnTK.Size = new Size(153, 46);
            btnTK.TabIndex = 12;
            btnTK.Text = "Tìm kiếm";
            btnTK.UseVisualStyleBackColor = true;
            btnTK.Click += btnTK_Click;
            // 
            // QuanLyKhach
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
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
            Name = "QuanLyKhach";
            Size = new Size(1227, 685);
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
