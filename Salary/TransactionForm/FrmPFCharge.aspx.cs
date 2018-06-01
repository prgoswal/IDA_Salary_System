using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salary_TransactionForm_FrmPFCharge : System.Web.UI.Page
{
    PL_PFCharges plobj = new PL_PFCharges();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void RbpayAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RbpayAmount.SelectedValue == "0")
        {
            DivBasic.Visible = true;
            DivGrade.Visible = true;
            DivDA.Visible = true;
            txtBasic.Text = "";
            txtGrade.Text = "";
            txtDA.Text = "";
            txtPF.Text = "";
            txtAdminCharge.Text = "";
        }
        else
        {
            DivBasic.Visible = true;
            DivGrade.Visible = false;
            DivDA.Visible = true;
            txtDesignation.Text = "";
            txtBasic.Text = "";
            txtGrade.Text = "";
            txtDA.Text = "";
            txtPF.Text = "";
            txtAdminCharge.Text = "";
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("PFCharges/SearchByEmpNo?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                txtBasic.Focus();
            }
            else
            {
                ShowMessage("Record Not Found", false);
                txtName.Text = "";
                txtDesignation.Text = "";
            }
        }
        else
        {
            ShowMessage("Record Not Found", false);
            txtName.Text = "";
            txtDesignation.Text = "";
        }
    }

    void Calulation()
    {
        decimal Basic = 0; decimal Grade = 0; decimal DA = 0;
        if (txtBasic.Text.Trim() == "")
        {
            Basic = 0;
        }
        else
        {
            Basic = Convert.ToDecimal(txtBasic.Text);
        }
        if (txtGrade.Text.Trim() == "")
        {
            Grade = 0;
        }
        else
        {
            Grade = Convert.ToDecimal(txtGrade.Text);
        }
        if (txtDA.Text.Trim() == "")
        {
            DA = 0;
        }
        else
        {
            DA = Convert.ToDecimal(txtDA.Text);
        }
        //txtPF.Text = Convert.ToString((Basic + Grade + DA) * Convert.ToDecimal(12) / 100);
        //txtAdminCharge.Text = Convert.ToString(((Basic + Grade + DA) - 15000) * Convert.ToDecimal(1.16) / 100);

        txtPF.Text = Convert.ToString(Math.Round((Basic + Grade + DA) * Convert.ToDecimal(12) / 100));
        txtAdminCharge.Text = Convert.ToString(Math.Round(((Basic + Grade + DA) - 15000) * Convert.ToDecimal(1.16) / 100));
    }
    protected void txtBasic_TextChanged(object sender, EventArgs e)
    {
        Calulation();
        txtGrade.Focus();
    }
    protected void txtGrade_TextChanged(object sender, EventArgs e)
    {
        Calulation();
        txtDA.Focus();
    }
    protected void txtDA_TextChanged(object sender, EventArgs e)
    {
        Calulation();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtName.Text = "";
        txtDesignation.Text = "";

        txtBasic.Text = "";
        txtGrade.Text = "";
        txtDA.Text = "";
        txtPF.Text = "";
        txtAdminCharge.Text = "";
        DivGrade.Visible = true;
    }

    void Clear()
    {
        txtName.Text = "";
        txtDesignation.Text = "";

        txtBasic.Text = "";
        txtGrade.Text = "";
        txtDA.Text = "";
        txtPF.Text = "";
        txtAdminCharge.Text = "";
    }

    bool btnSaveValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
        {
            txtEmployeeNo.Focus();
            ShowMessage("Please Enter Employee No", false);
            return false;
        }
        if (string.IsNullOrEmpty(txtBasic.Text.Trim()))
        {
            txtBasic.Focus();
            ShowMessage("Please Enter Basic", false);
            return false;
        }
        //if (string.IsNullOrEmpty(txtGrade.Text.Trim()))
        //{
        //    txtGrade.Focus();
        //    ShowMessage("Please Enter Grade", false);
        //    return false;
        //}
        if (string.IsNullOrEmpty(txtDA.Text.Trim()))
        {
            txtDA.Focus();
            ShowMessage("Please Enter DA", false);
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
            plobj.Ind = 2;
            plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
            plobj.month = Session["Month"].ToString();
            plobj.EmpNo = Convert.ToInt32(txtEmployeeNo.Text.Trim());
            plobj.Basic = Convert.ToDecimal(txtBasic.Text.Trim());
            if (txtGrade.Text.Trim() == "")
            {
                plobj.Grade = 0;
            }
            else
            {
                plobj.Grade = Convert.ToDecimal(txtGrade.Text.Trim());
            }
            plobj.DA = Convert.ToDecimal(txtDA.Text.Trim());
            plobj.PF = Convert.ToDecimal(txtPF.Text.Trim());
            plobj.AdminCharge = Convert.ToDecimal(txtAdminCharge.Text.Trim());
            if (RbpayAmount.SelectedValue == "0")
            {
                plobj.SalTypeInd = 0;
            }
            else
            {
                plobj.SalTypeInd = 1;
            }
            DataTable dt = Salary_CLSCommon.ApiPostDataTable("PFCharges/SavePFCharges", plobj);
            string lastno = dt.Rows[0][0].ToString();
            if (lastno == "1")
            {
                lblMsg.Text = "Record Save Successfully";
                lblMsg.CssClass = "alertMsg success";
                Clear();
                return;
            }
            else
            {
                lblMsg.Text = "Record Not Save ";
                lblMsg.CssClass = "alertMsg failed";
            }
        }
    }
}