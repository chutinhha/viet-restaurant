using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietRestaurant2._0.BanHang
{
    public partial class ListKhachHang : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ListKhachHang()
        {
            InitializeComponent();
        }

        private void ListKhachHang_Load(object sender, EventArgs e)
        {

            BanHang.Model.Load load = new BanHang.Model.Load();
            DataTable dt = load.LoadKhachHang();
            dataGridViewXListKhachHang.DataSource = dt;
            dataGridViewXListKhachHang.Columns[1].Visible = false;
            for (int i = 0; i < dataGridViewXListKhachHang.Rows.Count; i++)
            {

                dataGridViewXListKhachHang.Rows[i].Cells["STT1"].Value = i + 1;

            }
        }
        public delegate void  ListKhachHang1(int ID, string Name, string SDT, string DiaChi);
        public ListKhachHang1 KhachHang;
        private void dataGridViewXListKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(dataGridViewXListKhachHang.SelectedRows[0].Cells[1].Value.ToString());
            string Name = dataGridViewXListKhachHang.SelectedRows[0].Cells[2].Value.ToString();
            string SDT = dataGridViewXListKhachHang.SelectedRows[0].Cells[4].Value.ToString();
            string DiaChi = dataGridViewXListKhachHang.SelectedRows[0].Cells[3].Value.ToString();
            KhachHang(ID, Name, SDT, DiaChi);
            this.Close();
            
        }
      
    }
}
