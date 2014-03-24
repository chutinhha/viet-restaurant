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
    class Load
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public DataTable LoadKhuVuc()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from KhuVuc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadBanAn(int MaKhuVuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from BanAn where MaKhuVuc = @MaKhuVuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadHoaDonBanHang(DateTime date1, DateTime date2)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(" select MaHoaDon,ThoiGian as 'Thời gian',TenViTri as 'Vị trí',DichVu as 'Dịch vụ',GiamGia as 'Giảm giá',VAT as 'VAT', TongTien as 'Tổng tiền',ThanhToan as 'Thanh toán',NhanVienThanhToan as 'Nhân viên Thanh Toán',GhiChu as 'Ghi chú'  from HoaDonBanHang where TrangThai = 'false' and ThoiGian BETWEEN @Date1 and @Date2", conn);
            da.SelectCommand.Parameters.AddWithValue("@Date1", date1);
            da.SelectCommand.Parameters.AddWithValue("@Date2", date2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        
        }
        public DataTable LoadKhuVucTheoMaBanAn(int MaBan)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from BanAn where MaBan = @MaBan", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaBan", MaBan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadKhuVucTheoMaKhuVuc(int MaKhuVuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from KhuVuc where MaKhuVuc = @MaKhuVuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadBanAnTheoMaBan(int MaBan)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from BanAn where MaBan = @MaBan", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaBan", MaBan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadHoaDonChuaThanhToanTheoMaKhuVuc(int MaKhuVuc)
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from HoaDonBanHang inner join BanAn on HoaDonBanHang.ViTri = BanAn.MaBan inner join KhuVuc on BanAn.MaKhuVuc = KhuVuc.MaKhuVuc where HoaDonBanHang.TrangThai = 'true' and KhuVuc.MaKhuVuc = @MaKhuVuc", conn);
            da.SelectCommand.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;  
        }
        public DataTable LoadKhachHang()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select MaKhachHang as 'ID',TenKhachHang as 'Tên',DiaChi as 'Địa chỉ',DienThoai as 'SĐT' from KhachHang", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadBanAn()
        {
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(" select MaBan,TenBan,TenKhuVuc from BanAn inner join KhuVuc on BanAn.MaKhuVuc = KhuVuc.MaKhuVuc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
