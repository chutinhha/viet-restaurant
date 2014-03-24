namespace VietRestaurant2._0
{
    partial class DonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonVi));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDonVi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đơn vị:";
            // 
            // txtDonVi
            // 
            this.txtDonVi.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDonVi.Border.Class = "TextBoxBorder";
            this.txtDonVi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDonVi.ForeColor = System.Drawing.Color.Black;
            this.txtDonVi.Location = new System.Drawing.Point(96, 38);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(100, 20);
            this.txtDonVi.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnOk.Image = global::VietRestaurant2._0.Properties.Resources._001_06;
            this.btnOk.Location = new System.Drawing.Point(70, 77);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 35);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 114);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DonVi";
            this.Text = "Đơn Vị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDonVi;
        private DevComponents.DotNetBar.ButtonX btnOk;
    }
}