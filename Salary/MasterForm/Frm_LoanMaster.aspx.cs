using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterForm_Frm_LoanMaster : System.Web.UI.Page
{
    PL_LoanMaster plobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
            Fill_ddlLoanDescription();
        }
    }


    public void Fill_ddlLoanDescription()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LoanMaster/BindLoanDescription?Ind=8");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlLoanDescription.DataSource = dt;
                ddlLoanDescription.DataTextField = "Desc";
                ddlLoanDescription.DataValueField = "Edcd";
                ddlLoanDescription.DataBind();
                ddlLoanDescription.Items.Insert(0, new ListItem(" ---- Select Loan Description ---- ", "0"));
            }
            else
            {
                ddlLoanDescription.Items.Clear();
                ddlLoanDescription.Items.Insert(0, new ListItem(" ---- Select Loan Description ---- ", "0"));
            }
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtAbbreviatedDescription.Text = "";
        txtInstallmentAmount1.Text = "";
        //txtInstallmentAmount2.Text = "";
        txtInstallments.Text = "";
        txtInterestRate.Text = "";
        ddlLoanDescription.ClearSelection();
        lblMsg.Text = "";
        lblMsg.CssClass = "";
    }

    void clear()
    {
        txtAbbreviatedDescription.Text = "";
        txtInstallmentAmount1.Text = "";
        //txtInstallmentAmount2.Text = "";
        txtInstallments.Text = "";
        txtInterestRate.Text = "";
        ddlLoanDescription.ClearSelection();
    }
   
    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }
    bool btnSaveValidation()
    {
        if (ddlLoanDescription.SelectedItem.Value == "0")
        {
            ddlLoanDescription.Focus();
            ShowMessage("  Please Select Loan Description", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtAbbreviatedDescription.Text.Trim()))
        {
            txtAbbreviatedDescription.Focus();
            ShowMessage("Please Enter Abbreviated Description", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtInterestRate.Text.Trim()))
        {
            txtInterestRate.Focus();
            ShowMessage("Please Enter Interest Rate", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtInstallments.Text.Trim()))
        {
            txtInstallments.Focus();
            ShowMessage("Please Enter No. of Installments", false);
            return false;
        }
      
        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool IsValid = btnSaveValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            plobj = new PL_LoanMaster()
            {
                Ind = 1,
                CityCode = Convert.ToInt32(Session["CityCode"]),
                Edcd= Convert.ToInt32(ddlLoanDescription.SelectedValue),
                LoanDesc = ddlLoanDescription.SelectedItem.Text,
                Avrdesc = txtAbbreviatedDescription.Text.Trim(),
                IntRate = Convert.ToDecimal(txtInterestRate.Text.Trim()),
                NoOfInst = Convert.ToInt32(txtInstallments.Text.Trim()),
                LoanAmtRange1 = Convert.ToDecimal(txtInstallmentAmount1.Text.Trim()),
                LoanAmtRange2 = 0
            };
            string uri = string.Format("LoanMaster/SaveData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            string lastno = dt.Rows[0][0].ToString();
            if (lastno == "0")
            {
                ShowMessage("This Record Is Already Exists", false);
                return;
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("Record Save successfully", true);
                    BindGridView();
                    clear();
                    return;
                }
            }
        }
    }

    public void BindGridView()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LoanMaster/LoadBindGridview?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                GvLoanMaster.DataSource = dt;
                GvLoanMaster.DataBind();
            }
        }
    }
}
