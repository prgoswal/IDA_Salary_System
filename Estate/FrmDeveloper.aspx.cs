using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmDeveloper : System.Web.UI.Page
{
    PL_MstDeveloper objpl =null;
    protected void Page_Load(object sender, EventArgs e)
    {
       pnlfailed.Visible = false;
       pnlSuccess.Visible = false;
        if (!IsPostBack)
        {
            fillDevCategory();

        }
    }
    public void fillDevCategory()
    {
        objpl = new PL_MstDeveloper();
        objpl.Ind = 2;
        DataSet ds =Estate_CLSCommon.CallApiGet("MstDeveloper/FillDevCategory?Ind=" + objpl.Ind);
        //   a = objblscheme.spMstScheme(objpl);
        if (ds != null && ds.Tables.Count>0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDevCate.DataSource = ds.Tables[0];
                ddlDevCate.DataValueField = "DevCateCode";
                ddlDevCate.DataTextField = "DevCateDescE";
                ddlDevCate.DataBind();
            }
            if(ds.Tables[1].Rows.Count>0)
            {
                grdDeveloper.DataSource = ds.Tables[1];
                grdDeveloper.DataBind();
            }
            else
            {
                grdDeveloper.DataSource = null;
                grdDeveloper.DataBind();
            }
        }
        else
        {
            ddlDevCate.DataSource = null;           
            ddlDevCate.DataBind();
        }
        ddlDevCate.Items.Insert(0, "Select Developer Category");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {   
        try
        {            
            if (ddlDevCate.SelectedIndex == 0)
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Please Select Developer Category";
                ddlDevCate.Focus();
                return;
            }
            if (txtDevDescE.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Enter Developer Desc English";
                txtDevDescE.Focus();
                return;
            }

            if (txtDevDescH.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Enter Developer Desc Hindi";
                txtDevDescH.Focus();
                return;

            }
            objpl = new PL_MstDeveloper();

            objpl.Ind = 1;
            //objpl.city_id = Convert.ToInt32(Session["CityId"]);
            //objpl.user_id = Convert.ToString(Session["UserId"]);
            objpl.DevCateCode = Convert.ToInt32(ddlDevCate.SelectedValue.ToString());
            objpl.DeveloperDescE = txtDevDescE.Text.Trim();
            objpl.DeveloperDescH = txtDevDescH.Text.Trim();       
            objpl.CityCode = 0;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiPostDS("MstDeveloper/AddDeveloper", objpl);
            //   a = objblscheme.spMstScheme(objpl);
            if (ds != null)
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Inserted Successfully";
                // LblMsg.CssClass = "alertMsg success";
                Clear();
                fillDevCategory();
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Inserted ";
            }


        }
        catch (Exception ex)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }
    public void Clear()
    {
        txtDevDescE.Text = "";
        txtDevDescH.Text = "";
        ddlDevCate.SelectedIndex =0;

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void grdDeveloper_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelRecord")
        {
            int rowind = Convert.ToInt32(e.CommandArgument.ToString());
            objpl = new PL_MstDeveloper();
            objpl.Ind = 3;
            objpl.DeveloperCode = rowind;
            DataSet ds =Estate_CLSCommon.CallApiPostDS("MstDeveloper/DeleteDeveloper", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Deleted Successfully";
                // LblMsg.CssClass = "alertMsg success";
                Clear();
                fillDevCategory();
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Deleted ";
            }
        }
    }
}