using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using java.util;

public partial class MasterForm_Frm_LicPolicy : System.Web.UI.Page
{
    PL_LicPolicy plobj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillLICType();
            FillPolicyType();
            divstatus.Visible = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            txtEmployeeNo.Focus();
        }
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/SearchByEmpNo?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                FillGrid();
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                txtName.ReadOnly = true;
                txtDesignation.ReadOnly = true;
                DDLLICType.Focus();
            }
            else
            {
                DDLLICType.ClearSelection();
                DDLPolicyType.ClearSelection();
                txtPolicyAmt.Text = "";
                txtStartDate.Text = "";
                txtName.Text = "";
                txtDesignation.Text = "";
                txtPolicyNo.Text = "";
                txtPremiumAmt.Text = "";
                txtMaturityDate.Text = "";
                chkstatus.Checked = false;
                divstatus.Visible = false;
                gvLicpolicy.DataSource = null;
                gvLicpolicy.DataBind();
            }
        }

        else
        {
            DDLLICType.ClearSelection();
            DDLPolicyType.ClearSelection();
            txtPolicyAmt.Text = "";
            txtStartDate.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtPolicyNo.Text = "";
            txtPremiumAmt.Text = "";
            txtMaturityDate.Text = "";
            chkstatus.Checked = false;
            divstatus.Visible = false;
            gvLicpolicy.DataSource = null;
            gvLicpolicy.DataBind();
        }
    }

    public void FillLICType()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LicPolicy/Bind_Lictype?Ind=4&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DDLLICType.DataSource = dt;
                DDLLICType.DataValueField = "Edcd";
                DDLLICType.DataTextField = "Desc";
                DDLLICType.DataBind();
                DDLLICType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            DDLLICType.Items.Clear();
        }
    }
    public void FillPolicyType()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LicPolicy/Bind_PolicyType?Ind=6");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DDLPolicyType.DataSource = dt;
                DDLPolicyType.DataValueField = "PolicyID";
                DDLPolicyType.DataTextField = "Policyname";
                DDLPolicyType.DataBind();
                DDLPolicyType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            DDLPolicyType.Items.Clear();
        }
    }


    public void FillGrid()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LicPolicy/Bind_Grid?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                gvLicpolicy.DataSource = dt;
                gvLicpolicy.DataBind();
            }
            else
            {
                gvLicpolicy.DataSource = null;
                gvLicpolicy.DataBind();
            }
        }
        else
        {
            gvLicpolicy.DataSource = null;
            gvLicpolicy.DataBind();
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
        else if (DDLLICType.SelectedItem.Value == "0")
        {
            DDLLICType.Focus();
            ShowMessage(" Please Select LIC Type ", false);
            return false;
        }

        else if (DDLPolicyType.SelectedItem.Value == "0")
        {
            DDLPolicyType.Focus();
            ShowMessage(" Please Select Policy Type", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtPolicyNo.Text.Trim()))
        {
            txtPolicyNo.Focus();
            ShowMessage("Please Enter Policy No", false);
            return false;
        }
        //else if (string.IsNullOrEmpty(txtPolicyAmt.Text.Trim()))
        //{
        //    txtPolicyAmt.Focus();
        //    ShowMessage("Please Enter Policy Amt", false);
        //    return false;
        //}
        //else if (string.IsNullOrEmpty(txtPremiumAmt.Text.Trim()))
        //{
        //    txtPremiumAmt.Focus();
        //    ShowMessage("Please Enter Premium Amt", false);
        //    return false;
        //}
        else if (string.IsNullOrEmpty(txtStartDate.Text.Trim()))
        {
            txtStartDate.Focus();
            ShowMessage("Please Enter Start Date ", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtMaturityDate.Text.Trim()))
        {
            txtMaturityDate.Focus();
            ShowMessage("Please Enter Maturity Date", false);
            return false;
        }
        //DateTime F_Date = Convert.ToDateTime(txtStartDate.Text.Substring(6, 4) + "/" + txtStartDate.Text.Substring(3, 2) + "/" + txtStartDate.Text.Substring(0, 2));
        //DateTime T_Date = Convert.ToDateTime(txtMaturityDate.Text.Substring(6, 4) + "/" + txtMaturityDate.Text.Substring(3, 2) + "/" + txtMaturityDate.Text.Substring(0, 2));
        //if (F_Date > T_Date)
        //{
        //    ShowMessage(" From Date Should Not Be Greater Than To Date", false);
        //    txtStartDate.Focus();
        //    return false;
        //}
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
            plobj = new PL_LicPolicy()
            {
                Ind = 1,
                EmpNo = Convert.ToDecimal(txtEmployeeNo.Text),
                PolicyNo = Convert.ToDecimal(txtPolicyNo.Text),
                PolicyAmt = Convert.ToDecimal(txtPolicyAmt.Text),
                PolicyType = Convert.ToInt32(DDLPolicyType.SelectedValue),
                PolicyTypeDese = DDLPolicyType.SelectedItem.Text,
                Installment = Convert.ToDecimal(txtPremiumAmt.Text),
                StartDate = Salary_CLSCommon.ConvertToDate(txtStartDate.Text),
                MaturityDate = Salary_CLSCommon.ConvertToDate(txtMaturityDate.Text),
                DivCode = 0,
                DivCodeDese = "",
                Stop = 1,
                Edcd = Convert.ToInt32(DDLLICType.SelectedValue),
                EDDesc = DDLLICType.SelectedItem.Text,
                Month = Convert.ToString(Session["Month"]),
                citycode = Convert.ToInt32(Session["CityCode"])
            };
            string uri = string.Format("LicPolicy/Save_PolicyType");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            string lastno = dt.Rows[0][0].ToString();
            if (lastno == "0")
            {
                ShowMessage("This Policy No. Already Exists", false);
                return;
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("Record Save successfully", true);
                    FillGrid();
                    clear();
                    txtEmployeeNo.Focus();
                    return;
                }
            }
        }
    }

    protected void gvLicpolicy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (e.Row.FindControl("IsActive") as Label);
            LinkButton btnStatus = (e.Row.FindControl("btnActivenew") as LinkButton);
            if (lblStatus.Text == "0")
            {
                btnStatus.Text = "Stop";
                btnStatus.CssClass = "btn btn-danger btn-xs btn-min-ai btn-block";
            }
            else
            {
                btnStatus.Text = "Live";
                btnStatus.CssClass = "btn btn-success btn-xs btn-min-ai btn-block";
            }
        }
    }
    protected void gvLicpolicy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Actionnew")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Label EmpNo = gvLicpolicy.Rows[rowIndex].FindControl("lblEmpNo") as Label;
            Label PolicyNo = gvLicpolicy.Rows[rowIndex].FindControl("lblPolicyNo") as Label;
            Label lblStatus = gvLicpolicy.Rows[rowIndex].FindControl("IsActive") as Label;
            if (lblStatus.Text != "0")
            {

                PL_LicPolicy plobj = new PL_LicPolicy();
                plobj.Ind = 3;
                plobj.EmpNo = Convert.ToInt32(EmpNo.Text);
                plobj.PolicyNo = Convert.ToInt32(PolicyNo.Text);
                plobj.citycode = Convert.ToInt32(Session["CityCode"]);
                if (lblStatus.Text == "1")
                {
                    plobj.Stop = 0;
                }
                else
                {
                    plobj.Stop = 1;
                }
                DataTable dt = Salary_CLSCommon.ApiPostDataTable("LicPolicy/StatusUpdate_PolicyType", plobj);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ShowMessage("Change Status  successfully", true);
                        FillGrid();
                        return;
                    }
                }
            }
            else
            {
                ShowMessage("Record Not Updated ", false);
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        clear();
    }

    void clear()
    {
        txtEmployeeNo.Text = "";
        DDLLICType.ClearSelection();
        DDLPolicyType.ClearSelection();
        txtPolicyAmt.Text = "";
        txtStartDate.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        txtPolicyNo.Text = "";
        txtPremiumAmt.Text = "";
        txtMaturityDate.Text = "";
        chkstatus.Checked = false;
        divstatus.Visible = false;
        txtEmployeeNo.Enabled = true;
        txtPolicyNo.Enabled = true;
        btnSave.Visible = true;
        btnUpdate.Visible = false;

        gvLicpolicy.DataSource = null;
        gvLicpolicy.DataBind();

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        LinkButton btnEdit = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        int rowindex = gvr.RowIndex;
        Label EmpNo = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblEmpNo");
        Label Name = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblName");
        Label DesgDesc = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblDesgDesc");
        Label Edcd = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblEdcd");
        Label PolicyType = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblPolicyType");
        Label PolicyTypeDese = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblPolicyTypeDese");
        Label PolicyNo = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblPolicyNo");
        Label PolicyAmt = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblPolicyAmt");
        Label Installment = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblInstallment");
        Label StartDate = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblStartDate");
        Label MaturityDate = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblMaturityDate");
        Label IsActive = (Label)gvLicpolicy.Rows[rowindex].FindControl("IsActive");

        txtEmployeeNo.Text = EmpNo.Text;
        txtName.Text = Name.Text;
        txtDesignation.Text = DesgDesc.Text;
        DDLLICType.SelectedValue = Edcd.Text;
        DDLPolicyType.SelectedValue = PolicyType.Text;
        DDLPolicyType.SelectedItem.Text = PolicyTypeDese.Text;
        txtPolicyAmt.Text = PolicyAmt.Text;
        txtStartDate.Text = StartDate.Text;
        txtPolicyNo.Text = PolicyNo.Text;
        txtPremiumAmt.Text = Installment.Text;
        txtMaturityDate.Text = MaturityDate.Text;
        if (IsActive.Text == "1")
        {
            divstatus.Visible = true;
            chkstatus.Checked = true;
            chkstatus.Text = "Yes";
            chkstatus.CssClass = "text-success";
        }
        else
        {
            divstatus.Visible = true;
            chkstatus.Checked = false;
            chkstatus.Text = "No";
            chkstatus.CssClass = "text-danger";
        }
        txtEmployeeNo.Enabled = false;
        txtPolicyNo.Enabled = false;
        btnSave.Visible = false;
        btnUpdate.Visible = true;
    }
    protected void chkstatus_CheckedChanged(object sender, EventArgs e)
    {
        if (chkstatus.Checked == true)
        {
            chkstatus.CssClass = "text-success";
        }
        else
        {
            chkstatus.CssClass = "text-danger";
        }
    }

    bool btnUpdateValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()) || string.IsNullOrEmpty(txtPolicyNo.Text.Trim()))
        {
            ShowMessage("Please Select to Edit Button On Grid", false);
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
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            plobj = new PL_LicPolicy()
            {
                Ind = 4,
                EmpNo = Convert.ToDecimal(txtEmployeeNo.Text),
                PolicyNo = Convert.ToDecimal(txtPolicyNo.Text),
                PolicyAmt = Convert.ToDecimal(txtPolicyAmt.Text),
                PolicyType = Convert.ToInt32(DDLPolicyType.SelectedValue),
                PolicyTypeDese = DDLPolicyType.SelectedItem.Text,
                Installment = Convert.ToDecimal(txtPremiumAmt.Text),
                StartDate = Salary_CLSCommon.ConvertToDate(txtStartDate.Text),
                MaturityDate = Salary_CLSCommon.ConvertToDate(txtMaturityDate.Text),
                DivCode = 0,
                DivCodeDese = "",
                Edcd = Convert.ToInt32(DDLLICType.SelectedValue),
                EDDesc = DDLLICType.SelectedItem.Text,
                Month = Convert.ToString(Session["Month"]),
                citycode = Convert.ToInt32(Session["CityCode"])
            };
            if (chkstatus.Checked)
            {
                plobj.Stop = 1;
            }
            else
            {
                plobj.Stop = 0;
            }
            string uri = string.Format("LicPolicy/Save_PolicyType");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("Record Updated Successfully", true);
                    FillGrid();
                    clear();
                    txtEmployeeNo.Focus();
                    return;
                }
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        LinkButton btnEdit = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        int rowindex = gvr.RowIndex;
        Label EmpNo = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblEmpNo");
        Label PolicyNo = (Label)gvLicpolicy.Rows[rowindex].FindControl("lblPolicyNo");
        PL_LicPolicy plobj = new PL_LicPolicy();
        plobj.Ind = 5;
        plobj.EmpNo = Convert.ToDecimal(EmpNo.Text);
        plobj.PolicyNo = Convert.ToDecimal(PolicyNo.Text);
        plobj.Month = Convert.ToString(Session["Month"]);
        plobj.citycode = Convert.ToInt32(Session["CityCode"]);
        string uri = string.Format("LicPolicy/Delete_PolicyType");
        DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ShowMessage("Record Deleted Successfully", true);
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                FillGrid();
                clear();
                txtEmployeeNo.Focus();
                return;
            }
        }
    }


    bool btnCheckDate()
    {
        if (string.IsNullOrEmpty(txtStartDate.Text.Trim()))
        {
            txtStartDate.Focus();
            ShowMessage("Please Enter Start Date ", false);
            return false;
        }
        return true;
    }

    protected void txtMaturityDate_TextChanged(object sender, EventArgs e)
    {
        bool args;
        bool IsValid = btnCheckDate();
        if (!IsValid)
        {
            return;
        }
        else
        {
            args = (Convert.ToDateTime(txtStartDate.Text) <= Convert.ToDateTime(txtMaturityDate.Text));
            if (args == false)
            {
                ShowMessage("Maturity Date should be greater than Start Date !", false);
                txtMaturityDate.Text = "";
                txtMaturityDate.Focus();
                return;
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.CssClass = "";
            }
        }
    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
        txtStartDate.Focus();
        bool args;
        if (txtMaturityDate.Text == "")
        {
            return;
        }
        else
        {
            args = (Convert.ToDateTime(txtMaturityDate.Text) >= Convert.ToDateTime(txtStartDate.Text));
            if (args == false)
            {
                ShowMessage("Maturity Date should be greater than Start Date !", false);
                txtStartDate.Text = "";
                txtMaturityDate.Text = "";
               
                return;
            }
            else
            {
               
                lblMsg.Text = "";
                lblMsg.CssClass = "";
            }
        }
    }
}
