using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace GetWebResource.Auth
{
    class Auths
    {
        public string anlyUrl="";
        public string dClassi="";

        private Hashtable hashResgroupi;

        public Auths()
        {
            hashResgroupi = new Hashtable();
        }

        private static char[] constant =   
      {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
      };

        public string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        public string BuiltPath(string pUrl,string sUrl)
        {
            Regex regc = new Regex(@"\bhttp://.*?\/|\bhttp://.*", RegexOptions.IgnoreCase);
            Match body = regc.Match(sUrl);//看看此资源是不是相对位置
            if (body.Success) return sUrl; int i = 0;//是的话就直接返回了

            if (sUrl.Substring(i, 1) == "/")
            {
                i = 0;
            }
            else if (sUrl.Substring(i, 2) == "../")
            {
                i = 2;
            }
            else
            {
                i = 1;
            }

            switch(i)
            {
                case 0:{
                    Regex regx = new Regex(@"http://\w.*?[\/]+", RegexOptions.IgnoreCase);//不是就要取到当前的目录
                    Match head = regx.Match(pUrl);//获得网站地址头
                    sUrl = head + sUrl;
                } break;
                case 1:{
                    Regex regx = new Regex(@"http://\w.*[\/]+", RegexOptions.IgnoreCase);//不是就要取到当前的目录
                    Match head = regx.Match(pUrl);//获得网站地址头
                    sUrl = head + sUrl;
                    
                } break;
                case 2:{
                    Regex regx = new Regex(@"http://\w.*?[\/]+", RegexOptions.IgnoreCase);//不是就要取到当前的目录
                    Match head = regx.Match(pUrl);//获得网站地址头
                    Regex regv = new Regex(@"\w+.*?(?=\/)", RegexOptions.IgnoreCase);
                    MatchCollection mc = regv.Matches(pUrl);//"http a b c d"
                    if(mc.Count>0)
                    {
                        int n = 0;
                        string tmp=head.Value;
                        foreach (Match m in mc)
                        {
                            n++;
                            if (n < 3) continue;
                            tmp += m.Value;
                        } sUrl = tmp;
                    }
                } break;
                default: break;
            } //避免//符号出现在中间
            return Regex.Replace(sUrl, @"(?<=[^:])\/\/", @"/");
        }

        public string Compare(string s1, string s2)
        {
            string tmp = "";
            int n = s1.Length > s2.Length ? s2.Length : s1.Length;
            for (int i = 0; i < n; i++)
            {
                if (s1.Substring(i, 1) == s2.Substring(i, 1))/*同位置字符是否相同*/
                {
                    tmp += s1.Substring(i, 1);
                }
            } return tmp.Length < 3 ? s2 : tmp;
        }


        public string GetPicAlt(string urlStr)
        {
            Regex regx = new Regex(@"(?<=alt=['""]?)[\w,\u4E00-\u9FA5,“”，。？！：]+", RegexOptions.IgnorePatternWhitespace);
            Match mc = regx.Match(urlStr);
            if (mc.Success)
            {
                return mc.Value;
            } return "";
        }

        public string GetPicNamei(string urlStr)
        {
            Regex regx = new Regex(@"\w+(?=.jpg)", RegexOptions.IgnoreCase);
            Match mc = regx.Match(urlStr);
            if (mc.Success)
            {
                if (dClassi == "")
                {
                    dClassi = mc.Value;
                }
                else
                {
                    dClassi = Compare(dClassi, mc.Value);
                }
            } return dClassi;

        }

        public string GetGroupi(string title)
        {
            string groupiStr = "";
            if (hashResgroupi.Contains(title))
            {
                groupiStr = hashResgroupi[title].ToString();
            }
            else
            {
                groupiStr = DateTime.Now.ToFileTime().ToString() + GenerateRandomNumber(4);// 
                hashResgroupi.Add(title, groupiStr);
            } return groupiStr;
        }

        public Size GetPicSize(string urlStr)
        {
            WebClient mywebclient = new WebClient();
            Regex reg = new Regex(@"\w+.(?:jpg)", RegexOptions.IgnoreCase);
            Match tmpMac = reg.Match(urlStr);
            if (tmpMac.Success)
            {
                try
                {
                    mywebclient.DownloadFile(urlStr, ".//xtmp/pic/" + tmpMac.Value);
                    Bitmap bitmap = new Bitmap(".//xtmp/pic/" + tmpMac.Value);
                    if (bitmap.Width > 0) { return bitmap.Size; }
                }
                catch (System.Exception ex)
                {

                }

            } return new Size(-1, -1);

        }

        public string GetPicTitle(string urlStr)
        {
            Regex reg = new Regex(@"\w+.(?:jpg)");
            Match tmpMac = reg.Match(urlStr);
            if (tmpMac.Success)
            {
                reg = new Regex(@"(?<=>)[\w,\u4E00-\u9FA5,“”，。？！：]+", RegexOptions.IgnoreCase);
                Match tmpMac1 = reg.Match(urlStr);
                if (tmpMac1.Success)
                {
                    return tmpMac1.Value;
                }
            } return "";
        }

        public string GetPicture(String pUrl,String picStr)
        {
            Regex reg = new Regex(@"(?<=src=['""])[^>]*[^/].(?:jpg)", RegexOptions.IgnoreCase);
            Match mach = reg.Match(picStr);
            if (mach.Success)
            {
                string temp = mach.Value;
                Regex regx = new Regex(@"\bhttp://.*?\/|\bhttp://.*", RegexOptions.IgnoreCase);
                Match head = regx.Match(pUrl);//获得网站名称
                Match body = regx.Match(temp);//看看此资源是不是相对位置
                if (!body.Success && head.Success)
                {
                    temp = head + temp;
                    temp = Regex.Replace(temp, @"(?<=[^:])\/\/", @"/");//避免//符号出现在中间

                } return temp;
            } return "";
        }
    }
}
