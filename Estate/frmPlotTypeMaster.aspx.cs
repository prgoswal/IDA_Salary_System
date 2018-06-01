using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPlotTypeMaster : System.Web.UI.Page
{
    PL_PlotType objpl = new PL_PlotType();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;

        if(!IsPostBack)
        {
            BindGrid();
        }

    }

    public void BindGrid()
    {
        try
        {        
        objpl = new PL_PlotType();

            objpl.Ind = 2;           
            
            int a = 0;           
            DataSet ds =Estate_CLSCommon.CallApiGet("PlotType/BindGrid?Ind=" + objpl.Ind);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvPlot.DataSource = ds;
                    GvPlot.DataBind();
                }
            }
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
            if (txtPlotType.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Enter Plot Type";
                txtPlotType.Focus();
                return;
            }

            if (txtPlotTypeShort.Text.Trim() == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Enter Plot Type Short Name";
                txtPlotTypeShort.Focus();
                return;

            }
            objpl = new PL_PlotType();

            objpl.Ind = 1;           
            objpl.PlotTypeDesc = txtPlotType.Text.Trim();
            objpl.PlotTypeShortDesc = txtPlotTypeShort.Text.Trim();
            objpl.ActiveInd = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiPostDS("PlotType/AddPlotType", objpl);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerHtml = "Record Inserted Successfully";
                    BindGrid();
                    Clear();
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
        Clear();
    }

    public void Clear()
    {
        txtPlotType.Text = "";
        txtPlotTypeShort.Text = "";
    }
}