using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Net;

public partial class Report_MasterRptShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlReportName.Items.Insert(0, new ListItem("---SELECT---", "0"));
            FillSeletType();
            ddlReportName.ClearSelection();
        }
    }

    public void FillSeletType()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("MasterRptShow/BindSelectReport?Ind=1");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlReportName.DataSource = dt;
                ddlReportName.DataValueField = "RptCode";
                ddlReportName.DataTextField = "RptName";
                ddlReportName.DataBind();
                ddlReportName.Items.Insert(0, new ListItem("---SELECT---", "0"));
            }
        }
        else
        {
            ddlReportName.Items.Clear();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        //if (Session["PreviousPage"] != null)
        //{
        //    Response.Redirect(Session["PreviousPage"].ToString());
        //}
        Hashtable HT = new Hashtable();
        HT.Add("MonthDesc", Session["MonthDesc"].ToString());
        HT.Add("CITYNAME", Session["CorpName"].ToString());
        HT.Add("EMPTYPENAME", "0");
        HT.Add("UserName", Session["UserName"].ToString());
       // HT.Add("MOnth", Session["Month"].ToString());
        Session["ReportName"] = ddlReportName.SelectedItem.Text;
        if (ddlReportName.SelectedValue == "101")
        {
            HT.Add("CityCode", Session["CityCode"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptEarningDeduction";
            Response.Redirect("ReportViewer.aspx?index=18");
        }
        if (ddlReportName.SelectedValue == "102")
        {
            HT.Add("CityCode", Session["CityCode"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptGrade";
            Response.Redirect("ReportViewer.aspx?index=19");
        }
        if (ddlReportName.SelectedValue == "103")
        {
            HT.Add("CityCode", Session["CityCode"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptLeave";
            Response.Redirect("ReportViewer.aspx?index=21");
        }
        if (ddlReportName.SelectedValue == "104")
        {
            HT.Add("CityCode", Session["CityCode"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptMstDesignation";
            Response.Redirect("ReportViewer.aspx?index=17");
        }
        if (ddlReportName.SelectedValue == "105")
        {
            HT.Add("CityCode", Session["CityCode"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptMstLoan";
            Response.Redirect("ReportViewer.aspx?index=22");
        }
        if (ddlReportName.SelectedValue == "106")
        {
            HT.Add("finyr", Session["finyr"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptMstSection";
            Response.Redirect("ReportViewer.aspx?index=22");
        }
        if (ddlReportName.SelectedValue == "107")
        {
            HT.Add("CityCode", Session["CityCode"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptBank";
            Response.Redirect("ReportViewer.aspx?index=16");
        }

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

}