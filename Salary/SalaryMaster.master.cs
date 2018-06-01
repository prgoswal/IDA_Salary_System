using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            lblUserName.Text = "User Name :- " + Session["UserName"].ToString();
            lblMonth.Text = "Month :- " + Session["MonthDesc"].ToString();
            if (Session["MonthCd"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
            else
            {
                GetMonth();
            }
        }
    }

    public void GetMonth()
    {
        DataTable dt = Salary_CLSCommon.CallApiGetdt("Login/FillMonthYear?Ind=4&CityCode=" + Session["CityCode"] + "&MonthCd=" + Session["MonthCd"]);
        if (dt.Rows.Count > 0)
        {
            Session["Month"] = dt.Rows[0]["DMonth"];
            Session["finyr"] = dt.Rows[0]["Fyr"];
            Session["Month1"] = "0";

            if (dt.Rows[0]["Locked"].ToString() == "0")
            {
                HideMenuForOtherMonth.CssClass = "";
            }
            else
            {
                //   HideMenuForOtherMonth.Attributes.Add("class", "disabledbutton");
                HideMenuForOtherMonth.CssClass = "disabledbutton";

            }
        }
    }

    protected void lnlLogOut_Click(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();
        //dt = Salary_CLSCommon.CallApiGetdt("Login/LogOut?Ind=2&UserName=" + Session["LoginId"].ToString() + "&Password=" + Session["LoginPassword"].ToString());
        // if (dt.Rows.Count > 0)
        // {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");


        //}


    }
}
