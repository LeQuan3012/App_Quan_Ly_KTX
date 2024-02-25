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
using System.Net.NetworkInformation;

namespace QLKTX
{
    public partial class Ha_UCQLSV : UserControl
    {
        public Ha_UCQLSV()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        

        string timkiem;
        private void cbhinhthuctimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if(cbhinhthuctimkiem.SelectedIndex == 0)
            {
                label1.Text = "Nhập MSV cần tìm kiếm";
                tbnhap.ReadOnly = false;
                tbnhap.Text = "";
                dt.Rows.Clear();
                cbchon.Text = "Không chọn";
            }
            if (cbhinhthuctimkiem.SelectedIndex == 1)
            {
                label1.Text = "Nhập tên cần tìm kiếm";
                tbnhap.ReadOnly = false;
                tbnhap.Text = "";
                dt.Rows.Clear();
                cbchon.Text = "Không chọn";
            }
            else if (cbhinhthuctimkiem.SelectedIndex == 2)
            {
                label1.Text = "Chọn phòng cần tìm kiếm";
                tbnhap.ReadOnly = true;
                tbnhap.Text = "Không nhập";
                cbchon.Text = "";
                timkiem = "select TenPhong from Phong";
                da = new SqlDataAdapter(timkiem, conn);                
                da.Fill(dt);
                cbchon.DataSource = dt;
                cbchon.ValueMember = "TenPhong";
            }
            else if (cbhinhthuctimkiem.SelectedIndex == 3)
            {
                label1.Text = "Chọn quê quán cần tìm";
                tbnhap.ReadOnly = true;
                tbnhap.Text = "Không nhập";
                cbchon.Text = "";
                timkiem = "select distinct Quequan from SinhVien";
                da = new SqlDataAdapter(timkiem, conn);
                da.Fill(dt);
                cbchon.DataSource = dt;
                cbchon.ValueMember = "Quequan";
            }
            else if(cbhinhthuctimkiem.SelectedIndex == 4)
            {
                label1.Text = "Chọn lớp cần tìm kiếm";
                tbnhap.ReadOnly = true;
                tbnhap.Text = "Không nhập";
                cbchon.Text = "";
                timkiem = "select distinct Lop from SinhVien";
                da = new SqlDataAdapter(timkiem, conn);
                da.Fill(dt);
                cbchon.DataSource = dt;
                cbchon.ValueMember = "Lop";
            }
            else if(cbhinhthuctimkiem.SelectedIndex == 5)
            {
                label1.Text = "Chọn khoa cần tìm kiếm";
                tbnhap.ReadOnly = true;
                tbnhap.Text = "Không nhập";
                cbchon.Text = "";
                timkiem = "select distinct Khoa from SinhVien";
                da = new SqlDataAdapter(timkiem, conn);
                da.Fill(dt);
                cbchon.DataSource = dt;
                cbchon.ValueMember = "Khoa";
            }
            else if(cbhinhthuctimkiem.SelectedIndex == 6)
            {
                label1.Text = "Chọn khóa học cần tìm kiếm";
                tbnhap.ReadOnly = true;
                tbnhap.Text = "Không nhập";
                cbchon.Text = "";
                timkiem = "select distinct Khoahoc from SinhVien";
                da = new SqlDataAdapter(timkiem, conn);
                da.Fill(dt);
                cbchon.DataSource = dt;
                cbchon.ValueMember = "Khoahoc";
            }
            else if(cbhinhthuctimkiem.SelectedIndex == 7)
            {
                label1.Text = "Chọn giới tính cần tìm kiếm";
                tbnhap.ReadOnly = true;
                tbnhap.Text = "Không nhập";
                cbchon.Text = "";
                timkiem = "select distinct GioiTinh from SinhVien";
                da = new SqlDataAdapter(timkiem, conn);
                da.Fill(dt);
                cbchon.DataSource = dt;
                cbchon.ValueMember = "GioiTinh";
            }
            else if (cbhinhthuctimkiem.SelectedIndex == 8)
            {
                label1.Text = "Tất cả";
                tbnhap.ReadOnly = true;
                dt.Rows.Clear();
                tbnhap.Text = "Không nhập";
                cbchon.Text = "Không chọn";
            }
            tbmsv.Text = "";
            tbhoten.Text = "";
            rbnam.Checked = false;
            rbnu.Checked = false;
            tbkhoa.Text = "";
            tblop.Text = "";
            tbkhoahoc.Text = "";
            tbsdt.Text = "";
            tbquequan.Text = "";
        }
    
