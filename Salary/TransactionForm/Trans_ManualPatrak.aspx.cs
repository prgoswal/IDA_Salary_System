using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TransactionForm_Trans_ManualPatrak : System.Web.UI.Page
{
    PL_ManualPatrak plob;
    DataTable dt;
    DataSet ds;
    DataTable dtGvItemDetail = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            txtCurrentMonth.Text = Session["Month"].ToString();
            BindLoadAll();
            ViewState["grdData"] = null;
            GvEdcd.DataSource = null;
            GvEdcd.DataBind();
            txtEmpNo.Focus();
        }
    }

    public void BindLoadAll()
    {
        Var_dubRecord = 0;
        txtVoucherNo.Text = "";
        hfNoOfDay.Value = "";
        ddlEffectiveMonth.Items.Clear();
        ds = Salary_CLSCommon.CallApiGet("ManualPatrak/BindAllLoad?flag=4&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&MonthCd=" + Convert.ToInt32(Session["MonthCd"]) + "&Month=" + Session["Month"].ToString() + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlEffectiveMonth.DataSource = ds.Tables[0];
                    ddlEffectiveMonth.DataTextField = "DMonth";
                    ddlEffectiveMonth.DataValueField = "MonthCd";
                    ddlEffectiveMonth.DataBind();
                    ddlEffectiveMonth.Items.Insert(0, new ListItem("--SELECT--", "0"));
                }
                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtVoucherNo.Text = ds.Tables[1].Rows[0]["MaxVno"].ToString(); ds.Tables[1].Rows[0]["MaxVno"].ToString();
                        ViewState["MaxVoNo"] = ds.Tables[1].Rows[0]["MaxVno"].ToString();
                        txtEnteryDate.Text = ds.Tables[1].Rows[0]["CurrentDate"].ToString();
                        txtVoucherDate.Text = ds.Tables[1].Rows[0]["CurrentDate"].ToString();
                    }
                }
                if (ds.Tables.Count > 2)
                {
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        hfNoOfDay.Value = ds.Tables[2].Rows[0]["NoofDayCurrMonth"].ToString();
                    }
                }

                //if (ds.Tables.Count > 3)
                //{
                //    if (ds.Tables[3].Rows.Count > 0)
                //    {
                //        ddlType.DataSource = ds.Tables[3];
                //        ddlType.DataTextField = "TypeDesc";
                //        ddlType.DataValueField = "TypeId";
                //        ddlType.DataBind();
                //        ddlType.Items.Insert(0, new ListItem("--SELECT--", "0"));
                //    }
                //}
            }
        }
    }
    protected void txtEmpNo_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (txtEmpNo.Text.Trim() != "")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("ManualPatrak/FillEmp?flag=8&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&EmpNo=" + txtEmpNo.Text.Trim() + "");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblEmpName.Text = dt.Rows[0]["EmpName"].ToString();
                    lblDesignation.Text = dt.Rows[0]["DesgDesc"].ToString();
                    ddlEffectiveMonth.Focus();
                    ddlEffectiveMonth.ClearSelection();
                    ViewState["grdData"] = null;
                    GvEdcd.DataSource = null;
                    GvEdcd.DataBind();
                }
                else
                {
                    lblMsg.Text = "Invalid Employee";
                    lblMsg.CssClass = "alertMsg failed";
                    AddGridClear();
                    ViewState["grdData"] = null;
                    //GvEdcd.DataSource = null;
                    //GvEdcd.DataBind();
                    //BindLoadAll();
                    txtEmpNo.Focus();
                }
            }
            else
            {
                lblMsg.Text = "Invalid Employee";
                lblMsg.CssClass = "alertMsg failed";
                AddGridClear();
                // ViewState["grdData"] = null;
                // GvEdcd.DataSource = null;
                // GvEdcd.DataBind();
                // BindLoadAll();
                txtEmpNo.Focus();
            }
        }
    }

    public void BindEdCd()
    {
        if (txtEmpNo.Text.Trim() != "" && ddlType.SelectedValue != "0")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("ManualPatrak/FillEdCd?flag=3&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&EmpNo=" + txtEmpNo.Text.Trim() + "&Indication=" + ddlType.SelectedValue + "");
            ddlEarDed.ClearSelection();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ddlEarDed.DataSource = dt;
                    ddlEarDed.DataTextField = "AbrDesc";
                    ddlEarDed.DataValueField = "Edcd";
                    ddlEarDed.DataBind();
                    ddlEarDed.Items.Insert(0, new ListItem("--SELECT--", "0"));
                }
            }
        }
    }

    DataTable CreateGriddt()
    {
        DataTable DataRow = new DataTable();
        DataRow.Columns.Add("AbrDesc", typeof(string));
        DataRow.Columns.Add("TypeDesc", typeof(string));
        DataRow.Columns.Add("RefNo", typeof(decimal));
        DataRow.Columns.Add("Edcd", typeof(int));
        DataRow.Columns.Add("DrCr", typeof(int));
        DataRow.Columns.Add("EffMonth", typeof(string));
        DataRow.Columns.Add("Vno", typeof(int));
        DataRow.Columns.Add("Vdate", typeof(string));
        DataRow.Columns.Add("med", typeof(decimal));
        DataRow.Columns.Add("pl", typeof(decimal));
        DataRow.Columns.Add("hpl", typeof(decimal));
        DataRow.Columns.Add("lwp", typeof(decimal));
        DataRow.Columns.Add("cl", typeof(decimal));
        DataRow.Columns.Add("el", typeof(decimal));
        DataRow.Columns.Add("entdate", typeof(string));
        DataRow.Columns.Add("transno", typeof(int));
        DataRow.Columns.Add("narr", typeof(string));
        DataRow.Columns.Add("Type", typeof(int));
        DataRow.Columns.Add("Selection", typeof(string));
        DataRow.Columns.Add("EmpNo", typeof(int));
        DataRow.Columns.Add("Amount", typeof(decimal));
        DataRow.Columns.Add("TotalDay", typeof(decimal));
        return DataRow;
    }

    DataTable GvTempTable
    {
        get { return (DataTable)ViewState["grdData"]; }
        set { ViewState["grdData"] = value; }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEdCd();
        ddlType.Focus();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
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
            DataTable dtTemp = new DataTable();
            if (GvTempTable == null)
            {
                dtTemp = CreateGriddt();
            }
            else
            {
                dtTemp = GvTempTable;
                ViewState["grdData"] = dtTemp;
            }

            if (ViewState["grdData"] != null)
            {
                DataTable dtItemName = (DataTable)ViewState["grdData"];
                DataRow[] rows = dtItemName.Select("Edcd=" + ddlEarDed.SelectedValue);
                if (rows.Count() >= 1)
                {
                    lblMsg.Text = "Head Name Already Added.";
                    lblMsg.CssClass = "alertMsg failed";
                    return;
                }
            }
            DataRow dr = dtTemp.NewRow();
            dr["AbrDesc"] = ddlEarDed.SelectedItem.Text.ToString();
            dr["TypeDesc"] = ddlType.SelectedItem.Text.ToString();
            dr["RefNo"] = Convert.ToDecimal(0);
            dr["Edcd"] = Convert.ToInt32(ddlEarDed.SelectedValue);
            dr["DrCr"] = 0;
            dr["EffMonth"] = ddlEffectiveMonth.SelectedItem.Text.ToString();
            dr["Vno"] = Convert.ToInt32(txtVoucherNo.Text.Trim());
            dr["Vdate"] = Salary_CLSCommon.ConvertToDate(txtVoucherDate.Text);
            dr["med"] = Convert.ToDecimal(txtMedical.Text == "" ? "0" : txtMedical.Text);
            dr["pl"] = Convert.ToDecimal(0);
            dr["hpl"] = Convert.ToDecimal(txtHPL.Text == "" ? "0" : txtHPL.Text);
            dr["lwp"] = Convert.ToDecimal(0);
            dr["cl"] = Convert.ToDecimal(txtCL.Text == "" ? "0" : txtCL.Text);
            dr["el"] = Convert.ToDecimal(txtEL.Text == "" ? "0" : txtEL.Text);
            dr["entdate"] = Salary_CLSCommon.ConvertToDate(txtEnteryDate.Text);
            dr["transno"] = 0;
            dr["narr"] = txtNarration.Text;
            dr["Type"] = Convert.ToInt16(ddlType.SelectedValue);
            dr["Selection"] = "0";
            dr["EmpNo"] = Convert.ToInt32(txtEmpNo.Text.Trim());
            dr["Amount"] = Convert.ToDecimal(txtAmount.Text);
            dr["TotalDay"] = txtToatlDaysPrasent.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtToatlDaysPrasent.Text);
            dtTemp.Rows.Add(dr);
            ViewState["grdData"] = dtTemp;
            GvEdcd.DataSource = GvTempTable = dtTemp;
            GvEdcd.DataBind();
            Var_dubRecord = 0;
            btnAdd.Text = "Add";
            AddGridClear1();
            btnCalculate.Visible = false;
        }
    }

    void AllClear()
    {
        btnCalculate.Visible = true;
        txtEmpNo.Text = "";
        ddlEarDed.ClearSelection();
        ddlType.ClearSelection();
        ddlEarDed.ClearSelection();
        txtAmount.Text = "";
        txtToatlDaysPrasent.Text = "";
        txtVoucherDate.Text = "";
        txtMedical.Text = "";
        txtEL.Text = "";
        txtHPL.Text = "";
        txtCL.Text = "";
        txtNarration.Text = "";
        ddlType.ClearSelection();
        ddlEarDed.ClearSelection();
        lblEmpName.Text = "";
        lblDesignation.Text = "";
        ddlEffectiveMonth.ClearSelection();
        ViewState["grdData"] = null;
        GvEdcd.DataSource = null;
        GvEdcd.DataBind();
        BindLoadAll();
        Var_dubRecord = 0;
        txtSuspend.Text = "";
        txtEL.Enabled = true;
        txtCL.Enabled = true;
        txtHPL.Enabled = true;
        txtMedical.Enabled = true;
        ddlEffectiveMonth.ClearSelection();
    }

    void AddGridClear()
    {
        ddlType.SelectedValue = "0";
        lblEmpName.Text = "";
        lblDesignation.Text = "";
        chkLeaveType.Checked = false;
        txtVoucherDate.Text = "";
        ddlEarDed.ClearSelection();
        txtNarration.Text = "";
        txtAmount.Text = "";
        txtSuspend.Text = "";
        txtEL.Enabled = true;
        txtCL.Enabled = true;
        txtHPL.Enabled = true;
        txtMedical.Enabled = true;

    }
    void AddGridClear1()
    {
        //ddlType.SelectedValue = "0";
        //lblEmpName.Text = "";
        //lblDesignation.Text = "";
        //chkLeaveType.Checked = false;
        //txtVoucherDate.Text = "";
        ddlEarDed.ClearSelection();
        //txtNarration.Text = "";
        txtAmount.Text = "";
        //txtSuspend.Text = "";
        //txtEL.Enabled = true;
        //txtCL.Enabled = true;
        //txtHPL.Enabled = true;
        //txtMedical.Enabled = true;

    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (Var_dubRecord == 0)
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            btnAdd.Text = "Update";
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            Label AbrDesc = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblDesc");
            Label TypeDesc = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblTypeDesc");
            Label EmpNo = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblEmpNo");
            Label Edcd = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblEdcd");
            Label Amount = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblAmount");
            Label RefNo = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblRefNo");
            Label DrCr = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblDrCr");
            Label EffMonth = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblEffMonth");
            Label Vno = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblVno");
            Label Vdate = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblVdate");
            Label med = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblmed");
            Label hpl = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblhpl");
            Label cl = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblcl");
            Label el = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblel");
            Label entdate = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblentdate");
            Label transno = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lbltransno");
            Label narr = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblnarr");
            Label Type = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblType");
            Label Selection = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblSelection");
            Label TotlalLeavet = (Label)GvEdcd.Rows[rowindex].FindControl("gv_lblTotlalLeavet");
            //ddlType.SelectedItem.Text = TypeDesc.Text;

            ddlType.SelectedValue = Type.Text;


            if (ddlType.SelectedValue != "0")
            {
                BindEdCd();
            }
            ddlEarDed.SelectedValue = Edcd.Text;

            txtEmpNo.Text = EmpNo.Text;

            txtAmount.Text = Amount.Text;

            decimal aa = Convert.ToDecimal(hpl.Text) + Convert.ToDecimal(med.Text) + Convert.ToDecimal(cl.Text) + Convert.ToDecimal(el.Text);
            if (aa > 0)
            {
                txtSuspend.Text = "0";
            }
            else
            {
                txtSuspend.Text = TotlalLeavet.Text;
            }
            DrCr.Text = DrCr.Text;
            txtVoucherNo.Text = Vno.Text;
            txtVoucherDate.Text = Vdate.Text.Substring(8, 2) + "/" + Vdate.Text.Substring(5, 2) + "/" + Vdate.Text.Substring(0, 4);
            txtMedical.Text = med.Text;
            txtEL.Text = el.Text;
            txtHPL.Text = hpl.Text;
            txtCL.Text = cl.Text;
            txtEnteryDate.Text = entdate.Text.Substring(8, 2) + "/" + entdate.Text.Substring(5, 2) + "/" + entdate.Text.Substring(0, 4);
            transno.Text = transno.Text;
            txtNarration.Text = narr.Text;
            ddlType.SelectedValue = Type.Text;
            ddlEffectiveMonth.SelectedItem.Text = EffMonth.Text;
            txtToatlDaysPrasent.Text = TotlalLeavet.Text;
        }
    }

    static int Var_dubRecord = 0;
    protected void GvEdcd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if ((e.CommandName == "DeleteRow") || (e.CommandName == "Select1"))
            {
                if (e.CommandName == "Select1")
                {
                    if (Var_dubRecord == 0)
                    {
                        Var_dubRecord = 1;
                        dtGvItemDetail = GvTempTable;
                        dtGvItemDetail.Rows[rowIndex].Delete();
                        GvTempTable = dtGvItemDetail;
                        GvEdcd.DataSource = dtGvItemDetail;
                        GvEdcd.DataBind();
                        ViewState["grdData"] = dtGvItemDetail;
                    }
                    else
                    {
                        lblMsg.Text = "Yor are already click edit button.firstly update record";
                        lblMsg.CssClass = "alertMsg failed";
                        lblMsg.Attributes.Remove("style");
                        return;
                    }
                }
                else
                {
                    Var_dubRecord = 0;
                    dtGvItemDetail = GvTempTable;
                    dtGvItemDetail.Rows[rowIndex].Delete();
                    GvTempTable = dtGvItemDetail;
                    GvEdcd.DataSource = dtGvItemDetail;
                    GvEdcd.DataBind();
                    ViewState["grdData"] = dtGvItemDetail;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (GvEdcd.Rows.Count <= 0)
        {
            lblMsg.Text = "Please Add at least one item in gridview";
            lblMsg.CssClass = "alertMsg failed";
            return;
        }
        plob = new PL_ManualPatrak();
        plob.flag = 1;
        plob.CityCode = Convert.ToInt32(Session["CityCode"]);
        plob.Month = Session["Month"].ToString();
        plob.EffectiveMonth = ddlEffectiveMonth.SelectedItem.Text;
        plob.UserId = Convert.ToInt32(Session["UserId"]);
        plob.EmpNo = Convert.ToInt32(txtEmpNo.Text.Trim());
        DataTable dt12 = (DataTable)ViewState["grdData"];
        dt12.Columns.Remove("AbrDesc");
        dt12.Columns.Remove("TypeDesc");
        plob.dt_Grid = dt12;
        plob.dt_Grid.TableName = "Manual Patrak";
        dt = new DataTable();
        dt = Salary_CLSCommon.ApiPostDataTable("ManualPatrak/SaveManualPatrak", plob);
        string lastno = dt.Rows[0][0].ToString();
        if (lastno == "1")
        {
            lblMsg.Text = "Record Save Successfully";
            lblMsg.CssClass = "alertMsg success";
            AllClear();
            BindLoadAll();
            txtEmpNo.Focus();
            return;
        }
        else
        {
            lblMsg.Text = "Record Not Save ";
            lblMsg.CssClass = "alertMsg failed";
            GvEdcd.DataSource = null;
            GvEdcd.DataBind();
        }
    }
    void LeaveCalulation()
    {
        decimal EL = 0; decimal CL = 0; decimal HPL = 0; decimal MED = 0;
        if (txtEL.Text.Trim() == "")
        {
            EL = 0;
        }
        else
        {
            EL = Convert.ToDecimal(txtEL.Text);
        }
        if (txtCL.Text.Trim() == "")
        {
            CL = 0;
        }
        else
        {
            CL = Convert.ToDecimal(txtCL.Text);
        }
        if (txtHPL.Text.Trim() == "")
        {
            HPL = 0;
        }
        else
        {
            HPL = Convert.ToDecimal(txtHPL.Text) / 2;
        }
        if (txtMedical.Text.Trim() == "")
        {
            MED = 0;
        }
        else
        {
            MED = Convert.ToDecimal(txtMedical.Text);
        }
        txtToatlDaysPrasent.Text = Convert.ToString(EL + CL + HPL + MED);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        AllClear();
        BindLoadAll();
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        btnAdd.Text = "Add";
    }
    protected void txtMedical_TextChanged(object sender, EventArgs e)
    {
        LeaveCalulation();
        txtHPL.Focus();
    }
    protected void txtHPL_TextChanged(object sender, EventArgs e)
    {
        LeaveCalulation();
        txtCL.Focus();
    }
    protected void txtCL_TextChanged(object sender, EventArgs e)
    {
        LeaveCalulation();
        txtEL.Focus();
    }
    protected void txtEL_TextChanged(object sender, EventArgs e)
    {
        LeaveCalulation();
    }

    protected void txtSuspend_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtToatlDaysPrasent.Text = "";
        txtSuspend.BorderColor = System.Drawing.Color.LightGray;
        if (txtSuspend.Text.Trim() != "")
        {
            if (Convert.ToDecimal(txtSuspend.Text) > Convert.ToDecimal(hfNoOfDay.Value))
            {

                lblMsg.Text = "Total Leave Not Grater Than Current Days Of Month";
                lblMsg.CssClass = "alertMsg failed";
                txtSuspend.Text = "";
                txtSuspend.Focus();
                txtSuspend.BorderColor = System.Drawing.Color.Red;
                return;
            }
            txtCL.Enabled = false;
            txtCL.Text = "0";
            txtEL.Enabled = false;
            txtEL.Text = "0";
            txtHPL.Enabled = false;
            txtHPL.Text = "0";
            txtMedical.Enabled = false;
            txtMedical.Text = "0";
            ddlType.Focus();
            txtToatlDaysPrasent.Text = txtSuspend.Text;
        }
        else
        {
            txtCL.Enabled = true;
            txtCL.Text = "";
            txtEL.Enabled = true;
            txtEL.Text = "";
            txtHPL.Enabled = true;
            txtHPL.Text = "";
            txtMedical.Enabled = true;
            txtMedical.Text = "";
            txtMedical.Focus();

            txtToatlDaysPrasent.Text = "";
        }
    }
    bool btnSaveValidation()
    {
        if (txtEmpNo.Text.Trim() == "")
        {
            txtEmpNo.Focus();
            lblMsg.Text = "Please Enter Employee Number";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (ddlEffectiveMonth.SelectedValue == "0")
        {
            ddlEffectiveMonth.Focus();
            lblMsg.Text = "Please Select Effective Month";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (txtVoucherDate.Text.Trim() == "")
        {
            txtVoucherDate.Focus();
            lblMsg.Text = "Please Enter Voucher Date";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (ddlType.SelectedValue == "0")
        {
            ddlType.Focus();
            lblMsg.Text = "Please Select Type";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (ddlEarDed.SelectedValue == "0")
        {
            ddlEarDed.Focus();
            lblMsg.Text = "Please Select Ear./Ded. Head";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (txtAmount.Text.Trim() == "")
        {
            txtAmount.Focus();
            lblMsg.Text = "Please Enter Amount";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        //else if (txtToatlDaysPrasent.Text.Trim() == "")
        //{
        //    txtToatlDaysPrasent.Focus();
        //    lblMsg.Text = "Please Enter Total Days (P)";
        //    lblMsg.CssClass = "alertMsg failed";
        //    return false;
        //}
        else if (txtToatlDaysPrasent.Text.Trim() != "")
        {
            if (Convert.ToDecimal(txtToatlDaysPrasent.Text) > Convert.ToDecimal(hfNoOfDay.Value))
            {
                lblMsg.Text = "Total Leave Not Grater Than Current Days Of Month";
                lblMsg.CssClass = "alertMsg failed";
                txtToatlDaysPrasent.Focus();
                txtToatlDaysPrasent.BorderColor = System.Drawing.Color.Red;
                return false;
            }
        }
        return true;
    }
    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }


    bool btnCalcValidation()
    {
        if (txtEmpNo.Text.Trim() == "")
        {
            txtEmpNo.Focus();
            lblMsg.Text = "Please Enter Employee Number";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (ddlEffectiveMonth.SelectedValue == "0")
        {
            ddlEffectiveMonth.Focus();
            lblMsg.Text = "Please Select Effective Month";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        //else if (txtVoucherDate.Text.Trim() == "")
        //{
        //    txtVoucherDate.Focus();
        //    lblMsg.Text = "Please Enter Voucher Date";
        //    lblMsg.CssClass = "alertMsg failed";
        //    return false;
        //}
        //else if (ddlType.SelectedValue == "0")
        //{
        //    ddlType.Focus();
        //    lblMsg.Text = "Please Select Type";
        //    lblMsg.CssClass = "alertMsg failed";
        //    return false;
        //}
        //else if (ddlEarDed.SelectedValue == "0")
        //{
        //    ddlEarDed.Focus();
        //    lblMsg.Text = "Please Select Ear./Ded. Head";
        //    lblMsg.CssClass = "alertMsg failed";
        //    return false;
        //}
        //else if (txtAmount.Text.Trim() == "")
        //{
        //    txtAmount.Focus();
        //    lblMsg.Text = "Please Enter Amount";
        //    lblMsg.CssClass = "alertMsg failed";
        //    return false;
        //}
        else if (txtToatlDaysPrasent.Text.Trim() == "")
        {
            txtToatlDaysPrasent.Focus();
            lblMsg.Text = "Please Enter Total Days (P)";
            lblMsg.CssClass = "alertMsg failed";
            return false;
        }
        else if (Convert.ToDecimal(txtToatlDaysPrasent.Text) > Convert.ToDecimal(hfNoOfDay.Value))
        {
            lblMsg.Text = "Total Leave Not Grater Than Current Days Of Month";
            lblMsg.CssClass = "alertMsg failed";
            txtToatlDaysPrasent.Focus();
            txtToatlDaysPrasent.BorderColor = System.Drawing.Color.Red;
            return false;
        }
        return true;
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        bool IsValid = btnCalcValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            DataTable dtTemp = new DataTable();
            if (GvTempTable == null)
            {
                dtTemp = CreateGriddt();
            }
            else
            {
                dtTemp = GvTempTable;
                ViewState["grdData"] = dtTemp;
            }
            if (ViewState["grdData"] != null)
            {
                DataTable dtItemName = (DataTable)ViewState["grdData"];
                DataRow[] rows = dtItemName.Select("Edcd=" + ddlEarDed.SelectedValue);
                if (rows.Count() >= 1)
                {
                    lblMsg.Text = "Head Name Already Added.";
                    lblMsg.CssClass = "alertMsg failed";
                    return;
                }
            }
            plob = new PL_ManualPatrak();
            plob.flag = 1;
            plob.CityCode = Convert.ToInt32(Session["CityCode"]);

            plob.Month = Session["Month"].ToString();
            plob.EmpNo = Convert.ToInt32(txtEmpNo.Text);

            plob.SuspendLeave = txtSuspend.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtSuspend.Text);
            plob.TotalNoOfLeave = Convert.ToDecimal(txtToatlDaysPrasent.Text);
            dt = new DataTable();
            dt = Salary_CLSCommon.ApiPostDataTable("ManualPatrak/CalculateFun", plob);
            if (dt.Rows.Count > 0)
            {
                btnCalculate.Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dtTemp.NewRow();
                    dr["AbrDesc"] = dt.Rows[i]["AbrDesc"];
                    dr["TypeDesc"] = dt.Rows[i]["TypeDesc"];
                    dr["RefNo"] = Convert.ToDecimal(i);
                    dr["Edcd"] = dt.Rows[i]["Edcd"];
                    dr["DrCr"] = 0;
                    dr["EffMonth"] = ddlEffectiveMonth.SelectedItem.Text.ToString();
                    dr["Vno"] = Convert.ToInt32(txtVoucherNo.Text.Trim());
                    dr["Vdate"] = Salary_CLSCommon.ConvertToDate(txtVoucherDate.Text);
                    dr["med"] = Convert.ToDecimal(txtMedical.Text == "" ? "0" : txtMedical.Text);
                    dr["pl"] = Convert.ToDecimal(0);
                    dr["hpl"] = Convert.ToDecimal(txtHPL.Text == "" ? "0" : txtHPL.Text);
                    dr["lwp"] = Convert.ToDecimal(0);
                    dr["cl"] = Convert.ToDecimal(txtCL.Text == "" ? "0" : txtCL.Text);
                    dr["el"] = Convert.ToDecimal(txtEL.Text == "" ? "0" : txtEL.Text);
                    dr["entdate"] = Salary_CLSCommon.ConvertToDate(txtEnteryDate.Text);
                    dr["transno"] = 0;
                    dr["narr"] = txtNarration.Text;
                    dr["Type"] = dt.Rows[i]["Type"];
                    dr["Selection"] = "0";
                    dr["EmpNo"] = Convert.ToInt32(txtEmpNo.Text.Trim());
                    dr["Amount"] = dt.Rows[i]["Amount"];
                    dr["TotalDay"] = Convert.ToDecimal(txtToatlDaysPrasent.Text);
                    dtTemp.Rows.Add(dr);
                    ViewState["grdData"] = dtTemp;
                    GvEdcd.DataSource = GvTempTable = dtTemp;
                    GvEdcd.DataBind();
                   
                   
                }
                AddGridClear1();
                btnAdd.Text = "Add";
            }
        }
    }
    protected void ddlEffectiveMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        btnCalculate.Visible = true;
        DataTable dtt = new DataTable();
        dtt = Salary_CLSCommon.CallApiGetdt("ManualPatrak/GetData?flag=100&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&EmpNo=" + txtEmpNo.Text.Trim() + "&Month=" + txtCurrentMonth.Text.Trim() + "&EffMonth=" + ddlEffectiveMonth.SelectedItem.Text + "");
        if (dtt != null)
        {
            if (dtt.Rows.Count > 0)
            {
                ViewState["grdData"] = dtt;
                GvEdcd.DataSource = dtt;
                GvEdcd.DataBind();
                btnCalculate.Visible = false;
                txtVoucherNo.Text = dtt.Rows[0]["Vno"].ToString();
            }
            else
            {
                txtVoucherNo.Text = ViewState["MaxVoNo"].ToString();
                ViewState["grdData"] = null;
                GvEdcd.DataSource = null;
                GvEdcd.DataBind();
            }
        }
        else
        {
            txtVoucherNo.Text = ViewState["MaxVoNo"].ToString();
            ViewState["grdData"] = null;
            GvEdcd.DataSource = null;
            GvEdcd.DataBind();
        }
        ddlEffectiveMonth.Focus();

    }
}