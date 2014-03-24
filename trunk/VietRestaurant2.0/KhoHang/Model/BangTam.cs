using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace VietRestaurant2._0.KhoHang.Model
{
    class BangTam
    {
        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        DataTable dt;
        public void DataTable()
        { 
            
        }








        //public void TaoBangTam()
        //{
        //    conn = new SqlConnection(ConnectionString);
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("create table ##GolbalHoaDon (id int identity primary key,MaMatHang int,TenMatHang nvarchar(50),DonVi nvarchar(50),SoLuong float,DonGia float,ThanhTien float)",conn);
        //    cmd.ExecuteNonQuery();
            
        //}
        //public void InsertBangTam(int MaMatHang,string TenMatHang,string DonVi,float SoLuong,float DonGia,float ThanhTien)
        //{
        //    conn = new SqlConnection(ConnectionString);
        //    SqlCommand cmd = new SqlCommand("Insert into ##GolbalHoaDon values (@MaMatHang,@TenMatHang,@DonVi,@SoLuong,@DonGia,@ThanhTien)",conn);
        //    cmd.Parameters.AddWithValue("@MaMatHang", MaMatHang);
        //    cmd.Parameters.AddWithValue("@TenMatHang", TenMatHang);
        //    cmd.Parameters.AddWithValue("@DonVi",DonVi);
        //    cmd.Parameters.AddWithValue("@SoLuong",SoLuong);
        //    cmd.Parameters.AddWithValue("@DonGia",DonGia);
        //    cmd.Parameters.AddWithValue("@ThanhTien",ThanhTien);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();


        //    DataTable dt = new DataTable();
        //    DataRow dr =  dt.NewRow();
        //    SqlConnection();

        //}

        //private void SqlConnection()
        //{
        //    throw new NotImplementedException();
        //}
        //public DataTable SelectBangTam()
        //{
        //    conn = new SqlConnection(ConnectionString);
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("select * from ##GolbalHoaDon", conn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
        //public void DropBangTam()
        //{
        //    conn = new SqlConnection(ConnectionString);
        //    SqlCommand cmd = new SqlCommand("Drop table ##GolbalHoaDon", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
