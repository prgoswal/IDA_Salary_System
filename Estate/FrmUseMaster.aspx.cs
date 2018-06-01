using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmMstUser : System.Web.UI.Page
{
    PL_MstUse objpl = new PL_MstUse();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        if (!IsPostBack)
        {
            ShowUseType();
          
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
      
        try
        {
            
            if (txtSchemeUseE.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                 pnlfailed.InnerHtml = "Insert Scheme Use English";
                txtSchemeUseE.Focus();
                return;
            }

            if (txtSchemeUseH.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Insert Scheme Use Hindi";
                txtSchemeUseH.Focus();
                return;

            }
            if (txtSchemeUseSortName.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Insert Scheme Use Short Name";
                txtSchemeUseSortName.Focus();
                return;
            }

            objpl.Ind = 1;
            //objpl.city_id = Convert.ToInt32(Session["CityId"]);
            //objpl.user_id = Convert.ToString(Session["UserId"]);
            objpl.UseDescE = txtSchemeUseE.Text.Trim();
            objpl.UseDescH = txtSchemeUseH.Text.Trim();
            objpl.UseShortName = txtSchemeUseSortName.Text.Trim();
            objpl.CityCode = 0;




            int a = 0;
            DataSet ds = Estate_CLSCommon.CallApiPostDS("MstUse/AddUseType", objpl);
            //   a = objblscheme.spMstScheme(objpl);
            if (ds != null)
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Scheme Use Type Inserted Successfully";
               // LblMsg.CssClass = "alertMsg success";
                ShowUseType();
                Clear();
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
        txtSchemeUseE.Text = "";
        txtSchemeUseH.Text = "";
        txtSchemeUseSortName.Text = "";

    }
    public void ShowUseType() 
    {
        DataSet ds = Estate_CLSCommon.CallApiGet("MstUse/ShowUseType?Ind=2"); 
        if (ds != null && ds.Tables.Count > 0)
        {

            grdUseType.DataSource = ds.Tables[0];
            grdUseType.DataBind();
            Clear();
        }
        else
        {
            grdUseType.DataSource = null;
            grdUseType.DataBind();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void grdUseType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelRecord")
        {
            int rowind = Convert.ToInt32(e.CommandArgument.ToString());
            objpl = new PL_MstUse();
            objpl.Ind = 3;
            objpl.UseCode = rowind;
            DataSet ds = Estate_CLSCommon.CallApiPostDS("MstUse/DeleteUseType", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Deleted Successfully";
                // LblMsg.CssClass = "alertMsg success";
                Clear();
                ShowUseType();
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Deleted ";
            }
        }
    }
}