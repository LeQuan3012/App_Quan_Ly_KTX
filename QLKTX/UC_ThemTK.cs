using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class UC_ThemTK : UserControl
    {
        public UC_ThemTK()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        private void UC_ThemTK_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string hienthitkhethong = "select TenDangNhap as 'Tên đăng nhập', MatKhau as 'Mật khẩu', VaiTro as 'Vai trò', SoDienThoai as 'Số điện thoại' from TaiKhoan";
            da = new SqlDataAdapter(hienthitkhethong, conn);
            da.Fill(dt);
            dgv.DataSource = dt;
        }

        private void tbsdt_Leave(object sender, EventArgs e)
        {
            int a;
            try
            {
                a = int.Parse(tbsdt.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số điện thoại là một chuỗi số","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsdt.Focus();
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            int k;
            if(cbvaitro.SelectedIndex == 0)
            {
                k = 3;
            }
            else if (cbvaitro.SelectedIndex==1)
            {
                k = 2;
            }
            else
            {
                k = 1;
            }
            try
            {
                string them = "insert into TaiKhoan values (N'" + tbtendangnhap.Text + "','" + tbmatkhau.Text + "','" + k.ToString() + "', '" + tbsdt.Text + "')";
                cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                dt.Rows.Clear();
                da.Fill(dt);
                //UC_ThemTK_Load(sender, e);
                tbtendangnhap.Text = "";
                tbmatkhau.Text = "";
                tbsdt.Text = "";
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                int k;
                if (cbvaitro.SelectedIndex == 0)
                {
                    k = 3;
                }
                else if (cbvaitro.SelectedIndex == 1)
                {
                    k = 2;
                }
                else
                {
                    k = 1;
                }
                string sua = "update TaiKhoan set TenDangNhap = N'" + tbtendangnhap.Text + "', MatKhau = '" + tbmatkhau.Text + "', VaiTro = '" + k.ToString() + "', SoDienThoai = '" + tbsdt.Text + "' where TenDangNhap = N'" + dgv.Rows[ddc].Cells[0].Value.ToString() + "'";
                cmd = new SqlCommand(sua, conn);
                cmd.ExecuteNonQuery();
                dt.Rows.Clear();
                da.Fill(dt);
                //UC_ThemTK_Load(sender, e);
                tbtendangnhap.Text = "";
                tbmatkhau.Text = "";
                tbsdt.Text = "";
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int ddc;
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ddc = e.RowIndex;
                tbtendangnhap.Text = dgv.Rows[ddc].Cells[0].Value.ToString();
                tbmatkhau.Text = dgv.Rows[ddc].Cells[1].Value.ToString();
                if (dgv.Rows[ddc].Cells[2].Value.ToString() == "2")
                    cbvaitro.SelectedIndex = 1;
                else if (dgv.Rows[ddc].Cells[2].Value.ToString() == "1")
                    cbvaitro.SelectedIndex = 2;
                else
                    cbvaitro.SelectedIndex = 0;
                tbsdt.Text = dgv.Rows[ddc].Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                int k;
                if (cbvaitro.SelectedIndex == 0)
                {
                    k = 3;
                }
                else if (cbvaitro.SelectedIndex == 1)
                {
                    k = 2;
                }
                else
                {
                    k = 1;
                }
                string xoa = "delete from TaiKhoan where TenDangNhap = N'" + dgv.Rows[ddc].Cells[0].Value.ToString() + "' and VaiTro = '" + k.ToString() + "' and SoDienThoai = '" + dgv.Rows[ddc].Cells[3].Value.ToString() + "'";
                cmd = new SqlCommand(xoa, conn);
                cmd.ExecuteNonQuery();
                dt.Rows.Clear();
                da.Fill(dt);
                tbtendangnhap.Text = "";
                tbmatkhau.Text = "";
                tbsdt.Text = "";
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
