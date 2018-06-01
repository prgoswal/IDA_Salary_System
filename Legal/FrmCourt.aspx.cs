using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FrmCourt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlCourtType();
            ShowAllDevCateCode();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_CourtPlace.Text = "";
        txt_CourtJudgeNm.Text = "";
        txt_CourtNmE.Text = "";
        txt_CourtNmH.Text = "";
        btnSave.Text = "Save";
        ddlCourtType.SelectedIndex = 0;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_Court objpl = new PL_Court();
        if (txt_CourtNmE.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Case Stage English..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        if (txt_CourtNmH.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Case Stage Hindi..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        if (txt_CourtPlace.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Court Place..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        if (txt_CourtJudgeNm.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Court Judge Name..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        else
        {
            objpl.Ind = 1;
            objpl.CourtPlace=txt_CourtPlace.Text ;
            objpl.CourtJudgeNm=txt_CourtJudgeNm.Text;
            objpl.CourtNmE = txt_CourtNmE.Text;
            objpl.CourtNmH = txt_CourtNmH.Text;
            objpl.CourtTypeCode=Convert.ToInt32(ddlCourtType.SelectedValue.ToString());
            if (btnSave.Text == "Update")
            {
                objpl.Ind = 2;
                objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
                objpl.CourtCode = Convert.ToInt32(Session["CourtCode"]);
                DataSet ds = Legal_CLSCommon.CallApiPostDS("Court/EditCourt", objpl);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                    {
                        pnlSuccess.InnerHtml = "Edit Successfully Complete.";
                        Session["CourtCode"] = null;
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
                DataSet ds = Legal_CLSCommon.CallApiPostDS("Court/SubmitCourt", objpl);
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
                        pnlfailed.InnerHtml = "Record Allready Exist!!!";
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
    private void fillddlCourtType() 
    {
        
      int Ind = 6;
      int CityCode = Convert.ToInt32(Session["CityCode"]);
      DataSet ds = Legal_CLSCommon.CallApiGet("Court/ddlCourtType?Ind=" + Ind + "&CityCode=" + CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlCourtType.DataSource = ds.Tables[0];
            ddlCourtType.DataTextField = "CourtTypeNameH";
            ddlCourtType.DataValueField = "CourtTypeCode";
            ddlCourtType.DataBind();
            ddlCourtType.Items.Insert(0, "कोर्ट के प्रकार चुने ");
        }
        else
        {
            ds = null;
        }
    }
    private void ShowAllDevCateCode()
    {
        PL_ReplyMaster objpl = new PL_ReplyMaster();
        objpl.Ind = 5;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("Court/GetAllCourt?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            GridCourt.DataSource = ds.Tables[0];
            GridCourt.DataBind();
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


    protected void GridCourt_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        PL_Court objpl = new PL_Court();
        if (e.CommandName == "DelRecord")
        {
            int CourtCode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.CourtCode = CourtCode;
            DataSet ds = Legal_CLSCommon.CallApiPostDS("Court/DeleteCourt", objpl);
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
            int CourtCode = Convert.ToInt32(GridCourt.DataKeys[rowindex][0].ToString());
            int CourtTypeCode = Convert.ToInt32(GridCourt.DataKeys[rowindex][1].ToString());
            HiddenField field = GridCourt.Rows[rowindex].FindControl("lblCourtCode") as HiddenField;
            Label lblCourtE = (Label)GridCourt.Rows[rowindex].FindControl("lblCourtNmE");
            Label lblCourtH = (Label)GridCourt.Rows[rowindex].FindControl("lblCourtNmH");
            Label lblCourtJudgeNm = (Label)GridCourt.Rows[rowindex].FindControl("lblCourtJudgeNm");
            Label lblCourtPlace = (Label)GridCourt.Rows[rowindex].FindControl("lblCourtPlace");
            Label lblCourtTypeNameE = (Label)GridCourt.Rows[rowindex].FindControl("lblCourtTypeNameE");
            txt_CourtNmE.Text = lblCourtE.Text;
            txt_CourtNmH.Text = lblCourtH.Text;
            txt_CourtJudgeNm.Text = lblCourtJudgeNm.Text;
            txt_CourtPlace.Text = lblCourtPlace.Text;
            ddlCourtType.SelectedValue = CourtTypeCode.ToString();
            Session["CourtCode"] = CourtCode;
            btnSave.Text = "Update";


        }
    }
}