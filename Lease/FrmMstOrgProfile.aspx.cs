using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmMstOrgProfile : System.Web.UI.Page
{
    PL_OrgProfile objpl;
    DataTable dt = null;
    DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlSuccess.Visible = false;
        pnlfailed.Visible = false;
        if (!IsPostBack)
        {
            fillOrgName();
            //fillallComboInformation();          
        }
    }
    public void fillOrgName()
    {
        objpl = new PL_OrgProfile();
        objpl.Ind = 2;
        ds = new DataSet();
        ds = Lease_CLSCommon.CallApiGet("api/OrgProfile/ddl_fill?Ind=" + objpl.Ind);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlOrgName.DataSource = ds.Tables[0];
                ddlOrgName.DataTextField = "OrganizationNameE";
                ddlOrgName.DataValueField = "OrgCode";
                ddlOrgName.DataBind();
                ddlOrgName.Items.Insert(0, new ListItem("--SELECT--", "0"));
                ddlOrgName.SelectedIndex = 0;
            }
            else
            {
                ddlOrgName.DataSource = null;              
                ddlOrgName.DataBind();
            }           
        }

    }
    public void Clear()
    {
        rbtDevCateNo.Checked = true;
        rbtDevNameNo.Checked = true;
        rbtWardNo.Checked = true;
        rbtZoneNo.Checked = true;
        ddlOrgName.SelectedIndex = 0;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlOrgName.SelectedIndex == 0)
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Please Select Organization Name";
            return;
        }
        else
        objpl = new PL_OrgProfile();

        objpl.Ind = 1;
        if(rbtDevCateNo.Checked==true)
        {
            objpl.DevCateInd = 0;
        }else
            objpl.DevCateInd = 1;

        if (rbtDevNameYes.Checked == true)
        {
            objpl.DevNameAppliInd = 1;
        }
        else
            objpl.DevNameAppliInd = 0;

        if (rbtWardYes.Checked == true)
        {
            objpl.WardAppliInd = 1;
        }
        else
            objpl.WardAppliInd = 0;

        if (rbtZoneYes.Checked == true)
        {
            objpl.ZoneAppliInd = 1;
        }
        else
            objpl.ZoneAppliInd = 0;
       
           objpl.OrgCode = 0;
        objpl.OrgCode=Convert.ToInt32(ddlOrgName.SelectedValue.ToString());
        dt = new DataTable();
        dt = Lease_CLSCommon.CallApiPost("api/OrgProfile/SubmitOrgPrifile", objpl);
          if (dt != null && dt.Rows.Count > 0)
          {
              if ((dt.Rows[0]["res"]).ToString()=="1")
              {
                  pnlSuccess.Visible = true;
                   pnlfailed.Visible = false;

                  pnlSuccess.InnerHtml = "Submit Successfully Saved";
                  Clear();
              }
              else if ((dt.Rows[0]["res"]).ToString() == "0")
              {
                  pnlfailed.Visible = true;
                  pnlfailed.InnerHtml=("Organization Allraedy Exist");
              }
          }
          else
          {
              pnlfailed.Visible = true;
              pnlfailed.InnerHtml = ("Not Submit Successfully");
          }
        
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Clear();

    }
    protected void btnExit0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}