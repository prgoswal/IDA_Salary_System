using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estate_Report_ReportViewer : System.Web.UI.Page
{
    int ii;
    public string val;
    static string prevPage = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (hfprev.Value == "")
            {
                Session["PreviousPage"] = Request.UrlReferrer;
            }
            else
            {
                hfprev.Value = Request.UrlReferrer.AbsoluteUri;
            }
            pnlPrintDraftPatta.Visible = true;
            //downloadpdf();
            Call();
            lblHeading.InnerText = Session["ReportName"].ToString() + " REPORT";
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect(hfprev.Value);
    }

    void getpdf()
    {
        frmPrint.Attributes.Remove("src");
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;
        byte[] bytes = ReportViewer1.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
        FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Estate/TempFiles/output" + Session["UserCode"].ToString() + ".pdf"),
        FileMode.Create);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
        string StrPath = "~/Estate/TempFiles/output" + Session["UserCode"].ToString() + ".pdf";
        frmPrint.Attributes["src"] = StrPath;
    }

    public void Call()
    {
        if (!IsPostBack)
        {
            Session["PreviousPage"] = Request.UrlReferrer;
            val = Convert.ToString(Request.QueryString["index"]);
            if (Convert.ToString(Session["Report"]).Trim() == "")
            {
                Response.Write("Report Name Not Exist");
                return;
            }
            ReportViewer1.ShowCredentialPrompts = true;
            Microsoft.Reporting.WebForms.IReportServerCredentials irsc = new CustomReportCredentials(ConfigurationManager.AppSettings["EstateUserName"].ToString(), ConfigurationManager.AppSettings["EstatePassword"].ToString(), ConfigurationManager.AppSettings["EstateReportServer"].ToString());
            //  Microsoft.Reporting.WebForms.IReportServerCredentials irsc = new CustomReportCredentials("administrator", "nana181016@", "http://prg7/ReportServer/");
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            Hashtable HT = new Hashtable();
            HT = (Hashtable)Session["HT"];
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["EstateReportServer"].ToString());
            ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings["EstateReportProjectName"].ToString() + Convert.ToString(Session["Report"]);
            if (HT != null)
            {
                ReportParameter[] parm = new ReportParameter[HT.Count];
                int i = 0;
                foreach (DictionaryEntry Dt in HT)
                {
                    parm[i] = new ReportParameter(Convert.ToString(Dt.Key), Convert.ToString(Dt.Value));
                    i++;
                }
                ReportViewer1.ServerReport.SetParameters(parm);
                ReportViewer1.ServerReport.Refresh();
            }
        }
    }


    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        // From: http://community.discountasp.net/default.aspx?f=14&m=15967
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user,
            out string password, out string authority)
        {

            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }

    protected void print_Click(object sender, EventArgs e)
    {
        getpdf();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "$(document).ready(function(){printDocument();});", true);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Report/MasterRptShow.aspx");
        Response.Redirect(hfprev.Value);
    }

}