using QLKTX;
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


namespace Dự_án_QLSV_KTX
{
    public partial class frmDangNhap : Form
    {
        //Khoi tao cac form
        public frmDangNhap()
        {
            InitializeComponent();
        }

        //Tao ket noi toi SQL
        string chuoiKetNoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiKetNoi);
        }

        private void DangNhap_Click(object sender, EventArgs e)
        {
            string VaiTroDN;

             try
             {
                 conn.Open();
                 string username = txtTenDangNhap.Text;
                 string passWord = txtMatKhauDangNhap.Text;
                 if (rdbQTHT.Checked)
                 {
                     VaiTroDN = "1";
                 }
                 else if (rdbQLSV.Checked)
                 {
                     VaiTroDN = "2";
                 }
                 else
                 {
                     VaiTroDN = "3";
                 }
                 string sql = "Select * from TaiKhoan where TenDangNhap = '" + username + "' and MatKhau = '" + passWord + "' and VaiTro = '" + VaiTroDN + "'";
                 SqlCommand cmd = new SqlCommand(sql, conn);
                 SqlDataReader data = cmd.ExecuteReader();
                 if (data.Read() == true)
                 {
                     if (VaiTroDN == "1")
                     {
                        this.Hide();
                         QTHT add = new QTHT();
                         add.ShowDialog();
                         this.Close();
                     }

                     else if (VaiTroDN == "2")
                     {
                         this.Hide();
                         QLSV add = new QLSV();
                         add.ShowDialog();
                         this.Close();
                     }
                     else if (VaiTroDN == "3")
                     {
                        this.Hide();
                         QLP add =  new QLP();
                         add.ShowDialog();
                         this.Close();
                     }

                 }
                 else
                 {
                     MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng kiểm tra thông tin!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                 }
                 conn.Close();
             }
             catch(Exception){
                 MessageBox.Show("Lỗi kết nối", "Connect to SQL", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
             }

                 }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
        
    

