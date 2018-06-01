using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmSchOtherFacility : System.Web.UI.Page
{
    PL_SchemeOtherFacility objpl = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        if (!IsPostBack)
        {
            ShowSchOtherFacility();

        }
    }
 public void ShowSchOtherFacility()
    {
        DataSet ds =Estate_CLSCommon.CallApiGet("SchemeOtherFacility/ShowSchemeOtherFacility?Ind=2"); 
        if (ds != null && ds.Tables.Count>0)
        {

            grdSchOtherFacility.DataSource = ds.Tables[0];
            grdSchOtherFacility.DataBind();
            Clear();
        }
        else
        {
            grdSchOtherFacility.DataSource =null;
            grdSchOtherFacility.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
           
            if (txtSchOthFacEnglish.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Scheme Other Facility Area English";
                txtSchOthFacEnglish.Focus();
                return;
            }

            if (txtSchOthFacHindi.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Scheme Other Facility Area Hindi";
                txtSchOthFacHindi.Focus();
                return;

            }
            objpl = new PL_SchemeOtherFacility();

            objpl.Ind = 1;
            //objpl.city_id = Convert.ToInt32(Session["CityId"]);
            //objpl.user_id = Convert.ToString(Session["UserId"]);
           
            objpl.OtherfacilityDescE= txtSchOthFacEnglish.Text.Trim();
            objpl.OtherfacilityDescH= txtSchOthFacHindi.Text.Trim();  
            DataSet ds =Estate_CLSCommon.CallApiPostDS("SchemeOtherFacility/AddSchemeOtherFacility", objpl);
            //   a = objblscheme.spMstScheme(objpl);
            if (ds != null)
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Inserted Successfully";
                // LblMsg.CssClass = "alertMsg success";
                Clear();
                ShowSchOtherFacility();
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
        txtSchOthFacEnglish.Text = "";
        txtSchOthFacHindi.Text = "";
        

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void grdSchOtherFacility_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DelRecord")
        {
            int rowind = Convert.ToInt32(e.CommandArgument.ToString());
            objpl = new PL_SchemeOtherFacility();
            objpl.Ind = 3;
            objpl.OtherfacilityInd = rowind;
            DataSet ds =Estate_CLSCommon.CallApiPostDS("SchemeOtherFacility/DeleteSchemeOtherFacility", objpl);
            if (ds != null && ds.Tables.Count>0)
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Deleted Successfully";
                // LblMsg.CssClass = "alertMsg success";
                Clear();
                ShowSchOtherFacility();
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Deleted ";
            }
        }
    }
}