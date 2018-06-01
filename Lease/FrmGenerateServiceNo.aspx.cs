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
using System.IO;

public partial class FrmGenerateServiceNo : System.Web.UI.Page
{
    PL_GenerateServiceNo objpl;
    DataTable dt = null;
    DataSet ds = null;
    DataSet dsxml;
    FileInfo file;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserId"] == null)
        //{
        //    Response.Redirect("FrmLogin.aspx");
        //}
        objpl = new PL_GenerateServiceNo();
        //DL_ServiceNo = new DL_GenerateServiceNo();
        //BL_ServiceNo = new BL_GenerateServiceNo();
        if (!IsPostBack)
        {
            fillZone();

            //fillallComboInformation();
            fillComboboxPlotUse();
            PanelSingle.Visible = true;
            PanelMultipal.Visible = false;
        }
    }



    public void fillComboboxPlotUse()
    {
        //SchDevTypeid
        //citycode
        objpl.Ind = 8;
        objpl.PassId = 0;
        objpl.SchDevTypeid = 0;
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
        //BL_ServiceNo.ComboInformation(objpl);int CityCode, int PassId, int SchDevTypeid)
        dt = new DataTable();
       // dt = CLSCommon.CallApiGetdt("api/GenerateServiceNo/FillAllInformation?Ind=" + objpl.Ind);
        dt = Lease_CLSCommon.CallApiGetdt("api/GenerateServiceNo/FillAllInformation?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode + "&PassId=" + objpl.PassId + "&SchDevTypeid=" + objpl.SchDevTypeid);
        if (dt != null)
        {
            ddlPlotUse.DataSource = dt;
            ddlPlotUse.DataTextField = Convert.ToString(dt.Columns["UseDesc"]);
            ddlPlotUse.DataValueField = Convert.ToString(dt.Columns["UseId"]);
            ddlPlotUse.DataBind();
            ddlPlotUse.Items.Insert(0, new ListItem("--SELECT--", "0"));
            ddlPlotUse.SelectedIndex = 0;
        }
    }
    public void fillZone()
    {
        objpl.Ind = 31;
       // objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]); ;
        //   BL_ServiceNo.FillZone(objpl);
        ds = new DataSet();
        ds = Lease_CLSCommon.CallApiGet("api/GenerateServiceNo/FillZone?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null  && ds.Tables.Count>0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlZone.DataSource = ds.Tables[0];
                ddlZone.DataTextField = "Zname";
                ddlZone.DataValueField = "Zone";
                ddlZone.DataBind();
                ddlZone.Items.Insert(0, new ListItem("--SELECT--", "0"));
                ddlZone.SelectedIndex = 0;

            }
            else
            {
                ddlZone.Items.Clear();

            }


            if (ds.Tables[1].Rows.Count > 0)
            {


                ddlSchemeType.DataSource = ds.Tables[1];
                ddlSchemeType.DataTextField = "devTypeDesc";
                ddlSchemeType.DataValueField = "Devtypeid";
                ddlSchemeType.DataBind();
                ddlSchemeType.Items.Insert(0, new ListItem("--SELECT--", "0"));
                ddlSchemeType.SelectedIndex = 0;



            }
            else
            {
                ddlSchemeType.Items.Clear();

            }
        }

    }




    #region Filling ComboInformation
    public void fillallComboInformation()
    {
        for (int i = 1; i <= 1; i++)
        {
            objpl.Ind = Convert.ToInt32(i);
            objpl.PassId = 0;
            objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
            //objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
            objpl.SchDevTypeid = 0;
          //  BL_ServiceNo.ComboInformation(objpl);
            dt = Legal_CLSCommon.CallApiGetdt("api/GenerateServiceNo/FillAllInformation?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode + "&PassId=" + objpl.PassId + "&SchDevTypeid=" + objpl.SchDevTypeid);
            //dt = CLSCommon.CallApiGetdt("api/GenerateServiceNo/FillAllInformation?Ind=" + objpl.Ind);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (i == 1)
                    {
                        ddlZone.DataSource = dt;
                        ddlZone.DataTextField = Convert.ToString(dt.Columns["Zname"]);
                        ddlZone.DataValueField = Convert.ToString(dt.Columns["Zone"]);
                        ddlZone.DataBind();
                        ddlZone.Items.Insert(0, new ListItem("--SELECT--", "0"));
                        ddlZone.SelectedIndex = 0;
                    }
                    else if (i == 2)
                    {
                        ddlSchemeType.DataSource = dt;
                        ddlSchemeType.DataTextField = Convert.ToString(dt.Columns["devTypeDesc"]);
                        ddlSchemeType.DataValueField = Convert.ToString(dt.Columns["Devtypeid"]);
                        ddlSchemeType.DataBind();
                        ddlSchemeType.Items.Insert(0, new ListItem("--SELECT--", "0"));
                        ddlSchemeType.SelectedIndex = 0;
                    }
                    //else if (i == 4)
                    //{
                    //    ddlSector.DataSource = dt;
                    //    ddlSector.DataTextField = Convert.ToString(dt.Columns["sectorDesc"]);
                    //    ddlSector.DataValueField = Convert.ToString(dt.Columns["sectorid"]);
                    //    ddlSector.DataBind();
                    //    ddlSector.Items.Insert(0, new ListItem("--SELECT--", "0"));
                    //    ddlSector.SelectedIndex = 0;
                    //}
                }
            }
        }
    }
    #endregion

    #region FIX Information
    protected void cBoxFix_CheckedChanged(object sender, EventArgs e)
    {
        if (cBoxFix.Checked)
        {
            ddlZone.Enabled = false;
            ddlSchemeName.Enabled = false;
            ddlSector.Enabled = false;
            ddlSchemeType.Enabled = false;

        }

        else
        {
            ddlZone.Enabled = true;
            ddlSchemeName.Enabled = true;
            ddlSector.Enabled = true;
            ddlSchemeType.Enabled = true;
        }
    }
    #endregion

    #region Insert Service Number
    protected void bttSave_Click(object sender, ImageClickEventArgs e)
    {



    }
    #endregion

    #region Clear All Information
    protected void bttClear_Click(object sender, EventArgs e)
    {
        //file:///D:\Development\JDALeaseFinal14.07.2009\JdaLeaseJaipur\App_Code\XMLConn1.cs
        txtPlotNo.Text = "";
        lblServiceNo.Visible = false;
        lblMesg.Visible = false;
        if (cBoxFix.Checked)
        {
            cBoxFix.Checked = false;
            cBoxFix_CheckedChanged(sender, e);
            cBoxFix.Checked = false;
        }
        else if (cBoxFix.Checked == false)
        {
            ddlSchemeName.SelectedValue = "0";
            ddlSchemeType.SelectedValue = "0";
            ddlSector.SelectedValue = "0";
            ddlZone.SelectedValue = "0";
        }
        if (rbttMorethenon.Checked)
        {
            txtPlotNoFrom.Text = "";
            txtPlotNoTo.Text = "";
            txtFpost.Text = "";
            txtFpre.Text = "";
            txtTpost.Text = "";
            txtTpre.Text = "";
            PanelgetSno.Visible = false;
            lblMesg.Visible = false;
        }
        if (rbttMultipal.Checked)
        {
            txtSpost.Text = "";
            txtPlotNo.Text = "";
            txtPlotNoFrom.Text = "";
            txtPlotNoTo.Text = "";
            txtFpost.Text = "";
            txtTpost.Text = "";
            txtFpre.Text = "";
            txtTpre.Text = "";
            PanelgetSno.Visible = false;
            lblMesg.Visible = false;
        }
        if (rbttSingle.Checked)
        {
            txtSpost.Text = "";
            txtSPre.Text = "";
            txtPlotNo.Text = "";
            PanelgetSno.Visible = false;
            lblMesg.Visible = false;
        }

    }
    #endregion

    #region Redio Button Change
    protected void rbttSingle_CheckedChanged(object sender, EventArgs e)
    {
        PanelSingle.Visible = true;
        PanelMultipal.Visible = false;
        //txtFpost.Text="";
        //txtFpre.Text = "";
        txtPlotNoFrom.Text = "";
        txtTpost.Text = "";
        txtPlotNoTo.Text = "";
        txtTpre.Text = "";
        PanelgetSno.Visible = false;
    }
    protected void rbttMorethenon_CheckedChanged(object sender, EventArgs e)
    {
        PanelSingle.Visible = false;
        PanelMultipal.Visible = true;
        txtSpost.Text = "";
        txtPlotNo.Text = "";
        txtPlotNoFrom.Text = "";
        txtPlotNoTo.Text = "";
        txtFpost.Text = "";
        txtTpost.Text = "";
        txtFpre.Text = "";
        txtTpre.Text = "";
        txtPlotNoTo.Enabled = true;
        PanelgetSno.Visible = false;

    }
    #endregion

    #region TextBox Text Change
    //protected void TextBox3_TextChanged(object sender, EventArgs e)
    //{
    //        txtTpre.Text=txtFpre.Text;
    //}
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        if (rbttMorethenon.Checked)
        {
            txtTpost.Enabled = false;
            txtTpost.Text = txtFpost.Text;
            txtPlotNoTo.Focus();
        }
        else if (rbttMultipal.Checked)
        {
            txtTpost.Enabled = true;
            txtTpost.Focus();

        }
    }
    #endregion

    #region Get Multi Service Number
    protected void bttserviceNo_Click(object sender, EventArgs e)
    {
        if (rbttMorethenon.Checked)
        {
            string table;
            int ftxt, ttxt, diff;
            ftxt = Convert.ToInt32(txtPlotNoFrom.Text);
            ttxt = Convert.ToInt32(txtPlotNoTo.Text);
            diff = ttxt - ftxt;
            objpl.Ind = 6;
            objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
            objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
            objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString());
            objpl.Useid = Convert.ToInt32(ddlPlotUse.SelectedValue.ToString());
          //  objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
            objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
            if (ddlSector.SelectedValue.ToString() != "")
            {
                objpl.Sectorid = Convert.ToInt32(ddlSector.SelectedValue.ToString());
            }
            else
            {
                objpl.Sectorid = 0;
            }
            objpl.PlotNo = txtPlotNoFrom.Text;
            if (txtFpre.Text != "")
            {
                objpl.PreFix = txtFpre.Text;
            }
            else
            {
                objpl.PreFix = "";
            }
            if (txtFpost.Text != "")
            {
                objpl.PostFix = txtFpost.Text;
            }
            else
            {
                objpl.PostFix = "";
            }

            objpl.Diff = diff + 1;
            // BL_ServiceNo.GetallServiceNo(objpl);
            dt = new DataTable();
            dt = Legal_CLSCommon.CallApiPost("api/GenerateServiceNo/GetallServiceNo", objpl);
           
            if (dt!=null && dt.Rows.Count > 0)
            {
                lblServiceNo.Text = "";
                PanelgetSno.Visible = true;
                table = " <table border='0' >";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    table += "<tr>";
                    table += "<td align='left' width='200px'>Plot Number: " + dt.Rows[i]["PoltNo"].ToString();
                    table += "</td>";
                    if (dt.Rows[i]["ServiceNo"].ToString() == "0")
                    {
                        table += "<td align='left' width='400px'>Plot Already Exists";

                    }
                    else
                    {
                        table += "<td align='left' width='400px'>Service Number: " + dt.Rows[i]["ServiceNo"];

                    }
                    table += "</td>";
                    table += "</tr>";
                    //  ftxt++;
                }
                table += "<tr>";
                table += "<td align='left' width='200px'>Service Number";
                table += "</td><td align='left' width='400px'>0 Shows Duplicate Entry</td>";
                table += "</table>";
                lblServiceNo.Visible = true;
                lblServiceNo.Text = table;
                Session["getServicno"] = dt;
            }
        }
        else if (rbttMultipal.Checked)
        {
            string table;
            char pre = Convert.ToChar(txtFpost.Text.ToString().ToUpper());
            char post = Convert.ToChar(txtTpost.Text.ToString().ToUpper());
            int fromAsc = Convert.ToInt32(pre);
            int toAsc = Convert.ToInt32(post);
            objpl.Ind = 9;
            objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
            objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
            objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString());
           // objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
            objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
            if (ddlSector.Items.Count > 0)
            {
                objpl.Sectorid = Convert.ToInt32(ddlSector.SelectedValue.ToString());

            }
            else
            {
                objpl.Sectorid = 0;

            }
            objpl.Useid = Convert.ToInt32(ddlPlotUse.SelectedValue.ToString());
            objpl.PlotNo = txtPlotNoFrom.Text;
            if (txtFpre.Text != "")
            {
                objpl.PreFix = txtFpre.Text;
            }
            else
            {
                objpl.PreFix = "";
            }
            if (txtFpost.Text != "")
            {
                objpl.AscciPre = fromAsc;
                objpl.AscciPost = toAsc;
                objpl.Diff = (toAsc - fromAsc) + 2;
                objpl.PostFix = txtFpost.Text.ToUpper();
                objpl.PostFix2 = txtTpost.Text.ToUpper();
            }
            else
            {
                objpl.PostFix = "";
            }
           // BL_ServiceNo.GetallServiceNo(objpl);
            dt = Legal_CLSCommon.CallApiPost("api/GenerateServiceNo/GetallServiceNo", objpl);
            if (dt.Rows.Count > 0)
            {
                lblServiceNo.Text = "";
                PanelgetSno.Visible = true;
                table = " <table border='1' bordercolor='#dcdcdc' width='600px'>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    table += "<tr>";
                    table += "<td align='left' width='200px'>Plot Number: " + dt.Rows[i]["PoltNo"].ToString();
                    table += "</td>";
                    if (dt.Rows[i]["ServiceNo"].ToString() == "0")
                    {
                        table += "<td align='left' width='400px'>Plot Already Exists";

                    }
                    else
                    {
                        table += "<td align='left' width='400px'>Service Number: " + dt.Rows[i]["ServiceNo"];

                    }
                    table += "</td>";
                    table += "</tr>";
                }
                table += "<tr>";
                table += "<td align='left' width='200px'>Service Number";
                table += "</td><td align='left' width='400px'>0 Shows Duplicate Entry</td>";
                table += "</table>";
                lblServiceNo.Visible = true;
                lblServiceNo.Text = table;
                Session["getServicno"] = dt;
            }


        }
    }
    #endregion

    #region Get Singel Service No
    protected void bttSServiceno_Click(object sender, EventArgs e)
    {


        objpl.Ind = 7;
        objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
        objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
        objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString());
      //  objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
        if (ddlSector.Items.Count > 0)
        {
            objpl.Sectorid = Convert.ToInt32(ddlSector.SelectedValue.ToString());
        }
        else
        {

            objpl.Sectorid = 0;
        }
        objpl.Useid = Convert.ToInt32(ddlPlotUse.SelectedValue.ToString());
        if (txtSpost.Text != "")
        {
            objpl.PlotNo = txtSPre.Text + txtPlotNo.Text + txtSpost.Text;
        }
        else if (txtSpost.Text == "")
        {
            objpl.PlotNo = txtSPre.Text + txtPlotNo.Text;
        }
        else if (txtSpost.Text == "" && txtSPre.Text == "")
        {
            objpl.PlotNo = txtPlotNo.Text;
        }
        dt = new DataTable();

        dt = Legal_CLSCommon.CallApiPost("api/GenerateServiceNo/GetSingleServiceNo", objpl); 
      
       // BL_ServiceNo.GetallServiceNo(objpl);
        if (dt!=null && dt.Rows.Count>0)
        { 
            PanelgetSno.Visible = true;
            lblServiceNo.Visible = true;
            lblServiceNo.Text = "Your Service No is :- " + dt.Rows[0]["service_no"].ToString();
            btnSave.Enabled = true;
        }
        else
        {
            PanelgetSno.Visible = true;
            lblServiceNo.Visible = true;
            lblServiceNo.Text = "Plot Already Exists ";
            btnSave.Enabled = false;
        }
    }
    #endregion

    #region Filter ComboBox
    protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        objpl.Ind = 2;
       // objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
        //objpl.PassId = Convert.ToInt32(ddlZone.SelectedValue.ToString());
        objpl.PassId = 0;
        objpl.SchDevTypeid = 0;
        dt = new DataTable();
        dt = Legal_CLSCommon.CallApiGetdt("api/GenerateServiceNo/FillAllInformation?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode + "&PassId=" + objpl.PassId + "&SchDevTypeid=" + objpl.SchDevTypeid);
       // BL_ServiceNo.ComboInformation(objpl);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                //ddlSchemeName.Enabled = true;
                //ddlSchemeName.DataSource = dt;
                //ddlSchemeName.DataTextField = Convert.ToString(dt.Columns["schname"]);
                //ddlSchemeName.DataValueField = Convert.ToString(dt.Columns["schid"]);
                //ddlSchemeName.DataBind();
                //ddlSchemeName.Items.Insert(0, new ListItem("--SELECT--", "0"));
                //ddlSchemeName.SelectedIndex = 0;
                ddlSchemeType.DataSource = dt;
                ddlSchemeType.DataTextField = Convert.ToString(dt.Columns["devTypeDesc"]);
                ddlSchemeType.DataValueField = Convert.ToString(dt.Columns["Devtypeid"]);
                ddlSchemeType.DataBind();
                ddlSchemeType.Items.Insert(0, new ListItem("--SELECT--", "0"));
                ddlSchemeType.SelectedIndex = 0;
            }
            else
            {
                //ddlSchemeName.Enabled = false;
                //ddlSchemeName.DataSource = "";
                //ddlSchemeName.DataBind();
                //ddlSector.Enabled = false;
                //ddlSector.DataSource = "";
                //ddlSector.DataBind();
                ddlSchemeType.DataSource = "";
                ddlSchemeType.DataBind();


            }
        }
    }
    protected void ddlSchemeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        objpl.Ind = 33;
        objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString()); 
         objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
      //  objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
        //    BL_ServiceNo.Fillsector(objpl);Fillsector(int CityCode, int Ind, int Zoneid)
        ds = Legal_CLSCommon.CallApiGet("api/GenerateServiceNo/Fillsector?CityCode=" + objpl.CityCode + "&Ind=" + objpl.Ind + "&Schid=" + objpl.Schid);
        if (ds != null && ds.Tables.Count>0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSector.Enabled = true;
                ddlSector.DataSource = ds.Tables[0];
                ddlSector.DataTextField = "sectorDesc";
                ddlSector.DataValueField = "sectorid";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0, new ListItem("--SELECT--", "0"));
                ddlSector.SelectedIndex = 0;
            }
            else
            {
                ddlSector.Enabled = false;
                ddlSector.DataSource = "";
                ddlSector.DataBind();
            }
        }
    }
    #endregion

    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rbttSingle.Checked)
        //{
        //    txtSPre.Text = ddlSector.SelectedItem.ToString();
        //    txtSPre.Enabled = false;
        //}
        //if (rbttMorethenon.Checked)
        //{
        //    txtFpre.Text = ddlSector.SelectedItem.ToString();
        //    txtTpre.Text = ddlSector.SelectedItem.ToString();
        //    txtFpre.Enabled = false;
        //    txtTpre.Enabled = false;
        //}
    }
    protected void txtPlotNoFrom_TextChanged(object sender, EventArgs e)
    {
        if (rbttMultipal.Checked)
        {
            if (txtPlotNoFrom.Text != "0")
            {
                txtPlotNoTo.Enabled = false;
                txtPlotNoTo.Text = txtPlotNoFrom.Text;
                txtTpost.Enabled = true;
                //txtFpost.Focus();
                txtPlotNoTo.Focus();
            }
            else
            {
                txtPlotNoFrom.Text = "";
                txtPlotNoFrom.Focus();
            }
        }
        else if (rbttMorethenon.Checked)
        {
            if (txtPlotNoFrom.Text != "0")
            {
                //txtFpost.Focus();
                txtPlotNoTo.Focus();
            }
            else
            {
                txtPlotNoFrom.Text = "";
                txtPlotNoFrom.Focus();
            }
        }
    }
    protected void rbttMultipal_CheckedChanged(object sender, EventArgs e)
    {
        PanelSingle.Visible = false;
        PanelMultipal.Visible = true;
        txtSpost.Text = "";
        txtPlotNo.Text = "";
        txtPlotNoFrom.Text = "";
        txtPlotNoTo.Text = "";
        txtFpost.Text = "";
        txtTpost.Text = "";
        txtFpre.Text = "";
        txtTpre.Text = "";
        txtFpost.MaxLength = 1;
        txtTpost.MaxLength = 1;
        PanelgetSno.Visible = false;
    }
    protected void txtFpre_TextChanged(object sender, EventArgs e)
    {
        txtTpre.Text = txtFpre.Text;
        txtPlotNoFrom.Focus();
    }
    protected void txtTpost_TextChanged(object sender, EventArgs e)
    {
        char pre = Convert.ToChar(txtFpost.Text.ToString().ToUpper());
        char post = Convert.ToChar(txtTpost.Text.ToString().ToUpper());
        int fromAsc = Convert.ToInt32(pre);
        int toAsc = Convert.ToInt32(post);
        if (toAsc < fromAsc)
        {
            txtTpost.Text = "";
            txtTpost.Focus();
            //lblMsgplot.Visible=true;
            //lblMsgplot.Text="Insert Greater Value as compare to ";
        }
    }
    protected void ddlSchemeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        objpl.Ind = 32;
        //objpl.PassId = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
        objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
        objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedItem.Value);
        //objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
        objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
        //    BL_ServiceNo.Fillscheme(objpl); Fillscheme(int Ind, int SchDevTypeid, int Zoneid,int CityCode)

        ds = Legal_CLSCommon.CallApiGet("api/GenerateServiceNo/Fillscheme?Ind=" + objpl.Ind + "&SchDevTypeid=" + objpl.SchDevTypeid + "&Zoneid=" + objpl.Zoneid + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count>0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSchemeName.Enabled = true;
                ddlSchemeName.DataSource = ds.Tables[0];
                ddlSchemeName.DataTextField = "schname";
                ddlSchemeName.DataValueField = "schid";
                ddlSchemeName.DataBind();
                ddlSchemeName.Items.Insert(0, new ListItem("--SELECT--", "0"));
                ddlSchemeName.SelectedIndex = 0;
            }
            else
            {
                ddlSchemeName.Enabled = false;
                ddlSchemeName.DataSource = "";
                ddlSchemeName.DataBind();
                ddlSector.Enabled = false;
                ddlSector.DataSource = "";
                ddlSector.DataBind();
            }
        }
    }
    protected void txtPlotNo_TextChanged(object sender, EventArgs e)
    {
        if (txtPlotNo.Text == "0")
        {
            txtPlotNo.Focus();
            txtPlotNo.Text = "";
        }
    }
    protected void btnExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        #region Single Plot Insert
        lblMesg.Visible = false;
        lblServiceNo.Visible = false;
        if (rbttSingle.Checked)
        {
            objpl.Ind = 5;
            objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
            objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
            objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString());
          //  objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
            objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
            if (ddlSector.Items.Count > 0)
            {
                objpl.Sectorid = Convert.ToInt32(ddlSector.SelectedValue.ToString());
            }
            else
            {
                objpl.Sectorid = 0;


            }
            objpl.NPlotNo = Convert.ToInt32(txtPlotNo.Text);
            objpl.PreFix = txtSPre.Text;
            objpl.PostFix = txtSpost.Text;
            objpl.Useid = Convert.ToInt32(ddlPlotUse.SelectedValue.ToString());
            if (txtSPre.Text == "")
            {
                if (txtSpost.Text == "")
                {
                    objpl.PlotNo = txtPlotNo.Text;
                }
                else
                {
                    objpl.PlotNo = txtPlotNo.Text + txtSpost.Text;
                }
            }
            else
            {
                if (txtSpost.Text == "")
                {
                    objpl.PlotNo = txtSPre.Text + txtPlotNo.Text;
                }
                else
                {
                    objpl.PlotNo = txtSPre.Text + txtPlotNo.Text + txtSpost.Text;
                }
            }
          

            //objpl.PlotNo=   txtSPre.Text + "/" + txtPlotNo.Text +"/"+ txtSpost.Text;
          //  BL_ServiceNo.InsertServiceNo(objpl);
            dt = Legal_CLSCommon.CallApiPost("api/GenerateServiceNo/InsertServiceNo", objpl); 
            txtPlotNo.Text = "";
            if (dt!=null && dt.Rows.Count>0)
            {
                lblServiceNo.Visible = true;
                lblServiceNo.Text = "Your Service No is :- " + dt.Rows[0]["OutPutVal"].ToString();
            }
            else
            {
                lblServiceNo.Visible = true;
                lblServiceNo.Text = "Plot Already Exists ";
            }
        }
        #endregion
        #region Multipul Plot Insertion
        else if (rbttMorethenon.Checked)
        {
            int ftxt, ttxt, diff;
            ftxt = Convert.ToInt32(txtPlotNoFrom.Text);
            ttxt = Convert.ToInt32(txtPlotNoTo.Text);
            diff = ttxt - ftxt;
            objpl.Ind = 5;
            objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
            objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
            objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString());

            if (ddlSector.Items.Count > 0)
            {
                objpl.Sectorid = Convert.ToInt32(ddlSector.SelectedValue.ToString());
            }
            else
            {
                objpl.Sectorid = 0;
            }
            objpl.PreFix = txtFpre.Text;
            objpl.PostFix = txtFpost.Text;
           // objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
            objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
            objpl.Useid = Convert.ToInt32(ddlPlotUse.SelectedValue.ToString());
            for (int i = 0; i < diff + 1; i++)
            {
                if (txtFpre.Text == "")
                {
                    if (txtFpost.Text == "")
                    {
                        objpl.PlotNo = Convert.ToString(ftxt);
                    }
                    else
                    {
                        objpl.PlotNo = Convert.ToString(ftxt) + txtFpost.Text;
                    }
                }
                else
                {
                    if (txtFpost.Text == "")
                    {
                        objpl.PlotNo = txtFpre.Text + Convert.ToString(ftxt);
                    }
                    else
                    {
                        objpl.PlotNo = txtFpre.Text + Convert.ToString(ftxt) + txtFpost.Text;
                    }
                }
              
                objpl.NPlotNo = ftxt;
              //  BL_ServiceNo.InsertServiceNo(objpl);
                dt = Legal_CLSCommon.CallApiPost("api/GenerateServiceNo/InsertServiceNo", objpl); 
                ftxt++;
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lblMesg.Visible = true;
                lblMesg.Text = "Last Service No :- " + dt.Rows[0]["OutPutVal"].ToString();
                lblmess.Visible = true;
                lblmess.Text = "Service No. Generated Successfully";
                txtSpost.Text = "";
                txtPlotNo.Text = "";
                txtPlotNoFrom.Text = "";
                txtPlotNoTo.Text = "";
                txtFpost.Text = "";
                txtTpost.Text = "";
                txtFpre.Text = "";
                txtTpre.Text = "";
            }
            else
            {
                lblMesg.Visible = true;
                lblMesg.Text = "Plot Already Exists ";
                txtSpost.Text = "";
                txtPlotNo.Text = "";
                txtPlotNoFrom.Text = "";
                txtPlotNoTo.Text = "";
                txtFpost.Text = "";
                txtTpost.Text = "";
                txtFpre.Text = "";
                txtTpre.Text = "";
            }
        }
        else if (rbttMultipal.Checked)
        {
            char pre = Convert.ToChar(txtFpost.Text.ToString().ToUpper());
            char post = Convert.ToChar(txtTpost.Text.ToString().ToUpper());
            int fromAsc = Convert.ToInt32(pre);
            int toAsc = Convert.ToInt32(post);
            int diff = (toAsc - fromAsc) + 2;
            objpl.Ind = 5;
            objpl.Zoneid = Convert.ToInt32(ddlZone.SelectedValue.ToString());
            objpl.SchDevTypeid = Convert.ToInt32(ddlSchemeType.SelectedValue.ToString());
            objpl.Schid = Convert.ToInt32(ddlSchemeName.SelectedValue.ToString());
            if (ddlSector.Items.Count > 0)
            {
                objpl.Sectorid = Convert.ToInt32(ddlSector.SelectedValue.ToString());
            }
            else
            {

                objpl.Sectorid = 0;
            }
            objpl.PreFix = txtFpre.Text;
           // objpl.CityCode = Convert.ToInt32(Session["CITYID"]);
            objpl.CityCode = Convert.ToInt32(Session["CityCode"]); 
            objpl.PostFix2 = txtTpost.Text.ToUpper();
            objpl.Useid = Convert.ToInt32(ddlPlotUse.SelectedValue.ToString());
            for (int i = 0; i < diff + 1; i++, pre++)
            {
                if (txtFpre.Text == "")
                {
                    if (txtFpost.Text == "")
                    {
                        objpl.PlotNo = Convert.ToString(txtPlotNoFrom.Text);
                    }
                    else
                    {
                        if (post >= pre)
                        {
                            objpl.PostFix = txtFpost.Text.ToUpper();
                            objpl.PlotNo = Convert.ToString(txtPlotNoFrom.Text) + txtFpost.Text.ToUpper();                           
                            txtFpost.Text = Convert.ToString(Convert.ToChar(Convert.ToChar(txtFpost.Text.ToString().ToUpper()) + 1));
                        }
                    }
                }
                else
                {
                    if (txtFpost.Text == "")
                    {
                        objpl.PlotNo = txtFpre.Text + Convert.ToString(txtPlotNoFrom.Text);
                    }
                    else
                    {
                        if (post >= pre)
                        {
                            objpl.PostFix = txtFpost.Text.ToUpper();
                            objpl.PlotNo = txtFpre.Text + Convert.ToString(txtPlotNoFrom.Text) + txtFpost.Text.ToUpper();
                            txtFpost.Text = Convert.ToString(Convert.ToChar(Convert.ToChar(txtFpost.Text.ToString().ToUpper()) + 1));
                        }
                    }
                }
               
                objpl.NPlotNo = Convert.ToInt32(txtPlotNoFrom.Text);
                dt = Legal_CLSCommon.CallApiPost("api/GenerateServiceNo/InsertServiceNo", objpl); 
                //BL_ServiceNo.InsertServiceNo(objpl);
            }
            if (dt != null && dt.Rows.Count > 0)
            {              
                lblMesg.Visible = true;
                lblMesg.Text = "Last Service No :- " + dt.Rows[0]["OutPutVal"].ToString();
                lblmess.Visible = true;
                lblmess.Text = "Service No. Generated Successfully";
                txtSpost.Text = "";
                txtPlotNo.Text = "";
                txtPlotNoFrom.Text = "";
                txtPlotNoTo.Text = "";
                txtFpost.Text = "";
                txtTpost.Text = "";
                txtFpre.Text = "";
                txtTpre.Text = "";
            }
            else
            {
                //lblMesg.Visible = true;
                //lblMesg.Text = "Plot Already Exists ";
                txtSpost.Text = "";
                txtPlotNo.Text = "";
                txtPlotNoFrom.Text = "";
                txtPlotNoTo.Text = "";
                txtFpost.Text = "";
                txtTpost.Text = "";
                txtFpre.Text = "";
                txtTpre.Text = "";
                PanelgetSno.Visible = false;
            }
        }
        #endregion
        else
        {
            lblServiceNo.Visible = false;
            lblMesg.Visible = true;
            lblMesg.Text = "Plz Select Scheme Name Or Sector";
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblmess.Text = "";
        lblMesg.Text = "";
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}
