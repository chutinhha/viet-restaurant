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
    public partial class DieuChinhTonKho : DevComponents.DotNetBar.Metro.MetroForm
    {
        int ID;
        public DieuChinhTonKho(int MaNguyenLieu)
        {
            InitializeComponent();
            ID = MaNguyenLieu;
        }

        private void DieuChinhTonKho_Load(object sender, EventArgs e)
        {
            KhoHang.Model.LoadKhoHang load = new Model.LoadKhoHang();
            DataTable dt = load.LoadNguyenLieuTheoMaNguyenLieu(ID);
            lblName.Text = dt.Rows[0][1].ToString();
            txtSoLuongTon.Text = dt.Rows[0][2].ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            KhoHang.Model.UpdateKho update = new Model.UpdateKho();
            float SoLuong = float.Parse(txtSoLuong.Value.ToString());
            update.UpdateSoLuongTon(ID, SoLuong);
            this.Close();
        }
    }
}
