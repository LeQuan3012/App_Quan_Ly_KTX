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
    public partial class QLSV : Form
    {
        public QLSV()
        {
            InitializeComponent();
        }

        private void btsv_Click(object sender, EventArgs e)
        {
            ha_UCQLSV1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quan_UCDSphongtrong1.BringToFront();
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap add = new frmDangNhap();
            add.ShowDialog();
            this.Close();
        }

        private void QLSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
