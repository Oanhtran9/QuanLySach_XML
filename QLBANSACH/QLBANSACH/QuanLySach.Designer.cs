namespace QLBANSACH
{
    partial class QuanLySach
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
            txtTenSach = new TextBox();
            cbTheLoai = new ComboBox();
            cbTacGia = new ComboBox();
            txtGiaBan = new TextBox();
            txtSoLuong = new TextBox();
            dgvSach = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Quản lý sách";
            label1.Click += label1_Click;
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(22, 46);
            txtTenSach.Margin = new Padding(2, 2, 8, 2);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.PlaceholderText = "Tên sách";
            txtTenSach.Size = new Size(121, 27);
            txtTenSach.TabIndex = 1;
            txtTenSach.TextChanged += txtTenSach_TextChanged;
            // 
            // cbTheLoai
            // 
            cbTheLoai.FormattingEnabled = true;
            cbTheLoai.Location = new Point(152, 46);
            cbTheLoai.Margin = new Padding(2, 2, 8, 2);
            cbTheLoai.Name = "cbTheLoai";
            cbTheLoai.Size = new Size(146, 28);
            cbTheLoai.TabIndex = 2;
            // 
            // cbTacGia
            // 
            cbTacGia.FormattingEnabled = true;
            cbTacGia.Location = new Point(308, 46);
            cbTacGia.Margin = new Padding(2, 2, 8, 2);
            cbTacGia.Name = "cbTacGia";
            cbTacGia.Size = new Size(146, 28);
            cbTacGia.TabIndex = 3;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(464, 46);
            txtGiaBan.Margin = new Padding(2, 2, 8, 2);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.PlaceholderText = "Giá bán";
            txtGiaBan.Size = new Size(121, 27);
            txtGiaBan.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(594, 46);
            txtSoLuong.Margin = new Padding(2, 2, 8, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.PlaceholderText = "Số lượng";
            txtSoLuong.Size = new Size(121, 27);
            txtSoLuong.TabIndex = 5;
            // 
            // dgvSach
            // 
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSach.Location = new Point(2, 192);
            dgvSach.Margin = new Padding(2, 2, 2, 2);
            dgvSach.Name = "dgvSach";
            dgvSach.RowHeadersWidth = 62;
            dgvSach.Size = new Size(750, 138);
            dgvSach.TabIndex = 6;
            dgvSach.CellContentClick += dgvSach_CellContentClick;
            dgvSach.SelectionChanged += dgvSach_SelectionChanged;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(268, 123);
            btnThem.Margin = new Padding(2, 2, 24, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 27);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(384, 123);
            btnSua.Margin = new Padding(2, 2, 24, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 27);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(152, 123);
            btnLamMoi.Margin = new Padding(2, 2, 24, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 27);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // QuanLySach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLamMoi);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvSach);
            Controls.Add(txtSoLuong);
            Controls.Add(txtGiaBan);
            Controls.Add(cbTacGia);
            Controls.Add(cbTheLoai);
            Controls.Add(txtTenSach);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "QuanLySach";
            Size = new Size(755, 332);
            Load += QuanLySach_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenSach;
        private ComboBox cbTheLoai;
        private ComboBox cbTacGia;
        private TextBox txtGiaBan;
        private TextBox txtSoLuong;
        private DataGridView dgvSach;
        private Button btnThem;
        private Button btnSua;
        private Button btnLamMoi;
    }
}
