using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class frmCaseMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if(!IsPostBack)
        {
            ShowCaseMaster();
        }

        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        btnupdate.Visible = false;
    }
    public void ClearData()
    {
        txt_caseTypeNmH.Text = "";
        txt_caseTypeNmE.Text = "";
    }
    public void ShowCaseMaster()
    {
        PL_CaseMaster objpl = new PL_CaseMaster();
       
          objpl.Ind = 3;
          objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
          DataSet ds = Legal_CLSCommon.CallApiGet("CaseMaster/ShowCaseMaster?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
         if(ds!=null && ds.Tables.Count > 0)
         {
             gv_casemaster.DataSource = ds.Tables[0];
             gv_casemaster.DataBind();
         }
         else
         {
             ds = null;
         }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(txt_caseTypeNmE.Text=="")
        {
            pnlfailed.InnerText = "Enter Case Type Name In Hindi";
            txt_caseTypeNmE.Focus();
            pnlfailed.Visible = true;
            return;
        }
        if(txt_caseTypeNmH.Text=="")
        {
            pnlfailed.InnerText = "Enter case Type Name In Hindi";
            txt_caseTypeNmH.Focus();
            pnlfailed.Visible = true;
            return;
        }
        PL_CaseMaster objpl = new PL_CaseMaster();
        objpl.Ind = 1;
        objpl.CaseTypeNmE = txt_caseTypeNmE.Text;
        objpl.CaseTypeNmH = txt_caseTypeNmH.Text;
        objpl.OrgCode =Convert.ToInt32( Session["OrgCode"].ToString());
        objpl.CityCode =Convert.ToInt32( Session["CityCode"].ToString());
        objpl.EntryUserCode =Convert.ToInt32( Session["UserCode"].ToString());
        DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseMaster/SaveCaseMaster", objpl);
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.InnerHtml = "Save Successfully.";
                ShowCaseMaster();
                ClearData();
                pnlSuccess.Visible = true;
                pnlfailed.Visible = false;
            }
            else if(ds.Tables[0].Rows[0]["res"].ToString() == "2")
            {
                pnlfailed.InnerHtml = "Record Allready Exist!!!";
                pnlfailed.Visible = true;
            }
            else
            {
                pnlfailed.InnerHtml = "Data Failed...";
                pnlSuccess.Visible = false;
                pnlfailed.Visible = true;
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;      
       ClearData();
    }
   
    //protected void OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (gv_casemaster.Rows.Count > 0)
    //    {
    //        GridViewRow row = gv_casemaster.SelectedRow;
    //        lblcaseTypecode.Text = row.Cells[0].Text;
    //        txt_caseTypeNmE.Text = row.Cells[1].Text;
    //        txt_caseTypeNmH.Text = row.Cells[2].Text;
    //        //lblcaseTypecode.Text=
    //        btnupdate.Visible = true;
    //        btnSave.Visible = false;
    //    }
    //}
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        
            PL_CaseMaster objpl = new PL_CaseMaster();
            objpl.Ind = 2;
            objpl.CaseTypeNmE = txt_caseTypeNmE.Text;
            objpl.CaseTypeNmH = txt_caseTypeNmH.Text;
            objpl.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            objpl.CaseTypeCode =Convert.ToInt32( Session["CaseTypeCode"].ToString());
            DataSet ds = Legal_CLSCommon.CallApiPostDS("CaseMaster/UpdateCaseMaster", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.InnerHtml = "Update Successfully.";
                    btnupdate.Visible = false;
                    btnSave.Visible = true;
       
                    ShowCaseMaster();
                    ClearData();
                    pnlSuccess.Visible = true;
                    pnlfailed.Visible = false;
                }
                else
                {
                    pnlfailed.InnerHtml = "Updation Failed..Please try Again!!";
                    pnlSuccess.Visible = false;
                    pnlfailed.Visible = true;
                }
            }
        }
   // }
    protected void gv_casemaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            btnupdate.Visible = true;
            btnSave.Visible = false;
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            int caseTypeCode = Convert.ToInt32(gv_casemaster.DataKeys[rowindex].Value);
            HiddenField field = gv_casemaster.Rows[rowindex].FindControl("lblCaseTypeCode") as HiddenField;
            Label lblcaseTypeNmE = (Label)gv_casemaster.Rows[rowindex].FindControl("lblcaseTypeNmE");
            Label lblcaseTypeNmH = (Label)gv_casemaster.Rows[rowindex].FindControl("lblcaseTypeNmH");
            txt_caseTypeNmE.Text = lblcaseTypeNmE.Text;
            txt_caseTypeNmH.Text = lblcaseTypeNmH.Text;

            Session["CaseTypeCode"] = caseTypeCode;
           
        }
    }
}