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
    public partial class Quan_UCDSphongtrong : UserControl
    {
        public Quan_UCDSphongtrong()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        private void Quan_UCDSphongtrong_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string truyvan = "SELECT P.TenKhu as 'Tên khu', P.TenPhong as 'Tên Phòng', P.Sochotoida as 'Số chỗ tối đa', (P.Sochotoida - COUNT(S.TenPhong)) AS 'Số chỗ trống'\r\nFROM Phong P\r\nLEFT JOIN SinhVien S ON P.TenKhu = S.TenKhu AND P.TenPhong = S.TenPhong\r\nGROUP BY P.TenKhu, P.TenPhong, P.Sochotoida";
            da = new SqlDataAdapter(truyvan, conn);
            da.Fill(dt);
            dgvdsphongtrong.DataSource = dt;
            int dem = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dem += int.Parse(dt.Rows[i][3].ToString());
            }
            tbsochotrong.Text = dem.ToString();
        }
    }
}
