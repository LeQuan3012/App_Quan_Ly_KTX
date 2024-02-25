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
using System.IO;
using System.Drawing.Imaging;
using System.Linq.Expressions;

namespace QLKTX
{
    public partial class Cuong_UChopdong : UserControl
    {
        private OpenFileDialog openFileDialog1;
        public Cuong_UChopdong()
        {
            InitializeComponent();
        }
        public Cuong_UChopdong(OpenFileDialog openFileDialog1)
        {
            InitializeComponent();
            this.openFileDialog1 = openFileDialog1;
        }
        string chuoiketnoi = "Data Source=LEQUAN-3012;Initial Catalog=csdl_nhom4;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        private void Cuong_UChopdong_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            //do du lieu vao combobox
            string hienthi = "select TenKhu as 'Tên khu' from Khu ";
            da = new SqlDataAdapter(hienthi, conn);
            da.Fill(dt);
            cbkhu.DataSource = dt;
            cbkhu.ValueMember = "Tên khu";
            cbkhu.SelectedIndex = 0;
        }

        
        private void cbkhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();
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

        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng OpenFileDialog mới
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Định cấu hình các thuộc tính của hộp thoại
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog1.Title = "Select an image file";

                // Hiển thị hộp thoại cho người dùng và xử lý kết quả trả về
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName.ToString();
                    pichopdong.ImageLocation = file;
                    byte[] images = null;
                    FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    images = brs.ReadBytes((int)stream.Length);

                    string chenanh = "insert into HopDong values (N'" + cbkhu.Text + "', N'" + cbphong.Text + "', @images)";
                    cmd = new SqlCommand(chenanh, conn);
                    cmd.Parameters.Add(new SqlParameter("@images", images));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công");
                }
            
            }
            catch (Exception)
            {

            }
        }

        private void cbphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                SqlDataReader reader = null;
                pichopdong.Image = null;
                string query = "SELECT Image FROM HopDong WHERE TenKhu = N'" + cbkhu.Text + "' and TenPhong = N'" + cbphong.Text + "'";
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                img = (byte[])(reader[0]);
                if (img == null)
                {
                    pichopdong.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    pichopdong.Image = Image.FromStream(ms);
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng OpenFileDialog mới
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Định cấu hình các thuộc tính của hộp thoại
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog1.Title = "Select an image file";

                // Hiển thị hộp thoại cho người dùng và xử lý kết quả trả về
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName.ToString();
                    pichopdong.ImageLocation = file;
                    byte[] images = null;
                    FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    images = brs.ReadBytes((int)stream.Length);

                    string suaanh = "update HopDong set Image = @images where TenPhong = N'" + cbphong.Text + "' and TenKhu = N'" + cbkhu.Text + "'";
                    cmd = new SqlCommand(suaanh, conn);
                    cmd.Parameters.Add(new SqlParameter("@images", images));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công");
                }


            }
            catch (Exception) { }
        }
    }
}
