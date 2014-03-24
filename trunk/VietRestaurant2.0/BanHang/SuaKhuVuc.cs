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
    public partial class SuaKhuVuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SuaKhuVuc()
        {
            InitializeComponent();
        }

        private void SuaKhuVuc_Load(object sender, EventArgs e)
        {
            BanHang.Model.Load load = new Model.Load();
            DataTable dt = load.LoadKhuVuc();
            comboTree1.DataSource = dt;
            comboTree1.DisplayMembers = "TenKhuVuc";
            comboTree1.ValueMember = "MaKhuVuc";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            BanHang.Model.Update update = new Model.Update();
            update.UpdateKhuVuc(Convert.ToInt32( comboTree1.SelectedValue.ToString()), textBoxX1.Text);
            this.Close();
        }
    }
}
