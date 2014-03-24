namespace VietRestaurant2._0
{
    partial class SuaMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaMon));
            this.comboTreeDanhMuc = new DevComponents.DotNetBar.Controls.ComboTree();
            this.NhomDanhMuc = new DevComponents.AdvTree.ColumnHeader();
            this.DanhMuc = new DevComponents.AdvTree.ColumnHeader();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddDonVi = new DevComponents.DotNetBar.ButtonX();
            this.txtGiaBan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtThucDon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboTreeDonVi = new DevComponents.DotNetBar.Controls.ComboTree();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTreeDanhMuc
            // 
            this.comboTreeDanhMuc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.comboTreeDanhMuc.BackgroundStyle.Class = "TextBoxBorder";
            this.comboTreeDanhMuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.comboTreeDanhMuc.ButtonDropDown.Visible = true;
            this.comboTreeDanhMuc.Columns.Add(this.NhomDanhMuc);
            this.comboTreeDanhMuc.Columns.Add(this.DanhMuc);
            this.comboTreeDanhMuc.ColumnsVisible = false;
            this.comboTreeDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.comboTreeDanhMuc.Location = new System.Drawing.Point(108, 23);
            this.comboTreeDanhMuc.Name = "comboTreeDanhMuc";
            this.comboTreeDanhMuc.Size = new System.Drawing.Size(363, 29);
            this.comboTreeDanhMuc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboTreeDanhMuc.TabIndex = 13;
            // 
            // NhomDanhMuc
            // 
            this.NhomDanhMuc.Name = "NhomDanhMuc";
            this.NhomDanhMuc.Text = "Column";
            this.NhomDanhMuc.Width.Absolute = 150;
            // 
            // DanhMuc
            // 
            this.DanhMuc.Name = "DanhMuc";
            this.DanhMuc.Text = "Column";
            this.DanhMuc.Width.Absolute = 150;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(12, 151);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "Giá bán:";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(12, 109);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "Đơn vị tính:";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(12, 65);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "Tên thực đơn:";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(12, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(91, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "Danh mục:";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.buttonX3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonX3.Image = global::VietRestaurant2._0.Properties.Resources.cross_481;
            this.buttonX3.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonX3.Location = new System.Drawing.Point(262, 212);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(105, 35);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 21;
            this.buttonX3.Text = "Hủy";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOk.Image = global::VietRestaurant2._0.Properties.Resources._001_06;
            this.btnOk.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnOk.Location = new System.Drawing.Point(135, 212);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 35);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.TextColor = System.Drawing.Color.White;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(326, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnAddDonVi
            // 
            this.btnAddDonVi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddDonVi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddDonVi.Image = global::VietRestaurant2._0.Properties.Resources.add_48;
            this.btnAddDonVi.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnAddDonVi.Location = new System.Drawing.Point(281, 107);
            this.btnAddDonVi.Name = "btnAddDonVi";
            this.btnAddDonVi.Size = new System.Drawing.Size(39, 31);
            this.btnAddDonVi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddDonVi.TabIndex = 17;
            this.btnAddDonVi.Click += new System.EventHandler(this.btnAddDonVi_Click);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGiaBan.Border.Class = "TextBoxBorder";
            this.txtGiaBan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGiaBan.ForeColor = System.Drawing.Color.Black;
            this.txtGiaBan.Location = new System.Drawing.Point(108, 160);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(167, 20);
            this.txtGiaBan.TabIndex = 15;
            this.txtGiaBan.TextChanged += new System.EventHandler(this.txtGiaBan_TextChanged);
            // 
            // txtThucDon
            // 
            this.txtThucDon.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtThucDon.Border.Class = "TextBoxBorder";
            this.txtThucDon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtThucDon.ForeColor = System.Drawing.Color.Black;
            this.txtThucDon.Location = new System.Drawing.Point(108, 71);
            this.txtThucDon.Name = "txtThucDon";
            this.txtThucDon.Size = new System.Drawing.Size(107, 20);
            this.txtThucDon.TabIndex = 16;
            // 
            // comboTreeDonVi
            // 
            this.comboTreeDonVi.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.comboTreeDonVi.BackgroundStyle.Class = "TextBoxBorder";
            this.comboTreeDonVi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.comboTreeDonVi.ButtonDropDown.Visible = true;
            this.comboTreeDonVi.ColumnsVisible = false;
            this.comboTreeDonVi.ForeColor = System.Drawing.Color.Black;
            this.comboTreeDonVi.Location = new System.Drawing.Point(108, 115);
            this.comboTreeDonVi.Name = "comboTreeDonVi";
            this.comboTreeDonVi.Size = new System.Drawing.Size(167, 23);
            this.comboTreeDonVi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboTreeDonVi.TabIndex = 14;
            // 
            // SuaMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 257);
            this.Controls.Add(this.comboTreeDanhMuc);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddDonVi);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtThucDon);
            this.Controls.Add(this.comboTreeDonVi);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuaMon";
            this.Text = "Sửa món";
            this.Load += new System.EventHandler(this.SuaMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboTree comboTreeDanhMuc;
        private DevComponents.AdvTree.ColumnHeader NhomDanhMuc;
        private DevComponents.AdvTree.ColumnHeader DanhMuc;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX btnAddDonVi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGiaBan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtThucDon;
        private DevComponents.DotNetBar.Controls.ComboTree comboTreeDonVi;

    }
}