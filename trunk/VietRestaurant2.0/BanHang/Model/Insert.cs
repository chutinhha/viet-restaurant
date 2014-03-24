using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace VietRestaurant2._0.BanHang.Model
{
    class Insert
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
      public void  InsertHoaDon(int ViTri,string TenViTri)
      {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into HoaDonBanHang values (@ThoiGian,@ViTri,0,0,0,0,@TrangThai,0,0,0,@TenViTri,0,0,'false')", conn);
            cmd.Parameters.AddWithValue("@ThoiGian", DateTime.Now);
            cmd.Parameters.AddWithValue("@ViTri", ViTri);
            cmd.Parameters.AddWithValue("@TenViTri", TenViTri);
            cmd.Parameters.AddWithValue("@TrangThai", true);
            conn.Open();    
            cmd.ExecuteNonQuery();
            conn.Close();
      }
      public void InsertHoaDonChiTiet(int MaHoaDon,int MaMon,string TenMon,float SoLuong,string DonVi,float Gia,float GiamGia,float TongTien)
      {

          conn = new SqlConnection(ConnectionString);
          SqlCommand cmd = new SqlCommand("insert into ChiTietHoaDonBanHang values (@MaHoaDon,@MaMon,@TenMon,@SoLuong,@DonVi,@Gia,@GiamGia,@TongTien)", conn);
          cmd.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
          cmd.Parameters.AddWithValue("@MaMon", MaMon);
          cmd.Parameters.AddWithValue("@TenMon", TenMon);
          cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
          cmd.Parameters.AddWithValue("@DonVi", DonVi);
          cmd.Parameters.AddWithValue("@Gia", Gia);
          cmd.Parameters.AddWithValue("@GiamGia", GiamGia);
          cmd.Parameters.AddWithValue("@TongTien", TongTien);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
      }
      public void InsertBanAn(string TenBan,int MaKhuVuc)
      {
          conn = new SqlConnection(ConnectionString);
          SqlCommand cmd = new SqlCommand("insert into BanAn values (@TenBan,@MaKhuVuc)", conn);
          cmd.Parameters.AddWithValue("@TenBan", TenBan);
          cmd.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
      }
      public void InsertKhuVuc(string TenKhuVuc)
      {
          conn = new SqlConnection(ConnectionString);
          SqlCommand cmd = new SqlCommand("insert into KhuVuc values (@TenKhuVuc)", conn);
          cmd.Parameters.AddWithValue("@TenKhuVuc", TenKhuVuc);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();

          SqlDataAdapter da = new SqlDataAdapter("select top 1 * from KhuVuc order by MaKhuVuc desc", conn);
          DataTable dt = new DataTable();
          da.Fill(dt);
          int MaKhuVuc = Convert.ToInt32(dt.Rows[0][0].ToString());
          conn = new SqlConnection(ConnectionString);
          SqlCommand cmd1 = new SqlCommand("insert into BanAn values ('Bàn 1',@MaKhuVuc)", conn);
          cmd1.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
          conn.Open();
          cmd1.ExecuteNonQuery();
          conn.Close();
      }
      public void InsertKhachHang(string Ten,string SDT,string DiaChi)
      {
          conn = new SqlConnection(ConnectionString);
          SqlCommand cmd1 = new SqlCommand("insert into KhachHang values (@Ten,@DiaChi,@DienThoai,0,0)", conn);
          cmd1.Parameters.AddWithValue("@Ten", Ten);
          cmd1.Parameters.AddWithValue("@DienThoai", SDT);
          cmd1.Parameters.AddWithValue("@DiaChi", DiaChi);
          conn.Open();
          cmd1.ExecuteNonQuery();
          conn.Close();
      }
    }
}
