using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmSchPlotTypeAssign : System.Web.UI.Page
{
    PL_SchplotTypeAssign objpl = new PL_SchplotTypeAssign();

    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        lblPlotType.Visible = false;
        ddlPlotType.Visible = false;
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
            objpl = new PL_SchplotTypeAssign();

            objpl.Ind = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiGet("SchPlotTypeAssign/FillddlScheme?Ind=" + objpl.Ind);
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
                    ddlPlotType.DataTextField = "PlotTypeDesc";
                    ddlPlotType.DataValueField = "PlotTypeID";
                    ddlPlotType.DataSource = ds.Tables[1];
                    ddlPlotType.DataBind();
                }
            }
            else
            {
                ddlSchName.DataSource = null;
                ddlSchName.DataBind();
                ddlPlotType.DataSource = null;
                ddlPlotType.DataBind();
            }
            ddlSchName.Items.Insert(0, new ListItem("------ Select Scheme Name ------", "0"));
            ddlPlotType.Items.Insert(0, new ListItem("------ Select Plot Type ------", "0"));
        }
        catch (Exception ex)
        {
            // pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPlotType.SelectedValue == "0")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerText = "Select Plot Type";
                lblPlotType.Visible = true;
                ddlPlotType.Visible = true;
                ddlPlotType.Focus();
                return;
            }        
            objpl = new PL_SchplotTypeAssign();

            objpl.Ind = 2;
            objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
            objpl.PlotTypeID = Convert.ToInt32(ddlPlotType.SelectedValue);
            objpl.EntryUser = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiPostDS("SchPlotTypeAssign/SaveData", objpl);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerHtml = "Record Inserted Successfully";
                    BindGrid();
                    ddlPlotType.ClearSelection();                  
                }
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Inserted ";
            }


        }
        catch (Exception ex)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = true;
        Clear();
    }

    public void Clear()
    {
        ddlPlotType.ClearSelection();
        ddlSchName.ClearSelection();
        GvSchPTAssign.DataSource = null;
        GvSchPTAssign.DataBind();
    }

    public void BindGrid()
    {
        objpl = new PL_SchplotTypeAssign();
        objpl.Ind = 3;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
        objpl.PlotTypeID = Convert.ToInt32(ddlPlotType.SelectedValue);

        DataSet ds =Estate_CLSCommon.CallApiPostDS("SchPlotTypeAssign/GetData", objpl);
        if (ds != null)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["SchNameE"].ToString() != "")
                {
                    ddlPlotType.Visible = true;
                    lblPlotType.Visible = true;
                    GvSchPTAssign.DataSource = ds.Tables[1];
                    GvSchPTAssign.DataBind();
                }
                else
                {
                    GvSchPTAssign.DataSource = null;
                    GvSchPTAssign.DataBind();

                }
            }
            if (ds.Tables[1].Rows.Count == 0)
            {
                GvSchPTAssign.DataSource = null;
                GvSchPTAssign.DataBind();
            }
        }
    }
    protected void ddlSchName_SelectedIndexChanged(object sender, EventArgs e)
    {        
        try
        {
            ddlPlotType.ClearSelection();
            objpl = new PL_SchplotTypeAssign();
            objpl.Ind = 3;
            objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
            objpl.PlotTypeID = Convert.ToInt32(ddlPlotType.SelectedValue);

            DataSet ds =Estate_CLSCommon.CallApiPostDS("SchPlotTypeAssign/GetData", objpl);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["PlotCateTypeInd"].ToString() == "1")
                    {
                        lblPlotType.Visible = true;
                        ddlPlotType.Visible = true;
                        ddlPlotType.Focus();
                        btnSave.Enabled = true;
                        BindGrid();
                    }

                    else
                    {
                        lblPlotType.Visible = false;
                        ddlPlotType.Visible = false;
                        lblSchMsg.Visible = true;
                        lblSchMsg.Text = "Sector Not Applicable on Scheme";
                        btnSave.Enabled = false;
                        GvSchPTAssign.DataSource = null;
                        GvSchPTAssign.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }
}