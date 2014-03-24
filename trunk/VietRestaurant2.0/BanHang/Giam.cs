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
    public partial class Giam : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaHDCT;
        public Giam(string MaHoaDonChiTiet)
        {
            InitializeComponent();
            MaHDCT = Convert.ToInt32(MaHoaDonChiTiet);
        }

        private void Giam_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int SoLuong = Convert.ToInt32(numericUpDown1.Value.ToString());
            BanHang.Model.Update update = new Model.Update();
            update.UpdateGiamSoLuongMonAn(MaHDCT, SoLuong);
            this.Close();
        }
    }
}
