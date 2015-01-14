using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace GetWebResource.Auth
{
    /// <summary>   
    /// 柳永法采集类   
    /// </summary>   
    class CaiJi
    {
        /// <summary>   
        /// 取得网页源码   
        /// </summary>   
        /// <param name="url">网页地址，eg:"http://www.yongfa365.com/" </param>    
        /// <param name="charset">网页编码，eg:"utf-8"</param>   
        /// <returns>返回网页源文件</returns>   
        public string GetHtmlSource(string url, string charset)
        {
            //编码处理    
            Encoding nowCharset;
            if (charset == "" || charset == null)
            {
                nowCharset = Encoding.Default;
            }
            else
            {
                nowCharset = Encoding.GetEncoding(charset);
            }

            //处理内容   
            string html = "";
            try
            {
                //WebRequest myWebRequest = WebRequest.Create(url);   
                //WebResponse myWebResponse = myWebRequest.GetResponse();   
                //Stream stream = myWebResponse.GetResponseStream();   
                //StreamReader reader = new StreamReader(stream, nowCharset);   

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, nowCharset);
                html = reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
            }
            return html;
        }

        /// <summary>   
        /// 取得网页源码   
        /// </summary>   
        /// <param name="url">网页地址，eg: "http://www.yongfa365.com/" </param>    
        /// <param name="charset">网页编码，eg: Encoding.UTF8</param>   
        /// <returns>返回网页源文件</returns>   
        public  string GetHtmlSource(string url, Encoding charset)
        {
            //处理内容   
            string html = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, charset);
                html = reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
            }
            return html;
        }

        /// <summary>   
        /// 取得网页源码   
        /// 对于带BOM的网页很有效，不管是什么编码都能正确识别   
        /// </summary>   
        /// <param name="url">网页地址，eg: "http://www.yongfa365.com/" </param>    
        /// <returns>返回网页源文件</returns>   
        public string GetHtmlSource(string url)
        {
            //处理内容   
            string html = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                html = reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
            }
            return html;
        }
    }  
}
