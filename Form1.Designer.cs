
namespace RunDemoProject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFileSelect1 = new System.Windows.Forms.Label();
            this.lblFileSelect3 = new System.Windows.Forms.Label();
            this.lblFileSelect2 = new System.Windows.Forms.Label();
            this.tbxFileSelect1 = new System.Windows.Forms.TextBox();
            this.tbxFileSelect3 = new System.Windows.Forms.TextBox();
            this.tbxFileSelect2 = new System.Windows.Forms.TextBox();
            this.btnFileSelect1 = new System.Windows.Forms.Button();
            this.btnFileSelect2 = new System.Windows.Forms.Button();
            this.btnFileSelect3 = new System.Windows.Forms.Button();
            this.btnRunPython = new System.Windows.Forms.Button();
            this.btnHalcon = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpSelect = new System.Windows.Forms.TabPage();
            this.tbpShow = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tbpSelect.SuspendLayout();
            this.tbpShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileSelect1
            // 
            this.lblFileSelect1.AutoSize = true;
            this.lblFileSelect1.Location = new System.Drawing.Point(18, 32);
            this.lblFileSelect1.Name = "lblFileSelect1";
            this.lblFileSelect1.Size = new System.Drawing.Size(83, 12);
            this.lblFileSelect1.TabIndex = 0;
            this.lblFileSelect1.Text = "Hdict文件路径";
            this.lblFileSelect1.Click += new System.EventHandler(this.lblFileSelect1_Click_1);
            // 
            // lblFileSelect3
            // 
            this.lblFileSelect3.AutoSize = true;
            this.lblFileSelect3.Location = new System.Drawing.Point(23, 179);
            this.lblFileSelect3.Name = "lblFileSelect3";
            this.lblFileSelect3.Size = new System.Drawing.Size(77, 12);
            this.lblFileSelect3.TabIndex = 1;
            this.lblFileSelect3.Text = "标注文件路径";
            // 
            // lblFileSelect2
            // 
            this.lblFileSelect2.AutoSize = true;
            this.lblFileSelect2.Location = new System.Drawing.Point(24, 137);
            this.lblFileSelect2.Name = "lblFileSelect2";
            this.lblFileSelect2.Size = new System.Drawing.Size(53, 12);
            this.lblFileSelect2.TabIndex = 2;
            this.lblFileSelect2.Text = "图像路径";
            // 
            // tbxFileSelect1
            // 
            this.tbxFileSelect1.Location = new System.Drawing.Point(138, 29);
            this.tbxFileSelect1.Name = "tbxFileSelect1";
            this.tbxFileSelect1.Size = new System.Drawing.Size(809, 21);
            this.tbxFileSelect1.TabIndex = 3;
            // 
            // tbxFileSelect3
            // 
            this.tbxFileSelect3.Location = new System.Drawing.Point(138, 174);
            this.tbxFileSelect3.Name = "tbxFileSelect3";
            this.tbxFileSelect3.Size = new System.Drawing.Size(809, 21);
            this.tbxFileSelect3.TabIndex = 4;
            // 
            // tbxFileSelect2
            // 
            this.tbxFileSelect2.Location = new System.Drawing.Point(138, 132);
            this.tbxFileSelect2.Name = "tbxFileSelect2";
            this.tbxFileSelect2.Size = new System.Drawing.Size(809, 21);
            this.tbxFileSelect2.TabIndex = 5;
            // 
            // btnFileSelect1
            // 
            this.btnFileSelect1.Location = new System.Drawing.Point(964, 27);
            this.btnFileSelect1.Name = "btnFileSelect1";
            this.btnFileSelect1.Size = new System.Drawing.Size(34, 23);
            this.btnFileSelect1.TabIndex = 6;
            this.btnFileSelect1.Text = "...";
            this.btnFileSelect1.UseVisualStyleBackColor = true;
            this.btnFileSelect1.Click += new System.EventHandler(this.btnFileSelect1_Click);
            // 
            // btnFileSelect2
            // 
            this.btnFileSelect2.Location = new System.Drawing.Point(964, 132);
            this.btnFileSelect2.Name = "btnFileSelect2";
            this.btnFileSelect2.Size = new System.Drawing.Size(34, 23);
            this.btnFileSelect2.TabIndex = 7;
            this.btnFileSelect2.Text = "...";
            this.btnFileSelect2.UseVisualStyleBackColor = true;
            this.btnFileSelect2.Click += new System.EventHandler(this.btnFileSelect2_Click);
            // 
            // btnFileSelect3
            // 
            this.btnFileSelect3.Location = new System.Drawing.Point(964, 174);
            this.btnFileSelect3.Name = "btnFileSelect3";
            this.btnFileSelect3.Size = new System.Drawing.Size(34, 23);
            this.btnFileSelect3.TabIndex = 8;
            this.btnFileSelect3.Text = "...";
            this.btnFileSelect3.UseVisualStyleBackColor = true;
            this.btnFileSelect3.Click += new System.EventHandler(this.btnFileSelect3_Click);
            // 
            // btnRunPython
            // 
            this.btnRunPython.Location = new System.Drawing.Point(138, 223);
            this.btnRunPython.Name = "btnRunPython";
            this.btnRunPython.Size = new System.Drawing.Size(75, 23);
            this.btnRunPython.TabIndex = 9;
            this.btnRunPython.Text = "执行Python";
            this.btnRunPython.UseVisualStyleBackColor = true;
            this.btnRunPython.Click += new System.EventHandler(this.btnRunPython_Click);
            // 
            // btnHalcon
            // 
            this.btnHalcon.Location = new System.Drawing.Point(138, 79);
            this.btnHalcon.Name = "btnHalcon";
            this.btnHalcon.Size = new System.Drawing.Size(75, 23);
            this.btnHalcon.TabIndex = 10;
            this.btnHalcon.Text = "Hdict2Txt";
            this.btnHalcon.UseVisualStyleBackColor = true;
            this.btnHalcon.Click += new System.EventHandler(this.btnHalcon_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpSelect);
            this.tabControl1.Controls.Add(this.tbpShow);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1115, 716);
            this.tabControl1.TabIndex = 11;
            // 
            // tbpSelect
            // 
            this.tbpSelect.Controls.Add(this.tbxFileSelect3);
            this.tbpSelect.Controls.Add(this.btnHalcon);
            this.tbpSelect.Controls.Add(this.lblFileSelect1);
            this.tbpSelect.Controls.Add(this.btnRunPython);
            this.tbpSelect.Controls.Add(this.lblFileSelect2);
            this.tbpSelect.Controls.Add(this.btnFileSelect3);
            this.tbpSelect.Controls.Add(this.lblFileSelect3);
            this.tbpSelect.Controls.Add(this.btnFileSelect2);
            this.tbpSelect.Controls.Add(this.tbxFileSelect1);
            this.tbpSelect.Controls.Add(this.btnFileSelect1);
            this.tbpSelect.Controls.Add(this.tbxFileSelect2);
            this.tbpSelect.Location = new System.Drawing.Point(4, 22);
            this.tbpSelect.Name = "tbpSelect";
            this.tbpSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSelect.Size = new System.Drawing.Size(1107, 690);
            this.tbpSelect.TabIndex = 0;
            this.tbpSelect.Text = "页面1";
            this.tbpSelect.UseVisualStyleBackColor = true;
            // 
            // tbpShow
            // 
            this.tbpShow.Controls.Add(this.panel1);
            this.tbpShow.Location = new System.Drawing.Point(4, 22);
            this.tbpShow.Name = "tbpShow";
            this.tbpShow.Padding = new System.Windows.Forms.Padding(3);
            this.tbpShow.Size = new System.Drawing.Size(1107, 690);
            this.tbpShow.TabIndex = 1;
            this.tbpShow.Text = "页面2";
            this.tbpShow.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 397);
            this.panel1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1107, 690);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "页面3";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1107, 690);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "页面4";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 716);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Demo";
            this.tabControl1.ResumeLayout(false);
            this.tbpSelect.ResumeLayout(false);
            this.tbpSelect.PerformLayout();
            this.tbpShow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFileSelect1;
        private System.Windows.Forms.Label lblFileSelect3;
        private System.Windows.Forms.Label lblFileSelect2;
        private System.Windows.Forms.TextBox tbxFileSelect1;
        private System.Windows.Forms.TextBox tbxFileSelect3;
        private System.Windows.Forms.TextBox tbxFileSelect2;
        private System.Windows.Forms.Button btnFileSelect1;
        private System.Windows.Forms.Button btnFileSelect2;
        private System.Windows.Forms.Button btnFileSelect3;
        private System.Windows.Forms.Button btnRunPython;
        private System.Windows.Forms.Button btnHalcon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpSelect;
        private System.Windows.Forms.TabPage tbpShow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
    }
}

