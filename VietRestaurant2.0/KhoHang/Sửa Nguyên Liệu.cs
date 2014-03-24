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
    public partial class SuaNguyenLieu : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaNguyenLieu;
        public SuaNguyenLieu(int Ma)
        {
            InitializeComponent();
            MaNguyenLieu = Ma;

        }

        private void Sửa_Nguyên_Liệu_Load(object sender, EventArgs e)
        {
            KhoHang.Model.LoadKhoHang load = new Model.LoadKhoHang();
            DataTable dt = load.LoadNguyenLieuTheoMaNguyenLieu(MaNguyenLieu);
            txtNguyenLieu.Text = dt.Rows[0]["TenNguyenLieu"].ToString();
            txtGia.Text = dt.Rows[0]["Gia"].ToString();
            cbDonVi.DataSource= load.LoadDonVi();
            cbDonVi.ValueMember = "TenDonVi";
            cbDonVi.DisplayMembers = "TenDonVi";
            cbDonVi.SelectedValue = dt.Rows[0]["DonVi"].ToString();
            cbDanhMucNguyenLieu.DataSource = load.LoadDanhMucNguyenLieu();
            cbDanhMucNguyenLieu.ValueMember = "MaDanhMuc";
            cbDanhMucNguyenLieu.DisplayMembers = "TenDanhMuc";
            cbDanhMucNguyenLieu.SelectedValue = dt.Rows[0]["MaDanhMucNguyenLieu"];
           
        }
        float a;
        private void checkso(TextBox txtGia)
        {
            try
            {
                string tam = txtGia.Text.Replace(",", "");
                a = float.Parse(tam);
            }
            catch
            {
                MessageBox.Show("Không được điền chữ");
                txtGia.Text = "";
            }

        }

        public void TachSo(TextBox luong)
        {
            string txt, txt1;
            txt1 = luong.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            luong.Text = txt;
            luong.SelectionStart = luong.Text.Length;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtNguyenLieu.Text != "" && txtGia.Text != "")
            {
                KhoHang.Model.UpdateKho update = new Model.UpdateKho();
                update.UpdateNguyenLieu(MaNguyenLieu, txtNguyenLieu.Text, cbDonVi.Text, a, Convert.ToInt32(cbDanhMucNguyenLieu.SelectedValue.ToString()));
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền đầy đủ");
            }
           
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

            if (txtGia.Text != "")
            {
                checkso(txtGia);
                TachSo(txtGia);
            }
        }
    }
}
