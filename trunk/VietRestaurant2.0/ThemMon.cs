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
    public partial class ThemMon : MetroForm
    {
        public ThemMon(int MaDanhMucThucDon)
        {
            InitializeComponent();
            MaDanhMuc = MaDanhMucThucDon;
            this.CenterToParent();
        }
        int MaDanhMuc;
        private void ThemMon_Load(object sender, EventArgs e)
        {
            try
            {
                ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
                //load danh muc da chon
                DataTable dtDanhMuc = thucdon.LoadDanhMucNhomDanhMucThucDon();
                comboTreeDanhMuc.DataSource = dtDanhMuc;
                comboTreeDanhMuc.ValueMember = "MaDanhMuc";
                comboTreeDanhMuc.SelectedValue = MaDanhMuc;
                pictureBox1.Image = global::VietRestaurant2._0.Properties.Resources._5564116;
                LoadDonVi();
                panelEx1.Visible = false;
            }
            catch (Exception)
            {
                
                
            }
           
        }
        public void LoadDonVi()
        {
            ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
            //load Donvi
            DataTable dtDonVi = thucdon.LoadDonVi();
            comboTreeDonVi.DataSource = dtDonVi;
            comboTreeDonVi.ValueMember = "MaDonVi";
            comboTreeDonVi.DisplayMembers = "TenDonVi";
        }

        private void btnAddDonVi_Click(object sender, EventArgs e)
        {
            DonVi donvi = new DonVi();
            
            donvi.ShowDialog();
            LoadDonVi();

        }
        string path="";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = "~/";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                path = openFileDialog1.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ThucDon.InsertThucDon thucdon = new ThucDon.InsertThucDon();
                if(txtThucDon.Text!=""&& txtGiaBan.Text!="")
                {
                string TenMonAn = txtThucDon.Text;
                string DonVi = comboTreeDonVi.Text;
                checkso(txtGiaBan);
                float Gia = a;
                string Anh = path;
                int MaDanhMucThucDon = Convert.ToInt32(comboTreeDanhMuc.SelectedValue.ToString());
                if (checkBoxXThucDon.Checked)
                {
                    checkso(txtGiaNguyenLieu);
                   float GiaNguyenLieu = a;
                    int MaDanhMucNguyenLieu = Convert.ToInt32(cbDanhMucNguyenLieu.SelectedValue.ToString());
                  KhoHang.Model.InsertKho insert = new KhoHang.Model.InsertKho();
                    thucdon.InsertMonAn(TenMonAn, DonVi, Gia, Anh, MaDanhMucThucDon);
                   insert.InsertNguyenLieu(TenMonAn, DonVi, Gia, MaDanhMucNguyenLieu);
                   

                }
                else
                {
                    thucdon.InsertMonAn(TenMonAn, DonVi, Gia, Anh, MaDanhMucThucDon);
                }
                
                this.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            TachSo(txtGiaBan);
            checkso(txtGiaBan);
        }
        float a;
        private void checkso(TextBox txtGia)
        {
            if (txtGia.Text != "")
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

        private void checkBoxXThucDon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxXThucDon.Checked == true)
            {
                panelEx1.Visible = true;
                KhoHang.Model.LoadKhoHang load = new KhoHang.Model.LoadKhoHang();
                DataTable dt = load.LoadDanhMucNhomDanhMucNguyenLieu();
                cbDanhMucNguyenLieu.DataSource = dt;
                cbDanhMucNguyenLieu.ValueMember = "ID";

            }
            else
            {
                panelEx1.Visible = false;
            }
        }

        private void txtGiaNguyenLieu_TextChanged(object sender, EventArgs e)
        {
            checkso(txtGiaNguyenLieu);
            TachSo(txtGiaNguyenLieu);
        }
    }
}
