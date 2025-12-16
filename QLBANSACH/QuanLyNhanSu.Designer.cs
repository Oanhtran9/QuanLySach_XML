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
            label1.BackColor = Color.LavenderBlush;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(391, 24);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(457, 65);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ NHÂN SỰ";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(113, 135);
            txtHoTen.Margin = new Padding(5);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(238, 39);
            txtHoTen.TabIndex = 1;
            // 
            // txtLuong
            // 
            txtLuong.Location = new Point(486, 236);
            txtLuong.Margin = new Padding(5);
            txtLuong.Name = "txtLuong";
            txtLuong.Size = new Size(201, 39);
            txtLuong.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(113, 234);
            txtSDT.Margin = new Padding(5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(220, 39);
            txtSDT.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 141);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 32);
            label2.TabIndex = 4;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 141);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 32);
            label3.TabIndex = 5;
            label3.Text = "Chức vụ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(761, 149);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(99, 32);
            label4.TabIndex = 6;
            label4.Text = "Địa chỉ :";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.LemonChiffon;
            btnThem.Location = new Point(114, 337);
            btnThem.Margin = new Padding(5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(153, 46);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click_1;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.LemonChiffon;
            btnSua.Location = new Point(374, 337);
            btnSua.Margin = new Padding(5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(153, 46);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.LemonChiffon;
            btnXoa.Location = new Point(646, 337);
            btnXoa.Margin = new Padding(5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(153, 46);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnHienThi
            // 
            btnHienThi.BackColor = Color.LemonChiffon;
            btnHienThi.Location = new Point(931, 337);
            btnHienThi.Margin = new Padding(5);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(153, 46);
            btnHienThi.TabIndex = 10;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = false;
            // 
            // dgvNhanSu
            // 
            dgvNhanSu.BackgroundColor = SystemColors.ButtonHighlight;
            dgvNhanSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanSu.Location = new Point(10, 407);
            dgvNhanSu.Margin = new Padding(5);
            dgvNhanSu.Name = "dgvNhanSu";
            dgvNhanSu.RowHeadersWidth = 51;
            dgvNhanSu.Size = new Size(1183, 256);
            dgvNhanSu.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 245);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 32);
            label5.TabIndex = 12;
            label5.Text = "SDT:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(717, 240);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(170, 32);
            label6.TabIndex = 13;
            label6.Text = "Ngày làm việc:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(373, 247);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(86, 32);
            label7.TabIndex = 14;
            label7.Text = "Lương:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(899, 141);
            txtDiaChi.Margin = new Padding(5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(292, 39);
            txtDiaChi.TabIndex = 15;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Location = new Point(899, 234);
            dtpNgayVaoLam.Margin = new Padding(5);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(311, 39);
            dtpNgayVaoLam.TabIndex = 16;
            // 
            // cboChucVu
            // 
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(486, 136);
            cboChucVu.Margin = new Padding(5);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(217, 40);
            cboChucVu.TabIndex = 17;
            // 
            // QuanLyNhanSu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
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
            Margin = new Padding(5);
            Name = "QuanLyNhanSu";
            Size = new Size(1227, 685);
            Load += QuanLyNhanSu_Load;
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
