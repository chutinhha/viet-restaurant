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
    public partial class SuaBan : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaKhuVuc;
        int MaBan;
        public SuaBan(int MaBanAn,int KhuVuc)
        {
            InitializeComponent();
            MaKhuVuc = KhuVuc;
            MaBan = MaBanAn;
        }

        private void SuaBan_Load(object sender, EventArgs e)
        {

            BanHang.Model.Load load = new Model.Load();
            DataTable dt = load.LoadKhuVucTheoMaKhuVuc(MaKhuVuc);
            lblKhuVuc.Text = dt.Rows[0][1].ToString();
            DataTable dt1 = load.LoadBanAnTheoMaBan(MaBan);
            textBoxX1.Text = dt1.Rows[0][1].ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            BanHang.Model.Update update = new Model.Update();
            update.UpdateBanAn(MaBan, textBoxX1.Text);
            this.Close();
        }
    }
}
