﻿using Microsoft.Reporting.WebForms;
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

public partial class MstReport_RptMstCourtType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Hashtable HT = new Hashtable();
            HT.Add("Ind", 2);
            HT.Add("CityCode", Convert.ToInt32(Session["CityCode"]));
            HT.Add("ReportCaseTitle", "Legal Case Report");
            HT.Add("ReportHeadTitle", "INDORE DEVELOPMENT AUTHORITY,INDORE");
            HT.Add("ReportSearchTitle", "Court Type Master Report");
            Session["HT"] = HT;
            Session["format"] = "Pdf";
            //  Session["FileName"] = "RptMstCourt";
            Session["Report"] = "RptMstCourtType";
            Session["ReportName"] = "court Type Master";
            Response.Redirect("ReportViewer.aspx?index=27");

        }
    }


}