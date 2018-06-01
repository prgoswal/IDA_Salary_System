using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSector : System.Web.UI.Page
{
    PL_Sector objpl = new PL_Sector();
    DataTable dtitems = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        if(!IsPostBack)
        {
            FillddlScheme();
        }

    }

    public void FillddlScheme()
    {
        try
        {
            objpl = new PL_Sector();

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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(ddlSchName.SelectedIndex == 0)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Select Scheme Name";
            return;
        }

        if (ddlPlotType.SelectedIndex == 0)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Select Plot Type";
            return;
        }
                   
                if (ViewState["dtGvItemDetail"] != null)
                {
                    DataTable dtItemName = (DataTable)ViewState["dtGvItemDetail"];
                    DataRow[] rows = dtItemName.Select("PlotTypeCode=" + ddlPlotType.SelectedItem.Value + " AND Sector='" + txtSector.Text.ToString() + "'");                  
                    //DataRow[] rows1 = dtItemName.Select("Sector='" + txtSector.Text.ToString() + "'");           
                    if (rows.Count() >= 1 )
                     {                       
                        //if(rows[0].ItemArray[0].ToString() == ddlPlotType.SelectedValue && rows1[0].ItemArray[1].ToString() == txtSector.Text.Trim())
                        //{
                            ddlPlotType.Focus();
                            pnlfailed.Visible = true;
                            pnlfailed.InnerHtml = "Sector Already Added In  this Plot.";
                            return;
                        //}                       
                    }
                }
                   BindGridDetails();                  
    }

    DataTable CreatGrid()
    {
        DataTable Gv = new DataTable();
        Gv.Columns.Add("SchemeCode", typeof(int));
        Gv.Columns.Add("PlotTypeCode", typeof(int));
        Gv.Columns.Add("Sector", typeof(string));
        Gv.Columns.Add("PlotTypeName", typeof(string));
   
        return Gv;
    }

    DataTable VsdtGvItemDetail
    {
        get { return (DataTable)ViewState["dtGvItemDetail"]; }
        set { ViewState["dtGvItemDetail"] = value; }
    }

    public void BindGridDetails()
    {
        if (VsdtGvItemDetail == null)
        {
            dtitems = CreatGrid();
        }
        else
        {
            dtitems = VsdtGvItemDetail;
            ViewState["dtGvItemDetail"] = dtitems;
        }                                       
        DataRow dr = dtitems.NewRow();
        dr["SchemeCode"] = ddlSchName.SelectedValue;
        dr["PlotTypeCode"] = ddlPlotType.SelectedValue;        
        dr["Sector"] = txtSector.Text.Trim();
        dr["PlotTypeName"] = ddlPlotType.SelectedItem.Text;
     
        dtitems.Rows.Add(dr);
        GVSector.DataSource = dtitems;
        GVSector.DataBind();
        ViewState["dtGvItemDetail"] = dtitems;
        ddlPlotType.ClearSelection();
        ddlSchName.ClearSelection();
        txtSector.Text = "";
       // txtSector.Text = "";
    }

    public void Clear()
    {
        ddlPlotType.ClearSelection();
        ddlSchName.ClearSelection();
        txtSector.Text = "";     
        GVSector.DataSource = null;
        GVSector.DataBind();
        ViewState["dtGvItemDetail"] = null;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (GVSector.Rows.Count == 0)
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Item Detail Can Not be Blank";
                return;
            }
            objpl = new PL_Sector()
            {
                Ind = 2,
                CityCode = 1,
               // SchCode = Convert.ToInt32(ddlSchName.SelectedValue),
                UserID = 1,
              //  PlotTypeCode =Convert.ToInt32(ddlPlotType.SelectedValue),
                Sector = txtSector.Text.Trim(),
                dt = (DataTable)ViewState["dtGvItemDetail"]
            };

            DataSet ds =Estate_CLSCommon.CallApiPostDS("Sector/AddSector", objpl);
            if (ds != null)
            {             
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerHtml = "Record Inserted Successfully";
                    Clear();                                    
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
    protected void btnCleae_Click(object sender, EventArgs e)
    {
        Clear();
    }
}