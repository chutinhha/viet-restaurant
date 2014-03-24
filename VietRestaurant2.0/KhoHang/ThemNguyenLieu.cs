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
    public partial class ThemNguyenLieu : DevComponents.DotNetBar.Metro.MetroForm
    {
        int MaDanhMuc;
        public ThemNguyenLieu(int Ma)
        {
            InitializeComponent();
            MaDanhMuc = Ma;

        }

        private void ThemNguyenLieu_Load(object sender, EventArgs e)
        {
            panelEx1.Visible = false;
            LoadDonVi();
         
        }
        public void LoadDonVi()
          {
              KhoHang.Model.LoadKhoHang load = new Model.LoadKhoHang();
              DataTable dt = load.LoadDonVi();
              cbDonVi.DataSource = dt;
              cbDonVi.DisplayMembers = "TenDonVi";
              cbDonVi.ValueMember = "MaDonVi";
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                panelEx1.Visible = true;
                ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
                DataTable dt = thucdon.LoadDanhMucNhomDanhMucThucDon();
                cbDanhMucThucDon.DataSource = dt;
                cbDanhMucThucDon.ValueMember = "MaDanhMuc";
                
            }
            else
            {
                panelEx1.Visible = false;
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
        private void txtGiaThucDon_TextChanged(object sender, EventArgs e)
        {
            if(txtGiaThucDon.Text!="")
            {
                checkso(txtGiaThucDon);
                TachSo(txtGiaThucDon);
            }
            
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

        private void btnAddDonVi_Click(object sender, EventArgs e)
        {
            DonVi donvi = new DonVi();
            donvi.ShowDialog();
            LoadDonVi();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtName.Text!=""&& txtGia.Text!="")
            {
             if (!checkBoxX1.Checked)
            {
                 TachSo(txtGia);
                KhoHang.Model.InsertKho kho = new Model.InsertKho();
                kho.InsertNguyenLieu(txtName.Text, cbDonVi.Text, a,MaDanhMuc);
                this.Close();
            }
            else
            {
                if (txtGiaThucDon.Text != "")
                {
                    TachSo(txtGia);
                    KhoHang.Model.InsertKho kho = new Model.InsertKho();
                    kho.InsertNguyenLieu(txtName.Text, cbDonVi.Text, a, MaDanhMuc);
                    ThucDon.InsertThucDon thucdon = new ThucDon.InsertThucDon();
                    TachSo(txtGiaThucDon);
                    int MaDanhMucThucDon = Convert.ToInt32(cbDanhMucThucDon.SelectedValue.ToString());
                    string Anh = "";
                    thucdon.InsertMonAn(txtName.Text, cbDonVi.Text, a,Anh,MaDanhMucThucDon);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn điền giá của sản phẩm");
                }
               
            }
            }else
            {
                MessageBox.Show("Bạn điền đầy đủ thông tin");
            }
           
        }

  
    }
}
