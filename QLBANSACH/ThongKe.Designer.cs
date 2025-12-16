namespace QLBANSACH
{
    partial class ThongKe
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
            label2 = new Label();
            label3 = new Label();
            lblTongDoanhThu = new Label();
            lblTongDonHang = new Label();
            dgvTopSach = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTopSach).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 26);
            label1.Name = "label1";
            label1.Size = new Size(187, 32);
            label1.TabIndex = 0;
            label1.Text = "Tổng doanh thu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 101);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 1;
            label2.Text = "Tổng đơn hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 163);
            label3.Name = "label3";
            label3.Size = new Size(167, 32);
            label3.TabIndex = 2;
            label3.Text = "Sách bán chạy";
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Location = new Point(263, 26);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(84, 32);
            lblTongDoanhThu.TabIndex = 3;
            lblTongDoanhThu.Text = "0 VNĐ";
            lblTongDoanhThu.Click += label4_Click;
            // 
            // lblTongDonHang
            // 
            lblTongDonHang.AutoSize = true;
            lblTongDonHang.Location = new Point(263, 101);
            lblTongDonHang.Name = "lblTongDonHang";
            lblTongDonHang.Size = new Size(27, 32);
            lblTongDonHang.TabIndex = 4;
            lblTongDonHang.Text = "0";
            // 
            // dgvTopSach
            // 
            dgvTopSach.BackgroundColor = SystemColors.Control;
            dgvTopSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopSach.Location = new Point(0, 224);
            dgvTopSach.Name = "dgvTopSach";
            dgvTopSach.RowHeadersWidth = 62;
            dgvTopSach.Size = new Size(1219, 438);
            dgvTopSach.TabIndex = 5;
            dgvTopSach.CellContentClick += dgvTopSach_CellContentClick;
            // 
            // ThongKe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            Controls.Add(dgvTopSach);
            Controls.Add(lblTongDonHang);
            Controls.Add(lblTongDoanhThu);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ThongKe";
            Size = new Size(1227, 685);
            Load += ThongKe_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTopSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblTongDoanhThu;
        private Label lblTongDonHang;
        private DataGridView dgvTopSach;
    }
}
