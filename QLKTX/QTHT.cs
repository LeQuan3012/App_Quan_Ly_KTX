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
    public partial class QTHT : Form
    {
        public QTHT()
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

        private void bttaikhoan_Click(object sender, EventArgs e)
        {
            quan_UCQLTK1.BringToFront();
        }

        private void btsv_Click(object sender, EventArgs e)
        {
            ha_UCQLSV1.BringToFront();
        }

        private void btdssv_Click(object sender, EventArgs e)
        {
            quan_UCDSSV1.BringToFront();
        }

        private void btcsvc_Click(object sender, EventArgs e)
        {
            quan_UCCSVC1.BringToFront();
        }

        private void btdsphongtrong_Click(object sender, EventArgs e)
        {
            quan_UCDSphongtrong1.BringToFront();
        }

        private void btdsshp_Click(object sender, EventArgs e)
        {
            quan_UCSHP1.BringToFront();
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap add = new frmDangNhap();
            add.ShowDialog();
            this.Close();
        }

        private void btthemtk_Click(object sender, EventArgs e)
        {
            uC_ThemTK1.BringToFront();
        }

        private void QTHT_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
