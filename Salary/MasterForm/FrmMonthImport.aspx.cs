using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterForm_FrmMonthImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";

        PL_MonthImport obj = new PL_MonthImport();
        obj.Ind = 1;
        obj.CityCode = Convert.ToInt32(Session["CityCode"]);
        obj.month = Session["Month"].ToString();
        obj.Monthcd = Convert.ToInt32(Session["MonthCd"]);
        string uri = string.Format("MonthImport/Importdata");
        DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, obj);
        string ErrorMsg = dt.Rows[0][0].ToString();
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                if (ErrorMsg == "1")
                {
                    ShowMessage("Data Imported Sucessfully.", true);
                    Response.Redirect("~/frmSystem.aspx");
                    return;
                }
                if (ErrorMsg == "2")
                {
                    ShowMessage("Allready Imported for Current Month.", true);
                    //Response.Redirect("../Default.aspx");
                    return;
                }
                if (ErrorMsg == "3")
                {
                    ShowMessage("First Generate Account Controls.", true);
                    return;
                }

                if (ErrorMsg == "4")
                {
                    ShowMessage("First Generate PF Statement", true);
                    return;
                }

            }
            else
            {
            }
        }
    }
    //protected void btnclear_Click(object sender, EventArgs e)
    //{
    //    lblMsg.Text = "";
    //    lblMsg.CssClass = "";
    //}
}