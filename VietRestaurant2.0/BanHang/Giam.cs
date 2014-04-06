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
        int SoLuongTruoc;
        public Giam(string MaHoaDonChiTiet,int SoLuong)
        {
            InitializeComponent();
            MaHDCT = Convert.ToInt32(MaHoaDonChiTiet);
            SoLuongTruoc = SoLuong;
        }

        private void Giam_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int SoLuong = Convert.ToInt32(numericUpDown1.Value.ToString());
            if (SoLuong <= SoLuongTruoc)
            {
                BanHang.Model.Update update = new Model.Update();
                update.UpdateGiamSoLuongMonAn(MaHDCT, SoLuong);
                HoaDon.model.Load load = new HoaDon.model.Load();
                DataTable dt = load.LoadChiTietHoaDonTheoMaChiTietHoaDon(MaHDCT);
                int MaMonAn = Convert.ToInt32(dt.Rows[0][1].ToString());
                update.TraHangTrongKho(MaMonAn, SoLuong);
                this.Close();
            }
            else
            {
                MessageBox.Show("Số lượng giảm không được vượt quá số lượng ở hóa đơn");
            }
           
        }
    }
}
