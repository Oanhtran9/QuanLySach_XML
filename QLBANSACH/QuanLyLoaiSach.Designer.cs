namespace QLBANSACH
{
    partial class QuanLyLoaiSach
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
            txtTenTheLoaiSach = new TextBox();
            btnLamMoi = new Button();
            btnThem = new Button();
            btnSua = new Button();
            dgvTheLoaiSach = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SeaGreen;
            label1.Location = new Point(364, 56);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(465, 52);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ THỂ LOẠI SÁCH";
            // 
            // txtTenTheLoaiSach
            // 
            txtTenTheLoaiSach.Location = new Point(192, 167);
            txtTenTheLoaiSach.Margin = new Padding(4, 4, 4, 4);
            txtTenTheLoaiSach.Name = "txtTenTheLoaiSach";
            txtTenTheLoaiSach.PlaceholderText = "Tên thể loại sách";
            txtTenTheLoaiSach.Size = new Size(194, 39);
            txtTenTheLoaiSach.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.PaleTurquoise;
            btnLamMoi.Location = new Point(450, 167);
            btnLamMoi.Margin = new Padding(4, 4, 52, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(146, 44);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.PaleTurquoise;
            btnThem.Location = new Point(652, 167);
            btnThem.Margin = new Padding(4, 4, 52, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 44);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.PaleTurquoise;
            btnSua.Location = new Point(853, 167);
            btnSua.Margin = new Padding(4, 4, 52, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 44);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // dgvTheLoaiSach
            // 
            dgvTheLoaiSach.BackgroundColor = SystemColors.ButtonHighlight;
            dgvTheLoaiSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoaiSach.Location = new Point(0, 247);
            dgvTheLoaiSach.Margin = new Padding(4, 4, 4, 4);
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.RowHeadersWidth = 62;
            dgvTheLoaiSach.Size = new Size(1223, 373);
            dgvTheLoaiSach.TabIndex = 5;
            dgvTheLoaiSach.CellContentClick += dgvTheLoaiSach_CellContentClick;
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;
            // 
            // QuanLyLoaiSach
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(dgvTheLoaiSach);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTenTheLoaiSach);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "QuanLyLoaiSach";
            Size = new Size(1227, 685);
            Load += QuanLyLoaiSach_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenTheLoaiSach;
        private Button btnLamMoi;
        private Button btnThem;
        private Button btnSua;
        private DataGridView dgvTheLoaiSach;
    }
}
