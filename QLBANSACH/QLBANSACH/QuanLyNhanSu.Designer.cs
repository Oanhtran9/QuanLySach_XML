namespace QLBANSACH
{
    partial class QuanLyNhanSu
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
            txtHoTen = new TextBox();
            txtLuong = new TextBox();
            txtSDT = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnHienThi = new Button();
            dgvNhanSu = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtDiaChi = new TextBox();
            dtpNgayVaoLam = new DateTimePicker();
            cboChucVu = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvNhanSu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(295, 0);
            label1.Name = "label1";
            label1.Size = new Size(233, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản lý nhân sự";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(78, 48);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(148, 27);
            txtHoTen.TabIndex = 1;
            // 
            // txtLuong
            // 
            txtLuong.Location = new Point(308, 111);
            txtLuong.Name = "txtLuong";
            txtLuong.Size = new Size(125, 27);
            txtLuong.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(78, 110);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(137, 27);
            txtSDT.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 52);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 4;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 52);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 5;
            label3.Text = "Chức vụ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(477, 57);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 6;
            label4.Text = "Địa chỉ :";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(28, 172);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(188, 172);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(356, 172);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(531, 172);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(94, 29);
            btnHienThi.TabIndex = 10;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click_1;
            // 
            // dgvNhanSu
            // 
            dgvNhanSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanSu.Location = new Point(15, 207);
            dgvNhanSu.Name = "dgvNhanSu";
            dgvNhanSu.RowHeadersWidth = 51;
            dgvNhanSu.Size = new Size(728, 126);
            dgvNhanSu.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 117);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 12;
            label5.Text = "SDT:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(450, 114);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 13;
            label6.Text = "Ngày làm việc:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(238, 118);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 14;
            label7.Text = "Lương:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(562, 52);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(181, 27);
            txtDiaChi.TabIndex = 15;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Location = new Point(562, 110);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(193, 27);
            dtpNgayVaoLam.TabIndex = 16;
            // 
            // cboChucVu
            // 
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(308, 49);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(135, 28);
            cboChucVu.TabIndex = 17;
            // 
            // QuanLyNhanSu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboChucVu);
            Controls.Add(dtpNgayVaoLam);
            Controls.Add(txtDiaChi);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dgvNhanSu);
            Controls.Add(btnHienThi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtSDT);
            Controls.Add(txtLuong);
            Controls.Add(txtHoTen);
            Controls.Add(label1);
            Name = "QuanLyNhanSu";
            Size = new Size(755, 332);
            ((System.ComponentModel.ISupportInitialize)dgvNhanSu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtHoTen;
        private TextBox txtLuong;
        private TextBox txtSDT;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnHienThi;
        private DataGridView dgvNhanSu;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtDiaChi;
        private DateTimePicker dtpNgayVaoLam;
        private ComboBox cboChucVu;
    }
}
