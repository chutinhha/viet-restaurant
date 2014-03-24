namespace VietRestaurant2._0.KhoHang
{
    partial class SuaNguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaNguyenLieu));
            this.nguyelieu = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtNguyenLieu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbDonVi = new DevComponents.DotNetBar.Controls.ComboTree();
            this.cbDanhMucNguyenLieu = new DevComponents.DotNetBar.Controls.ComboTree();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // nguyelieu
            // 
            this.nguyelieu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.nguyelieu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nguyelieu.ForeColor = System.Drawing.Color.Black;
            this.nguyelieu.Location = new System.Drawing.Point(48, 30);
            this.nguyelieu.Name = "nguyelieu";
            this.nguyelieu.Size = new System.Drawing.Size(103, 23);
            this.nguyelieu.TabIndex = 0;
            this.nguyelieu.Text = "Tên Nguyên Liệu";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(48, 77);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Đơn Vị";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(48, 126);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Giá";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(48, 169);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(139, 23);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "Danh mục nguyên liệu";
            // 
            // txtNguyenLieu
            // 
            this.txtNguyenLieu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNguyenLieu.Border.Class = "TextBoxBorder";
            this.txtNguyenLieu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNguyenLieu.ForeColor = System.Drawing.Color.Black;
            this.txtNguyenLieu.Location = new System.Drawing.Point(226, 30);
            this.txtNguyenLieu.Name = "txtNguyenLieu";
            this.txtNguyenLieu.Size = new System.Drawing.Size(166, 20);
            this.txtNguyenLieu.TabIndex = 4;
            // 
            // txtGia
            // 
            this.txtGia.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGia.Border.Class = "TextBoxBorder";
            this.txtGia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGia.ForeColor = System.Drawing.Color.Black;
            this.txtGia.Location = new System.Drawing.Point(226, 126);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(166, 20);
            this.txtGia.TabIndex = 5;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // cbDonVi
            // 
            this.cbDonVi.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbDonVi.BackgroundStyle.Class = "TextBoxBorder";
            this.cbDonVi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDonVi.ButtonDropDown.Visible = true;
            this.cbDonVi.Location = new System.Drawing.Point(226, 74);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(166, 23);
            this.cbDonVi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDonVi.TabIndex = 6;
            // 
            // cbDanhMucNguyenLieu
            // 
            this.cbDanhMucNguyenLieu.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbDanhMucNguyenLieu.BackgroundStyle.Class = "TextBoxBorder";
            this.cbDanhMucNguyenLieu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDanhMucNguyenLieu.ButtonDropDown.Visible = true;
            this.cbDanhMucNguyenLieu.Location = new System.Drawing.Point(226, 166);
            this.cbDanhMucNguyenLieu.Name = "cbDanhMucNguyenLieu";
            this.cbDanhMucNguyenLieu.Size = new System.Drawing.Size(166, 23);
            this.cbDanhMucNguyenLieu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDanhMucNguyenLieu.TabIndex = 7;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.Lime;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.buttonX1.Image = global::VietRestaurant2._0.Properties.Resources._001_06;
            this.buttonX1.Location = new System.Drawing.Point(183, 233);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(99, 45);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 8;
            this.buttonX1.Text = "Đồng ý";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // SuaNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 290);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.cbDanhMucNguyenLieu);
            this.Controls.Add(this.cbDonVi);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtNguyenLieu);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.nguyelieu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuaNguyenLieu";
            this.Text = "Sửa Nguyên Liệu";
            this.Load += new System.EventHandler(this.Sửa_Nguyên_Liệu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX nguyelieu;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNguyenLieu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGia;
        private DevComponents.DotNetBar.Controls.ComboTree cbDonVi;
        private DevComponents.DotNetBar.Controls.ComboTree cbDanhMucNguyenLieu;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}