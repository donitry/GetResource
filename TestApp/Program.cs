using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Data;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strHTML = "<html><form>sss</form></html><html><form>vvvvvv</form></html>";
            Regex regTmp = new Regex("<form.*?</form>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
             MatchCollection mc = regTmp.Matches(strHTML);
             foreach (Match m in mc)
             {
                 Console.WriteLine(m.Value);
             }
            Console.WriteLine(DateTime.Now.ToFileTime());
        }
    }
}
