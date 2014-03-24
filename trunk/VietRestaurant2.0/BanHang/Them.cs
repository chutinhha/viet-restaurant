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
    public partial class Them : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaHDCT;
        public Them(string Ma)
        {
            InitializeComponent();
            MaHDCT = Convert.ToInt32(Ma);
        }

        private void Them_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int SoLuong = Convert.ToInt32(numericUpDown1.Value.ToString());
             BanHang.Model.Update update = new Model.Update();
             update.UpdateThemSoLuongMonAn(MaHDCT, SoLuong);
            HoaDon.model.Load load = new HoaDon.model.Load();
            DataTable dt = load.LoadChiTietHoaDonTheoMaChiTietHoaDon(MaHDCT);
           int MaMonAn = Convert.ToInt32( dt.Rows[0][1].ToString());
           update.LayHangTrongKho(MaMonAn,SoLuong);
             this.Close();
        }
    }
}
