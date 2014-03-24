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
    class Delete
    {
         SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void DeleteMonAn(int MaChiTietHoaDon)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "delete from ChiTietHoaDonBanHang where MaChiTietHoaDon = @MaChiTietHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteHoaDon(int MaHoaDon)
        { 
            //Xóa chi tiết hóa đơn
            conn = new SqlConnection(ConnectionString);
            string query = "delete from ChiTietHoaDonBanHang where MaHoaDon = @MaHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
            //Xóa hóa đơn
            conn = new SqlConnection(ConnectionString);
            string query1 = "delete from HoaDonBanHang where MaHoaDon = @MaHoaDon ";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            conn.Open();
            int a1 = cmd1.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteBanAn(int MaBan)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "delete from BanAn where MaBan = @MaBan ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaBan", MaBan);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteKhuVuc(int MaKhuVuc)
        {
             conn = new SqlConnection(ConnectionString);
            string query1 = "delete from BanAn where MaKhuVuc = @MaKhuVuc ";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
            conn.Open();
            int a = cmd1.ExecuteNonQuery();
            conn.Close();
        

            conn = new SqlConnection(ConnectionString);
            string query = "delete from KhuVuc where MaKhuVuc = @MaKhuVuc ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
            conn.Open();
             cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
