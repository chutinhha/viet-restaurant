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
    public partial class SuaDanhMucNguyenLieu : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaDanhMuc;
        public SuaDanhMucNguyenLieu(int Kho)
        {
            InitializeComponent();
            MaDanhMuc = Kho;
        }

        private void SuaDanhMucNguyenLieu_Load(object sender, EventArgs e)
        {
            KhoHang.Model.LoadKhoHang kho = new Model.LoadKhoHang();
            DataTable dt = kho.LoadDanhMucTheoMaDanhMuc(MaDanhMuc);
            textBoxX1.Text = dt.Rows[0][1].ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                KhoHang.Model.UpdateKho kho = new Model.UpdateKho();
                kho.UpdateDanhMucKho(MaDanhMuc, textBoxX1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin");
            }
        }
    }
}
