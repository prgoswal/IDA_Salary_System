using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim().Length == 0)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Enter UserId";
            Page.SetFocus(txtUserName);
            return;
        }
        if (txtPassword.Text.Trim().Length == 0)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Enter Password";
            Page.SetFocus(txtPassword);
            return;
        }
        DataSet ds = Admin_CommonCls.CallApiGet("Login/VerifyLogin?Ind=1&UserName=" + txtUserName.Text.ToString() + "&Password=" + txtPassword.Text.ToString());
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["UserCode"] = ds.Tables[0].Rows[0]["UserCode"].ToString();
                Session["UserCodeOdp"] = ds.Tables[0].Rows[0]["UserCodeOdp"].ToString();                
                Session["UserLevel"] = ds.Tables[0].Rows[0]["UserLevel"].ToString();
                Session["UserEmpCode"] = ds.Tables[0].Rows[0]["UserEmpCode"].ToString();
                Session["OrgCode"] = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                Session["CityCode"] = ds.Tables[0].Rows[0]["CityCodeOther"].ToString();
                Session["OrgName"] = ds.Tables[0].Rows[0]["OrgName"].ToString();
                Session["CityName"] = ds.Tables[0].Rows[0]["CityName"].ToString();
                Session["UserName"] = "IDA";
                //Session["CityCodeOther"] = ds.Tables[0].Rows[0]["CityCode"].ToString();               
                Response.Redirect("~/frmSystem.aspx");

            }
            else
            {
                lblmsg.Text = "Invalid UserName & Password";
                lblmsg.Visible = true;

            }
        }
        else
        {
            lblmsg.Text = "Invalid UserName & Password";
            lblmsg.Visible = true;
        }
    }
}