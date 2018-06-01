using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmCaseDetailUpdate : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDLCaseDetail();
            FillDDlScheme();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    PL_CaseDetail objpl = null;
    DataSet ds = new DataSet();

    public void FillDDLCaseDetail()        // fill All Dropdown //
    {
        objpl = new PL_CaseDetail();
        objpl.Ind = 5;
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("CaseDetail/FillDDlCaseDetail?ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            ds.Tables[0].TableName = "MstCourt";
            ds.Tables[1].TableName = "MstCourtType";
            ds.Tables[2].TableName = "MstReplyType";
            ds.Tables[3].TableName = "MstCaseStage";
            ds.Tables[4].TableName = "MstCaseType";
            ds.Tables[5].TableName = "MstAdvocate";
            ds.Tables[6].TableName = "MstOrder";
            ds.Tables[7].TableName = "MstOIC";


            ddlCourtPlace.DataSource = ds.Tables[0];
            ddlCourtPlace.DataTextField = "CourtPlace";
            ddlCourtPlace.DataValueField = "CourtCode";
            ddlCourtPlace.DataBind();
            // ddlCourtPlace.Items.Insert(0, "Select Court Place");
            ddlCourtPlace.Items.Insert(0, new ListItem("चुने", "0"));

            ddlCaseType.DataSource = ds.Tables[4];
            ddlCaseType.DataTextField = "CaseTypeNmH";
            ddlCaseType.DataValueField = "CaseTypeCode";
            ddlCaseType.DataBind();
            //ddlCaseType.Items.Insert(0, "Select Case Type");
            ddlCaseType.Items.Insert(0, new ListItem("चुने", "0"));

            ddlAdvoName.DataSource = ds.Tables[5];
            ddlAdvoName.DataTextField = "AdvocateNmH";
            ddlAdvoName.DataValueField = "AdvocateCode";
            ddlAdvoName.DataBind();
            // ddlAdvoName.Items.Insert(0, "Select Name");
            ddlAdvoName.Items.Insert(0, new ListItem("चुने", "0"));


            ddlReplyType.DataSource = ds.Tables[2];
            ddlReplyType.DataTextField = "ReplyTypeDescH";
            ddlReplyType.DataValueField = "ReplyTypeCode";
            ddlReplyType.DataBind();
            // ddlReplyType.Items.Insert(0, "Select Reply Type");
            ddlReplyType.Items.Insert(0, new ListItem("चुने", "0"));


            ddlCaseStage.DataSource = ds.Tables[3];
            ddlCaseStage.DataTextField = "CaseStageDescH";
            ddlCaseStage.DataValueField = "CaseStageCode";
            ddlCaseStage.DataBind();
            ddlCaseStage.Items.Insert(0, new ListItem("चुने", "0"));


            ddlOrderType.DataSource = ds.Tables[6];
            ddlOrderType.DataTextField = "OrderDesc";
            ddlOrderType.DataValueField = "OrderCode";
            ddlOrderType.DataBind();
            ddlOrderType.Items.Insert(0, new ListItem("चुने", "0"));


            ddlOICName.DataSource = ds.Tables[7];
            ddlOICName.DataTextField = "NameH";
            ddlOICName.DataValueField = "EmpNo";
            ddlOICName.DataBind();
            ddlOICName.Items.Insert(0, new ListItem("चुने", "0"));

        }
        else
        {
            ds = null;
        }

    }
    protected void BtnAddSuitName_Click(object sender, EventArgs e)
    {
        if (dtSuit == null || dtSuit.Rows.Count < 1)
        {
            dtSuit = new DataTable();
            dtSuit.Columns.Add("SuitName");
        }
        DataRow dr = dtSuit.NewRow();
        dr["SuitName"] = txtSuitName.Text;
        dtSuit.Rows.Add(dr);
        gridSuitName.DataSource = dtSuit;
        gridSuitName.DataBind();
        txtSuitName.Text = "";
    }
    DataTable dtSuit
    {
        get
        {
            return (DataTable)ViewState["vsSuite"];
        }
        set
        {
            ViewState["vsSuite"] = value;
        }
    }
    DataTable dtParty
    {
        get
        {
            return (DataTable)ViewState["vsParty"];
        }
        set
        {
            ViewState["vsParty"] = value;
        }
    }
    DataTable dtOIC
    {
        get
        {
            return (DataTable)ViewState["vsOIC"];
        }
        set
        {
            ViewState["vsOIC"] = value;
        }
    }
    DataTable dtAdvo
    {
        get
        {
            return (DataTable)ViewState["vsAdvo"];
        }
        set
        {
            ViewState["vsAdvo"] = value;
        }
    }

    protected void gridSuitName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RecordDelete")
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            dtSuit.Rows[rowindex].Delete();
            gridSuitName.DataSource = dtSuit;
            gridSuitName.DataBind();
        }
    }
    protected void BtnPartyAdd_Click(object sender, EventArgs e)
    {
        if ((txtAadharNo.Text).Length != 12)
        {
            pnlfailed.InnerHtml = "Enter Valid Aadhar No.";
            pnlfailed.Visible = true;
            pnlSuccess.Visible = false;
            return;
        }
        if ((txtPartyMobNo.Text).Length != 10)
        {
            pnlfailed.InnerHtml = "Enter Valid Mobile No.";
            pnlfailed.Visible = true;
            pnlSuccess.Visible = false;
            return;
        }
        else
        {

            if (dtParty == null || dtParty.Rows.Count < 1)
            {
                dtParty = new DataTable();
                dtParty.Columns.Add("PartyName");
                dtParty.Columns.Add("PartyAddress");
                dtParty.Columns.Add("PartyMobNo");
                dtParty.Columns.Add("PartyAadharNo");
                dtParty.Columns.Add("PartyPlanName");
                dtParty.Columns.Add("PartyPlanId");
                dtParty.Columns.Add("PartyPlotNo");
                dtParty.Columns.Add("PartyRef");
            }
            DataRow dr = dtParty.NewRow();
            dr["PartyAadharNo"] = txtAadharNo.Text;
            dr["PartyAddress"] = txtPartyAddress.Text;
            dr["PartyMobNo"] = txtPartyMobNo.Text;
            dr["PartyPlotNo"] = txtPlotNo.Text;
            dr["PartyRef"] = txtRefNo.Text;
            dr["PartyName"] = txtPartyName.Text;
            dr["PartyPlanName"] = (ddlSchemeName.SelectedItem).ToString();
            // dr["PartyPlanId"] = (ddlPlanName.SelectedValue).ToString();
            dr["PartyPlanId"] = (ddlSchemeName.SelectedValue).ToString();

            dtParty.Rows.Add(dr);
            GridParty.DataSource = dtParty;
            GridParty.DataBind();
            ClearParty();
        }
    }
    public void ClearParty()
    {
        txtAadharNo.Text = "";
        txtPartyAddress.Text = "";
        txtPartyMobNo.Text = "";
        txtPlotNo.Text = "";
        txtRefNo.Text = "";
        txtPartyName.Text = "";
        ddlSchemeName.SelectedIndex = 0;
    }

    public void ClearOIC()
    {
        txtOICAddress.Text = "";
        txtOICLetterDate.Text = "";
        txtOICLetterNo.Text = "";
        txtOICAddress.Text = "";
        ddlOICName.SelectedIndex = 0;
    }

    public void ClearAdvo()
    {
        txtAdvoAddress.Text = "";
        txtAdvoLetterDate.Text = "";
        txtAdvoLetterNo.Text = "";
        txtAdvoAddress.Text = "";
        ddlAdvoName.SelectedIndex = 0;
    }
    protected void GridParty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RecordDel")
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            dtParty.Rows[rowindex].Delete();
            GridParty.DataSource = dtParty;
            GridParty.DataBind();
        }
    }
    protected void btnOICAdd_Click(object sender, EventArgs e)
    {
        if (dtOIC == null || dtOIC.Rows.Count < 1)
        {
            dtOIC = new DataTable();
            dtOIC.Columns.Add("OICLetterNo");
            dtOIC.Columns.Add("OICLetterDate");
            dtOIC.Columns.Add("OICName");
            dtOIC.Columns.Add("OICAddress");
            dtOIC.Columns.Add("OICNameId");
        }
        DataRow dr = dtOIC.NewRow();
        dr["OICLetterNo"] = txtOICLetterNo.Text;
        dr["OICLetterDate"] = Legal_CLSCommon.DateFormat(txtOICLetterDate.Text);
        dr["OICName"] = ddlOICName.SelectedItem.Text;
        dr["OICAddress"] = txtOICAddress.Text;

         dr["OICNameId"] = (ddlOICName.SelectedValue).ToString();
        //dr["OICNameId"] = 1;

        dtOIC.Rows.Add(dr);
        GridOIC.DataSource = dtOIC;
        GridOIC.DataBind();
        ClearOIC();
    }
    protected void GridOIC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RecordDel")
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            dtOIC.Rows[rowindex].Delete();
            GridOIC.DataSource = dtOIC;
            GridOIC.DataBind();
        }
    }
    protected void btnAdvocateAdd_Click(object sender, EventArgs e)
    {
        if (dtAdvo == null || dtAdvo.Rows.Count < 1)
        {
            dtAdvo = new DataTable();
            dtAdvo.Columns.Add("AdvoLetterNo");
            dtAdvo.Columns.Add("AdvoLetterDate");
            dtAdvo.Columns.Add("AdvoName");
            dtAdvo.Columns.Add("AdvoAddress");
            dtAdvo.Columns.Add("AdvoNameId");
        }
        DataRow dr = dtAdvo.NewRow();
        dr["AdvoLetterNo"] = txtAdvoLetterNo.Text;
        dr["AdvoLetterDate"] = Legal_CLSCommon.DateFormat(txtAdvoLetterDate.Text);
        dr["AdvoName"] = ddlAdvoName.SelectedItem.Text;
        dr["AdvoAddress"] = txtAdvoAddress.Text;
        dr["AdvoNameId"] = ddlAdvoName.SelectedValue.ToString();
        dtAdvo.Rows.Add(dr);
        GridAdvo.DataSource = dtAdvo;
        GridAdvo.DataBind();
        ClearAdvo();
    }
    protected void GridAdvo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RecordDel")
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            dtAdvo.Rows[rowindex].Delete();
            GridAdvo.DataSource = dtAdvo;
            GridAdvo.DataBind();
        }
    }
    public void FillDDlScheme()
    {
        objpl.Ind = 1;
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        ds = Legal_CLSCommon.CallApiGet("CaseDetail/FillDDlScheme?ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlSchemeName.DataTextField = "SchNameH";
            ddlSchemeName.DataValueField = "SchCode";
            ddlSchemeName.DataSource = ds.Tables[0];
            ddlSchemeName.DataBind();
            ddlSchemeName.Items.Insert(0, new ListItem("चुने", "0"));
        }
    }

    public void clear()
    {
        txtNoticeNo.Text = "";
        txtNoticeDate.Text = "";
        txtSuitRegNo.Text = ""; ;
        txtSuitRegDate.Text = "";
        ddlCourtPlace.SelectedIndex = 0;
        txtOldSuitRegNo.Text = "";
        txtOldCaseNo.Text = "";
        txtCaseTitle.Text = "";
        ddlCaseType.SelectedIndex = 0;
        txtcaseDetails.Text = "";
        txtfirsthdate.Text = "";
        txtfinancialburden.Text = "";
        ddlReplyType.SelectedIndex = 0;
        txtreplydate.Text = "";
        ddlCaseStage.SelectedIndex = 0;
        txtnexthdate.Text = "";
        rdblist.SelectedIndex = 0;
        ddlOrderType.SelectedIndex = 0;
        txtOrderDesc.Text = "";
        txtorderdate.Text = "";
        txtlastDecision.Text = "";
        txtRemark.Text = "";
        txtCaseNumber.Text = "";
        gridSuitName.DataSource = null;
        gridSuitName.DataBind();
        GridAdvo.DataSource = null;
        GridAdvo.DataBind();
        GridOIC.DataSource = null;
        GridOIC.DataBind();
        GridParty.DataSource = null;
        GridParty.DataBind();
        dtSuit = null;
        dtParty = null;
        dtOIC = null;
        dtAdvo = null;
        txtSuitRegDate.Enabled = true;
        txtSuitRegNo.Enabled = true;
        ClearAdvo();
        ClearOIC();
        ClearParty();
        txtSuitName.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_CaseDetailUpdate objpl = new PL_CaseDetailUpdate();
        objpl.Ind = 2;
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        objpl.EntryUserCode = Convert.ToInt32(Session["UserCode"]);
        objpl.OrgCode = Convert.ToInt32(Session["OrgCode"]);
        objpl.CaseNo = Convert.ToInt32(txtCaseNumber.Text);
        objpl.NoticeNo = txtNoticeNo.Text;
        objpl.NoticeDate = Legal_CLSCommon.DateFormat(txtNoticeDate.Text);
        objpl.SuitRegNo = txtSuitRegNo.Text;
        objpl.SuitRegDate = Legal_CLSCommon.DateFormat(txtSuitRegDate.Text);
        objpl.CourtCode = Convert.ToInt32(ddlCourtPlace.SelectedValue);
        objpl.OldSuitRegNo = txtOldSuitRegNo.Text;
        objpl.OldCaseNo = Convert.ToInt32(txtOldCaseNo.Text);
        objpl.CaseTitle = txtCaseTitle.Text;
        objpl.CaseTypeCode = Convert.ToInt32(ddlCaseType.SelectedValue);
        objpl.CaseDesc = txtcaseDetails.Text;
        objpl.FirstHDate = Legal_CLSCommon.DateFormat(txtfirsthdate.Text);
        objpl.DeptCode = 1;
        objpl.Amount = Convert.ToInt32(txtfinancialburden.Text);
        objpl.ReplyCode = Convert.ToInt32(ddlReplyType.SelectedValue);
        objpl.ReplyDate = Legal_CLSCommon.DateFormat(txtreplydate.Text);
        objpl.CaseStageCode = Convert.ToInt32(ddlCaseStage.SelectedValue);
        objpl.NextHDate = Legal_CLSCommon.DateFormat(txtnexthdate.Text);
        if (rdblist.SelectedIndex == 0)
        {
            objpl.IsReplyYesNo = 1;
        }
        else
        {
            objpl.IsReplyYesNo = 0;
        }

        objpl.OrderCode = Convert.ToInt32(ddlOrderType.SelectedValue);
        objpl.OrderDesc = txtOrderDesc.Text;
        objpl.OrderDate = Legal_CLSCommon.DateFormat(txtorderdate.Text);
        objpl.LastDesc = txtlastDecision.Text;
        objpl.Remarks = txtRemark.Text;

        if (dtSuit != null && dtSuit.Rows.Count > 0)
        {
            dtSuit.TableName = "dtSuit";
            objpl.ds.Tables.Add(dtSuit);
        }

        if (dtOIC != null && dtOIC.Rows.Count > 0)
        {
            dtOIC.TableName = "dtOIC";
            objpl.ds.Tables.Add(dtOIC);
        }

        if (dtAdvo != null && dtAdvo.Rows.Count > 0)
        {
            dtAdvo.TableName = "dtAdvo";
            objpl.ds.Tables.Add(dtAdvo);
        }
        if (dtParty != null && dtParty.Rows.Count > 0)
        {
            dtParty.TableName = "dtParty";
            objpl.ds.Tables.Add(dtParty);
        }
        DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseDetailUpdate/EditCaseDetailUpdate", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Case Update Successfully Save.";
                clear();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else
            {
                pnlfailed.InnerHtml = "Update Failed..Please try Again!!";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
    protected void btnCaseSearch_Click(object sender, EventArgs e)
    {
        if (txtSuitRegNo.Text.Trim() == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Suit Registration No.";
            pnlSuccess.Visible = false;
            return;
        }
        if (txtSuitRegDate.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Suit Registration Date.";
            pnlSuccess.Visible = false;
            return;
        }
        else
        {
            int ind = 7;
            string SuitRegNo = txtSuitRegNo.Text.Trim();
            string SuitRegDate = Legal_CLSCommon.DateFormat(txtSuitRegDate.Text.Trim());
            int CityCode = Convert.ToInt32(Session["CityCode"]);
            ds = Legal_CLSCommon.CallApiGet("CaseDetailUpdate/GetCaseDetailUpdate?ind=" + ind + "&SuitRegNo=" + SuitRegNo + "&SuitRegDate=" + SuitRegDate + "&CityCode=" + CityCode);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtSuit = ds.Tables[1];
                    dtOIC = ds.Tables[2];
                    dtAdvo = ds.Tables[3];
                    dtParty = ds.Tables[4];

                    txtCaseNumber.Text = ds.Tables[0].Rows[0]["CaseNo"].ToString();

                    txtNoticeNo.Text = ds.Tables[0].Rows[0]["NoticeNo"].ToString();
                    txtNoticeDate.Text = ds.Tables[0].Rows[0]["NoticeDate"].ToString();
                    txtSuitRegNo.Text = ds.Tables[0].Rows[0]["SuitRegNo"].ToString();
                    txtSuitRegDate.Text = ds.Tables[0].Rows[0]["SuitRegDate"].ToString();

                    ddlCourtPlace.SelectedValue = (ds.Tables[0].Rows[0]["CourtCode"].ToString());
                    txtOldSuitRegNo.Text = ds.Tables[0].Rows[0]["OldSuitRegNo"].ToString();
                    txtOldCaseNo.Text = ds.Tables[0].Rows[0]["OldCaseNo"].ToString();
                    txtCaseTitle.Text = ds.Tables[0].Rows[0]["CaseTitle"].ToString();
                    ddlCaseType.SelectedValue = ds.Tables[0].Rows[0]["CaseTypeCode"].ToString();
                    txtcaseDetails.Text = ds.Tables[0].Rows[0]["CaseDesc"].ToString();
                    txtfirsthdate.Text = ds.Tables[0].Rows[0]["FirstHDate"].ToString();
                    // txtNoticeNo.Text = ds.Tables[0].Rows[0]["DeptCode"].ToString();

                    txtfinancialburden.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                    ddlReplyType.SelectedValue = ds.Tables[0].Rows[0]["ReplyCode"].ToString();
                    txtreplydate.Text = ds.Tables[0].Rows[0]["ReplyDate"].ToString();
                    ddlCaseStage.SelectedValue = ds.Tables[0].Rows[0]["CaseStageCode"].ToString();
                    txtnexthdate.Text = ds.Tables[0].Rows[0]["NextHDate"].ToString();
                    if (ds.Tables[0].Rows[0]["IsReplyYesNo"].ToString() == "1")
                        rdblist.SelectedIndex = 0;
                    else
                        rdblist.SelectedIndex = 1;

                    ddlOrderType.SelectedValue = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                    txtOrderDesc.Text = ds.Tables[0].Rows[0]["OrderDesc"].ToString();
                    txtorderdate.Text = ds.Tables[0].Rows[0]["OrderDate"].ToString();
                    txtlastDecision.Text = ds.Tables[0].Rows[0]["LastDesc"].ToString();
                    txtRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    
                    gridSuitName.DataSource = dtSuit;
                    gridSuitName.DataBind();
                    GridOIC.DataSource = dtOIC;
                    GridOIC.DataBind();
                    GridAdvo.DataSource = dtAdvo;
                    GridAdvo.DataBind();
                    GridParty.DataSource = dtParty;
                    GridParty.DataBind();
                    txtSuitRegDate.Enabled = false;
                    txtSuitRegNo.Enabled = false;
                }
                else
                {
                    pnlfailed.Visible = true;
                    pnlfailed.InnerHtml = "This Case Not Found";
                    pnlSuccess.Visible = false;
                    txtSuitRegDate.Enabled = true;
                    txtSuitRegNo.Enabled = true;
                }
            }
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        PL_CaseDetailUpdate objpl = new PL_CaseDetailUpdate();
        objpl.Ind = 2;
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        objpl.EntryUserCode = Convert.ToInt32(Session["UserCode"]);
        objpl.OrgCode = Convert.ToInt32(Session["OrgCode"]);
        objpl.CaseNo = Convert.ToInt32(txtCaseNumber.Text);
        objpl.NoticeNo = txtNoticeNo.Text;
        objpl.NoticeDate = Legal_CLSCommon.DateFormat(txtNoticeDate.Text);
        objpl.SuitRegNo = txtSuitRegNo.Text;
        objpl.SuitRegDate = Legal_CLSCommon.DateFormat(txtSuitRegDate.Text);
        objpl.CourtCode = Convert.ToInt32(ddlCourtPlace.SelectedValue);
        objpl.OldSuitRegNo = txtOldSuitRegNo.Text;
        objpl.OldCaseNo = Convert.ToInt32(txtOldCaseNo.Text);
        objpl.CaseTitle = txtCaseTitle.Text;
        objpl.CaseTypeCode = Convert.ToInt32(ddlCaseType.SelectedValue);
        objpl.CaseDesc = txtcaseDetails.Text;
        objpl.FirstHDate = Legal_CLSCommon.DateFormat(txtfirsthdate.Text);
        objpl.DeptCode = 1;
        objpl.Amount = Convert.ToInt32(txtfinancialburden.Text);
        objpl.ReplyCode = Convert.ToInt32(ddlReplyType.SelectedValue);
        objpl.ReplyDate = Legal_CLSCommon.DateFormat(txtreplydate.Text);
        objpl.CaseStageCode = Convert.ToInt32(ddlCaseStage.SelectedValue);
        objpl.NextHDate = Legal_CLSCommon.DateFormat(txtnexthdate.Text);
        if (rdblist.SelectedIndex == 0)
        {
            objpl.IsReplyYesNo = 1;
        }
        else
        {
            objpl.IsReplyYesNo = 0;
        }

        objpl.OrderCode = Convert.ToInt32(ddlOrderType.SelectedValue);
        objpl.OrderDesc = txtOrderDesc.Text;
        objpl.OrderDate = Legal_CLSCommon.DateFormat(txtorderdate.Text);
        objpl.LastDesc = txtlastDecision.Text;
        objpl.Remarks = txtRemark.Text;

        if (dtSuit != null && dtSuit.Rows.Count > 0)
        {
            dtSuit.TableName = "dtSuit";
            objpl.ds.Tables.Add(dtSuit);
        }

        if (dtOIC != null && dtOIC.Rows.Count > 0)
        {
            dtOIC.TableName = "dtOIC";
            objpl.ds.Tables.Add(dtOIC);
        }

        if (dtAdvo != null && dtAdvo.Rows.Count > 0)
        {
            dtAdvo.TableName = "dtAdvo";
            objpl.ds.Tables.Add(dtAdvo);
        }
        if (dtParty != null && dtParty.Rows.Count > 0)
        {
            dtParty.TableName = "dtParty";
            objpl.ds.Tables.Add(dtParty);
        }
        DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseDetailUpdate/EditCaseDetailUpdate", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Case Update Successfully Save.";
                clear();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else
            {
                pnlfailed.InnerHtml = "Update Failed..Please try Again!!";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }
}