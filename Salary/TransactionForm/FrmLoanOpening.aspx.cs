using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransactionForm_FrmLoanOpening : System.Web.UI.Page
{
    PL_LoanOpening plobj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            txtNarration.Attributes.Add("maxlength", "50");
            BindLoantype();
            txtEmployeeNo.Focus();
            BindAllData();
        }
    }
    public void SearchByEmployeeNo()
    {
        lblPopUpErrorMsg.Text = "";

        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LoanOpening/SearchByEmpNo?Ind=1&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                txtName.ReadOnly = true;
                txtDesignation.ReadOnly = true;

            }
            else
            {
                ShowMessage("Record Not Found !", false);

                txtDesignation.Text = "";
                Clear();
                return;

            }
        }
        else
        {
            txtName.Text = "";
            txtDesignation.Text = "";
            Clear();
        }
    }
    public void BindLoantype()
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataSet ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("LoanOpening/GetLoanType?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&MonthCd=" + Session["MonthCd"] + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlTypeofLoan.DataSource = ds.Tables[0];
                    ddlTypeofLoan.DataTextField = "LoanDesc";
                    ddlTypeofLoan.DataValueField = "Edcd";
                    ddlTypeofLoan.DataBind();
                    ddlTypeofLoan.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
                }
                else
                {
                    ddlTypeofLoan.Items.Clear();
                    ddlTypeofLoan.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
                }
            }
            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlDeductionMonth.DataSource = ds.Tables[1];
                    ddlDeductionMonth.DataTextField = "Desc1";
                    ddlDeductionMonth.DataValueField = "MonthCD";
                    ddlDeductionMonth.DataBind();
                    ddlDeductionMonth.Items.Insert(0, new ListItem(" -- Select Month -- ", "0"));
                }
                else
                {
                    ddlDeductionMonth.Items.Clear();

                }
            }
        }
        else
        {
            ddlTypeofLoan.Items.Clear();
            ddlTypeofLoan.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
        }
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        SearchByEmployeeNo();
        ddlTypeofLoan.Focus();

    }

    protected void ddlTypeofLoan_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";


        txtLoanSectionDate.Text = "";
        txtActualLoanAmount.Text = "";
        txtInterestRate.Text = "";
        txtInterestAmount.Text = "";
        txtMonthlyIncome.Text = "";
        txtNoOfInstalments.Text = "";


        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LoanOpening/GetInterestRate?Ind=3&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Edcd=" + ddlTypeofLoan.SelectedValue + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                txtInterestRate.Text = dt.Rows[0]["IntRate"].ToString();
                txtInterestRate.ReadOnly = true;
                txtActualLoanAmount.Focus();
                txtInterestAmount.Text = dt.Rows[0]["IntAmt"].ToString();

                // Calculate();
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
        if (GvFilterInformation.Rows.Count <= 0)
        {
            if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
            {
                txtEmployeeNo.Focus();
                ShowMessage("Please Enter Employee No", false);
                return false;
            }
        }
        if (ddlTypeofLoan.SelectedItem.Value == "0")
        {
            ddlTypeofLoan.Focus();
            ShowMessage(" Please Select Type of Loan", false);
            return false;
        }
        if (string.IsNullOrEmpty(txtActualLoanAmount.Text.Trim()))
        {
            txtActualLoanAmount.Focus();
            ShowMessage("Please Enter Actual Loan Amount", false);
            return false;
        }
        if (string.IsNullOrEmpty(txtInterestAmount.Text.Trim()))
        {
            txtInterestAmount.Focus();
            ShowMessage("Please Enter Interest Amount", false);
            return false;
        }
        if (string.IsNullOrEmpty(txtLoanSectionDate.Text.Trim()))
        {
            txtLoanSectionDate.Focus();
            ShowMessage("Please Enter Loan Senction Date ", false);
            return false;
        }

        //else if (string.IsNullOrEmpty(txtBalanceAmount.Text.Trim()))
        //{
        //    txtBalanceAmount.Focus();
        //    ShowMessage("Please Enter Balance Amount", false);
        //    return false;
        //}


        if (ddlDeductionMonth.SelectedValue == "0")
        {
            ddlDeductionMonth.Focus();
            ShowMessage("Please Select Deduction Month", false);
            return false;
        }

        if (string.IsNullOrEmpty(txtMonthlyIncome.Text.Trim()))
        {
            txtMonthlyIncome.Focus();
            ShowMessage("Please Enter Monthly Instalment", false);
            return false;
        }
        if (string.IsNullOrEmpty(txtNoOfInstalments.Text.Trim()))
        {
            txtNoOfInstalments.Focus();
            ShowMessage("Please Enter No. Of Instalments", false);
            return false;
        }
        if (string.IsNullOrEmpty(txtVNo.Text.Trim()))
        {
            txtVNo.Focus();
            ShowMessage("Please Enter Voucher No.", false);
            return false;
        }
        //else if (string.IsNullOrEmpty(txtRefNo.Text.Trim()))
        //{
        //    txtRefNo.Focus();
        //    ShowMessage("Please Enter Ref. No.", false);
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
            var dtBulkEmp = new DataTable();
            dtBulkEmp.Columns.Add("EmpNo", typeof(int));

            if (GvFilterInformation.Rows.Count > 0)
            {
                foreach (GridViewRow row in GvFilterInformation.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.FindControl("chk_Grid") as CheckBox);
                        if (chkRow != null && chkRow.Checked)
                        {
                            var dro = dtBulkEmp.NewRow();
                            dro["EmpNo"] = ((Label)row.FindControl("lblEmpNo")).Text;
                            dtBulkEmp.Rows.Add(dro);
                        }
                    }
                }
            }
            else
            {
                var dro = dtBulkEmp.NewRow();
                dro["EmpNo"] = txtEmployeeNo.Text;
                dtBulkEmp.Rows.Add(dro);
            }

            plobj = new PL_LoanOpening();
            plobj.ind = 4;
            plobj.CityCode = Convert.ToInt32(Session["CityCode"].ToString());
            plobj.dtEmp = dtBulkEmp;
            plobj.EmpNo = 0;
            plobj.MonthCd = Convert.ToInt32(Convert.ToInt32(Session["MonthCd"]));
            plobj.FinYear = Convert.ToInt32(Convert.ToInt32(Session["finyr"]));
            plobj.LoanCd = Convert.ToInt32(ddlTypeofLoan.SelectedValue);
            plobj.LoanSenctionDate = Salary_CLSCommon.ConvertToDate(txtLoanSectionDate.Text.Trim());
            plobj.ActualLoanAmt = Convert.ToDecimal(txtActualLoanAmount.Text.Trim());
            plobj.IntrestRate = Convert.ToDecimal(txtInterestRate.Text.Trim());
            plobj.InterstAmt = Convert.ToDecimal(txtInterestAmount.Text.Trim());
            plobj.MonthlyInstalment = Convert.ToDecimal(txtMonthlyIncome.Text.Trim());
            plobj.NoOfInstalment = Convert.ToDecimal(txtNoOfInstalments.Text.Trim());

            plobj.Month = Session["Month"].ToString();

            plobj.UserId = Session["UserId"].ToString();
            plobj.Vno = Convert.ToInt32(txtVNo.Text.Trim());
            plobj.RefNo = txtRefNo.Text;
            plobj.Narration = txtNarration.Text.Trim();
            plobj.DeductionMonth = Convert.ToInt32(ddlDeductionMonth.SelectedValue);

            string uri = string.Format("LoanOpening/SaveData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["OutputMsg"].ToString() == "0")
                    {
                        ShowMessage("Record Save Successfully..!!!", true);
                    }
                    if (dt.Rows[0]["OutputMsg"].ToString() == "1")
                    {
                        ShowMessage("Record not save record already exist..!!!", false);
                    }

                    Clear();
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
    void Clear()
    {
        chkBulk.Checked = false;
        divGrid.Visible = false;
        GvFilterInformation.DataSource = null;
        GvFilterInformation.DataBind();
        ddlDeductionMonth.ClearSelection();
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlTypeofLoan.ClearSelection();
        txtLoanSectionDate.Text = "";
        txtActualLoanAmount.Text = "";
        // txtBalanceAmount.Text = "";
        txtInterestRate.Text = "";
        txtInterestAmount.Text = "";
        txtMonthlyIncome.Text = "";
        txtNoOfInstalments.Text = "";
        txtVNo.Text = "";
        txtRefNo.Text = "";
        //txtPendingInstalments.Text = "";
        txtNarration.Text = "";
        txtEmployeeNo.Focus();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Salary/TransactionForm/FrmLoanOpening.aspx");
        //lblMsg.Text = "";
        //lblMsg.CssClass = "";
        //txtEmployeeNo.Text = "";
        //txtName.Text = "";
        //txtDesignation.Text = "";
        //ddlTypeofLoan.ClearSelection();
        //txtLoanSectionDate.Text = "";
        //txtActualLoanAmount.Text = "";
        ////txtBalanceAmount.Text = "";
        //txtInterestRate.Text = "";
        //txtInterestAmount.Text = "";
        //txtMonthlyIncome.Text = "";
        //txtNoOfInstalments.Text = "";
        //txtVNo.Text = "";
        //txtRefNo.Text = "";
        ////txtPendingInstalments.Text = "";
        //txtNarration.Text = "";
        //ddlDeductionMonth.ClearSelection();
    }
    protected void txtActualLoanAmount_TextChanged(object sender, EventArgs e)
    {
        if (txtActualLoanAmount.Text.Trim() != "")
        {
            decimal ActualLoanAmount = Convert.ToDecimal(txtActualLoanAmount.Text);
            decimal MonthlyInstalment = ActualLoanAmount / 10;

            txtMonthlyIncome.Text = (MonthlyInstalment).ToString();
            txtNoOfInstalments.Text = "10";
            txtLoanSectionDate.Focus();
        }
        else
        {
            txtMonthlyIncome.Text = "";
            txtNoOfInstalments.Text = "";
        }


    }
    void Calculate()
    {


        if (txtActualLoanAmount.Text != "" && txtInterestRate.Text != "")
        {
            decimal ActualLoanAmount = Convert.ToDecimal(txtActualLoanAmount.Text);
            decimal IntrestRate = Convert.ToDecimal(txtInterestRate.Text);
            decimal TotalNoOfInstalments = Convert.ToInt64(ActualLoanAmount * IntrestRate / 100);
            txtInterestAmount.Text = TotalNoOfInstalments.ToString();
        }


        if (txtActualLoanAmount.Text != "" && txtMonthlyIncome.Text != "" && txtInterestAmount.Text != "")
        {
            decimal ActualLoanAmount = Convert.ToDecimal(txtActualLoanAmount.Text);
            decimal IntrestRate = Convert.ToDecimal(txtInterestAmount.Text);
            decimal MonthlyInstalment = Convert.ToDecimal(txtMonthlyIncome.Text);
            decimal TotalLoan = Convert.ToDecimal(ActualLoanAmount + IntrestRate);
            decimal NoOfInsta = (TotalLoan / MonthlyInstalment);
            txtNoOfInstalments.Text = NoOfInsta.ToString("F2");
        }
    }
    protected void txtMonthlyIncome_TextChanged(object sender, EventArgs e)
    {
        Calculate();
        txtVNo.Focus();
    }

    protected void chkBulk_CheckedChanged(object sender, EventArgs e)
    {

        ChkClass.BackColor = System.Drawing.Color.White;
        ChkGrad.BackColor = System.Drawing.Color.White;
        ChkDesignation.BackColor = System.Drawing.Color.White;
        ChkDepartment.BackColor = System.Drawing.Color.White;
        chkFilterField.BackColor = System.Drawing.Color.White;
        chkEmpType.BackColor = System.Drawing.Color.White;
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        lblPopUpErrorMsg.Text = "";
        if (chkBulk.Checked == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
            divEmployeeDetails.Visible = false;
        }
        else
        {
            GvFilterInformation.DataSource = null;
            GvFilterInformation.DataBind();
            divGrid.Visible = false;
            divEmployeeDetails.Visible = true;
        }

    }
    public void BindAllData()
    {
        DataSet ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FilterInformation/Bind_Getdata?Ind=1");
        if (ds != null)
        {

            chkFilterField.DataSource = ds.Tables[1];
            chkFilterField.DataTextField = "DeptDisplayField";
            chkFilterField.DataValueField = "DeptActualField";
            chkFilterField.DataBind();

            ChkDesignation.DataSource = ds.Tables[3];
            ChkDesignation.DataTextField = "DesgDesc";
            ChkDesignation.DataValueField = "DesgCd";
            ChkDesignation.DataBind();


            ChkDepartment.DataSource = ds.Tables[4];
            ChkDepartment.DataTextField = "DeptName";
            ChkDepartment.DataValueField = "DeptCode";
            ChkDepartment.DataBind();

            ChkClass.DataSource = ds.Tables[5];
            ChkClass.DataTextField = "ClassDesc";
            ChkClass.DataValueField = "Classind";
            ChkClass.DataBind();
            //ChkClass.Items.Insert(0, new ListItem("All", "0"));

            ChkGrad.DataSource = ds.Tables[6];
            ChkGrad.DataTextField = "G";
            ChkGrad.DataValueField = "GrdCd";
            ChkGrad.DataBind();

            chkEmpType.DataSource = ds.Tables[7];
            chkEmpType.DataTextField = "Desc1";
            chkEmpType.DataValueField = "EmpType";
            chkEmpType.DataBind();
            //chkEmpType.Items.Insert(0, new ListItem("All", "0"));
        }
    }

    protected void chkFilterField_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkFilterField.BackColor = System.Drawing.Color.White;

        lblMsg.Text = "";
        lblMsg.CssClass = "";
        lblPopUpErrorMsg.Text = "";
        chkFilterField.BackColor = System.Drawing.Color.White;
        //class
        if (chkFilterField.Items[1].Selected == true)
        {
            divClass.Visible = true;
        }
        else
        {
            divClass.Visible = false;
        }

        //Department
        if (chkFilterField.Items[2].Selected == true)
        {
            divDepartment.Visible = true;
        }
        else
        {
            divDepartment.Visible = false;
        }

        //Date Of Joining
        if (chkFilterField.Items[7].Selected == true)
        {
            txtDateOfJoin.Focus();
            divDoj.Visible = true;

        }
        else
        {
            divDoj.Visible = false;
        }

        //Date Of Retirement
        if (chkFilterField.Items[8].Selected == true)
        {
            txtDateOfRetir.Focus();
            divDor.Visible = true;

        }
        else
        {
            divDor.Visible = false;
        }

        //Designation
        if (chkFilterField.Items[3].Selected == true)
        {
            divDesignation.Visible = true;
        }
        else
        {
            divDesignation.Visible = false;
        }

        //Grade
        if (chkFilterField.Items[5].Selected == true)
        {
            divGrade.Visible = true;
        }
        else
        {
            divGrade.Visible = false;
        }

        //Emp No
        if (chkFilterField.Items[6].Selected == true)
        {
            txtEmpNoFrom.Focus();
            divEmpNo.Visible = true;
        }
        else
        {
            divEmpNo.Visible = false;
        }

        //Emp Type
        if (chkFilterField.Items[0].Selected == true)
        {
            ChkAllEmpType.Focus();
            divEmpType.Visible = true;
        }
        else
        {
            divEmpType.Visible = false;
        }

        //Gender
        if (chkFilterField.Items[4].Selected == true)
        {
            chkGender.Focus();
            divGender.Visible = true;
        }
        else
        {
            divGender.Visible = false;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
    }

    //protected void chkGender_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //if (chkGender.Items[1].Selected == true)
    //    //{
    //    //    txtMale.Visible = true;
    //    //}
    //    //else
    //    //{
    //    //    txtMale.Visible = false;
    //    //}
    //    //if (chkGender.Items[2].Selected == true)
    //    //{
    //    //    txtFemale.Visible = true;
    //    //}
    //    //else
    //    //{
    //    //    txtFemale.Visible = false;
    //    //}
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
    //}


    protected void btnList_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        BindGrid();
    }


    public void BindGrid()
    {
        //////////////////////////////////////  FILTER BY FIELD /////////////////////////////////////////////////////////


        string DepString = null;
        string ClassString = null;
        string DesignationString = null;
        string GradeString = null;
        string EmpType = null;
        string all = null;
        string a1 = null;
        string a2 = null;
        string a3 = null;
        string a4 = "";
        string a5 = "";
        string a6 = "";
        string a7 = "";
        string a8 = "";
        string a9 = "";
        ViewState["FilterFieldString"] = null;

        for (int j = 0; j < chkFilterField.Items.Count; j++)
        {
            if (chkFilterField.Items[j].Selected == true)
            {

                /////////////////////////////////////////////////////  Department  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[j].Value.ToString() == "C.DeptCd")
                {
                    if (ChkAllDepartment.Checked == true)
                    {
                        a1 = DepString = " and A.DeptCd1 <> 0  ";
                    }
                    else
                    {
                        for (int k = 0; k < ChkDepartment.Items.Count; k++)
                        {
                            if (ChkDepartment.Items[k].Selected == true)
                            {
                                if (DepString == null)
                                    DepString = " and DeptCd1 " + " in(" + ChkDepartment.Items[k].Value;
                                else
                                    DepString = DepString + " , " + ChkDepartment.Items[k].Value;
                            }
                        }
                        a1 = DepString + " ) ";
                    }
                }

                /////////////////////////////////////////////////////  Class  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[j].Value.ToString() == "D.ClassInd")
                {
                    if (chkAllClass.Checked == true)
                    {
                        a2 = " and A.ClassInd in (1,2,3,4)";
                    }

                    else
                    {
                        for (int k = 0; k < ChkClass.Items.Count; k++)
                        {
                            if (ChkClass.Items[k].Selected == true)
                            {
                                if (ClassString == null)
                                    ClassString = " and A.ClassInd " + " in(" + ChkClass.Items[k].Value;
                                else
                                    ClassString = ClassString + " , " + ChkClass.Items[k].Value;
                            }
                        }
                        a2 = ClassString + " ) ";

                    }
                }

                /////////////////////////////////////////////////////  Designation  ////////////////////////////////////////////////////////////////

                if (chkAllDesgination.Checked == true)
                {
                    a3 = DesignationString = " and A.DesgCd <> 0  ";
                }
                else
                {
                    if (chkFilterField.Items[j].Value.ToString() == "B.DesgCd")
                    {
                        for (int k = 0; k < ChkDesignation.Items.Count; k++)
                        {
                            if (ChkDesignation.Items[k].Selected == true)
                            {
                                if (DesignationString == null)
                                    DesignationString = " and A.DesgCd " + " in(" + ChkDesignation.Items[k].Value;
                                else
                                    DesignationString = DesignationString + " , " + ChkDesignation.Items[k].Value;
                            }
                        }
                        a3 = DesignationString + " ) ";
                    }
                }

                /////////////////////////////////////////////////////  Grade  ////////////////////////////////////////////////////////////////
                if (chkFilterField.Items[j].Value.ToString() == "F.Grade")
                {
                    if (chkAllGrade.Checked == true)
                    {
                        a4 = GradeString = " and A.GrdCd<>999  ";
                    }
                    else
                    {

                        for (int k = 0; k < ChkGrad.Items.Count; k++)
                        {
                            if (ChkGrad.Items[k].Selected == true)
                            {
                                if (GradeString == null)
                                    GradeString = " and A.GrdCd " + " in(" + ChkGrad.Items[k].Value;
                                else
                                    GradeString = GradeString + " , " + ChkGrad.Items[k].Value;
                            }
                        }
                        a4 = GradeString + " ) ";
                    }
                }
                /////////////////////////////////////////////////////  Employee Number  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[6].Selected == true)
                {
                    if (txtEmpNoFrom.Text.Trim() == "" || txtEmpNoTo.Text.Trim() == "")
                    {
                        lblPopUpErrorMsg.Text = "Please Select Employee No.";
                        txtEmpNoFrom.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                        return;
                    }
                    else
                    {
                        // Empno between 740212 and 741462

                        a5 = " and A.Empno between " + txtEmpNoFrom.Text + " and " + txtEmpNoTo.Text;
                    }
                }

                /////////////////////////////////////////////////////  Emp type  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[0].Selected == true)
                {
                    if (ChkAllEmpType.Checked == true)
                    {
                        a6 = " and A.EmpType in (1,2,3,4)";

                    }

                    else
                    {
                        if (chkFilterField.Items[j].Value.ToString() == "A.EmpType")
                        {
                            for (int k = 0; k < chkEmpType.Items.Count; k++)
                            {
                                if (chkEmpType.Items[k].Selected == true)
                                {
                                    if (EmpType == null)
                                        EmpType = " and A.EmpType " + " in(" + chkEmpType.Items[k].Value;
                                    else
                                        EmpType = EmpType + " , " + chkEmpType.Items[k].Value;
                                }
                            }
                            a6 = EmpType + " ) ";
                        }
                    }
                }
                ///////////////////////////////////////////////////// Date Of Joining  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[7].Selected == true)
                {
                    if (txtDateOfJoin.Text.Trim() == "")
                    {
                        lblPopUpErrorMsg.Text = "Please Select Date Of Joining";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                        txtDateOfJoin.Focus();
                        return;
                    }
                    else
                    {
                        if (rbDateOfJoin.SelectedValue == "0")
                        {
                            a7 = " and A.doj <= '" + Salary_CLSCommon.ConvertToDate(txtDateOfJoin.Text) + "'";
                        }
                        else
                        {
                            a7 = " and A.doj >= '" + Salary_CLSCommon.ConvertToDate(txtDateOfJoin.Text) + "'";
                        }

                    }
                }


                ///////////////////////////////////////////////////// Date Of Retirement  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[8].Selected == true)
                {
                    if (txtDateOfRetir.Text.Trim() == "")
                    {
                        lblPopUpErrorMsg.Text = "Please Select Date Of Retirement";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);

                        txtDateOfRetir.Focus();
                        return;
                    }
                    else
                    {
                        if (rbDateOfRetir.SelectedValue == "0")
                        {
                            a8 = " and A.SupRetDt <= '" + Salary_CLSCommon.ConvertToDate(txtDateOfRetir.Text) + "'";
                        }
                        else
                        {
                            a8 = " and A.SupRetDt >= '" + Salary_CLSCommon.ConvertToDate(txtDateOfRetir.Text) + "'";
                        }

                    }
                }


                ///////////////////////////////////////////////////// Gender  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[4].Selected == true)
                {
                    if (chkGender.SelectedValue == "0")
                    {
                        a9 = " and A.Sex in(0,1) ";
                    }
                    else if (chkGender.SelectedValue == "1")
                    {
                        a9 = " and A.Sex = 1 ";
                    }
                    else
                    {
                        a9 = " and A.Sex = 0 ";
                    }

                }

                ////////////////////////////////////////////////////////////  END ///////////////////////////////////////////////////////////////////////////////////
            }
        }
        all = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9;

        if (all == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
            lblPopUpErrorMsg.Text = "Please Select At Least One Checkbox";
            chkFilterField.BackColor = System.Drawing.Color.LightYellow;
            GvFilterInformation.DataSource = null;
            GvFilterInformation.DataBind();
            return;
        }

        else
        {
            if (a1 != "" && a1 != null)
            {
                if (a1.Trim() == ")")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                    lblPopUpErrorMsg.Text = "Please Select At Least One Department";
                    ChkDepartment.BackColor = System.Drawing.Color.LightYellow;
                    return;
                }
            }
            if (a2 != "" && a2 != null)
            {
                if (a2.Trim() == ")")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                    lblPopUpErrorMsg.Text = "Please Select At Least One Class";
                    ChkClass.BackColor = System.Drawing.Color.LightYellow;
                    return;
                }
            }

            if (a3 != "" && a3 != null)
            {
                if (a3.Trim() == ")")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                    lblPopUpErrorMsg.Text = "Please Select At Least One Desigantion";
                    ChkDesignation.BackColor = System.Drawing.Color.LightYellow;
                    return;
                }
            }

            if (a4 != "" && a4 != null)
            {
                if (a4.Trim() == ")")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                    lblPopUpErrorMsg.Text = "Please Select At Least One Grade";
                    ChkGrad.BackColor = System.Drawing.Color.LightYellow;
                    return;
                }
            }

            if (a6 != "" && a6 != null)
            {
                if (a6.Trim() == ")")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                    lblPopUpErrorMsg.Text = "Please Select At Least One EmpType";
                    chkEmpType.BackColor = System.Drawing.Color.LightYellow;
                    return;
                }
            }

            PL_FilterInformation plobj = new PL_FilterInformation();
            plobj.Ind = 10;
            plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
            plobj.MonthCd = Convert.ToInt32(Session["MonthCd"]);

            plobj.SelectStringParameter = "";
            plobj.FilterStringParameter = all;
            plobj.OrderByStringParameter = "";
            string uri = string.Format("FilterInformation/FilterGetData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    GvFilterInformation.DataSource = dt;
                    GvFilterInformation.DataBind();
                    divEmployeeDetails.Visible = false;
                    divGrid.Visible = true;
                }
            }
            else
            {
                GvFilterInformation.DataSource = null;
                GvFilterInformation.DataBind();
                divEmployeeDetails.Visible = true;
                divGrid.Visible = false;
            }
        }
    }

    protected void txtEmpNoFrom_TextChanged(object sender, EventArgs e)
    {
        if ((txtEmpNoFrom.Text.Trim() != ""))
        {
            txtEmpNoTo.Text = txtEmpNoFrom.Text;
            txtEmpNoTo.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
        }
    }


    protected void bntAddGrid_Click(object sender, EventArgs e)
    {
        BindGrid();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "Close();", true);

    }


    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAll.Checked == true)
        {
            foreach (GridViewRow row in GvFilterInformation.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.FindControl("chk_Grid") as CheckBox);
                    chkRow.Checked = true;

                }
            }
        }
        else
        {
            foreach (GridViewRow row in GvFilterInformation.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.FindControl("chk_Grid") as CheckBox);
                    chkRow.Checked = false;

                }
            }
        }
    }
}

