namespace QLKTX
{
    partial class QLP
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btdangxuat = new System.Windows.Forms.Button();
            this.btshp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btkhuphong = new System.Windows.Forms.Button();
            this.bthopdong = new System.Windows.Forms.Button();
            this.btthongtincsvc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.thai_UCQLSHP1 = new QLKTX.Thai_UCQLSHP();
            this.cuong_UCthemphongkhu1 = new QLKTX.Cuong_UCthemphongkhu();
            this.cuong_UChopdong1 = new QLKTX.Cuong_UChopdong();
            this.uCnhapthongtinCSVC1 = new QLKTX.UCnhapthongtinCSVC();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 577);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 554);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btdangxuat);
            this.groupBox4.Controls.Add(this.btshp);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(3, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 118);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quản lý sinh hoạt phí";
            // 
            // btdangxuat
            // 
            this.btdangxuat.Location = new System.Drawing.Point(44, 71);
            this.btdangxuat.Name = "btdangxuat";
            this.btdangxuat.Size = new System.Drawing.Size(105, 41);
            this.btdangxuat.TabIndex = 1;
            this.btdangxuat.Text = "Đăng xuất";
            this.btdangxuat.UseVisualStyleBackColor = true;
            this.btdangxuat.Click += new System.EventHandler(this.btdangxuat_Click);
            // 
            // btshp
            // 
            this.btshp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btshp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btshp.ForeColor = System.Drawing.Color.Black;
            this.btshp.Location = new System.Drawing.Point(7, 21);
            this.btshp.Name = "btshp";
            this.btshp.Size = new System.Drawing.Size(193, 33);
            this.btshp.TabIndex = 0;
            this.btshp.Text = "Thông tin sinh hoạt phí";
            this.btshp.UseVisualStyleBackColor = true;
            this.btshp.Click += new System.EventHandler(this.btshp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btkhuphong);
            this.groupBox2.Controls.Add(this.bthopdong);
            this.groupBox2.Controls.Add(this.btthongtincsvc);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 142);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quản lý phòng";
            // 
            // btkhuphong
            // 
            this.btkhuphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btkhuphong.ForeColor = System.Drawing.Color.Black;
            this.btkhuphong.Location = new System.Drawing.Point(7, 101);
            this.btkhuphong.Name = "btkhuphong";
            this.btkhuphong.Size = new System.Drawing.Size(193, 33);
            this.btkhuphong.TabIndex = 2;
            this.btkhuphong.Text = "Khu, Phòng";
            this.btkhuphong.UseVisualStyleBackColor = true;
            this.btkhuphong.Click += new System.EventHandler(this.btkhuphong_Click);
            // 
            // bthopdong
            // 
            this.bthopdong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bthopdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthopdong.ForeColor = System.Drawing.Color.Black;
            this.bthopdong.Location = new System.Drawing.Point(7, 61);
            this.bthopdong.Name = "bthopdong";
            this.bthopdong.Size = new System.Drawing.Size(193, 33);
            this.bthopdong.TabIndex = 1;
            this.bthopdong.Text = "Hợp đồng";
            this.bthopdong.UseVisualStyleBackColor = true;
            this.bthopdong.Click += new System.EventHandler(this.bthopdong_Click);
            // 
            // btthongtincsvc
            // 
            this.btthongtincsvc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btthongtincsvc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthongtincsvc.ForeColor = System.Drawing.Color.Black;
            this.btthongtincsvc.Location = new System.Drawing.Point(7, 22);
            this.btthongtincsvc.Name = "btthongtincsvc";
            this.btthongtincsvc.Size = new System.Drawing.Size(193, 33);
            this.btthongtincsvc.TabIndex = 0;
            this.btthongtincsvc.Text = "Thông tin CSVC";
            this.btthongtincsvc.UseVisualStyleBackColor = true;
            this.btthongtincsvc.Click += new System.EventHandler(this.btthongtincsvc_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.thai_UCQLSHP1);
            this.panel1.Controls.Add(this.cuong_UCthemphongkhu1);
            this.panel1.Controls.Add(this.cuong_UChopdong1);
            this.panel1.Controls.Add(this.uCnhapthongtinCSVC1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(214, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 577);
            this.panel1.TabIndex = 2;
            // 
            // thai_UCQLSHP1
            // 
            this.thai_UCQLSHP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thai_UCQLSHP1.Location = new System.Drawing.Point(0, 0);
            this.thai_UCQLSHP1.Name = "thai_UCQLSHP1";
            this.thai_UCQLSHP1.Size = new System.Drawing.Size(744, 577);
            this.thai_UCQLSHP1.TabIndex = 3;
            // 
            // cuong_UCthemphongkhu1
            // 
            this.cuong_UCthemphongkhu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuong_UCthemphongkhu1.Location = new System.Drawing.Point(0, 0);
            this.cuong_UCthemphongkhu1.Name = "cuong_UCthemphongkhu1";
            this.cuong_UCthemphongkhu1.Size = new System.Drawing.Size(744, 577);
            this.cuong_UCthemphongkhu1.TabIndex = 2;
            // 
            // cuong_UChopdong1
            // 
            this.cuong_UChopdong1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuong_UChopdong1.Location = new System.Drawing.Point(0, 0);
            this.cuong_UChopdong1.Name = "cuong_UChopdong1";
            this.cuong_UChopdong1.Size = new System.Drawing.Size(744, 577);
            this.cuong_UChopdong1.TabIndex = 1;
            // 
            // uCnhapthongtinCSVC1
            // 
            this.uCnhapthongtinCSVC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uCnhapthongtinCSVC1.Location = new System.Drawing.Point(0, 0);
            this.uCnhapthongtinCSVC1.Name = "uCnhapthongtinCSVC1";
            this.uCnhapthongtinCSVC1.Size = new System.Drawing.Size(744, 577);
            this.uCnhapthongtinCSVC1.TabIndex = 0;
            // 
            // QLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "QLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QLP_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btshp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btkhuphong;
        private System.Windows.Forms.Button bthopdong;
        private System.Windows.Forms.Button btthongtincsvc;
        private System.Windows.Forms.Panel panel1;
        private UCnhapthongtinCSVC uCnhapthongtinCSVC1;
        private Thai_UCQLSHP thai_UCQLSHP1;
        private Cuong_UCthemphongkhu cuong_UCthemphongkhu1;
        private Cuong_UChopdong cuong_UChopdong1;
        private System.Windows.Forms.Button btdangxuat;
    }
}