using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Module_Forms_frmCreateProfile : System.Web.UI.Page
{
    HttpClient HttpClient;  
    ClsUserProfile _Model;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    //// For Success
    //ErrorMsg.Visible = true;
    //    ErrorMsg.InnerText = "Saved !";
    //    ErrorMsg.Attributes.Add("class", "alertMsg success");


    ////for Error

        //ErrorMsg.Visible = true;
        //ErrorMsg.InnerText = "Error !";
        //ErrorMsg.Attributes.Add("class", "alertMsg failed");


    protected void btnSave_Click(object sender, EventArgs e)
    {
        ClsUserProfile obj = new ClsUserProfile();
        obj.Ind = 1;
        obj.LevelId = 0;
        obj.LevelDesc = txtProfileName.Text.Trim();
        obj.OrgCode = Convert.ToInt32(Session["OrgCode"].ToString());
        obj.CityCode = Convert.ToInt32(Session["CityCode"].ToString()); ;
        obj.EntryDate = System.DateTime.Today.ToShortDateString();
        obj.EntryUserCode = Convert.ToInt32(Session["UserCode"].ToString()); ;
        Response res = new Response();
        res = APIRequest(obj);
        if(res.Code == 100)
        {
            ErrorMsg.Visible = true;
            ErrorMsg.InnerText = res.msg;
            ErrorMsg.Attributes.Add("class", "alertMsg success");
        }
        else
        {
            ErrorMsg.Visible = true;
            ErrorMsg.InnerText = res.msg;
            ErrorMsg.Attributes.Add("class", "alertMsg failed");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtProfileName.Text = "";
        ErrorMsg.Visible = false;
        ErrorMsg.InnerText = string.Empty;

    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin_Module/Forms/Dashboard.aspx");
    }

    public Response APIRequest(ClsUserProfile obj)
    {
        Response resp = new Response();
        if (obj != null)
        {
            string uri = "CtrlUserProfile/CreareUserProfile/";
            resp = SaveData(uri, obj);
        }
        return resp;
    }

    public Response SaveData(string uri, ClsUserProfile parameters)
    {
        Response resp = new Response();
        HttpClient = new HttpClient();

        string baseurl = System.Configuration.ConfigurationManager.AppSettings["BaseUrlAdmin"].ToString(); ;//BaseUrlAdmin
        HttpClient.BaseAddress = new Uri(baseurl);
        HttpClient.DefaultRequestHeaders.Accept.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
        var json = JObject.FromObject(parameters).ToString();
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = HttpClient.PostAsync(uri, content).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        resp = JsonConvert.DeserializeObject<Response>(responseString);
        return resp;
    }
}