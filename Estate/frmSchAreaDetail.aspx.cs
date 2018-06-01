using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSchAreaDetail : System.Web.UI.Page
{
    PL_SchAreaDetail objpl = new PL_SchAreaDetail();
    DataTable  dtitems = new DataTable();

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
            objpl = new PL_SchAreaDetail();

            objpl.Ind = 1;

            int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiGet("AreaDetail/FillddlScheme?Ind=" + objpl.Ind);
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
                    ddlOtherFac.DataTextField = "OtherfacilityDescE";
                    ddlOtherFac.DataValueField = "OtherfacilityInd";
                    ddlOtherFac.DataSource = ds.Tables[1];
                    ddlOtherFac.DataBind();
                }
            }
            else
            {
                ddlSchName.DataSource = null;
                ddlSchName.DataBind();
                ddlOtherFac.DataSource = null;
                ddlOtherFac.DataBind();
            }
            ddlSchName.Items.Insert(0, new ListItem("------ Select Scheme Name ------", "0"));
            ddlOtherFac.Items.Insert(0, new ListItem("------ Select Other Facility ------", "0"));
        }
        catch (Exception ex)
        {
            // pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
    }
    public void CalculateTotal()
    {
        int sum = 0;
         int area =0;
        if (GVOtherFacility.Rows.Count > 0)
        {
            foreach (GridViewRow gridrow in GVOtherFacility.Rows)
            {
                Label value = (Label)gridrow.FindControl("lblAreaName");
                int svalue = Convert.ToInt32(value.Text);
                sum += svalue;
                if(txtArea.Text != "")
                {
                     area = Convert.ToInt32(txtArea.Text);
                }
            else
                {
                    area = 0;
                }

                int finalvalue = sum + area;
                txtTotalfac.Text = finalvalue.ToString();
            }
        }
        else
        {
            txtTotalfac.Text = txtArea.Text;
        }
       

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        CalculateTotal();
        objpl = new PL_SchAreaDetail()
        {
            Ind = 4,
            SchCode = Convert.ToInt32(ddlSchName.SelectedValue),
        };
        DataSet ds =Estate_CLSCommon.CallApiGet("AreaDetail/GetSchCodeOdp?Ind=" + objpl.Ind + "&SchCode=" + objpl.SchCode);
      if(ds !=null)
      {
        if(ds.Tables[0].Rows.Count > 0)
        {
            ViewState["SchCodeOdp"] = ds.Tables[0].Rows[0]["SchCodeOdp"].ToString();
        }
      }
       
        BindGrid();
    }

    DataTable CreatGrid()
    {
        DataTable DtOther = new DataTable();
        DtOther.Columns.Add("SchCode", typeof(int));
        DtOther.Columns.Add("SchCodeOdp", typeof(int));
        DtOther.Columns.Add("FacilityCode", typeof(int));      
        DtOther.Columns.Add("FacilityAreaSqYard", typeof(string));
        DtOther.Columns.Add("FacilityAreaSqMeter", typeof(decimal));
        DtOther.Columns.Add("FacilityAreaString", typeof(string));
        DtOther.Columns.Add("FacilityName", typeof(string));

        return DtOther;
    }


    DataTable VsdtGvItemDetail
    {
        get { return (DataTable)ViewState["dtGvItemDetail"]; }
        set { ViewState["dtGvItemDetail"] = value; }
    }

    public void BindGrid()
    {
        try
        {

            double Area = Convert.ToDouble(txtArea.Text);
            double MArea = Area / 0.8361;
           //string finalVal = MArea.ToString("{##.####}");
            decimal finaval = Convert.ToDecimal(MArea);
           
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
            dr["SchCodeOdp"] = ViewState["SchCodeOdp"];
            dr["FacilityCode"] = ddlOtherFac.SelectedValue;         
            dr["FacilityAreaSqYard"] = txtArea.Text.Trim();
            dr["FacilityAreaSqMeter"] = finaval;  //String.Format("{0:0.0000}", MArea);
            dr["FacilityAreaString"] = "";
            dr["FacilityName"] = ddlOtherFac.SelectedItem.Text;

            dtitems.Rows.Add(dr);
            GVOtherFacility.DataSource = dtitems;
            GVOtherFacility.DataBind();
            ViewState["dtGvItemDetail"] = dtitems;
                     
            ddlOtherFac.ClearSelection();
         //   ddlSchName.ClearSelection();
            txtArea.Text = "";
          //  txtTotalSchArea.Text = "";
          //  txtTotalPlotArea.Text = "";
        }
        catch(Exception ex)
        {
            pnlfailed.InnerHtml = "Please Check Api";
        }     
    }

    protected void ddlSchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        objpl = new PL_SchAreaDetail()
        {
            Ind = 2,
            SchCode =Convert.ToInt32(ddlSchName.SelectedValue)
        };

        int a = 0;
            DataSet ds =Estate_CLSCommon.CallApiGet("AreaDetail/ddlChange?Ind=" + objpl.Ind + "&SchCode=" + objpl.SchCode);
            if (ds != null )
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTotalSchArea.Text = ds.Tables[0].Rows[0]["TotalSchAreaSqYard"].ToString();
                    txtTotalPlotArea.Text = ds.Tables[0].Rows[0]["TotalPlotingAreaSqyard"].ToString();                   
                }
                else
                {
                    txtTotalSchArea.Text = "";
                    txtTotalPlotArea.Text = "";
                }
            }
            else
            {
                txtTotalSchArea.Text = "";
                txtTotalPlotArea.Text = "";       
            }           
        }
        catch (Exception ex)
        {
            // pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Check Api";
        }
        ddlOtherFac.Focus();
    }

    public void Clear()
    {
        ddlSchName.ClearSelection();
        ddlSchName.ClearSelection();
        txtArea.Text = "";
        txtTotalPlotArea.Text = "";
        txtTotalSchArea.Text = "";
        GVOtherFacility.DataSource = null;
        GVOtherFacility.DataBind();
        ViewState["dtGvItemDetail"] = null;
        txtTotalfac.Text = "";
        ddlOtherFac.ClearSelection();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {       
         try
        {
            if (GVOtherFacility.Rows.Count == 0)
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Other Facility Detail Can Not be Blank";
                return;
            }
            objpl = new PL_SchAreaDetail()
            {
                Ind = 3,
                CityCode = 1,
                UserID = 1,
                dt = (DataTable)ViewState["dtGvItemDetail"],
            };

            DataSet ds =Estate_CLSCommon.CallApiPostDS("AreaDetail/SaveData", objpl);
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.InnerHtml = "Record Inserted Successfully";
                    ViewState["dtGvItemDetail"] = null;
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
    protected void GVOtherFacility_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DeleteRow")
            {
                dtitems = VsdtGvItemDetail;
                dtitems.Rows[rowIndex].Delete();

                VsdtGvItemDetail = dtitems;
                GVOtherFacility.DataSource = dtitems;
                GVOtherFacility.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
        CalculateTotal();
    }
}