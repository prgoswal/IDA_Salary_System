using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Legal_MstReport_RptOICCaseCount : System.Web.UI.Page
{
    Hashtable ht = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (txtfromdate.Text != "")
        {
            ht.Add("FromDate", Legal_CLSCommon.DateFormat(txtfromdate.Text));
           // ht.Add("ReportSearchTitle", "Search By From Date . - " + Convert.ToString(txtfromdate.Text));
            ht.Add("ReportSearchTitle", "OIC Name Wise");
        }
        else
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = " दिनांक दर्ज करे ..";
            txtfromdate.Focus();
            return;
        }

        if (txttodate.Text != "")
        {
            ht.Add("ToDate", Legal_CLSCommon.DateFormat(txttodate.Text));
            //ht.Add("ReportSearchTitle", "Search By To Date. - " + Convert.ToString(txttodate.Text));
           //

        }
        else
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = " दिनांक दर्ज करे ..";
            txttodate.Focus();
            return;
        }

        ht.Add("ReportHeadTitle", "INDORE DEVELOPMENT AUTHORITY,INDORE");
        ht.Add("Ind", 1);
        ht.Add("ReportCaseTitle", "Legal Case Report");
        //ht.Add("CityCode", Convert.ToInt32(Session["CityCode"]));
        Session["HT"] = ht;
        Session["Report"] = "RptOICCaseCount";
        Session["ReportName"] = "OIC Case Count";
        Response.Redirect("ReportViewer.aspx?index=27");
    }
    public void ClearData()
    {
        txtfromdate.Text = "";
        txttodate.Text = "";
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}