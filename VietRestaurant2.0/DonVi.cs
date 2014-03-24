using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace VietRestaurant2._0
{
    public partial class DonVi : MetroForm
    {
        public DonVi()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtDonVi.Text != "")
            {
                try
                {
                    ThucDon.InsertThucDon thucdon = new ThucDon.InsertThucDon();
                    thucdon.InsertDonVi(txtDonVi.Text);
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Có lỗi");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đơn vị");
            }
        }
    }
}
