using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Report_Rpt_PayPostringRegister : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
    PL_PayPostingRegister plobj;
    static string Checklistvalue = "";
    static string Checklistvalue1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSelectType();
            BindGridView();
            EarningPanal.Enabled = false;
            chkall.Enabled = false;
            chkall.Checked = true;
            DeductionPanal.Enabled = false;
            ChkDeductionAll.Enabled = false;
            ChkDeductionAll.Checked = true;
            //FillYrs();
            if (rbEarnind.SelectedValue == "0")
            {
                chkAllHead();
            }
            if (rbDeduction.SelectedValue == "0")
            {
                ChkAllDeduction();
            }
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

    public void BindGridView()
    {
        lblMsg.CssClass = "";
        lblMsg.Text = "";
        chkall.Checked = false;
        plobj = new PL_PayPostingRegister()
        {
            Ind = 1,
            CityCode = Convert.ToInt32(Session["CityCode"]),
            Edcdind = 1,
        };
        DataSet ds = Salary_CLSCommon.ApiPostDataSet("PayPostingRegister/BindGrid", plobj);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (plobj.Edcdind == 1)
                {
                    EarningPanal.Visible = true;
                    chklist.DataSource = ds.Tables[0];
                    chklist.DataTextField = "Desc";
                    chklist.DataValueField = "Edcd";
                    chklist.DataBind();

                    EarningPanal.Visible = true;
                    ChkDeduction.DataSource = ds.Tables[1];
                    ChkDeduction.DataTextField = "Desc";
                    ChkDeduction.DataValueField = "Edcd";
                    ChkDeduction.DataBind();
                }
                if (plobj.Edcdind == 2)
                {
                    EarningPanal.Visible = true;
                    chklist.DataSource = ds.Tables[0];
                    chklist.DataTextField = "Desc";
                    chklist.DataValueField = "Edcd";
                    chklist.DataBind();
                }
                if (plobj.Edcdind == 3)
                {
                    EarningPanal.Visible = true;
                    ChkDeduction.DataSource = ds.Tables[0];
                    ChkDeduction.DataTextField = "Desc";
                    ChkDeduction.DataValueField = "Edcd";
                    ChkDeduction.DataBind();
                }
            }
            if(ds.Tables.Count>2)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlfinancialyear.DataSource = ds.Tables[2];
                    ddlfinancialyear.DataTextField = "Fyr";
                    ddlfinancialyear.DataValueField = "Fyr";
                    ddlfinancialyear.DataBind();
                    ddlfinancialyear.Items.Insert(0, new ListItem("--Select Type--", "0"));
                }
                else
                {
                    ddlfinancialyear.DataSource = null;
                    ddlfinancialyear.DataBind();
                }
            }
        }
        else
        {
            chklist.Items.Clear();
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
        //if (rbEarnind.SelectedValue == "1")
        //{
        //    if (Session["FilterEdcd"] == null)
        //    {
        //        rbEarnind.Focus();
        //        ShowMessage("Please Check at least one Earning", false);
        //        return false;
        //    }
        //}
        //if (rbDeduction.SelectedValue == "1")
        //{
        //    if (Session["FilterEdcd1"] == null)
        //    {
        //        rbDeduction.Focus();
        //        ShowMessage("Please Check at least one Deduction", false);
        //        return false;
        //    }
        //}

        else if (ddlfinancialyear.SelectedItem.Value == "0")
        {
            ddlfinancialyear.Focus();
            ShowMessage(" Please Select Financial Year", false);
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
            foreach (ListItem li in chklist.Items)
            {
                if (li.Selected)
                {
                    Checklistvalue = Checklistvalue + li.Value.ToString() + ",";
                }
            }
            if (Checklistvalue.Length > 0)
            {
                Checklistvalue = Checklistvalue.Substring(0, (Checklistvalue.Length - 1));
            }
            string val2 = null;
            for (int j = 0; j < chklist.Items.Count; j++)
            {
                if (chklist.Items[j].Selected == true)
                {
                    if (val2 == null)
                        val2 = chklist.Items[j].Value;
                    else
                        val2 = val2 + "," + chklist.Items[j].Value;
                }
            }
            Checklistvalue = val2;
            Session["FilterEdcd"] = Checklistvalue;

            //----------Checklist Deduction----
            foreach (ListItem li2 in ChkDeduction.Items)
            {
                if (li2.Selected)
                {
                    Checklistvalue1 = Checklistvalue1 + li2.Value.ToString() + ",";
                }
            }
            if (Checklistvalue1.Length > 0)
            {
                Checklistvalue1 = Checklistvalue1.Substring(0, (Checklistvalue1.Length - 1));
            }
            string val22 = null;
            for (int j = 0; j < ChkDeduction.Items.Count; j++)
            {
                if (ChkDeduction.Items[j].Selected == true)
                {
                    if (val22 == null)
                        val22 = ChkDeduction.Items[j].Value;
                    else
                        val22 = val22 + "," + ChkDeduction.Items[j].Value;
                }
            }
            Checklistvalue1 = val22;
            Session["FilterEdcd1"] = Checklistvalue1;
            //---------end---------------
            string pt = Session["RegDepDesc"] + " >> " + Session["DOJDesc"];
            string pt1 = Session["ZoneDesc2"] + " " + Session["WardDesc2"] + Session["DeptDesc2"] + "  " + Session["SubDeptDesc2"] + Session["lotfrom1"] + Session["lotTo1"] + Session["empnof1"] + Session["empnot1"];
            Hashtable HT = new Hashtable();
            HT.Add("UserName", Session["UserName"].ToString());
            HT.Add("CITYNAME", Session["CorpName"].ToString());
            HT.Add("Flag", 1);
            HT.Add("EmpType", ddlEmpType.SelectedValue);
            HT.Add("MOnth", Session["Month"].ToString());
            HT.Add("CityCode", Session["CityCode"].ToString());
            HT.Add("EmpNoFrom", txtFromEmp.Text.Trim() == "" ? "0" : txtFromEmp.Text);
            HT.Add("EmpNoTo", txtToEmp.Text.Trim() == "" ? "0" : txtToEmp.Text);
            HT.Add("MonthCd", Session["MonthCd"].ToString());
            HT.Add("LotNoF", txtFromLot.Text == "" ? "0" : txtFromLot.Text);
            HT.Add("LotNoTo", txtToLot.Text == "" ? "0" : txtToLot.Text);
            HT.Add("Zone", 0);
            HT.Add("Ward", 0);
            HT.Add("DeptCd", ddlDepartment.SelectedValue);
            HT.Add("SubDeptCd", 0);
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
            HT.Add("Fyr", 17);
            HT.Add("MarToFeb", 1);
            HT.Add("AprToMar", 0);
            HT.Add("IncomeTax", 0);
            HT.Add("FilterEdcd1", Session["FilterEdcd1"].ToString());
            HT.Add("FilterEdcd", Session["FilterEdcd"].ToString());
            HT.Add("PPInd", 2);
            HT.Add("SearchType", pt.ToString());
            HT.Add("SearchType1", pt1.ToString());
            HT.Add("classind", Convert.ToInt32(ddlClass.SelectedValue) == 0 ? 0 : Convert.ToInt32(ddlClass.SelectedValue));
            HT.Add("EMPTYPENAME", "0");
            HT.Add("MonthDesc", Session["MonthDesc"].ToString() + "   " + ddlEmpType.SelectedItem.Text + " Employee");
            Session["HT"] = HT;
            Session["Report"] = "PayPostingRegister";
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
    protected void rbEarnind_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (rbEarnind.SelectedValue == "1")
        {
            EarningPanal.Enabled = true;
            chkall.Enabled = true;
            if (chkall.Checked == true)
            {
                foreach (ListItem li in chklist.Items)
                {
                    li.Selected = false;
                }
                chkall.Checked = false;
            }
            else
            {
                foreach (ListItem li in chklist.Items)
                {
                    li.Selected = false;
                }
            }
        }
        else
        {
            EarningPanal.Enabled = false;
            chkall.Enabled = false;
            if (chkall.Checked == false)
            {
                foreach (ListItem li in chklist.Items)
                {
                    li.Selected = true;
                    Checklistvalue = Checklistvalue + li.Value.ToString() + ",";
                    chkall.Text = "UnChecked All";
                }
                chkall.Checked = true;
                Checklistvalue = Checklistvalue.Substring(0, (Checklistvalue.Length - 1));
                Session["FilterEdcd"] = Checklistvalue;
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
    }
    protected void rbDeduction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbDeduction.SelectedValue == "1")
        {
            DeductionPanal.Enabled = true;
            ChkDeductionAll.Enabled = true;
            if (ChkDeductionAll.Checked == true)
            {
                foreach (ListItem li in ChkDeduction.Items)
                {
                    li.Selected = false;
                }
                ChkDeductionAll.Checked = false;
            }
            else
            {
                foreach (ListItem li in ChkDeduction.Items)
                {
                    li.Selected = false;
                }
            }
        }
        else
        {
            DeductionPanal.Enabled = false;
            ChkDeductionAll.Enabled = false;
            if (ChkDeductionAll.Checked == false)
            {
                foreach (ListItem li in ChkDeduction.Items)
                {
                    li.Selected = true;
                    Checklistvalue = Checklistvalue + li.Value.ToString() + ",";
                    ChkDeductionAll.Text = "Unchecked All";
                }
                ChkDeductionAll.Checked = true;
                Checklistvalue = Checklistvalue.Substring(0, (Checklistvalue.Length - 1));
                Session["FilterEdcd1"] = Checklistvalue;
            }
            else
            {
                foreach (ListItem li in ChkDeduction.Items)
                {
                    li.Selected = false;
                    ChkDeductionAll.Text = "Checked All";
                }
            }
        }
    }
    public void chkAllHead()
    {
        if (chkall.Checked == true)
        {
            foreach (ListItem li in chklist.Items)
            {
                li.Selected = true;
                Checklistvalue = Checklistvalue + li.Value.ToString() + ",";
                chkall.Text = "UnChecked All";
            }
            Checklistvalue = Checklistvalue.Substring(0, (Checklistvalue.Length - 1));
            Session["FilterEdcd"] = Checklistvalue;
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


    public void ChkAllDeduction()
    {
        if (ChkDeductionAll.Checked == true)
        {
            foreach (ListItem li in ChkDeduction.Items)
            {
                li.Selected = true;
                Checklistvalue = Checklistvalue + li.Value.ToString() + ",";
                ChkDeductionAll.Text = "Unchecked All";
            }
            Checklistvalue = Checklistvalue.Substring(0, (Checklistvalue.Length - 1));
            Session["FilterEdcd1"] = Checklistvalue;
        }
        else
        {
            foreach (ListItem li in ChkDeduction.Items)
            {
                li.Selected = false;
                ChkDeductionAll.Text = "Checked All";
            }
        }
    }

    //public void FillYrs()
    //{
    //    DataTable dt = new DataTable();
    //    dt = Salary_CLSCommon.CallApiGetdt("PayPostingRegister/BindFyr?Ind=2");
    //    if (dt != null)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            ddlfinancialyear.DataSource = dt;
    //            ddlfinancialyear.DataTextField = "Fyr";
    //            ddlfinancialyear.DataValueField = "Fyr";
    //            ddlfinancialyear.DataBind();
    //            ddlfinancialyear.Items.Insert(0, new ListItem("--Select Type--", "0"));
    //        }
    //        else
    //        {
    //            ddlfinancialyear.DataSource = null;
    //            ddlfinancialyear.DataBind();
    //        }
    //    }
    //    else
    //    {
    //        ddlfinancialyear.DataSource = null;
    //        ddlfinancialyear.DataBind();
    //    }
    //}

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        EarningPanal.Visible = true;
        chkAllHead();
    }
    protected void ChkDeductionAll_CheckedChanged(object sender, EventArgs e)
    {
        EarningPanal.Visible = true;
        ChkAllDeduction();
    }
}