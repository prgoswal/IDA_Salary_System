using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_frm_InwardApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_InwardCategory();
        }
    }

    private void Fill_InwardCategory()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/InwardApplication/Fill_InwardCategory?Ind=1");
        if (ds != null)
        {
            chkInward.DataSource = ds.Tables[0];
            chkInward.DataValueField = "LetterCateCode";
            chkInward.DataTextField = "LettercateDescE";
            chkInward.DataBind();
            chkInward.SelectedValue = "1";
            
        }
    }
    protected void btnGO_Click(object sender, EventArgs e)
    {
        if (chkInward.SelectedValue == "1")
        {
            Response.Redirect("~/FrontOffice/Administrator/frm_RegisterComplain.aspx?InwardType=" + chkInward.SelectedValue);
        }
        else
        {
            Response.Redirect("~/FrontOffice/Administrator/frm_InwardApplication.aspx");
           
        }
    }
}