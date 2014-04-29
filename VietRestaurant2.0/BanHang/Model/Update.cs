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
    class Update
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public void UpdateChiTietHoaDon(int MaChiTietHoaDon,float SoLuong,float GiamGia)
        {

            conn = new SqlConnection(ConnectionString);
            string query = "update ChiTietHoaDonBanHang set SoLuong = SoLuong+ @SoLuong,GiamGia=@GiamGia,TongTien = Gia*(SoLuong+@SoLuong)-@GiamGia where MaChiTietHoaDon = @MaChiTietHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            cmd.Parameters.AddWithValue("@GiamGia ",GiamGia);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void UpdateThemSoLuongMonAn(int MaChiTietHoaDon,float SoLuong)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update ChiTietHoaDonBanHang set SoLuong = SoLuong+ @SoLuong,TongTien = Gia*(SoLuong+@SoLuong)-GiamGia where MaChiTietHoaDon = @MaChiTietHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateGiamSoLuongMonAn(int MaChiTietHoaDon, float SoLuong)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update ChiTietHoaDonBanHang set SoLuong = SoLuong- @SoLuong,TongTien = Gia*(SoLuong-@SoLuong)-GiamGia where MaChiTietHoaDon = @MaChiTietHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void UpdateGiamGiaMonAn(int MaChiTietHoaDon, float GiamGia)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update ChiTietHoaDonBanHang set GiamGia = @GiamGia, TongTien = Gia*SoLuong -@GiamGia where MaChiTietHoaDon = @MaChiTietHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            cmd.Parameters.AddWithValue("@GiamGia", GiamGia);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateHoaDon(int MaHoaDon,float DichVu,int GiamGia,int VAT,float TongTien,float ThanhToan,string GhiChu)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update HoaDonBanHang set DichVu = @DichVu, GiamGia = @GiamGia,VAT= @VAT,TongTien = @TongTien,ThanhToan= @ThanhToan,GhiChu= @GhiChu,TrangThai = 'false'   where MaHoaDon = @MaHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            cmd.Parameters.AddWithValue("@GiamGia", GiamGia);
            cmd.Parameters.AddWithValue("@DichVu", DichVu);
            cmd.Parameters.AddWithValue("@VAT", VAT);
            cmd.Parameters.AddWithValue("@ThanhToan", ThanhToan);
            cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
            cmd.Parameters.AddWithValue("@TongTien", TongTien);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateHoaDonGhiNo(int MaHoaDon, float DichVu, int GiamGia, int VAT, float TongTien, float ThanhToan, string GhiChu,int MaKhachHang,string TenKhachHang)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update HoaDonBanHang set DichVu = @DichVu, GiamGia = @GiamGia,VAT= @VAT,TongTien = @TongTien,ThanhToan= @ThanhToan,GhiChu= @GhiChu,TrangThai = 'false',MaKhachHang = @MaKhachHang,TenKhachHang = @TenKhachHang,TinhTrangThanhToan = 'true'   where MaHoaDon = @MaHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            cmd.Parameters.AddWithValue("@GiamGia", GiamGia);
            cmd.Parameters.AddWithValue("@DichVu", DichVu);
            cmd.Parameters.AddWithValue("@VAT", VAT);
            cmd.Parameters.AddWithValue("@ThanhToan", ThanhToan);
            cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
            cmd.Parameters.AddWithValue("@TongTien", TongTien);
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
            cmd.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void  UpdateBanAn(int MaBan,string TenBan)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update BanAn set TenBan = @TenBan where MaBan = @MaBan ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaBan", MaBan);
            cmd.Parameters.AddWithValue("@TenBan", TenBan);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateKhuVuc(int MaKhuVuc, string TenKhuVuc)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update KhuVuc set TenKhuVuc = @TenKhuVuc where MaKhuVuc = @MaKhuVuc ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
            cmd.Parameters.AddWithValue("@TenKhuVuc", TenKhuVuc);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateGiaMonAn(int MaChiTietHoaDon,float GiaMonAn)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update ChiTietHoaDonBanHang set Gia = @Gia,TongTien = @Gia*SoLuong - GiamGia where MaChiTietHoaDon = @MaChiTietHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Gia", GiaMonAn);
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", MaChiTietHoaDon);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateHoaDonGhiNoKhachHangMoi(int MaHoaDon, float DichVu, int GiamGia, int VAT, float TongTien, float ThanhToan, string GhiChu)
        {
            
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select top 1 * from KhachHang order by MaKhachHang desc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int MaKhachHang = Convert.ToInt32(dt.Rows[0][0].ToString());
            string TenKhachHang = dt.Rows[0][1].ToString();

            conn = new SqlConnection(ConnectionString);
            string query = "update HoaDonBanHang set DichVu = @DichVu, GiamGia = @GiamGia,VAT= @VAT,TongTien = @TongTien,ThanhToan= @ThanhToan,GhiChu= @GhiChu,TrangThai = 'false',MaKhachHang = @MaKhachHang,TenKhachHang = @TenKhachHang,TinhTrangThanhToan = 'true'   where MaHoaDon = @MaHoaDon ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
            cmd.Parameters.AddWithValue("@GiamGia", GiamGia);
            cmd.Parameters.AddWithValue("@DichVu", DichVu);
            cmd.Parameters.AddWithValue("@VAT", VAT);
            cmd.Parameters.AddWithValue("@ThanhToan", ThanhToan);
            cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
            cmd.Parameters.AddWithValue("@TongTien", TongTien);
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
            cmd.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateSoLuongMonAn()
        {
            //load tat ca cac ma mon an tu mon an
            conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(" select MaMonAn from CheBien group by MaMonAn", conn);
            DataTable dtThucDon = new DataTable();
            da.Fill(dtThucDon);
            //load tat ca id mon an, kiem tra xem co trong che bien khong
            for (int i = 0; i < dtThucDon.Rows.Count; i++)
            {
                SqlDataAdapter daCheBien = new SqlDataAdapter("select * from CheBien where MaMonAn = @MaMonAn", conn);
                DataTable dtCheBien = new DataTable();
                daCheBien.SelectCommand.Parameters.AddWithValue("@MaMonAn", Convert.ToInt32(dtThucDon.Rows[i][0].ToString()));
                daCheBien.Fill(dtCheBien);
                if (dtCheBien.Rows.Count > 0)
                {
                    int[] a= new int[100];
                    for (int j = 0; j < dtCheBien.Rows.Count; j++)
                    {
                        SqlDataAdapter daNguyenLieu = new SqlDataAdapter("select * from NguyenLieu where MaNguyenLieu = @MaNguyenLieu",conn);
                        daNguyenLieu.SelectCommand.Parameters.AddWithValue("@MaNguyenLieu", Convert.ToInt32(dtCheBien.Rows[j][2].ToString()));
                        DataTable dtNguyenLieu = new DataTable();
                        daNguyenLieu.Fill(dtNguyenLieu);
                        a[j] = (int)( float.Parse(dtNguyenLieu.Rows[0][2].ToString())/float.Parse(dtCheBien.Rows[j][3].ToString()));
                    }
                    int min = a[0];
                    for (int k = 0; k < dtCheBien.Rows.Count; k++)
                    {
                        if (min > a[k])
                        {
                            min = a[k];
                        }
                      
                    }
                    // tim duoc min thi update vao so luong
                    string query = "update ThucDon set SoLuong = @SoLuong where MaMonAn = @MaMonAn ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaMonAn", Convert.ToInt32(dtThucDon.Rows[i][0].ToString()));
                    cmd.Parameters.AddWithValue("@SoLuong", min);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    // nhung mon khong che bien thi so luong  = null
                    // nhung mon co so luong khac null
                    SqlDataAdapter daThucDonNotNull = new SqlDataAdapter("select MaMonAn from ThucDon where SoLuong is Not Null",conn);
                    DataTable dtThucDonNotNull = new DataTable();
                    daThucDonNotNull.Fill(dtThucDonNotNull);
                    for (int f = 0; f < dtThucDonNotNull.Rows.Count; f++)
                    {
                        int MaMonAnKT = Convert.ToInt32( dtThucDonNotNull.Rows[f][0].ToString());
                        SqlDataAdapter daKiemTra = new SqlDataAdapter("select * from CheBien where MaMonAn = @MaMonAn", conn);
                        daKiemTra.SelectCommand.Parameters.AddWithValue("@MaMonAn",MaMonAnKT);
                        DataTable dtKiemTra = new DataTable();
                        daKiemTra.Fill(dtKiemTra);
                        if (dtKiemTra.Rows.Count == 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("Update ThucDon set SoLuong = null where MaMonAn = @MaMonAn",conn);
                            cmd2.Parameters.AddWithValue("@MaMonAn", MaMonAnKT);
                            conn.Open();
                            cmd2.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    
                    
                }
            }
            

        }
        public void UpdateChuyenBanAn(int ViTriDauTien,int ViTri,string TenViTri)
        {
            conn = new SqlConnection(ConnectionString);
            string query = "update HoaDonBanHang set ViTri = @ViTri,TenViTri = @TenViTri where ViTri = @ViTriDauTien ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ViTri", ViTri);
            cmd.Parameters.AddWithValue("@ViTriDauTien", ViTriDauTien);
            cmd.Parameters.AddWithValue("@TenViTri", TenViTri);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int LayHangTrongKho(int MaMonAn,float SoLuong)
        {
            int kiemtra = 0;
            try
            {
                //load cac nguyen lieu trong che bien
                conn = new SqlConnection(ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(" select CheBien.ID,CheBien.MaMonAn,CheBien.MaNguyenLieu,CheBien.SoLuong,NguyenLieu.SoLuong from CheBien inner join NguyenLieu on CheBien.MaNguyenLieu = NguyenLieu.MaNguyenLieu where MaMonAn = @MaMonAn", conn);
                da.SelectCommand.Parameters.AddWithValue("@MaMonAn", MaMonAn);
                DataTable dt = new DataTable();
                da.Fill(dt); // Nguyen lieu cua 1 mon
                string query=""; 
                SqlTransaction transaction;
                conn.Open();
                transaction = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Transaction = transaction;
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float SoLuongNguyenLieu = SoLuong * float.Parse(dt.Rows[i][3].ToString());
                    //kiem tra so luong nguyen lieu trong kho
                  
                    float SoLuongTon = float.Parse(dt.Rows[i][4].ToString());
                    if (SoLuongTon >= SoLuongNguyenLieu)
                    {
                        cmd.Parameters.Clear();
                        query = "update NguyenLieu set SoLuong = SoLuong-@SoLuong where MaNguyenLieu = @MaNguyenLieu ";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@SoLuong", SoLuongNguyenLieu);
                        cmd.Parameters.AddWithValue("@MaNguyenLieu", Convert.ToInt32(dt.Rows[i][2].ToString()));
                        cmd.ExecuteNonQuery();
                        count++;
                    }
                  
                }
                if (count < dt.Rows.Count)
                {
                    transaction.Rollback();
                    
                }
                else
                {
                    transaction.Commit();
                    kiemtra = 1;
                }
                
            }
            catch 
            {
              
            }
            return kiemtra;
          
        }
        public void TraHangTrongKho(int MaMonAn, float SoLuong)
        {
            try
            {
                //load cac nguyen lieu trong che bien
                conn = new SqlConnection(ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(" select * from CheBien where MaMonAn = @MaMonAn", conn);
                da.SelectCommand.Parameters.AddWithValue("@MaMonAn", MaMonAn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float SoLuongNguyenLieu = SoLuong * float.Parse(dt.Rows[i][3].ToString());
                        string query = "update NguyenLieu set SoLuong = SoLuong+@SoLuong where MaNguyenLieu = @MaNguyenLieu ";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@SoLuong", SoLuongNguyenLieu);
                        cmd.Parameters.AddWithValue("@MaNguyenLieu", Convert.ToInt32(dt.Rows[i][2].ToString()));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                   
                }
            }
            catch
            {

            }

        }
    }
}
