using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSchSector : System.Web.UI.Page
{
    PL_SchSector objpl = new PL_SchSector();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        lblSectorName.Visible = false;
        txtSector.Visible = false;
        lblSchMsg.Visible = false;
        if(!IsPostBack)
        {
            FillddlScheme();
        }
    }

    public void FillddlScheme()
    {
        try
        {
            objpl = new PL_SchSector();

            objpl.Ind = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiGet("Sector/FillddlScheme?Ind=" + objpl.Ind);
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
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }
    protected void ddlSchName_SelectedIndexChanged(object sender, EventArgs e)
    {       
        try
        {
            txtSector.Text = "";
            objpl = new PL_SchSector();
            objpl.Ind = 2;          
            objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

            DataSet ds =Estate_CLSCommon.CallApiPostDS("SchSector/GetSchInd",objpl);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["SectorAvalInd"].ToString() == "1")
                    {
                        lblSectorName.Visible = true;
                        txtSector.Visible = true;
                        btnSave.Enabled = true;
                        BindGrid();
                        txtSector.Focus();
                    } 
                                          
                else
                {                
                    lblSectorName.Visible = false;
                    txtSector.Visible = false;
                    lblSchMsg.Visible = true;
                    lblSchMsg.Text = "Sector Not Applicable on Scheme";
                    btnSave.Enabled = false;
                    GvSchSector.DataSource = null;
                    GvSchSector.DataBind();
                }
            }               
            }           
        }
        catch (Exception ex)
        {
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }

    public void BindGrid()
    {
        objpl = new PL_SchSector();
        objpl.Ind = 2;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
        DataSet ds =Estate_CLSCommon.CallApiPostDS("SchSector/GetSchInd", objpl);
        if (ds != null)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["SchNameE"].ToString() != "")
                {
                    lblSectorName.Visible = true;
                    txtSector.Visible = true;
                    GvSchSector.DataSource = ds.Tables[1];
                    GvSchSector.DataBind();
                }
                else
                {
                    GvSchSector.DataSource = null;
                    GvSchSector.DataBind();

                }
            }
            if (ds.Tables[1].Rows.Count == 0)
            {
                GvSchSector.DataSource = null;
                GvSchSector.DataBind();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if(txtSector.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerText = "Enter Sector Name";
                txtSector.Visible = true;
                lblSectorName.Visible = true;
                txtSector.Focus();
                return;
            }
        objpl = new PL_SchSector();
        objpl.Ind = 3;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
        objpl.SectorDesc = txtSector.Text == "" ? "" : txtSector.Text.Trim();
        objpl.ActiveInd = 1;
        objpl.EntryUser = 1;

        DataSet ds =Estate_CLSCommon.CallApiPostDS("SchSector/SaveData", objpl);
        if(ds != null)
        {
            if(ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerHtml = "Record Inserted Successfully";
                    txtSector.Text = "";
                    BindGrid();
                                
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Inserted ";
            }
            }
        }
        }
        catch (Exception ex)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
        }
     
    public void Clear()
    {
        ddlSchName.ClearSelection();
        txtSector.Text = "";
        GvSchSector.DataSource = null;
        GvSchSector.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = true;
        Clear();
    }
}