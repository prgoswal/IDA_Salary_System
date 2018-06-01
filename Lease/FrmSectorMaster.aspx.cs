using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class FrmSectorMaster : System.Web.UI.Page
{

    PL_SectMaster objpl = new PL_SectMaster();
   // Bl_Sector objblsector = new Bl_Sector();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            //if (Convert.ToInt32(Session["CityCode"]) == 0 || Convert.ToString(Session["CityCode"]) == "" || Convert.ToString(Session["CityCode"]) == null || Convert.ToString(Session["UserCode"]) == "" || Convert.ToString(Session["UserCode"]) == null || Convert.ToInt32(Session["UserCode"]) == 0)
            //{
            //    Response.Redirect("Default2.aspx");

            //}
            //else
            //{
                DDLWard();
            //}
        }

    }
    protected void DDlWardNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlSchemeName.Items.Clear();
        if (DDlWardNo.SelectedIndex > 0)
        {
            FillScheme();

        }

    }
    DataSet ds = null;

    public void DDLWard()
    {
        objpl.ind = 3;
      
        int CityId = Convert.ToInt32(Session["CityCode"]);
        ds = new DataSet();
        ds = Lease_CLSCommon.CallApiGet("api/SectorMaster/SectorMaster_FillWard?ind=3&CityId=" + CityId);
      //  objblsector.Bl_FillWard(objpl);

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {

                DDlWardNo.DataSource = ds.Tables[0];
                DDlWardNo.DataTextField = "Ward";
                DDlWardNo.DataValueField = "WardNo";
                DDlWardNo.DataBind();
                DDlWardNo.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                DDlWardNo.Items.Clear();

            }
        }
        else
        {
            DDlWardNo.Items.Clear();


        }




    }



    public void FillScheme()
    {

        objpl.ind = 4;
       // objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        int CityId = Convert.ToInt32(Session["CityCode"]);
        objpl.WardNo = Convert.ToInt32(DDlWardNo.SelectedValue);
        ds = Lease_CLSCommon.CallApiGet("api/SectorMaster/SectorMaster_FillScheme?ind=4&CityId=" + CityId + "&WardNo=" + objpl.WardNo);
       // objblsector.Bl_FillScheme(objpl);



        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                DDlSchemeName.DataSource = ds.Tables[0];
                DDlSchemeName.DataTextField = "SchName";
                DDlSchemeName.DataValueField = "SchID";
                DDlSchemeName.DataBind();
                DDlSchemeName.Items.Insert(0, new ListItem("--Select--", "0"));



            }
            else
            {
                DDlSchemeName.Items.Clear();

            }
        }
        else
        {
            DDlSchemeName.Items.Clear();

        }




    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (DDlWardNo.Items.Count > 0 && DDlWardNo.SelectedIndex == 0)
        {
            LblMsg.Text = "Select WardNo...!!";
            DDlWardNo.Focus();
            return;


        }

        if (DDlSchemeName.Items.Count > 0 && DDlSchemeName.SelectedIndex == 0)
        {
            LblMsg.Text = "Select Scheme...!!";
            DDlSchemeName.Focus();
            return;


        }
        if (txtSector.Text.Trim() == "")
        {
            LblMsg.Text = "Insert Sector...!!";
            txtSector.Focus();
            return;

        }
        objpl.ind = 1;
        objpl.WardNo = Convert.ToInt32(DDlWardNo.SelectedValue);

        objpl.SchId = Convert.ToInt32(DDlSchemeName.SelectedValue);
       
        objpl.SectorDesc = txtSector.Text.Trim().ToUpper();
       
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
    
        objpl.UserID = Convert.ToInt32(Session["UserCode"]); 
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt = Lease_CLSCommon.CallApiPost("api/SectorMaster/SaveSector", objpl);
        if (dt != null)
        {
            LblMsg.Text = "Record Saved...!!";
            Clear();
        }
        else
        {
            LblMsg.Text = "Record Not Inserted ";
        }

       // objblsector.Bl_SaveSector(objpl);
       

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
       // Response.Redirect("FrmSectorMaster.aspx");
        Clear();
    }
    public void Clear()
    {
        DDlWardNo.SelectedIndex = 0;
        DDlSchemeName.Items.Clear();
        txtSector.Text = "";
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
       // Response.Redirect("Home.aspx");
    }
}