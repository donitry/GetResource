using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Data;



namespace GetWebResource.Auth
{
    class CaijiFun
    {
        private static Hashtable hashWebStyle;
        public Auths auths;
        private CaiJi caiji;
        private String anyUrl;


        public CaijiFun()
        {
            auths = new Auths();
            caiji = new CaiJi(); 
            hashWebStyle = new Hashtable();
            hashWebStyle.Add("http://www.2345.com/", "a");
            hashWebStyle.Add("http://www.166122.com/","b");

        }

        public String GetHtml(string url,Encoding charset)
        {
            return caiji.GetHtmlSource(url, charset);
        }

        public ArrayList GetResoucre(string url, Encoding charset, object sender,string title)
        {
            string temp = auths.BuiltPath(this.anyUrl,url);
            Regex regx = new Regex(@"http://\w.*?[\/]+", RegexOptions.IgnoreCase);//不是就要取到当前的目录
            Match head = regx.Match(temp);//获得网站地址头
            if(head.Success && hashWebStyle.ContainsKey(head.Value))
            {
                if (hashWebStyle[head.Value].ToString() == "a")
                {
                    return GetResForSqlA(temp, charset, sender);
                }
                else if (hashWebStyle[head.Value].ToString() == "b")
                {
                    return GetResForSqlB(temp, charset, sender, "pagesshow", "show_img", title);
                }
                else return null;
            }return null;
        }

