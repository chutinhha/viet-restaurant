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
    public partial class ThemKhuVuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ThemKhuVuc()
        {
            InitializeComponent();
        }

        private void ThemKhuVuc_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            BanHang.Model.Insert insert = new Model.Insert();
            insert.InsertKhuVuc(textBoxX1.Text);
            this.Close();
        }
    }
}
