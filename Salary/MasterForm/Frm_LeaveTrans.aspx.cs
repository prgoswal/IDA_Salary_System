using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterForm_Frm_LeaveTrans : System.Web.UI.Page
{
    PL_LeaveTrasaction plobj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtEmployeeNo.Focus();
            txtNarration.Attributes.Add("maxlength", "70");
            Fill_TypeofLeave();

            DivDate.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            DivTrans.Visible = false;
        }
    }

    //public void date()
    //{
    //    if (txtFromDate.Text != "" && txtToDate.Text != "")
    //    {
    //        //Storing input Dates  
    //        DateTime FromYear = Convert.ToDateTime(txtFromDate.Text);
    //        DateTime ToYear = Convert.ToDateTime(txtToDate.Text);
    //        //Creating object of TimeSpan Class  
    //        TimeSpan objTimeSpan = ToYear - FromYear;
    //        //years  
    //        int Years = ToYear.Year - FromYear.Year;
    //        //months  
    //        int month = ToYear.Month - FromYear.Month;
    //        //TotalDays  
    //        double Days = Convert.ToDouble(objTimeSpan.TotalDays) + 1;
    //        //Total Months  
    //        int TotalMonths = (Years * 12) + month;
    //        //Total Hours  
    //        double TotalHours = objTimeSpan.TotalHours;
    //        //Total Minutes  
    //        double TotalMinutes = objTimeSpan.TotalMinutes;
    //        //Total Seconds  
    //        double TotalSeconds = objTimeSpan.TotalSeconds;
    //        //Total Mile Seconds  
    //        double TotalMileSeconds = objTimeSpan.TotalMilliseconds;
    //        //Assining values to td tags  
    //        //tdYear.InnerText = Years + "  Year  " + month + "  Months";
    //        //txtNoOfmounth.Text = Convert.ToString(TotalMonths);
    //        txtNoOfDays.Text = Convert.ToString(Days);
    //    }


    //}
    public void Fill_TypeofLeave()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/Bind_TypeOfLeave?Ind=3&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        bool IsValid = btnDeleteValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            DataTable dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/DeleteData?Ind=5&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "&LvCd=" + Convert.ToInt32(ddlTypeofLeave.SelectedValue) + "");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    bindGrid();
                    clear();
                    ShowMessage("Record Delete successfully", true);
                    return;
                }
            }
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }


    bool btnDeleteValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
        {
            txtEmployeeNo.Focus();
            ShowMessage("Please Enter Employee No", false);
            return false;
        }
        return true;
    }

    bool btnSaveValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
        {
            txtEmployeeNo.Focus();
            ShowMessage("Please Enter Employee No", false);
            return false;
        }
        if (ddlTypeofLeave.SelectedItem.Value == "0")
        {
            ddlTypeofLeave.Focus();
            ShowMessage(" Please Select Type of Leave", false);
            return false;
        }

        decimal inputNoofday = Convert.ToDecimal(txtNoOfDays.Text);
        decimal alreadyleaveday = Convert.ToDecimal(ViewState["TotalLeave"]);
        decimal validday = inputNoofday + alreadyleaveday;
        if (Convert.ToDecimal(ViewState["TotalNoofDayMonth"]) < validday)
        {
            ShowMessage("No of Days are not Greater then Insert Month days", false);
            txtNoOfDays.Text = "";
            txtNoOfDays.Focus();
            return false;
        }
        if (ddlTypeofLeave.SelectedItem.Value == "6")
        {
            if (string.IsNullOrEmpty(txtFromDate.Text.Trim()))
            {
                txtFromDate.Focus();
                ShowMessage("Please Enter From Date", false);
                return false;
            }
            if (string.IsNullOrEmpty(txtToDate.Text.Trim()))
            {
                txtToDate.Focus();
                ShowMessage("Please Enter To Date", false);
                return false;
            }
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                DateTime F_Date = Convert.ToDateTime(txtFromDate.Text.Substring(6, 4) + "/" + txtFromDate.Text.Substring(3, 2) + "/" + txtFromDate.Text.Substring(0, 2));
                DateTime T_Date = Convert.ToDateTime(txtToDate.Text.Substring(6, 4) + "/" + txtToDate.Text.Substring(3, 2) + "/" + txtToDate.Text.Substring(0, 2));
                if (F_Date > T_Date)
                {
                    ShowMessage(" From Date Should Not Be Greater Than To Date", false);
                    txtFromDate.Focus();
                    return false;
                }
            }
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
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            plobj = new PL_LeaveTrasaction()
            {
                Ind = 4,
                CityCode = Convert.ToInt32(Session["CityCode"]),
                Empno = Convert.ToInt32(txtEmployeeNo.Text.Trim()),

                NoOfLv = Convert.ToDecimal(txtNoOfDays.Text.Trim()),
                LvCd = Convert.ToInt32(ddlTypeofLeave.SelectedValue),
                DateFrom = txtFromDate.Text == "" ? " " : Salary_CLSCommon.ConvertToDate(txtFromDate.Text.Trim()),
                DateTo = txtToDate.Text == "" ? " " : Salary_CLSCommon.ConvertToDate(txtToDate.Text.Trim()),
                Month = Convert.ToString(Session["Month"]),
                Upd_Ind = 0,
                Narr = txtNarration.Text.Trim()
            };
            string uri = string.Format("LeaveTrasaction/SaveData");
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
                    ShowMessage("Record Save successfully Employee No. Is  " + dt.Rows[0]["empno"].ToString(), true);
                    // bindGrid();
                    GvTransaction.DataSource = null;
                    GvTransaction.DataBind();
                    DivTrans.Visible = false;
                    clear();

                    return;
                }
            }
        }
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        bindGrid();
        ddlTypeofLeave.Focus();
    }


    public void bindGrid()
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/SearchByEmpNo?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
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
                if (dt.Rows[0]["NoOfLv"].ToString() == "")
                {
                    GvTransaction.DataSource = null;
                    GvTransaction.DataBind();
                    DivTrans.Visible = false;

                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    GvTransaction.DataSource = dt;
                    GvTransaction.DataBind();
                    DivTrans.Visible = true;
                    ddlTypeofLeave.ClearSelection();
                    txtNoOfDays.Text = "";
                    txtNarration.Text = "";
                    txtFromDate.Text = "";
                    txtToDate.Text = "";

                }
            }
            else
            {
                GvTransaction.DataSource = null;
                GvTransaction.DataBind();
                DivTrans.Visible = false;
                clear();
                lblMsg.Text = "Invalid Employee";
                lblMsg.CssClass = "alertMsg failed";
            }
        }
        else
        {
            GvTransaction.DataSource = null;
            GvTransaction.DataBind();
            DivTrans.Visible = false;
            clear();
            lblMsg.Text = "Invalid Employee";
            lblMsg.CssClass = "alertMsg failed";
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlTypeofLeave.ClearSelection();
        txtNoOfDays.Text = "";
        txtNarration.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        DivTrans.Visible = false;
        GvTransaction.DataSource = null;
        GvTransaction.DataBind();
        txtEmployeeNo.Focus();
    }
    void clear()
    {
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        ddlTypeofLeave.ClearSelection();
        txtNoOfDays.Text = "";
        txtNarration.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtEmployeeNo.Focus();
    }

    void clearUpdate()
    {

        txtName.Text = "";
        txtDesignation.Text = "";
        ddlTypeofLeave.ClearSelection();
        txtNoOfDays.Text = "";
        txtNarration.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtEmployeeNo.Focus();
    }


    //bool btnUpdationValidation()
    //{
    //    if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
    //    {
    //        txtEmployeeNo.Focus();
    //        ShowMessage("Please Enter Employee No", false);
    //        return false;
    //    }
    //    if (txtFromDate.Text != "" && txtToDate.Text != "")
    //    {
    //        DateTime F_Date = Convert.ToDateTime(txtFromDate.Text.Substring(6, 4) + "/" + txtFromDate.Text.Substring(3, 2) + "/" + txtFromDate.Text.Substring(0, 2));
    //        DateTime T_Date = Convert.ToDateTime(txtToDate.Text.Substring(6, 4) + "/" + txtToDate.Text.Substring(3, 2) + "/" + txtToDate.Text.Substring(0, 2));
    //        if (F_Date > T_Date)
    //        {
    //            ShowMessage(" From Date Should Not Be Greater Than To Date", false);
    //            txtFromDate.Focus();
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    protected void btnUpdate_Click(object sender, EventArgs e)
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

            plobj = new PL_LeaveTrasaction();
            {
                plobj.Ind = 4;
                plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
                plobj.Empno = Convert.ToInt32(txtEmployeeNo.Text.Trim());
                plobj.LvCd = Convert.ToInt32(ddlTypeofLeave.SelectedValue);
                plobj.NoOfLv = Convert.ToDecimal(txtNoOfDays.Text.Trim());
                plobj.DateFrom = Salary_CLSCommon.ConvertToDate(txtFromDate.Text.Trim());
                plobj.DateTo = Salary_CLSCommon.ConvertToDate(txtToDate.Text.Trim());
                plobj.Month = Convert.ToString(Session["Month"]);
                plobj.Upd_Ind = 0;
                plobj.Narr = txtNarration.Text.Trim();
            }
            string uri = string.Format("LeaveTrasaction/UpdateData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
            string lastno = dt.Rows[0][0].ToString();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    bindGrid();
                    clearUpdate();
                    ShowMessage("Record Update successfully", true);
                    GvTransaction.DataSource = null;
                    GvTransaction.DataBind();
                    DivTrans.Visible = false;
                    return;
                }
            }
        }
    }
    protected void ddlTypeofLeave_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTypeofLeave.SelectedValue == "6")
        {
            DivDate.Visible = true;
            txtFromDate.Text = "";
            txtToDate.Text = "";

        }
        else
        {
            DivDate.Visible = false;
            txtFromDate.Text = "";
            txtToDate.Text = "";

        }
        ddlTypeofLeave.Focus();

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

        lblMsg.Text = "";
        lblMsg.CssClass = "";
        LinkButton btnEdit = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        int rowindex = gvr.RowIndex;
        Label EmpNo = (Label)GvTransaction.Rows[rowindex].FindControl("lblEmpNo");
        Label Name = (Label)GvTransaction.Rows[rowindex].FindControl("lblName");
        Label DesgDesc = (Label)GvTransaction.Rows[rowindex].FindControl("lblDesgDesc");
        Label LvCd = (Label)GvTransaction.Rows[rowindex].FindControl("lblLvCd");
        Label NoOfLv = (Label)GvTransaction.Rows[rowindex].FindControl("lblNoOfLv");
        Label FormDate = (Label)GvTransaction.Rows[rowindex].FindControl("lblFormDate");
        Label ToDate = (Label)GvTransaction.Rows[rowindex].FindControl("lblToDate");
        Label Narr = (Label)GvTransaction.Rows[rowindex].FindControl("lblNarr");
        txtEmployeeNo.Text = EmpNo.Text;
        txtName.Text = Name.Text;
        txtDesignation.Text = DesgDesc.Text;
        ddlTypeofLeave.SelectedValue = LvCd.Text;
        txtNoOfDays.Text = NoOfLv.Text;

        if (LvCd.Text == "6")
        {
            DivDate.Visible = true;
            txtFromDate.Text = FormDate.Text;
            txtToDate.Text = ToDate.Text;
        }
        else
        {
            DivDate.Visible = false;
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
        txtNarration.Text = Narr.Text;
        btnUpdate.Visible = true;
        btnDelete.Visible = false;
        btnSave.Visible = false;
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        LinkButton btnEdit = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
        int rowindex = gvr.RowIndex;
        Label EmpNo = (Label)GvTransaction.Rows[rowindex].FindControl("lblEmpNo");
        Label Name = (Label)GvTransaction.Rows[rowindex].FindControl("lblName");
        Label DesgDesc = (Label)GvTransaction.Rows[rowindex].FindControl("lblDesgDesc");
        Label LvCd = (Label)GvTransaction.Rows[rowindex].FindControl("lblLvCd");
        Label NoOfLv = (Label)GvTransaction.Rows[rowindex].FindControl("lblNoOfLv");
        Label FormDate = (Label)GvTransaction.Rows[rowindex].FindControl("lblFormDate");
        Label ToDate = (Label)GvTransaction.Rows[rowindex].FindControl("lblToDate");
        Label Narr = (Label)GvTransaction.Rows[rowindex].FindControl("lblNarr");
        txtEmployeeNo.Text = EmpNo.Text;
        txtName.Text = Name.Text;
        txtDesignation.Text = DesgDesc.Text;
        ddlTypeofLeave.SelectedValue = LvCd.Text;
        txtNoOfDays.Text = NoOfLv.Text;
        if (LvCd.Text == "6")
        {
            DivDate.Visible = true;
            txtFromDate.Text = FormDate.Text;
            txtToDate.Text = ToDate.Text;
        }
        else
        {
            DivDate.Visible = false;
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
        txtNarration.Text = Narr.Text;
        btnUpdate.Visible = false;
        btnDelete.Visible = true;
        btnSave.Visible = false;
    }
    //protected void txtNoOfDays_TextChanged(object sender, EventArgs e)
    //{
    //    lblMsg.Text = "";
    //    lblMsg.CssClass = "";
    //    decimal inputNoofday = Convert.ToDecimal(txtNoOfDays.Text);
    //    decimal alreadyleaveday = Convert.ToDecimal(ViewState["TotalLeave"]);
    //    decimal validday = inputNoofday + alreadyleaveday;
    //    if (Convert.ToDecimal(ViewState["TotalNoofDayMonth"]) < validday)
    //    {
    //        ShowMessage("No of Days are not Greater then Insert Month days", false);
    //        txtNoOfDays.Text = "";
    //        txtNoOfDays.Focus();
    //        return false;
    //    }



    //}

    protected void chkSuspendCase_CheckedChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (chkSuspendCase.Checked == true)
        {
           
            DataTable dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/BindSuspendCase?Ind=6&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&month=" + Session["Month"] + "");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
                    gvPopupSuspendCase.DataSource = dt;
                    gvPopupSuspendCase.DataBind();
                    divSusCase.Visible = true;

                }
                else
                {
                    ShowMessage("No Record Found ..!!!", false);
                }
            }
            else
            {
                ShowMessage("No Record Found ..!!!", false);
            }
        }
        else
        {
            divSusCase.Visible = false;
        }
    }

    //protected void chkGridCheckbox_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in gvPopupSuspendCase.Rows)
    //    {
    //        CheckBox chkbox = (CheckBox)row.FindControl("chkGridCheckbox");
    //        TextBox narration = (TextBox)row.FindControl("txtNarration");

    //        if (chkbox.Checked == true)
    //        {

    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
    //            divSusCase.Visible = true;
    //            narration.Focus();
    //        }
    //    }
    //}
    protected void BtnSusDelete_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";

        LinkButton btnEdit1 = (LinkButton)sender;
        GridViewRow gvr1 = (GridViewRow)btnEdit1.NamingContainer;
        int rowindex = gvr1.RowIndex;
        Label EmpNo = (Label)gvPopupSuspendCase.Rows[rowindex].FindControl("lblEmpNo1");
        TextBox Narration = (TextBox)gvPopupSuspendCase.Rows[rowindex].FindControl("txtNarrationPopup");
        if (Narration.Text.Trim() == "")
        {
            lblPopErrorMsg.Text = "Please Enter Narration";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#myModal').modal('show');});", true);
            Narration.BorderColor = System.Drawing.Color.Red;
            return;
        }


        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("LeaveTrasaction/DeleteSuspenCase?Ind=7&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + EmpNo.Text + "&month=" + Session["Month"] + "&Narration= " + Narration.Text.Trim() + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Employee Record Deleted Employee No Is :- " + dt.Rows[0]["empno"] + "'); $('.modal-backdrop').removeClass('modal-backdrop');", true);
            }

        }

    }
}