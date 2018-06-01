using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estate_Report_Rpt_LeaseLedger : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillddlScheme();
        }
    }

    public void FillddlScheme()
    {
        try
        {
           PL_PropertyMaster objpl = new PL_PropertyMaster();

            objpl.Ind = 1;

            int a = 0;
            DataSet ds = Estate_CLSCommon.CallApiGet("PropertyMaster/FillddlScheme?Ind=" + objpl.Ind);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSchName.DataTextField = "SchNameE";
                    ddlSchName.DataValueField = "SchCode";
                    ddlSchName.DataSource = ds.Tables[0];
                    ddlSchName.DataBind();
                }                
            }
            else
            {
                ddlSchName.DataSource = null;
                ddlSchName.DataBind();                
            }
            ddlSchName.Items.Insert(0, new ListItem("------ Select Scheme Name ------", "0"));
        }
        catch (Exception ex)
        {
            ShowMessage(" Please Check Api ", false);
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlSchName.SelectedItem.Value == "0")
        {
            ddlSchName.Focus();
            ShowMessage(" Please Select Scheme Name ", false);
            return;
        }


        Hashtable HT = new Hashtable();
        HT.Add("Ind", 1);
        HT.Add("SchCode", ddlSchName.SelectedValue);
        HT.Add("ServiceNo", 0);
        Session["HT"] = HT;
        Session["format"] = "Pdf";
        Session["FileName"] = "RptLedger";
        Session["Report"] = "RptLedger";
        Session["ReportName"] = "Lease Ledger";
     //   Response.Redirect("~/Report/ReportViewer.aspx");
        Response.Redirect("ReportViewer.aspx?index=27");
    }
}