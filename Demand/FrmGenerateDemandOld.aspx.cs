using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demand_FrmGenerateDemandOld : System.Web.UI.Page
{
    PL_DemandGeneration objpl = new PL_DemandGeneration();
   static DataSet dsacc = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Fillddl();
        }
        pnlSuccess.Visible = false;
        pnlfailed.Visible = false;

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
        if(txtRefPartycode.Text!="")
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
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

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
        if(dt.Rows.Count>0)
        { 
        txtAccNameHindi.Text = dt.Rows[0]["AccNameHindi"].ToString();
        txtRefPartycode.Text = dt.Rows[0]["ReffPartycode"].ToString();
        }
        else
        {
            txtAccNameHindi.Text = "";
            txtRefPartycode.Text = "";
        }
        FillddlDemandFor();
    }
    
   

    
}