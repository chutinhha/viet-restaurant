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
using System.Data.SqlClient;
using System.Configuration;

namespace VietRestaurant2._0.KhoHang
{
    public partial class NhapHangVaoKho : DevComponents.DotNetBar.Metro.MetroForm
    {
        public NhapHangVaoKho()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        DataTable dtTam;
        private void NhapHangVaoKho_Load(object sender, EventArgs e)
        {
            AutoCompleteText();
            LoadKhoHang();
           
             dtTam = new DataTable();
             dtTam.Columns.Add("ID",typeof(int));
             dtTam.Columns.Add("Tên",typeof(string));
             dtTam.Columns.Add("Đơn Vị",typeof(string));
             dtTam.Columns.Add("Số Lượng");
             dtTam.Columns.Add("Giá");
             dtTam.Columns.Add("Thành Tiền");
             dgvNhapHang.DataSource = dtTam;
             dgvNhapHang.Columns["ID"].Visible = false;
     
        }
        DataTable dtKho;
        public void LoadKhoHang()
        {
            KhoHang.Model.LoadKhoHang load = new Model.LoadKhoHang();
            DataTable dt = load.LoadToanBoNguyenLieu();
            dgvViewKhoHang.DataSource = dt;
            dgvViewKhoHang.Columns[0].Visible = false;
            dgvViewKhoHang.Columns[4].Visible = false;
            dtKho = dt;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtTam.Rows.Count > 0)
            {
                checkso(txtTongTien);
                float TongTien = a;
                KhoHang.Model.InsertKho insert = new Model.InsertKho();
                insert.InserVaoKho(dtTam, a, txtGhiChu.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu");
            }
            
        }
        float a;
        private void checkso(DevComponents.DotNetBar.Controls.RichTextBoxEx txtGia)
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

        public void TachSo(DevComponents.DotNetBar.Controls.RichTextBoxEx luong)
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

        private void dgvViewKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int MaNguyenLieu = Convert.ToInt32(dgvViewKhoHang.SelectedRows[0].Cells[0].Value.ToString());
                lblID.Text = MaNguyenLieu.ToString();
                KhoHang.Model.LoadKhoHang load = new Model.LoadKhoHang();
                DataTable dt = load.LoadNguyenLieuTheoMaNguyenLieu(MaNguyenLieu);
                lblName.Text = dt.Rows[0][1].ToString();
                txtGia.Text = dt.Rows[0][4].ToString();
                txtSoLuong.Text = "1";
                checkso(txtGia);
                TachSo(txtGia);
                float tien = a *  float.Parse(txtSoLuong.Text);
                txtTien.Text = tien.ToString();
                lblDonVi.Text = dt.Rows[0][3].ToString();
            }
            catch (Exception)
            {
               
            }
          
          
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkso(txtGia);
                TachSo(txtGia);
                float tien = a * float.Parse(txtSoLuong.Text);
                txtTien.Text = tien.ToString();
            }
            catch (Exception)
            {
                
               
            }
           
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkso(txtGia);
                TachSo(txtGia);
                float tien = a * float.Parse(txtSoLuong.Text);
                txtTien.Text = tien.ToString();
            }
            catch (Exception)
            {
                
            }
           
        }
      
        public void TongTien()
        {
            int tongTien = 0;
          
                for (int i = 0; i < dtTam.Rows.Count; i++)
                {
                    try
                    {
                        tongTien = Convert.ToInt32(dtTam.Rows[i][5].ToString()) + tongTien;
                        txtTongTien.Text = tongTien.ToString();
                    }
                    catch (Exception)
                    {
                        
                    }
                   

                }
        
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "0" && txtSoLuong.Text != "")
            {
           
		        checkso(txtGia);
                float Gia = a;
                checkso(txtTien);
                float ThanhTien = a;
                
                int ID = Convert.ToInt32(lblID.Text);
                float SoLuong = float.Parse(txtSoLuong.Text);
                int kiemtra = 0;
                for (int i = 0; i < dtTam.Rows.Count; i++)
                {
                    if(ID ==Convert.ToInt32( dtTam.Rows[i][0].ToString()))
                    {
                        dtTam.Rows[i][3] = float.Parse( dtTam.Rows[i][3].ToString())+SoLuong;
                        dtTam.Rows[i][5] = float.Parse(dtTam.Rows[i][3].ToString()) * float.Parse(dtTam.Rows[i][4].ToString());
                        kiemtra = 1;
                    }
                }
                if (kiemtra == 0)
                {
                    dtTam.Rows.Add(ID, lblName.Text, lblDonVi.Text, SoLuong, Gia, ThanhTien);
                    dgvNhapHang.DataSource = dtTam;
                    TongTien();
                }
                
                }
            else
            {
                MessageBox.Show("Bạn chưa điền đầy đủ");
            }
         
        }

        private void lblTien_TextChanged(object sender, EventArgs e)
        {

            TachSo(txtTien);
        }

   
   
        private void dgvNhapHang_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TongTien();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            TachSo(txtTongTien);
        }
        void AutoCompleteText()
        {
            textBoxX1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxX1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            string sql = "Select * from NguyenLieu";
            conn = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader reader;
            reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    coll.Add(reader["TenNguyenLieu"].ToString());
                }
            }
            textBoxX1.AutoCompleteCustomSource = coll;
        }
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {   
                DataView dv = new DataView(dtKho);
                string name = dtKho.Columns[1].ToString();
                dv.RowFilter = string.Format(" Tên  LIKE '%{0}%'", textBoxX1.Text);
                dgvViewKhoHang.DataSource = dv;
               
            
        }

    }
}
