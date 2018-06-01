using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Legal_CLSCommon
/// </summary>
public class Legal_CLSCommon
{
	public Legal_CLSCommon()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet CallApiGet(string URL)
    {
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlLegal"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var uri = URL;
            HClient.Timeout = TimeSpan.FromMinutes(20);
            var response = HClient.GetAsync(URL).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
          //  var outObject = JsonConvert.DeserializeObject(a).ToString(); 
            DataSet ds = new DataSet();
            ds = JsonConvert.DeserializeObject<DataSet>(a);
           
            //ds.ReadXml(new XmlTextReader(new StringReader(a)));
            //DataTable dt = JsonConvert.DeserializeObject<DataTable>(a);
            return ds;
        }
        catch
        {
            DataSet ds;
            return ds = null;
        }
    }

    public static DataTable CallApiGetdt(string URL)
    {
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlLegal"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var uri = URL;
            HClient.Timeout = TimeSpan.FromMinutes(10);
            var response = HClient.GetAsync(URL).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
            DataTable dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(a);
            //ds.ReadXml(new XmlTextReader(new StringReader(a)));
            //DataTable dt = JsonConvert.DeserializeObject<DataTable>(a);
            return dt;
        }
        catch
        {
            DataTable dt;
            return dt = null;
        }
    }

    public static DataTable CallApiPost(string URL, object obj)
    {
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlLegal"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //  var uri = URL;
            HClient.Timeout = TimeSpan.FromMinutes(10);
            var response = HClient.PostAsJsonAsync(URL, obj).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
            DataTable dt = new DataTable();
             dt = JsonConvert.DeserializeObject<DataTable>(a);
       
            return dt;
        }
        catch
        {
            DataTable dt;
            return dt = null;
        }
    }
    public static DataSet CallApiPostDS(string URL, object obj)
    {
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlLegal"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //  var uri = URL;
            HClient.Timeout = TimeSpan.FromMinutes(10);
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = HClient.PostAsync(URL, content).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
            DataSet ds = new DataSet();
            ds = JsonConvert.DeserializeObject<DataSet>(a);
            return ds;
        }
        catch
        {
            DataSet ds;
            return ds = null;
        }
    }
    public static JObject CallApiPostJson(string URL, object obj)
    {
        JObject jRes = new JObject();
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlLegal"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //  var uri = URL;
            HClient.Timeout = TimeSpan.FromMinutes(10);
            var response = HClient.PostAsJsonAsync(URL, obj).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
            jRes = JObject.Parse(a);
            return jRes;
        }
        catch
        {

            return jRes;
        }
    }

    public static void CommonCheckSession()
    {
        if (HttpContext.Current.Session["UserCode"] == null || HttpContext.Current.Session["UserCode"] == "" || HttpContext.Current.Session["UserCode"] == "0" ||
             HttpContext.Current.Session["CityCode"] == null || HttpContext.Current.Session["CityCode"] == "" || HttpContext.Current.Session["CityCode"] == "0" ||
            HttpContext.Current.Session["OrgCode"] == null || HttpContext.Current.Session["OrgCode"] == "" || HttpContext.Current.Session["OrgCode"] == "0"

            )
        {
            HttpContext.Current.Response.Redirect("~/frmSystem.aspx");
        }
    }
   
    public static string DateFormat(string Date)
    {
        return Date.Substring(6, 4) + "/" + Date.Substring(3, 2) + "/" + Date.Substring(0, 2);
    }
    public static string SendMessage(string MobileNo, string Message)
    {
        try
        {
            string SenderID = "SAATHI";
            StringBuilder sbpostdata = new StringBuilder();
            sbpostdata.AppendFormat("&mobiles={0}", MobileNo);
            sbpostdata.AppendFormat("&message={0}", Message);
            sbpostdata.AppendFormat("&sender={0}", SenderID);
            sbpostdata.AppendFormat("&route={0}", "4");
            string sendSMSUri = "";
            sendSMSUri = "http://msg.msgclub.net/sendhttp.php?authkey=413Azi1FBPp532d30e3";
            //sendSMSUri = "http://panel.msgclub.net/user/index.php?authkey=413Azi1FBPp532d30e3";
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(sbpostdata.ToString());
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse Response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader Reader = new StreamReader(Response.GetResponseStream());
            string ResponseString = Reader.ReadToEnd();
            Reader.Close();
            Response.Close();
            return ResponseString;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public static void SendHtmlFormattedEmail(string body, string email, string Subject = "GST SAATHI")
    {

        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                MailMessage loginInfo = new MailMessage();
                loginInfo.To.Add(email);

                loginInfo.From = new MailAddress("gst@gstsaathi.com");
                loginInfo.Subject = Subject;
                loginInfo.Body = body;
                loginInfo.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.yandex.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("gst@gstsaathi.com", "saathi123");
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(loginInfo);
            }
        }
        catch (System.Net.Mail.SmtpException ex)
        {
            //Response.Write(ex.Message);
        }
    }
}