using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demand_UserControl_DemandSearch : System.Web.UI.UserControl
{
    PL_DemandGeneration objpl = new PL_DemandGeneration();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddl();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int SearchRefno = 0;
        if (txtSearchRefNo.Text != "")
        {
            SearchRefno = Convert.ToInt32(txtSearchRefNo.Text.Trim());
        }

        DataSet ds = Demand_CLSCommon.CallApiGet("DemandGeneration/GetSearch?Ind=4&RefNo=" + SearchRefno + "&SchCode=" + ddlSearchScheme.SelectedValue + "&PlotNo=" + txtSearchPlotNo.Text.Trim() + " ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtRefNo.Text = ds.Tables[0].Rows[0]["RefNo"].ToString();
            txtServiceNo.Text = ds.Tables[0].Rows[0]["ServiceNo"].ToString();
            txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
            txtPropPlaceHolder.Text = ds.Tables[0].Rows[0]["PlotHolderNameE"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["Schemecode"].ToString();
        }
        else
        {

            lblmsg.Text = "No record Found ";
            txtRefNo.Text = "";
            txtServiceNo.Text = "";
            txtPlotNo.Text = "";
            txtPropPlaceHolder.Text = "";
            txtAddress.Text = "";
            ddlScheme.SelectedValue = "0";

        }
    }

    public void Fillddl()
    {
        DataSet ds = Demand_CLSCommon.CallApiGet("DemandGeneration/Fillddl?Ind=1");
        if (ds != null)
        {
            ddlSearchScheme.DataSource = ds.Tables[1];
            ddlSearchScheme.DataValueField = "SchCode";
            ddlSearchScheme.DataTextField = "SchNameE";
            ddlSearchScheme.DataBind();
            ddlSearchScheme.Items.Insert(0, new ListItem("--Select Scheme Name--", "0"));

            ddlScheme.DataSource = ds.Tables[1];
            ddlScheme.DataValueField = "SchCode";
            ddlScheme.DataTextField = "SchNameE";
            ddlScheme.DataBind();
            ddlScheme.Items.Insert(0, new ListItem("--Select Scheme Name--", "0"));
        }
    }
    protected void btnSearchClear_Click(object sender, EventArgs e)
    {
        ddlSearchScheme.SelectedValue = "0";
        txtSearchPlotNo.Text = "";
        txtSearchRefNo.Text = "";

        txtRefNo.Text = "";
        txtServiceNo.Text = "";
        txtPlotNo.Text = "";
        txtPropPlaceHolder.Text = "";
        txtAddress.Text = "";
        ddlScheme.SelectedValue = "0";
    }
    
}