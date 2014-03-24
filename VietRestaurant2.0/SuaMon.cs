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
using System.IO;

namespace VietRestaurant2._0
{
    public partial class SuaMon : MetroForm
    {
        int MaMonAn;
        public SuaMon(int maMon)
        {
            InitializeComponent();
            MaMonAn = maMon;
        }

        private void SuaMon_Load(object sender, EventArgs e)
        {
            ThucDon.ModuleThucDon thucDon = new ThucDon.ModuleThucDon();
            DataTable dt = thucDon.LoadThucDonTheoMaMonAn(MaMonAn);
            ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
            pictureBox1.Image = global::VietRestaurant2._0.Properties.Resources._5564116;
            //load danh muc da chon
            DataTable dtDanhMuc = thucdon.LoadDanhMucNhomDanhMucThucDon();
            comboTreeDanhMuc.DataSource = dtDanhMuc;
            comboTreeDanhMuc.ValueMember = "MaDanhMuc";
            int MaDanhMuc = Convert.ToInt32(dt.Rows[0][5].ToString());
            comboTreeDanhMuc.SelectedValue = MaDanhMuc;
            txtThucDon.Text = dt.Rows[0][1].ToString();
            txtGiaBan.Text = dt.Rows[0][3].ToString();
            try
            {
                pictureBox1.Image = byeArrayToImage((byte[])dt.Rows[0][4]);
            }
            catch (Exception)
            {
                
                
            }
            LoadDonVi();
            comboTreeDonVi.SelectedValue = dt.Rows[0][2].ToString();

        }
        public Image byeArrayToImage(byte[] byeArrayIn)
        {
            MemoryStream ms = new MemoryStream(byeArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public void LoadDonVi()
        {
            ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
            //load Donvi
            DataTable dtDonVi = thucdon.LoadDonVi();
            comboTreeDonVi.DataSource = dtDonVi;
            comboTreeDonVi.ValueMember = "TenDonVi";
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
            ThucDon.UpdateThucDon thucdon = new ThucDon.UpdateThucDon();
            int MaDanhMuc = Convert.ToInt32(comboTreeDanhMuc.SelectedValue.ToString());
            string Ten = txtThucDon.Text;
            string DonVi = comboTreeDonVi.Text;
             float Gia = a;
             string Anh = path;
             thucdon.UpdateMonAn(MaMonAn, Ten, DonVi, Gia, Anh, MaDanhMuc);
             this.Close();
        }
        float a;
        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            TachSo(txtGiaBan);
            checkso(txtGiaBan);
        }
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
                    txtGiaBan.Text = "";
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
    }

}
