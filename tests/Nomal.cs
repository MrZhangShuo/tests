using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace tests
{
    public class Nomal
    {
        /// <summary>
        /// 输入日志
        /// </summary>
        /// <param name="mess"></param>
        public static void WritLog(string mess)
        {
            //string path = System.Web.HttpContext.Current.Server.MapPath("tokenlog.txt");
            try
            {
                string path = System.Web.HttpRuntime.AppDomainAppPath + "tokenlog.txt";
                System.IO.File.AppendAllText(path, "\r\n" + DateTime.Now.ToString() + mess, Encoding.UTF8);

            }
            catch (IOException ex)
            {
                //System.IO.IOException 文件占用异常
                //忽略此异常
            }
            catch (Exception e) { }
        }
    }
}