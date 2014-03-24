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
    public partial class SuaNhomDanhMucNguyenLieu : DevComponents.DotNetBar.Metro.MetroForm
    {
        int Nhom;
        public SuaNhomDanhMucNguyenLieu(int NhomNguyenLieu)
        {
            InitializeComponent();
            Nhom = NhomNguyenLieu;
        }

        private void SuaNhomDanhMucNguyenLieu_Load(object sender, EventArgs e)
        {
            KhoHang.Model.LoadKhoHang kho = new Model.LoadKhoHang();
            DataTable dt = kho.LoadNhomDanhMucTheoMaNhomDanhMuc(Nhom);
            textBoxX1.Text = dt.Rows[0][1].ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                KhoHang.Model.UpdateKho kho = new Model.UpdateKho();
                kho.UpdateNhomDanhMucNguyenLieu(Nhom,textBoxX1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đầy đủ");
            }
        }
    }
}
