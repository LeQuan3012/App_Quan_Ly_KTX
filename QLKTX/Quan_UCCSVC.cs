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
    public partial class Quan_UCCSVC : UserControl
    {
        public Quan_UCCSVC()
        {
            InitializeComponent();
        }

        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        private void Quan_UCCSVC_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            
        }

        private void btxem_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                string yeucau = "select TenKhu as 'Tên khu', TenPhong as 'Tên phòng',Yeucau as 'Yêu cầu sửa', Ghichu as 'Ghi chú'\r\nfrom CSVC\r\nwhere Yeucau ='Có'";
                da = new SqlDataAdapter(yeucau, conn);
                da.Fill(dt);
                dgvcsvc.DataSource = dt;
                int dem = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dem++;
                }
                tbyeucau.Text = dem.ToString();
            }
            catch (Exception) { }
            
        }
    }
}
