﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Legal_CLSCommon.CommonCheckSession();
        Page.Header.DataBind();
        logo.DataBind();
        sideBar.DataBind();
        lblUserName.Text = "User Name :- " + Session["UserName"].ToString();
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
