namespace GetWebResource
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.res_jpg = new System.Windows.Forms.TabPage();
            this.pBar_wk = new System.Windows.Forms.ProgressBar();
            this.done = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.res_mp3 = new System.Windows.Forms.TabPage();
            this.res_avi = new System.Windows.Forms.TabPage();
            this.rad_one = new System.Windows.Forms.RadioButton();
            this.rad_two = new System.Windows.Forms.RadioButton();
            this.txt_index = new System.Windows.Forms.TextBox();
            this.txt_pic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.res_jpg.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.res_jpg);
            this.tabControl1.Controls.Add(this.res_mp3);
            this.tabControl1.Controls.Add(this.res_avi);
            this.tabControl1.Location = new System.Drawing.Point(4, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(323, 213);
            this.tabControl1.TabIndex = 0;
            // 
            // res_jpg
            // 
            this.res_jpg.Controls.Add(this.label3);
            this.res_jpg.Controls.Add(this.txt_title);
            this.res_jpg.Controls.Add(this.label2);
            this.res_jpg.Controls.Add(this.label1);
            this.res_jpg.Controls.Add(this.txt_pic);
            this.res_jpg.Controls.Add(this.txt_index);
            this.res_jpg.Controls.Add(this.rad_two);
            this.res_jpg.Controls.Add(this.rad_one);
            this.res_jpg.Controls.Add(this.pBar_wk);
            this.res_jpg.Controls.Add(this.done);
            this.res_jpg.Controls.Add(this.txt_url);
            this.res_jpg.Location = new System.Drawing.Point(4, 22);
            this.res_jpg.Name = "res_jpg";
            this.res_jpg.Padding = new System.Windows.Forms.Padding(3);
            this.res_jpg.Size = new System.Drawing.Size(315, 187);
            this.res_jpg.TabIndex = 0;
            this.res_jpg.Text = "picture";
            this.res_jpg.UseVisualStyleBackColor = true;
            // 
            // pBar_wk
            // 
            this.pBar_wk.Location = new System.Drawing.Point(7, 153);
            this.pBar_wk.Name = "pBar_wk";
            this.pBar_wk.Size = new System.Drawing.Size(101, 15);
            this.pBar_wk.TabIndex = 1;
            this.pBar_wk.Visible = false;
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(266, 6);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(41, 23);
            this.done.TabIndex = 16;
            this.done.Text = "go";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(6, 6);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(253, 21);
            this.txt_url.TabIndex = 14;
            this.txt_url.Text = "www.2345.com/zt/girl.htm";
            // 
            // res_mp3
            // 
            this.res_mp3.Location = new System.Drawing.Point(4, 22);
            this.res_mp3.Name = "res_mp3";
            this.res_mp3.Padding = new System.Windows.Forms.Padding(3);
            this.res_mp3.Size = new System.Drawing.Size(315, 187);
            this.res_mp3.TabIndex = 1;
            this.res_mp3.Text = "music";
            this.res_mp3.UseVisualStyleBackColor = true;
            // 
            // res_avi
            // 
            this.res_avi.Location = new System.Drawing.Point(4, 22);
            this.res_avi.Name = "res_avi";
            this.res_avi.Size = new System.Drawing.Size(315, 187);
            this.res_avi.TabIndex = 2;
            this.res_avi.Text = "movie";
            this.res_avi.UseVisualStyleBackColor = true;
            // 
            // rad_one
            // 
            this.rad_one.AutoSize = true;
            this.rad_one.Checked = true;
            this.rad_one.Location = new System.Drawing.Point(7, 33);
            this.rad_one.Name = "rad_one";
            this.rad_one.Size = new System.Drawing.Size(119, 16);
            this.rad_one.TabIndex = 17;
            this.rad_one.TabStop = true;
            this.rad_one.Text = "class one(index)";
            this.rad_one.UseVisualStyleBackColor = true;
            this.rad_one.CheckedChanged += new System.EventHandler(this.rad_one_CheckedChanged);
            // 
            // rad_two
            // 
            this.rad_two.AutoSize = true;
            this.rad_two.Location = new System.Drawing.Point(7, 56);
            this.rad_two.Name = "rad_two";
            this.rad_two.Size = new System.Drawing.Size(137, 16);
            this.rad_two.TabIndex = 18;
            this.rad_two.Text = "class two(show pic)";
            this.rad_two.UseVisualStyleBackColor = true;
            this.rad_two.CheckedChanged += new System.EventHandler(this.rad_two_CheckedChanged);
            // 
            // txt_index
            // 
            this.txt_index.Enabled = false;
            this.txt_index.Location = new System.Drawing.Point(25, 78);
            this.txt_index.Name = "txt_index";
            this.txt_index.Size = new System.Drawing.Size(50, 21);
            this.txt_index.TabIndex = 19;
            this.txt_index.Text = "pagesshow";
            // 
            // txt_pic
            // 
            this.txt_pic.Enabled = false;
            this.txt_pic.Location = new System.Drawing.Point(98, 79);
            this.txt_pic.Name = "txt_pic";
            this.txt_pic.Size = new System.Drawing.Size(50, 21);
            this.txt_pic.TabIndex = 20;
            this.txt_pic.Text = "show_img";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "i";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "p";
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(201, 78);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(100, 21);
            this.txt_title.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "title";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 228);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.res_jpg.ResumeLayout(false);
            this.res_jpg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage res_jpg;
        private System.Windows.Forms.TabPage res_mp3;
        private System.Windows.Forms.TabPage res_avi;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.ProgressBar pBar_wk;
        private System.Windows.Forms.RadioButton rad_one;
        private System.Windows.Forms.RadioButton rad_two;
        private System.Windows.Forms.TextBox txt_pic;
        private System.Windows.Forms.TextBox txt_index;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_title;

    }
}

