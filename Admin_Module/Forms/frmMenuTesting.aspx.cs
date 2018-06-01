using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using Newtonsoft.Json.Linq;

public partial class Admin_Module_Forms_frmMenuTesting : System.Web.UI.Page
{
    HttpClient HttpClient;
    Response resp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OrgCode"] == null && Session["CityCode"] == null && Session["UserCode"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            FillDropdown();
        }
    }
    private void FillDropdown()
    {
        int Ind = 1;
        int OrgCode = Convert.ToInt32(Session["OrgCode"].ToString());
        int CityCode = Convert.ToInt32(Session["CityCode"].ToString());
        int EntryUserCode = Convert.ToInt32(Session["UserCode"].ToString());
        StringBuilder sb = new StringBuilder();

        sb.Append("Ind=" + Ind);
        sb.Append("&OrgCode=" + OrgCode);
        sb.Append("&CityCode=" + CityCode);
        sb.Append("&EntryUserCode=" + EntryUserCode);
        string uri = "CtrlUserProfile/GetProfileSyatem/";
        resp = new Response();

        resp = GetDataAPICallingRequest(uri, sb);
        if (resp.Code == 100)
        {
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(resp.data);
            if (ds.Tables.Count > 0)
            {

                ddlProfileName.DataSource = ds.Tables[0];
                ddlProfileName.DataTextField = "LevelDesc";
                ddlProfileName.DataValueField = "LevelId";
                ddlProfileName.DataBind();
                ddlProfileName.Items.Insert(0, "-Select-");

                ddlSystemName.DataSource = ds.Tables[1];
                ddlSystemName.DataTextField = "SystemName";
                ddlSystemName.DataValueField = "SystemCode";
                ddlSystemName.DataBind();
                ddlSystemName.Items.Insert(0, "-Select-");
            }
        }
        else
        {
            ddlProfileName.Focus();
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

    protected void btnGo_Click(object sender, EventArgs e)
    {
        if(ddlProfileName.SelectedIndex != 0)
        {
            Session["ProfileID"] = ddlProfileName.SelectedValue;
        }
        if(ddlSystemName.SelectedIndex != 0)
        {
            Session["SysCode"] = ddlSystemName.SelectedValue;
        }
        Response.Redirect("~/Admin_Module/frmTestingHomePage.aspx");
    }
}