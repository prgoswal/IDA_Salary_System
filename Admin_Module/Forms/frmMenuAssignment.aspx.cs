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

public partial class Admin_Module_Forms_frmMenuAssignment : System.Web.UI.Page
{
    HttpClient HttpClient;
    Response resp;
    List<MainMenu> MainMenuList;
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
            ErrorMsg.Visible = true;
            ErrorMsg.InnerText = resp.msg;
            ErrorMsg.Attributes.Add("class", "alertMsg failed");
            ddlProfileName.Focus();
        }


    }
    int MainRowindex = 0;

    protected void gvMainMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            int RowIndex = e.Row.RowIndex;
            if (gvMainMenu.DataKeys[RowIndex][1].ToString() == "#")
            {
                MainRowindex = RowIndex;
                GridView grdSubmenul1 = (GridView)e.Row.FindControl("gvSubMenuL1");
                grdSubmenul1.DataSource = MainMenuList[RowIndex].sml1;
                grdSubmenul1.DataBind();
            }
        }
    }

    protected void gvSubMenuL1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfLink = (HiddenField)e.Row.FindControl("hfLinkUrl");

            //GridView grdSubmenul1 = (GridView)gvMainMenu.Rows[MainRowindex].FindControl("gvSubMenuL1");
            int RowIndex = e.Row.RowIndex;
            if (hfLink.Value == "#")
            {
                GridView grdSubmenul2 = (GridView)e.Row.FindControl("gvSubMenuL2");
                grdSubmenul2.DataSource = MainMenuList[MainRowindex].sml1[RowIndex].sml2;
                grdSubmenul2.DataBind();
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlProfileName.SelectedIndex == 0)
        {
            ErrorMsg.Visible = true;
            ErrorMsg.InnerText = "Profile name is required";
            ErrorMsg.Attributes.Add("class", "alertMsg failed");
            ddlProfileName.Focus();
            return;
        }
        else if (ddlSystemName.SelectedIndex == 0)
        {
            ErrorMsg.Visible = true;
            ErrorMsg.InnerText = "System name is required";
            ErrorMsg.Attributes.Add("class", "alertMsg failed");
            ddlSystemName.Focus();
            return;
        }
        int Ind = 2;
        int OrgCode = Convert.ToInt32(Session["OrgCode"].ToString());
        int CityCode = Convert.ToInt32(Session["CityCode"].ToString());
        int EntryUserCode = Convert.ToInt32(Session["UserCode"].ToString());
        int SystemCode = Convert.ToInt32(ddlSystemName.SelectedValue);
        StringBuilder sb = new StringBuilder();

        sb.Append("Ind=" + Ind);
        sb.Append("&OrgCode=" + OrgCode);
        sb.Append("&CityCode=" + CityCode);
        sb.Append("&EntryUserCode=" + EntryUserCode);
        sb.Append("&SystemCode=" + SystemCode);

        string uri = "CtrlUserProfile/GetMenuData/";
        resp = new Response();

        resp = GetDataAPICallingRequest(uri, sb);
        if (resp.Code == 100)
        {
            MainMenuList = new List<MainMenu>();
            MainMenuList = JsonConvert.DeserializeObject<List<MainMenu>>(resp.data);
            if (MainMenuList.Count > 0)
            {
                gvMainMenu.DataSource = MainMenuList.ToList();
                gvMainMenu.DataBind();
                pnlDetailSection.Visible = true;
            }
        }
        else
        {
            ErrorMsg.Visible = true;
            ErrorMsg.InnerText = resp.msg;
            ErrorMsg.Attributes.Add("class", "alertMsg failed");
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        if (gvMainMenu.Rows.Count > 0)
        {
            sb.Append("<div class='sidebar-inner'>");
            sb.Append("<ul class='sidenav'>");
            foreach (GridViewRow rMain in gvMainMenu.Rows)
            {
                CheckBox chkMain = (CheckBox)rMain.FindControl("chkMainMenu");
                HiddenField hfMenuCode = (HiddenField)rMain.FindControl("hfMenuCode");
                HiddenField hfLinkUrl = (HiddenField)rMain.FindControl("hfLinkUrl");
                if (chkMain.Checked == true)
                {
                    if (hfLinkUrl.Value != "#")
                    {
                        string Path = hfLinkUrl.Value;
                        sb.Append("<li>");
                        sb.Append("<a runat='server' href='" + Path + "' data-toggle='collapse' data-target='#" + chkMain.Text + "Profile'  class='collapsed  child-1'><span class='text-sidenav'>" + chkMain.Text + "</span></a></li>");
                    }
                    else
                    {
                        sb.Append("<li>");
                        sb.Append("<a runat='server' href='#' data-toggle='collapse' data-target='#" + chkMain.Text + "Profile'  class='collapsed  child-1'><span class='text-sidenav'>" + chkMain.Text + "</span></a>");
                        sb.Append("<ul class='sidenav collapse' id='" + chkMain.Text + "Profile'>");
                    }

                    GridView gvSubMenuL1 = (GridView)rMain.FindControl("gvSubMenuL1");
                    if (gvSubMenuL1.Rows.Count > 0)
                    {
                        foreach (GridViewRow rSubMenu in gvSubMenuL1.Rows)
                        {
                            CheckBox chkSubMenuL1 = (CheckBox)rSubMenu.FindControl("chkSubMenuL1");
                            HiddenField hfSubMenuL1Code = (HiddenField)rSubMenu.FindControl("hfSubMenuL1Code");
                            HiddenField hfSubMenuL1LinkUrl = (HiddenField)rSubMenu.FindControl("hfSubMenuL1LinkUrl");
                            if (chkSubMenuL1.Checked == true)
                            {
                                if (hfSubMenuL1LinkUrl.Value != "#")
                                {
                                    string Path = hfSubMenuL1LinkUrl.Value;//string Path = "\""+ hfSubMenuL1LinkUrl.Value + "\"";
                                    sb.Append("<li><a runat='server' href='" + Path + "'><span class='text-sidenav'>" + chkSubMenuL1.Text + "</span></a></li>");
                                }
                                else
                                {
                                    sb.Append("<li>");
                                    sb.Append("<a runat='server' href='#' data-toggle='collapse' data-target='#" + chkSubMenuL1.Text + "Profile2' class='collapsed  child-1'><span class='text-sidenav'>" + chkSubMenuL1.Text + "</span></a>");
                                    sb.Append("<ul class='sidenav collapse' id='" + chkSubMenuL1.Text + "Profile2'>");
                                }

                                GridView gvSubMenuL2 = (GridView)rSubMenu.FindControl("gvSubMenuL2");
                                if (gvSubMenuL2.Rows.Count > 0)
                                {

                                    foreach (GridViewRow rSubSubMenu in gvSubMenuL2.Rows)
                                    {
                                        CheckBox chkSubMenuL2 = (CheckBox)rSubSubMenu.FindControl("chkSubMenuL2");
                                        HiddenField hfSubMenuL2Code = (HiddenField)rSubSubMenu.FindControl("hfSubMenuL2Code");
                                        HiddenField hfSubMenuL2LinkUrl = (HiddenField)rSubSubMenu.FindControl("hfSubMenuL2LinkUrl");
                                        if (chkSubMenuL2.Checked == true)
                                        {
                                            if (hfSubMenuL2LinkUrl.Value != "#")
                                            {
                                                string Path = hfSubMenuL2LinkUrl.Value;

                                                sb.Append("<li><a  runat='server' href='" + Path + "'><span class='text-sidenav'>" + chkSubMenuL2.Text + "</span></a></li>");
                                            }

                                            if (hfSubMenuL2LinkUrl.Value == "#")
                                            {
                                                sb.Append("</ul>");
                                                sb.Append("</li>");
                                            }
                                        }

                                    }

                                }
                                if (hfSubMenuL1LinkUrl.Value == "#")
                                {
                                    sb.Append("</ul>");
                                    sb.Append("</li>");
                                }
                            }
                        }
                    }
                    if (hfLinkUrl.Value == "#")
                    {
                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                }
            }
            sb.Append("</ul>");
            sb.Append("</div>");
        }
        if (sb.ToString() != string.Empty)
        {
            ClsMenuPermission objMPer = new ClsMenuPermission();

            objMPer.LevelSysAssignCD = 0;
            objMPer.OrgCode = Convert.ToInt32(Session["OrgCode"].ToString());
            objMPer.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            objMPer.LevelCode = Convert.ToInt32(ddlProfileName.SelectedValue);
            objMPer.SystemCode = Convert.ToInt32(ddlSystemName.SelectedValue);
            objMPer.MenusHtml = sb.ToString();
            objMPer.EntryUserCode = Convert.ToInt32(Session["UserCode"].ToString());
            string uri = "CtrlUserProfile/SaveMenusDesc/";
            resp = new Response();
            resp = SaveData(uri, objMPer);
            if (resp.Code == 100)
            {
                ErrorMsg.Visible = true;
                ErrorMsg.InnerText = resp.msg;
                ErrorMsg.Attributes.Add("class", "alertMsg success");
                ddlProfileName.Focus();
                ClearFilelds();
            }
            else
            {
                ErrorMsg.Visible = true;
                ErrorMsg.InnerText = resp.msg;
                ErrorMsg.Attributes.Add("class", "alertMsg failed");
                ddlProfileName.Focus();
            }
        }


    }

    public Response SaveData(string uri, ClsMenuPermission parameters)
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

    private void ClearFilelds()
    {
        ddlProfileName.SelectedIndex = 0;
        ddlSystemName.SelectedIndex = 0;
        MainMenuList = new List<MainMenu>();
        gvMainMenu.DataSource = MainMenuList;
        pnlDetailSection.Visible = false;

    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFilelds();
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin_Module/Forms/Dashboard.aspx");
    }
}