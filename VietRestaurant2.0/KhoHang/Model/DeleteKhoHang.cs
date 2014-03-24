using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace VietRestaurant2._0.KhoHang.Model
{
    class DeleteKhoHang
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void DeleteDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd1 = new SqlCommand("Delete from NguyenLieu where MaDanhMucNguyenLieu = @MaDanhMucNguyenLieu", conn);
            cmd1.Parameters.AddWithValue("@MaDanhMucNguyenLieu", MaDanhMuc);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            SqlCommand cmd = new SqlCommand("Delete from DanhMucNguyenLieu where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteNhomDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd1 = new SqlCommand("Delete NguyenLieu from NguyenLieu inner join DanhMucNguyenLieu on NguyenLieu.MaDanhMucNguyenLieu = DanhMucNguyenLieu.MaDanhMuc inner join NhomDanhMucNguyenLieu on DanhMucNguyenLieu.MaDanhMucNguyenLieu = NhomDanhMucNguyenLieu.MaDanhMuc where NhomDanhMucNguyenLieu.MaDanhMuc = @MaNhomDanhMuc", conn);
            cmd1.Parameters.AddWithValue("@MaNhomDanhMuc", MaDanhMuc);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd = new SqlCommand("Delete from NhomDanhMucNguyenLieu where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void DeleteNguyenLieu(int MaNguyenLieu)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Delete from NguyenLieu where MaNguyenLieu = @MaNguyenLieu", conn);
            cmd.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
