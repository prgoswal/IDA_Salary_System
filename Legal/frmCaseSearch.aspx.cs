using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frmCaseSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillInformTypeDDL();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        txtCaseInform.Visible = false;
     
        lblcaseTitle.Visible=false;
        lblSuitRegNo.Visible=false; 
        lblSuitregdate.Visible=false;
        lblcaseNo.Visible=false;
        lblCourtplace.Visible = false;
        
        lblAdvoname.Visible=false;  
        lblOICname.Visible=false;   
        lblfirsthdate.Visible=false; 
        lblOldcaseNo.Visible=false;
        lblCourttype.Visible = false;

        lblSuitdateTo.Visible = false;
        txt_FromsuitDate.Visible = false;
        txt_SuitDateto.Visible = false;
    }

    public void showAllAction()
    {
        if (ddlInformType.SelectedIndex == 1)
        {
            ddl_caseUnvan.Visible = true;
            ddl_courtname.Visible = false;
            ddl_oic.Visible = false;
            ddl_Advo.Visible = false;
            ddl_courttype.Visible = false;
            txtCaseInform.Visible = false;
            txtInformDate.Visible = false;

            lblcaseTitle.Visible = true;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;
        }

        if (ddlInformType.SelectedIndex == 2)
        {
            txtCaseInform.Visible = true;
            ddl_courtname.Visible = false;
            ddl_oic.Visible = false;
            ddl_Advo.Visible = false;
            ddl_courttype.Visible = false;
            ddl_caseUnvan.Visible = false;
            txtInformDate.Visible = false;

            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = true;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 3)
        {
            ddl_courtname.Visible = false;
            ddl_oic.Visible = false;
            ddl_Advo.Visible = false;
            ddl_caseUnvan.Visible = false;
            txtCaseInform.Visible = false;
            ddl_courttype.Visible = false;
            txtInformDate.Visible = true;

            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = true;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }

        if (ddlInformType.SelectedIndex == 4)
        {
            ddl_caseUnvan.Visible = false;
            txtCaseInform.Visible = true;
            txtInformDate.Visible = false;
            ddl_courtname.Visible = false;
            ddl_courttype.Visible = false;
            ddl_oic.Visible = false;
            ddl_Advo.Visible = false;

            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = true;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 5)
        {
            ddl_caseUnvan.Visible = false;
            ddl_courtname.Visible = true;
            ddl_Advo.Visible = false;
            ddl_oic.Visible = false;
            ddl_courttype.Visible = false;
            txtCaseInform.Visible = false;
            txtInformDate.Visible = false;

            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = true;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 6)
        {
            ddl_oic.Visible = false;
            ddl_courtname.Visible = false;
            ddl_Advo.Visible = true;
            ddl_caseUnvan.Visible = false;
            ddl_courttype.Visible = false;

            txtCaseInform.Visible = false;
            txtInformDate.Visible = false;


            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = true;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 7)
        {
            ddl_courtname.Visible = false;
            ddl_Advo.Visible = false;
            ddl_oic.Visible = true;
            ddl_caseUnvan.Visible = false;
            ddl_courttype.Visible = false;
            txtCaseInform.Visible = false;
            txtInformDate.Visible = false;

            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = true;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 8)
        {
            ddl_courtname.Visible = false;
            ddl_caseUnvan.Visible = false;
            ddl_oic.Visible = false;
            ddl_Advo.Visible = false;
            ddl_courttype.Visible = false;
            txtCaseInform.Visible = false;
            txtInformDate.Visible = true;


            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = true;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 9)
        {
            ddl_courtname.Visible = false;
            ddl_Advo.Visible = false;
            ddl_oic.Visible = false;
            txtCaseInform.Visible = true;
            txtInformDate.Visible = false;
            ddl_caseUnvan.Visible = false;
            ddl_courttype.Visible = false;


            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = true;
            lblCourttype.Visible = false;

        }
        if (ddlInformType.SelectedIndex == 10)
        {
            ddl_caseUnvan.Visible = false;
            ddl_courtname.Visible = false;
            ddl_courttype.Visible = true;
            ddl_Advo.Visible = false;
            ddl_oic.Visible = false;

            txtCaseInform.Visible = false;
            txtInformDate.Visible = false;


            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = true;

        }

        if (ddlInformType.SelectedIndex == 11)
        {
            ddl_caseUnvan.Visible = false;
            ddl_courtname.Visible = false;
            ddl_courttype.Visible = false;
            ddl_Advo.Visible = false;
            ddl_oic.Visible = false;

            txtCaseInform.Visible = false;
            txtInformDate.Visible = false;


            lblcaseTitle.Visible = false;
            lblSuitRegNo.Visible = false;
            lblSuitregdate.Visible = false;
            lblcaseNo.Visible = false;
            lblCourtplace.Visible = false;

            lblAdvoname.Visible = false;
            lblOICname.Visible = false;
            lblfirsthdate.Visible = false;
            lblOldcaseNo.Visible = false;
            lblCourttype.Visible = false;

            //lblSuitdatefrom.Visible = true;
            lblSuitdateTo.Visible = true;
            txt_FromsuitDate.Visible = true;
            txt_SuitDateto.Visible = true;

        }
    }

    public void FillInformTypeDDL()
    {
        PL_CaseSearch objpl = new PL_CaseSearch();
        objpl.Ind = 1;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("CaseSearch/FillAllDDL?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {

            ds.Tables[0].TableName = "MstSearchType";
            
            ddlInformType.DataTextField = "SearchDesc";
            ddlInformType.DataValueField = "SearchTypeId";
            ddlInformType.DataSource = ds.Tables[0];
            ddlInformType.DataBind();
            ddlInformType.Items.Insert(0, "जानकारी के प्रकार चुने");
        }

        else
        {
            ds = null;
        }
    }
    public void FillAllDDL()
    {
        PL_CaseSearch objpl = new PL_CaseSearch();
        objpl.Ind = 1;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("CaseSearch/FillAllDDL?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            ds.Tables[1].TableName = "MstAdvocate";
            ds.Tables[2].TableName = "MstCourt";
            ds.Tables[3].TableName = "MstCaseDetail";
            ds.Tables[4].TableName = "MstOIC";

            ddl_Advo.DataTextField = "AdvocateNmH";
            ddl_Advo.DataValueField = "AdvocateCode";
            ddl_Advo.DataSource = ds.Tables[1];
            ddl_Advo.DataBind();
            ddl_Advo.Items.Insert(0, "अभिभाषक का नाम चुने");

            ddl_courtname.DataTextField = "CourtPlace";
            ddl_courtname.DataValueField = "CourtCode";
            ddl_courtname.DataSource = ds.Tables[2];
            ddl_courtname.DataBind();
            ddl_courtname.Items.Insert(0, "न्यायालय/स्थान का नाम चुने");

            ddl_courttype.DataTextField = "CourtNmH";
            ddl_courttype.DataValueField = "CourtCode";
            ddl_courttype.DataSource = ds.Tables[2];
            ddl_courttype.DataBind();
            ddl_courttype.Items.Insert(0, "न्यायालय का प्रकार चुने");


            ddl_caseUnvan.DataTextField = "CaseDesc";
            ddl_caseUnvan.DataValueField = "CaseNo";
            ddl_caseUnvan.DataSource = ds.Tables[3];
            ddl_caseUnvan.DataBind();
            ddl_caseUnvan.Items.Insert(0, "केस का उन्वान चुने ");

            ddl_oic.DataTextField = "NameH";
            ddl_oic.DataValueField = "EmpNo";
            ddl_oic.DataSource = ds.Tables[4];
            ddl_oic.DataBind();
            ddl_oic.Items.Insert(0, "प्रभारी अधिकारी चुने");
        }

        else
        {
            ds = null;
        }
    }

    protected void ddlInformType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCaseInform.Text = "";
        FillAllDDL();
        showAllAction();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        PL_CaseSearch objpl = new PL_CaseSearch();
        objpl.Ind = 2;
        if (ddlInformType.SelectedValue == "1")
        {
            lblcaseTitle.Visible = true;
            if (ddl_caseUnvan.SelectedIndex != 0)
            {
                objpl.CaseTitle = ddl_caseUnvan.SelectedValue;
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "केस का उन्वान चुने..";
                return;                
            }
        }
        if (ddlInformType.SelectedValue == "2")
        {
            lblSuitRegNo.Visible = true;
            txtCaseInform.Visible = true;
            if (txtCaseInform.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "दावा रजिस्टर क्रमांक दर्ज करे..";
                return;
            }
            else
            {
                objpl.SuitRegNo = txtCaseInform.Text;
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
        }
        if (ddlInformType.SelectedValue == "3")
        {
            lblSuitregdate.Visible = true;
            if (txtInformDate.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "दावा रजिस्टर दिनाँक दर्ज करे..";
                return;
            }
            else
            {
                objpl.SuitRegDate = Legal_CLSCommon.DateFormat(txtInformDate.Text);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
        }
        if (ddlInformType.SelectedValue == "4")
        {
            lblcaseNo.Visible = true;
            txtCaseInform.Visible = true;
            if (txtCaseInform.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "प्रकरण क्रमांक दर्ज करे.. ";
                return;
            }
            else
            {
                objpl.CaseNo = Convert.ToInt32(txtCaseInform.Text);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
        }
        if (ddlInformType.SelectedValue == "5")
        {
            lblCourtplace.Visible = true;
            if (ddl_courtname.SelectedIndex != 0)
            {
                //objpl.CourtCode=Convert.ToInt32( ddl_courtname.SelectedValue);
                objpl.CourtPlace = ddl_courtname.SelectedValue;
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "न्यायालय/स्थान का नाम चुने..";
                return;
            }
        }
        if (ddlInformType.SelectedValue == "6")
        {
            lblAdvoname.Visible = true;
            if (ddl_Advo.SelectedIndex != 0)
            {
                objpl.AdvoName = ddl_Advo.SelectedValue;
                objpl.AdvocateCode = Convert.ToInt32(ddl_Advo.SelectedValue);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "अभिभाषक का नाम चुने..";
                return;
            }
        }
        if (ddlInformType.SelectedValue == "7")
        {
            lblOICname.Visible = true;
            if (ddl_oic.SelectedIndex != 0)
            {
                objpl.OICName = ddl_oic.SelectedValue;
                objpl.EmpNo = Convert.ToInt32(ddl_oic.SelectedValue);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "प्रभारी अधिकारी चुने";
                return;
            }
        }
        if (ddlInformType.SelectedValue == "8")
        {
            lblfirsthdate.Visible = true;
            if (txtInformDate.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "प्रथम पेसि दिनांक दर्ज करे..";
                return;
            }
            else
            {
                objpl.FirstHDate = Legal_CLSCommon.DateFormat(txtInformDate.Text);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
        }
        if (ddlInformType.SelectedValue == "9")
        {
            lblOldcaseNo.Visible = true;
            
            txtCaseInform.Visible = true;
            if (txtCaseInform.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "पुराने केस का नंबर दर्ज करे.. ";
                return;
            }
            else
            {
                objpl.OldCaseNo = Convert.ToInt32(txtCaseInform.Text);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
        }

        if (ddlInformType.SelectedValue == "10")
        {
            lblCourttype.Visible = true;
            if (ddl_courttype.SelectedIndex != 0)
            {
                //objpl.CourtCode=Convert.ToInt32( ddl_courtname.SelectedValue);
                objpl.CourtPlace = ddl_courttype.SelectedValue;
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "न्यायालय का प्रकार चुने..";
                return;
            }
        }

        if (ddlInformType.SelectedValue == "11")
        {
            lblSuitdateTo.Visible = true;
            txt_FromsuitDate.Visible = true;
            txt_SuitDateto.Visible = true;
            if (txt_FromsuitDate.Text != "")
            {
                objpl.fromDate = Legal_CLSCommon.DateFormat(txt_FromsuitDate.Text);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "सूट दिनांक दर्ज करे ..";
                txt_FromsuitDate.Focus();
                return;
            }

            if (txt_SuitDateto.Text != "")
            {

                objpl.ToDate = Legal_CLSCommon.DateFormat(txt_SuitDateto.Text);
                objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "सूट दिनांक दर्ज करे ..";
                txt_SuitDateto.Focus();
                return;
            }
        }
        
            DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseSearch/ShowAlldata", objpl);

            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgv_ShowwAlldata.DataSource = ds.Tables[0];
                    dgv_ShowwAlldata.DataBind();
                }
                else
                {
                    pnlfailed.Visible = true;
                    pnlfailed.InnerHtml = "This Record Not Available!!!";
                    dgv_ShowwAlldata.DataSource = null;
                    dgv_ShowwAlldata.DataBind();
                }
            }
            else
            {
                ds = null;
                pnlfailed.Visible = true;

                pnlfailed.InnerHtml = "This Record Not Available!!!";
            }
        }
    
    public void ClearData()
    {
        txtCaseInform.Text = "";
        txtInformDate.Text = "";
        ddlInformType.SelectedIndex = 0;
        ddl_oic.Items.Clear();
        ddl_caseUnvan.Items.Clear();
        ddl_courtname.Items.Clear();
        ddl_Advo.Items.Clear();
        dgv_ShowwAlldata.DataSource = null;
        dgv_ShowwAlldata.DataBind();

        txtCaseInform.Visible = false;
        ddl_Advo.Visible = false;
        ddl_caseUnvan.Visible = false;
        ddl_courtname.Visible = false;
        ddl_courttype.Visible = false;
        ddl_oic.Visible = false;
        txtInformDate.Visible = false;
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}