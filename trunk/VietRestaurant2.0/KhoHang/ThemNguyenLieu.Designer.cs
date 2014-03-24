namespace VietRestaurant2._0.KhoHang
{
    partial class ThemNguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemNguyenLieu));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbDonVi = new DevComponents.DotNetBar.Controls.ComboTree();
            this.txtGia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtGiaThucDon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cbDanhMucThucDon = new DevComponents.DotNetBar.Controls.ComboTree();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnAddDonVi = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(40, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên mặt hàng:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(40, 92);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Giá:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(40, 53);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Đơn vị:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(148, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 20);
            this.txtName.TabIndex = 4;
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
            this.cbDonVi.Location = new System.Drawing.Point(148, 52);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(185, 24);
            this.cbDonVi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDonVi.TabIndex = 5;
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
            this.txtGia.Location = new System.Drawing.Point(148, 94);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(185, 20);
            this.txtGia.TabIndex = 6;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.BackColor = System.Drawing.Color.Lime;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOk.Image = global::VietRestaurant2._0.Properties.Resources._001_06;
            this.btnOk.Location = new System.Drawing.Point(132, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 53);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.Symbol = "";
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.TextColor = System.Drawing.Color.White;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(40, 121);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(180, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 8;
            this.checkBoxX1.Text = "Sử dụng làm thực đơn ";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // txtGiaThucDon
            // 
            this.txtGiaThucDon.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGiaThucDon.Border.Class = "TextBoxBorder";
            this.txtGiaThucDon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGiaThucDon.ForeColor = System.Drawing.Color.Black;
            this.txtGiaThucDon.Location = new System.Drawing.Point(118, 59);
            this.txtGiaThucDon.Name = "txtGiaThucDon";
            this.txtGiaThucDon.Size = new System.Drawing.Size(185, 20);
            this.txtGiaThucDon.TabIndex = 10;
            this.txtGiaThucDon.TextChanged += new System.EventHandler(this.txtGiaThucDon_TextChanged);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbDanhMucThucDon);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.txtGiaThucDon);
            this.panelEx1.Location = new System.Drawing.Point(30, 150);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(338, 84);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 11;
            // 
            // cbDanhMucThucDon
            // 
            this.cbDanhMucThucDon.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbDanhMucThucDon.BackgroundStyle.Class = "TextBoxBorder";
            this.cbDanhMucThucDon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDanhMucThucDon.ButtonDropDown.Visible = true;
            this.cbDanhMucThucDon.Location = new System.Drawing.Point(122, 14);
            this.cbDanhMucThucDon.Name = "cbDanhMucThucDon";
            this.cbDanhMucThucDon.Size = new System.Drawing.Size(181, 24);
            this.cbDanhMucThucDon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDanhMucThucDon.TabIndex = 13;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(10, 56);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 12;
            this.labelX5.Text = "Giá bán:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(10, 15);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(105, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "Danh mục thực đơn:";
            // 
            // btnAddDonVi
            // 
            this.btnAddDonVi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddDonVi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddDonVi.Image = global::VietRestaurant2._0.Properties.Resources.add_48;
            this.btnAddDonVi.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnAddDonVi.Location = new System.Drawing.Point(342, 45);
            this.btnAddDonVi.Name = "btnAddDonVi";
            this.btnAddDonVi.Size = new System.Drawing.Size(39, 31);
            this.btnAddDonVi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddDonVi.TabIndex = 12;
            this.btnAddDonVi.Click += new System.EventHandler(this.btnAddDonVi_Click);
            // 
            // ThemNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 301);
            this.Controls.Add(this.btnAddDonVi);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.cbDonVi);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ThemNguyenLieu";
            this.Text = "Thêm nguyên liệu";
            this.Load += new System.EventHandler(this.ThemNguyenLieu_Load);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.Controls.ComboTree cbDonVi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGia;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGiaThucDon;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboTree cbDanhMucThucDon;
        private DevComponents.DotNetBar.ButtonX btnAddDonVi;
    }
}