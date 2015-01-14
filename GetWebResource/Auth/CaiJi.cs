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
    /// �������ɼ���   
    /// </summary>   
    class CaiJi
    {
        /// <summary>   
        /// ȡ����ҳԴ��   
        /// </summary>   
        /// <param name="url">��ҳ��ַ��eg:"http://www.yongfa365.com/" </param>    
        /// <param name="charset">��ҳ���룬eg:"utf-8"</param>   
        /// <returns>������ҳԴ�ļ�</returns>   
        public string GetHtmlSource(string url, string charset)
        {
            //���봦��    
            Encoding nowCharset;
            if (charset == "" || charset == null)
            {
                nowCharset = Encoding.Default;
            }
            else
            {
                nowCharset = Encoding.GetEncoding(charset);
            }

            //��������   
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
        /// ȡ����ҳԴ��   
        /// </summary>   
        /// <param name="url">��ҳ��ַ��eg: "http://www.yongfa365.com/" </param>    
        /// <param name="charset">��ҳ���룬eg: Encoding.UTF8</param>   
        /// <returns>������ҳԴ�ļ�</returns>   
        public  string GetHtmlSource(string url, Encoding charset)
        {
            //��������   
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
        /// ȡ����ҳԴ��   
        /// ���ڴ�BOM����ҳ����Ч��������ʲô���붼����ȷʶ��   
        /// </summary>   
        /// <param name="url">��ҳ��ַ��eg: "http://www.yongfa365.com/" </param>    
        /// <returns>������ҳԴ�ļ�</returns>   
        public string GetHtmlSource(string url)
        {
            //��������   
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
