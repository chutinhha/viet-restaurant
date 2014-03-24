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
    class UpdateKho
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void UpdateNguyenLieu(int MaNguyenLieu, string TenNguyenLieu, string DonVi, float Gia, int MaDanhMucMaNguyenLieu)
        {
            
                conn = new SqlConnection(ConnectionString);
                string query = "update NguyenLieu set TenNguyenLieu = @TenNguyenLieu,DonVi = @DonVi,Gia = @Gia,MaDanhMucNguyenLieu=@MaDanhMucMaNguyenLieu where MaNguyenLieu = @MaNguyenLieu ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                cmd.Parameters.AddWithValue("@TenNguyenLieu", TenNguyenLieu);
                cmd.Parameters.AddWithValue("@DonVi", DonVi);
                cmd.Parameters.AddWithValue("@Gia", Gia);
                cmd.Parameters.AddWithValue("@MaDanhMucMaNguyenLieu", MaDanhMucMaNguyenLieu);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                conn.Close();
          

        }
      
        public void UpdateDanhMucKho(int MaDanhMuc, string TenDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("update  DanhMucNguyenLieu set TenDanhMuc= @TenDanhMuc where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateNhomDanhMucNguyenLieu(int MaDanhMuc, string TenDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("update  NhomDanhMucNguyenLieu set TenDanhMuc= @TenDanhMuc where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateSoLuongTon(int MaNguyenLieu,float SoLuong)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("update  NguyenLieu set SoLuong = @SoLuong where MaNguyenLieu = @MaNguyenLieu", conn);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            cmd.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
