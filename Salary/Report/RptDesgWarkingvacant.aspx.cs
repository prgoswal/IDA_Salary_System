using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salary_Report_RptDesgWarkingvacant : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSelectType();
        }
    }

    public void FillSelectType()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FillReportType/FillSelectType?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlClass.DataSource = ds.Tables[2];
                    ddlClass.DataTextField = "ClassDesc";
                    ddlClass.DataValueField = "Classind";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("All", "0"));
                }
            }
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Hashtable HT = new Hashtable();
        HT.Add("MonthDesc", Session["MonthDesc"].ToString());
        HT.Add("CITYNAME", Session["CorpName"].ToString());
        HT.Add("EMPTYPENAME", "");
        HT.Add("UserName", Session["UserName"].ToString());
        HT.Add("CityCode", Session["CityCode"].ToString());
        HT.Add("classind", ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue);
        Session["HT"] = HT;
        Session["Report"] = "RptDesgWarkingvacant";
        Session["ReportName"] = ddlClass.SelectedItem.Text;
        Response.Redirect("ReportViewer.aspx?index=16");
    }
}