        DataTable dt3 = new DataTable();
        private void Ha_UCQLSV_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            dt3.Rows.Clear();
            //do du lieu vao combobox
            string hienthi = "select TenKhu as 'Tên khu' from Khu ";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt3);
            cbkhu.DataSource = dt3;
            cbkhu.ValueMember = "Tên khu";

            dt1.Rows.Clear();
            timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien";
            da = new SqlDataAdapter(timkiem1 , conn);
            da.Fill(dt1);
            dgvqlsv.DataSource = dt1;
        }
        string timkiem1;
        DataTable dt1 = new DataTable();
        private void bttimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                dt1.Rows.Clear();
                if(cbhinhthuctimkiem.SelectedIndex == 0)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Msv = N'" + tbnhap.Text + "'";
                }
                else if (cbhinhthuctimkiem.SelectedIndex == 1)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where HoTen = N'" + tbnhap.Text + "'";

                }
                else if (cbhinhthuctimkiem.SelectedIndex == 2)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where TenPhong = N'" + cbchon.Text + "'";
                }
                else if (cbhinhthuctimkiem.SelectedIndex == 3)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Quequan = N'" + cbchon.Text + "'";

                }
                else if (cbhinhthuctimkiem.SelectedIndex == 4)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Lop= N'" + cbchon.Text + "'";
                }
                else if(cbhinhthuctimkiem.SelectedIndex == 5)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Khoa = N'" + cbchon.Text + "'";
                }
                else if(cbhinhthuctimkiem.SelectedIndex == 6)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Khoahoc = N'" + cbchon.Text + "'";
                }
                else if(cbhinhthuctimkiem.SelectedIndex == 7)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where GioiTinh = N'" + cbchon.Text + "'";
                }
                else if (cbhinhthuctimkiem.SelectedIndex == 8)
                {
                    timkiem1 = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại',Quequan as 'Quê quán', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien ";
                }
                da = new SqlDataAdapter(timkiem1, conn);
                da.Fill(dt1);
                dgvqlsv.DataSource = dt1;
                tbnhap.Text = "";
                tbmsv.Text = "";
                tbhoten.Text = "";
                rbnam.Checked = false;
                rbnu.Checked = false;
                tbkhoa.Text = "";
                tblop.Text = "";
                tbkhoahoc.Text = "";
                tbsdt.Text = "";
                tbquequan.Text = "";
            
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btthoattimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                dt1.Rows.Clear();
                dgvqlsv.DataSource = dt1;
                tbnhap.Text = "";
                tbmsv.Text = "";
                tbhoten.Text = "";
                rbnam.Checked = false;
                rbnu.Checked = false;
                tbkhoa.Text = "";
                tblop.Text = "";
                tbkhoahoc.Text = "";
                tbsdt.Text = "";
                tbquequan.Text = "";
            
            }
            catch (Exception) { }
            
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                string gioitinh;
                if (rbnam.Checked)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                string them = "insert into SinhVien values ('" + tbmsv.Text + "', N'" + tbhoten.Text + "','" + dtpdate.Text + "',N'" + gioitinh + "', N'" + tbkhoa.Text + "',N'" + tblop.Text + "',N'" + tbkhoahoc.Text + "','" + tbsdt.Text + "',N'" + tbquequan.Text + "', N'" + cbkhu.Text + "', N'" + cbphong.Text + "')";
                cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                dt1.Rows.Clear();
                Ha_UCQLSV_Load(sender, e);
                tbmsv.Text = "";
                tbhoten.Text = "";
                rbnam.Checked = false;
                rbnu.Checked = false;
                tbkhoa.Text = "";
                tblop.Text = "";
                tbkhoahoc.Text = "";
                tbsdt.Text = "";
                tbquequan.Text = "";
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        DataTable dt4 = new DataTable();
        private void cbkhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt4.Rows.Clear();
            string hienthi = "select TenPhong as 'Tên Phòng' from Phong where TenKhu = N'"+cbkhu.Text
                +"' except select SinhVien.TenPhong as 'Tên Phòng' from SinhVien inner join Phong on SinhVien.TenPhong = Phong.TenPhong and SinhVien.TenKhu = Phong.TenKhu "
                +"where SinhVien.TenKhu = N'"+cbkhu.Text+"' group by SinhVien.TenKhu,SinhVien.TenPhong, Phong.sochotoida having count(*) = sochotoida";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt4);
            cbphong.DataSource = dt4;
            cbphong.ValueMember = "Tên Phòng";
        }
        int ddc;
        private void dgvqlsv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ddc = e.RowIndex;
                tbmsv.Text = dgvqlsv.Rows[ddc].Cells[0].Value.ToString();
                tbhoten.Text = dgvqlsv.Rows[ddc].Cells[1].Value.ToString();
                dtpdate.Text = dgvqlsv.Rows[ddc].Cells[2].Value.ToString();
                if (dgvqlsv.Rows[ddc].Cells[3].Value.ToString() == "Nam")
                {
                    rbnam.Checked = true;
                }
                else
                {
                    rbnu.Checked = true;
                }
                tbkhoa.Text = dgvqlsv.Rows[ddc].Cells[4].Value.ToString();
                tblop.Text = dgvqlsv.Rows[ddc].Cells[5].Value.ToString();
                tbkhoahoc.Text = dgvqlsv.Rows[ddc].Cells[6].Value.ToString();
                tbsdt.Text = dgvqlsv.Rows[ddc].Cells[7].Value.ToString();
                cbkhu.Text = dgvqlsv.Rows[ddc].Cells[9].Value.ToString();
                cbphong.Text = dgvqlsv.Rows[ddc].Cells[10].Value.ToString();
                tbquequan.Text = dgvqlsv.Rows[ddc].Cells[8].Value.ToString();
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
                string gioitinh;
                if (rbnam.Checked)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                string sua = "update SinhVien set Msv ='" + tbmsv.Text + "', HoTen = N'" + tbhoten.Text + "', NgaySinh ='" + dtpdate.Text + "', Gioitinh = N'" + gioitinh + "', Khoa = N'" + tbkhoa.Text + "', Lop = N'" + tblop.Text + "', Khoahoc = N'" + tbkhoahoc.Text + "', Sdt = '" + tbsdt.Text + "', Quequan = N'" + tbquequan.Text + "', TenKhu = N'" + cbkhu.Text + "', TenPhong = N'" + cbphong.Text + "' where Msv = '" + dgvqlsv.Rows[ddc].Cells[0].Value.ToString() + "'";
                cmd = new SqlCommand(sua, conn);
                dt1.Rows.Clear();
                cmd.ExecuteNonQuery();
                Ha_UCQLSV_Load(sender, e);
                tbmsv.Text = "";
                tbhoten.Text = "";
                rbnam.Checked = false;
                rbnu.Checked = false;
                tbkhoa.Text = "";
                tblop.Text = "";
                tbkhoahoc.Text = "";
                tbsdt.Text = "";
                tbquequan.Text = "";
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string xoa = "delete from SinhVien where Msv = '" + dgvqlsv.Rows[ddc].Cells[0].Value.ToString()+"'";
                cmd = new SqlCommand(xoa, conn);
                cmd.ExecuteNonQuery();
                dt1.Rows.Clear();
                Ha_UCQLSV_Load(sender, e);
                tbmsv.Text = "";
                tbhoten.Text = "";
                rbnam.Checked = false;
                rbnu.Checked = false;
                tbkhoa.Text = "";
                tblop.Text = "";
                tbkhoahoc.Text = "";
                tbsdt.Text = "";
                tbquequan.Text = "";
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        TextBox tb;
        private void tbmsv_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                tb = (TextBox)sender;
            }
        }

        private void tbmsv_Leave(object sender, EventArgs e)
        {
            int a;
            try
            {
                a = int.Parse(tbsdt.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
            }

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
                MessageBox.Show("Số điện thoại là một chuỗi số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbsdt.Focus();
            }
        }

        private void cbphong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
