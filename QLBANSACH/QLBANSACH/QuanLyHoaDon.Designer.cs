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
            label1.Location = new Point(17, 15);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 0;
            label1.Text = "Quản lý Hóa đơn";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.BackgroundColor = SystemColors.Control;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(31, 97);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(684, 144);
            dgvHoaDon.TabIndex = 1;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(31, 49);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(220, 27);
            txtTim.TabIndex = 2;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(270, 49);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 3;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // btnXemTatCa
            // 
            btnXemTatCa.Location = new Point(621, 48);
            btnXemTatCa.Name = "btnXemTatCa";
            btnXemTatCa.Size = new Size(94, 29);
            btnXemTatCa.TabIndex = 4;
            btnXemTatCa.Text = "Xem tất cả";
            btnXemTatCa.UseVisualStyleBackColor = true;
            btnXemTatCa.Click += btnXemTatCa_Click_1;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.BackgroundColor = SystemColors.Control;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(29, 273);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(688, 54);
            dgvChiTiet.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 250);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 6;
            label2.Text = "Chiết hóa đơn";
            // 
            // QuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(dgvChiTiet);
            Controls.Add(btnXemTatCa);
            Controls.Add(btnTim);
            Controls.Add(txtTim);
            Controls.Add(dgvHoaDon);
            Controls.Add(label1);
            Name = "QuanLyHoaDon";
            Size = new Size(755, 332);
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
