using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Legal_MstReport_ReportViewer : System.Web.UI.Page
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
            reportcall();
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
        FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Legal/TempFiles/output" + Session["UserCode"].ToString() + ".pdf"),
        FileMode.Create);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
        string StrPath = "~/Legal/TempFiles/output" + Session["UserCode"].ToString() + ".pdf";
        frmPrint.Attributes["src"] = StrPath;
    }
    public void reportcall()
    {
        Session["PreviousPage"] = Request.UrlReferrer;
        val = Convert.ToString(Request.QueryString["index"]);

        if (Convert.ToString(Session["Report"]).Trim() == "")
        {
            Response.Write("Report Name Not Exist");
            return;
        }
        ReportViewer1.ShowCredentialPrompts = true;
        Microsoft.Reporting.WebForms.IReportServerCredentials irsc = new CustomReportCredentials(ConfigurationManager.AppSettings["LegalUserName"].ToString(), ConfigurationManager.AppSettings["LegalPassword"].ToString(), ConfigurationManager.AppSettings["LegalReportServer"].ToString()); /*//"http://occweb02/ReportServer");*/
        ReportViewer1.ServerReport.ReportServerCredentials = irsc;
        Hashtable HT = new Hashtable();
        HT = (Hashtable)Session["HT"];
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["LegalReportServer"].ToString());
        ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings["LegalReportProjectName"].ToString() + Session["Report"].ToString();
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

    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        // From: http://community.discountasp.net/default.aspx?f=14&m=15967
        // local variable for network credential.
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
                return null;  // not use ImpersonationUser
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {    // use NetworkCredentials
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            // not use FormsCredentials unless you have implements a custom autentication.
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}