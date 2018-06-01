using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TransactionForm_Proc_FrmSalaryProcessing : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
    PL_Proc_FrmSalaryProcessing plobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            FillSelectType();
        }
    }

    bool btnPreviewValidation()
    {
        if (ddlSelectType.SelectedItem.Value == "0")
        {
            ddlSelectType.Focus();

            lblMsg.Text = "Please Select Salary Type ";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (ddlSelectType.SelectedItem.Value == "3")
        {
            if (ddlDepartment.SelectedItem.Value == "0")
            {
                ddlDepartment.Focus();
                lblMsg.Text = "Please Select Department ";
                lblMsg.CssClass = "alertMsg failed";
                return false;
            }
        }

        else if (ddlSelectType.SelectedItem.Value == "4")
        {
            if (txtFromLot.Text == "")
            {
                txtFromLot.Focus();
                lblMsg.Text = "Please Enter Lot From ";
                lblMsg.CssClass = "alertMsg failed";
                return false;
            }
            else if (txtToLot.Text == "")
            {
                txtToLot.Focus();
                lblMsg.Text = "Please Enter  Lot To ";
                lblMsg.CssClass = "alertMsg failed";
                return false;
            }
            return true;
        }
        else if (ddlSelectType.SelectedItem.Value == "5")
        {
            if (txtFromEmp.Text == "")
            {
                txtFromEmp.Focus();
                lblMsg.Text = "Please Enter Emp From ";
                lblMsg.CssClass = "alertMsg failed";
                return false;
            }
            else if (txtToEmp.Text == "")
            {
                txtToEmp.Focus();
                lblMsg.Text = "Please Enter  Emp To ";
                lblMsg.CssClass = "alertMsg failed";
                return false;
            }
            return true;
        }
        else if (ddlSelectType.SelectedItem.Value == "6")
        {
            if (ddlClass.SelectedItem.Value == "0")
            {
                ddlClass.Focus();
                lblMsg.Text = "Please Select Class ";
                lblMsg.CssClass = "alertMsg failed";
                return false;
            }
        }
        return true;
    }
    public void FillSelectType()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FillReportType/FillSelectType?Ind=1&CityCode=" + Session["CityCode"] + "");

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
                    ddlSelectType.Items.Insert(0, new ListItem("--Select Type--", "0"));
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
                    //ddlEmpType.Items.Insert(0, new ListItem("All", "0"));
                }
            }
        }
    }
    protected void ddlSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDepartment.Visible = false;
        pnlLot.Visible = false;
        pnlEmployee.Visible = false;
        pnlClass.Visible = false;
        //  pnlEmpType.Visible = false;

        txtFromLot.Text = "";
        txtToLot.Text = "";
        txtFromEmp.Text = "";
        txtToEmp.Text = "";
        ddlClass.ClearSelection();
        // ddlEmpType.ClearSelection();
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
        //else if (ddlSelectType.SelectedValue == "7")
        //{
        //    pnlEmpType.Visible = true;
        //}
    }

    protected void btnPopYes_Click(object sender, EventArgs e)
    {
        plobj = new PL_Proc_FrmSalaryProcessing();
        plobj.Flag = 2;
        plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        plobj.Month = (Session["Month"]).ToString();
        plobj.MonthCd = Convert.ToInt32(Session["MonthCd"]);
        plobj.UserId = Convert.ToInt32(Session["UserId"]);
        plobj.DepartmentCd = Convert.ToInt32(ddlDepartment.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlDepartment.SelectedValue);
        plobj.Lotnofrom = txtFromLot.Text.Trim() == "" ? "" : txtFromLot.Text;
        plobj.Lotnoto = txtToLot.Text.Trim() == "" ? "" : txtToLot.Text;
        plobj.Empnofrom = txtFromEmp.Text.Trim() == "" ? "" : txtFromEmp.Text;
        plobj.Empnoto = txtToEmp.Text.Trim() == "" ? "" : txtToEmp.Text;
        plobj.ClassInd = Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue);
        plobj.EmpType =  Convert.ToInt32(ddlEmpType.SelectedValue) == 0 ? 0 :  Convert.ToInt32(ddlEmpType.SelectedValue);
        

        dt = new DataTable();
        dt = Salary_CLSCommon.ApiPostDataTable("Proc_FrmSalaryProcessing/AmendmentProcessing", plobj);

        if (dt != null)
        {
            if (dt.Rows[0]["ErrorMsg"].ToString() == "2")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#processed-modal').modal('show');});", true);
                return;
            }
            else
            {
                ProcessdSalalry();
            }
        }
    }

    void ProcessdSalalry()
    {
        plobj = new PL_Proc_FrmSalaryProcessing();
        plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        plobj.MonthCd = Convert.ToInt32(Session["MonthCd"]);
        plobj.Month = Session["Month"].ToString();
        plobj.UserId = Convert.ToInt32(Session["UserId"]);
        plobj.DepartmentCd = Convert.ToInt32(ddlDepartment.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlDepartment.SelectedValue);
        plobj.Lotnofrom = txtFromLot.Text.Trim() == "" ? "" : txtFromLot.Text;
        plobj.Lotnoto = txtToLot.Text.Trim() == "" ? "" : txtToLot.Text;
        plobj.Empnofrom = txtFromEmp.Text.Trim() == "" ? "" : txtFromEmp.Text;
        plobj.Empnoto = txtToEmp.Text.Trim() == "" ? "" : txtToEmp.Text;
        plobj.ClassInd = Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue);
        plobj.EmpType = Convert.ToInt32(ddlEmpType.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlEmpType.SelectedValue);

        plobj.Flag = 1;
        ds = new DataSet();
        ds = Salary_CLSCommon.ApiPostDataSet("Proc_FrmSalaryProcessing/SalProcessing", plobj);

        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ErrorMsg"].ToString() == "1")
                {
                    lblMsg.Text = "Salary Processing Successfully...!!! ";
                    lblMsg.CssClass = "alertMsg success";
                }
                else
                {
                    lblMsg.Text = "No Record Found";
                    lblMsg.CssClass = "alertMsg failed";
                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
                lblMsg.CssClass = "alertMsg failed";
            }
        }
        else
        {
            lblMsg.Text = "No Record Found";
            lblMsg.CssClass = "alertMsg failed";
        }
    }
    protected void btnSalProcYes_Click(object sender, EventArgs e)
    {
        bool IsValid = btnPreviewValidation();
        if (!IsValid)
        {
            return;
        }
        ProcessdSalalry();
    }
}