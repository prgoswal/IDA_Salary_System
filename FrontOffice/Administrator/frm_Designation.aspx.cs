using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_frm_Designation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_DesignationNameEng.Text = "";
        txt_DesignationNameHindi.Text = "";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_Designation objpl = new PL_Designation();
        objpl.Ind = 1;
        objpl.DesignDescE = txt_DesignationNameEng.Text;
        objpl.DesignDescH = txt_DesignationNameHindi.Text;

        DataTable dt = FO_CLSCommon.CallApiPost("api/Designation/SubmitDesignation", objpl);

        if (dt != null)
        {
            if (dt.Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Save Successfully.";
                ClearData();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else if (dt.Rows[0]["res"].ToString() == "2")
            {
                pnlfailed.InnerHtml = "Already Exist";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
            else
            {
                pnlfailed.InnerHtml = "Data Failed...";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }

    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    PL_Designation objpl = new PL_Designation();
    //    objpl.Ind = 1;
    //    objpl.DesignDescE = txt_DesignationNameEng.Text;
    //    objpl.DesignDescH = txt_DesignationNameHindi.Text;

    //    DataTable dt = CLSCommon.CallApiPut("api/Designation/UpdateDesignation?designcode=2", objpl);

    //    if (dt != null)
    //    {
    //        if (dt.Rows[0]["res"].ToString() == "1")
    //        {
    //            pnlSuccess.InnerHtml = "Save Successfully.";
    //            ClearData();
    //            pnlSuccess.Visible = true;
    //            pnlfailed.Visible = false;
    //        }
    //        else if (dt.Rows[0]["res"].ToString() == "2")
    //        {
    //            pnlfailed.InnerHtml = "Already Exist";
    //            pnlSuccess.Visible = false;
    //            pnlfailed.Visible = true;
    //        }
    //        else
    //        {
    //            pnlfailed.InnerHtml = "Data Failed...";
    //            pnlSuccess.Visible = false;
    //            pnlfailed.Visible = true;
    //        }
    //    }
    //}
}