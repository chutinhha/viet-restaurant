﻿namespace VietRestaurant2._0.BanHang
{
    partial class ThemKhuVuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemKhuVuc));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblKhuVuc = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.Lime;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.buttonX1.Location = new System.Drawing.Point(248, 46);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 68);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 11;
            this.buttonX1.Text = "Thêm";
            this.buttonX1.TextColor = System.Drawing.Color.White;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(110, 88);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(116, 26);
            this.textBoxX1.TabIndex = 10;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(8, 91);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 23);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "Tên Khu vực:";
            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblKhuVuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblKhuVuc.ForeColor = System.Drawing.Color.Black;
            this.lblKhuVuc.Location = new System.Drawing.Point(34, 14);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(154, 70);
            this.lblKhuVuc.TabIndex = 8;
            this.lblKhuVuc.Text = "<b><font color=\"#B02B2C\">Khu Vực</font></b>";
            // 
            // ThemKhuVuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 129);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lblKhuVuc);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ThemKhuVuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm khu vực";
            this.Load += new System.EventHandler(this.ThemKhuVuc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lblKhuVuc;
    }
}