using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPlotNoAllotment : System.Web.UI.Page
{
    PL_PlotNoAllotment objpl = new PL_PlotNoAllotment();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        if(!IsPostBack)
        {
            GetPFeatures();
            FillddlScheme();
        }   
    }
    
    public void FillddlScheme()
    {
        try
        {
            objpl = new PL_PlotNoAllotment();

            objpl.Ind = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiGet("PlotNoAllotment/FillddlScheme?Ind=" + objpl.Ind);
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
        BindGrid();
        objpl = new PL_PlotNoAllotment();
        objpl.Ind = 6;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

        DataSet dssec =Estate_CLSCommon.CallApiGet("PlotNoAllotment/FillddlSector?Ind= " + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if (dssec != null && dssec.Tables.Count > 0)
        {
            if (dssec.Tables[0].Rows[0]["SectorAvalInd"].ToString() == "1")
            {
                lblSectorName.Visible = true;
                ddlSecName.Visible = true;
                lblSchMsg.Visible = false;
                ddlSecName.Focus();
            }

            else
            {
                lblSectorName.Visible = false;
                ddlSecName.Visible = false;
                lblSchMsg.Visible = true;
                lblSchMsg.Text = "Sector Not Applicable on Scheme";
                ddlPlotType.Focus();
            }
        }
        else
        {
            ddlPlotSize.Items.Clear();
        }
        objpl = new PL_PlotNoAllotment();
        objpl.Ind = 2;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

        DataSet ds =Estate_CLSCommon.CallApiGet("PlotNoAllotment/FillddlSector?Ind= " + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if (ds != null && ds.Tables.Count > 0)
         {            
                if (ds.Tables[0].Rows[0]["SectorID"].ToString() != "")
                {
                    ddlSecName.DataTextField = "SectorDesc";
                    ddlSecName.DataValueField = "SectorID";
                    ddlSecName.DataSource = ds.Tables[0];
                    ddlSecName.DataBind();                
                }                     
        }
        else
        {
            ddlSecName.Items.Clear();
            ddlSecName.DataSource = null;
            ddlSecName.DataBind();
            if(objpl.SchCode == 0)
            {
                lblSchMsg.Visible = false;   
            }
                                
        }
        ddlSecName.Items.Insert(0, new ListItem(" ------- Select Sector Name -------", "0"));
      

        objpl = new PL_PlotNoAllotment();
        objpl.Ind = 3;
        objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);

        DataSet ds1 =Estate_CLSCommon.CallApiGet("PlotNoAllotment/FillddlSector?Ind= " + objpl.Ind + "&SchCode= " + objpl.SchCode);
        if (ds1 != null && ds1.Tables.Count > 0)
        {              
                if (ds1.Tables[0].Rows[0]["PlotTypeCode"].ToString() != "")
                {
                    ddlPlotType.DataTextField = "PlotTypeDesc";
                    ddlPlotType.DataValueField = "PlotTypeCode";
                    ddlPlotType.DataSource = ds1.Tables[0];
                    ddlPlotType.DataBind();                   
                }
          }       
        else
        {           
            ddlPlotType.Items.Clear();
            ddlPlotType.DataSource = null;
            ddlPlotType.DataBind();
            ddlPlotSize.Items.Clear();               
           
            txtTotalPlot.Text = "";
        }      
        ddlPlotType.Items.Insert(0, new ListItem(" ------- Select Plot Type -------", "0"));       
    }
    
    protected void ddlPlotSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        objpl = new PL_PlotNoAllotment();
        objpl.Ind = 4;
        objpl.PlotSize = ddlPlotSize.SelectedItem.Text;

        DataSet ds =Estate_CLSCommon.CallApiGet("PlotNoAllotment/GetTotalPlot?Ind=" + objpl.Ind + "&PlotSize=" + objpl.PlotSize);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["TotalPlot"].ToString() != "")
            {
                txtTotalPlot.Text = ds.Tables[0].Rows[0]["TotalPlot"].ToString();
                ViewState["AreaSqYard"] = ds.Tables[0].Rows[0]["PlotAreaSqyard"].ToString();
                ViewState["AreaSqMeter"] = ds.Tables[0].Rows[0]["PlotAreaSqMeter"].ToString();
            }
            else
            {
                txtTotalPlot.Text = "";
                ViewState["AreaSqYard"] = "";
                ViewState["AreaSqMeter"] = "";
            }
        }
        else
        {
            txtTotalPlot.Text = "";
            ViewState["AreaSqYard"] = "";
            ViewState["AreaSqMeter"] = "";
            
        }

    }

    DataTable VsdtGvItemDetail
    {
        get { return (DataTable)ViewState["dtGvItemDetail"]; }
        set { ViewState["dtGvItemDetail"] = value; }
    }

    DataSet ds = new DataSet();
    public void GetPFeatures()
    {
        objpl = new PL_PlotNoAllotment();
        objpl.Ind = 5;
         ds =Estate_CLSCommon.CallApiPostDS("PlotNoAllotment/GetPlotFeatures", objpl);
    }

    protected void btnAsgPlotNo_Click(object sender, EventArgs e)
    {
        if(txtPlotNoFrom.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot No. From";
            txtPlotNoFrom.Focus();
            return;
        }
        if (txtPlotNoTo.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerText = "Enter Plot No. To";
            txtPlotNoTo.Focus();
            return;
        }    
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("PlotTypeCode", typeof(int)));
        dt.Columns.Add(new DataColumn("PlotSize", typeof(string)));       
        dt.Columns.Add(new DataColumn("PlotAreaSqyard", typeof(decimal)));
        dt.Columns.Add(new DataColumn("PlotAreaSqMeter", typeof(decimal)));
        dt.Columns.Add(new DataColumn("PlotNo", typeof(int)));       
        dt.Columns.Add(new DataColumn("PlotTypeName", typeof(string)));
        dt.Columns.Add(new DataColumn("PlotSizeCode", typeof(string)));
       
    
        for (int Row = Convert.ToInt32(txtPlotNoFrom.Text); Row <= Convert.ToInt32(txtPlotNoTo.Text); Row++)
        {
            dr = dt.NewRow();
            dr["PlotTypeCode"] = ddlPlotType.SelectedValue == "" ? "0" : ddlPlotType.SelectedValue;
            dr["PlotSize"] = ddlPlotSize.SelectedValue == "" || ddlPlotSize.SelectedValue == "0" ? "" : ddlPlotSize.SelectedItem.Text;
            dr["PlotAreaSqyard"] = ViewState["AreaSqYard"] == null ? "0" : ViewState["AreaSqYard"];
            dr["PlotAreaSqMeter"] = ViewState["AreaSqMeter"] == null ? "0" : ViewState["AreaSqMeter"];
            dr["PlotNo"] = Row;          
            dr["PlotTypeName"] = ddlPlotType.SelectedValue == "" || ddlPlotType.SelectedValue == "0" ? "" : ddlPlotType.SelectedItem.Text;
            dr["PlotSizeCode"] = ddlPlotSize.SelectedValue;
                     
            dt.Rows.Add(dr);      
        }

        GvPlotAllot.DataSource = dt;
        GvPlotAllot.DataBind();
        ViewState["dtGvItemDetail"] = dt;  
    }

    protected void GvPlotAllot_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if(ds.Tables.Count==0)
            {
                GetPFeatures();
            }
            if (ds != null && ds.Tables.Count > 0)
            {                
                CheckBoxList chk = (CheckBoxList)e.Row.FindControl("chkplot");
                chk.DataSource = ds.Tables[0];
                chk.DataTextField = "PlotSituationE";
                chk.DataValueField = "PlotSituationCode";
                chk.DataBind();                                     
                txtPlotNoFrom.Text = "";
                txtPlotNoTo.Text = "";
            }

        }
    }

     public void Clear()
     {
      //  ddlSecName.ClearSelection();
      //  ddlSchName.ClearSelection();
        ddlPlotType.ClearSelection();
        ddlPlotSize.ClearSelection();
      //  ddlSecName.Items.Clear();
        ddlPlotType.Items.Clear();
        ddlPlotSize.Items.Clear();
        txtTotalPlot.Text = "";
        txtTotalAssplot.Text = "";
        txtPlotNoFrom.Text = "";
        txtPlotNoTo.Text = "";
        ddlSeprator.ClearSelection();
        GvPlotAllot.DataSource = null;
        GvPlotAllot.DataBind();
        ViewState["dtGvItemDetail"] = null;
        ViewState["dtGvFeature"] = null;

    }
     DataTable dtfeature = new DataTable();
     DataTable CreatGrid()
     {        
         dtfeature.Columns.Add("PlotNo", typeof(int));
         dtfeature.Columns.Add("PlotFeatureCode", typeof(int));

         return dtfeature;
     }
     DataRow drfeature = null;
     DataTable VsDtGvFeature
     {
         get { return (DataTable)ViewState["dtGvFeature"]; }
         set { ViewState["dtGvFeature"] = value; }
     }
    

     protected void btnSave_Click(object sender, EventArgs e)
     {
         try
         {
             if (GvPlotAllot.Rows.Count == 0)
             {
                 pnlfailed.Visible = true;
                 pnlfailed.InnerHtml = "Assign Plot Detail Can Not be Blank";
                 return;
             }
             CreatGrid();
             objpl = new PL_PlotNoAllotment();
             objpl.Ind = 7;
             objpl.SchCode = Convert.ToInt32(ddlSchName.SelectedValue);
             objpl.SectorCode = Convert.ToInt32(ddlSecName.SelectedValue);
             objpl.EntryUserCode = 1;
             objpl.dt = (DataTable)ViewState["dtGvItemDetail"];

             foreach (GridViewRow gvr in GvPlotAllot.Rows)
             {
                 CheckBoxList chk = (CheckBoxList)gvr.FindControl("chkplot");
                 foreach (ListItem lst in chk.Items)
                 {
                     if (lst.Selected)
                     {
                         drfeature = dtfeature.NewRow();
                         Label plotno = (Label)gvr.FindControl("lblPlotNo");
                         drfeature["PlotNo"] = plotno.Text;
                         drfeature["PlotFeatureCode"] = lst.Value;
                         dtfeature.Rows.Add(drfeature);
                     }
                 }
             }
             ViewState["dtGvFeature"] = dtfeature;
             if (VsDtGvFeature != null)
             {
                 VsDtGvFeature.TableName = "dtGvFeature";
                 objpl.AllDs.Tables.Add(VsDtGvFeature);
             }
             else
             {
                 objpl.AllDs.Tables.Add(CreatGrid());
             }



             objpl.dtfeat = (DataTable)ViewState["dtGvFeature"];
             DataSet ds =Estate_CLSCommon.CallApiPostDS("PlotNoAllotment/SaveData", objpl);
             if (ds != null && ds.Tables.Count > 0)
             {
                 pnlSuccess.Visible = true;
                 pnlSuccess.InnerText = "Record Inserted Successfully";
                 Clear();
                 BindGrid();
                 return;
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
         ddlSchName.ClearSelection();
         ddlSecName.ClearSelection();
         ddlSecName.Items.Clear();
         GvBind.DataSource = null;
         GvBind.DataBind();
         lblSchMsg.Visible = false;
         Clear();         
     }
     protected void ddlPlotType_SelectedIndexChanged(object sender, EventArgs e)
     {
         objpl = new PL_PlotNoAllotment();
         objpl.Ind = 8;
         objpl.PlotTypeCode =ddlPlotType.SelectedValue == "" ? 0 : Convert.ToInt32(ddlPlotType.SelectedValue);

         DataSet ds =Estate_CLSCommon.CallApiGet("PlotNoAllotment/GetPlotSize?Ind=" + objpl.Ind + "&PlotTypeCode=" + objpl.PlotTypeCode);
         if(ds!=null && ds.Tables.Count > 0)
         {
             ddlPlotSize.DataTextField = "PlotSize";
           //  ddlPlotSize.DataValueField = "PlotTypeCode";
             ddlPlotSize.DataSource = ds.Tables[0];
             ddlPlotSize.DataBind();
             if(ds.Tables[0].Rows[0]["PlotTypeCode"].ToString() == "0")
             {
                 ddlPlotSize.Items.Clear();
                 ddlPlotSize.DataSource = null;
                 ddlPlotSize.DataBind();
                 txtTotalPlot.Text = "";
             }
         }
         else
         {
             ddlPlotSize.Items.Clear();
             ddlPlotSize.DataSource = null;
             ddlPlotSize.DataBind();
             txtTotalPlot.Text = "";
         }
         ddlPlotSize.Items.Insert(0, new ListItem(" ------- Select Plot Size -------", "0"));
     }
   
    public void BindGrid()
     {
         DataSet ds = new DataSet();
         objpl = new PL_PlotNoAllotment();       
         objpl.SchCode =Convert.ToInt32(ddlSchName.SelectedValue);
         objpl.SectorCode =ddlSecName.SelectedValue == "" ? 0 : Convert.ToInt32(ddlSecName.SelectedValue);

        if(objpl.SectorCode == 0)
        {
            objpl.Ind = 9;
             ds =Estate_CLSCommon.CallApiGet("PlotNoAllotment/BindGirdAcToSch?Ind=" + objpl.Ind + "&SchCode=" + objpl.SchCode);
        }   
        else
        {
            objpl.Ind = 10;
             ds =Estate_CLSCommon.CallApiGet("PlotNoAllotment/BindGird?Ind=" + objpl.Ind + "&SchCode=" + objpl.SchCode + "&SectorCode=" + objpl.SectorCode);
        }
       
         if (ds != null && ds.Tables.Count > 0)
         {
             GvBind.DataSource = ds;
             GvBind.DataBind();
         }
         else
         {
             GvBind.DataSource = null;
             GvBind.DataBind();
         }
     }
    protected void ddlSecName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}