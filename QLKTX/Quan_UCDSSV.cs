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
    public partial class Quan_UCDSSV : UserControl
    {
        public Quan_UCDSSV()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        private void Quan_UCDSSV_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            /*string laydl = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien";
            da = new SqlDataAdapter(laydl, conn);
            da.Fill(dt);
            dgvdssv.DataSource = dt;
            int dem = 0;
            for(int i=0; i < dt.Rows.Count; i++)
            {
                dem++;
            }
            tbsosv.Text = dem.ToString();*/
        }
        string loc;
        DataTable dt2 = new DataTable();
        private void btloc_Click(object sender, EventArgs e)
        {
            try
            {
                dt2.Rows.Clear();
                dgvdssv.Rows.Clear();
                if (cbloc.SelectedIndex == 0)
                {
                    loc = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Khoahoc = N'" + cbchon.Text + "'";

                }
                else if (cbloc.SelectedIndex == 1)
                {
                    loc = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Lop = N'" + cbchon.Text + "'";
                }
                else if (cbloc.SelectedIndex == 2)
                {
                    loc = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where Khoa = N'" + cbchon.Text + "'";
                }
                else if (cbloc.SelectedIndex == 3)
                {
                    loc = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where TenKhu = N'" + cbchon.Text + "'";
                }
                else if (cbloc.SelectedIndex == 4)
                {
                    loc = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien where TenPhong = N'" + cbchon.Text + "'";
                }
                else if (cbloc.SelectedIndex == 5)
                {
                    loc = "select Msv as 'Mã sinh viên', HoTen as 'Họ tên', Ngaysinh as 'Ngày sinh', GioiTinh as 'Giới tính', Khoa as 'Khoa', Lop as 'Lớp', Khoahoc as 'Khóa học', sdt as 'Số điện thoại', TenKhu as 'Tên khu', TenPhong as 'Tên phòng' from SinhVien";
                }
                da = new SqlDataAdapter(loc, conn);
                da.Fill(dt2);
                int stt = 1;
                for(int i=0; i<dt2.Rows.Count; i++)
                {
                    dgvdssv.Rows.Add(stt.ToString(), dt2.Rows[i][0].ToString(), dt2.Rows[i][1].ToString(), dt2.Rows[i][2].ToString(), dt2.Rows[i][3].ToString(), dt2.Rows[i][4].ToString(), dt2.Rows[i][5].ToString(), dt2.Rows[i][6].ToString(), dt2.Rows[i][7].ToString(), dt2.Rows[i][8].ToString(), dt2.Rows[i][9].ToString());
                    
                    stt++;
                }
                int dem = 0;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    dem++;
                }
                tbsosv.Text = dem.ToString();
            }
            catch (Exception) { }

        }
        
        private void cbloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tradl;
            DataTable dt1= new DataTable();
            if(cbloc.SelectedIndex == 0)
            {
                label3.Text = "Chọn khóa";
                tradl = "select distinct Khoahoc from SinhVien";
                da = new SqlDataAdapter (tradl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "Khoahoc";
            }
            else if (cbloc.SelectedIndex == 1)
            {
                label3.Text = "Chọn lớp";
                tradl = "select distinct Lop from SinhVien";
                da = new SqlDataAdapter(tradl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "Lop";
            }
            else if (cbloc.SelectedIndex == 2)
            {
                label3.Text = "Chọn khoa";
                tradl = "select distinct Khoa from SinhVien";
                da = new SqlDataAdapter(tradl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "Khoa";
            }
            else if (cbloc.SelectedIndex == 3)
            {
                label3.Text = "Chọn khu";
                tradl = "select distinct TenKhu from SinhVien";
                da = new SqlDataAdapter(tradl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "TenKhu";
            }
            else if ( cbloc.SelectedIndex == 4)
            {
                label3.Text = "Chọn phòng";
                tradl = "select distinct TenPhong from SinhVien";
                da = new SqlDataAdapter(tradl, conn);
                da.Fill(dt1);
                cbchon.DataSource = dt1;
                cbchon.ValueMember = "TenPhong";
            }
            else if (cbloc.SelectedIndex == 5)
            {
                label3.Text = "Tất cả";
                cbchon.Text = "Không chọn";
            }
        }
    }
}
