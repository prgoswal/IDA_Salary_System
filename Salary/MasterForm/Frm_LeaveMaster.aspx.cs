using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterForm_Frm_LeaveMaster : System.Web.UI.Page
{
    PL_LeaveMaster plobj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGridView();
        }
    }


    public void BindGridView()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveMaster/LoadBindGridview?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                GvLeaveMaster.DataSource = dt;
                GvLeaveMaster.DataBind();
            }
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    bool btnSaveValidation()
    {
        if (string.IsNullOrEmpty(txtLoanDescription.Text.Trim()))
        {
            txtLoanDescription.Focus();
            ShowMessage("Please Enter Loan Description", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtAbbreviated.Text.Trim()))
        {
            txtAbbreviated.Focus();
            ShowMessage("Please Enter Abbreviated", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtMaximumLifeLimit.Text.Trim()))
        {
            txtMaximumLifeLimit.Focus();
            ShowMessage("Please Enter Maximum Life Limit", false);
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
             plobj = new PL_LeaveMaster()
             {
                 Ind = 1,
                 CITYCODE = Convert.ToInt32(Session["CityCode"]),
                 LvDesc = txtLoanDescription.Text.Trim(),
                 LvAbrDesc = txtAbbreviated.Text.Trim(),
                 MaxLimitLife = Convert.ToInt32(txtMaximumLifeLimit.Text.Trim()),
             };
             string uri = string.Format("LeaveMaster/SaveData");
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

    void clear()
    {
        txtLoanDescription.Text = "";
        txtAbbreviated.Text = "";
        txtMaximumLifeLimit.Text = "";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtLoanDescription.Text = "";
        txtAbbreviated.Text = "";
        txtMaximumLifeLimit.Text = "";
    }
  
    protected void txtMaximumLifeLimit_TextChanged(object sender, EventArgs e)
    {
        if (txtMaximumLifeLimit.Text == "0")
        {
            ShowMessage("Life Limit Should be greater than zero", false);
            txtMaximumLifeLimit.Text = "";
            txtMaximumLifeLimit.Focus();
            return;
        }
    }
}