using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Rpt_Rpt_AllDeduction : System.Web.UI.Page
{

    DataTable dt;
    DataSet ds;
    static string Checklistvalue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            FillSelectType();

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
                    //ddlSelectType.Items.Insert(0, new ListItem("--Select Type--", "0"));
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

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    bool btnPreviewValidation()
    {
        if (ddlSelectType.SelectedItem.Value == "0")
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
        else if (ddlSelectType.SelectedItem.Value == "6")
        {
            if (ddlClass.SelectedItem.Value == "0")
            {
                ddlClass.Focus();
                ShowMessage(" Please Select Class", false);
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

        if (ddlHead.SelectedValue == "0")
        {
            ddlHead.Focus();
            ShowMessage("Please Select Head", false);
            return false;
        }

        return true;
    }

    protected void btnpreview_Click(object sender, EventArgs e)
    {
        bool IsValid = btnPreviewValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {

            string val2 = null;
            string val3 = null;
            for (int j = 0; j < chklist.Items.Count; j++)
            {
                if (chklist.Items[j].Selected == true)
                {
                    if (val2 == null)
                        val2 = chklist.Items[j].Value;

                    else
                        val2 = val2 + "," + chklist.Items[j].Value;
                    val3 = val3 + "" + chklist.Items[j].Text;
                }
            }
            Checklistvalue = val2;

            Session["FilterEdcd"] = Checklistvalue;
            Session["TaxName"] = val3;



            //Session["RegDep"] = "0";
            //Session["Regular"] = "0";
            //Session["Deputation"] = "0";
            //Session["RRD"] = "0";
            //Session["OldPay"] = "0";
            //Session["FIXPAY"] = "1";

            //Session["BeforeDoj"] = "0";
            //Session["AferDoj"] = "0";
            //Session["DojBoth"] = "0";

            //Session["FifthPay1"] = "0";
            //Session["SixPay1"] = "0";
            //Session["BothFifth_Six1"] = "0";
            //Session["ErrorMsg1"] = " ";
            //Session["Search"] = 0;
            //Session["Bank"] = "0";
            //Session["Branch"] = "0";
            //Session["Zone"] = " ";
            //Session["Ward"] = " ";
            //Session["Dept"] = " ";
            //Session["SubDept"] = " ";
            //Session["lotfrom"] = " ";
            //Session["lotTo"] = " ";
            //Session["empnof"] = " ";
            //Session["empnot"] = " ";
            //Session["billno"] = "";
            //Session["billdate"] = "";
            //Session["FilterEdcd"] = "1";

            //Session["EmpTypeid"] ="0";
            //Session["classind"] = "0";

            //Session["FIXPAY"] = "0";

            //if (RadioButtonList1.SelectedItem.Value == "0")
            //{
            //    Session["RegDep"] = "0";
            //}
            //if (RadioButtonList1.SelectedItem.Value == "1")
            //{
            //    Session["Regular"] = "1";
            //}
            //if (RadioButtonList1.SelectedItem.Value == "2")
            //{
            //    Session["Deputation"] = "1";
            //}
            //if (RadioButtonList1.SelectedItem.Value == "3")
            //{
            //    Session["RRD"] = "1";
            //}
            //if (Convert.ToInt32(ddlSelectType.SelectedIndex.ToString()) != 0)
            //{
            //    Session["EmpTypeid"] = Convert.ToInt32(ddlSelectType.SelectedValue.ToString());
            //}
            //if (Convert.ToInt32(ddlDepartment.SelectedIndex.ToString()) != 0)
            //{
            //    Session["Dept"] = Convert.ToInt32(ddlDepartment.SelectedValue.ToString());
            //}
            //if (Convert.ToInt32(ddlClass.SelectedIndex.ToString()) != 0)
            //{
            //    Session["classind"] = Convert.ToInt32(ddlClass.SelectedValue.ToString());
            //}
            //Hashtable HT = new Hashtable();
            //HT.Add("Flag", 1);
            //HT.Add("MonthDesc", Session["MonthDesc"].ToString());
            //HT.Add("UserName", Session["UserName"].ToString());
            //HT.Add("EMPTYPENAME", " ");
            //HT.Add("CITYNAME", Session["CorpName"].ToString());
            //HT.Add("MonthDate", Session["Month1"].ToString());
            //HT.Add("Year", Session["finyr"].ToString());
            //HT.Add("BillNo", Session["billno"].ToString());
            //HT.Add("BillDate", Session["billdate"].ToString());
            //HT.Add("EmpType", Session["EmpTypeid"].ToString());
            //HT.Add("MOnth", Session["Month"].ToString());
            //HT.Add("CityCode", Session["CityCode"].ToString());
            //HT.Add("EmpNoFrom", Session["empnof"].ToString());
            //HT.Add("EmpNoTo", Session["empnot"].ToString());
            //HT.Add("FilterEdcd", Session["FilterEdcd"].ToString());
            //HT.Add("MonthCd", Session["MonthCd"].ToString());
            //HT.Add("LotNoF", Session["lotfrom"].ToString());
            //HT.Add("LotNoTo", Session["lotTo"].ToString());
            //HT.Add("Zone", Session["Zone"].ToString());
            //HT.Add("Ward", Session["Ward"].ToString());
            //HT.Add("DeptCd", Session["Dept"].ToString());
            //HT.Add("SubDeptCd", Session["SubDept"].ToString());
            //HT.Add("ErrorMsg", Session["ErrorMsg1"].ToString());
            //HT.Add("Regular", Session["Regular"].ToString());
            //HT.Add("Deputation", Session["Deputation"].ToString());
            //HT.Add("Reg_Dep", Session["RegDep"].ToString());
            //HT.Add("RRD", Session["RRD"].ToString());
            //HT.Add("OldPay", Session["OldPay"].ToString());
            //HT.Add("FifthPay", Session["FifthPay1"].ToString());
            //HT.Add("SixPay", Session["SixPay1"].ToString());
            //HT.Add("BothFifth_Six", Session["BothFifth_Six1"].ToString());
            //HT.Add("BeforeDoj", Session["BeforeDoj"].ToString());
            //HT.Add("AferDoj", Session["AferDoj"].ToString());
            //HT.Add("DojBoth", Session["DojBoth"].ToString());
            //HT.Add("BnkCd", Session["Bank"].ToString());
            //HT.Add("BrCd", Session["Branch"].ToString());
            //HT.Add("classind", Session["classind"].ToString());
            //HT.Add("FIXPAY", Session["FIXPAY"].ToString());

            Hashtable HT = new Hashtable();
            HT.Add("Flag", 1);
            HT.Add("FilterEdcd", Session["FilterEdcd"].ToString());
            HT.Add("MonthDesc", "STATMENT OF " + Session["TaxName"].ToString() + " FOR MONTH : " + Session["MonthDesc"].ToString() + "   " + ddlEmpType.SelectedItem.Text + " Employee");
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
            HT.Add("Reg_Dep", RadioButtonList1.SelectedItem.Value == "0" ? "1" : "0");
            HT.Add("Regular", RadioButtonList1.SelectedItem.Value == "1" ? "1" : "0");
            HT.Add("Deputation", RadioButtonList1.SelectedItem.Value == "2" ? "1" : "0");
            HT.Add("RRD", 0);
            HT.Add("OldPay", 0);
            HT.Add("FifthPay", 0);
            HT.Add("SixPay", 0);
            HT.Add("FIXPAY", 0);
            HT.Add("BothFifth_Six", 0);
            HT.Add("BeforeDoj", 0);
            HT.Add("AferDoj", 0);
            HT.Add("DojBoth", 1);
            HT.Add("BnkCd", 0);
            HT.Add("BrCd", 0);
            HT.Add("EMPTYPENAME", "0");
            HT.Add("MonthDate", Session["Month1"].ToString());
            HT.Add("CITYNAME", Session["CorpName"].ToString());
            HT.Add("Year", Session["finyr"].ToString());
            HT.Add("BillNo", 0);
            HT.Add("BillDate", "0");
            // HT.Add("SelectType", ddlSelectType.SelectedValue);

            HT.Add("EmpNoFrom", txtFromEmp.Text.Trim() == "" ? "0" : txtFromEmp.Text);
            HT.Add("EmpNoTo", txtToEmp.Text.Trim() == "" ? "0" : txtToEmp.Text);
            HT.Add("classind", Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue));

            Session["HT"] = HT;
            Session["Report"] = "AllDeductionList";
            Session["ReportName"] = ddlSelectType.SelectedItem.Text;
            Response.Redirect("ReportViewer.aspx?index=27");
        }
    }
    protected void txtlotfrom_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtlotto_TextChanged(object sender, EventArgs e)
    {
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
        //   ddlEmpType.ClearSelection();
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
    protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.CssClass = "";
        lblMsg.Text = "";
        chkall.Checked = false;

        if (ddlHead.SelectedValue != "0")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("RptDeductionList/FilterHead?Ind=" + ddlHead.SelectedValue + "&CityCode=" + Convert.ToInt32(Session["CityCode"]));

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    EarningPanal.Visible = true;
                    chklist.DataSource = dt;
                    chklist.DataTextField = "Desc";
                    chklist.DataValueField = "Edcd";
                    chklist.DataBind();
                }
            }
        }
        else
        {
            chklist.Items.Clear();
        }
    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        lblMsg.CssClass = "";
        lblMsg.Text = "";
        if (ddlHead.SelectedValue != "0")
        {
            EarningPanal.Visible = true;
            if (chkall.Checked == true)
            {

                string b = "";
                foreach (ListItem li in chklist.Items)
                {

                    li.Selected = true;
                    //a =a + chklist.SelectedValue + ",";
                    //b = b + li.Text + ",";
                    Checklistvalue = Checklistvalue + li.Value.ToString() + ",";
                    //   Session["checklistvalue"] = li.Selected
                    chkall.Text = "Unchecked All";


                }
                Checklistvalue = Checklistvalue.Substring(0, (Checklistvalue.Length - 1));
                Session["FilterEdcd"] = Checklistvalue;
                //b = b.Substring(0, (b.Length - 1));
            }
            else
            {

                foreach (ListItem li in chklist.Items)
                {
                    li.Selected = false;
                    chkall.Text = "Checked All";

                }
            }
        }
        else
        {
            ddlHead.Focus();
            ShowMessage("Please Select Head", false);

        }
    }
}