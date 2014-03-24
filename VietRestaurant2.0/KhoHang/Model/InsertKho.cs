using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace VietRestaurant2._0.KhoHang.Model
{
    class InsertKho
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void InsertDonVi(string TenDonVi)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into DonVi values (@TenDonVi)", conn);
            cmd.Parameters.AddWithValue("@TenDonVi", TenDonVi);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertNguyenLieu(string TenNguyenLieu, string DonVi, float Gia, int MaDanhMucNguyenLieu)
        {

            int SoLuong = 0;
                conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into NguyenLieu values (@TenNguyenLieu,@SoLuong,@DonVi,@Gia,@MaDanhMucNguyenLieu)", conn);
                cmd.Parameters.AddWithValue("@TenNguyenLieu", TenNguyenLieu);
                cmd.Parameters.AddWithValue("@DonVi", DonVi);
                cmd.Parameters.AddWithValue("@Gia", Gia);
                cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                cmd.Parameters.AddWithValue("@MaDanhMucNguyenLieu", MaDanhMucNguyenLieu);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            

        }
      
        public void InsertNhomDanhMuc(string NhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into NhomDanhMucNguyenLieu values (@TenDanhMuc)", conn);
            cmd.Parameters.AddWithValue("@TenDanhMuc", NhomDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertDanhMucNguyenLieu(string TenDanhMuc, int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into DanhMucNguyenLieu values (@TenDanhMuc,@MaNhomDanhMuc)", conn);
            cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMuc);
            cmd.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InserVaoKho(DataTable dt, float tongTien,string ghiChu)
        {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction();
            //    update du lieu vao kho
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float SoLuong = float.Parse( dt.Rows[i][3].ToString());
                    int ID = Convert.ToInt32( dt.Rows[i][0].ToString());
                    SqlCommand cmdUpdate = new SqlCommand("Update NguyenLieu set SoLuong = SoLuong+@SoLuong where MaNguyenLieu = @MaNguyenLieu",conn);
                    cmdUpdate.Parameters.AddWithValue("SoLuong",SoLuong);
                    cmdUpdate.Parameters.AddWithValue("MaNguyenLieu", ID);
                    cmdUpdate.Transaction = transaction;
                    try
                    {
                        cmdUpdate.ExecuteNonQuery();
                        
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
              transaction.Commit();
            //Insert hoa don
                transaction = conn.BeginTransaction();
                DateTime date = DateTime.Now;
                SqlCommand cmdHoaDon = new SqlCommand("Insert into HoaDonNhapHang values (@ThoiGian,@TongTien,@GhiChu)",conn);
                cmdHoaDon.Parameters.AddWithValue("@ThoiGian", date);
                cmdHoaDon.Parameters.AddWithValue("@TongTien", tongTien);
                cmdHoaDon.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmdHoaDon.Transaction = transaction;    
                try
                {
                    
                    cmdHoaDon.ExecuteNonQuery();
                   
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
              SqlDataAdapter da = new SqlDataAdapter("select top 1 * from  HoaDonNhapHang order by MaHoaDon desc",conn);
              DataTable dt1 = new DataTable();
               da.Fill(dt1);
                int MaHoaDon = Convert.ToInt32(dt1.Rows[0][0].ToString());
            //Insert hoa don chi tiet
                transaction = conn.BeginTransaction();
            for (int i = 0; i < dt.Rows.Count; i++)
			{

			  float SoLuong = float.Parse( dt.Rows[i][3].ToString());
              int ID = Convert.ToInt32( dt.Rows[i][0].ToString());
              SqlCommand cmdHoaDonChiTiet = new SqlCommand("Insert into HoaDonNhapHangChiTiet values (@MaHoaDon,@TenMatHang,@DonVi,@SoLuong,@DonGia,@ThanhTien)",conn);
              cmdHoaDonChiTiet.Parameters.AddWithValue("@MaHoaDon",MaHoaDon);
              cmdHoaDonChiTiet.Parameters.AddWithValue("@TenMatHang",dt.Rows[i][1].ToString());
              cmdHoaDonChiTiet.Parameters.AddWithValue("@DonVi", dt.Rows[i][2].ToString());
              cmdHoaDonChiTiet.Parameters.AddWithValue("@SoLuong", dt.Rows[i][3].ToString());
              cmdHoaDonChiTiet.Parameters.AddWithValue("@DonGia", dt.Rows[i][4].ToString());
              cmdHoaDonChiTiet.Parameters.AddWithValue("@ThanhTien", dt.Rows[i][5].ToString());
              cmdHoaDonChiTiet.Transaction = transaction;
              try
              {
                  
                  cmdHoaDonChiTiet.ExecuteNonQuery();
                  
              }
              catch (Exception)
              {
                  transaction.Rollback();
              }
            }
            transaction.Commit();
               
        }
        
    }
}
