using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VietRestaurant2._0.KhoHang.Model
{
    class LoadKhoHang
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public DataTable LoadNhomDanhMucNguyenLieu()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from NhomDanhMucNguyenLieu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
             public DataTable LoadDanhMucNguyenLieu()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhMucNguyenLieu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadNhomDanhMucNguyenLieuDanhMucNguyenLieuTheoMaDanhMuc(int MaDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select NhomDanhMucNguyenLieu.TenDanhMuc,DanhMucNguyenLieu.TenDanhMuc from DanhMucNguyenLieu inner join NhomDanhMucNguyenLieu on DanhMucNguyenLieu.MaDanhMucNguyenLieu = NhomDanhMucNguyenLieu.MaDanhMuc where DanhMucNguyenLieu.MaDanhMuc = @MaDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadDanhMucNhomDanhMucNguyenLieu()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select DanhMucNguyenLieu.MaDanhMuc as 'ID',DanhMucNguyenLieu.TenDanhMuc as 'Danh Mục',NhomDanhMucNguyenLieu.TenDanhMuc as 'Nhóm' from DanhMucNguyenLieu inner join NhomDanhMucNguyenLieu on DanhMucNguyenLieu.MaDanhMucNguyenLieu = NhomDanhMucNguyenLieu.MaDanhMuc ", conn);          
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadDanhMucTheoNhomNguyenLieu(int MaDanhMucNguyenLieu)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhMucNguyenLieu where MaDanhMucNguyenLieu = @MaDanhMucNguyenLieu", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMucNguyenLieu", MaDanhMucNguyenLieu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadNguyenLieuTheoDanhMuc(int MaDanhMucNguyenLieu)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaNguyenLieu as 'Mã nguyên liệu',TenNguyenLieu as 'Tên nguyên liệu',SoLuong as 'Số Lượng',DonVi as 'Đơn vị',Gia as 'Giá' from NguyenLieu where MaDanhMucNguyenLieu = @MaDanhMucNguyenLieu", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMucNguyenLieu", MaDanhMucNguyenLieu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadNguyenLieuTheoNhomDanhMuc(int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaNguyenLieu as 'Mã nguyên liệu',TenNguyenLieu as 'Tên nguyên liệu',SoLuong as 'Số Lượng',DonVi as 'Đơn vị',Gia as 'Giá' from NguyenLieu inner join DanhMucNguyenLieu on NguyenLieu.MaDanhMucNguyenLieu = DanhMucNguyenLieu.MaDanhMuc inner join NhomDanhMucNguyenLieu on DanhMucNguyenLieu.MaDanhMucNguyenLieu = NhomDanhMucNguyenLieu.MaDanhMuc where NhomDanhMucNguyenLieu.MaDanhMuc = @MaNhomDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadToanBoNguyenLieu()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaNguyenLieu as 'Mã nguyên liệu',TenNguyenLieu as 'Tên',SoLuong as 'Số Lượng',DonVi as 'Đơn vị',Gia as 'Giá' from NguyenLieu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadNguyenLieuTheoMaNguyenLieu(int MaNguyenLieu)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from NguyenLieu where MaNguyenLieu = @MaNguyenLieu", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
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
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhMucNguyenLieu where MaDanhMuc = @MaDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaDanhMuc", MaDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadNhomDanhMucTheoMaNhomDanhMuc(int MaNhomDanhMuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from NhomDanhMucNguyenLieu where MaDanhMuc = @MaNhomDanhMuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNhomDanhMuc", MaNhomDanhMuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    
    
    }
}
