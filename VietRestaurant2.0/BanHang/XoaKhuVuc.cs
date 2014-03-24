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
    public partial class XoaKhuVuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public XoaKhuVuc()
        {
            InitializeComponent();
        }

        private void XoaKhuVuc_Load(object sender, EventArgs e)
        {

            BanHang.Model.Load load = new Model.Load();
            DataTable dt = load.LoadKhuVuc();
            comboTree1.DataSource = dt;
            comboTree1.DisplayMembers = "TenKhuVuc";
            comboTree1.ValueMember = "MaKhuVuc";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int MaKhuVuc = Convert.ToInt32(comboTree1.SelectedValue.ToString());
                BanHang.Model.Load load = new BanHang.Model.Load();
                DataTable dt = load.LoadHoaDonChuaThanhToanTheoMaKhuVuc(MaKhuVuc);
                if (dt.Rows.Count == 0)
                {
                    BanHang.Model.Delete delete = new Model.Delete();
                    delete.DeleteKhuVuc(MaKhuVuc);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vẫn còn bàn chưa thanh toán, không thể xóa");
                }
           
            }
            catch (Exception)
            {
                
            }
           
        }
    }
}
