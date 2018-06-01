using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demand_DemandMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Demand_CLSCommon.CommonCheckSession();
        EntryLevel.Visible = true;
        lblUserName.Text = "User Name :- " + Session["UserName"].ToString();
        if (!IsPostBack)
        {

        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
