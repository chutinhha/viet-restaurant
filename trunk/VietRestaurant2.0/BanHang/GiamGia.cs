using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietRestaurant2._0.BanHang
{
    public partial class GiamGia : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaHDCT;
        public GiamGia(string Ma)
        {
            InitializeComponent();
            MaHDCT = Convert.ToInt32(Ma);
        }

        private void GiamGia_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            checkso(textBoxX1);
            float GiamGia = a;
            BanHang.Model.Update update = new Model.Update();
            update.UpdateGiamGiaMonAn(MaHDCT, GiamGia);
            this.Close();
        }
        float a;
        private void checkso(DevComponents.DotNetBar.Controls.TextBoxX txtGia)
        {
            if (txtGia.Text != null)
            {
                try
                {
                    string tam = txtGia.Text.Replace(",", "");
                    a = float.Parse(tam);
                }
                catch
                {
                    MessageBox.Show("Không được điền chữ");
                    txtGia.Text = "";
                }
            }
        }
        public void TachSo(DevComponents.DotNetBar.Controls.TextBoxX luong)
        {
            string txt, txt1;
            txt1 = luong.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            luong.Text = txt;
            luong.SelectionStart = luong.Text.Length;
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            TachSo(textBoxX1);
        }
    }
}
