using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FrmCourtType : System.Web.UI.Page
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
        txt_CourtTypeE.Text = "";
        txt_CourtTypeH.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_CourtType objpl = new PL_CourtType();
        if (txt_CourtTypeE.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Court Type English..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        if (txt_CourtTypeH.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Court Type Hindi..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        else
        {


            objpl.Ind = 1;
            objpl.CourtTypeNameE = txt_CourtTypeE.Text;
            objpl.CourtTypeNameH = txt_CourtTypeH.Text;
            if (btnSave.Text == "Update")
            {
                objpl.Ind = 2;
                objpl.CourtTypeCode = Convert.ToInt32(Session["CourtTypeCode"]);
                DataSet ds = Legal_CLSCommon.CallApiPostDS("CourtType/EditCourtType", objpl);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                    {
                        pnlSuccess.InnerHtml = "Edit Successfully Complete.";
                        Session["CourtTypeCode"] = null;
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
                DataSet ds = Legal_CLSCommon.CallApiPostDS("CourtType/SubmitCourtType", objpl);
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
        DataSet ds = Legal_CLSCommon.CallApiGet("CourtType/GetAllCourtType?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            GridCourtType.DataSource = ds.Tables[0];
            GridCourtType.DataBind();
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


    protected void GridCourtType_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        PL_CourtType objpl = new PL_CourtType();
        if (e.CommandName == "DelRecord")
        {
            int CourtTypeCode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.CourtTypeCode = CourtTypeCode;
            DataSet ds = Legal_CLSCommon.CallApiPostDS("CourtType/DeleteCourtType", objpl);
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
            int CourtTypeCode = Convert.ToInt32(GridCourtType.DataKeys[rowindex].Value);
            HiddenField field = GridCourtType.Rows[rowindex].FindControl("lblCourtTypeCode") as HiddenField;
            Label lblCourtTypeE = (Label)GridCourtType.Rows[rowindex].FindControl("lblCourtTypeDescE");
            Label lblCourtTypeH = (Label)GridCourtType.Rows[rowindex].FindControl("lblCourtTypeDescH");
            txt_CourtTypeE.Text = lblCourtTypeE.Text;
            txt_CourtTypeH.Text = lblCourtTypeH.Text;
            Session["CourtTypeCode"] = CourtTypeCode;
            btnSave.Text = "Update";


        }

    }
}