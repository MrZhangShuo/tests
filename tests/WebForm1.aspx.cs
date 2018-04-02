using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tests
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string GetVariableStr;//注意变量的修饰符
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                GetVariableStr = "物流数据";
            }
        }
        //HttpPost接口测试
        protected string GetFunctionStr()//注意返回值的修饰符
        {
            string url = "http://localhost:50695/LogisticsAPI/Query";

            object PostData = new
            {
                Kuaidi_Type = "3",
                KuaidiApp_key = "",
                KuaidiApp_Secret = "",
                KuaidiApp_Code = "",
                shipperCode = "STO",
                logisticsCode = "964384723742"
            };
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json;charset=UTF-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 8000;
            byte[] btBodys = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(PostData));
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string SynchroIntegralResult = streamReader.ReadToEnd();
            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();
            Nomal.WritLog(SynchroIntegralResult);
            return SynchroIntegralResult;
        }
    }
}