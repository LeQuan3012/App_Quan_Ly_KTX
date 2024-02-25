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
using System.Data.SqlClient;
namespace QLKTX
{
    public partial class UCnhapthongtinCSVC : UserControl
    {
        public UCnhapthongtinCSVC()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        private void UCnhapthongtinCSVC_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            //do du lieu vao combobox
            string hienthi = "select TenKhu as 'Tên khu' from Khu ";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt);
            cbkhu.DataSource = dt;
            cbkhu.ValueMember = "Tên khu";
            checksua.Checked = true;
            cbkhu.SelectedIndex = 0;
            
        }
        DataTable dt1 = new DataTable();
        private void cbkhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt1.Rows.Clear();
                cbphong.Text = "";
                string hienthi = "select TenPhong as 'Tên phòng' from Phong where Tenkhu = N'" + cbkhu.Text + "'";
                da = new SqlDataAdapter(hienthi, conn);
                da.Fill(dt1);
                cbphong.DataSource = dt1;
                cbphong.ValueMember = "Tên phòng";
            }
            catch (Exception) { }
             
            
        }
        TextBox tb;
        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button== MouseButtons.Left)
            {
                tb = (TextBox)sender;
            }
        }


        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                string them;
                if (checksua.Checked)
                {
                    them = "insert into CSVC values (N'" + cbkhu.Text + "', N'" + cbphong.Text + "'," + tbgiuong.Text + "," + tbtu.Text + "," + tbdieuhoa.Text + "," + tbnonglanh.Text + "," + tbcua.Text + "," + tbboncau.Text + "," + tbvoixit.Text + "," + tbden.Text + "," + tbvoihoasen.Text + "," + tbwifi.Text + ",N'Có', N'" + tbghichu.Text + "')";
                }
                else
                {
                    them = "insert into CSVC values (N'" + cbkhu.Text + "', N'" + cbphong.Text + "'," + tbgiuong.Text + "," + tbtu.Text + "," + tbdieuhoa.Text + "," + tbnonglanh.Text + "," + tbcua.Text + "," + tbboncau.Text + "," + tbvoixit.Text + "," + tbden.Text + "," + tbvoihoasen.Text + "," + tbwifi.Text + ",N'Không', N'" + tbghichu.Text + "')";
                }
                cmd = new SqlCommand(them, conn);
                dt2.Rows.Clear();
                cmd.ExecuteNonQuery();
                da.Fill(dt2);
                
                MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt2.Rows.Clear();
                string hienthi1 = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng', Giuong as 'Giường', Tu as 'Tủ', DieuHoa as 'Điều hòa', NongLanh as 'Nóng lạnh', Cua as 'Cửa',BonCau as 'Bồn cầu', VoiXit as 'Vòi xịt', Den as 'Đèn', VoiHoaSen as 'Vòi hoa sen', Wifi, Yeucau as 'Yêu cầu sửa',GhiChu as 'Ghi chú' from CSVC where TenPhong = N'" + cbphong.Text + "' and TenKhu = N'" + cbkhu.Text + "'";
                da = new SqlDataAdapter(hienthi1, conn);
                da.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
            tbgiuong.Text = "";
            tbtu.Text = "";
            tbdieuhoa.Text = "";
            tbnonglanh.Text = "";
            tbcua.Text = "";
            tbboncau.Text = "";
            tbvoixit.Text = "";
            tbden.Text = "";
            tbvoihoasen.Text = "";
            tbwifi.Text = "";
            tbghichu.Text = "";
            checksua.Checked = true;

        }

        private void checksua_CheckedChanged(object sender, EventArgs e)
        {
            if (checksua.Checked)
            {
                tbghichu.ReadOnly= false;
                tbghichu.Text = "";
            }
            else
            {
                tbghichu.ReadOnly = true;
                tbghichu.Text = "Không";
            }
        }

        private void cbphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt2.Rows.Clear();
            string hienthi1 = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng', Giuong as 'Giường', Tu as 'Tủ', DieuHoa as 'Điều hòa', NongLanh as 'Nóng lạnh', Cua as 'Cửa',BonCau as 'Bồn cầu', VoiXit as 'Vòi xịt', Den as 'Đèn', VoiHoaSen as 'Vòi hoa sen', Wifi, Yeucau as 'Yêu cầu sửa',GhiChu as 'Ghi chú' from CSVC where TenPhong = N'"+cbphong.Text+"' and TenKhu = N'"+cbkhu.Text+"'";
            da = new SqlDataAdapter(hienthi1, conn);
            da.Fill(dt2);
            dataGridView1.DataSource = dt2;
            tbgiuong.Text = "";
            tbtu.Text = "";
            tbdieuhoa.Text = "";
            tbnonglanh.Text = "";
            tbcua.Text = "";
            tbboncau.Text = "";
            tbvoixit.Text = "";
            tbden.Text = "";
            tbvoihoasen.Text = "";
            tbwifi.Text = "";
            tbghichu.Text = "";
            checksua.Checked = true;
        }
        int ddc;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ddc = e.RowIndex;
                tbgiuong.Text = dataGridView1.Rows[ddc].Cells[2].Value.ToString();
                tbtu.Text = dataGridView1.Rows[ddc].Cells[3].Value.ToString();
                tbdieuhoa.Text = dataGridView1.Rows[ddc].Cells[4].Value.ToString();
                tbnonglanh.Text = dataGridView1.Rows[ddc].Cells[5].Value.ToString();
                tbcua.Text = dataGridView1.Rows[ddc].Cells[6].Value.ToString();
                tbboncau.Text = dataGridView1.Rows[ddc].Cells[7].Value.ToString();
                tbvoixit.Text = dataGridView1.Rows[ddc].Cells[8].Value.ToString();
                tbden.Text = dataGridView1.Rows[ddc].Cells[9].Value.ToString();
                tbvoihoasen.Text = dataGridView1.Rows[ddc].Cells[10].Value.ToString();
                tbwifi.Text = dataGridView1.Rows[ddc].Cells[11].Value.ToString();
                if (dataGridView1.Rows[ddc].Cells[12].Value.ToString() == "Có")
                {
                    checksua.Checked = true;
                }
                else
                {
                    checksua.Checked = false;
                }
                tbghichu.Text = dataGridView1.Rows[ddc].Cells[13].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                string sua;
                if (checksua.Checked)
                {
                    sua = "update CSVC set Giuong = " + tbgiuong.Text + ", Tu = " + tbtu.Text + ", DieuHoa = " + tbdieuhoa.Text + ", NongLanh = " + tbnonglanh.Text +
                    ", Cua = " + tbcua.Text + ", BonCau = " + tbboncau.Text + ", VoiXit = " + tbvoixit.Text + ", Den = " + tbden.Text + ", VoiHoaSen = " + tbvoihoasen.Text +
                    ", Wifi = " + tbwifi.Text + ", Yeucau = N'Có', GhiChu = N'" + tbghichu.Text + "' where TenPhong = N'" + cbphong.Text + "' and TenKhu = N'" + cbkhu.Text + "'";
                }
                else
                {
                    sua = "update CSVC set Giuong = " + tbgiuong.Text + ", Tu = " + tbtu.Text + ", DieuHoa = " + tbdieuhoa.Text + ", NongLanh = " + tbnonglanh.Text +
                    ", Cua = " + tbcua.Text + ", BonCau = " + tbboncau.Text + ", VoiXit = " + tbvoixit.Text + ", Den = " + tbden.Text + ", VoiHoaSen = " + tbvoihoasen.Text +
                    ", Wifi = " + tbwifi.Text + ", Yeucau = N'Không', GhiChu = N'" + tbghichu.Text + "' where TenPhong = N'" + cbphong.Text + "' and TenKhu = N'" + cbkhu.Text + "'";
                }
                cmd = new SqlCommand(sua, conn);
                dt2.Rows.Clear();
                cmd.ExecuteNonQuery();
                da.Fill(dt2);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập kiểm tra lại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
             
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string xoa = "delete from CSVC where TenPhong = N'" + cbphong.Text + "' and TenKhu = N'" + cbkhu.Text + "'";
                cmd = new SqlCommand(xoa, conn);
                dt2.Rows.Clear();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbgiuong.Text = "";
                tbtu.Text = "";
                tbdieuhoa.Text = "";
                tbnonglanh.Text = "";
                tbcua.Text = "";
                tbboncau.Text = "";
                tbvoixit.Text = "";
                tbden.Text = "";
                tbvoihoasen.Text = "";
                tbwifi.Text = "";
                checksua.Checked = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng để xóa","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void tbgiuong_TextChanged(object sender, EventArgs e)
        {
            /*int a;
            try
            {
                a = int.Parse(tb.Text);
            }
            catch (Exception)
            {
                
            }*/
        }

        private void tbgiuong_Leave(object sender, EventArgs e)
        {
            int a;
            try
            {
                a = int.Parse(tb.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb.Focus();
            }
        }
    }
}
