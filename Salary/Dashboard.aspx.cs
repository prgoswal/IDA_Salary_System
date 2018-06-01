using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["MonthCd"] == null)
            //{
            //    HttpContext.Current.Response.Redirect("~/Login.aspx");
            //}
            //GetMonth();
        }

    }

    //public void GetMonth()
    //{
    //    DataTable dt = Salary_CLSCommon.CallApiGetdt("Login/FillMonthYear?Ind=4&CityCode=" + Session["CityCode"] + "&MonthCd=" + Session["MonthCd"]);
    //    if (dt.Rows.Count > 0)
    //    {
    //        Session["Month"] = dt.Rows[0]["DMonth"];
    //        Session["finyr"] = dt.Rows[0]["Fyr"];
    //        Session["Month1"] = "0";


    //    }
    //}
}