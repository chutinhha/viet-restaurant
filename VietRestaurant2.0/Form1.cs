using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;


namespace VietRestaurant2._0
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
       //     AutoCompleteText();
        }

        private void metroTabItemThucDon_Click(object sender, EventArgs e)
        {
            LoadTreeViewThucDon();
            LoadDataGridViewThucDon();
        }

        private void LoadTreeViewThucDon()
        {
            advTreeThucDon.Nodes.Clear();
            DevComponents.AdvTree.Node node2 = new DevComponents.AdvTree.Node();
            node2.Text = "Tất cả";
            DevComponents.AdvTree.Node node3 = new DevComponents.AdvTree.Node();
            node3.Text = "Tất cả thực đơn";
            node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node3 });
            node3.Image = global::VietRestaurant2._0.Properties.Resources._001_43;
            advTreeThucDon.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node2 });


            ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
            DataTable dtNhom = thucdon.LoadNhomDanhMucThucDon();
            int a = dtNhom.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                node.Text = dtNhom.Rows[i]["TenDanhMuc"].ToString();
                node.Name = "a"+ dtNhom.Rows[i]["MaDanhMuc"].ToString();

                DataTable dt = thucdon.LoadDanhMucTheoNhomDanhMuc(Convert.ToInt32(dtNhom.Rows[i]["MaDanhMuc"].ToString()));
                int b = dt.Rows.Count;
                    for (int j = 0; j < b; j++)
                    {
                    DevComponents.AdvTree.Node node1 = new DevComponents.AdvTree.Node();
                    node1.Text = dt.Rows[j]["TenDanhMuc"].ToString();
                    node1.Name = dt.Rows[j]["MaDanhMuc"].ToString();
                    node1.Image = global::VietRestaurant2._0.Properties.Resources._001_43;
                    node.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node1 });
                    }
                advTreeThucDon.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node });
                
            }
            advTreeThucDon.ExpandAll();
        }

        private void advTreeThucDon_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            LoadDataGridViewThucDon();
        }
        public void LoadDataGridViewThucDon()
        {
           
            string s="";

            try
            {
                s = advTreeThucDon.SelectedNode.Name;
                int MaDanhMuc = Convert.ToInt32(s);
                MaDanhMucThucDon = MaDanhMuc;
                ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
                DataTable dt = thudon.LoadThucDonTheoDanhMuc(MaDanhMuc);
                loadData(dt);
                toolStripMenuItemThemMon.Enabled = true;
                ToolStripMenuItemThemDanhMuc.Enabled = true;
                ToolStripMenuItemSuaDanhMuc.Enabled = true;
            }
            catch 
            {
                try
                {
                    
                    int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                    ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
                    DataTable dt = thudon.LoadThucDonTheoNhomDanhMuc(NhomDanhMuc);
                    loadData(dt);
                    ToolStripMenuItemThemDanhMuc.Enabled = true;
                    toolStripMenuItemThemMon.Enabled = false;
                    ToolStripMenuItemSuaDanhMuc.Enabled = true;
                   
                }
                catch
                {
                    
                    ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
                    DataTable dt = thudon.LoadToanBoThucDon();
                    dataGridViewXThucDon.DataSource = dt;
                    loadData(dt);
                    ToolStripMenuItemThemDanhMuc.Enabled = false;
                    toolStripMenuItemThemMon.Enabled = false;
                    ToolStripMenuItemSuaDanhMuc.Enabled = false;
                    }
            }
        }
        public void  loadData(DataTable dt)
        {
                dataGridViewXThucDon.DataSource = dt;
                dataGridViewXThucDon.AllowUserToResizeRows = false;
                dataGridViewXThucDon.Columns[1].Visible = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dataGridViewXThucDon.Rows[i].Cells["ThuTu"].Value = i + 1;

                }
               
               DataGridViewImageColumn dc = dataGridViewXThucDon.Columns[5] as DataGridViewImageColumn;
               dc.ImageLayout = DataGridViewImageCellLayout.Zoom;
               dataGridViewXThucDon.Columns[2].Width = 500;
        }
      
       

        private void toolStripMenuItemThemMon_Click(object sender, EventArgs e)
        {
            ThemMon themMon = new ThemMon(MaDanhMucThucDon);
            themMon.ShowDialog();
            LoadDataGridViewThucDon();
        }

        private void toolStripMenuItemSuaMon_Click(object sender, EventArgs e)
        {
             try 
	        {	        
                 int maMon = Convert.ToInt32(dataGridViewXThucDon.SelectedRows[0].Cells[1].Value.ToString());
                 SuaMon suaMon = new SuaMon(maMon);
                 suaMon.ShowDialog();
                 LoadDataGridViewThucDon();
	        }
	        catch (Exception)
	        {
		
		       MessageBox.Show("Bạn chưa chọn món");
	        }
           
        }

        private void toolStripMenuItemXoaMon_Click(object sender, EventArgs e)
        {
            try
            {
                int MaMon = Convert.ToInt32(dataGridViewXThucDon.SelectedRows[0].Cells[1].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn xóa?", "Xóa Món", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ThucDon.UpdateThucDon thucDon = new ThucDon.UpdateThucDon();
                    thucDon.DeleteThucDon(MaMon);
                    LoadDataGridViewThucDon();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chưa chọn món");
            }
            
        }

        private void toolStripMenuItemNhapExcel_Click(object sender, EventArgs e)
        {

        }
        int MaDanhMucThucDon = 0;

  
        private void ToolStripMenuItemThemNhomDanhMuc_Click(object sender, EventArgs e)
        {
            ThemNhomDanhMuc them = new ThemNhomDanhMuc();
            them.ShowDialog();
            LoadTreeViewThucDon();
        }

        private void ToolStripMenuItemThemDanhMuc_Click(object sender, EventArgs e)
        {
            string s = advTreeThucDon.SelectedNode.Name;
            try
            {
               int DanhMuc = Convert.ToInt32(s);
                // load Nhom danh muc
               ThucDon.ModuleThucDon load = new ThucDon.ModuleThucDon();
               DataTable dt = load.LoadDanhMucTheoMaDanhMuc(DanhMuc);
               int NhomDanhMuc = Convert.ToInt32(dt.Rows[0][2].ToString());
               ThemDanhMuc them = new ThemDanhMuc(NhomDanhMuc);
               them.ShowDialog();
               LoadTreeViewThucDon();
            }
            catch 
            {
                int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                ThemDanhMuc them = new ThemDanhMuc(NhomDanhMuc);
                them.ShowDialog();
                LoadTreeViewThucDon();
            }
            
        }

        private void ToolStripMenuItemSuaDanhMuc_Click(object sender, EventArgs e)
        {
            string s = "";
            try
            {
               s = advTreeThucDon.SelectedNode.Name;
               int DanhMuc = Convert.ToInt32(s);
               SuaDanhMuc sua = new SuaDanhMuc(DanhMuc);
               sua.ShowDialog();
               LoadTreeViewThucDon();
            }
            catch (Exception)
            {
                try
                {
                    int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                    SuaNhomDanhMuc sua = new SuaNhomDanhMuc(NhomDanhMuc);
                    sua.ShowDialog();
                    LoadTreeViewThucDon();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn chưa chọn mục");
                }
                    
            }
        }

        private void ToolStripMenuItemXoaDanhMuc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Xóa", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                string s = "";
                try
                {
                    s = advTreeThucDon.SelectedNode.Name;
                    int NhomDanhMuc = Convert.ToInt32(s);
                    ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
                    thucdon.DeleteDanhMuc(NhomDanhMuc);
                    LoadTreeViewThucDon();
                    LoadDataGridViewThucDon();
                }
                catch (Exception)
                {
                    try
                    {
                        int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                        ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
                        thucdon.DeleteNhomDanhMuc(NhomDanhMuc);
                        LoadTreeViewThucDon();
                        LoadDataGridViewThucDon();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Bạn chưa chọn mục");
                    }

                }
            }
                
        }
        //KHO HANG
        //
        //
        private void metroTabItemKhoHang_Click(object sender, EventArgs e)
        {
            LoadTreeViewKhoHang();
            LoadDataGridViewKhoNguyenLieu();
        }
        public void loadDataKho(DataTable dt)
        {
            dataGridViewXKhoHang.DataSource = dt;
            dataGridViewXKhoHang.AllowUserToResizeRows = false;
            dataGridViewXKhoHang.Columns[1].Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dataGridViewXKhoHang.Rows[i].Cells["STT"].Value = i + 1;

            }

        }
        private void LoadTreeViewKhoHang()
        {
            advTreeKhoHang.Nodes.Clear();
            DevComponents.AdvTree.Node node2 = new DevComponents.AdvTree.Node();
            node2.Text = "Tất cả";
            DevComponents.AdvTree.Node node3 = new DevComponents.AdvTree.Node();
            node3.Text = "Tất cả kho hàng";
            node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node3 });
            node3.Image = global::VietRestaurant2._0.Properties.Resources._001_43;
            advTreeKhoHang.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node2 });

           
            KhoHang.Model.LoadKhoHang kho = new KhoHang.Model.LoadKhoHang();
            DataTable dtNhom = kho.LoadNhomDanhMucNguyenLieu();
            int a = dtNhom.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                node.Text = dtNhom.Rows[i]["TenDanhMuc"].ToString();
                node.Name = "a" + dtNhom.Rows[i]["MaDanhMuc"].ToString();

                DataTable dt = kho.LoadDanhMucTheoNhomNguyenLieu(Convert.ToInt32(dtNhom.Rows[i]["MaDanhMuc"].ToString()));
                int b = dt.Rows.Count;
                for (int j = 0; j < b; j++)
                {
                    DevComponents.AdvTree.Node node1 = new DevComponents.AdvTree.Node();
                    node1.Text = dt.Rows[j]["TenDanhMuc"].ToString();
                    node1.Name = dt.Rows[j]["MaDanhMuc"].ToString();
                    node1.Image = global::VietRestaurant2._0.Properties.Resources._001_43;
                    node.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node1 });
                }
                advTreeKhoHang.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node });

            }
            advTreeKhoHang.ExpandAll();
        }
        public void LoadDataGridViewKhoNguyenLieu()
        {

            string s = "";

            try
            {
                s = advTreeKhoHang.SelectedNode.Name;
                int MaDanhMuc = Convert.ToInt32(s);
                MaDanhMucThucDon = MaDanhMuc;
                KhoHang.Model.LoadKhoHang kho = new KhoHang.Model.LoadKhoHang();
                DataTable dt = kho.LoadNguyenLieuTheoDanhMuc(MaDanhMuc);
                loadDataKho(dt);
                toolStripMenuItemThemDanhMucNguyenLieu.Enabled = false;
                toolStripMenuItemSuaTenDanhMucNguyenLieu.Enabled = true;
                toolStripMenuItemXoaDanhMucNguyenLieu.Enabled = true;
                toolStripMenuItemThemNguyenLieu.Enabled = true;
                
            }
            catch (Exception)
            {
                try
                {
                   
                    int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                    KhoHang.Model.LoadKhoHang kho = new KhoHang.Model.LoadKhoHang();
                    DataTable dt = kho.LoadNguyenLieuTheoNhomDanhMuc(NhomDanhMuc);
                    loadDataKho(dt);
                    toolStripMenuItemThemNguyenLieu.Enabled = false;
                    toolStripMenuItemThemDanhMucNguyenLieu.Enabled = true;
                    toolStripMenuItemSuaTenDanhMucNguyenLieu.Enabled = true;
                    toolStripMenuItemXoaDanhMucNguyenLieu.Enabled = true;
                    
                }
                catch
                {

                    KhoHang.Model.LoadKhoHang kho = new KhoHang.Model.LoadKhoHang();
                    DataTable dt = kho.LoadToanBoNguyenLieu();
                    loadDataKho(dt);
                    toolStripMenuItemThemDanhMucNguyenLieu.Enabled = false;
                    toolStripMenuItemSuaTenDanhMucNguyenLieu.Enabled = false;
                    toolStripMenuItemXoaDanhMucNguyenLieu.Enabled = false;
                    toolStripMenuItemThemNguyenLieu.Enabled = false;
                    
                }
            }
        }
        private void advTreeKhoHang_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            LoadDataGridViewKhoNguyenLieu();
        }
        private void metroTabItemHoaDon_Click(object sender, EventArgs e)
        {
            dateTimeInput2.Value = DateTime.Now;
           
        }


        private void toolStripMenuItemThemNhomDanhMucNguyenLieu_Click(object sender, EventArgs e)
        {
            KhoHang.ThemNhomDanhMuc them = new KhoHang.ThemNhomDanhMuc();
            them.ShowDialog();
            LoadTreeViewKhoHang();
        }

        private void toolStripMenuItemThemDanhMucNguyenLieu_Click(object sender, EventArgs e)
        {
            try
            {
                string s = advTreeKhoHang.SelectedNode.Name;
                int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                KhoHang.ThemDanhMucKhoHang them = new KhoHang.ThemDanhMucKhoHang(NhomDanhMuc);
                them.ShowDialog();
                LoadTreeViewKhoHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItemSuaTenDanhMucNguyenLieu_Click(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                s = advTreeKhoHang.SelectedNode.Name;
                int kho = Convert.ToInt32(s);
                KhoHang.SuaDanhMucNguyenLieu sua = new KhoHang.SuaDanhMucNguyenLieu(kho);
                sua.ShowDialog();
                LoadTreeViewKhoHang();
            }
            catch (Exception)
            {
                try
                {
                    int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                    KhoHang.SuaNhomDanhMucNguyenLieu sua = new KhoHang.SuaNhomDanhMucNguyenLieu(NhomDanhMuc);
                    sua.ShowDialog();
                    LoadTreeViewKhoHang();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn chưa chọn mục");
                }

            }
        }

        private void toolStripMenuItemXoaDanhMucNguyenLieu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string s = "";
                try
                {
                    s = advTreeKhoHang.SelectedNode.Name;
                    int NhomDanhMuc = Convert.ToInt32(s);
                    KhoHang.Model.DeleteKhoHang delete = new KhoHang.Model.DeleteKhoHang();
                    delete.DeleteDanhMuc(NhomDanhMuc);
                    LoadTreeViewKhoHang();
                    LoadDataGridViewKhoNguyenLieu();
                }
                catch (Exception)
                {
                    try
                    {
                        s = advTreeKhoHang.SelectedNode.Name;
                        int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                        KhoHang.Model.DeleteKhoHang delete = new KhoHang.Model.DeleteKhoHang();
                        delete.DeleteNhomDanhMuc(NhomDanhMuc);
                        LoadTreeViewKhoHang();
                        LoadDataGridViewKhoNguyenLieu();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Bạn chưa chọn mục");
                    }

                }
            }
        }

        private void toolStripMenuItemThemNguyenLieu_Click(object sender, EventArgs e)
        {
            try
            {
                
                string s = advTreeKhoHang.SelectedNode.Name;
                int DanhMuc = Convert.ToInt32(s);
                KhoHang.ThemNguyenLieu them = new KhoHang.ThemNguyenLieu(DanhMuc);
                them.ShowDialog();
                LoadDataGridViewKhoNguyenLieu();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
            
        }

        private void toolStripMenuItemSuaNguyenLieu_Click(object sender, EventArgs e)
        {

            try
            {
                int maNguyenLieu = Convert.ToInt32(dataGridViewXKhoHang.SelectedRows[0].Cells[1].Value.ToString());
                KhoHang.SuaNguyenLieu sua = new KhoHang.SuaNguyenLieu(maNguyenLieu);
                sua.ShowDialog();
                LoadDataGridViewKhoNguyenLieu();
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chưa chọn nguyên liệu");
            }
        }

        private void toolStripMenuItemXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa nguyên liệu", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    int maNguyenLieu = Convert.ToInt32(dataGridViewXKhoHang.SelectedRows[0].Cells[1].Value.ToString());
                    KhoHang.Model.DeleteKhoHang delete = new KhoHang.Model.DeleteKhoHang();
                    delete.DeleteNguyenLieu(maNguyenLieu);
                    LoadDataGridViewKhoNguyenLieu();
                }
           
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chưa chọn nguyên liệu");
            }


        }

        private void toolStripMenuItemNhapKho_Click(object sender, EventArgs e)
        {
            KhoHang.NhapHangVaoKho nhap = new KhoHang.NhapHangVaoKho();
            nhap.ShowDialog();
            LoadDataGridViewKhoNguyenLieu();
        }

        private void toolStripMenuItemDieuChinhTonKho_Click(object sender, EventArgs e)
        {
            int maNguyenLieu = Convert.ToInt32(dataGridViewXKhoHang.SelectedRows[0].Cells[1].Value.ToString());
            KhoHang.DieuChinhTonKho dctk = new KhoHang.DieuChinhTonKho(maNguyenLieu);
            dctk.ShowDialog();
            LoadDataGridViewKhoNguyenLieu();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            KiemTraHoaDon = 2;
            HoaDon.model.Load load = new HoaDon.model.Load();
            DataTable dt = load.LoadHoaDonNhapHang(dateTimeInput1.Value,dateTimeInput2.Value);
            loadDataHoaDon(dt);
            lblHoaDon.Text = dt.Rows.Count.ToString();
            int Tong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
			{
                 Tong =Convert.ToInt32( dt.Rows[i][2].ToString())+Tong;
            }
                txtTongTien.Text = Tong.ToString();
        }
        float a;
        private void checkso(DevComponents.DotNetBar.Controls.RichTextBoxEx txtGia)
        {
            if (txtGia.Text != "")
            {
                try
                {
                    string tam = txtGia.Text.Replace(",", "");
                    a = float.Parse(tam);
                }
                catch
                {
                    MessageBox.Show("Không được điền chữ");
                    txtGia.Text = "";
                }
            }
          
        }

        public void TachSo(DevComponents.DotNetBar.Controls.RichTextBoxEx luong)
        {
            string txt, txt1;
            txt1 = luong.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            luong.Text = txt;
            luong.SelectionStart = luong.Text.Length;
        }

        public void loadDataHoaDon(DataTable dt)
        {
            dgvHoaDon.DataSource = dt;
            dgvHoaDon.AllowUserToResizeRows = false;
            dgvHoaDon.Columns[1].Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dgvHoaDon.Rows[i].Cells["ST"].Value = i + 1;

            }

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            TachSo(txtTongTien);
        }

        private void toolStripMenuItemChiTietHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells[1].Value.ToString());
                if (KiemTraHoaDon == 1)
                {
                   
                    HoaDon.ChiTietHoaDon hd = new HoaDon.ChiTietHoaDon(maHoaDon,KiemTraHoaDon);
                    hd.ShowDialog();
                }
                else if(KiemTraHoaDon == 2)
                {
                   
                    HoaDon.ChiTietHoaDon hd = new HoaDon.ChiTietHoaDon(maHoaDon,2);
                    hd.ShowDialog();
                }
                
                
                
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chưa chọn món");
            }
        }
        
        private void metroTabItemBanHang_Click(object sender, EventArgs e)
        {
            LoadKhuVuc();
            loadThucDon();
            LoadTreeViewThucDon1();
        }
        DataTable dtThucDon;
        private void loadThucDon()
        {
            ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
            DataTable dt = thudon.LoadToanBoThucDon();
            LoadThucDonTheoAdvTree(dt);
            LoadSoLuongSanPham();
        }
        public void LoadThucDonTheoAdvTree(DataTable dt)
        {
            dgvThucDon.DataSource = dt;
            dtThucDon = dt;
            dgvThucDon.Columns[0].Visible = false;
            DataGridViewImageColumn dc = dgvThucDon.Columns[4] as DataGridViewImageColumn;
            dc.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvThucDon.AllowUserToResizeRows = false;
            dgvThucDon.Columns[1].Width = 150;
        }
        // Search: 

        //void AutoCompleteText()
        //{
        //    txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        //    string sql = "Select * from ThucDon";
        //    conn = new SqlConnection(ConnectionString);
        //    SqlCommand com = new SqlCommand();
        //    com.Connection = conn;
        //    com.CommandText = sql;
        //    com.CommandType = CommandType.Text;
        //    conn.Open();
        //    SqlDataReader reader;
        //    reader = com.ExecuteReader();
        //    if (reader != null)
        //    {
        //        while (reader.Read())
        //        {
        //            coll.Add(reader["TenMonAn"].ToString());
        //        }
        //    }
        //    txtSearch.AutoCompleteCustomSource = coll;
        //}



        SqlConnection conn;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtThucDon);
            string name = dtThucDon.Columns[1].ToString();
            dv.RowFilter = string.Format(" Tên  LIKE '%{0}%'", txtSearch.Text);
            dgvThucDon.DataSource = dv;
        }
        private DataTable LoadListKhuVuc()
        {
            BanHang.Model.Load load = new BanHang.Model.Load();
            return load.LoadKhuVuc();
        }
        public DataTable LoadListBanAnTheoKhuVuc(int MaKhuVuc)
        {
            BanHang.Model.Load load = new BanHang.Model.Load();
            return load.LoadBanAn(MaKhuVuc);
        }
        public void LoadKhuVuc()
        {
            listViewExKhuVuc.Clear();
            DataTable dtKhuVuc = LoadListKhuVuc();
            DataTable dtHoaDonChuaThanhToan = loadHoaDon();

            for (int i = 0; i < dtKhuVuc.Rows.Count; i++)
            {
                ListViewGroup group1 = new ListViewGroup(dtKhuVuc.Rows[i][1].ToString());
                group1.Name = dtKhuVuc.Rows[i][0].ToString();
                listViewExKhuVuc.Groups.Add(group1);
                int MaKhuVuc = Convert.ToInt32( dtKhuVuc.Rows[i][0].ToString());
                DataTable dtBanAn = LoadListBanAnTheoKhuVuc(MaKhuVuc);
                for (int j = 0; j < dtBanAn.Rows.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dtBanAn.Rows[j][1].ToString();
                    item.Name = dtBanAn.Rows[j][0].ToString();
                    item.Group = group1;
                    item.ImageIndex = 2;
                    for (int k = 0; k <dtHoaDonChuaThanhToan.Rows.Count; k++)
                    {
                        if (dtHoaDonChuaThanhToan.Rows[k][2].ToString() == item.Name)
                        {
                            item.ImageIndex = 3;
                        }
                    }
                    listViewExKhuVuc.Items.Add(item);
                  
                }
               
            }
        }

        private DataTable loadHoaDon()
        {
            HoaDon.model.Load load = new HoaDon.model.Load();
            return  load.LoadHoaDonChuaThanhToan();
        }
     
        private void listViewExKhuVuc_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtHoaDonChuaThanhToan = loadHoaDon();
            int check = 0;
            if (dtHoaDonChuaThanhToan.Rows.Count > 0)
            {
                for (int k = 0; k < dtHoaDonChuaThanhToan.Rows.Count; k++)
                {
                    if (dtHoaDonChuaThanhToan.Rows[k][2].ToString() == listViewExKhuVuc.SelectedItems[0].Name.ToString())
                    {
                        check = 1;
                    }
                   
                }
                if (check == 0)
                {
                    listViewExKhuVuc.SelectedItems[0].ImageIndex = 3;
                    int MaBan = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
                    string TenBan = listViewExKhuVuc.SelectedItems[0].Text.ToString();
                    //Tao Hoa Don
                    BanHang.Model.Insert insert = new BanHang.Model.Insert();
                    insert.InsertHoaDon(MaBan,TenBan);
                    LoadHoaDonChuaThanhToanDangChon();
                }
            }
            else
            {

                listViewExKhuVuc.SelectedItems[0].ImageIndex = 3;
                int MaBan = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
                //Tao Hoa Don
                BanHang.Model.Insert insert = new BanHang.Model.Insert();
                string TenBan = listViewExKhuVuc.SelectedItems[0].Text.ToString();
                insert.InsertHoaDon(MaBan,TenBan);
                LoadHoaDonChuaThanhToanDangChon();

            }
            labelXID.Text = "";
            textBoxXKhachHang.Text = "";
            textBoxXSDT.Text = "";
            richTextBoxExDiaChi.Text = "";
            checkBoxX1.Checked = false;
      
        }

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblName.Text = dgvThucDon.SelectedRows[0].Cells[1].Value.ToString();
            lblMaMon.Text = dgvThucDon.SelectedRows[0].Cells[0].Value.ToString();
            txtSoLuong.Value = 1;
            richTextBoxExGiamGia.Text = "0";
          
        }

        public void resetThucDon()
        {
            txtSearch.Text = "";
            txtSoLuong.Value = 1;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            //nho them try catch
            try
            {
                int ID = Convert.ToInt32(lblMaMon.Text);
                string Ten = lblName.Text;
                float SoLuong = float.Parse(txtSoLuong.Value.ToString());
                string DonVi = dgvThucDon.SelectedRows[0].Cells[2].Value.ToString();
                float Gia = float.Parse(dgvThucDon.SelectedRows[0].Cells[3].Value.ToString()) ;
                checkso(richTextBoxExGiamGia);
                float GiamGia = a;
                float TongTien = Gia* SoLuong - GiamGia;
                if (MaHoaDon != 0)
                {
                    //neu chua co mon thi insert con neu khong thi update
                    //Kiem tra mon an co cung maMonAn va MaHoaDon
                    HoaDon.model.Load load = new HoaDon.model.Load();
                    DataTable dt = load.LoadMonAn(MaHoaDon, ID);
                    if (dt.Rows.Count == 0)
                    {
                        //InsertMonAn
                        BanHang.Model.Insert insert = new BanHang.Model.Insert();
                        insert.InsertHoaDonChiTiet(MaHoaDon, ID, Ten, SoLuong, DonVi, Gia, GiamGia, TongTien);
                        LoadChiTietHoaDon(MaHoaDon);
                    }
                    else
                    {
                        //Update
                        int MaChiTietHoaDon = Convert.ToInt32(dt.Rows[0][0].ToString());

                        BanHang.Model.Update update = new BanHang.Model.Update();
                        update.UpdateChiTietHoaDon(MaChiTietHoaDon, SoLuong, GiamGia);
                        LoadChiTietHoaDon(MaHoaDon);
                    }
                    resetThucDon();
                    LayHangTrongKho(ID, SoLuong);
                    LoadSoLuongSanPham();
                    loadThucDon();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn bàn");
                }
               
            }
            catch (Exception)
            {
                
            }
           
        }

        int MaHoaDon = 0;
        public void LoadHoaDonChuaThanhToanDangChon()
        {
            try
            {
                int MaBan = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
                HoaDon.model.Load load = new HoaDon.model.Load();
                DataTable HoaDon = load.LoadHoaDonChuaThanhToanCanChon(MaBan);
                lblThoiGian.Text = HoaDon.Rows[0][1].ToString();
                lblViTri.Text = HoaDon.Rows[0][11].ToString();
                richtxtTongTien.Text = HoaDon.Rows[0][6].ToString();
                MaHoaDon = Convert.ToInt32(HoaDon.Rows[0][0].ToString());
                LoadChiTietHoaDon(MaHoaDon);
                labelXID.Text = "";
                textBoxXKhachHang.Text = "";
                textBoxXSDT.Text = "";
                richTextBoxExDiaChi.Text = "";
                checkBoxX1.Checked = false;


            }
            catch (Exception)
            {
                MaHoaDon = 0;
                DataTable dt = new DataTable();
                dataGridViewXListMonAn.DataSource = dt;
                lblThoiGian.Text = "";
                lblViTri.Text = "";
                richtxtTongTien.Text = "";
                richtxtThanhToan.Text = "";
                numericUpDownGiamGia.Value = 0;
                numericUpDownVAT.Value = 0;
                labelXID.Text = "";
                textBoxXKhachHang.Text = "";
                textBoxXSDT.Text = "";
                richTextBoxExDiaChi.Text = "";
                checkBoxX1.Checked = false;
                
            }
        }
        private void listViewExKhuVuc_Click(object sender, EventArgs e)
        {
            LoadHoaDonChuaThanhToanDangChon();
        }
        public void TinhToanHoaDon()
        {
            int TongTien = 0;
            try
            {
                for (int i = 0; i < dataGridViewXListMonAn.Rows.Count; i++)
                {
                    TongTien = TongTien + Convert.ToInt32(dataGridViewXListMonAn.Rows[i].Cells[8].Value.ToString());
                   
                }
                richtxtTongTien.Text = TongTien.ToString();
                TinhToan();
            }
            catch (Exception)
            {
                
            }
        }
        public void LoadChiTietHoaDon(int MaHoaDon)
        {
            try
            {
                HoaDon.model.Load load = new HoaDon.model.Load();
                dataGridViewXListMonAn.DataSource = load.LoadChiTietHoaDonChuaThanhToanCanChon(MaHoaDon);
                dataGridViewXListMonAn.AllowUserToResizeRows = false;
                dataGridViewXListMonAn.Columns[1].Visible = false;
                dataGridViewXListMonAn.Columns[2].Visible = false;
                dataGridViewXListMonAn.Columns[3].Width = 200;
                for (int i = 0; i < dataGridViewXListMonAn.Rows.Count; i++)
                {

                    dataGridViewXListMonAn.Rows[i].Cells["STT1"].Value = i + 1;

                }
                TinhToanHoaDon();
            }
            catch (Exception)
            {
                
               
            }
          
        }
        public void TinhToan()
        {
            try
            {
                //Xu ly Thanh Toan
                checkso(richtxtTongTien);
                float TongTien = a;
                checkso(richtxtDichVu);
                float DichVu = a ;
                int GiamGia = Convert.ToInt32(numericUpDownGiamGia.Value.ToString());
                int VAT = Convert.ToInt32(numericUpDownVAT.Value.ToString());
                float ThanhToan = TongTien - TongTien * GiamGia / 100 - DichVu - TongTien*VAT/100;
                int ThanhToan1 = Convert.ToInt32(ThanhToan);
                richtxtThanhToan.Text = ThanhToan1.ToString();
            }
            catch (Exception)
            {
                
               
            }
       
        }

   
 

        private void richtxtDichVu_TextChanged(object sender, EventArgs e)
        {
            checkso(richtxtDichVu);
            TachSo(richtxtDichVu);
            if (richtxtDichVu.Text == "")
            {
                richtxtDichVu.Text = "0";
            }
            TinhToan();
        }

    

        private void richTextBoxExGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (richTextBoxExGiamGia.Text == "")
            {
                richTextBoxExGiamGia.Text = "0";
            }
            checkso(richTextBoxExGiamGia);
            TachSo(richTextBoxExGiamGia);
        }

        private void richtxtTongTien_TextChanged(object sender, EventArgs e)
        {
            checkso(richtxtTongTien);
            TachSo(richtxtTongTien);
        }

        private void richtxtThanhToan_TextChanged(object sender, EventArgs e)
        {

            checkso(richtxtThanhToan);
            TachSo(richtxtThanhToan);
        }

        private void toolStripMenuItemThemSoLuongMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString() != null)
                {
                    BanHang.Them them = new BanHang.Them(dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString());
                    them.ShowDialog();
                    LoadChiTietHoaDon(MaHoaDon);
                    LoadSoLuongSanPham();
                    loadThucDon();
                }
            }
            catch (Exception)
            {
                
            }
            
           
        }

        private void toolStripMenuItemBotSoLuongMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString() != null)
                {
                    int SoLuong = Convert.ToInt32(dataGridViewXListMonAn.SelectedRows[0].Cells[4].Value.ToString());
                    BanHang.Giam giam = new BanHang.Giam(dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString(),SoLuong);
                    giam.ShowDialog();
                    LoadChiTietHoaDon(MaHoaDon);
                    LoadSoLuongSanPham();
                    loadThucDon();
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void toolStripMenuItemGiamGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString() != null)
                {
                    BanHang.GiamGia giam = new BanHang.GiamGia(dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString());
                    giam.ShowDialog();
                    LoadChiTietHoaDon(MaHoaDon);
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void toolStripMenuItemHuyMon_Click(object sender, EventArgs e)
        {
             try
            {
                if (dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString() != null)
                {
                     DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
            {
                int MaChiTiet = Convert.ToInt32(dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString() );
                BanHang.Model.Delete delete = new BanHang.Model.Delete();
                delete.DeleteMonAn(MaChiTiet);
                LoadChiTietHoaDon(MaHoaDon);
            }
                }
            }
            catch (Exception)
            {

            }

        }
        private void toolStripMenuItemSuaGiaMonAn_Click(object sender, EventArgs e)
        {
            if (dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString() != null)
            {
                int ID = Convert.ToInt32(dataGridViewXListMonAn.SelectedRows[0].Cells[1].Value.ToString());
                string Name = dataGridViewXListMonAn.SelectedRows[0].Cells[3].Value.ToString();
                int Gia = Convert.ToInt32(dataGridViewXListMonAn.SelectedRows[0].Cells[6].Value.ToString());
                BanHang.SuaGiaMonAn sua = new BanHang.SuaGiaMonAn(ID,Name,Gia);
                sua.ShowDialog();
                LoadChiTietHoaDon(MaHoaDon);
            }
          
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
           try
            {
                if (MaHoaDon != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thanh toán", "Thanh toán", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        checkso(richtxtDichVu);
                        float DichVu = a;
                        checkso(richtxtTongTien);
                        float TongTien = a;
                        int GiamGia = Convert.ToInt32(numericUpDownGiamGia.Value.ToString());
                        int VAT = Convert.ToInt32(numericUpDownVAT.Value.ToString());
                        string GhiChu = richTextBoxExGhiChu.Text;
                        checkso(richtxtThanhToan);
                        float ThanhToan = a;
                        BanHang.Model.Update update = new BanHang.Model.Update();
                        if (checkBoxX1.Checked == false)
                        {
                            update.UpdateHoaDon(MaHoaDon, DichVu, GiamGia, VAT, TongTien, ThanhToan, GhiChu);
                        }
                        else
                        {
                            if (labelXID.Text != "")
                            {
                                int MaKhachHang = Convert.ToInt32(labelXID.Text);
                                string TenKhachHang = textBoxXKhachHang.Text;
                                update.UpdateHoaDonGhiNo(MaHoaDon, DichVu, GiamGia, VAT, TongTien, ThanhToan, GhiChu, MaKhachHang, TenKhachHang);
                            }
                            else
                            { 
                                // Them Khach hang
                                BanHang.Model.Insert insert = new BanHang.Model.Insert();
                                insert.InsertKhachHang(textBoxXKhachHang.Text, textBoxXSDT.Text, richTextBoxExDiaChi.Text);
                                //update thoi
                                update.UpdateHoaDonGhiNoKhachHangMoi(MaHoaDon, DichVu, GiamGia, VAT, TongTien, ThanhToan, GhiChu);

                            }
                        }
                        ResetBanHang();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ResetBanHang()
        {
            richtxtDichVu.Text = "0";
            richtxtTongTien.Text = "0";
            numericUpDownGiamGia.Value = 0;
            numericUpDownVAT.Value = 0;
            richTextBoxExGhiChu.Text = "";
            richtxtThanhToan.Text = "0";
            lblMaMon.Text = "";
            DataTable dt = new DataTable();
            dataGridViewXListMonAn.DataSource = dt;
            lblThoiGian.Text = "";
            lblViTri.Text = "";
            labelXID.Text = "";
            textBoxXKhachHang.Text = "";
            textBoxXSDT.Text = "";
            richTextBoxExDiaChi.Text = "";
            checkBoxX1.Checked = false;
            LoadKhuVuc();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if(MaHoaDon!=0)
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn hủy bàn", "Hủy", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        BanHang.Model.Delete delete = new BanHang.Model.Delete();
                        delete.DeleteHoaDon(MaHoaDon);
                        ResetBanHang();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn");
                }
            }
            catch (Exception)
            {
                
          
            }
        }
        int KiemTraHoaDon = 0;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            BanHang.Model.Load load = new BanHang.Model.Load();
            DataTable dt = new DataTable(); ;
            KiemTraHoaDon = 1;
            if (!checkBoxX2.Checked)
            {
                dt = load.LoadHoaDonBanHang(dateTimeInput1.Value, dateTimeInput2.Value);
            }
            else
            {
                dt = load.LoadHoaDonBanHangNo(dateTimeInput1.Value, dateTimeInput2.Value);
            }
           
            loadDataHoaDon(dt);
            lblHoaDon.Text = dt.Rows.Count.ToString();
            int Tong = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tong = Convert.ToInt32(dt.Rows[i][7].ToString()) + Tong;
            }
            txtTongTien.Text = Tong.ToString();
        }

        private void toolStripMenuItemThemBan_Click(object sender, EventArgs e)
        {
            try
            {
                //check khu vuc
                int MaBanAn = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
                BanHang.Model.Load load = new BanHang.Model.Load();
                DataTable dt = load.LoadKhuVucTheoMaBanAn(MaBanAn);
                int MaKhuVuc = Convert.ToInt32(dt.Rows[0][2].ToString());
                BanHang.ThemBan them = new BanHang.ThemBan(MaKhuVuc);
                them.ShowDialog();
                LoadKhuVuc();
            }
            catch (Exception)
            {
            }
        }

        private void toolStripMenuItemSuaBan_Click(object sender, EventArgs e)
        {
            try
            {
                //check khu vuc
                int MaBanAn = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
                BanHang.Model.Load load = new BanHang.Model.Load();
                DataTable dt = load.LoadKhuVucTheoMaBanAn(MaBanAn);
                int MaKhuVuc = Convert.ToInt32(dt.Rows[0][2].ToString());
                BanHang.SuaBan sua = new BanHang.SuaBan(MaBanAn,MaKhuVuc);
                sua.ShowDialog();
                LoadKhuVuc();
            }
            catch (Exception)
            {
            }
        }

        private void toolStripMenuItemXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                //check khu vuc
                int MaBanAn = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
               
                HoaDon.model.Load load = new HoaDon.model.Load();
                DataTable HoaDon = load.LoadHoaDonChuaThanhToanCanChon(MaBanAn);
                if (HoaDon.Rows.Count == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn không", "Xóa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        BanHang.Model.Delete delete = new BanHang.Model.Delete();
                        delete.DeleteBanAn(MaBanAn);
                    }
                    LoadKhuVuc();
                }
                else
                {
                    MessageBox.Show("Hóa đơn chưa thanh toán");
                }
             
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItemChuyenBan_Click(object sender, EventArgs e)
        {
                   try 
	        {
                int MaBanAn = Convert.ToInt32(listViewExKhuVuc.SelectedItems[0].Name.ToString());
                HoaDon.model.Load load = new HoaDon.model.Load();
                DataTable HoaDon = load.LoadHoaDonChuaThanhToanCanChon(MaBanAn);
                if (HoaDon.Rows.Count > 0)
                {
                    BanHang.ChuyenBan chuyen = new BanHang.ChuyenBan(MaBanAn,HoaDon.Rows[0][11].ToString());
                    chuyen.ShowDialog();
                    LoadKhuVuc();
                }
	        }
	        catch 
	        {
		
	        }
           
        }
        private void radialMenuItemThemKhuVuc_Click(object sender, EventArgs e)
        {
            BanHang.ThemKhuVuc them = new BanHang.ThemKhuVuc();
            them.ShowDialog();
            LoadKhuVuc();
        }
        private void radialMenuItemSuaKhuVuc_Click(object sender, EventArgs e)
        {
            BanHang.SuaKhuVuc sua = new BanHang.SuaKhuVuc();
            sua.ShowDialog();
            LoadKhuVuc();
        }
        private void radialMenuItemXoaKhuVuc_Click(object sender, EventArgs e)
        {
            
            BanHang.XoaKhuVuc xoa = new BanHang.XoaKhuVuc();
            xoa.ShowDialog();
            LoadKhuVuc();
        }
        private void LoadTreeViewThucDon1()
        {
            advTreeThucDon1.Nodes.Clear();
            DevComponents.AdvTree.Node node2 = new DevComponents.AdvTree.Node();
            node2.Text = "Tất cả";
            DevComponents.AdvTree.Node node3 = new DevComponents.AdvTree.Node();
            node3.Text = "Tất cả thực đơn";
            node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node3 });
          //  node3.Image = global::VietRestaurant2._0.Properties.Resources.folder_48;
            advTreeThucDon1.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node2 });


            ThucDon.ModuleThucDon thucdon = new ThucDon.ModuleThucDon();
            DataTable dtNhom = thucdon.LoadNhomDanhMucThucDon();
            int a = dtNhom.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                node.Text = dtNhom.Rows[i]["TenDanhMuc"].ToString();
                node.Name = "a" + dtNhom.Rows[i]["MaDanhMuc"].ToString();

                DataTable dt = thucdon.LoadDanhMucTheoNhomDanhMuc(Convert.ToInt32(dtNhom.Rows[i]["MaDanhMuc"].ToString()));
                int b = dt.Rows.Count;
                for (int j = 0; j < b; j++)
                {
                    DevComponents.AdvTree.Node node1 = new DevComponents.AdvTree.Node();
                    node1.Text = dt.Rows[j]["TenDanhMuc"].ToString();
                    node1.Name = dt.Rows[j]["MaDanhMuc"].ToString();
                  //  node1.Image = global::VietRestaurant2._0.Properties.Resources.folder_48;
                    node.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node1 });
                }
                advTreeThucDon1.Nodes.AddRange(new DevComponents.AdvTree.Node[] { node });

            }
            advTreeThucDon1.ExpandAll();
        }

        private void advTreeThucDon1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            LoadDataGridViewThucDon1();
        }
        public void LoadDataGridViewThucDon1()
        {

            string s = "";

            try
            {
                s = advTreeThucDon1.SelectedNode.Name;
                int MaDanhMuc = Convert.ToInt32(s);
                MaDanhMucThucDon = MaDanhMuc;
                ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
                DataTable dt = thudon.LoadThucDonTheoDanhMuc(MaDanhMuc);
                LoadThucDonTheoAdvTree(dt);
            }
            catch (Exception)
            {
                try
                {

                    int NhomDanhMuc = Convert.ToInt32(s.Substring(1));
                    ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
                    DataTable dt = thudon.LoadThucDonTheoNhomDanhMuc(NhomDanhMuc);
                    LoadThucDonTheoAdvTree(dt);

                }
                catch
                {

                    ThucDon.ModuleThucDon thudon = new ThucDon.ModuleThucDon();
                    DataTable dt = thudon.LoadToanBoThucDon();
                    dataGridViewXThucDon.DataSource = dt;
                    LoadThucDonTheoAdvTree(dt);
                }
            }
        }

        private void dgvThucDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                int ID = Convert.ToInt32(dgvThucDon.SelectedRows[0].Cells[0].Value.ToString());
                string Ten = dgvThucDon.SelectedRows[0].Cells[1].Value.ToString();
                float SoLuong =  1;
                string DonVi = dgvThucDon.SelectedRows[0].Cells[2].Value.ToString();
                float Gia = float.Parse(dgvThucDon.SelectedRows[0].Cells[3].Value.ToString());      
                float GiamGia = 0;
                float TongTien = Gia * SoLuong - GiamGia;
                if (LayHangTrongKho(ID, SoLuong) == 1)
                {
                    if (MaHoaDon != 0)
                    {
                        //neu chua co mon thi insert con neu khong thi update
                        //Kiem tra mon an co cung maMonAn va MaHoaDon
                        HoaDon.model.Load load = new HoaDon.model.Load();
                        DataTable dt = load.LoadMonAn(MaHoaDon, ID);
                        if (dt.Rows.Count == 0)
                        {
                            //InsertMonAn
                            BanHang.Model.Insert insert = new BanHang.Model.Insert();
                            insert.InsertHoaDonChiTiet(MaHoaDon, ID, Ten, SoLuong, DonVi, Gia, GiamGia, TongTien);
                            LoadChiTietHoaDon(MaHoaDon);

                        }
                        else
                        {
                            //Update
                            int MaChiTietHoaDon = Convert.ToInt32(dt.Rows[0][0].ToString());

                            BanHang.Model.Update update = new BanHang.Model.Update();
                            update.UpdateChiTietHoaDon(MaChiTietHoaDon, SoLuong, GiamGia);
                            LoadChiTietHoaDon(MaHoaDon);
                        }
                }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn hàng hoặc hết đồ");
                }
            }
            catch (Exception)
            {

            }
            LoadSoLuongSanPham();
            loadThucDon();
            resetThucDon();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == true)
            {
                panelExGhiNo.Visible = true;
              
            }
            else
            {
                panelExGhiNo.Visible = false;
            }
        }

       

        private void numericUpDownGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhToan();
        }

        private void numericUpDownVAT_ValueChanged(object sender, EventArgs e)
        {
            TinhToan();
        }

        private void bubbleButton2_Click(object sender, ClickEventArgs e)
        {
            BanHang.ListKhachHang list = new BanHang.ListKhachHang();
            list.KhachHang = new BanHang.ListKhachHang.ListKhachHang1(LoadKhachHang);
            list.ShowDialog();
        }
        public void LoadKhachHang(int ID, string TenKhach, string sdt, string diachi)
        {
            labelXID.Text =  ID.ToString();
            textBoxXKhachHang.Text = TenKhach;
            textBoxXSDT.Text = sdt;
            richTextBoxExDiaChi.Text = diachi;
        }
        //Tinh toan so luong mon an
        public void LoadSoLuongSanPham()
        {
            BanHang.Model.Update update = new BanHang.Model.Update();
            update.UpdateSoLuongMonAn();
        }
        public int LayHangTrongKho(int MaMonAn, float SoLuong)
        {
            BanHang.Model.Update update = new BanHang.Model.Update();
            return update.LayHangTrongKho(MaMonAn, SoLuong);
            
        }

        private void metroTabItemNhanVien_Click(object sender, EventArgs e)
        {
           LoaddgvNhanVien();
        }
        int SuaXoaNhanVien = 0;
        public void LoaddgvNhanVien()
        {
            NhanVien.Model.Load load = new NhanVien.Model.Load();
            dgvNhanVien.DataSource = load.LoadNhanVien();
            dgvNhanVien.Columns[1].Visible = false;
            dgvNhanVien.Columns[6].Visible = false;

            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {

                dgvNhanVien.Rows[i].Cells["STTT"].Value = i + 1;

            }
            if (SuaXoaNhanVien == 0)
            {
                AddSuaXoaNhanVien();

            }
            else
            {
                dgvNhanVien.Columns.Remove("Sua");
                dgvNhanVien.Columns.Remove("Xoa");
                AddSuaXoaNhanVien();
            }
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                row.Cells["Sua"].Value = "Sửa";
                row.Cells["Xoa"].Value = "Xóa";
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IDNhanVien = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString());
            if (e.ColumnIndex == dgvNhanVien.Columns["Sua"].Index && e.RowIndex >= 0)
            {
               
                NhanVien.SuaNhanVien sua = new NhanVien.SuaNhanVien(IDNhanVien);
                sua.ShowDialog();
                LoaddgvNhanVien();
            }
            else if (e.ColumnIndex == dgvNhanVien.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn không", "Xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    NhanVien.Model.Delete delete = new NhanVien.Model.Delete();
                    delete.DeleteNhanVien(IDNhanVien);
                    LoaddgvNhanVien();
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien.Model.ThemNhanVien them = new NhanVien.Model.ThemNhanVien();
            them.ShowDialog();
            
            LoaddgvNhanVien();
        }
      
        public void AddSuaXoaNhanVien()
        {
            DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn btnColum = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            btnColum.HeaderText = "Sửa";
            btnColum.Text = "Sửa";
            btnColum.Name = "Sua";
            dgvNhanVien.Columns.Add(btnColum);
            DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn btnColum1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            btnColum1.HeaderText = "Xóa";
            btnColum1.Text = "Xóa";
            btnColum1.Name = "Xoa";
            dgvNhanVien.Columns.Add(btnColum1);
            SuaXoaNhanVien = 1;
        }

        private void metroTabItemKhacHang_Click(object sender, EventArgs e)
        {
            LoaddgvKhachHang();
        }
        int SuaXoaKhachHang = 0;
        public void LoaddgvKhachHang()
        {
            KhachHang.Model.Load load = new KhachHang.Model.Load();
            dgvKhachHang.DataSource = load.LoadKhachHang();
            dgvKhachHang.Columns[1].Visible = false;

            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {

                dgvKhachHang.Rows[i].Cells["STT2"].Value = i + 1;

            }
            if (SuaXoaKhachHang == 0)
            {
                AddSuaXoaKhachHang();
            }
            else
            {
                dgvKhachHang.Columns.Remove("Sua");
                dgvKhachHang.Columns.Remove("Xoa");
                AddSuaXoaKhachHang();
            }
            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                row.Cells["Sua"].Value = "Sửa";
                row.Cells["Xoa"].Value = "Xóa";
            }
        }
        public void AddSuaXoaKhachHang()
        {
            DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn btnColum = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            btnColum.HeaderText = "Sửa";
            btnColum.Text = "Sửa";
            btnColum.Name = "Sua";
            dgvKhachHang.Columns.Add(btnColum);
            DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn btnColum1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            btnColum1.HeaderText = "Xóa";
            btnColum1.Text = "Xóa";
            btnColum1.Name = "Xoa";
            dgvKhachHang.Columns.Add(btnColum1);
            SuaXoaKhachHang = 1;
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang.ThemKhachHang them = new KhachHang.ThemKhachHang();
            them.ShowDialog();
            LoaddgvKhachHang();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IDKhachHang = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells[1].Value.ToString());
            if (e.ColumnIndex == dgvKhachHang.Columns["Sua"].Index && e.RowIndex >= 0)
            {

                KhachHang.SuaKhachHang sua = new KhachHang.SuaKhachHang(IDKhachHang);
                sua.ShowDialog();
                LoaddgvKhachHang();
            }
            else if (e.ColumnIndex == dgvKhachHang.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn không", "Xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    KhachHang.Model.Delete delete = new KhachHang.Model.Delete();
                    delete.DeleteKhachHang(IDKhachHang);
                    LoaddgvKhachHang();
                }
            }
        }

        private void metroTabItemThuChi_Click(object sender, EventArgs e)
        {
            LoadThuChi();
        }
        //tính tổng tiền thu chi
        public int TinhTongTienThuChi(DataGridView ThuChi)
        {
            int Tien = 0;
            for (int i = 0; i < ThuChi.Rows.Count; i++)
            {
                Tien = Tien + Convert.ToInt32(ThuChi.Rows[i].Cells[4].Value.ToString());
                
            }
            return Tien;
        }
        public void LoadThuChi()
        {

            ThuChi.Model.Load load = new ThuChi.Model.Load();
            //Load Phieu thu
            if (checkBoxPhieuThu.Checked != true)
            {
                dgvPhieuThu.DataSource = load.LoadPhieuThu(dateTimeNgayDauThuChi.Value, dateTimeNgayCuoiThuChi.Value);
               
            }
            else
            {
                dgvPhieuThu.DataSource = load.LoadPhieuThuNo(dateTimeNgayDauThuChi.Value, dateTimeNgayCuoiThuChi.Value);
            }
            dgvPhieuThu.Columns[1].Visible = false;
            richTextBoxExPhieuThu.Text = TinhTongTienThuChi(dgvPhieuThu).ToString();
            for (int i = 0; i < dgvPhieuThu.Rows.Count; i++)
            {
                dgvPhieuThu.Rows[i].Cells["STT3"].Value = i + 1;
            }
            //Load phieu chi
            if (checkBoxPhieuChi.Checked != true)
            {
                dgvPhieuChi.DataSource = load.LoadPhieuChi(dateTimeNgayDauThuChi.Value, dateTimeNgayCuoiThuChi.Value);
                
            }
            else
            {
                dgvPhieuChi.DataSource = load.LoadPhieuChiNo(dateTimeNgayDauThuChi.Value, dateTimeNgayCuoiThuChi.Value);
            }
            dgvPhieuChi.Columns[1].Visible = false;
            richTextBoxExPhieuChi.Text = TinhTongTienThuChi(dgvPhieuChi).ToString();
            for (int i = 0; i < dgvPhieuChi.Rows.Count; i++)
            {

                dgvPhieuChi.Rows[i].Cells["STT4"].Value = i + 1;

            }
          
        }
        private void btnThuChi_Click(object sender, EventArgs e)
        {
            LoadThuChi();
        }

        private void richTextBoxExPhieuThu_TextChanged(object sender, EventArgs e)
        {
            TachSo(richTextBoxExPhieuThu);
        }

        private void richTextBoxExPhieuChi_TextChanged(object sender, EventArgs e)
        {
            TachSo(richTextBoxExPhieuChi);
        }

        private void toolStripMenuItemCheBien_Click(object sender, EventArgs e)
        {

            try
            {
                int ID = Convert.ToInt32(dataGridViewXThucDon.SelectedRows[0].Cells[1].Value.ToString());
                string Name = dataGridViewXThucDon.SelectedRows[0].Cells[2].Value.ToString();
                ThucDon.CheBien chebien = new ThucDon.CheBien(Name, ID);
                chebien.ShowDialog();
            }
            catch 
            {


            }
        }
        // Xuất kho hàng ra Excel
        private void toolStripMenuItemXuatKhoRaExcel_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            for (i = 1; i <= dataGridViewXKhoHang.Columns.Count; i++)
            {

                xlWorkSheet.Cells[1, i] = dataGridViewXKhoHang.Columns[i - 1].HeaderText;

            }
            for (i = 0; i <= dataGridViewXKhoHang.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridViewXKhoHang.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridViewXKhoHang[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void toolStripMenuItemNhapHangTuExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
