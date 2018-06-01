using OdpERPSystem.Salary.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterForm_Frm_AmendmentEarningDeduction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            DivmultipalEmp.Visible = false;
            FillSelectType();

        }
    }

    public void FillSelectType()
    {
        DataSet ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FillReportType/FillSelectType?Ind=2&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DDlDesignatio.DataSource = ds.Tables[0];
                    DDlDesignatio.DataTextField = "DesgDesc";
                    DDlDesignatio.DataValueField = "DesgCd";
                    DDlDesignatio.DataBind();
                    DDlDesignatio.Items.Insert(0, new ListItem("--All Department--", "0"));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlDepartment.DataSource = ds.Tables[1];
                    ddlDepartment.DataTextField = "DeptName";
                    ddlDepartment.DataValueField = "DeptCode";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("--All Department--", "0"));
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlClass.DataSource = ds.Tables[2];
                    ddlClass.DataTextField = "ClassDesc";
                    ddlClass.DataValueField = "Classind";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("--All Class--", "0"));
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlEmpType.DataSource = ds.Tables[3];
                    ddlEmpType.DataTextField = "Desc1";
                    ddlEmpType.DataValueField = "EmpType";
                    ddlEmpType.DataBind();
                    ddlEmpType.Items.Insert(0, new ListItem("All Type", "0"));
                }

            }
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        pnlErDedDesc.Visible = false;
        pnlDynClass.Attributes["class"] = "col-sm-12";
        LinkButton1.Text = "Add";
        btnBulkAdd.Text = "Add";
        txtReplaceAmt.Text = "";
        a = 0;
        ClearChk();
        if (chkemp.Checked == true)
        {
            LinkButton1.Visible = false;
            btnBulkAdd.Visible = true;

            DataTable dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("AmendmentErDd/BindEmployee?Ind=9&CityCode=" + Convert.ToUInt32(Session["CityCode"]) + "");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //DDlDesignatio.DataSource = dt;
                    //DDlDesignatio.DataValueField = "DesgCd";
                    //DDlDesignatio.DataTextField = "DesgDesc";
                    //DDlDesignatio.DataBind();
                    //DDlDesignatio.Items.Insert(0, new ListItem("---SELECT---", "0"));
                    ViewState["grdData"] = null;
                    GridDEDUCTION.DataSource = new DataTable();
                    GridDEDUCTION.DataBind();
                    GvBULKEMPLOYEE.DataSource = null;
                    GvBULKEMPLOYEE.DataBind();
                }
            }
            else
            {
                //DDlDesignatio.Items.Clear();
            }
            DivmultipalEmp.Visible = true;
            divpanal.Visible = false;

            //LinkButton1.Visible = false;
            //btnBulkAdd.Visible = true;
        }
        else
        {
            // DDlDesignatio.Items.Clear();
            DivmultipalEmp.Visible = false;
            divpanal.Visible = true;

            ViewState["grdData"] = null;
            GridDEDUCTION.DataSource = new DataTable();
            GridDEDUCTION.DataBind();

            GvBULKEMPLOYEE.DataSource = null;
            GvBULKEMPLOYEE.DataBind();

            LinkButton1.Visible = true;
            btnBulkAdd.Visible = false;

        }
    }
    protected void DDlHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDlHead.SelectedValue == "0")
        {
            ddlDeductionHead.DataSource = new DataTable();
            ddlDeductionHead.DataBind();
        }
        else
        {
            FillDeductionHead();
        }
        DDlHead.Focus();
    }
    public void FillDeductionHead()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("AmendmentErDd/BindDeductionHead?Ind=1&CityCode=" + Convert.ToUInt32(Session["CityCode"]) + "&Edcd=" + DDlHead.SelectedValue + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlDeductionHead.DataSource = dt;
                ddlDeductionHead.DataValueField = "Edcd";
                ddlDeductionHead.DataTextField = "Desc";
                ddlDeductionHead.DataBind();
                ddlDeductionHead.Items.Insert(0, new ListItem("---SELECT---", "0"));
            }
        }
        else
        {
            ddlDeductionHead.Items.Clear();
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }
    protected void txtEmployeeNo_TextChanged(object sender, EventArgs e)
    {
        gvOldEarDed.DataSource = null;
        gvOldEarDed.DataBind();
        pnlErDedDesc.Visible = false;
        pnlDynClass.Attributes["class"] = "col-sm-12";

        a = 0;
        DataSet ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("AmendmentErDd/SearchByEmpNo?Ind=9&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gvOldEarDed.DataSource = ds.Tables[2];
                        gvOldEarDed.DataBind();
                        pnlErDedDesc.Visible = true;
                        pnlDynClass.Attributes["class"] = "col-sm-9";
                    }


                    txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtDesignation.Text = ds.Tables[0].Rows[0]["DesgDesc"].ToString();
                    txtName.ReadOnly = true;
                    txtDesignation.ReadOnly = true;
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    if (ViewState["grdData"] != null)
                    {
                        DataTable dt_Table = (DataTable)ViewState["grdData"];
                        string FilterCond1 = "EmpNo=" + txtEmployeeNo.Text;
                        DataRow[] dr = dt_Table.Select(FilterCond1);
                        if (dr.Length > 0)
                        {
                        }
                    }
                    else
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ViewState["grdData"] = ds.Tables[1];
                            GridDEDUCTION.DataSource = IndDTGvItemDetail = ds.Tables[1];
                            GridDEDUCTION.DataBind();
                        }
                        else
                        {
                            ViewState["grdData"] = null;
                            GridDEDUCTION.DataSource = null;
                            GridDEDUCTION.DataBind();
                        }
                    }
                }
                else
                {
                    //ViewState["grdData"] = null;
                    // GridDEDUCTION.DataSource = null;
                    //GridDEDUCTION.DataBind();
                    txtName.Text = "";
                    txtDesignation.Text = "";
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    ShowMessage("Invalid Employee No.", false);
                    return;

                }
            }
        }
        else
        {
            txtName.Text = "";
            txtDesignation.Text = "";
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            GridDEDUCTION.DataSource = null;
            GridDEDUCTION.DataBind();
        }
        DDlHead.Focus();
    }
    //protected void DDlDesignatio_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    dt = Salary_CLSCommon.CallApiGetdt("AmendmentErDd/BindGrid?Ind=3&CityCode=" + Convert.ToUInt32(Session["CityCode"]) + "&DesgCd=" + DDlDesignatio.SelectedValue + "");
    //    if (dt != null)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            if (DDlDesignatio.SelectedValue == "0")
    //            {
    //                GvBULKEMPLOYEE.DataSource = null;
    //                GvBULKEMPLOYEE.DataBind();
    //            }
    //            else
    //            {
    //                GvBULKEMPLOYEE.DataSource = dt;
    //                GvBULKEMPLOYEE.DataBind();
    //                //  lblclassname.Text = dt.Rows[0]["ClassDesc"].ToString();
    //            }
    //        }
    //        else
    //        {
    //            GvBULKEMPLOYEE.DataSource = new DataTable();
    //            GvBULKEMPLOYEE.DataBind();
    //            // lblclassname.Text = "";
    //        }
    //    }
    //    else
    //    {
    //        ddlDeductionHead.Items.Clear();
    //    }
    //}

    public void BindGrid()
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (DDlHead.SelectedItem.Value == "0")
        {
            DDlHead.Focus();
            ShowMessage(" Please Select Head ", false);
            return;
        }
        else if (ddlDeductionHead.SelectedItem.Value == "0")
        {
            ddlDeductionHead.Focus();
            ShowMessage(" Please Select Deduction Head", false);
            return;
        }
        else if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
        {
            txtAmount.Focus();
            ShowMessage("Please Enter Amount", false);
            return;
        }
        else if (ddlFilterType.SelectedItem.Value == "0")
        {
            ddlFilterType.Focus();
            ShowMessage(" Please Select Filter Type", false);
            return;
        }


        PL_AmendmentErDd Plobj = new PL_AmendmentErDd();

        Plobj.Ind = 10;
        Plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        Plobj.Edcd = Convert.ToInt32(ddlDeductionHead.SelectedValue);
        Plobj.DeptCode = Convert.ToInt32(ddlDepartment.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlDepartment.SelectedValue);
        Plobj.DesiCode = Convert.ToInt32(DDlDesignatio.SelectedValue) == 0 ? 0 : Convert.ToInt32(DDlDesignatio.SelectedValue);
        Plobj.ClassCode = Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue);
        Plobj.OldAmt = txtAmount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtAmount.Text.Trim());
        string uri = string.Format("AmendmentErDd/SearchEmployee");
        DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, Plobj);
        if (dt != null)
        {
            GvBULKEMPLOYEE.DataSource = dt;
            GvBULKEMPLOYEE.DataBind();
            btnBulkAdd.Visible = true;

        }

        //DataTable dt = new DataTable();
        //dt = Salary_CLSCommon.CallApiGetdt("AmendmentErDd/BindGrid?Ind=3&CityCode=" + Convert.ToUInt32(Session["CityCode"]) + "&DesgCd=" + DDlDesignatio.SelectedValue + "");
        //if (dt != null)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (DDlDesignatio.SelectedValue == "0")
        //        {
        //            GvBULKEMPLOYEE.DataSource = null;
        //            GvBULKEMPLOYEE.DataBind();
        //        }
        //        else
        //        {
        //            GvBULKEMPLOYEE.DataSource = dt;
        //            GvBULKEMPLOYEE.DataBind();
        //            // lblclassname.Text = dt.Rows[0]["ClassDesc"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        GvBULKEMPLOYEE.DataSource = null;
        //        GvBULKEMPLOYEE.DataBind();
        //        //  lblclassname.Text = "";
        //    }
        //}
        //else
        //{
        //    ddlDeductionHead.Items.Clear();
        //}
    }


    DataTable CreateGriddt()
    {
        DataTable DataRow = new DataTable();
        DataRow.Columns.Add("EmpNo", typeof(decimal));
        DataRow.Columns.Add("name", typeof(string));
        DataRow.Columns.Add("EdCd", typeof(int));
        DataRow.Columns.Add("EdDes", typeof(string));
        DataRow.Columns.Add("OldAmt", typeof(decimal));
        DataRow.Columns.Add("NewAmt", typeof(decimal));
        DataRow.Columns.Add("selectType", typeof(string));
        DataRow.Columns.Add("DesignationNameID", typeof(int));

        DataRow.Columns.Add("FilterType", typeof(int));
        DataRow.Columns.Add("ClassId", typeof(int));
        DataRow.Columns.Add("DeptId", typeof(int));
        return DataRow;
    }

    DataTable IndDTGvItemDetail
    {
        get { return (DataTable)ViewState["grdData"]; }
        set { ViewState["grdData"] = value; }
    }

    DataTable InddtItems
    {
        get { return (DataTable)ViewState["dtItems"]; }
        set { ViewState["dtItems"] = value; }
    }

    void BindGvItemDetail()
    {

        DataTable dtGvItemDetail = new DataTable();
        if (IndDTGvItemDetail == null)
        {
            dtGvItemDetail = CreateGriddt();
        }
        else
        {
            dtGvItemDetail = IndDTGvItemDetail;
            ViewState["grdData"] = dtGvItemDetail;
        }
        DataTable dtItems = InddtItems;
        DataRow dr = dtGvItemDetail.NewRow();
        if (chkemp.Checked == true)
        {
            foreach (GridViewRow gvrow in GvBULKEMPLOYEE.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkItem");
                if (chk != null && chk.Checked)
                {
                    DataRow drr = dtGvItemDetail.NewRow();
                    Label lblEmpNo = (Label)gvrow.FindControl("lblEmpNo");
                    Label lblEmpName = (Label)gvrow.FindControl("lblEmpName");
                    DataTable dt_BankTable = (DataTable)ViewState["grdData"];
                    if (dt_BankTable != null)
                    {
                        DataRow[] dr1 = dt_BankTable.Select("EmpNo=" + lblEmpNo.Text.ToString() + "and EdCd=" + ddlDeductionHead.SelectedValue + "");
                        if (dr1.Any())
                        {
                            DataTable BranchTable = dr1.CopyToDataTable();
                            if (BranchTable.Rows.Count > 0)
                            {
                                ShowMessage("Emp no already exist", false);
                                return;
                            }
                        }
                    }
                    drr["EmpNo"] = lblEmpNo.Text;
                    drr["name"] = lblEmpName.Text;
                    drr["EdCd"] = ddlDeductionHead.SelectedValue;
                    drr["EdDes"] = ddlDeductionHead.SelectedItem.Text;
                    if (chkemp.Checked == true)
                    {
                        drr["OldAmt"] = txtAmount.Text == "" ? "0" : txtAmount.Text.Trim();
                        drr["NewAmt"] = txtReplaceAmt.Text == "" ? "0" : txtReplaceAmt.Text.Trim();

                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt = Salary_CLSCommon.CallApiGetdt("AmendmentErDd/GetOldAmt?Ind=4&CityCode=" + Convert.ToUInt32(Session["CityCode"]) + "&Empno=" + lblEmpNo.Text + "&month=" + Session["Month"] + "&Edcd=" + Convert.ToUInt32(ddlDeductionHead.SelectedValue) + "");
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                ViewState["oldValue"] = dt.Rows[0]["FixAmt"].ToString();
                            }
                        }
                        if (ViewState["oldValue"] != null)
                        {
                            drr["OldAmt"] = ViewState["oldValue"];
                        }
                        else
                        {
                            drr["OldAmt"] = 0;
                        }

                        drr["NewAmt"] = txtAmount.Text.Trim().ToUpper();
                    }
                    drr["selectType"] = DDlHead.SelectedValue;
                    drr["DesignationNameID"] = DDlDesignatio.SelectedValue;


                    drr["FilterType"] = ddlFilterType.SelectedValue;
                    drr["DeptId"] = ddlDepartment.SelectedValue;
                    drr["ClassId"] = ddlClass.SelectedValue;
                    dtGvItemDetail.Rows.Add(drr);
                }
            }
            if (dtGvItemDetail.Rows.Count > 0)
            {
                ViewState["grdData"] = dtGvItemDetail;
                LinkButton1.Text = "Add";
                btnBulkAdd.Text = "Add";
                clearADD1();
            }
            else
            {
                ShowMessage("Please Select At Least One Employee", false);
                return;
            }
            GridDEDUCTION.DataSource = IndDTGvItemDetail = dtGvItemDetail;
            GridDEDUCTION.DataBind();

            LinkButton1.Text = "Add";
            clearADD1();
            pnlDepartment.Visible = false;
            pnlEmpType.Visible = false;

            pnlClass.Visible = true;
        }
        else
        {
            dr["EmpNo"] = txtEmployeeNo.Text.Trim().ToUpper();
            dr["name"] = txtName.Text.Trim();
            dr["EdCd"] = ddlDeductionHead.SelectedValue;
            if (LinkButton1.Text == "ADD")
            {
                DataTable dt_BankTable = (DataTable)ViewState["grdData"];
                if (dt_BankTable != null)
                {
                    DataRow[] dr1 = dt_BankTable.Select("EmpNo=" + txtEmployeeNo.Text.ToString() + "and EdCd=" + ddlDeductionHead.SelectedValue + "");
                    if (dr1.Any())
                    {
                        DataTable BranchTable = dr1.CopyToDataTable();
                        if (BranchTable.Rows.Count > 0)
                        {
                            ShowMessage("Emp No Already Exit", false);
                            return;
                        }
                    }
                }
            }
            dr["EdDes"] = ddlDeductionHead.SelectedItem.Text;
            if (ViewState["oldValue"] != null)
            {
                dr["OldAmt"] = ViewState["oldValue"];
            }
            else
            {
                dr["OldAmt"] = 0;
            }
            dr["NewAmt"] = txtAmount.Text.Trim();
            dr["selectType"] = DDlHead.SelectedValue;
            if (chkemp.Checked == true)
            {
                dr["DesignationNameID"] = DDlDesignatio.SelectedValue;

                dr["FilterType"] = ddlFilterType.SelectedValue;
                dr["DeptId"] = ddlDepartment.SelectedValue;
                dr["ClassId"] = ddlClass.SelectedValue;
            }
            dtGvItemDetail.Rows.Add(dr);
            ViewState["grdData"] = dtGvItemDetail;
            GridDEDUCTION.DataSource = IndDTGvItemDetail = dtGvItemDetail;
            GridDEDUCTION.DataBind();
            LinkButton1.Text = "Add";
            btnBulkAdd.Text = "Add";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (chkemp.Checked == true)
        {

            if (DDlHead.SelectedItem.Value == "0")
            {
                DDlHead.Focus();
                ShowMessage(" Please Select Head ", false);
                return;
            }
            else if (ddlDeductionHead.SelectedItem.Value == "0")
            {
                ddlDeductionHead.Focus();
                ShowMessage(" Please Select Deduction Head", false);
                return;
            }
            else if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                txtAmount.Focus();
                ShowMessage("Please Enter Amount", false);
                return;
            }


            else if (btnBulkAdd.Visible == true)
            {
                if (string.IsNullOrEmpty(txtReplaceAmt.Text.Trim()))
                {
                    txtReplaceAmt.Focus();
                    ShowMessage("Please Enter Replace Amount", false);
                    return;
                }
            }
                       

            BindGvItemDetail();

            //LinkButton1.Text = "Add";
            //clearADD1();
            //pnlDepartment.Visible = false;
            //pnlEmpType.Visible = false;

            //pnlClass.Visible = true;
        }
        else
        {
            if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()))
            {
                txtEmployeeNo.Focus();
                ShowMessage("Please Enter Employee No.", false);
                return;
            }
            else if (DDlHead.SelectedItem.Value == "0")
            {
                DDlHead.Focus();
                ShowMessage(" Please Select Head ", false);
                return;
            }
            else if (ddlDeductionHead.SelectedItem.Value == "0")
            {
                ddlDeductionHead.Focus();
                ShowMessage(" Please Select Deduction Head", false);
                return;
            }
            else if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                txtAmount.Focus();
                ShowMessage("Please Enter Amount", false);
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                dt = Salary_CLSCommon.CallApiGetdt("AmendmentErDd/GetOldAmt?Ind=4&CityCode=" + Convert.ToUInt32(Session["CityCode"]) + "&Empno=" + txtEmployeeNo.Text + "&month=" + Session["Month"] + "&Edcd=" + ddlDeductionHead.SelectedValue + "");
                ViewState["oldValue"] = 0;
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ViewState["oldValue"] = dt.Rows[0]["FixAmt"].ToString();
                    }
                }
                BindGvItemDetail();
                LinkButton1.Text = "Add";
                clearADD1();
            }
        }
        a = 0;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        gvOldEarDed.DataSource = null;
        gvOldEarDed.DataBind();
        pnlErDedDesc.Visible = false;
        pnlDynClass.Attributes["class"] = "col-sm-12";

        chkSelectAll.Checked = false;
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        txtAmount.Text = "0";
        ddlDeductionHead.ClearSelection();
        DDlDesignatio.ClearSelection();
        DDlHead.ClearSelection();
        //  lblclassname.Text = "";
        DivmultipalEmp.Visible = false;
        chkemp.Checked = false;
        divpanal.Visible = true;
        LinkButton1.Text = "Add";
        btnBulkAdd.Text = "Add";
        LinkButton1.Visible = true;
        btnBulkAdd.Visible = true;


        GridDEDUCTION.DataSource = null;
        GridDEDUCTION.DataBind();
        GvBULKEMPLOYEE.DataSource = null;
        GvBULKEMPLOYEE.DataBind();
        ViewState["grdData"] = null;
        txtReplaceAmt.Text = "";

    }
    void clear()
    {
        pnlErDedDesc.Visible = false;
        pnlDynClass.Attributes["class"] = "col-sm-12";

        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        txtAmount.Text = "0";
        //lblclassname.Text = "";
        ddlDeductionHead.ClearSelection();
        DDlDesignatio.ClearSelection();
        DDlHead.ClearSelection();
        GridDEDUCTION.DataSource = null;
        GridDEDUCTION.DataBind();
        GvBULKEMPLOYEE.DataSource = null;
        GvBULKEMPLOYEE.DataBind();
        ViewState["grdData"] = null;
    }

    void clearADD()
    {
        foreach (GridViewRow row in GvBULKEMPLOYEE.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkItem") as CheckBox);
                chkRow.Checked = false;
            }
        }
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        txtAmount.Text = "0";
        // lblclassname.Text = "";
        ddlDeductionHead.DataSource = new DataTable();
        ddlDeductionHead.DataBind();
        DDlDesignatio.ClearSelection();
        DDlHead.ClearSelection();
        GvBULKEMPLOYEE.DataSource = null;
        GvBULKEMPLOYEE.DataBind();
    }

    void clearADD1()
    {
        foreach (GridViewRow row in GvBULKEMPLOYEE.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkItem") as CheckBox);
                chkRow.Checked = false;
            }
        }
        //txtEmployeeNo.Text = "";
        //txtName.Text = "";
        //txtDesignation.Text = "";
        txtAmount.Text = "0";
        // lblclassname.Text = "";
        ddlDeductionHead.DataSource = new DataTable();
        ddlDeductionHead.DataBind();
        DDlDesignatio.ClearSelection();
        ddlDepartment.ClearSelection();

        DDlHead.ClearSelection();
        GvBULKEMPLOYEE.DataSource = null;
        GvBULKEMPLOYEE.DataBind();


        txtReplaceAmt.Text = "";
        ddlFilterType.ClearSelection();
        ddlClass.ClearSelection();

        chkSelectAll.Checked = false;
    }

    public void ClearChk()
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        txtEmployeeNo.Text = "";
        txtName.Text = "";
        txtDesignation.Text = "";
        txtAmount.Text = "0";
        ddlDeductionHead.ClearSelection();
        DDlHead.ClearSelection();


    }
    bool btnSaveValidation()
    {
        if (GridDEDUCTION.Rows.Count == 0)
        {
            ShowMessage("Grid Can not be blank", false);
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
            PL_AmendmentErDd Plobj = new PL_AmendmentErDd();
            DataTable dt12 = (DataTable)ViewState["grdData"];
            dt12.Columns.Remove("DesignationNameID");

            dt12.Columns.Remove("FilterType");
            dt12.Columns.Remove("DeptId");
            dt12.Columns.Remove("ClassId");
            Plobj.dt = dt12;
            Plobj.dt.TableName = "AmendmentErDd";
            Plobj.Ind = 5;
            Plobj.Month = Session["Month"].ToString();
            Plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
            string uri = string.Format("AmendmentErDd/SaveAmendmentData");
            DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, Plobj);
            if (dt != null)
            {
                ShowMessage("Record Save successfully", true);
                clear();
                LinkButton1.Text = "Add";
                txtEmployeeNo.Focus();
                return;
            }
        }
    }
    static int a = 0;
    protected void btnEdit_Click(object sender, EventArgs e)
    {

        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (a == 0)
        {
            a = 1;
            LinkButton btnEdit = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
            int rowindex = gvr.RowIndex;
            Label EmpNo = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblEmpNo");
            Label amt = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblNewAmt");
            Label oldamt = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblOldAmtAMOUNT");
            Label Name = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblName");
            Label selectType = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblselectType");
            Label DeductionHeadCD = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblDeductionHeadCD");
            Label DDLHead = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblHead");

            Label DesignationNameID = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblDesignationNameID");

            Label FilterType = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblFilterType");
            Label DeptId = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblDeptId");
            Label ClassId = (Label)GridDEDUCTION.Rows[rowindex].FindControl("lblClassId");
            txtEmployeeNo.Text = EmpNo.Text;
            txtName.Text = Name.Text;

            if (chkemp.Checked == true)
            {
                DDlHead.SelectedValue = selectType.Text;
                FillDeductionHead();
                ddlDeductionHead.SelectedValue = DeductionHeadCD.Text;
                DDlDesignatio.SelectedValue = DesignationNameID.Text;

                ddlFilterType.SelectedValue = FilterType.Text;
                ddlDepartment.SelectedValue = DeptId.Text;
                ddlClass.SelectedValue = ClassId.Text;


                BindGrid();
                foreach (GridViewRow row in GvBULKEMPLOYEE.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        Label EmpNoBulk = (Label)row.FindControl("lblEmpNo");
                        if (EmpNo.Text == EmpNoBulk.Text)
                        {
                            CheckBox chkRow = (row.FindControl("chkItem") as CheckBox);
                            chkRow.Checked = true;
                        }
                    }
                }
            }
            else
            {
                DDlHead.SelectedValue = selectType.Text;
                FillDeductionHead();
                ddlDeductionHead.SelectedValue = DeductionHeadCD.Text;
            }

            if (btnBulkAdd.Visible == true)
            {
                txtReplaceAmt.Text = amt.Text;
                txtAmount.Text = oldamt.Text;
                btnBulkAdd.Text = "Update";
            }
            else
            {
                ViewState["oldValue"] = oldamt.Text;
                txtAmount.Text = amt.Text;
            }
            LinkButton1.Text = "Update";
            DataTable dt = (DataTable)ViewState["grdData"];
            dt.Rows.RemoveAt(rowindex);
            GridDEDUCTION.DataSource = dt;
            GridDEDUCTION.DataBind();
        }
        else
        {
            ShowMessage("Firstly Update Recored", false);
            return;
        }

    }
    bool btnUpdationValidation()
    {
        if (string.IsNullOrEmpty(txtEmployeeNo.Text.Trim()) || string.IsNullOrEmpty(txtAmount.Text.Trim()))
        {
            ShowMessage("Please Click Edit Button on Grid", false);
            return false;
        }
        return true;
    }
    protected void ddlFilterType_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDepartment.Visible = false;
        Designation.Visible = false;
        pnlEmpType.Visible = false;

        ddlClass.ClearSelection();
        ddlDepartment.ClearSelection();
        ddlDepartment.ClearSelection();
        ddlEmpType.ClearSelection();

        GvBULKEMPLOYEE.DataSource = null;
        GvBULKEMPLOYEE.DataBind();
        chkSelectAll.Checked = false;

        if (ddlFilterType.SelectedValue == "1")
        {
            pnlClass.Visible = true;
        }
        else
        {
            pnlClass.Visible = false;
        }


        if (ddlFilterType.SelectedValue == "2")
        {
            Designation.Visible = true;
        }

        else if (ddlFilterType.SelectedValue == "3")
        {
            pnlDepartment.Visible = true;
        }

        else if (ddlFilterType.SelectedValue == "4")
        {
            pnlEmpType.Visible = true;
        }
        ddlFilterType.Focus();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        chkSelectAll.Checked = false;
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (DDlHead.SelectedItem.Value == "0")
        {
            DDlHead.Focus();
            ShowMessage(" Please Select Head ", false);
            return;
        }
        else if (ddlDeductionHead.SelectedItem.Value == "0")
        {
            ddlDeductionHead.Focus();
            ShowMessage(" Please Select Deduction Head", false);
            return;
        }
        else if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
        {
            txtAmount.Focus();
            ShowMessage("Please Enter Amount", false);
            return;
        }
        else if (ddlFilterType.SelectedItem.Value == "0")
        {
            ddlFilterType.Focus();
            ShowMessage(" Please Select Filter Type", false);
            return;
        }


        PL_AmendmentErDd Plobj = new PL_AmendmentErDd();

        Plobj.Ind = 10;
        Plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        Plobj.Edcd = Convert.ToInt32(ddlDeductionHead.SelectedValue);
        Plobj.DeptCode = Convert.ToInt32(ddlDepartment.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlDepartment.SelectedValue);
        Plobj.DesiCode = Convert.ToInt32(DDlDesignatio.SelectedValue) == 0 ? 0 : Convert.ToInt32(DDlDesignatio.SelectedValue);
        Plobj.ClassCode = Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue);
        Plobj.EmpType = Convert.ToInt32(ddlEmpType.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlEmpType.SelectedValue);
        Plobj.OldAmt = txtAmount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtAmount.Text.Trim());

        string uri = string.Format("AmendmentErDd/SearchEmployee");
        DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, Plobj);
        if (dt != null)
        {
            GvBULKEMPLOYEE.DataSource = dt;
            GvBULKEMPLOYEE.DataBind();
            btnBulkAdd.Visible = true;

        }

    }
    //protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkSelectAll.Checked == true)
    //    {
    //        foreach (GridViewRow row in GvBULKEMPLOYEE.Rows)
    //        {
    //            if (row.RowType == DataControlRowType.DataRow)
    //            {
    //                CheckBox chkRow = (row.FindControl("chkItem") as CheckBox);
    //                chkRow.Checked = true;

    //            }
    //        }
    //    }
    //    else
    //    {
    //        foreach (GridViewRow row in GvBULKEMPLOYEE.Rows)
    //        {
    //            if (row.RowType == DataControlRowType.DataRow)
    //            {
    //                CheckBox chkRow = (row.FindControl("chkItem") as CheckBox);
    //                chkRow.Checked = false;

    //            }
    //        }
    //    }
    //}
    protected void gvOldEarDed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int EdCd = int.Parse(e.Row.Cells[0].Text);
            foreach (TableCell cell in e.Row.Cells)
            {
                if (EdCd < 100)
                {
                    cell.BackColor = Color.LightGreen;
                }
                if (EdCd > 100 && EdCd < 500)
                {
                    cell.BackColor = Color.Yellow;
                }
                if (EdCd == 999)
                {
                    cell.BackColor = Color.IndianRed;
                    cell.Style["font-weight"] = "bold";
                    cell.Style["font-Size"] = "12px";
                }
            }
        }
    }
}