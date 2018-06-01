using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmGenerateDemand : System.Web.UI.Page
{
    PL_DemandGeneration objpl = new PL_DemandGeneration();
    static DataSet dsacc = new DataSet();
     int totalsum = 0;
    DataTable DtFinal
    {
        get { return (DataTable)ViewState["DtFinal"]; }
        set { ViewState["DtFinal"] = value; }
    }
    DataTable DtTotalCal
    {
        get { return (DataTable)ViewState["DtTotalCal"]; }
        set { ViewState["DtTotalCal"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddl();
        }


        //pnlSuccess.Visible = false;
        //pnlfailed.Visible = false;
    }
    public void Fillddl()
    {
        DataSet ds = Demand_CLSCommon.CallApiGet("DemandGeneration/Fillddl?Ind=1");
        if (ds != null)
        {
            ddlDemandCategory.DataSource = ds.Tables[0];
            ddlDemandCategory.DataValueField = "Demandcatcode";
            ddlDemandCategory.DataTextField = "DemandcatDesc";
            ddlDemandCategory.DataBind();
            ddlDemandCategory.Items.Insert(0, new ListItem("--Select Demand Category--", "0"));

        }
    }
    public void FillAccountName()
    {
        dsacc = Demand_CLSCommon.CallApiGet("DemandGeneration/FillddlAccountName?Ind=2&DemandCat=" + ddlDemandCategory.SelectedValue + "");
        if (dsacc != null)
        {
            ddlAccountName.DataSource = dsacc.Tables[0];
            ddlAccountName.DataValueField = "AccCode";
            ddlAccountName.DataTextField = "AccName";
            ddlAccountName.DataBind();
            ddlAccountName.Items.Insert(0, new ListItem("--Select AccountName--", "0"));

        }
    }
    public void FillddlDemandFor()
    {
        int RefPartycode = 0;
        if (txtRefPartycode.Text != "")
        {
            RefPartycode = Convert.ToInt32(txtRefPartycode.Text.Trim());
        }
        DataSet ds = Demand_CLSCommon.CallApiGet("DemandGeneration/FillddlDemandFor?Ind=3&Acccode=" + ddlAccountName.SelectedValue + "&RefPartyCode=" + RefPartycode + "");
        if (ds != null)
        {
            ddldemandfor.DataSource = ds.Tables[0];
            ddldemandfor.DataValueField = "SubAccCode";
            ddldemandfor.DataTextField = "SubAccDesc";
            ddldemandfor.DataBind();
            ddldemandfor.Items.Insert(0, new ListItem("--Select Demand For--", "0"));

        }
    }
    protected void ddlDemandCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAccountName();
        FillddlDemandFor();
        txtAccNameHindi.Text = "";
        txtRefPartycode.Text = "";
    }
    protected void ddlAccountName_SelectedIndexChanged(object sender, EventArgs e)
    {
        dsacc.Tables[0].DefaultView.RowFilter = "AccCode = " + ddlAccountName.SelectedValue.ToString() + "";
        DataTable dt = (dsacc.Tables[0].DefaultView).ToTable();
        if (dt.Rows.Count > 0)
        {
            txtAccNameHindi.Text = dt.Rows[0]["AccNameHindi"].ToString();
            txtRefPartycode.Text = dt.Rows[0]["ReffPartycode"].ToString();
            pnltext.Visible = true;
        }
        else
        {
            txtAccNameHindi.Text = "";
            txtRefPartycode.Text = "";
        }
        FillddlDemandFor();
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        TextBox txtRefNo = (TextBox)this.UCDemardSearch.FindControl("txtRefNo");
        TextBox txtServiceNo = (TextBox)this.UCDemardSearch.FindControl("txtServiceNo");
        string ReferenceNo = txtRefNo.Text;
        string ServiceNo = txtServiceNo.Text;
        int AccCode = Convert.ToInt32(ddlAccountName.SelectedValue);
        int DemandFor = Convert.ToInt32(ddldemandfor.SelectedValue);
        DataSet ds = Demand_CLSCommon.CallApiGet("DemandGeneration/GetCalculate?Ind=5&RefNo=" + ReferenceNo + "&ServiceNo=" + ServiceNo + "&DemandFor=" + DemandFor + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdCal.DataSource = ds.Tables[0];
            grdCal.DataBind();
            DtTotalCal = grdCal.DataSource as DataTable;
            //DtFinal = grdCal.DataSource as DataTable;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (DtFinal == null)
        {
            DtFinal = DtTotalCal;               //grdCal.DataSource as DataTable;

        }
        else
        {
            DtFinal.Merge(DtTotalCal);
        }
        grdTotalCal.DataSource = DtFinal;
        grdTotalCal.DataBind();
        DtTotalCal = new DataTable();
        grdCal.DataSource = DtTotalCal;
        grdCal.DataBind();
    }
    protected void grdTotalCal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField Acccode = (HiddenField)e.Row.FindControl("hdnacccode");//take lable id
            Label Amt = (Label)e.Row.FindControl("lblAmount");//take lable id
            if (Acccode.Value != "99")
            {
                totalsum = totalsum +int.Parse(Amt.Text);
            }
            else
            {
                totalsum = totalsum -int.Parse(Amt.Text);
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAmt = (Label)e.Row.FindControl("lbltotalAmount");
            lblTotalAmt.Text = totalsum.ToString();
        }
       

    }
}


//double totalSalary = 0;
//    foreach (DataRow dr in ds.Tables[0].Rows)
//    {
//        totalSalary += Convert.ToDouble(dr["Salary"]);
//    }

//    //--- Here 3 is the number of column where you want to show the total.  
//    grdTest.Columns[3].FooterText = totalSalary.ToString();