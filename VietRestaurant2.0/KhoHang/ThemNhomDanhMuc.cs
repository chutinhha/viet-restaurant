using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietRestaurant2._0.KhoHang
{
    public partial class ThemNhomDanhMuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ThemNhomDanhMuc()
        {
            InitializeComponent();
        }

        private void ThemNhomDanhMuc_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                KhoHang.Model.InsertKho kho = new Model.InsertKho();
                kho.InsertNhomDanhMuc(textBoxX1.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa điền");
            }
            
        }
    }
}
