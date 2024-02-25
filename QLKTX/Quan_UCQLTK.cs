using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLKTX
{
    public partial class Quan_UCQLTK : UserControl
    {
        public Quan_UCQLTK()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        SqlCommand cmd = null;
        private void Quan_UCQLTK_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            
        }
        int ddc;
        private void dgvtkkhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ddc = e.RowIndex;           
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string xoa = "delete from TaiKhoan where TenDangNhap = N'" + dgvtkkhach.Rows[ddc].Cells[0].Value.ToString() + "' and VaiTro = '" + dgvtkkhach.Rows[ddc].Cells[2].Value.ToString() + "'";
                    cmd = new SqlCommand(xoa, conn);
                    cmd.ExecuteNonQuery();
                    dt1.Rows.Clear();
                    da.Fill(dt1);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btxem_Click(object sender, EventArgs e)
        {
            try
            {
                dt1.Rows.Clear();
                dt.Rows.Clear();
                //Hien thi bang danh sach tai khoan he thong
                string hienthitkhethong = "select TenDangNhap as 'Tên đăng nhập', MatKhau as 'Mật khẩu', VaiTro as 'Vai trò', SoDienThoai as 'Số điện thoại' from TaiKhoan where VaiTro ='1'";
                da = new SqlDataAdapter(hienthitkhethong, conn);
                da.Fill(dt);
                dgvtkhethong.DataSource = dt;

                //hien thi bang danh sach tai khoan khach
                string hienthikhach = "select TenDangNhap as 'Tên đăng nhập', MatKhau as 'Mật khẩu', VaiTro as 'Vai trò', SoDienThoai as 'Số điện thoại' from TaiKhoan where VaiTro !='1'";
                da = new SqlDataAdapter(hienthikhach, conn);
                da.Fill(dt1);
                dgvtkkhach.DataSource = dt1;
                int dem = 0;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dem++;
                }
                tbsotaikhoan.Text = dem.ToString();
            }
            catch (Exception) { }
            
        }
    }
}
