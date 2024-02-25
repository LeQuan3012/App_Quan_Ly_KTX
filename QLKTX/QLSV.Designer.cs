namespace QLKTX
{
    partial class QLSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btdangxuat = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btsv = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quan_UCDSphongtrong1 = new QLKTX.Quan_UCDSphongtrong();
            this.ha_UCQLSV1 = new QLKTX.Ha_UCQLSV();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.btdangxuat);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 698);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btdangxuat
            // 
            this.btdangxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdangxuat.ForeColor = System.Drawing.Color.Red;
            this.btdangxuat.Location = new System.Drawing.Point(27, 206);
            this.btdangxuat.Name = "btdangxuat";
            this.btdangxuat.Size = new System.Drawing.Size(146, 34);
            this.btdangxuat.TabIndex = 2;
            this.btdangxuat.Text = "Đăng xuất";
            this.btdangxuat.UseVisualStyleBackColor = true;
            this.btdangxuat.Click += new System.EventHandler(this.btdangxuat_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btsv);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(6, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 231);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quản lý sinh viên";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(7, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Danh sách phòng trống";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btsv
            // 
            this.btsv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsv.ForeColor = System.Drawing.Color.Black;
            this.btsv.Location = new System.Drawing.Point(7, 22);
            this.btsv.Name = "btsv";
            this.btsv.Size = new System.Drawing.Size(193, 33);
            this.btsv.TabIndex = 0;
            this.btsv.Text = "Thông tin sinh viên";
            this.btsv.UseVisualStyleBackColor = true;
            this.btsv.Click += new System.EventHandler(this.btsv_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quan_UCDSphongtrong1);
            this.panel1.Controls.Add(this.ha_UCQLSV1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(214, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 698);
            this.panel1.TabIndex = 2;
            // 
            // quan_UCDSphongtrong1
            // 
            this.quan_UCDSphongtrong1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quan_UCDSphongtrong1.Location = new System.Drawing.Point(0, 0);
            this.quan_UCDSphongtrong1.Name = "quan_UCDSphongtrong1";
            this.quan_UCDSphongtrong1.Size = new System.Drawing.Size(786, 698);
            this.quan_UCDSphongtrong1.TabIndex = 1;
            // 
            // ha_UCQLSV1
            // 
            this.ha_UCQLSV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ha_UCQLSV1.Location = new System.Drawing.Point(0, 0);
            this.ha_UCQLSV1.Name = "ha_UCQLSV1";
            this.ha_UCQLSV1.Size = new System.Drawing.Size(786, 698);
            this.ha_UCQLSV1.TabIndex = 0;
            // 
            // QLSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "QLSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QLSV_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btsv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Quan_UCDSphongtrong quan_UCDSphongtrong1;
        private Ha_UCQLSV ha_UCQLSV1;
        private System.Windows.Forms.Button btdangxuat;
    }
}