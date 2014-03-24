using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietRestaurant2._0.HoaDon
{
    public partial class ChiTietHoaDon : DevComponents.DotNetBar.Metro.MetroForm
    {
        int ID;
        public ChiTietHoaDon(int maHoaDon)
        {
            InitializeComponent();
            ID = maHoaDon;
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            HoaDon.model.Load load = new model.Load();
            DataTable dt = load.LoadChiTietHoaDonNhapHang(ID);
            dgvChiTietHoaDon.DataSource = dt;
            dgvChiTietHoaDon.AllowUserToResizeRows = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dgvChiTietHoaDon.Rows[i].Cells["ST"].Value = i + 1;

            }
        }
    }
}
