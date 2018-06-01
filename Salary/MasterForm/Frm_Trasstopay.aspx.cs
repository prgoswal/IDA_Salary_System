using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterForm_Frm_Trasstopay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            txtStopReason.Attributes.Add("maxlength", "50");
            txtMonth.Text = Session["Month"].ToString();
        }
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("StopPayment/SearchByEmpNo?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                txtMonth.Text = dt.Rows[0]["Month"].ToString();
                txtDate.Text = dt.Rows[0]["Date"].ToString();
                txtStopReason.Text = dt.Rows[0]["StopReason"].ToString();
                txtName.ReadOnly = true;
                txtDesignation.ReadOnly = true;
                if (dt.Rows[0]["StopReason"].ToString() == "")
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    txtDate.Focus();
                }
                else
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    txtDate.Focus();
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.CssClass = "";
                clear();
            }
        }
        else
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            clear();
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    bool btnSaveValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
        {
            txtEmployeeNo.Focus();
            ShowMessage("Please Enter Employee No", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtDate.Text.Trim()))
        {
            txtDate.Focus();
            ShowMessage(" Please Select Date", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtStopReason.Text.Trim()))
        {
            txtStopReason.Focus();
            ShowMessage("Please Enter Stop Reason", false);
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
            PL_StopPayment Plobj = new PL_StopPayment();
            Plobj.Ind = 1;
            Plobj.Empno = Convert.ToInt32(txtEmployeeNo.Text);
            Plobj.Date = txtDate.Text;
            Plobj.Month = txtMonth.Text;
            Plobj.StopReason = txtStopReason.Text;
            Plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
            string uri = string.Format("StopPayment/SaveStopPayment");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, Plobj);
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
                    clear();
                    return;
                }
            }
        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        //var month = DateTime.Now.Month.ToString();
        //var year = DateTime.Now.Year.ToString();
        //if (month == "1" || month == "2" || month == "3" || month == "4" || month == "5" || month == "6" || month == "7" || month == "8" || month == "9")
        //{
        //    month = "0" + month;
        //}
        //var MargeMtoY = (month + year).ToString();
        txtMonth.Text = Session["Month"].ToString();
        txtStopReason.Focus();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        clear();
    }

    void clear()
    {
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        txtDate.Text = "";
        txtMonth.Text = "";
        txtStopReason.Text = "";
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }

    bool btnUpdateValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
        {
            txtEmployeeNo.Focus();
            ShowMessage("Please Enter Employee No", false);
            return false;
        }
        return true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool IsValid = btnUpdateValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            PL_StopPayment Plobj = new PL_StopPayment();
            Plobj.Ind = 3;
            Plobj.Empno = Convert.ToInt32(txtEmployeeNo.Text);
            Plobj.Date = txtDate.Text;
            Plobj.Month = txtMonth.Text;
            Plobj.StopReason = txtStopReason.Text;
            Plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
            string uri = string.Format("StopPayment/SaveStopPayment");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, Plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("Record Update successfully", true);
                    clear();
                    return;
                }
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        bool IsValid = btnUpdateValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            DataTable dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("StopPayment/SearchByEmpNo?Ind=4&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("Record Delete successfully", true);
                    clear();
                    return;
                }
            }
        }
    }

}