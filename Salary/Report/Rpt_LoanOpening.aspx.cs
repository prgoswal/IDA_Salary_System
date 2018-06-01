using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salary_Report_Rpt_LoanOpening : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            Fill_TypeofLoan();
            FillSelectType();
        }
    }

    public void Fill_TypeofLoan()
    {
        DataSet ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("LoanOpening/GetLoanType?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&MonthCd=" + Session["MonthCd"] + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlLoanopening.DataSource = ds.Tables[0];
                    ddlLoanopening.DataTextField = "LoanDesc";
                    ddlLoanopening.DataValueField = "Edcd";
                    ddlLoanopening.DataBind();
                    ddlLoanopening.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
                }
                else
                {
                    ddlLoanopening.Items.Clear();
                    ddlLoanopening.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
                }
            }
           
        }
        else
        {
            ddlLoanopening.Items.Clear();
            ddlLoanopening.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
        }
    }


    void clear()
    {
        ddlSelectType.ClearSelection();
        ddlDepartment.ClearSelection();
        ddlClass.ClearSelection();
        txtFromLot.Text = "";
        txtToLot.Text = "";
        txtFromEmp.Text = "";
        txtToEmp.Text = "";
    }

    public void FillSelectType()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FillReportType/FillSelectType?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSelectType.DataSource = ds.Tables[0];
                    ddlSelectType.DataTextField = "RptTypeDesc";
                    ddlSelectType.DataValueField = "RptTypeId";
                    ddlSelectType.DataBind();
                   // ddlSelectType.Items.Insert(0, new ListItem("--Select Type--", "0"));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlDepartment.DataSource = ds.Tables[1];
                    ddlDepartment.DataTextField = "DeptName";
                    ddlDepartment.DataValueField = "DeptCode";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlClass.DataSource = ds.Tables[2];
                    ddlClass.DataTextField = "ClassDesc";
                    ddlClass.DataValueField = "Classind";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("--Select Class--", "0"));
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlEmpType.DataSource = ds.Tables[3];
                    ddlEmpType.DataTextField = "Desc1";
                    ddlEmpType.DataValueField = "EmpType";
                    ddlEmpType.DataBind();
                   // ddlEmpType.Items.Insert(0, new ListItem("All", "0"));
                }
            }
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    bool btnPreviewValidation()
    {

        if (ddlEmpType.SelectedItem.Value == "0")
        {
            ddlEmpType.Focus();
            ShowMessage(" Please Select Employee Type ", false);
            return false;
        }
        else if (ddlSelectType.SelectedItem.Value == "0")
        {
            ddlSelectType.Focus();
            ShowMessage(" Please Select Salary Type ", false);
            return false;
        }
        else if (ddlSelectType.SelectedItem.Value == "3")
        {
            if (ddlDepartment.SelectedItem.Value == "0")
            {
                ddlDepartment.Focus();
                ShowMessage(" Please Select Department", false);
                return false;
            }
        }

        else if (ddlSelectType.SelectedItem.Value == "4")
        {
            if (txtFromLot.Text == "")
            {
                txtFromLot.Focus();
                ShowMessage("Please Enter Lot From ", false);
                return false;
            }
            else if (txtToLot.Text == "")
            {
                txtToLot.Focus();
                ShowMessage("Please Enter  Lot To  ", false);
                return false;
            }
            return true;
        }
        else if (ddlSelectType.SelectedItem.Value == "5")
        {
            if (txtFromEmp.Text == "")
            {
                txtFromEmp.Focus();
                ShowMessage("Please Enter Emp From ", false);
                return false;
            }
            else if (txtToEmp.Text == "")
            {
                txtToEmp.Focus();
                ShowMessage("Please Enter  Emp To  ", false);
                return false;
            }
            return true;
        }
        else if (ddlSelectType.SelectedItem.Value == "6")
        {
            if (ddlClass.SelectedItem.Value == "0")
            {
                ddlClass.Focus();
                ShowMessage(" Please Select Class", false);
                return false;
            }
        }
        else if (ddlLoanopening.SelectedItem.Value == "0")
        {
            ddlLoanopening.Focus();
            ShowMessage(" Please Select Type Of Loan", false);
            return false;
        }

        return true;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        bool IsValid = btnPreviewValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            Hashtable HT = new Hashtable();
            HT.Add("MonthDesc", Session["MonthDesc"].ToString() + "   -(" + ddlLoanopening.SelectedItem.Text +")");
            HT.Add("UserName", Session["UserName"].ToString());
            HT.Add("MonthCd", Session["MonthCd"].ToString());
            HT.Add("EmpType", ddlEmpType.SelectedValue);
            HT.Add("LotNoF", txtFromLot.Text == "" ? "0" : txtFromLot.Text);
            HT.Add("LotNoTo", txtToLot.Text == "" ? "0" : txtToLot.Text);
            HT.Add("Zone", 0);
            HT.Add("Ward", 0);
            HT.Add("DeptCd", ddlDepartment.SelectedValue);
            HT.Add("SubDeptCd", 0);
            HT.Add("MOnth", Session["Month"].ToString());
            HT.Add("CityCode", Session["CityCode"].ToString());
            HT.Add("Reg_Dep", RadioButtonList1.SelectedItem.Value == "0" ? "0" : "0");
            HT.Add("Regular", RadioButtonList1.SelectedItem.Value == "1" ? "1" : "0");
            HT.Add("Deputation", RadioButtonList1.SelectedItem.Value == "2" ? "2" : "0");
            HT.Add("RRD", 0);
            HT.Add("OldPay", 0);
            HT.Add("FifthPay", 0);
            HT.Add("SixPay", 0);
            HT.Add("BothFifth_Six", 0);
            HT.Add("BeforeDoj", 0);
            HT.Add("AferDoj", 0);
            HT.Add("DojBoth", 0);
            HT.Add("BnkCd", 0);
            HT.Add("BrCd", 0);
            HT.Add("FIXPAY", 0);
            HT.Add("EMPTYPENAME", "0");
            HT.Add("MonthDate", "0");
            HT.Add("CITYNAME", Session["CorpName"].ToString());
            HT.Add("Year", Session["finyr"].ToString());
            HT.Add("SearchType", 0);
            HT.Add("EmpNoFrom", txtFromEmp.Text.Trim() == "" ? "0" : txtFromEmp.Text);
            HT.Add("EmpNoTo", txtToEmp.Text.Trim() == "" ? "0" : txtToEmp.Text);
            HT.Add("classind", Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue));
            HT.Add("LoanCd", Convert.ToInt32(ddlLoanopening.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlLoanopening.SelectedValue));
            Session["HT"] = HT;
            Session["Report"] = "RptLoanOpening";
            Session["ReportName"] = ddlLoanopening.SelectedItem.Text;
            Response.Redirect("ReportViewer.aspx?index=27");
        }
    }
    protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDepartment.Visible = false;
        pnlLot.Visible = false;
        pnlEmployee.Visible = false;
        pnlClass.Visible = false;
        txtFromLot.Text = "";
        txtToLot.Text = "";
        txtFromEmp.Text = "";
        txtToEmp.Text = "";
        ddlClass.ClearSelection();
        ddlDepartment.ClearSelection();
        if (ddlSelectType.SelectedValue == "3")
        {
            pnlDepartment.Visible = true;
        }
        else if (ddlSelectType.SelectedValue == "4")
        {
            pnlLot.Visible = true;
        }
        else if (ddlSelectType.SelectedValue == "5")
        {
            pnlEmployee.Visible = true;
        }
        else if (ddlSelectType.SelectedValue == "6")
        {
            pnlClass.Visible = true;
        }
    }
    protected void txtFromEmp_TextChanged(object sender, EventArgs e)
    {
        txtFromEmp.Text = txtToEmp.Text;
        txtToEmp.Focus();
    }
    protected void txtToEmp_TextChanged(object sender, EventArgs e)
    {
        txtFromEmp.Text = txtToEmp.Text;
    }
}