using Dự_án_QLSV_KTX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class QLP : Form
    {
        public QLP()
        {
            InitializeComponent();
        }

        private void btthongtincsvc_Click(object sender, EventArgs e)
        {
            uCnhapthongtinCSVC1.BringToFront();
        }

        private void bthopdong_Click(object sender, EventArgs e)
        {
            cuong_UChopdong1.BringToFront();
        }

        private void btkhuphong_Click(object sender, EventArgs e)
        {
            cuong_UCthemphongkhu1.BringToFront();
        }

        private void btshp_Click(object sender, EventArgs e)
        {
            thai_UCQLSHP1.BringToFront();
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap add = new frmDangNhap();
            add.ShowDialog();
            this.Close();
        }

        private void QLP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
