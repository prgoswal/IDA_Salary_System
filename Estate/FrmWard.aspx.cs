using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_Ward : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ShowAllWard();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_WardnameE.Text = "";
        txt_WardNameH.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_Ward objpl = new PL_Ward();
        objpl.Ind = 1;
        objpl.WardNameE = txt_WardnameE.Text;
        objpl.WardNameH = txt_WardNameH.Text;
        objpl.CityCode = 0;

        DataSet ds = Estate_CLSCommon.CallApiPostDS("Ward/SubmitWard", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Record Inserted Successfully";
                ShowAllWard();
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    private void ShowAllWard()
    {
        PL_Ward objpl = new PL_Ward();
        objpl.Ind = 2;
        DataSet ds = Estate_CLSCommon.CallApiGet("Ward/ShowAllWard?Ind=" + objpl.Ind);
        if(ds!=null && ds.Tables.Count > 0)
        {
            dgv_Ward.DataSource = ds.Tables[0];
            dgv_Ward.DataBind();

        }
        else
        {
            ds = null;
        }
    }
    protected void dgv_Ward_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        PL_Ward objpl = new PL_Ward();
        if (e.CommandName == "DelRecord")
        {
            int wardcode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.WardCode = wardcode;
            DataSet ds = Estate_CLSCommon.CallApiPostDS("Ward/DeleteWard", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                ShowAllWard();
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