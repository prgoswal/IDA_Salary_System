using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_frm_InwardCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_Inwardcategory objpl = new PL_Inwardcategory();
        objpl.Ind = 1;
        objpl.LetterCateDescE = txt_inwardcategoryeng.Text;
        objpl.LetterCatedescH = txt_InwardcategoryHindi.Text;
        DataTable dt = FO_CLSCommon.CallApiPost("api/Inwardcategory/SubmitInwardcategory", objpl);


        if (dt != null)
        {
            if (dt.Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Save Successfully.";
                ClearData();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else
            {
                pnlfailed.InnerHtml = "Data Failed...";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }
    private void ClearData()
    {
        txt_InwardcategoryHindi.Text = "";
        txt_inwardcategoryeng.Text = "";

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
   
}