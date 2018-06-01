using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmScanningFileEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlSuccess.Visible = false;
        pnlfailed.Visible = false;
        if (!IsPostBack)
        {
            Fillddl();
        }
    }

    public void Fillddl()
    {
        DataSet ds = Lease_CLSCommon.CallApiGet("api/ScanningFileEntry/Fillddl?Ind=2");
        if (ds != null && ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlScheme.DataSource = ds.Tables[1];
                ddlScheme.DataValueField = "SchCode";
                ddlScheme.DataTextField = "SchNameE";
                ddlScheme.DataBind();
                ddlScheme.Items.Insert(0, new ListItem("Select Scheme Name", "0"));
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //lblmsg.Text = "";
        int Refno = 0;
        if (txtRefNo.Text != "")
        {
            Refno = Convert.ToInt32(txtRefNo.Text.Trim());

        }
        else if (ddlScheme.SelectedIndex != 0)
        {
            if (txtPlotNo.Text != "")
            {

            }
            else
            {

                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Please Enter Plot No.";
                pnlSuccess.Visible = false;
                return;
            }

        }
        else
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Enter Reference No. or Select Scheme";
            pnlSuccess.Visible = false;
            return;
        }

        DataSet ds = Lease_CLSCommon.CallApiGet("api/ScanningFileEntry/GetSearch?Ind=5&RefNo=" + Refno + "&SchCode=" + ddlScheme.SelectedValue + "&PlotNo=" + txtPlotNo.Text.Trim() + " ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            pnlSearchedItem.Visible = true;
            txtSPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
            txtPropPlaceHolder.Text = ds.Tables[0].Rows[0]["PlotHolderNameE"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtSchemeName.Text = ds.Tables[0].Rows[0]["SchemeName"].ToString();
            txtIDARefNo.Text = ds.Tables[0].Rows[0]["IdaRefNo"].ToString();
            txtNewServiceNo.Text = ds.Tables[0].Rows[0]["ServiceNo"].ToString();

            txtRefNo.Enabled = false;
            txtRefNo.CssClass = "form-control";
            txtPlotNo.Enabled = false;
            txtPlotNo.CssClass = "form-control";
            ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["SchCode"].ToString();
            ddlScheme.Enabled = false;
            ddlScheme.CssClass = "form-control";
            txtSPlotNo.Enabled = false;
            txtSPlotNo.CssClass = "form-control";
            txtPropPlaceHolder.Enabled = false;
            txtPropPlaceHolder.CssClass = "form-control";
            txtAddress.Enabled = false;
            txtAddress.CssClass = "form-control";
            txtSchemeName.Enabled = false;
            txtSchemeName.CssClass = "form-control";
            txtIDARefNo.Enabled = false;
            txtPropPlaceHolder.CssClass = "form-control";
            txtNewServiceNo.Enabled = false;
            txtNewServiceNo.CssClass = "form-control";
        }
        else
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Record Not Found.";
            pnlSuccess.Visible = false;

            txtSPlotNo.Text = "";
            txtPropPlaceHolder.Text = "";
            txtAddress.Text = "";
            txtSchemeName.Text = "";

        }
    }
    public void clear()
    {
        pnlSearchedItem.Visible = false;
        txtRefNo.Text = "";
        txtPlotNo.Text = "";
        ddlScheme.SelectedIndex = 0;
        txtSPlotNo.Text = "";
        txtPropPlaceHolder.Text = "";
        txtAddress.Text = "";
        txtSchemeName.Text = "";
        txtIDARefNo.Text = "";
        txtNewServiceNo.Text = "";
        CheckYes.Checked = false;
        txtRefNo.Enabled = true;
        txtPlotNo.Enabled = true;
        ddlScheme.Enabled = true;
        txtSPlotNo.Enabled = true;
       
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CheckYes.Checked == false)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Verify Then Save";
            pnlSuccess.Visible = false;
            return;
        }
        if (txtIDARefNo.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Enter IDA Reference No.";
            pnlSuccess.Visible = false;
            return;
        }
        if (txtNewServiceNo.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Enter New Service No.";
            pnlSuccess.Visible = false;
            return;
        }
        else
        {
            PL_ScanningFileEntry objpl = new PL_ScanningFileEntry();
            objpl.Ind = 1;
            objpl.SchCode = Convert.ToInt32(ddlScheme.SelectedValue);
            objpl.ServiceNo = Convert.ToDecimal(txtNewServiceNo.Text.Trim());
            objpl.IDARefNo = Convert.ToDecimal(txtIDARefNo.Text.Trim());
            objpl.EntryUserCode = Convert.ToInt32(Session["EntryUserCode"]);
            DataTable dt = Lease_CLSCommon.CallApiPost("api/ScanningFileEntry/SaveScanningFileEntry", objpl);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerHtml = "Successfully Saved";
                    pnlfailed.Visible = false;
                    clear();

                }
                else if (dt.Rows[0]["res"].ToString() == "2")
                {
                    pnlfailed.Visible = true;
                    pnlfailed.InnerHtml = "IDA Reference No or Service No. Already Exsist ";
                    pnlSuccess.Visible = false;

                }
            }
        }

    }
    protected void CheckYes_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckYes.Checked == true)
        {
            pnlfailed.Visible = false;
            pnlSuccess.Visible = false;
        }
    }
}