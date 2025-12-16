namespace QLBANSACH
{
    partial class DonHang
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
            cbKhachHang = new ComboBox();
            cbNhanSu = new ComboBox();
            lblNgayLap = new Label();
            btnTaoHoaDon = new Button();
            cbSach = new ComboBox();
            txtSoLuong = new TextBox();
            txtDonGia = new TextBox();
            dgvChiTiet = new DataGridView();
            label2 = new Label();
            btnThemChiTiet = new Button();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // cbKhachHang
            // 
            cbKhachHang.FormattingEnabled = true;
            cbKhachHang.Location = new Point(21, 61);
            cbKhachHang.Name = "cbKhachHang";
            cbKhachHang.Size = new Size(171, 28);
            cbKhachHang.TabIndex = 0;
            cbKhachHang.Text = "Mã khách hàng";
            cbKhachHang.SelectedIndexChanged += cbKhachHang_SelectedIndexChanged;
            // 
            // cbNhanSu
            // 
            cbNhanSu.FormattingEnabled = true;
            cbNhanSu.Location = new Point(239, 60);
            cbNhanSu.Name = "cbNhanSu";
            cbNhanSu.Size = new Size(151, 28);
            cbNhanSu.TabIndex = 1;
            cbNhanSu.Text = "Mã nhân sự";
            cbNhanSu.SelectedIndexChanged += cbNhanSu_SelectedIndexChanged;
            // 
            // lblNgayLap
            // 
            lblNgayLap.AutoSize = true;
            lblNgayLap.Location = new Point(433, 60);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(69, 20);
            lblNgayLap.TabIndex = 2;
            lblNgayLap.Text = "Ngày lập";
            // 
            // btnTaoHoaDon
            // 
            btnTaoHoaDon.Location = new Point(639, 51);
            btnTaoHoaDon.Name = "btnTaoHoaDon";
            btnTaoHoaDon.Size = new Size(94, 29);
            btnTaoHoaDon.TabIndex = 3;
            btnTaoHoaDon.Text = "Tạo";
            btnTaoHoaDon.UseVisualStyleBackColor = true;
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            // 
            // cbSach
            // 
            cbSach.FormattingEnabled = true;
            cbSach.Location = new Point(21, 109);
            cbSach.Name = "cbSach";
            cbSach.Size = new Size(171, 28);
            cbSach.TabIndex = 4;
            cbSach.Text = "Mã sách";
            cbSach.SelectedIndexChanged += cbSach_SelectedIndexChanged;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(239, 110);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(151, 27);
            txtSoLuong.TabIndex = 5;
            txtSoLuong.Text = "SL";
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(433, 109);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(145, 27);
            txtDonGia.TabIndex = 6;
            txtDonGia.Text = "Đơn giá";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(21, 156);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(712, 115);
            dgvChiTiet.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 286);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 8;
            label2.Text = "Tổng tiền:";
            label2.Click += label2_Click;
            // 
            // btnThemChiTiet
            // 
            btnThemChiTiet.Location = new Point(639, 107);
            btnThemChiTiet.Name = "btnThemChiTiet";
            btnThemChiTiet.Size = new Size(94, 29);
            btnThemChiTiet.TabIndex = 11;
            btnThemChiTiet.Text = "Thêm";
            btnThemChiTiet.UseVisualStyleBackColor = true;
            btnThemChiTiet.Click += btnThemChiTiet_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(212, 286);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(40, 20);
            lblTongTien.TabIndex = 12;
            lblTongTien.Text = "VND";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(541, 277);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(94, 29);
            btnThanhToan.TabIndex = 13;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(282, 10);
            label1.Name = "label1";
            label1.Size = new Size(220, 34);
            label1.TabIndex = 14;
            label1.Text = "TẠO HÓA ĐƠN";
            // 
            // DonHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            Controls.Add(label1);
            Controls.Add(btnThanhToan);
            Controls.Add(lblTongTien);
            Controls.Add(btnThemChiTiet);
            Controls.Add(label2);
            Controls.Add(dgvChiTiet);
            Controls.Add(txtDonGia);
            Controls.Add(txtSoLuong);
            Controls.Add(cbSach);
            Controls.Add(btnTaoHoaDon);
            Controls.Add(lblNgayLap);
            Controls.Add(cbNhanSu);
            Controls.Add(cbKhachHang);
            Name = "DonHang";
            Size = new Size(773, 320);
            Load += QuanLyDonHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbKhachHang;
        private ComboBox cbNhanSu;
        private Label lblNgayLap;
        private Button btnTaoHoaDon;
        private ComboBox cbSach;
        private TextBox txtSoLuong;
        private TextBox txtDonGia;
        private DataGridView dgvChiTiet;
        private Label label2;
        private Button btnThemChiTiet;
        private Label lblTongTien;
        private Button btnThanhToan;
        private Label label1;
    }
}
