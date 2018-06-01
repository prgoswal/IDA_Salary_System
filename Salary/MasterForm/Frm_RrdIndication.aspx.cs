using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterForm_Frm_RrdIndication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            FillSeletType();
            //  txtCurrentDate.Text = Session["Month"].ToString();
        }
    }

    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("RrdIndication/SearchByEmpNo?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                ddlRRDSelectType.SelectedValue = dt.Rows[0]["RrdtInd"].ToString();

                txtDate.Text = dt.Rows[0]["rrdtdt"].ToString() == "01/01/1900" ? "" : dt.Rows[0]["rrdtdt"].ToString();
                txtCurrentDate.Text = dt.Rows[0]["Month"].ToString();
                txtName.ReadOnly = true;
                txtDesignation.ReadOnly = true;
                ddlRRDSelectType.Focus();
            }
            else
            {
                ShowMessage("Record Not Found", false);
                txtName.Text = "";
                txtDesignation.Text = "";
                ddlRRDSelectType.ClearSelection();
                txtDate.Text = "";
                txtCurrentDate.Text = "";
                txtEmployeeNo.Focus();
            }
        }
        else
        {
            ShowMessage("Record Not Found", false);
            txtName.Text = "";
            txtDesignation.Text = "";
            ddlRRDSelectType.ClearSelection();
            txtDate.Text = "";
            txtCurrentDate.Text = "";
            txtEmployeeNo.Focus();
        }
    }

    public void FillSeletType()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("RrdIndication/BindRRDType?Ind=7");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlRRDSelectType.DataSource = dt;
                ddlRRDSelectType.DataValueField = "RrdtInd";
                ddlRRDSelectType.DataTextField = "RRDDesc";
                ddlRRDSelectType.DataBind();
                ddlRRDSelectType.Items.Insert(0, new ListItem("---SELECT---", "0"));
            }
        }
        else
        {
            ddlRRDSelectType.Items.Clear();
        }
    }

    //protected void txtDate_TextChanged(object sender, EventArgs e)
    //{
    //    var month = DateTime.Now.Month.ToString();
    //    var year = DateTime.Now.Year.ToString();
    //    if (month == "1" || month == "2" || month == "3" || month == "4" || month == "5" || month == "6" || month == "7" || month == "8" || month == "9")
    //    {
    //        month = "0" + month;
    //    }
    //    var MargeMtoY = (month + year).ToString();
    //    txtCurrentDate.Text = MargeMtoY;

    //}

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    bool btnUpdateValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
        {
            txtEmployeeNo.Focus();
            ShowMessage("Please Enter Employee No", false);
            return false;
        }
        else if (ddlRRDSelectType.SelectedItem.Value == "0")
        {
            ddlRRDSelectType.Focus();
            ShowMessage(" Please Select Type", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtDate.Text.Trim()))
        {
            txtDate.Focus();
            ShowMessage("Please Select Date", false);
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
            PL_RrdIndication Plobj = new PL_RrdIndication();
            Plobj.Ind = 2;
            Plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
            Plobj.EmpNo = Convert.ToInt32(txtEmployeeNo.Text);
            Plobj.selecttype = Convert.ToInt32(ddlRRDSelectType.SelectedValue);
            Plobj.Date = Salary_CLSCommon.ConvertToDate(txtDate.Text);
            Plobj.month = txtCurrentDate.Text;
            string uri = string.Format("RrdIndication/UpdateRrdUP");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, Plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ShowMessage("Record Update successfully", true);
                    Clear();
                    return;
                }
            }
        }
    }

    void Clear()
    {
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlRRDSelectType.ClearSelection();
        txtDate.Text = "";
        txtCurrentDate.Text = "";
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlRRDSelectType.ClearSelection();
        txtDate.Text = "";
        txtCurrentDate.Text = "";
        txtName.ReadOnly = false;
        txtDesignation.ReadOnly = false;
    }


}
