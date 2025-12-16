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
            label1.BackColor = Color.DarkSeaGreen;
            label1.Font = new Font("Segoe UI Semibold", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(507, 44);
            label1.Name = "label1";
            label1.Size = new Size(281, 50);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ SÁCH";
            label1.Click += label1_Click;
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(33, 190);
            txtTenSach.Margin = new Padding(3, 3, 13, 3);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.PlaceholderText = "Tên sách";
            txtTenSach.Size = new Size(194, 39);
            txtTenSach.TabIndex = 1;
            txtTenSach.TextChanged += txtTenSach_TextChanged;
            // 
            // cbTheLoai
            // 
            cbTheLoai.FormattingEnabled = true;
            cbTheLoai.Location = new Point(244, 190);
            cbTheLoai.Margin = new Padding(3, 3, 13, 3);
            cbTheLoai.Name = "cbTheLoai";
            cbTheLoai.Size = new Size(235, 40);
            cbTheLoai.TabIndex = 2;
            // 
            // cbTacGia
            // 
            cbTacGia.FormattingEnabled = true;
            cbTacGia.Location = new Point(497, 190);
            cbTacGia.Margin = new Padding(3, 3, 13, 3);
            cbTacGia.Name = "cbTacGia";
            cbTacGia.Size = new Size(235, 40);
            cbTacGia.TabIndex = 3;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(751, 190);
            txtGiaBan.Margin = new Padding(3, 3, 13, 3);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.PlaceholderText = "Giá bán";
            txtGiaBan.Size = new Size(194, 39);
            txtGiaBan.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(962, 190);
            txtSoLuong.Margin = new Padding(3, 3, 13, 3);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.PlaceholderText = "Số lượng";
            txtSoLuong.Size = new Size(194, 39);
            txtSoLuong.TabIndex = 5;
            // 
            // dgvSach
            // 
            dgvSach.BackgroundColor = SystemColors.ButtonHighlight;
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSach.Location = new Point(0, 423);
            dgvSach.Name = "dgvSach";
            dgvSach.RowHeadersWidth = 62;
            dgvSach.Size = new Size(1219, 221);
            dgvSach.TabIndex = 6;
            dgvSach.CellContentClick += dgvSach_CellContentClick;
            dgvSach.SelectionChanged += dgvSach_SelectionChanged;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.PowderBlue;
            btnThem.Location = new Point(527, 315);
            btnThem.Margin = new Padding(3, 3, 39, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 43);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.PowderBlue;
            btnSua.Location = new Point(715, 315);
            btnSua.Margin = new Padding(3, 3, 39, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 43);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.PowderBlue;
            btnLamMoi.Location = new Point(338, 315);
            btnLamMoi.Margin = new Padding(3, 3, 39, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(146, 43);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // QuanLySach
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
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
            Name = "QuanLySach";
            Size = new Size(1227, 685);
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
