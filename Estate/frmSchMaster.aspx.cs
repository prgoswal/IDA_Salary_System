using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_frmSchMaster : System.Web.UI.Page
{
    PL_Scheme plobj = new PL_Scheme();

    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        if (!IsPostBack)
        {
            FillddlUseType();
            FillddlDevCate();
            FillddlDeveloper();
        }
    }

    public void FillddlUseType()
    {
        plobj = new PL_Scheme()
       {
           Ind = 1
       };
        DataTable dt =Estate_CLSCommon.CallApiPost("Scheme/FillddlUseType", plobj);
        if(dt != null)
        {
        if(dt.Rows.Count > 0)
        {           
            ddlSchUseType.DataTextField = "UseDescE";
            ddlSchUseType.DataValueField = "UseCode";
            ddlSchUseType.DataSource = dt;
            ddlSchUseType.DataBind();          
        }
        }
        else
        {
            ddlSchUseType.DataSource = null;
            ddlSchUseType.DataBind();
        }
        ddlSchUseType.Items.Insert(0, new ListItem("------ Select Use Type ------","0"));
    }

    public void FillddlDevCate()
    {
        plobj = new PL_Scheme()
        {
            Ind = 2
        };
        DataTable dt =Estate_CLSCommon.CallApiPost("Scheme/FillddlDevCate", plobj);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlSchDevCat.DataTextField = "DevCateDescE";
                ddlSchDevCat.DataValueField = "DevCateCode";
                ddlSchDevCat.DataSource = dt;
                ddlSchDevCat.DataBind();               
            }
        }
        else
        {
            ddlSchDevCat.DataSource = null;
            ddlSchDevCat.DataBind();
        }       
        ddlSchDevCat.Items.Insert(0, new ListItem("------ Select Develop Category ------", "0"));
    }

    public void FillddlDeveloper()
    {
        plobj = new PL_Scheme()
        {
            Ind = 3
        };
        DataTable dt =Estate_CLSCommon.CallApiPost("Scheme/FillddlDeveloper", plobj);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlSchDev.DataTextField = "DeveloperDescE";
                ddlSchDev.DataValueField = "DeveloperCode";
                ddlSchDev.DataSource = dt;
                ddlSchDev.DataBind();               
            }
        }
        else
        {
            ddlSchDev.DataSource = null;
            ddlSchDev.DataBind();
        }     
        ddlSchDev.Items.Insert(0, new ListItem("------ Select Scheme Develop ------", "0"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {        
        if(txtSchNameE.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Scheme Name English";
            txtSchNameE.Focus();
            return;
        }
        if (txtSchNameH.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Scheme Name Hindi";
            txtSchNameH.Focus();
            return;
        }
        if (ddlSchUseType.SelectedIndex == 0)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Select Scheme Use Type";
            ddlSchUseType.Focus();
            return;
        }
        if (txtSchNo.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Scheme No";
            txtSchNo.Focus();
            return;
        }
        double MSchArea = 0;
        double MPlotArea = 0;
        if (txtTotalSchArea.Text != "")
        {
            double SchArea = Convert.ToDouble(txtTotalSchArea.Text);
             MSchArea = SchArea / 0.8361;
        }
            else
        {
            MSchArea = 0;
        }

        if (txtTotalPlotArea.Text != "")
        {
            double PlotArea = Convert.ToDouble(txtTotalPlotArea.Text);
             MPlotArea = PlotArea / 0.8361;
        }
            else
        {
            MPlotArea = 0;
        }
            plobj = new PL_Scheme();          
            plobj.Ind = 4;
            plobj.CityCode = 1;//Convert.ToInt32(Session["CityCode"]);
            plobj.SchNameE =txtSchNameE.Text=="" ? "" : txtSchNameE.Text;
            plobj.SchNameH = txtSchNameH.Text == "" ? "" : txtSchNameH.Text;
            plobj.Location = txtSchLoc.Text == "" ? "" : txtSchLoc.Text;
            plobj.SchUseCode =ddlSchUseType.SelectedValue == "" ? 0 : Convert.ToInt32(ddlSchUseType.SelectedValue);
            plobj.SchNoDesc = txtSchNo.Text == "" ? "" : txtSchNo.Text;
            plobj.DevCtyID = ddlSchDevCat.SelectedValue == "0" ? 0 : Convert.ToInt32(ddlSchDevCat.SelectedValue);
            plobj.DevloperID = ddlSchDev.SelectedValue == "0" ? 0 : Convert.ToInt32(ddlSchDev.SelectedValue);                  
            plobj.Aprno =txtAppno.Text == "" ? "" : txtAppno.Text;
            plobj.AprDate =txtAppDate.Text=="" ?"": txtAppDate.Text;
            plobj.AprName =txtAppby.Text==""?"": txtAppby.Text;
            plobj.ActiveInd = 1;
            plobj.EntryUserID = 1;
            plobj.TotalSchAreaSqYard =txtTotalSchArea.Text == "" ? 0 : Convert.ToDecimal(txtTotalSchArea.Text.Trim());
            plobj.TotalSchAreaSqMeter =Convert.ToDecimal(MSchArea);
            plobj.TotalSchAreaString = "";
            plobj.TotalPlotingAreaSqyard =txtTotalPlotArea.Text=="" ? 0 : Convert.ToDecimal(txtTotalPlotArea.Text.Trim());
            plobj.TotalPlotingAreaSqMeter = Convert.ToDecimal(MPlotArea);          
            plobj.TotalPlotingAreaString ="";
            plobj.IDASchNo = Convert.ToInt32(txtIDASchNo.Text);
            if(rdbSectorAval.SelectedValue == "0")
            {
                plobj.SectorAval = 0;
            }
            else
            {
                plobj.SectorAval = 1;
            }
            if(rdbPlotAval.SelectedValue == "0")
            {
                plobj.PlotAval = 0;
            }
            else
            {
                plobj.PlotAval = 1;
            }
       
        DataTable dt =Estate_CLSCommon.CallApiPost("Scheme/SaveScheme", plobj);
        if (dt != null)
        {
            if (dt.Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Inserted Successfully";
                Clear();
                return;
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

    public void Clear()
    {
        txtSchNameE.Text = "";
        txtSchNameH.Text = "";
        txtSchLoc.Text = "";
        ddlSchUseType.ClearSelection();
        txtSchNo.Text = "";
        ddlSchDevCat.ClearSelection();
        ddlSchDev.ClearSelection();
        txtAppno.Text = "";
        txtAppDate.Text = "";
        txtAppby.Text = "";
        rdbSectorAval.SelectedValue = "0";
        rdbPlotAval.SelectedValue = "0";
        txtTotalPlotArea.Text = "";
        txtTotalSchArea.Text = "";
        txtIDASchNo.Text = "";
    }   

    protected void btnclear_Click(object sender, EventArgs e)
     {
        Clear();
    }    
}