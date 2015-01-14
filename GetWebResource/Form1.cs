using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GetWebResource.Auth;
using System.IO;
using System.Threading;


namespace GetWebResource
{
    public partial class Form1 : Form
    {
        static ArrayList arrayResource;
        static Hashtable hashResource;
        
        public Form1()
        {
            arrayResource = new ArrayList();
            hashResource = new Hashtable();
            InitializeComponent();
        }

        private void done_Click(object sender, EventArgs e)
        {
            CaijiFun caijifun = new CaijiFun();
            string urlStr = this.txt_url.Text.ToString();
            Regex reg = new Regex("^(?<!=http://)([\\w-]+\\.)+[\\w-]+(/[\\w-\\./?%=]*)?");
            urlStr = reg.Replace(urlStr, "http://$0");
            ArrayList strSql = new ArrayList(); string path = @".//xtmp/res.sql";
            //string strSql = caijifun.GetResForSql(urlStr, Encoding.Default);
            /*
            if(this.rad_one.Checked)
            {
                strSql = (caijifun.GetResForSqlA(urlStr, Encoding.Default, this.pBar_wk)).Clone() as ArrayList;
            }else if(this.rad_two.Checked)
            {
                strSql = (caijifun.GetResForSqlB(urlStr, Encoding.Default, this.pBar_wk,this.txt_index.Text, this.txt_pic.Text, this.txt_title.Text)).Clone() as ArrayList;
            }*/
            
            
            ArrayList arrSql = (caijifun.GetResForSql(urlStr, Encoding.Default, this.pBar_wk)).Clone() as ArrayList;
            if (arrSql != null && arrSql.Count > 0)
            {
                this.pBar_wk.Visible = true;int n = 0;
                this.pBar_wk.Maximum = arrSql.Count;
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (ArrayList arr in arrSql)
                    {
                        foreach (string str in arr)
                        {
                            sw.WriteLine(str);
                        } n++; this.pBar_wk.Value = n; Application.DoEvents();
                    } this.pBar_wk.Visible = false;
                }
              }


            //MessageBox.Show(arr[1].ToString());
        }

        private void rad_one_CheckedChanged(object sender, EventArgs e)
        {
            //this.rad_two.Checked = false;
            this.txt_index.Enabled = false;
            this.txt_pic.Enabled = false;
        }

        private void rad_two_CheckedChanged(object sender, EventArgs e)
        {
            //this.rad_one.Checked = false;
            this.txt_index.Enabled = true;
            this.txt_pic.Enabled = true;
        }
    }
}