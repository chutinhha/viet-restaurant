using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace VietRestaurant2._0.HoaDon.model
{
    class Load
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public DataTable LoadHoaDonNhapHang(DateTime date1,DateTime date2)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaHoaDon,ThoiGian as 'Thời gian',TongTien as 'Tổng tiền',GhiChu as 'Ghi chú' from HoaDonNhapHang where ThoiGian BETWEEN @Date1 and @Date2", conn);
            da.SelectCommand.Parameters.AddWithValue("@Date1",date1);
            da.SelectCommand.Parameters.AddWithValue("@Date2", date2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadChiTietHoaDonNhapHang(int MaHoaDon)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select TenMatHang as 'Tên',SoLuong as 'Số lượng',DonVi as 'Đơn vị',DonGia as 'Đơn giá',ThanhTien as 'Tiền' from HoaDonNhapHangChiTiet where MaHoaDon = @MaHoaDon", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       
        public DataTable LoadHoaDonChuaThanhToan()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from HoaDonBanHang where TrangThai = 'True'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadHoaDonChuaThanhToanCanChon(int ViTri)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select HoaDonBanHang.*,BanAn.TenBan from HoaDonBanHang inner join BanAn on HoaDonBanHang.ViTri = BanAn.MaBan where TrangThai = 'true' and ViTri = @ViTri", conn);
            da.SelectCommand.Parameters.AddWithValue("@ViTri", ViTri);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadChiTietHoaDonChuaThanhToanCanChon(int MaHoaDon)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaChiTietHoaDon,MaMon,TenMon as 'Tên',SoLuong as 'Số lượng',DonVi as 'Đơn vị',Gia as 'Giá',GiamGia as 'Giảm giá',TongTien as 'Tổng tiền' from ChiTietHoaDonBanHang where MaHoaDon = @MaHoaDon ", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadMonAn(int MaHoaDon, int MaMonAn)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from ChiTietHoaDonBanHang where MaHoaDon = @MaHoaDon and MaMon = @MaMon ", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            da.SelectCommand.Parameters.AddWithValue("@MaMon", MaMonAn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadChiTietHoaDonTheoMaChiTietHoaDon(int MaChiTietHoaDon)
        {

            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaChiTietHoaDon,MaMon,TenMon as 'Tên',SoLuong as 'Số lượng',DonVi as 'Đơn vị',Gia as 'Giá',GiamGia as 'Giảm giá',TongTien as 'Tổng tiền' from ChiTietHoaDonBanHang where MaChiTietHoaDon = @MaChiTietHoaDon ", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadChiTietHoaDonTheoMaHoaDon(int MaHoaDon)
        {

            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select TenMon as 'Tên',SoLuong as 'Số lượng',DonVi as 'Đơn vị',Gia as 'Giá',GiamGia as 'Giảm giá',TongTien as 'Tổng tiền' from ChiTietHoaDonBanHang where MaHoaDon = @MaHoaDon ", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadHoaDonTheoMaHoaDon(int MaHoaDon)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from HoaDonBanHang where MaHoaDon = @MaHoaDon ", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadHoaDonNhapHangTheoMaHoaDon(int MaHoaDon)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from HoaDonNhapHang where MaHoaDon = @MaHoaDon ", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
