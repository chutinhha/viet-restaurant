using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace VietRestaurant2._0.ThucDon
{
    class UpdateThucDon
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void UpdateMonAn(int MaMonAn, string TenMonAn,string DonVi,float Gia,string Anh,int MaDanhMuc)
        {
            if (Anh != "")
            {
                conn = new SqlConnection(ConnectionString);
                string query = "update ThucDon set TenMonAn = @TenMonAn,DonVi = @DonVi,Gia = @Gia,Anh=@Anh,MaDanhMuc=@MaDanhMuc where MaMonAn = @MaMonAn ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMonAn", MaMonAn);
                cmd.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd.Parameters.AddWithValue("@DonVi", DonVi);
                cmd.Parameters.AddWithValue("@Gia", Gia);
                cmd.Parameters.AddWithValue("@Anh", convertImageToBytes(Anh));
                cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn = new SqlConnection(ConnectionString);
                string query = "update ThucDon set TenMonAn = @TenMonAn,DonVi = @DonVi,Gia = @Gia,MaDanhMuc=@MaDanhMuc where MaMonAn = @MaMonAn ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMonAn", MaMonAn);
                cmd.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd.Parameters.AddWithValue("@DonVi", DonVi);
                cmd.Parameters.AddWithValue("@Gia", Gia);
                cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        public byte[] convertImageToBytes(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        public void DeleteThucDon(int MaMonAn)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from ThucDon where MaMonAn = @MaMonAn",conn);
            cmd.Parameters.AddWithValue("@MaMonAn", MaMonAn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateDanhMucThucDon(int MaDanhMuc,string TenDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("update  DanhMucThucDon set TenDanhMuc= @TenDanhMuc where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateNhomDanhMucThucDon(int MaDanhMuc, string TenDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("update  NhomDanhMucThucDon set TenDanhMuc= @TenDanhMuc where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateCheBien(int MaMonAn, int MaNguyenLieu, float SoLuong)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Update CheBien set SoLuong = SoLuong+@SoLuong where MaMonAn = @MaMonAn and MaNguyenLieu = MaNguyenLieu)", conn);
            cmd.Parameters.AddWithValue("@MaMonAn", MaMonAn);
            cmd.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
