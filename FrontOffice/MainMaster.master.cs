using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FO_CLSCommon.CommonCheckSession();
            Page.Header.DataBind();
            Page.Form.FindControl("logo").DataBind();
            Page.Form.FindControl("UcAdmin").DataBind();
       lblUserName.Text = "User Name :- " + Session["UserName"].ToString();
        if(!IsPostBack)
        {

        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
