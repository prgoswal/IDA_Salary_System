using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransactionForm_FrmRetirmentBenfit : System.Web.UI.Page
{
    PL_RetirmnetBenfit plobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            txtEmployeeNo.Focus();
        }
    }

    public void SearchByEmployeeNo()
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("RetirmnetBenfit/SearchByEmpNo?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                //Years: 24 Months: 9 Days: 20
                txtName.Text = dt.Rows[0]["EmpName"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                txtDOJ.Text = dt.Rows[0]["DOJ"].ToString();
                txtDOR.Text = dt.Rows[0]["DOR"].ToString();

                string a = dt.Rows[0]["YYYYmmdd"].ToString();

                lblYear.Text = a.Substring(7, 2);
                lblMonth.Text = a.Substring(18, 2);
                lblDays.Text = a.Substring(27, 2);

                hfRrdInd.Value = dt.Rows[0]["RrdtInd"].ToString();
                lblBacic.Text = dt.Rows[0]["Basic"].ToString();
                lblGradePay.Text = dt.Rows[0]["GrdPay"].ToString();
                txtName.ReadOnly = true;
                txtDesignation.ReadOnly = true;
                ddlSelectType.Focus();
            }
            else
            {
                ClearAll();
                ShowMessage("Invalid Employee Number !", false);
                return;
            }
        }
        else
        {
            ClearAll();
        }
    }

    void ClearAll()
    {
        txtEmployeeNo.Text = "";
        txtEmployeeNo.Focus();
        txtName.Text = "";
        txtDesignation.Text = "";
        lblBacic.Text = "";
        lblGradePay.Text = "";
        ddlSelectType.ClearSelection();
        txtDOJ.Text = "";
        txtDOR.Text = "";
        txtTotalLeave.Text = "";
        txtDaPer.Text = "";
        lblPayableAmount.Text = "";
        lblYear.Text = "";
        lblMonth.Text = "";
        lblDays.Text = "";
        divPayableAmount.Visible = false;
        DivTotalLeave.Visible = false;
        lblMsg.Text = "";
        lblMsg.CssClass = "";

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
        if (ddlSelectType.SelectedItem.Value == "0")
        {
            ddlSelectType.Focus();
            ShowMessage(" Please Select Type", false);
            return false;
        }
        if (txtDOJ.Text.Trim() == "")
        {
            txtDOJ.Focus();
            ShowMessage("Please Enter Date Of Joining ", false);
            return false;
        }

        if (txtDOR.Text.Trim() == "")
        {
            txtDOR.Focus();
            ShowMessage("Please Enter Date Of Retirement ", false);
            return false;
        }

        if (txtDaPer.Text.Trim() == "")
        {
            txtDaPer.Focus();
            ShowMessage("Please Enter DA ", false);
            return false;
        }
        if (ddlSelectType.SelectedItem.Value == "2")
        {
            if (txtTotalLeave.Text.Trim() == "")
            {
                txtTotalLeave.Focus();
                ShowMessage("Please Enter Total No. Of Days ", false);
                return false;
            }

        }
        if (txtTotalLeave.Text != "")
        {
            if (Convert.ToInt32(txtTotalLeave.Text) > 240)
            {
                txtTotalLeave.Focus();
                txtTotalLeave.Text = "";
                ShowMessage("Total No. Of Days Not Greater-than 240 Days", false);
                return false;
            }
        }
        if (lblPayableAmount.Text.Trim() == "")
        {
            lnkBtnCalculate.Focus();
            ShowMessage("Submit Calculate Button", false);
            return false;

        }

        return true;
    }


    protected void btnclear_Click(object sender, EventArgs e)
    {
        ClearAll();

    }


    protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectType.SelectedValue != "0")
        {
            if (ddlSelectType.SelectedValue == "2")
            {
                DivTotalLeave.Visible = true;
            }
            else
            {
                DivTotalLeave.Visible = false;
                txtTotalLeave.Text = "";
            }
        }
        else
        {
            DivTotalLeave.Visible = false;
            txtTotalLeave.Text = "";
        }
        txtDaPer.Focus();

    }
    protected void lnkBtnCalculate_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        divPayableAmount.Visible = false;
        if (ddlSelectType.SelectedValue == "2")
        {
            decimal Basic = 0; decimal GradPay = 0; decimal Da = 0; decimal CalculateDa = 0; decimal TotalNoOfDays = 0; decimal Total = 0;
            Basic = Convert.ToDecimal(lblBacic.Text);
            GradPay = Convert.ToDecimal(lblGradePay.Text);
            Da = Convert.ToDecimal(txtDaPer.Text);
            TotalNoOfDays = Convert.ToDecimal(txtTotalLeave.Text);

            CalculateDa = Math.Round((((Basic + GradPay) * Da) / 100));
            Total = (((Basic + GradPay) + CalculateDa) * (TotalNoOfDays));
            lblPayableAmount.Text = Math.Round((Total / 30)).ToString();
            divPayableAmount.Visible = true;
            hfTotalMonth.Value = "0";
        }

        if (ddlSelectType.SelectedValue == "1")
        {
            decimal Basic = 0; decimal GradPay = 0; decimal DaPer = 0; decimal CalculateDa = 0; decimal Total = 0; decimal A = 0; decimal B = 0; decimal CountMonth = 0; decimal TotalMonth = 0;

            CountMonth = Convert.ToDecimal(lblMonth.Text);
            if (CountMonth >= 6)
            {
                CountMonth = 1;
                TotalMonth = (Convert.ToDecimal(lblYear.Text) * 2) + CountMonth;
            }
            else
            {
                TotalMonth = (Convert.ToDecimal(lblYear.Text) * 2);
            }
            if (TotalMonth > 66)
            {
                hfTotalMonth.Value = 66.ToString();
            }
            else
            {
                hfTotalMonth.Value = TotalMonth.ToString();
            }
            Basic = Convert.ToDecimal(lblBacic.Text);
            GradPay = Convert.ToDecimal(lblGradePay.Text);
            DaPer = Convert.ToDecimal(txtDaPer.Text);

            CalculateDa = Math.Round((((Basic + GradPay) * DaPer) / 100));
            Total = (((Basic + GradPay) + CalculateDa));
            A = Math.Round((Total / 26) * (30));

            if (hfRrdInd.Value == "2") // Retirment Case 
            {
                B = (((A) * (Convert.ToDecimal(hfTotalMonth.Value))) / 4);
            }
            else if (hfRrdInd.Value == "4")// Death Case
            {
                B = (((A) * (Convert.ToDecimal(hfTotalMonth.Value))) / 2);
            }

            lblPayableAmount.Text = Math.Round(Convert.ToDouble(B), 0, MidpointRounding.AwayFromZero).ToString();

            divPayableAmount.Visible = true;
        }
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
            plobj = new PL_RetirmnetBenfit();
            plobj.Ind = 3;
            plobj.CityCode = Session["CityCode"].ToString();
            plobj.EmpNo = txtEmployeeNo.Text;
            plobj.Month = Session["Month"].ToString();
            plobj.GraduityTotalMonth = Convert.ToInt32(hfTotalMonth.Value);
            plobj.BasicAmt = Convert.ToDecimal(lblBacic.Text);
            plobj.GradePayAmt = Convert.ToDecimal(lblGradePay.Text);
            plobj.SelectType = Convert.ToInt32(ddlSelectType.SelectedValue);
            plobj.DOJ = Salary_CLSCommon.ConvertToDate(txtDOJ.Text);
            plobj.DOR = Salary_CLSCommon.ConvertToDate(txtDOR.Text);
            plobj.NoOfLeave = txtTotalLeave.Text.Trim() == "" ? 0 : Convert.ToInt32(txtTotalLeave.Text);
            plobj.DaPer = Convert.ToDecimal(txtDaPer.Text);
            plobj.PayableAmt = Convert.ToDecimal(lblPayableAmount.Text);
            plobj.DaAmt = Convert.ToDecimal(lblBacic.Text) + Convert.ToDecimal((lblGradePay.Text));
            plobj.NoOfYears = Convert.ToInt32(lblYear.Text.Trim());
            plobj.NoOfMonths = Convert.ToInt32(lblMonth.Text.Trim());
            plobj.NoOfDays = Convert.ToInt32(lblDays.Text.Trim());
            plobj.Status = hfRrdInd.Value == "2" ? "R" : hfRrdInd.Value == "4" ? "D" : "O";

            string uri = string.Format("RetirmnetBenfit/SaveData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ClearAll();
                    ShowMessage("Record Save successfully", true);
                    divPayableAmount.Visible = false;
                    DivTotalLeave.Visible = false;
                    return;
                }
            }
            else
            {
                ShowMessage("Recored Not Save", true);
                return;
            }
        }
    }
    protected void txtDOR_TextChanged(object sender, EventArgs e)
    {
        if (txtDOR.Text != "" && txtDOJ.Text != "")
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            DataTable dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("RetirmnetBenfit/GetYYYYmmdd?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&DOR=" + Salary_CLSCommon.ConvertToDate(txtDOR.Text) + "");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    string a = dt.Rows[0]["YYYYmmdd"].ToString();

                    lblYear.Text = a.Substring(7, 2);
                    lblMonth.Text = a.Substring(18, 2);
                    lblDays.Text = a.Substring(27, 2);
                    txtName.ReadOnly = true;
                    txtDesignation.ReadOnly = true;
                }
            }
        }
    }
}
