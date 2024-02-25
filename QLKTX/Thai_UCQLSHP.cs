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
    public partial class Thai_UCQLSHP : UserControl
    {
        public Thai_UCQLSHP()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        private void Thai_UCQLSHP_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            //do du lieu vao combobox
            string hienthi = "select TenKhu as 'Tên khu' from Khu ";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt);
            cbchonkhu.DataSource = dt;
            cbchonkhu.ValueMember = "Tên khu";
            checknop.Checked = true;
        }
        DataTable dt1 = new DataTable();
        private void cbchonkhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt1.Rows.Clear();
            string hienthi = "select TenPhong as 'Tên phòng' from Phong where Tenkhu = N'" + cbchonkhu.Text + "'";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt1);
            cbchonphong.DataSource = dt1;
            cbchonphong.ValueMember = "Tên phòng";
        }

        TextBox tb;
        private void tbtiendien_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                tb = (TextBox)sender;
            }
        }

        private void tbtiendien_Leave(object sender, EventArgs e)
        {
            int a = 0;
            try
            {
                a = int.Parse(tb.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb.Focus();
            }
        }
        DataTable dt3 = new DataTable();
        private void btthem_Click(object sender, EventArgs e)
        {
            string nop;
            if (checknop.Checked)
                nop = "Đã nộp";
            else
                nop = "Chưa nộp";
            try
            {
                //dgvshp.Rows.Clear();
                int tien = int.Parse(tbtiendien.Text) + int.Parse(tbtiennuoc.Text) + int.Parse(tbtienwifi.Text) + int.Parse(tbtienphong.Text);
                string them = "insert into SinhHoatPhi values ( N'" + cbchonkhu.Text + "', N'" + cbchonphong.Text + "',N'" + cbthang.Text + "'," + tbnam.Text + "," + tbtiendien.Text + "," + tbtiennuoc.Text + "," + tbtienwifi.Text + "," + tbtienphong.Text + "," + tien.ToString() + ", N'"+nop+"', N'"+tbghichu.Text+ "')";
                cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                dt3.Rows.Clear();
                da.Fill(dt3);
                MessageBox.Show("Thêm thành công","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                cbthang.Text = "";
                tbnam.Text = "";
                tbtiendien.Text = "";
                tbtiennuoc.Text = "";
                tbtienwifi.Text = "";
                tbtienphong.Text = "";
                tbnam.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                string nop;
                if (checknop.Checked)
                    nop = "Đã nộp";
                else
                    nop = "Chưa nộp";
                int tongtien = int.Parse(tbtiendien.Text) + int.Parse(tbtiennuoc.Text) + int.Parse(tbtienwifi.Text) + int.Parse(tbtienphong.Text);
                string sua = "update SinhHoatPhi set thang = N'" + cbthang.Text + "', TienDien =" + tbtiendien.Text + ", TienNuoc =" + tbtiennuoc.Text + ", TienWifi =" + tbtienwifi.Text + ", TienPhong =" + tbtienphong.Text + ", TongTien =" + tongtien.ToString() +", noptien = N'"+nop+"', ghichu = N'"+tbghichu.Text +"' where TenKhu = N'" + cbchonkhu.Text + "' and TenPhong = N'" + cbchonphong.Text + "' and thang = N'" + cbthang.Text + "'";
                cmd = new SqlCommand(sua, conn);
                cmd.ExecuteNonQuery();
                dt3.Rows.Clear();
                da.Fill(dt3);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbtiendien.Text = "";
                tbtiennuoc.Text = "";
                tbtienwifi.Text = "";
                tbtienphong.Text = "";
                tbnam.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void cbchonphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt3.Rows.Clear();
            string xem = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', (TienDien+TienNuoc+TienWifi+TienPhong) as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' from SinhHoatPhi where TenKhu = N'" + cbchonkhu.Text + "' and TenPhong = N'" + cbchonphong.Text + "'";
            da = new SqlDataAdapter(xem, conn);
            da.Fill(dt3);
            dgvshp.DataSource = dt3;
        }

        int ddc;

        private void dgvshp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ddc = e.RowIndex;
                cbthang.Text = dgvshp.Rows[ddc].Cells[2].Value.ToString();
                tbnam.Text = dgvshp.Rows[ddc].Cells[3].Value.ToString();
                tbtiendien.Text = dgvshp.Rows[ddc].Cells[4].Value.ToString();
                tbtiennuoc.Text = dgvshp.Rows[ddc].Cells[5].Value.ToString();
                tbtienwifi.Text = dgvshp.Rows[ddc].Cells[6].Value.ToString();
                tbtienphong.Text = dgvshp.Rows[ddc].Cells[7].Value.ToString();
                if (dgvshp.Rows[ddc].Cells[9].Value.ToString() == "Đã nộp")
                {
                    checknop.Checked = true;
                }
                else
                    checknop.Checked = false;
                tbghichu.Text = dgvshp.Rows[ddc].Cells[10].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string xoa = "delete from SinhHoatPhi where TenKhu = N'" + cbchonkhu.Text + "' and TenPhong = N'" + cbchonphong.Text + "' and thang = N'" + cbthang.Text + "' and nam ="+tbnam.Text;
                cmd = new SqlCommand(xoa, conn);
                cmd.ExecuteNonQuery();
                dt3.Rows.Clear();
                da.Fill(dt3);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbthang.Text = "";
                tbnam.Text = "";
                tbtiendien.Text = "";
                tbtiennuoc.Text = "";
                tbtienwifi.Text = "";
                tbtienphong.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
