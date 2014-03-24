using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace VietRestaurant2._0.ThucDon
{
    class ModuleThucDon 
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public DataTable LoadNhomDanhMucThucDon()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from NhomDanhMucThucDon", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadDanhMucThucDon()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhMucThucDon", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadDanhMucNhomDanhMucThucDonTheoMaDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select NhomDanhMucThucDon.TenDanhMuc,DanhMucThucDon.TenDanhMuc from DanhMucThucDon inner join NhomDanhMucThucDon on DanhMucThucDon.MaNhomDanhMuc = NhomDanhMucThucDon.MaDanhMuc where DanhMucThucDon.MaDanhMuc = @MaDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadDanhMucNhomDanhMucThucDon()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select DanhMucThucDon.MaDanhMuc,NhomDanhMucThucDon.TenDanhMuc,DanhMucThucDon.TenDanhMuc from DanhMucThucDon inner join NhomDanhMucThucDon on DanhMucThucDon.MaNhomDanhMuc = NhomDanhMucThucDon.MaDanhMuc ", conn);          
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadDanhMucTheoNhomDanhMuc(int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhMucThucDon where MaNhomDanhMuc = @MaNhomDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadThucDonTheoDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaMonAn as 'Mã món ăn',TenMonAn as 'Tên',DonVi as 'Đơn vị',Gia as 'Giá',Anh as 'Ảnh',SoLuong as 'Số Lượng' from ThucDon where MaDanhMuc = @MaDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadThucDonTheoNhomDanhMuc(int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaMonAn as 'Mã món ăn',TenMonAn as 'Tên',DonVi as 'Đơn vị',Gia as 'Giá',Anh as 'Ảnh',SoLuong as 'Số Lượng' from ThucDon inner join DanhMucThucDon on ThucDon.MaDanhMuc = DanhMucThucDon.MaDanhMuc inner join NhomDanhMucThucDon on DanhMucThucDon.MaNhomDanhMuc = NhomDanhMucThucDon.MaDanhMuc where NhomDanhMucThucDon.MaDanhMuc = @MaNhomDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadToanBoThucDon()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaMonAn as 'Mã món ăn',TenMonAn as 'Tên',DonVi as 'Đơn vị',Gia as 'Giá',Anh as 'Ảnh',SoLuong as 'Số Lượng' from ThucDon", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadThucDonTheoMaMonAn(int MaMonAn)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from ThucDon where MaMonAn = @MaMonAn", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaMonAn", MaMonAn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadDonVi()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DonVi", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadDanhMucTheoMaDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhMucThucDon where MaDanhMuc = @MaDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadNhomDanhMucTheoMaNhomDanhMuc(int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from NhomDanhMucThucDon where MaDanhMuc = @MaNhomDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void DeleteDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd1 = new SqlCommand("Delete from ThucDon where MaDanhMuc = @MaDanhMuc", conn);
            cmd1.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            SqlCommand cmd = new SqlCommand("Delete from DanhMucThucDon where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        
        public void DeleteNhomDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd1 = new SqlCommand("Delete ThucDon from ThucDon inner join DanhMucThucDon on ThucDon.MaDanhMuc = DanhMucThucDon.MaDanhMuc inner join NhomDanhMucThucDon on DanhMucThucDon.MaNhomDanhMuc = NhomDanhMucThucDon.MaDanhMuc where NhomDanhMucThucDon.MaDanhMuc = @MaNhomDanhMuc", conn);
            cmd1.Parameters.AddWithValue("@MaNhomDanhMuc", MaDanhMuc);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd2 = new SqlCommand("Delete from DanhMucThucDon where MaDanhMuc = @MaDanhMuc", conn);
            cmd2.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();


            SqlCommand cmd = new SqlCommand("Delete from NhomDanhMucThucDon where MaDanhMuc = @MaDanhMuc", conn);
            cmd.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
          
        }
    }
}
