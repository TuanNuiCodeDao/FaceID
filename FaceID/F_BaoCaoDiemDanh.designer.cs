namespace FaceID
{
    partial class F_BaoCaoDiemDanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_BaoCaoDiemDanh));
            this.dgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTG = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.checkLoc = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkLop = new System.Windows.Forms.CheckBox();
            this.checkKhoa = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDiemDanh
            // 
            this.dgvDiemDanh.AllowUserToAddRows = false;
            this.dgvDiemDanh.AllowUserToDeleteRows = false;
            this.dgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiemDanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvDiemDanh.Location = new System.Drawing.Point(100, 431);
            this.dgvDiemDanh.Name = "dgvDiemDanh";
            this.dgvDiemDanh.ReadOnly = true;
            this.dgvDiemDanh.RowHeadersWidth = 51;
            this.dgvDiemDanh.RowTemplate.Height = 24;
            this.dgvDiemDanh.Size = new System.Drawing.Size(1113, 307);
            this.dgvDiemDanh.TabIndex = 59;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên SV";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "MSSV";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Thời gian điểm danh";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Khoa";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Lớp";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // cbLop
            // 
            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(168, 75);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(415, 32);
            this.cbLop.TabIndex = 55;
            // 
            // cbKhoa
            // 
            this.cbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhoa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(168, 27);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(415, 32);
            this.cbKhoa.TabIndex = 53;
            this.cbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbKhoa_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(377, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 44);
            this.label1.TabIndex = 51;
            this.label1.Text = "TRA CỨU THÔNG TIN ĐIỂM DANH";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(78, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 29);
            this.button5.TabIndex = 50;
            this.button5.Text = "Trở về";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(177, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 24);
            this.label6.TabIndex = 48;
            this.label6.Text = "Thời gian";
            // 
            // dateTG
            // 
            this.dateTG.CustomFormat = "dd/MM/yyyy";
            this.dateTG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTG.Location = new System.Drawing.Point(349, 147);
            this.dateTG.Name = "dateTG";
            this.dateTG.Size = new System.Drawing.Size(418, 30);
            this.dateTG.TabIndex = 61;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(819, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(354, 85);
            this.button1.TabIndex = 62;
            this.button1.Text = "Tra cứu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkLoc
            // 
            this.checkLoc.AutoSize = true;
            this.checkLoc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLoc.Location = new System.Drawing.Point(181, 201);
            this.checkLoc.Name = "checkLoc";
            this.checkLoc.Size = new System.Drawing.Size(143, 28);
            this.checkLoc.TabIndex = 63;
            this.checkLoc.Text = "Lọc kết quả";
            this.checkLoc.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.checkLop);
            this.panel1.Controls.Add(this.checkKhoa);
            this.panel1.Controls.Add(this.cbLop);
            this.panel1.Controls.Add(this.cbKhoa);
            this.panel1.Location = new System.Drawing.Point(181, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 136);
            this.panel1.TabIndex = 64;
            // 
            // checkLop
            // 
            this.checkLop.AutoSize = true;
            this.checkLop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLop.Location = new System.Drawing.Point(60, 77);
            this.checkLop.Name = "checkLop";
            this.checkLop.Size = new System.Drawing.Size(70, 28);
            this.checkLop.TabIndex = 67;
            this.checkLop.Text = "Lớp";
            this.checkLop.UseVisualStyleBackColor = true;
            // 
            // checkKhoa
            // 
            this.checkKhoa.AutoSize = true;
            this.checkKhoa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkKhoa.Location = new System.Drawing.Point(62, 29);
            this.checkKhoa.Name = "checkKhoa";
            this.checkKhoa.Size = new System.Drawing.Size(81, 28);
            this.checkKhoa.TabIndex = 66;
            this.checkKhoa.Text = "Khoa";
            this.checkKhoa.UseVisualStyleBackColor = true;
            this.checkKhoa.CheckedChanged += new System.EventHandler(this.checkKhoa_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 24);
            this.label4.TabIndex = 65;
            this.label4.Text = "Bộ lọc kết quả";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(977, 744);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(236, 47);
            this.button2.TabIndex = 66;
            this.button2.Text = "Xuất báo cáo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // F_BaoCaoDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 803);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkLoc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTG);
            this.Controls.Add(this.dgvDiemDanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_BaoCaoDiemDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO ĐIỂM DANH";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDiemDanh;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.ComboBox cbKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkLoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkLop;
        private System.Windows.Forms.CheckBox checkKhoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button button2;
    }
}