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

public partial class FrmSchemeMaster : System.Web.UI.Page
{
   
   
    bool validDate = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


            //if (Convert.ToInt32(Session["CityCode"]) == 0 || Convert.ToString(Session["CityId"]) == "" || Convert.ToString(Session["CityId"]) == null || Convert.ToString(Session["UserCode"]) == "" || Convert.ToString(Session["UserCode"]) == null || Convert.ToInt32(Session["UserCode"]) == 0)
            //{
            //    Response.Redirect("Default2.aspx");

            //}
            //else
            //{
                
            mst_zone();
                //mst_developer();
                // mst_scheme_use();
                //mst_unit1();
                //mst_unit2();
                // mst_unit3();
                //  mst_unit4();
            //FillWard();

          
            ddl_developer_name.SelectedIndex = 0;
           // }
           
        }
    }
    PL_SCHMaster objpl = new PL_SCHMaster(); 
    public void mst_zone()
    {
        try
        {
            //objpl.ind = 1;

            //objpl.city_id = Convert.ToInt32(Session["CityCode"]);
            //objblscheme.sp_ddl_fill(objpl);
            int CityId = Convert.ToInt32(Session["CityCode"]);
            DataSet ds = Lease_CLSCommon.CallApiGet("api/SchemeMaster/SchemeMaster_Fillddl?ind=1&CityId=" + CityId);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl_zone.DataSource = ds.Tables[0];
                    ddl_zone.DataTextField = "ZName";
                    ddl_zone.DataValueField = "Zone";
                    ddl_zone.DataBind();
                    ddl_zone.Items.Insert(0, new ListItem("--SELECT--"));

                }
                else
                {
                    ddl_zone.Items.Clear();

                }


                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddl_developer_type.DataSource = ds.Tables[2];
                    ddl_developer_type.DataTextField = "DevTypeDesc";
                    ddl_developer_type.DataValueField = "DevTypeId";
                    ddl_developer_type.DataBind();
                    ddl_developer_type.Items.Insert(0, new ListItem("--SELECT--"));

                }
                else
                {
                    ddl_developer_type.Items.Clear();


                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddl_scheme_use1.DataSource = ds.Tables[3];
                    ddl_scheme_use1.DataTextField = "UseDesc";
                    ddl_scheme_use1.DataValueField = "UseId";
                    ddl_scheme_use1.DataBind();
                    ddl_scheme_use1.Items.Insert(0, new ListItem("--SELECT--"));

                }
                else
                {
                    ddl_zone.Items.Clear();

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddl_unit.DataSource = ds.Tables[1];
                    ddl_unit.DataTextField = "UnitDesc";
                    ddl_unit.DataValueField = "UnitId";
                    ddl_unit.DataBind();
                    ddl_unit.Items.Insert(0, new ListItem("--SELECT--"));


                    ddl_unit2.DataSource = ds.Tables[1];
                    ddl_unit2.DataTextField = "UnitDesc";
                    ddl_unit2.DataValueField = "UnitId";
                    ddl_unit2.DataBind();
                    ddl_unit2.Items.Insert(0, new ListItem("--SELECT--"));


                    ddl_unit3.DataSource = ds.Tables[1];
                    ddl_unit3.DataTextField = "UnitDesc";
                    ddl_unit3.DataValueField = "UnitId";
                    ddl_unit3.DataBind();
                    ddl_unit3.Items.Insert(0, new ListItem("--SELECT--"));


                    ddl_unit4.DataSource = ds.Tables[1];
                    ddl_unit4.DataTextField = "UnitDesc";
                    ddl_unit4.DataValueField = "UnitId";
                    ddl_unit4.DataBind();
                    ddl_unit4.Items.Insert(0, new ListItem("--SELECT--"));

                   

                }
                else
                {
                    ddl_unit.Items.Clear();
                    ddl_unit2.Items.Clear();
                    ddl_unit3.Items.Clear();
                    ddl_unit4.Items.Clear();

                }
                if (ds.Tables[6].Rows.Count > 0)
                {

                    ddl_Ward.DataSource = ds.Tables[6];
                    ddl_Ward.DataTextField = "Ward";
                    ddl_Ward.DataValueField = "WardNo";
                    ddl_Ward.DataBind();
                    ddl_Ward.Items.Insert(0, new ListItem("--SELECT--"));


                }
                else
                {
                    ddl_Ward.Items.Clear();

                }


            }




        }
        catch (Exception ex)
        { }
       //
     

    }

    public void FillWard()
    {
        DataSet DS = new DataSet();
        //objpl.ind = 3;
        //objpl.city_id = Convert.ToInt32(Session["CityId"]);
        //objblscheme.FillWard(objpl);
        int CityId = 1001035;
        DS = Lease_CLSCommon.CallApiGet("api/SchemeMaster/FillWard?ind=3&CityId=" + CityId);
        if (DS != null)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {

                ddl_Ward.DataSource = DS.Tables[0];
                ddl_Ward.DataTextField = "Ward";
                ddl_Ward.DataValueField = "WardNo";
                ddl_Ward.DataBind();
                ddl_Ward.Items.Insert(0, new ListItem("--SELECT--"));


            }
            else
            {
                ddl_Ward.Items.Clear();

            }

        }
        else
        {

            ddl_Ward.Items.Clear();
        }



    }

    public void clear()
    {
        try
        {
            txt_scheme_name.Text = "";
            Txtscheme_short_name.Text = "";
            ddl_zone.SelectedIndex = 0;
            ddl_developer_type.SelectedIndex = 0;
            ddl_developer_type.SelectedIndex = 0;
            ddl_scheme_use1.SelectedIndex = 0;
            ddl_developer_name.SelectedIndex = 0;
            ddl_developer_type.SelectedIndex = 0;
            ddl_Ward.SelectedIndex = 0;
            ddl_unit.SelectedIndex = 0;
            txt_secemelocation.Text = "";
            txtapprovalno1.Text = "";
            txtappdate.Text = "";
            txt_total_area.Text = "";
            ddl_unit2.SelectedIndex = 0;
            ddl_unit3.SelectedIndex = 0;
            ddl_unit4.SelectedIndex = 0;
            txt_Residental_Area.Text = "";
            txt_commersial_area.Text = "";
            txt_internal_area.Text = "";
            //LblMsg.Text="";
            TxtCCCode.Text = "";


        }
        catch (Exception ex)
        { }

    }

    protected void btnclear_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Frm_Scheme_master.aspx");
    }

    protected void cstmDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!CstmDate.cstm_DateValidation(source, args, Page))
            if (validDate == true)
                validDate = false;
    }



 

    public void mst_developer_name()
    {
        try
        {
            DataSet DS = new DataSet();
            objpl.ind = 2;
            objpl.developer_id = Convert.ToInt16(ddl_developer_type.SelectedValue.ToString());

            //   objblscheme.sp_ddl_filldevelopername(objpl);

            DataSet ds = Lease_CLSCommon.CallApiGet("api/SchemeMaster/filldevelopername?ind=2&developer_id=" + objpl.developer_id);
            if (DS != null)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ddl_developer_name.DataSource = DS.Tables[0];
                    ddl_developer_name.DataTextField = "DevnameDesc";
                    ddl_developer_name.DataValueField = "DevNameId";
                    ddl_developer_name.DataBind();
                    ddl_developer_name.Items.Insert(0, new ListItem("--SELECT--"));
                    ddl_developer_name.Focus();

                }
                else
                {
                    ddl_developer_name.Items.Clear();
                }
            }
            else
            {
                ddl_developer_name.Items.Clear();
            }




        }
        catch (Exception ex)
        { }

    }







    protected void ddl_developer_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            mst_developer_name();
            ddl_developer_name.Focus();
        }
        catch (Exception ex)
        { }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        LblMsg.Text = "";
        LblMsg.Visible = true;
        try
        {
            LblMsg.Text = "";
            if (txt_scheme_name.Text.Trim() == "")
            {
                LblMsg.Text = "Insert Scheme Name";
                txt_scheme_name.Focus();
                return;
            }

            if (ddl_zone.SelectedIndex == 0)
            {
                LblMsg.Text = "Insert Zone";
                ddl_zone.Focus();
                return;

            }
            if (ddl_Ward.SelectedIndex == 0 && ddl_Ward.Items.Count > 0)
            {
                LblMsg.Text = "Select Ward";
                ddl_Ward.Focus();
                return;
            }
            if (ddl_developer_type.Items.Count > 0 && ddl_developer_type.SelectedIndex == 0)
            {
                LblMsg.Text = "Insert Devloper Type";
                ddl_developer_type.Focus();
                return;

            }

            if (ddl_developer_type.Items.Count > 0)
            {
                if (ddl_developer_name.Items.Count > 0 && ddl_developer_name.SelectedIndex == 0)
                {
                    if (ddl_developer_type.Items.Count > 0 && ddl_developer_type.SelectedIndex == 0)
                    {
                        LblMsg.Text = "Insert Devloper Name";
                        ddl_developer_type.Focus();
                        return;

                    }

                }

            }


            if (TxtCCCode.Text.Trim() == "")
            {
                LblMsg.Text = "Insert CostCenter Code ...!!!!";
                TxtCCCode.Focus();
                return;

            }

            objpl.ind = 1;
           
            objpl.city_id = Convert.ToInt32(Session["CityCode"]);
            objpl.user_id = Convert.ToString(Session["UserCode"]);
            objpl.SchName = txt_scheme_name.Text.ToUpper();
            objpl.SchShortName= Txtscheme_short_name.Text.ToUpper();
            if (ddl_zone.SelectedIndex > 0 && ddl_zone.Items.Count > 0)
            {
                objpl.zone_id = Convert.ToInt32(ddl_zone.SelectedValue.ToString());
            }
            if (ddl_developer_type.SelectedIndex > 0 && ddl_developer_type.Items.Count > 0)
            {
                objpl.developer_id = Convert.ToInt32(ddl_developer_type.SelectedValue.ToString());
            }
            if (ddl_developer_name.SelectedIndex > 0 && ddl_developer_name.Items.Count > 0)
            {
                objpl.developer_name_id = Convert.ToInt32(ddl_developer_name.SelectedValue.ToString());
            }
            if (ddl_scheme_use1.Items.Count > 0 && ddl_scheme_use1.SelectedIndex > 0)
            {
                objpl.seheme_id = Convert.ToInt32(ddl_scheme_use1.SelectedValue.ToString());
            }
            objpl.schemelocation = txt_secemelocation.Text.ToUpper();
            objpl.approvalno = (txtapprovalno1.Text.ToUpper());
            if (txtappdate.Text.Trim() != "")
            {
                objpl.approval_date = CstmDate.yyyyMMddDate(txtappdate.Text.ToString());
            }
            objpl.total_area = (txt_total_area.Text);
            if (ddl_unit.Items.Count > 0 && ddl_unit.SelectedIndex > 0)
            {
                objpl.unit_id = Convert.ToInt32(ddl_unit.SelectedValue.ToString());
            }
            objpl.residental_area = txt_Residental_Area.Text;
            objpl.commersial_area = txt_commersial_area.Text;
            objpl.internal_area = txt_internal_area.Text;
            if (ddl_unit2.SelectedIndex > 0 && ddl_unit2.Items.Count > 0)
            {
                objpl.unit_id2 = Convert.ToInt32(ddl_unit2.SelectedValue.ToString());
            }

            if (ddl_unit3.SelectedIndex > 0 && ddl_unit3.Items.Count > 0)
            {
                objpl.unit_id3 = Convert.ToInt32(ddl_unit3.SelectedValue.ToString());
            }
            if (ddl_unit4.SelectedIndex > 0 && ddl_unit4.Items.Count > 0)
            {
                objpl.unit_id4 = Convert.ToInt32(ddl_unit4.SelectedValue.ToString());
            }
            if (ddl_Ward.SelectedIndex > 0 && ddl_Ward.Items.Count > 0)
            {
                objpl.WardNo = Convert.ToInt32(ddl_Ward.SelectedValue);
            }


            objpl.CCCode = Convert.ToInt32(TxtCCCode.Text.Trim());

            int a = 0;
            DataSet ds = Lease_CLSCommon.CallApiPostDS("api/SchemeMaster/SaveMstScheme", objpl);
         //   a = objblscheme.spMstScheme(objpl);
            if (ds!=null)
            {
                LblMsg.Text = "Record Inserted Successfully";
                LblMsg.CssClass = "alertMsg success";
                clear();
            }
            else
            {
                LblMsg.Text = "Record Not Inserted ";
            }


        }
        catch (Exception ex)
        {
            LblMsg.Text = "Enter Valid Date";
        }

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {

        clear();
        LblMsg.Text = "";
        //Response.Redirect("Frm_Scheme_master.aspx");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Home.aspx");
    }

  
}