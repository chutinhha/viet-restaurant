using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietRestaurant2._0.HoaDon
{
    public partial class ChiTietHoaDon : DevComponents.DotNetBar.Metro.MetroForm
    {
        int ID;
        int check;
        public ChiTietHoaDon(int maHoaDon,int kt)
        {
            InitializeComponent();
            ID = maHoaDon;
            check = kt;
            groupPanel1.Visible = false;
        }
        int MaKhachHang = 0;
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            HoaDon.model.Load load = new model.Load();
            DataTable dt = new DataTable();
            if (check == 2)
            {
                DataTable dtHoaDonNhapHang = load.LoadHoaDonNhapHangTheoMaHoaDon(ID);
                string ThoiGian = dtHoaDonNhapHang.Rows[0][1].ToString();
                //     string ViTri = dtHoaDon.Rows[0][2].ToString();
                //    string Khach = dtHoaDon.Rows[0][13].ToString();
                //     string MaKhach = dtHoaDon.Rows[0][12].ToString();
                int ThanhToan = Convert.ToInt32(dtHoaDonNhapHang.Rows[0][2].ToString());   
                dt = load.LoadChiTietHoaDonNhapHang(ID);
                lblNgay.Text = ThoiGian;
                lblBan.Visible = false;
                lblKhachHang.Visible = false;
                lblTongTien.Text = ThanhToan.ToString();
                
            }
            else if(check ==1)
            {

                DataTable dtHoaDon = load.LoadHoaDonTheoMaHoaDon(ID);
                string ThoiGian = dtHoaDon.Rows[0][1].ToString();
                string ViTri = dtHoaDon.Rows[0][11].ToString();
                string Khach = dtHoaDon.Rows[0][13].ToString();
                string MaKhach = dtHoaDon.Rows[0][12].ToString();
                int ThanhToan = Convert.ToInt32( dtHoaDon.Rows[0][8].ToString());
                dt = load.LoadChiTietHoaDonTheoMaHoaDon(ID);
                lblNgay.Text = ThoiGian;
                lblBan.Text = ViTri;
                lblKhachHang.Text = Khach;
                lblTongTien.Text = ThanhToan.ToString();
                
                if (MaKhach!=""&& Convert.ToInt32(MaKhach)!=0)
                {
                    MaKhachHang = Convert.ToInt32(MaKhach);
                    groupPanel1.Visible = true;
                    BanHang.Model.Load load1 = new BanHang.Model.Load();
                    DataTable dtKhach = load1.LoadKhachHangTheoMaKhach(MaKhachHang);
                    labelXSDT.Text = dtKhach.Rows[0][2].ToString();
                    richTextBoxExDiaChi.Text = dtKhach.Rows[0][1].ToString();
                }
                
            }
           
            dgvChiTietHoaDon.DataSource = dt;
            dgvChiTietHoaDon.AllowUserToResizeRows = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                dgvChiTietHoaDon.Rows[i].Cells["ST"].Value = i + 1;

            }
        }

      
    }
}
