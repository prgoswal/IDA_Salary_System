using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmAdvocateMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ShowAdvocateMaster();
        }
        btnupdate.Visible = false;
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    public void ClearData()
    {
        txt_AdvonmE.Text = "";
        txt_AdvonmH.Text = "";
        txt_AdvoAddress.Text = "";
        txt_AddvoQualif.Text = "";
        txt_Advopanel.Text = "";
        txt_Appointmentdate.Text = "";
        txt_telephone.Text = "";
        chk_Active.Checked = false;
    }
    public void ShowAdvocateMaster()
    {
        PL_AdvocateMaster objpl = new PL_AdvocateMaster();
        objpl.Ind = 3;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("AdvocateMaster/ShowAdvocateMaster?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            gv_Advocatemaster.DataSource = ds.Tables[0];
            gv_Advocatemaster.DataBind();

            if (ds !=null && ds.Tables.Count > 1)          // fill Court type dropdown 
            {
                ddl_Courttype.DataSource = ds.Tables[1];
                ddl_Courttype.DataValueField = "CourtTypeCode";
                ddl_Courttype.DataTextField = "CourtTypeNameH";
                ddl_Courttype.DataBind();
                ddl_Courttype.Items.Insert(0, new ListItem("--कोर्ट के प्रकार चुने --", "0"));
            }
            else
            {
                ds = null;
            }                  // 

        }
        
        else
        {
            ds = null;
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        PL_AdvocateMaster objpl = new PL_AdvocateMaster();
        objpl.Ind = 2;
        objpl.AdvocateNmE = txt_AdvonmE.Text;
        objpl.AdvocateNmH = txt_AdvonmH.Text;
        objpl.AdvoAddress = txt_AdvoAddress.Text;
        objpl.AdvoQualification = txt_AddvoQualif.Text;
        objpl.AdvoPanel = txt_Advopanel.Text;
        objpl.TelNo = txt_telephone.Text;
        objpl.AdvocateTypeId = Convert.ToInt32(ddl_Courttype.SelectedValue.ToString());
        objpl.AppointmentDt = Convert.ToDateTime(txt_Appointmentdate.Text).ToString();
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);

        objpl.AdvocateCode = Convert.ToInt32(Session["AdvocateCode"].ToString());
        DataSet ds = Legal_CLSCommon.CallApiPostDS("AdvocateMaster/UpdateAdvocateMaster", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Update Successfully.";
                btnupdate.Visible = false;
                btnSave.Visible = true;

                ShowAdvocateMaster();
                ClearData();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else
            {
                pnlfailed.InnerHtml = "Updation Failed..Please try Again!!";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_AdvocateMaster objpl = new PL_AdvocateMaster();
        objpl.Ind = 1;
        objpl.AdvocateNmE = txt_AdvonmE.Text;
        objpl.AdvocateNmH = txt_AdvonmH.Text;
        objpl.AdvoAddress = txt_AdvoAddress.Text;
        objpl.AdvoQualification = txt_AddvoQualif.Text;
        objpl.AdvoPanel = txt_Advopanel.Text;
        objpl.TelNo = txt_telephone.Text;
        objpl.AppointmentDt = Legal_CLSCommon.DateFormat(txt_Appointmentdate.Text);
        objpl.AdvocateTypeId = Convert.ToInt32(ddl_Courttype.SelectedValue.ToString());
        objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
        objpl.OrgCode = Convert.ToInt32(Session["OrgCode"].ToString());
        objpl.EntryUserCode = Convert.ToInt32(Session["UserCode"].ToString());
        if (chk_Active.Checked == true)
        {
            objpl.ActiveCode = 1;
        }
        else
            objpl.ActiveCode = 0;

        DataSet ds = Legal_CLSCommon.CallApiPostDS("AdvocateMaster/SaveAdvocateMaster", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Save Successfully.";
                ShowAdvocateMaster();
                ClearData();
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        ClearData();
    }
    protected void gv_Advocatemaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            btnupdate.Visible = true;
            btnSave.Visible = false;
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            int advocatecode = Convert.ToInt32(gv_Advocatemaster.DataKeys[rowindex][0]);
            int advocatetypeId = Convert.ToInt32(gv_Advocatemaster.DataKeys[rowindex][1]);
            HiddenField field = gv_Advocatemaster.Rows[rowindex].FindControl("lblAdvocateCode") as HiddenField;
            Label lblAdvocateNameE = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblAdvocateNameE");
            Label lblAdvocateNameH = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblAdvocateNameH");

            Label lblAdvocateAddress = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblAdvocateAddress");
            Label lblQualification = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblQualification");
            Label lblAdvopanel = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblAdvopanel");
            Label lblTelephoneno = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblTelephoneno");
            Label lblAppointmentDt = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblAppointmentDt");
           // Label lblCourtTypeNameE = (Label)gv_Advocatemaster.Rows[rowindex].FindControl("lblCourtTypeNameE");


            txt_AdvonmE.Text = lblAdvocateNameE.Text;
            txt_AdvonmH.Text = lblAdvocateNameH.Text;
            txt_AdvoAddress.Text = lblAdvocateAddress.Text;
            txt_AddvoQualif.Text = lblQualification.Text;
            txt_Advopanel.Text = lblAdvopanel.Text;
            txt_telephone.Text = lblTelephoneno.Text;
            txt_Appointmentdate.Text = lblAppointmentDt.Text;
            ddl_Courttype.SelectedValue = Convert.ToInt32(advocatetypeId).ToString();
            Session["AdvocateCode"] = advocatecode;
        }
    }
}