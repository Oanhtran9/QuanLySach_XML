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
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 25);
            label1.TabIndex = 0;
            label1.Text = "Quản lý thể loại sách";
            // 
            // txtTenTheLoaiSach
            // 
            txtTenTheLoaiSach.Location = new Point(29, 60);
            txtTenTheLoaiSach.Name = "txtTenTheLoaiSach";
            txtTenTheLoaiSach.PlaceholderText = "Tên thể loại sách";
            txtTenTheLoaiSach.Size = new Size(150, 31);
            txtTenTheLoaiSach.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(228, 60);
            btnLamMoi.Margin = new Padding(3, 3, 40, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 34);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(383, 60);
            btnThem.Margin = new Padding(3, 3, 40, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(538, 60);
            btnSua.Margin = new Padding(3, 3, 40, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // dgvTheLoaiSach
            // 
            dgvTheLoaiSach.BackgroundColor = SystemColors.Control;
            dgvTheLoaiSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoaiSach.Location = new Point(0, 127);
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.RowHeadersWidth = 62;
            dgvTheLoaiSach.Size = new Size(941, 288);
            dgvTheLoaiSach.TabIndex = 5;
            dgvTheLoaiSach.CellContentClick += dgvTheLoaiSach_CellContentClick;
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;
            // 
            // QuanLyLoaiSach
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTheLoaiSach);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTenTheLoaiSach);
            Controls.Add(label1);
            Name = "QuanLyLoaiSach";
            Size = new Size(944, 415);
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
