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
    public partial class ThemDanhMuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        int Nhom;
        public ThemDanhMuc(int NhomDanhMuc)
        {
            InitializeComponent();
            Nhom = NhomDanhMuc;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
                if(textBoxX1.Text!="")
                {
                    ThucDon.InsertThucDon thucdon = new ThucDon.InsertThucDon();
                    thucdon.InsertDanhMucThucDon(textBoxX1.Text, Nhom);
                    this.Close();
                }
        }
    }
}
