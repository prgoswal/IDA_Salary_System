using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FrmCaseStage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            ShowAllDevCateCode();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_CaseStageE.Text = "";
        txt_CaseStageH.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_CaseStage objpl = new PL_CaseStage();
        if (txt_CaseStageE.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Case Stage English..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        if (txt_CaseStageH.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Case Stage Hindi..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        else
        {
            objpl.Ind = 1;
            objpl.CaseStageDescE= txt_CaseStageE.Text;
            objpl.CaseStageDescH = txt_CaseStageH.Text;
            if (btnSave.Text == "Update")
            {
                objpl.Ind = 2;
                objpl.CaseStageCode = Convert.ToInt32(Session["CaseStageCode"]);
                objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
                DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseStage/EditCaseStage", objpl);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                    {
                        pnlSuccess.InnerHtml = "Edit Successfully Complete.";
                        Session["CaseStageCode"] = null;
                        ClearData();
                        btnSave.Text = "Save";
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
            else
            {
                objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
                objpl.EntryUserCode = Convert.ToInt32(Session["UserCode"]);
                objpl.OrgCode = Convert.ToInt32(Session["OrgCode"]);
                DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseStage/SubmitCaseStage", objpl);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                    {
                        pnlSuccess.InnerHtml = "Save Successfully.";
                        ClearData();
                        ShowAllDevCateCode();
                        pnlSuccess.Visible = true;
                        pnlfailed.Visible = false;
                    }
                    else if (ds.Tables[0].Rows[0]["res"].ToString() == "2")
                    {
                        pnlfailed.InnerHtml = "Allready Exist.";
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
        }
    }
    private void ShowAllDevCateCode()
    {
        PL_ReplyMaster objpl = new PL_ReplyMaster();
        objpl.Ind = 5;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("CaseStage/GetAllCaseStage?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            GridCaseStage.DataSource = ds.Tables[0];
            GridCaseStage.DataBind();
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


    protected void GridCaseStage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        PL_CaseStage objpl = new PL_CaseStage();
        if (e.CommandName == "DelRecord")
        {
            int CaseStageCode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.CaseStageCode = CaseStageCode;
            DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseStage/DeleteCaseStage", objpl);
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

        else if (e.CommandName == "EditRecord")
        {

            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            int CaseStageCode = Convert.ToInt32(GridCaseStage.DataKeys[rowindex].Value);
            HiddenField field = GridCaseStage.Rows[rowindex].FindControl("lblCaseStageCode") as HiddenField;
            Label lblCaseStageE = (Label)GridCaseStage.Rows[rowindex].FindControl("lblCaseStageDescE");
            Label lblCaseStageH = (Label)GridCaseStage.Rows[rowindex].FindControl("lblCaseStageDescH");
            txt_CaseStageE.Text = lblCaseStageE.Text;
            txt_CaseStageH.Text = lblCaseStageH.Text;
            Session["CaseStageCode"] = CaseStageCode;
            btnSave.Text = "Update";


        }
    }
}