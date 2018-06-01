using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_DevCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ShowAllDevCateCode();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_DevCatNameH.Text = "";
        txt_DevelopercatnameE.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_DevCategory objpl = new PL_DevCategory();
        objpl.Ind = 1;
        objpl.DevCateDescE = txt_DevelopercatnameE.Text;
        objpl.DevCateDescH = txt_DevCatNameH.Text;
        objpl.CityCode = 0;

        DataSet ds = Estate_CLSCommon.CallApiPostDS("DevCategory/SubmitDevCate", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Record Inserted Successfully";
                ClearData();
                ShowAllDevCateCode();
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
    private void ShowAllDevCateCode()
    {
        PL_DevCategory objpl = new PL_DevCategory();
        objpl.Ind = 2;
        DataSet ds = Estate_CLSCommon.CallApiGet("DevCategory/ShowAllDevCategory?Ind=" + objpl.Ind);
        if(ds!=null && ds.Tables.Count > 0)
        {
            dgv_Devcat.DataSource = ds.Tables[0];
            dgv_Devcat.DataBind();
        }
        else
        {
            ds = null;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void dgv_Devcat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        PL_DevCategory objpl = new PL_DevCategory();
        if (e.CommandName == "DelRecord")
        {
            int devcatecode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.DevCateCode = devcatecode;
            DataSet ds = Estate_CLSCommon.CallApiPostDS("DevCategory/DeleteDevCate", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                ShowAllDevCateCode();
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Deleted Successfully";
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Deleted ";
            }
        }
    }
}