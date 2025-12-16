namespace QLBANSACH
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuTrangChu = new ToolStripMenuItem();
            đăngNhậpToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            tàiKhoảnToolStripMenuItem1 = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuQLSACH = new ToolStripMenuItem();
            mnuQLKHACHHANG = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            sáchToolStripMenuItem = new ToolStripMenuItem();
            loạiToolStripMenuItem = new ToolStripMenuItem();
            hóaĐơnToolStripMenuItem = new ToolStripMenuItem();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            chuyểnĐổiXMLToolStripMenuItem = new ToolStripMenuItem();
            mnuChuyenDoiXmlSangSql = new ToolStripMenuItem();
            mnuChuyenDoiSqlSangXml = new ToolStripMenuItem();
            panelContent = new Panel();
            hóaĐơnToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Goldenrod;
            menuStrip1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuTrangChu, mnuQuanLy, quảnLýToolStripMenuItem, thốngKêToolStripMenuItem, chuyểnĐổiXMLToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(755, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuTrangChu
            // 
            mnuTrangChu.DropDownItems.AddRange(new ToolStripItem[] { đăngNhậpToolStripMenuItem, đăngXuấtToolStripMenuItem, tàiKhoảnToolStripMenuItem1 });
            mnuTrangChu.Name = "mnuTrangChu";
            mnuTrangChu.Size = new Size(91, 24);
            mnuTrangChu.Text = "Trang chủ";
            mnuTrangChu.Click += mnuTrangChu_Click;
            // 
            // đăngNhậpToolStripMenuItem
            // 
            đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            đăngNhậpToolStripMenuItem.Size = new Size(224, 26);
            đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
            đăngNhậpToolStripMenuItem.Click += đăngNhậpToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(224, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // tàiKhoảnToolStripMenuItem1
            // 
            tàiKhoảnToolStripMenuItem1.Name = "tàiKhoảnToolStripMenuItem1";
            tàiKhoảnToolStripMenuItem1.Size = new Size(224, 26);
            tàiKhoảnToolStripMenuItem1.Text = "Tài khoản";
            tàiKhoảnToolStripMenuItem1.Click += tàiKhoảnToolStripMenuItem1_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuQLSACH, mnuQLKHACHHANG });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(160, 24);
            mnuQuanLy.Text = "Quản lý người dùng";
            // 
            // mnuQLSACH
            // 
            mnuQLSACH.Name = "mnuQLSACH";
            mnuQLSACH.Size = new Size(173, 26);
            mnuQLSACH.Text = "Nhân viên";
            mnuQLSACH.Click += mnuQLSACH_Click;
            // 
            // mnuQLKHACHHANG
            // 
            mnuQLKHACHHANG.Name = "mnuQLKHACHHANG";
            mnuQLKHACHHANG.Size = new Size(173, 26);
            mnuQLKHACHHANG.Text = "Khách hàng";
            mnuQLKHACHHANG.Click += mnuQLKHACHHANG_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sáchToolStripMenuItem, loạiToolStripMenuItem, hóaĐơnToolStripMenuItem, hóaĐơnToolStripMenuItem1 });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(157, 24);
            quảnLýToolStripMenuItem.Text = "Quản lý doanh mục";
            // 
            // sáchToolStripMenuItem
            // 
            sáchToolStripMenuItem.Name = "sáchToolStripMenuItem";
            sáchToolStripMenuItem.Size = new Size(224, 26);
            sáchToolStripMenuItem.Text = "Sách";
            sáchToolStripMenuItem.Click += sáchToolStripMenuItem_Click;
            // 
            // loạiToolStripMenuItem
            // 
            loạiToolStripMenuItem.Name = "loạiToolStripMenuItem";
            loạiToolStripMenuItem.Size = new Size(224, 26);
            loạiToolStripMenuItem.Text = "Loại sách";
            loạiToolStripMenuItem.Click += loạiToolStripMenuItem_Click;
            // 
            // hóaĐơnToolStripMenuItem
            // 
            hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            hóaĐơnToolStripMenuItem.Size = new Size(224, 26);
            hóaĐơnToolStripMenuItem.Text = "Đơn hàng";
            hóaĐơnToolStripMenuItem.Click += hóaĐơnToolStripMenuItem_Click;
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(87, 24);
            thốngKêToolStripMenuItem.Text = "Thống kê";
            thốngKêToolStripMenuItem.Click += thốngKêToolStripMenuItem_Click;
            // 
            // chuyểnĐổiXMLToolStripMenuItem
            // 
            chuyểnĐổiXMLToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuChuyenDoiXmlSangSql, mnuChuyenDoiSqlSangXml });
            chuyểnĐổiXMLToolStripMenuItem.Name = "chuyểnĐổiXMLToolStripMenuItem";
            chuyểnĐổiXMLToolStripMenuItem.Size = new Size(135, 24);
            chuyểnĐổiXMLToolStripMenuItem.Text = "Chuyển đổi XML";
            chuyểnĐổiXMLToolStripMenuItem.Click += chuyểnĐổiXMLToolStripMenuItem_Click;
            // 
            // mnuChuyenDoiXmlSangSql
            // 
            mnuChuyenDoiXmlSangSql.Name = "mnuChuyenDoiXmlSangSql";
            mnuChuyenDoiXmlSangSql.Size = new Size(270, 26);
            mnuChuyenDoiXmlSangSql.Text = "Chuyển đổi XML sang SQL";
            mnuChuyenDoiXmlSangSql.Click += mnuChuyenDoiXmlSangSql_Click;
            // 
            // mnuChuyenDoiSqlSangXml
            // 
            mnuChuyenDoiSqlSangXml.Name = "mnuChuyenDoiSqlSangXml";
            mnuChuyenDoiSqlSangXml.Size = new Size(270, 26);
            mnuChuyenDoiSqlSangXml.Text = "Chuyển đổi SQL sang XML";
            mnuChuyenDoiSqlSangXml.Click += mnuChuyenDoiSqlSangXml_Click;
            // 
            // panelContent
            // 
            panelContent.Location = new Point(0, 29);
            panelContent.Margin = new Padding(2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(755, 332);
            panelContent.TabIndex = 1;
            // 
            // hóaĐơnToolStripMenuItem1
            // 
            hóaĐơnToolStripMenuItem1.Name = "hóaĐơnToolStripMenuItem1";
            hóaĐơnToolStripMenuItem1.Size = new Size(224, 26);
            hóaĐơnToolStripMenuItem1.Text = "Hóa đơn";
            hóaĐơnToolStripMenuItem1.Click += hóaĐơnToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 360);
            Controls.Add(panelContent);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "App";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuTrangChu;
        private ToolStripMenuItem mnuQuanLy;
        private Panel panelContent;
        private ToolStripMenuItem mnuQLSACH;
        private ToolStripMenuItem mnuQLKHACHHANG;
        private ToolStripMenuItem chuyểnĐổiXMLToolStripMenuItem;
        private ToolStripMenuItem mnuChuyenDoiXmlSangSql;
        private ToolStripMenuItem mnuChuyenDoiSqlSangXml;
        private ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem1;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem sáchToolStripMenuItem;
        private ToolStripMenuItem loạiToolStripMenuItem;
        private ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ToolStripMenuItem hóaĐơnToolStripMenuItem1;
    }
}
