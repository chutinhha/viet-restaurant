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
    public partial class SuaGiaMonAn : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaHoaDonChiTiet;
        string TenMon;
        int Gia;
        public SuaGiaMonAn(int ID,string Name,int Gia1)
        {
            InitializeComponent();
            MaHoaDonChiTiet = ID;
            TenMon = Name;
            Gia = Gia1;
        }
        float a;
        private void checkso(DevComponents.DotNetBar.Controls.TextBoxX  txtGia)
        {
            if (txtGia.Text != "")
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
        private void SuaGiaMonAn_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = Gia.ToString();
            lblKhuVuc.Text = TenMon;
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            checkso(textBoxX1);
            TachSo(textBoxX1);
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            BanHang.Model.Update update = new Model.Update();
            checkso(textBoxX1);
            float Gia2 = a;
            update.UpdateGiaMonAn(MaHoaDonChiTiet, Gia2);
            this.Close();
        }
    }
}
