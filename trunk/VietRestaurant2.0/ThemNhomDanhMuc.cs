using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VietRestaurant2._0
{
    public partial class ThemNhomDanhMuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ThemNhomDanhMuc()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                ThucDon.InsertThucDon thucdon = new ThucDon.InsertThucDon();
                thucdon.InsertNhomDanhMuc(textBoxX1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền tên");
            }
        }
    }
}
