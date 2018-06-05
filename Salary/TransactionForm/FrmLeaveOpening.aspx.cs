using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransactionForm_FrmLeaveOpening : System.Web.UI.Page
{
    PL_LeaveOpening plobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            txtNarration.Attributes.Add("maxlength", "70");
            Fill_TypeofLeave();
        }
    }
    public void Fill_TypeofLeave()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/Bind_TypeOfLeave?Ind=10&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlTypeofLeave.DataSource = dt;
                ddlTypeofLeave.DataTextField = "LvDesc";
                ddlTypeofLeave.DataValueField = "LvCd";
                ddlTypeofLeave.DataBind();
                ddlTypeofLeave.Items.Insert(0, new ListItem(" ---- Select Type of Leave ---- ", "0"));
            }
            else
            {
                ddlTypeofLeave.Items.Clear();
                ddlTypeofLeave.Items.Insert(0, new ListItem(" ---- Select Type of Leave ---- ", "0"));
            }
        }
    }

    public void SearchByEmployeeNo()
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveOpening/SearchByEmpNo?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                ViewState["TotalNoofDayMonth"] = dt.Rows[0]["NoOfDayMonth"].ToString();
                ViewState["TotalLeave"] = dt.Rows[0]["TotalLeave"].ToString();
                txtName.ReadOnly = true;
                txtDesignation.ReadOnly = true;
                ddlTypeofLeave.Focus();
            }
            else
            {
                ShowMessage("Record Not Found !", false);

                txtName.Text = "";
                txtDesignation.Text = "";
                ddlTypeofLeave.ClearSelection();
                txtNoOfLeave.Text = "";
                txtNarration.Text = "";
                return;
            }
        }
        else
        {
            txtName.Text = "";
            txtDesignation.Text = "";
        }
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        SearchByEmployeeNo();
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
        else if (ddlTypeofLeave.SelectedItem.Value == "0")
        {
            ddlTypeofLeave.Focus();
            ShowMessage(" Please Select Type of Leave", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtNoOfLeave.Text.Trim()))
        {
            txtNoOfLeave.Focus();
            ShowMessage("Please Enter No. Of Leave ", false);
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
            plobj = new PL_LeaveOpening()
            {
                Ind = 2,
                CityCode = Convert.ToInt64(Session["CityCode"].ToString()),
                Month = Session["Month"].ToString(),
                EmpNo = Convert.ToInt32(txtEmployeeNo.Text),
                LvCd = Convert.ToInt32(ddlTypeofLeave.SelectedValue),
                NoOfLeave = Convert.ToDecimal(txtNoOfLeave.Text),
                Narration = txtNarration.Text
            };
            string uri = string.Format("LeaveOpening/SaveData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        ShowMessage("Reocord Already Saved", false);
                        ddlTypeofLeave.Focus();
                        return;
                    }
                    else
                    {
                        ShowMessage("Record Save successfully", true);
                        clearAll();
                        return;
                    }

                }
            }
            else
            {
                ShowMessage("Recored Not Save", true);
                return;
            }
        }
    }
void ShowMessages(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }
    void clearAll()
    {
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlTypeofLeave.ClearSelection();
        txtNoOfLeave.Text = "";
        txtNarration.Text = "";
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlTypeofLeave.ClearSelection();
        txtNoOfLeave.Text = "";
        txtNarration.Text = "";
    }
    //protected void txtNoOfLeave_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtNoOfLeave.Text != "")
    //    {
    //        decimal inputNoofday = Convert.ToDecimal(txtNoOfLeave.Text);
    //        decimal alreadyleaveday = Convert.ToDecimal(ViewState["TotalLeave"]);
    //        decimal validday = inputNoofday + alreadyleaveday;
    //        if (Convert.ToDecimal(ViewState["TotalNoofDayMonth"]) < validday)
    //        {
    //            ShowMessage("No of Days are not Greater then Insert Month days", false);
    //            txtNoOfLeave.Focus();
    //            txtNoOfLeave.Text = "";

    //            return;
    //        }
    //        else
    //        {
    //            lblMsg.Text = "";
    //            lblMsg.CssClass = "";
    //            txtNarration.Focus();
    //        }
    //    }
    //    else
    //    {

    //    }
    //}
}
