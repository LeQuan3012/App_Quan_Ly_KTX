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
    public partial class Cuong_UCthemphongkhu : UserControl
    {
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public Cuong_UCthemphongkhu()
        {
            InitializeComponent();
        }

        private void Cuong_UCthemphongkhu_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            //Hien thi khu len DataGridView
            string hienthi = "select TenKhu as 'Tên khu' from Khu ";
            da = new SqlDataAdapter(hienthi,conn);
            da.Fill(dt);
            dgvkhu.DataSource = dt;

            //do du lieu vao combobox
            cbkhu.DataSource = dt;
            cbkhu.ValueMember = "Tên khu";
        }

        private void btthemkhu_Click(object sender, EventArgs e)
        {
            try
            {
                string them = "insert into Khu values (N'" + tbtenkhu.Text + "')";
                cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                dt.Rows.Clear();
                //da.Fill(dt);
                tbtenkhu.Text = "";
                Cuong_UCthemphongkhu_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error );
                tbtenkhu.Focus();
            }
            
        }

        private void btxoakhu_Click(object sender, EventArgs e)
        {
            try
            {
                string xoa = "delete from Khu where TenKhu = N'" + dgvkhu.Rows[ddckhu].Cells[0].Value.ToString() + "'";
                cmd = new SqlCommand(xoa, conn);
                cmd.ExecuteNonQuery();
                dt.Rows.Clear();
                //da.Fill(dt);
                Cuong_UCthemphongkhu_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        int ddckhu;
        private void dgvkhu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ddckhu = e.RowIndex;
            
        }

        DataTable dt1 = new DataTable();
        private void btthemphong_Click(object sender, EventArgs e)
        {
            try
            {
                string themphong = "insert into Phong values (N'" + cbkhu.Text + "', N'" + tbtenphong.Text + "',"+tbsochootoida.Text+")";
                cmd = new SqlCommand(themphong, conn);
                cmd.ExecuteNonQuery();
                dt1.Rows.Clear();
                da.Fill(dt1);
                tbtenphong.Text = "";
                tbsochootoida.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbtenphong.Focus();
            }
            
        }

        
        private void cbkhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt1.Rows.Clear();
            string hienthi = "select TenPhong as 'Tên phòng', sochotoida as 'Số chỗ tối đa' from Phong where Tenkhu = N'"+cbkhu.Text+"'";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt1);
            dgvphong.DataSource = dt1;
        }

        int ddcphong;
        private void dgvphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ddcphong = e.RowIndex;
        }

        private void btxoaphong_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Dữ liệu phòng này sẽ bị xóa toàn bộ. Bạn chắc chắn chứ?","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string xoa1 = "delete from HopDong where TenPhong = N'" + dgvphong.Rows[ddcphong].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(xoa1, conn);
                    cmd.ExecuteNonQuery();

                    string xoa2 = "delete from SinhVien where TenPhong = N'" + dgvphong.Rows[ddcphong].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(xoa2, conn);
                    cmd.ExecuteNonQuery();

                    string xoa3 = "delete from CSVC where TenPhong = N'" + dgvphong.Rows[ddcphong].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(xoa3, conn);
                    cmd.ExecuteNonQuery();

                    string xoa4 = "delete from SinhHoatPhi where TenPhong = N'" + dgvphong.Rows[ddcphong].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(xoa4, conn);
                    cmd.ExecuteNonQuery();

                    string xoa = "delete from Phong where TenPhong = N'" + dgvphong.Rows[ddcphong].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(xoa, conn);
                    cmd.ExecuteNonQuery();
                    dt1.Rows.Clear();
                    da.Fill(dt1);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void tbsochootoida_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbsochootoida_Leave(object sender, EventArgs e)
        {
            int a;
            try
            {
                a = int.Parse(tbsochootoida.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsochootoida.Focus();
            }
        }
    }
}
