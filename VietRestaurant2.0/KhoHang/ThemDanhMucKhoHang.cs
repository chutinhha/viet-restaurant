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
    public partial class ThemDanhMucKhoHang : DevComponents.DotNetBar.Metro.MetroForm
    {
        int nhom;
        public ThemDanhMucKhoHang(int NhomDanhMuc)
        {
            InitializeComponent();
            nhom = NhomDanhMuc;
        }

        private void ThemDanhMucKhoHang_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                KhoHang.Model.InsertKho kho = new Model.InsertKho();
                kho.InsertDanhMucNguyenLieu(textBoxX1.Text,nhom);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền");
            }
        }
    }
}
