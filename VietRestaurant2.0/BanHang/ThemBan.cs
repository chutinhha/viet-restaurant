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
    public partial class ThemBan : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaKhuVuc;
        public ThemBan(int KhuVuc)
        {
            InitializeComponent();
            MaKhuVuc = KhuVuc;
        }

        private void ThemBan_Load(object sender, EventArgs e)
        {
            BanHang.Model.Load load  = new Model.Load();
            DataTable dt = load.LoadKhuVucTheoMaKhuVuc(MaKhuVuc);
            lblKhuVuc.Text = dt.Rows[0][1].ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                BanHang.Model.Insert insert = new Model.Insert();
                insert.InsertBanAn(textBoxX1.Text, MaKhuVuc);
                this.Close();
            }
        }
    }
}
