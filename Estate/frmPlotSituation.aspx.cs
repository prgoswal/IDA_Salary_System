using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmPlotSituation : System.Web.UI.Page
{
    PL_PlotSituation objpl = new PL_PlotSituation();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(txtPlotSituaE.Text == "")
        {
            pnlfailed.Visible=true;
            pnlfailed.InnerText="Enter Situation Type English";
            txtPlotSituaE.Focus();
            return;
        }
        if(txtPlotSituaH.Text == "")
        {
            pnlfailed.Visible=true;
            pnlfailed.InnerText="Enter Situation Type Hindi";
            txtPlotSituaH.Focus();
            return;
        }
        objpl.Ind = 1;
        objpl.PlotSituaEng = txtPlotSituaE.Text.Trim();
        objpl.PlotSituaHindi = txtPlotSituaH.Text;
        objpl.Active = 1;

        DataSet ds =Estate_CLSCommon.CallApiPostDS("PlotSituation/SaveData", objpl);
        if(ds != null && ds.Tables.Count > 0)
        {
            if(ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerText = "Record Inserted Successfully";
                Clear();
                return;
               
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Clear()
    {
        txtPlotSituaE.Text = "";
        txtPlotSituaH.Text = "";
    }
}