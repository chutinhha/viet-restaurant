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
    public partial class ChuyenBan : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaBanAn;
        string TenBan;
        public ChuyenBan(int MaBan,string TenBanAn)
        {
            InitializeComponent();
            MaBanAn = MaBan;
            TenBan = TenBanAn;
        }

        private void ChuyenBan_Load(object sender, EventArgs e)
        {
            LoadBanAn();
            lblBanDauTien.Text = TenBan;
        }
        public void LoadBanAn()
        {
            BanHang.Model.Load load = new Model.Load();
            DataTable dt = load.LoadBanAn();
            comboTree1.DataSource = dt;
            comboTree1.ValueMember = "MaBan";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int MaBanTiep = Convert.ToInt32(comboTree1.SelectedValue.ToString());
            HoaDon.model.Load load1 = new HoaDon.model.Load();
            DataTable dt1 = load1.LoadHoaDonChuaThanhToanCanChon(MaBanTiep);
            if (dt1.Rows.Count == 0)
            {
                BanHang.Model.Load load = new Model.Load();
                DataTable dt = load.LoadBanAnTheoMaBan(MaBanTiep);
                string Ten = dt.Rows[0][1].ToString();
                BanHang.Model.Update update = new Model.Update();
                update.UpdateChuyenBanAn(MaBanAn, MaBanTiep, Ten);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bàn đã có người ngồi");
            }
           
        }
    }
}
