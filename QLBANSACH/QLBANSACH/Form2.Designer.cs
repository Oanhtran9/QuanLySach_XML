namespace QLBANSACH
{
    partial class Form2
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblMaHD = new Label();
            lblKhachHang = new Label();
            lblNhanVien = new Label();
            dgvInvoiceDetails = new DataGridView();
            lblNgayLap = new Label();
            label12 = new Label();
            lblTongTienCuoi = new Label();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetails).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 37);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Rockwell", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 19);
            label2.Name = "label2";
            label2.Size = new Size(189, 38);
            label2.TabIndex = 1;
            label2.Text = "BORCELLE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 57);
            label3.Name = "label3";
            label3.Size = new Size(331, 20);
            label3.TabIndex = 2;
            label3.Text = "========= Hóa đơn bán hàng ==========";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 93);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 3;
            label4.Text = "Mã HD:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 132);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 4;
            label5.Text = "Khách hàng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(126, 172);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 5;
            label6.Text = "Nhân viên:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(513, 106);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 6;
            label7.Text = "Ngày lập:";
            // 
            // lblMaHD
            // 
            lblMaHD.AutoSize = true;
            lblMaHD.Location = new Point(221, 98);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(50, 20);
            lblMaHD.TabIndex = 7;
            lblMaHD.Text = "label8";
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(223, 133);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(50, 20);
            lblKhachHang.TabIndex = 8;
            lblKhachHang.Text = "label9";
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(225, 175);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(58, 20);
            lblNhanVien.TabIndex = 9;
            lblNhanVien.Text = "label10";
            // 
            // dgvInvoiceDetails
            // 
            dgvInvoiceDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceDetails.Location = new Point(52, 219);
            dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            dgvInvoiceDetails.RowHeadersWidth = 51;
            dgvInvoiceDetails.Size = new Size(666, 117);
            dgvInvoiceDetails.TabIndex = 10;
            // 
            // lblNgayLap
            // 
            lblNgayLap.AutoSize = true;
            lblNgayLap.Location = new Point(588, 107);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(58, 20);
            lblNgayLap.TabIndex = 11;
            lblNgayLap.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(530, 358);
            label12.Name = "label12";
            label12.Size = new Size(83, 20);
            label12.TabIndex = 12;
            label12.Text = "Tổng cộng:";
            // 
            // lblTongTienCuoi
            // 
            lblTongTienCuoi.AutoSize = true;
            lblTongTienCuoi.Location = new Point(617, 358);
            lblTongTienCuoi.Name = "lblTongTienCuoi";
            lblTongTienCuoi.Size = new Size(58, 20);
            lblTongTienCuoi.TabIndex = 13;
            lblTongTienCuoi.Text = "label13";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(676, 19);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(lblTongTienCuoi);
            Controls.Add(label12);
            Controls.Add(lblNgayLap);
            Controls.Add(dgvInvoiceDetails);
            Controls.Add(lblNhanVien);
            Controls.Add(lblKhachHang);
            Controls.Add(lblMaHD);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblMaHD;
        private Label lblKhachHang;
        private Label lblNhanVien;
        private DataGridView dgvInvoiceDetails;
        private Label lblNgayLap;
        private Label label12;
        private Label lblTongTienCuoi;
        private Button btnThoat;
    }
}