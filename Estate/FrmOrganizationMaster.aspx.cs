using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FrmOrganizationMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_OrganizationnameE.Text = "";
        txt_OrganizationnameH.Text = "";
        txt_OrganizationAddress.Text = "";
        txt_ContactPer1name.Text = "";
        txt_ContactPer1Mob.Text = "";
        txt_Contactper1Email.Text = "";
        txt_Contactper1Desg.Text = "";
        txt_ContactPer2name.Text = "";
        txt_ContactPer2Mob.Text = "";
        txt_Contactper2Emai.Text = "";
        txt_Contactper2Desg.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        PL_Organization objpl = new PL_Organization();
        objpl.Ind = 1;
        if(txt_OrganizationnameE.Text=="")
        {
            pnlfailed.Visible=true;
            pnlfailed.InnerHtml = "Enter Organization Name English";
            txt_OrganizationnameE.Focus();
            return;
        }
        if(txt_OrganizationnameH.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Organization Name Hindi";
            txt_OrganizationnameH.Focus();
            return;
        }
        if(txt_OrganizationAddress.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Organization Address";
            txt_OrganizationAddress.Focus();
            return; 
        }
        if(txt_ContactPer1name.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion1 Name";
            txt_ContactPer1name.Focus();
            return;
        }
        if(txt_ContactPer1Mob.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion1 MobileNo";
            txt_ContactPer1Mob.Focus();
            return;
        }
        if(txt_Contactper1Email.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion1 Email";
            txt_Contactper1Email.Focus();
            return;
        }
        if(txt_Contactper1Desg.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion1 Designation";
            txt_Contactper1Desg.Focus();
            return;
        }
        if(txt_ContactPer2name.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion2 Name";
            txt_ContactPer2name.Focus();
            return;
        }
        if(txt_ContactPer2Mob.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion2 Mobile";
            txt_ContactPer2Mob.Focus();
            return;
        }
        if(txt_Contactper2Emai.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion2 Email";
            txt_Contactper2Emai.Focus();
            return;
        }
        if(txt_Contactper2Desg.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Contact Persion2 Designation";
            txt_Contactper2Desg.Focus();
            return;
        }
        objpl.OrganizationNameE = txt_OrganizationnameE.Text;
        objpl.OrganizationNameH = txt_OrganizationnameH.Text;
        objpl.OrganizationAddress = txt_OrganizationAddress.Text;
        objpl.ContactPer1Name = txt_ContactPer1name.Text;
        objpl.ContactPer1Mobile = txt_ContactPer1Mob.Text;
        objpl.ContactPer1Email = txt_Contactper1Email.Text;
        objpl.ContactPer1Desg = txt_Contactper1Desg.Text;
        objpl.ContactPer2Name = txt_ContactPer2name.Text;
        objpl.ContactPer2Mobile = txt_ContactPer2Mob.Text;
        objpl.ContactPer2Email = txt_Contactper2Emai.Text;
        objpl.ContactPer2Desg = txt_Contactper2Desg.Text;
        objpl.CityCode = 0;
        DataSet ds =Estate_CLSCommon.CallApiPostDS("Organization/SaveOrganization", objpl);
        if(ds!=null && ds.Tables.Count > 0)
        {
            if(ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Record Save Successfully!!!";
                ClearData();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else
            {
                pnlfailed.InnerHtml = "Record Failed.. Please Try Again!!";
                pnlfailed.Visible = true;
                pnlSuccess.Visible = false;
            }
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}