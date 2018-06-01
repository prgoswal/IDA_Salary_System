using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmSchPlotingDetail : System.Web.UI.Page
{
    PL_SchPlotingDetail objpl = new PL_SchPlotingDetail();
    DataTable dtitems = new DataTable();
    double MSchArea = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
      
        if(!IsPostBack)
        {
            Fillddl();
        }        
    }

    public void Fillddl()
    {
        objpl = new PL_SchPlotingDetail();
        objpl.Ind = 1;

        DataSet ds =Estate_CLSCommon.CallApiGet("SchPlotingDetail/FillddlScheme?Ind= " + objpl.Ind);
        if(ds != null  && ds.Tables.Count >0)
        {            
                if (ds.Tables[0].Rows[0]["SchCode"].ToString() != "")
                {
                    ddlSchName.DataTextField = "SchNameE";
                    ddlSchName.DataValueField = "SchCode";
                    ddlSchName.DataSource = ds.Tables[0];
                    ddlSchName.DataBind();
                }
                if (ds.Tables[1].Rows[0]["UseCode"].ToString() != "")
                {
                    ddlPlotUse.DataTextField = "UseDescE";
                    ddlPlotUse.DataValueField = "UseCode";
                    ddlPlotUse.DataSource = ds.Tables[1];
                    ddlPlotUse.DataBind();
                    
                }            
        }       
        else
        {
            ddlSchName.Items.Clear();
            ddlSchName.DataSource = null;
            ddlSchName.DataBind();
            ddlPlotUse.Items.Clear();
            ddlPlotUse.DataSource = null;
            ddlPlotUse.DataBind();  
        }
        ddlSchName.Items.Insert(0, new ListItem(" ------ Select Scheme Name ------", "0"));
        ddlPlotUse.Items.Insert(0, new ListItem(" ------ Select Plot Use ------", "0"));
    }

    protected void ddlSchName_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if(ddlSchName.SelectedIndex == 0)
        {
            lblSchName.Text = "";
            lblSchMsg.Visible = false;
        }
        else
        {
            lblSchName.Text = ddlSchName.SelectedItem.Text;

        }
        objpl = new PL_SchPlotingDetail();
        objpl.Ind = 6;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

        DataSet dssec =Estate_CLSCommon.CallApiGet("SchPlotingDetail/FillddlSector?Ind= " + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if (dssec != null && dssec.Tables.Count > 0)
        {
            if (dssec.Tables[0].Rows[0]["SectorAvalInd"].ToString() == "1")
            {
                lblSectorName.Visible = true;
                ddlSectorName.Visible = true;
                lblSchMsg.Visible = false;
                ddlSectorName.Focus();
            }

            else
            {
                lblSectorName.Visible = false;
                ddlSectorName.Visible = false;
                lblSchMsg.Visible = true;
                lblSchMsg.Text = "Sector Not Applicable on Scheme";
            }
        }
    

        objpl = new PL_SchPlotingDetail();
        objpl.Ind = 2;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

        DataSet ds =Estate_CLSCommon.CallApiGet("SchPlotingDetail/FillddlSector?Ind= " + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if (ds != null && ds.Tables.Count > 0)
        {                       
                if (ds.Tables[0].Rows[0]["SectorID"].ToString() != "")
                {
                    ddlSectorName.DataTextField = "SectorDesc";
                    ddlSectorName.DataValueField = "SectorID";
                    ddlSectorName.DataSource = ds.Tables[0];
                    ddlSectorName.DataBind();
                }                     
        }
        else
        {
            ddlSectorName.Items.Clear();
            ddlSectorName.DataSource = null;
            ddlSectorName.DataBind();      
        }
        ddlSectorName.Items.Insert(0, new ListItem(" ------- Select Sector Name -------", "0"));

      
        objpl.Ind = 3;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
        DataSet ds1 =Estate_CLSCommon.CallApiGet("SchPlotingDetail/FillddlPlotType?Ind= " + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if (ds1 != null && ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows[0]["PlotTypeID"].ToString() != "")
            {
                ddlPlotType.DataTextField = "PlotTypeDesc";
                ddlPlotType.DataValueField = "PlotTypeID";
                ddlPlotType.DataSource = ds1.Tables[0];
                ddlPlotType.DataBind();
            }

        }
        else
        {            
            ddlPlotType.Items.Clear();
            ddlPlotType.DataSource = null;
            ddlPlotType.DataBind();
        }       
        ddlPlotType.Items.Insert(0, new ListItem("----Select Plot Type ----", "0"));
        BindGridAcToSch();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(ddlPlotUse.SelectedIndex == 0)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Select Plot Use";
            ddlPlotUse.Focus();
            return;
        }
        if(txtPlotWidth.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot Width";
            txtPlotWidth.Focus();
            return;
        }
        if(txtPlotLength.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot Length";
            txtPlotLength.Focus();
            return;
        }  
         if(txtPlotSize.Text =="")
         {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot Size";
            txtPlotSize.Focus();
            return;
        }
         if (txtTotalPlots.Text == "")
         {
             pnlfailed.Visible = true;
             pnlfailed.InnerText = "Enter Total Plot";
             txtTotalPlots.Focus();
             return;
         }
        if(txtPlotAreaSqYard.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot Area Sq. Yard";
            txtPlotAreaSqYard.Focus();
            return;
        }
        if(txtPlotAreaSqMeter.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot Area Sq. Meter";
            txtPlotAreaSqMeter.Focus();
            return;
        }
        BindGrid();
        ClearAdd();
    }

    DataTable CreatGrid()
     {
        DataTable Gv = new DataTable();
        Gv.Columns.Add("SchCode",typeof(int));
        Gv.Columns.Add("SectorCode", typeof(int));
        Gv.Columns.Add("PlotTypeCode", typeof(int));
        Gv.Columns.Add("PlotUseCode", typeof(int));        
        Gv.Columns.Add("PlotWidth", typeof(decimal));
        Gv.Columns.Add("PlotLength", typeof(decimal));       
        Gv.Columns.Add("PlotAreaSqyard", typeof(decimal));
        Gv.Columns.Add("PlotAreaSqMeter", typeof(decimal));
        Gv.Columns.Add("PlotAreaString", typeof(string));
        Gv.Columns.Add("PlotSize", typeof(string));
        Gv.Columns.Add("TotalPlot", typeof(Int64));
        Gv.Columns.Add("PlotTypeName", typeof(string));
        Gv.Columns.Add("PlotUseName", typeof(string));


        return Gv;
    }

    DataTable VsdtGvItemDetail
    {
        get { return (DataTable)ViewState["dtGvItemDetail"]; }
        set { ViewState["dtGvItemDetail"] = value; }
    }
    
    public void BindGrid()
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
        dr["SchCode"] = ddlSchName.SelectedValue;
        dr["SectorCode"] = ddlSectorName.SelectedValue;
        dr["PlotTypeCode"] = ddlPlotType.SelectedValue;       
        dr["PlotUseCode"] = ddlPlotUse.SelectedValue;      
        dr["PlotWidth"] = txtPlotWidth.Text.Trim();
        dr["PlotLength"] = txtPlotLength.Text.Trim();      
        dr["PlotAreaSqyard"] = txtPlotAreaSqYard.Text;
        dr["PlotAreaSqMeter"] = txtPlotAreaSqMeter.Text;       
        dr["PlotAreaString"] = txtPlotAreaSqYard.Text + " x " + txtPlotAreaSqMeter.Text;
        dr["PlotSize"] = txtPlotSize.Text.Trim();
        dr["TotalPlot"] =Convert.ToInt64(txtTotalPlots.Text.Trim());
        if (ddlPlotType.SelectedValue == "0")
        {
            dr["PlotTypeName"] = "";
        }
        else
        {
            dr["PlotTypeName"] = ddlPlotType.SelectedItem.Text;
        }
          dr["PlotUseName"] = ddlPlotUse.SelectedItem.Text;

        dtitems.Rows.Add(dr);
        GvPlotDetail.DataSource = dtitems;
        GvPlotDetail.DataBind();
        ViewState["dtGvItemDetail"] = dtitems;        
    }
    protected void txtPlotAreaSqYard_TextChanged(object sender, EventArgs e)
    {
        
        if (txtPlotAreaSqYard.Text != "")
        {
            double SchArea = Convert.ToDouble(txtPlotAreaSqYard.Text);
            MSchArea = SchArea / 0.8361;
         
            txtPlotAreaSqMeter.Text = MSchArea.ToString("##.####");
            btnAdd.Focus();
        }
        else
        {
            MSchArea = 0;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlSectorName.Items.Clear();
        ClearAdd();
        Clear();
        GvPlotDetail.DataSource = null;
        GvPlotDetail.DataBind();
        GvPlotSaveDetail.DataSource = null;
        GvPlotSaveDetail.DataBind();
        ViewState["dtGvItemDetail"] = null;
        ddlSchName.ClearSelection();
    }

    public void ClearAdd()
    {
        ddlPlotType.ClearSelection();
        ddlPlotUse.ClearSelection();
        txtPlotWidth.Text = "";
        txtPlotLength.Text = "";
        txtPlotAreaSqYard.Text = "";
        txtPlotAreaSqMeter.Text = "";
      //  GvPlotDetail.DataSource = null;
      //  GvPlotDetail.DataBind();
        lblSchName.Text = "";
        txtPlotSize.Text = "";
        txtTotalPlots.Text = "";
    }
    
    public void Clear()
    {
        lblSchMsg.Text = "";
      //  ddlSchName.ClearSelection();
        ddlSectorName.ClearSelection();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (GvPlotDetail.Rows.Count == 0)
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Plot Detail Can Not be Blank";
                return;
            }
            objpl = new PL_SchPlotingDetail();
            objpl.Ind = 4;
            objpl.EntryUserCode = 1;
            objpl.dt = (DataTable)ViewState["dtGvItemDetail"];

            DataSet ds =Estate_CLSCommon.CallApiPostDS("SchPlotingDetail/SaveData", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerText = "Record Inserted Successfully";
                    Clear();
                    ClearAdd();
                    ViewState["dtGvItemDetail"] = null;
                    GvPlotDetail.DataSource = null;
                    GvPlotDetail.DataBind();
                    BindGridAcToSch();
                    return;
                }
                else
                {
                    pnlfailed.Visible = true;
                    pnlfailed.InnerHtml = "Record Not Inserted ";
                }


            }
        }
        catch (Exception ex)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }

    public void BindGridAcToSch()
    {
        objpl = new PL_SchPlotingDetail();
        objpl.Ind = 5;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

        DataSet ds1 =Estate_CLSCommon.CallApiGet("SchPlotingDetail/BindGridAcToSch?Ind=" + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if(ds1 != null && ds1.Tables.Count > 0)
        {
            GvPlotSaveDetail.DataSource = ds1.Tables[0];
            GvPlotSaveDetail.DataBind();
        }
        else
        {
            GvPlotSaveDetail.DataSource = null;
            GvPlotSaveDetail.DataBind();
        }
    }

    protected void txtPlotWidth_TextChanged(object sender, EventArgs e)
    {
        if(txtPlotWidth.Text != "" && txtPlotLength.Text != "")
        {
            txtPlotSize.Text = txtPlotWidth.Text + " x " + txtPlotLength.Text;
        }
        else
        {
            if (txtPlotWidth.Text == "" || txtPlotLength.Text == "")
            {
                txtPlotSize.Text = "";
            }
        }
        txtPlotLength.Focus();
    }
    protected void txtPlotLength_TextChanged(object sender, EventArgs e)
    {
        if(txtPlotWidth.Text != "" && txtPlotLength.Text != "")
        {
            txtPlotSize.Text = txtPlotWidth.Text + " x " + txtPlotLength.Text;
        }
        else
        {
            if (txtPlotWidth.Text == "" || txtPlotLength.Text == "")
            {
                txtPlotSize.Text = "";
            }
            
        }
        txtTotalPlots.Focus();
    }   
}