        public ArrayList GetResForSql(string url, Encoding charset, object sender)
        {
            this.anyUrl = url; auths.dClassi = "";
            ProgressBar press = (sender as ProgressBar);
            ArrayList arrTmp = new ArrayList();
            Hashtable hashTmp = new Hashtable();
            string strHTML = caiji.GetHtmlSource(url, charset);
            if(strHTML!="")
            {
                ArrayList tmpx = GetResForSqlA(url, charset, sender); //先把当前的索引页写进去
                if (tmpx != null && tmpx.Count > 0) arrTmp.Add(tmpx);
                Regex regx = new Regex(@"(?<=<img)[^<].*[\s]*<a.*(?=<(\/a))", RegexOptions.IgnoreCase);
                MatchCollection mc = regx.Matches(strHTML);
                 if (mc.Count > 0)
                 {
                     press.Maximum = mc.Count;
                     press.Visible = true; int n = 0;
                     ArrayList sitTmp = new ArrayList();
                     foreach (Match m in mc)
                     {
                         Regex regv = new Regex(@"(?<=href=['""""]+).*?(?=[?'""]+)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                         Match mc_href = regv.Match(m.Value);
                         string titleStr = auths.GetPicTitle(m.Value);
                         if(mc_href.Success)
                         {
                             if (sitTmp.Contains(mc_href.Value)) continue;
                             ArrayList tmp = GetResoucre(mc_href.Value, charset, sender, titleStr);
                             if(tmp!=null)
                             {
                                 sitTmp.Add(mc_href.Value); 
                                 arrTmp.Add(tmp.Clone() as ArrayList);
                             }
                             
                         }// if(mc_href.Success)
                         n++; press.Value = n; Application.DoEvents();
                     }// foreach (Match m in mc)
                 }// if (mc.Count > 0)
                 press.Visible = false; return arrTmp;
            }// if(strHTML!="")
            return null;
        }


        /// <summary>
        ///  解决一类采集：类似2345主页的图片分布。主要是简单的列表显示
        /// </summary>
        /// <param name="url">网站地址</param>
        /// <param name="charset">编码</param>
        /// <param name="sender">进度条</param>
        /// <returns>arraylist已经封装好的sql语句:insert into</returns>
        public ArrayList GetResForSqlA(string url,Encoding charset,object sender)
        {
            
          
            ArrayList arrTmp = new ArrayList();
            string strHTML = caiji.GetHtmlSource(url, charset);
            
            if (strHTML != "")
            {
                Regex reg = new Regex(@"(?<=<img)[^<].*[\s]*<a.*(?=<(\/a))", RegexOptions.IgnoreCase);
                MatchCollection mc = reg.Matches(strHTML);
                 if (mc.Count > 0)
                 {
    
                    string classiStr = "";
                    foreach (Match m in mc)
                    {
                        string picStr = auths.GetPicture(url,m.Value);
                        string titleStr = auths.GetPicTitle(m.Value);
                        string altStr = auths.GetPicAlt(m.Value);
                          if (picStr != "" && titleStr != "")
                          {
                              Size sizePic = auths.GetPicSize(picStr);
                              string groupiStr = auths.GetGroupi(titleStr);
                              string indexiStr = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                              string nameiStr = auths.GetPicNamei(picStr);
                              if (classiStr == "") classiStr = altStr;
                              else
                              {
                                  if (altStr != "" && classiStr != altStr)
                                  {
                                      classiStr = altStr;
                                  }
                              }
                              string strSql = string.Format(  "INSERT INTO `Dbm_WebSite`.`Tal_Resource` (`width`,`height`,`type`,`src`,`title`,`groupi`,`linki`,`g_alt`,`classi`,`indexi`,`namei`) "+
                                  "SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}' FROM DUAL WHERE '{11}' NOT IN (SELECT src FROM `Dbm_WebSite`.`Tal_Resource`);",
                                                                                sizePic.Width, sizePic.Height, "jpg", picStr, titleStr, groupiStr, "/" + indexiStr + "/" + groupiStr, altStr, classiStr, indexiStr, nameiStr, picStr);
                             
                              arrTmp.Add(strSql);
                              //arrTmp.Add(picStr + "  desc:  " + decStr + " classi: " + testClassi + " size: " + testSize.ToString());
                          } 
                      } 
                      return arrTmp;
                 }
             } return null;
        }

        /// <summary>
        /// 解决二类采集：类似/www.166122.com/meinv/show_3090.htm这样页面的图片分布。主要是一个页只有一副图
        /// 多图对应多页的情况
        /// </summary>
        /// <param name="url">网站地址</param>
        /// <param name="charset">编码</param>
        /// <param name="sender">进度条</param>
        /// <returns>arraylist已经封装好的sql语句:insert into</returns>
        public ArrayList GetResForSqlB(string url,Encoding charset,object sender,string index,string pic,string title)
        {
            string strHTML = caiji.GetHtmlSource(url, charset);
            ArrayList arrTmp = new ArrayList();
            if(strHTML!="")
            {
                Regex regv = new Regex(@"(?<=<(div)[\s])class=['""]?" + pic + @".*['""]?[\s]*<a.*(?=<\/\1>)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                Regex regx = new Regex(@"(?<=<(div)[\s])class=['""]?" + index + @".*['""]?[\s]*<a.*(?=<\/\1>)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                Match mc = regx.Match(strHTML);
                if(mc.Success)
                {
                    regx = new Regex(@"(?<=href=['""]+).*?(?=['""]+)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                    MatchCollection mcc = regx.Matches(mc.Value);
                    if(mcc.Count>0)
                    {
                        
                        foreach (Match m in mcc)
                        {
                            string temp = auths.BuiltPath(url,m.Value);
                            string tmpHtml = caiji.GetHtmlSource(temp, charset);
                            if (tmpHtml != "")
                            {
                                Match mcPic = regv.Match(tmpHtml);
                                if (mcPic.Success)
                                {
                                    string picStr = auths.GetPicture(url,mcPic.Value);
                                    Size sizePic = auths.GetPicSize(picStr);
                                    string groupiStr = auths.GetGroupi(title);
                                    
                                    string indexiStr = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                                    string nameiStr = auths.GetPicNamei(picStr);
                                    string altStr = auths.GetPicAlt(mcPic.Value);
                                    string classiStr = "";
                                    if (classiStr == "") classiStr = altStr;
                                    else
                                    {
                                        if (altStr != "" && classiStr != altStr)
                                        {
                                            classiStr = altStr;
                                        }
                                    }
                                    string strSql = string.Format("INSERT INTO `Dbm_WebSite`.`Tal_Resource` (`width`,`height`,`type`,`src`,`title`,`groupi`,`linki`,`g_alt`,`indexi`,`namei`) " +
                                  "SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}' FROM DUAL WHERE '{10}' NOT IN (SELECT src FROM `Dbm_WebSite`.`Tal_Resource`);",
                                                                                sizePic.Width, sizePic.Height, "jpg", picStr, title, groupiStr, "/" + indexiStr + "/" + groupiStr, altStr, indexiStr, nameiStr, picStr);

                                    arrTmp.Add(strSql);
                                    //arrTmp.Add(picStr + "  desc:  " + decStr + " classi: " + testClassi + " size: " + testSize.ToString());
                                } 
                            }

                        }  return arrTmp;
                    }
                }
            }

            return null;
        }
    }
}
