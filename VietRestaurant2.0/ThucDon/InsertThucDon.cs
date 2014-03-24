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
    class InsertThucDon
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void InsertDonVi(string TenDonVi)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into DonVi values (@TenDonVi)",conn );
            cmd.Parameters.AddWithValue("@TenDonVi", TenDonVi);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertMonAn(string TenMonAn,string DonVi,float Gia,string Anh,int MaDanhMuc)
        {
            if (Anh != "")
            {
                conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into ThucDon values (@TenMonAn,@DonVi,@Gia,@Anh,@MaDanhMuc)", conn);
                cmd.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd.Parameters.AddWithValue("@DonVi", DonVi);
                cmd.Parameters.AddWithValue("@Gia", Gia);
                cmd.Parameters.AddWithValue("@Anh", convertImageToBytes(Anh));
                cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {

              
                conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into ThucDon (TenMonAn,DonVi,Gia,MaDanhMuc) values (@TenMonAn,@DonVi,@Gia,@MaDanhMuc)", conn);
                cmd.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd.Parameters.AddWithValue("@DonVi", DonVi);
                cmd.Parameters.AddWithValue("@Gia", Gia);
                cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
                conn.Open();
                cmd.ExecuteNonQuery();
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
        public void InsertNhomDanhMuc(string NhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into NhomDanhMucThucDon values (@TenDanhMuc)",conn);
            cmd.Parameters.AddWithValue("@TenDanhMuc", NhomDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertDanhMucThucDon(string TenDanhMuc,int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into DanhMucThucDon values (@TenDanhMuc,@MaNhomDanhMuc)", conn);
            cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMuc);
            cmd.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
