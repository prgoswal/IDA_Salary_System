using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmCaseHistory : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        txt_Suitno.Enabled = true;
        txt_Suitdate.Enabled = true; 
        txt_Suitno.CssClass = "form-control form-control-xs";
        txt_Suitdate.CssClass = "form-control form-control-xs datepicker";
        txt_from.CssClass = "form-control form-control-xs datepicker";
        txt_To.CssClass = "form-control form-control-xs datepicker";
        txt_from.Enabled = false;
        txt_To.Enabled = false;
    }
    public void CheckRadioButton()
    {
        if(rdb_SuitNoAndDatewise.Checked==true)
        {
            txt_Suitno.Enabled = true;
            txt_Suitdate.Enabled = true;
            txt_from.Enabled = false;
            txt_To.Enabled = false;
            dgv_caseHistroy.DataSource = null;
            dgv_caseHistroy.DataBind();
        }
        if (rdb_casehearingdate.Checked == true)
        {
            txt_from.Enabled = true;
            txt_To.Enabled = true;
            txt_Suitno.Enabled = false;
            txt_Suitdate.Enabled = false;
            dgv_caseHistroy.DataSource = null;
            dgv_caseHistroy.DataBind();
        }
    }
    public void BindCaseHistoryGrid()
    {
        PL_CaseHistory objpl = new PL_CaseHistory();
        objpl.Ind = 1;
        if (txt_Suitdate.Text != "" && txt_Suitno.Text != "")
        {
            objpl.SuitRegDate = Legal_CLSCommon.DateFormat(txt_Suitdate.Text);
            objpl.SuitRegNo = txt_Suitno.Text;
        }
        if (txt_from.Text != "" && txt_To.Text != "")
        {
            objpl.From = Legal_CLSCommon.DateFormat(txt_from.Text);
            objpl.To = Legal_CLSCommon.DateFormat(txt_To.Text);
        }

        objpl.CityCode =Convert.ToInt32( Session["CityCode"].ToString());

        ds = Legal_CLSCommon.CallApiPostDS("CaseHistory/SearchCaseHistory", objpl);
        if(ds!=null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv_caseHistroy.DataSource = ds.Tables[0];
                dgv_caseHistroy.DataBind();
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "This Record Not Available!!!";
                dgv_caseHistroy.DataSource = null;
                dgv_caseHistroy.DataBind();
            }           
        }
        else
        {
            ds = null;
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "This Record Not Available!!!";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {       
        if(rdb_SuitNoAndDatewise.Checked==true && txt_Suitno.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Suit No..";
            txt_Suitno.Enabled = true;
            txt_Suitdate.Enabled = true;
            txt_Suitno.Focus();
            return;
        }
        if(rdb_SuitNoAndDatewise.Checked==true && txt_Suitno.Text!="")
        {
            txt_Suitno.Enabled = true;
            txt_Suitdate.Enabled = true;
        }
       
        if(rdb_SuitNoAndDatewise.Checked==true && txt_Suitdate.Text=="")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter Suit Date..";
            txt_Suitdate.Enabled = true;
            txt_Suitno.Enabled = true;
            txt_Suitdate.Focus();
            return;
        }
        if(rdb_SuitNoAndDatewise.Checked==true && txt_Suitdate.Text!="")
        {
            txt_Suitdate.Enabled = true;
            txt_Suitno.Enabled = true;
        }

        if (rdb_casehearingdate.Checked == true && txt_from.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter From Date..";
            txt_from.Enabled = true;
            txt_To.Enabled = true;
            txt_from.Focus();
            return;
        }
        if (rdb_casehearingdate.Checked == true && txt_from.Text != "")
        {
            txt_from.Enabled = true;
            txt_To.Enabled = true;

            txt_Suitdate.Enabled = false;
            txt_Suitno.Enabled = false;
        }

        if (rdb_casehearingdate.Checked == true && txt_To.Text == "")
        {
            pnlfailed.Visible = true;
            pnlfailed.InnerHtml = "Enter To Date..";
            txt_To.Enabled = true;
            txt_from.Enabled = true;
            txt_To.Focus();
            return;
        }
        if (rdb_casehearingdate.Checked == true && txt_To.Text != "")
        {
            txt_To.Enabled = true;
            txt_from.Enabled = true;
            txt_Suitdate.Enabled = false;
            txt_Suitno.Enabled = false;
        }
        BindCaseHistoryGrid();
    }
    public void ClearData()
    {
        txt_Suitno.Text = "";
        txt_Suitdate.Text = "";
        txt_from.Text = "";
        txt_To.Text = "";
        rdb_SuitNoAndDatewise.Checked = true;
        rdb_casehearingdate.Checked = false;
        dgv_caseHistroy.DataSource = null;
        dgv_caseHistroy.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void rdb_MemberId_CheckedChanged(object sender, EventArgs e)
    {
        CheckRadioButton();
        txt_Suitno.Text = "";
        txt_Suitdate.Text = "";
        txt_from.Text = "";
        txt_To.Text = "";
    }
    protected void rdb_SuitNoAndDatewise_CheckedChanged(object sender, EventArgs e)
    {
        CheckRadioButton();
        txt_from.Text = "";
        txt_To.Text = "";
    }
    protected void rdb_casehearingdate_CheckedChanged(object sender, EventArgs e)
    {
        CheckRadioButton();
        txt_Suitno.Text = "";
        txt_Suitdate.Text = "";
    }
}