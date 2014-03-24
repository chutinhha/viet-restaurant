using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietRestaurant2._0
{
    public partial class SuaNhomDanhMuc : DevComponents.DotNetBar.Metro.MetroForm
    {
        int Nhom;
        public SuaNhomDanhMuc(int NhomDanhMuc)
        {
            InitializeComponent();
            Nhom = NhomDanhMuc;
        }

        private void SuaNhomDanhMuc_Load(object sender, EventArgs e)
        {
            ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
            DataTable dt = thucdon.LoadNhomDanhMucTheoMaNhomDanhMuc(Nhom);
            textBoxX1.Text = dt.Rows[0][1].ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                ThucDon.UpdateThucDon thucdon = new ThucDon.UpdateThucDon();
                thucdon.UpdateNhomDanhMucThucDon(Nhom, textBoxX1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền");
            }
           
        }
    }
}
