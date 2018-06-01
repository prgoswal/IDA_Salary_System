using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_Zone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ShowAllZone();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_ZonenameH.Text = "";
        txt_ZonenameE.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_Zone objpl = new PL_Zone();
        objpl.Ind = 1;
        objpl.ZoneNameE = txt_ZonenameE.Text;
        objpl.ZoneNameH = txt_ZonenameH.Text;
        objpl.CityCode = 0;

        DataSet ds = Estate_CLSCommon.CallApiPostDS("Zone/SubmitZone", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Save Successfully.";
                ShowAllZone();
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
    private void ShowAllZone()
    {
          PL_Zone objpl = new PL_Zone();
          objpl.Ind = 2;
          DataSet ds = Estate_CLSCommon.CallApiGet("Zone/ShowAllZone?Ind=" + objpl.Ind);
         if(ds!=null && ds.Tables.Count > 0)
         {
             gv_Zone.DataSource = ds.Tables[0];
             gv_Zone.DataBind();
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
    
    protected void gv_Zone_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        PL_Zone objpl = new PL_Zone();
        if (e.CommandName == "DelRecord")
        {
            int Zonecode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.ZoneCode = Zonecode;
            DataSet ds = Estate_CLSCommon.CallApiPostDS("Zone/DeleteZone", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
               
                //ClearData();
                ShowAllZone();
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