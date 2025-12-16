namespace QLBANSACH
{
    partial class QuanLyHoaDon
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
            dgvHoaDon = new DataGridView();
            txtTim = new TextBox();
            btnTim = new Button();
            btnXemTatCa = new Button();
            dgvChiTiet = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(480, 22);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(314, 45);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ HOÁ ĐƠN";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.BackgroundColor = SystemColors.ButtonHighlight;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(50, 179);
            dgvHoaDon.Margin = new Padding(5, 5, 5, 5);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(1112, 206);
            dgvHoaDon.TabIndex = 1;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(316, 84);
            txtTim.Margin = new Padding(5, 5, 5, 5);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(355, 39);
            txtTim.TabIndex = 2;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.LightCyan;
            btnTim.Location = new Point(713, 78);
            btnTim.Margin = new Padding(5, 5, 5, 5);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(153, 46);
            btnTim.TabIndex = 3;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // btnXemTatCa
            // 
            btnXemTatCa.Location = new Point(1009, 77);
            btnXemTatCa.Margin = new Padding(5, 5, 5, 5);
            btnXemTatCa.Name = "btnXemTatCa";
            btnXemTatCa.Size = new Size(153, 46);
            btnXemTatCa.TabIndex = 4;
            btnXemTatCa.Text = "Xem tất cả";
            btnXemTatCa.UseVisualStyleBackColor = true;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.BackgroundColor = SystemColors.ButtonHighlight;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(47, 437);
            dgvChiTiet.Margin = new Padding(5, 5, 5, 5);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(1118, 198);
            dgvChiTiet.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 400);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 32);
            label2.TabIndex = 6;
            label2.Text = "Chiết hóa đơn";
            // 
            // QuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            Controls.Add(label2);
            Controls.Add(dgvChiTiet);
            Controls.Add(btnXemTatCa);
            Controls.Add(btnTim);
            Controls.Add(txtTim);
            Controls.Add(dgvHoaDon);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "QuanLyHoaDon";
            Size = new Size(1227, 685);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvHoaDon;
        private TextBox txtTim;
        private Button btnTim;
        private Button btnXemTatCa;
        private DataGridView dgvChiTiet;
        private Label label2;
    }
}
