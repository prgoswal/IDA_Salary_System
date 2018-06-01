using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Rpt_SalaryVoucher : System.Web.UI.Page
{
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

                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlEmpType.DataSource = ds.Tables[3];
                    ddlEmpType.DataTextField = "Desc1";
                    ddlEmpType.DataValueField = "EmpType";
                    ddlEmpType.DataBind();
                    // ddlEmpType.Items.Insert(0, new ListItem("All", "0"));
                }
            }
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

  
    protected void btnpreview_Click(object sender, EventArgs e)
    {       
            Hashtable HT = new Hashtable();
            HT.Add("MonthDesc", ddlEmpType.SelectedItem.Text + " Employee");
            HT.Add("EmpType", ddlEmpType.SelectedValue);
            HT.Add("MOnth", Session["Month"].ToString());
            HT.Add("CityCode", Session["CityCode"].ToString());
            HT.Add("CITYNAME", Session["CorpName"].ToString());
            Session["HT"] = HT;
            Session["Report"] = "RptSalaryVoucher";
            Session["ReportName"] = "Salary Voucher";
            Response.Redirect("ReportViewer.aspx?index=27");
        }
    }
