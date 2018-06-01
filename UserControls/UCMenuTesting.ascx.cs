using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_UCMenuTesting : System.Web.UI.UserControl
{
    HttpClient HttpClient;

    Response resp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ProfileID"] != null && Session["SysCode"] != null)
        {
            FillMenu();
        }
    }

    private void FillMenu()
    {
        StringBuilder sb = new StringBuilder();
        int ProfileCode = Convert.ToInt32(Session["ProfileID"].ToString());
        int SysCode = Convert.ToInt32(Session["SysCode"].ToString());
        int UserCode = Convert.ToInt32(Session["UserCode"].ToString());
        string uri = "CtrlUserProfile/GetPermitMenuDesc/";
        resp = new Response();
        if(ProfileCode != 0 && SysCode != 0)
        {
            sb.Append("ProfileCode=" + ProfileCode);
            sb.Append("&SysCode=" + SysCode);
            sb.Append("&UserCode=" + UserCode);
            resp = GetDataAPICallingRequest(uri, sb);
            if (resp.Code == 100)
            {
                string MenuDesc = resp.data;
                menuDiv.InnerHtml = MenuDesc.ToString();
            }
        }
    }

    public Response GetDataAPICallingRequest(string uri, StringBuilder sb)
    {
        HttpClient = new HttpClient();
        resp = new global::Response();

        string baseurl = System.Configuration.ConfigurationManager.AppSettings["BaseUrlAdmin"].ToString(); ;//BaseUrlAdmin
        HttpClient.BaseAddress = new Uri(baseurl);
        HttpClient.DefaultRequestHeaders.Accept.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
        var resRetStatus = HttpClient.GetAsync(uri + "?" + sb.ToString()).Result;
        var responseString = resRetStatus.Content.ReadAsStringAsync().Result;

        resp = JsonConvert.DeserializeObject<Response>(responseString);
        return resp;
    }
}