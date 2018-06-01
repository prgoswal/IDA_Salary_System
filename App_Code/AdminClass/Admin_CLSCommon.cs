using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

/// <summary>
/// Summary description for Admin_CommonCls
/// </summary>
public class Admin_CommonCls
{
	public Admin_CommonCls()
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
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlAdmin"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var uri = URL;
            HClient.Timeout = TimeSpan.FromMinutes(10);
            var response = HClient.GetAsync(URL).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
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

    public static void CommonCheckSession()
    {
        if (HttpContext.Current.Session["UserCode"] == null || HttpContext.Current.Session["UserCode"] == "" || HttpContext.Current.Session["UserCode"] == "0" ||
             HttpContext.Current.Session["CityCode"] == null || HttpContext.Current.Session["CityCode"] == "" || HttpContext.Current.Session["CityCode"] == "0" ||
            HttpContext.Current.Session["OrgCode"] == null || HttpContext.Current.Session["OrgCode"] == "" || HttpContext.Current.Session["OrgCode"] == "0"

            )
        {
            HttpContext.Current.Response.Redirect("~/Login.aspx");
        }
    }
}