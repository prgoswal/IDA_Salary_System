using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class CaseProgressEntry : System.Web.UI.Page
{
     DataSet ds = new DataSet();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddl();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
       
    }
    PL_CaseProgressEnrty objpl = null;
    public void Fillddl()
    {
        objpl = new PL_CaseProgressEnrty();
        objpl.Ind = 1;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = new DataSet();
        ds = Legal_CLSCommon.CallApiGet("CaseProgressEnrty/FillDDlCaseProgress?ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlCaseStage.DataSource = ds.Tables[1];
            ddlCaseStage.DataTextField = "CaseStageDescH";
            ddlCaseStage.DataValueField = "CaseStageCode";
            ddlCaseStage.DataBind();
            ddlCaseStage.Items.Insert(0, "चुने ");

            ddlAdvoName.DataSource = ds.Tables[2];
            ddlAdvoName.DataTextField = "AdvocateNmH";
            ddlAdvoName.DataValueField = "AdvocateCode";
            ddlAdvoName.DataBind();
            ddlAdvoName.Items.Insert(0, "अभिभाषक का नाम चुने ");

            ddlOICOfficer.DataSource = ds.Tables[3];
            ddlOICOfficer.DataTextField = "NameH";
            ddlOICOfficer.DataValueField = "EmpNo";
            ddlOICOfficer.DataBind();
            ddlOICOfficer.Items.Insert(0, "चुने ");
        }
    }
    public void searchClear()
    {
        txtCaseNo.Text = "";
        txtSuitRegDate.Text = "";
        txtSuitNo.Text = "";
        txtCaseNo.Enabled = true;
        txtSuitRegDate.Enabled = true;
        txtSuitNo.Enabled = true;
        txtCourtPlace.Text = "";
        txtCaseTital.Text = "";
        txtNextHdate.Text = "";
        ddlCaseStage.SelectedIndex = 0;
    }
   
    public void SearchData()
    {
        objpl = new PL_CaseProgressEnrty();
        objpl.Ind = 2;
        objpl.SuitRegDate = Legal_CLSCommon.DateFormat(txtSuitRegDate.Text.Trim());
        objpl.SuitRegNo = txtSuitNo.Text.Trim();
        objpl.CaseNo = Convert.ToInt32(txtCaseNo.Text.Trim());
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        ds = Legal_CLSCommon.CallApiGet("CaseProgressEnrty/SearchCaseProgress?ind=" + objpl.Ind + "&CaseNo=" + objpl.CaseNo + "&SuitRegNo=" + objpl.SuitRegNo + "&SuitRegDate=" + objpl.SuitRegDate+"&CityCode="+objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCaseTital.Text = (ds.Tables[0].Rows[0]["CaseTitle"]).ToString();
                txtCourtPlace.Text = (ds.Tables[0].Rows[0]["CourtNmH"]).ToString();
                txtLastNHDate.Text = (ds.Tables[0].Rows[0]["NextHDate"]).ToString();
                txtHDesc.Text = (ds.Tables[0].Rows[0]["CaseDesc"]).ToString();
                txtlastdate.Text = (ds.Tables[0].Rows[0]["LastDate"]).ToString();
            }
            else
            {
                pnlSuccess.Visible = false;              
                pnlfailed.InnerHtml = "This Record Not Found..Please try Another Record!!";
                pnlfailed.Visible = true;                
            }
        }
    }
    public void UpdateAllRecord()
    {
        PL_CaseProgressEnrty objpl = new PL_CaseProgressEnrty();
        objpl.Ind = 3;
        objpl.CaseDesc = txtHDesc.Text;
        objpl.AdvoName = ddlAdvoName.SelectedItem.Text;
        objpl.LetterDate = Legal_CLSCommon.DateFormat(txtAppointDate.Text);
        objpl.CaseNo =Convert.ToInt32( txtCaseNo.Text);       
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        objpl.OrgCode = Convert.ToInt32(Session["OrgCode"]);
        objpl.OICName=ddlOICOfficer.SelectedItem.Text;
        objpl.LetterNo=Convert.ToInt32( txtChargeAppointNo.Text);    
        objpl.NextHDate = Legal_CLSCommon.DateFormat(txtNextHdate.Text);
        objpl.CaseStageCode = Convert.ToInt32(ddlCaseStage.SelectedValue);
      
        objpl.SuitNo = txtSuitNo.Text;
        objpl.SuitDate = Legal_CLSCommon.DateFormat(txtSuitRegDate.Text);
        objpl.EntryUserCode = Convert.ToInt32(Session["UserCode"]);

        objpl.LastDate = Legal_CLSCommon.DateFormat(txtlastdate.Text);

        ds = Legal_CLSCommon.CallApiPostDS("CaseProgressEnrty/SaveAndUpdAllProgressEntry", objpl);
        if(ds!=null && ds.Tables.Count > 0)
        {
            if(ds.Tables[0].Rows[0]["res"].ToString()=="1")
            {
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
                pnlSuccess.InnerHtml = "Record Successfully Updated!!!";
                searchClear();
                btnupdate.Visible = true;
            }
            else
            {
                pnlSuccess.InnerHtml = "Updation failed.. Please try Again Another record..";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        SearchData();
        btnupdate.Visible = true;
    }
   
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        UpdateAllRecord();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        searchClear();
    }  
}
