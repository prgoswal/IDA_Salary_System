using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Rpt_ManualPatrakRegister : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
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
        txtVoucherFrom.Text = "";
        txtVoucherTo.Text = "";
        txtbillno.Text = "";
        txtdate.Text = "";
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "0")
        {
            Session["RegDep"] = "1";
        }
        else
        {
            Session["RegDep"] = "0";
        }
        if (RadioButtonList1.SelectedValue.Trim() == "1")
        {
            Session["Regular"] = "1";
        }
        else
        {
            Session["Regular"] = "0";
        }
        if (RadioButtonList1.SelectedValue == "2")
        {
            Session["Deputation"] = "1";
        }
        else
        {
            Session["Deputation"] = "0";
        }
        if (RadioButtonList1.SelectedValue == "3")
        {
            Session["RRD"] = "1";
        }
        else
        {
            Session["RRD"] = "0";
        }
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
        if (txtVoucherFrom.Text != "")
        {
            if (txtVoucherFrom.Text == "" || txtVoucherTo.Text == "")
            {
                txtVoucherTo.Focus();
                ShowMessage("Please Enter Voucher To", false);
                return false;
            }
            return true;
        }
        if (txtbillno.Text != "")
        {

            if (txtbillno.Text == "" || txtdate.Text == "")
            {
                txtdate.Focus();
                ShowMessage("Please Enter Bill Date ", false);
                return false;
            }
            return true;
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
            Hashtable HT = new Hashtable();
            //string pt = Session["RegDepDesc"] + " >> " + Session["DOJDesc"] + " >> " + Session["PAYDesc"];
            //string pt1 = Session["ZoneDesc2"] + " " + Session["WardDesc2"] + Session["DeptDesc2"] + "  " + Session["SubDeptDesc2"] + " " + Session["lotfrom1"] + " " + Session["lotTo1"] + " " + Session["empnof1"] + " " + Session["empnot1"] + " " + Session["billno1"] + " " + Session["billdate1"];
            HT.Add("MonthDesc", Session["MonthDesc"].ToString() + "   " + ddlEmpType.SelectedItem.Text + " Employee");
            HT.Add("UserName", Session["UserName"].ToString());
            HT.Add("MonthCd", Session["MonthCd"].ToString());
            HT.Add("EmpType", ddlEmpType.SelectedValue);
            HT.Add("LotNoF", txtFromLot.Text == "" ? "0" : txtFromLot.Text);
            HT.Add("LotNoTo", txtToLot.Text == "" ? "0" : txtToLot.Text);
            HT.Add("VnoFrom", txtVoucherFrom.Text == "" ? "0" : txtVoucherFrom.Text);
            HT.Add("VnoTo", txtVoucherTo.Text == "" ? "" : txtVoucherTo.Text);
            HT.Add("Zone", "0");
            HT.Add("Ward", "0");
            HT.Add("DeptCd", ddlDepartment.SelectedValue == "0" ? "" : ddlDepartment.SelectedValue);
            HT.Add("SubDeptCd", "");
            HT.Add("MOnth", Session["Month"].ToString());
            HT.Add("CityCode", Session["CityCode"].ToString());
            HT.Add("Reg_Dep", RadioButtonList1.SelectedItem.Value == "0" ? "1" : "0");
            HT.Add("Regular", RadioButtonList1.SelectedItem.Value == "1" ? "1" : "0");
            HT.Add("Deputation", RadioButtonList1.SelectedItem.Value == "2" ? "1" : "0");
            HT.Add("RRD", "0");
            HT.Add("OldPay", "0");
            HT.Add("FifthPay", "0");
            HT.Add("SixPay", "0");
            HT.Add("FIXPAY", "0");
            HT.Add("BothFifth_Six", "0");
            HT.Add("BeforeDoj", "0");
            HT.Add("AferDoj", "0");
            HT.Add("DojBoth", "1");
            HT.Add("BnkCd", "0");
            HT.Add("BrCd", "0");
            HT.Add("ErrorMsg", "");
            HT.Add("EMPTYPENAME", "0");
            HT.Add("MonthDate", Session["Month1"].ToString());
            HT.Add("CITYNAME", Session["CorpName"].ToString());
            HT.Add("Year", Session["finyr"].ToString());
            HT.Add("SearchType", "0");
            //HT.Add("BillNo", pt1.ToString());
            //HT.Add("BillDate", "0");
            HT.Add("BillNo", txtbillno.Text.Trim() == "" ? "0" : txtbillno.Text);
            HT.Add("BillDate", txtdate.Text.Trim() == "" ? "0" : txtdate.Text);
            HT.Add("EmpNoFrom", txtFromEmp.Text.Trim() == "" ? "" : txtFromEmp.Text);
            HT.Add("EmpNoTo", txtToEmp.Text.Trim() == "" ? "0" : txtToEmp.Text);
            HT.Add("classind", ddlClass.SelectedValue == "0" ? "0" : ddlClass.SelectedValue);
            Session["HT"] = HT;
            Session["ReportName"] = ddlSelectType.SelectedItem.Text;
            Session["Report"] = "RptManualPatrak";
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
        // pnlEmpType.Visible = false;
        txtFromLot.Text = "";
        txtToLot.Text = "";
        txtFromEmp.Text = "";
        txtToEmp.Text = "";
        ddlClass.ClearSelection();
        // ddlEmpType.ClearSelection();
        ddlDepartment.ClearSelection();
        if (ddlSelectType.SelectedValue == "0")
        {
            clear();
        }
        else if (ddlSelectType.SelectedValue == "3")
        {
            pnlDepartment.Visible = true;
            PnlVoucher.Visible = true;
        }
        else if (ddlSelectType.SelectedValue == "4")
        {
            pnlLot.Visible = true;
            PnlVoucher.Visible = true;
        }
        else if (ddlSelectType.SelectedValue == "5")
        {
            pnlEmployee.Visible = true;
            PnlVoucher.Visible = false;
            txtVoucherFrom.Text = "";
            txtVoucherTo.Text = "";
        }
        else if (ddlSelectType.SelectedValue == "6")
        {
            pnlClass.Visible = true;
            PnlVoucher.Visible = true;
        }
        else
        {
            PnlVoucher.Visible = true;
        }
        //else if (ddlSelectType.SelectedValue == "7")
        //{
        //    pnlEmpType.Visible = true;
        //}
    }
}