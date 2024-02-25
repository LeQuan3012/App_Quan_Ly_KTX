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
    public partial class Quan_UCSHP : UserControl
    {
        public Quan_UCSHP()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        
        
        private void cbhinhthucthongke_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            string laydl;
            if (cbhinhthucthongke.SelectedIndex == 0)
            {
                lbhinhthucthongke.Text = "Vui lòng chọn phòng";
                laydl = "select TenPhong from Phong";
                da = new SqlDataAdapter(laydl, conn);               
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "TenPhong";
            }
            else if (cbhinhthucthongke.SelectedIndex == 1)
            {
                lbhinhthucthongke.Text = "Vui lòng chọn khu";
                laydl = "select TenKhu from Khu";
                da = new SqlDataAdapter(laydl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "TenKhu";
            }
            else if (cbhinhthucthongke.SelectedIndex == 2)
            {
                lbhinhthucthongke.Text = "Vui lòng chọn tháng";
                laydl = "select Thang from SinhHoatPhi";
                da = new SqlDataAdapter(laydl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "Thang";
            }
            else if(cbhinhthucthongke.SelectedIndex == 3)
            {
                lbhinhthucthongke.Text = "Tất cả";
                cbchon.Text = "Không chọn";
            }
            else if(cbhinhthucthongke.SelectedIndex == 4)
            {
                lbhinhthucthongke.Text = "";
                cbchon.Text = "Không chọn";
            }

        }
        string loc;
        
        private void btloc_Click(object sender, EventArgs e)
        {
            try
            {
                double tiendien = 0, tiennuoc = 0, tienwifi = 0, tienphong = 0;
                dt.Rows.Clear();
                if (cbhinhthucthongke.SelectedIndex == 0)
                {
                    loc = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', TongTien as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' from SinhHoatPhi where TenPhong = N'" + cbchon.Text + "'";
                }
                else if (cbhinhthucthongke.SelectedIndex == 1)
                {
                    loc = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', TongTien as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' from SinhHoatPhi where TenKhu = N'" + cbchon.Text + "'";
                }
                else if (cbhinhthucthongke.SelectedIndex == 2)
                {
                    loc = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', TongTien as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' from SinhHoatPhi where Thang = N'" + cbchon.Text + "'";
                }
                else if (cbhinhthucthongke.SelectedIndex == 3)
                {
                    loc = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', TongTien as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' from SinhHoatPhi";
                }
                else if (cbhinhthucthongke.SelectedIndex == 4)
                {
                    loc = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',thang as 'Tháng',nam as 'Năm', TienDien as 'Tiền điện', TienNuoc as 'Tiền nước', TienWifi as 'Tiền Wifi', TienPhong as 'Tiền phòng', TongTien as 'Tổng tiền', noptien as 'Tình trạng nộp tiền', ghichu as 'Ghi chú' from SinhHoatPhi where noptien = N'Chưa nộp'";
                }
                da = new SqlDataAdapter(loc, conn);
                da.Fill(dt);
                dgvshp.DataSource = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tiendien += double.Parse(dt.Rows[i][4].ToString());
                    tiennuoc += double.Parse(dt.Rows[i][5].ToString());
                    tienwifi += double.Parse(dt.Rows[i][6].ToString());
                    tienphong += double.Parse(dt.Rows[i][7].ToString());
                }
                tbtiendien.Text = tiendien.ToString();
                tbtiennuoc.Text = tiennuoc.ToString();
                tbtienwifi.Text = tienwifi.ToString();
                tbtienphong.Text = tienphong.ToString();
                tbtong.Text = (tiendien + tiennuoc + tienphong + tienwifi).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Quan_UCSHP_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
        }
    }
}