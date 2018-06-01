using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Collections;
using Microsoft.Reporting.WebForms;
using System.Configuration;

public partial class frmPropertyMatser : System.Web.UI.Page
{
    PL_PropertyMaster objpl = new PL_PropertyMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
         
        if(!IsPostBack)
        {
            pnlSuccess.Visible = false;
            lblTplot.Visible = false;
            FillddlScheme();
        }
    }

    public void FillddlScheme()
    {
        try
        {
            objpl = new PL_PropertyMaster();

            objpl.Ind = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiGet("PropertyMaster/FillddlScheme?Ind=" + objpl.Ind);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSchName.DataTextField = "SchNameE";
                    ddlSchName.DataValueField = "SchCode";
                    ddlSchName.DataSource = ds.Tables[0];
                    ddlSchName.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlValidity.DataTextField = "ValidityDesc";
                    ddlValidity.DataValueField = "ValidityCode";
                    ddlValidity.DataSource = ds.Tables[1];
                    ddlValidity.DataBind();
                }
            }
            else
            {
                ddlSchName.DataSource = null;
                ddlSchName.DataBind();
                ddlValidity.DataSource = null;
                ddlValidity.DataBind();
            }
            ddlSchName.Items.Insert(0, new ListItem("------ Select Scheme Name ------", "0"));
        }
        catch (Exception ex)
        {
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }

    public void BindGrid()
    {
        objpl.Ind =Convert.ToInt32(ddlValidity.SelectedValue);//1;
        objpl.SchCode = ddlSchName.SelectedValue == "" ? 0 : Convert.ToInt32(ddlSchName.SelectedValue);
        objpl.IDARefNo = txtIDARefNumber.Text == "" ? 0 : Convert.ToInt32(txtIDARefNumber.Text);

        DataSet ds =Estate_CLSCommon.CallApiGet("PropertyMaster/BindGrid?Ind=" + objpl.Ind + "&SchCode=" + objpl.SchCode + "&IDARefNo=" + objpl.IDARefNo);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["IDARefNo"].ToString() != "")
            {
                GvProMaster.DataSource = ds.Tables[0];
                GvProMaster.DataBind();
                lblTplot.Visible = true;
                lblSchName.Visible = true;
                lblSchName.Text = ds.Tables[0].Rows.Count.ToString();
                pnlfailed.Visible = false;
           }
            
            else
            {
                GvProMaster.DataSource = null;
                GvProMaster.DataBind();
                lblTplot.Visible = false;
                lblSchName.Text = "";
            }
           
        }
        else
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Record Not Found";
            GvProMaster.DataSource = null;
            GvProMaster.DataBind();
            lblTplot.Visible = false;
            lblSchName.Text = "";
        }
    }
    protected void ddlSchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        GvProMaster.DataSource = null;
        GvProMaster.DataBind();
        lblSchName.Visible = false;
       // BindGrid();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblTplot.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#propertyEditModal').modal('show');});", true);
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;

        Label IDARefNo = (Label)GvProMaster.Rows[rowindex].FindControl("lblIDARefNo");
        Label ServiceNo = (Label)GvProMaster.Rows[rowindex].FindControl("lblServiceNo");
        Label PlotNo = (Label)GvProMaster.Rows[rowindex].FindControl("lblPlotNo");
        Label PlotUse = (Label)GvProMaster.Rows[rowindex].FindControl("lblPlotCat");
        //Label PlotCat = (Label)GvProMaster.Rows[rowindex].FindControl("lblPlotCat");
        Label NG = (Label)GvProMaster.Rows[rowindex].FindControl("lblNameGender");
        Label CAddr1 = (Label)GvProMaster.Rows[rowindex].FindControl("lblCAddress1");
       // Label CAddr23 = (Label)GvProMaster.Rows[rowindex].FindControl("lblCAddr23");
        Label EAGM = (Label)GvProMaster.Rows[rowindex].FindControl("lblEAGM");
       // Label NameH = (Label)GvProMaster.Rows[rowindex].FindControl("lblNameH");
      //  Label CAddre1H = (Label)GvProMaster.Rows[rowindex].FindControl("lblCAddre1H");
      //  Label CAddrH23 = (Label)GvProMaster.Rows[rowindex].FindControl("lblCAddrH23");
        Label PlotSize = (Label)GvProMaster.Rows[rowindex].FindControl("lblPlotSize");
        Label PLotRate = (Label)GvProMaster.Rows[rowindex].FindControl("lblPLotRate");
        Label PlotCost = (Label)GvProMaster.Rows[rowindex].FindControl("lblPlotCost");
        Label PlotDate = (Label)GvProMaster.Rows[rowindex].FindControl("lblPlotDate");
        Label DelFlag = (Label)GvProMaster.Rows[rowindex].FindControl("lbldelflag");
        Label CommDate = (Label)GvProMaster.Rows[rowindex].FindControl("lblCommDate");
        Label RegLeaseAmt = (Label)GvProMaster.Rows[rowindex].FindControl("lblRegLease");

        Label InstAmt = (Label)GvProMaster.Rows[rowindex].FindControl("lblInstAmount");
        Label PaidInst = (Label)GvProMaster.Rows[rowindex].FindControl("lblTotNoOfPaidInst");
        Label StartDate = (Label)GvProMaster.Rows[rowindex].FindControl("lblInstStartDate");
        Label LoanAmt = (Label)GvProMaster.Rows[rowindex].FindControl("lblInstLoanBalAmt");
 
        ////ViewState["SerNo"] = ServiceNo;

        txtIDARefNo.Text =IDARefNo.Text;
        txtServiceNo.Text = ServiceNo.Text;
        txtPlotNo.Text = PlotNo.Text;
        txtPlotUse.Text = PlotUse.Text;
       // txtPlotCate.Text = PlotCat.Text;
        txtName.Text = NG.Text;
        txtCAddress1.Text = CAddr1.Text;
      //  txtCAddress2.Text = CAddr23.Text;
        txtEmail.Text = EAGM.Text;
        //txtNameH.Text = NameH.Text;
       // txtNameH.CssClass = "form-control hindi";
       // txtAddH1.Text = CAddre1H.Text;
      //  txtAddH1.CssClass = "form-control hindi";
     //   txtAddH2.Text = CAddrH23.Text;
      //  txtAddH2.CssClass = "form-control hindi";
        txtPlotSize.Text = PlotSize.Text;
        txtPlotRate.Text = PLotRate.Text;
        txtPlotCost.Text = PlotCost.Text;
        txtPlossDate.Text = PlotDate.Text;
        txtDelflag.Text = DelFlag.Text;
        txtCommDate.Text = CommDate.Text;
        txtRegLeaseAmt.Text = RegLeaseAmt.Text;

        string str = null;
        string[] strArr = null;
        str = txtName.Text;
        char[] splitchar = {'-'};
        strArr = str.Split(splitchar);
        txtName.Text = strArr[0].ToString();
        txtGender.Text = strArr[1].ToString();

        str = txtPlotNo.Text;
        char[] splitchar1 = { ',' };
        strArr = str.Split(splitchar1);
        txtPlotNo.Text = strArr[0].ToString();
        txtSecName.Text = strArr[1].ToString();

        str = txtCAddress1.Text;
        strArr = str.Split(splitchar);
       txtCAddress1.Text = strArr[0].ToString();
        txtCAddress2.Text = strArr[1].ToString();
        txtCAddress3.Text = strArr[2].ToString();

        str = txtEmail.Text;
        strArr = str.Split(splitchar);
        txtEmail.Text = strArr[0].ToString();
        txtAadhaaNo.Text = strArr[1].ToString();
        txtGSTNo.Text = strArr[2].ToString();
        txtMobileNo.Text = strArr[3].ToString();

        txtInstAmt.Text = InstAmt.Text;
        txtPaidInst.Text = PaidInst.Text;
        txtInstSdate.Text = StartDate.Text;
        txtLoanAmt.Text = LoanAmt.Text;
       // str = txtAddH1.Text;
       // strArr = str.Split(splitchar);
       // txtAddH1.Text = strArr[0].ToString();
      //  txtAddH2.Text = strArr[1].ToString();
       // txtAddH3.Text = strArr[2].ToString();
       // txtAddH1.CssClass = "form-control hindi";
       // txtAddH2.CssClass = "form-control hindi";
      //  txtAddH3.CssClass = "form-control hindi";

        str = txtPlotUse.Text;
        char[] splitchar2 = { ',' };
        strArr = str.Split(splitchar2);
        txtPlotUse.Text = strArr[0].ToString();
        txtPlotCate.Text = strArr[1].ToString();
    }


    protected void ddlValidity_SelectedIndexChanged(object sender, EventArgs e)
    {
       // BindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void btnLedger_Click(object sender, EventArgs e)
    {
        lblHeader.Text = "Ledger";
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
       
        Label ServiceNo = (Label)GvProMaster.Rows[rowindex].FindControl("lblServiceNo");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#LedgerModal').modal('show');});", true);
        Hashtable HT = new Hashtable();
        HT.Add("Ind", 2);
        HT.Add("ServiceNo", ServiceNo.Text);
        HT.Add("SchCode", 0);
        HT.Add("Header", "INDORE DEVELOPMENT AUTHORITY,INDORE");
        function(HT, "RptLedger");
       
      //  Response.Redirect("~/Report/Frm_ReportViewer.aspx");     
    }

    public void function(Hashtable HT,string ReportName)
    {
        ReportViewer1.ShowCredentialPrompts = true;
        Microsoft.Reporting.WebForms.IReportServerCredentials irsc = new CustomReportCredentials(ConfigurationManager.AppSettings["EstateUserName"].ToString(), ConfigurationManager.AppSettings["EstatePassword"].ToString(), ConfigurationManager.AppSettings["EstateReportServer"].ToString());//"http://prg7/ReportServer");
        ReportViewer1.ServerReport.ReportServerCredentials = irsc;
       // Hashtable HT = new Hashtable();
       // HT = (Hashtable)Session["HT"];
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["EstateReportServer"].ToString());
        ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings["EstateReportProjectName"].ToString() + ReportName;
        if (HT != null)
        {
            ReportParameter[] parm = new ReportParameter[HT.Count];
            int i = 0;
            foreach (DictionaryEntry Dt in HT)
            {
                parm[i] = new ReportParameter(Convert.ToString(Dt.Key), Convert.ToString(Dt.Value));
                i++;
            }
            ReportViewer1.ServerReport.SetParameters(parm);
            ReportViewer1.ServerReport.Refresh();
        }

    }

    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {

            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GvProMaster.DataSource = null;
        GvProMaster.DataBind();
        ddlSchName.ClearSelection();
        ddlValidity.ClearSelection();
        txtIDARefNumber.Text = "";
        lblSchName.Visible = false;
        lblSchName.Visible = false;
        lblTplot.Visible = false;
    }
    protected void GvProMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if(GvProMaster.DataKeys[e.Row.RowIndex].Value.ToString() == "1")
            {
                LinkButton btn = (LinkButton)e.Row.FindControl("btnIns");
                btn.Visible = true;
                LinkButton btnInsledger = (LinkButton)e.Row.FindControl("btnInstLedger");
                btnInsledger.Visible = true;
            }
        }
    }
    protected void btnIns_Click(object sender, EventArgs e)
    {
        lblHeader.Text = "Installment Sheet";
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;

        Label IDaRefNo = (Label)GvProMaster.Rows[rowindex].FindControl("lblIDARefNo");
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#LedgerModal').modal('show');});", true);
        Hashtable HT = new Hashtable();
        HT.Add("Ind", 2);
        HT.Add("IDARefNo", IDaRefNo.Text);
        HT.Add("SchCode", 0);
        HT.Add("Header", "INDORE DEVELOPMENT AUTHORITY,INDORE");
        function(HT, "RptInstChart");
    }

    protected void btnInstLedger_Click(object sender, EventArgs e)
    {
        lblHeader.Text = "Installment Ledger";
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;

        Label IDaRefNo = (Label)GvProMaster.Rows[rowindex].FindControl("lblIDARefNo");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#LedgerModal').modal('show');});", true);
        Hashtable HT = new Hashtable();
        HT.Add("Ind", 2);
        HT.Add("IDARefNo", IDaRefNo.Text);
        HT.Add("SchCode", 0);
        HT.Add("ServiceNo",0);
        HT.Add("Header", "INDORE DEVELOPMENT AUTHORITY,INDORE");
        function(HT, "RptInstallmentLedger");

    }
}