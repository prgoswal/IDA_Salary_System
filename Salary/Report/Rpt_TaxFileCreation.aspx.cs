using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Rpt_TaxFileCreation : System.Web.UI.Page
{
    DataTable dt;
    DataSet ds;
    PL_BankTextFileCreation plobj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNarration.Attributes.Add("maxlength","855");
            FillSelectType();
            Fill_ddltxtFils();
            BindAllDropDown();
        }
    }


    public void Fill_ddltxtFils()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("TaxFileCreation/BindTaxtFile?Ind=10");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlTxtFileCreation.DataSource = dt;
                ddlTxtFileCreation.DataTextField = "TxtTypeDesc";
                ddlTxtFileCreation.DataValueField = "TxtTypeID";
                ddlTxtFileCreation.DataBind();
                ddlTxtFileCreation.Items.Insert(0, new ListItem(" --- Select Text File --- ", "0"));
            }
            else
            {
                ddlTxtFileCreation.Items.Clear();
                ddlTxtFileCreation.Items.Insert(0, new ListItem(" --- Select Text File --- ", "0"));
            }
        }
    }

    void BindAllDropDown()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("EmployeeMaster/BindAll?Ind=1&CityCode=" + Session["CityCode"] + "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[6].Rows.Count > 0)
                {
                    ddlBank.DataSource = ds.Tables[6];
                    ddlBank.DataTextField = "BankName";
                    ddlBank.DataValueField = "BnkCd";
                    ddlBank.DataBind();
                    ddlBank.Items.Insert(0, new ListItem("-- Select Bank --- ", "0"));
                    ViewState["VS_BankTable"] = ds.Tables[6];
                }
                else
                {
                    ddlBank.Items.Insert(0, new ListItem("-- Select Bank --- ", "0"));
                }
            }
        }
    }

    void clear()
    {
        txtNarration.Text = "";
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        lblMsg1.CssClass = "";
        lblMsg2.CssClass = "";
        lblMsg1.Text = "";
        lblMsg2.Text = "";
        pnlDepartment.Visible = false;
        pnlLot.Visible = false;
        pnlEmployee.Visible = false;
        pnlClass.Visible = false;
        pnlEmpType.Visible = false;
        PanelLoanType.Visible = false;
        ddlSelectType.ClearSelection();
        ddlDepartment.ClearSelection();
        ddlClass.ClearSelection();
        ddlEmpType.ClearSelection();
        ddlTxtFileCreation.ClearSelection();
        ddlBank.ClearSelection();
        ddlBranch.ClearSelection();
        txtFromLot.Text = "";
        txtToLot.Text = "";
        txtFromEmp.Text = "";
        txtToEmp.Text = "";

    }
    public void FillSelectType()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FillReportType/FillSelectType?Ind=3&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
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
                    ddlEmpType.Items.Insert(0, new ListItem("All", "0"));
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
        return true;
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
        pnlEmpType.Visible = false;
        txtFromLot.Text = "";
        txtToLot.Text = "";
        txtFromEmp.Text = "";
        txtToEmp.Text = "";
        ddlClass.ClearSelection();
        ddlEmpType.ClearSelection();
        ddlDepartment.ClearSelection();
        
        ddlTxtFileCreation.ClearSelection();
        ddlBank.ClearSelection();
        ddlBranch.ClearSelection();

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
        else if (ddlSelectType.SelectedValue == "7")
        {
            pnlEmpType.Visible = true;
        }
    }
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBank.SelectedValue != "0")
        {
            DataTable dt_BankTable = (DataTable)ViewState["VS_BankTable"];
            DataRow[] dr = dt_BankTable.Select("BnkCd=" + ddlBank.SelectedValue.ToString());
            DataTable BranchTable = dr.CopyToDataTable();
            if (BranchTable.Rows.Count > 0)
            {
                ddlBranch.DataSource = BranchTable;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BrCd";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));
            }
            else
            {
                ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));
            }
        }
        else
        {
            ddlBranch.Items.Clear();
        }
        if (ddlLoantype.SelectedValue != "0")
        {
          if(ddlBank.SelectedItem.Text == "AXIS BANK")
          {
              ShowMessage("This Bank File Formate Not Define ?", false);
          }
            else
          {
              lblMsg.Text = "";
              lblMsg.CssClass = "";
          }
        }
        else
        {
        }

        ddlBank.Focus();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    string FilenameMastName, mmyy = "", city = "";
    protected void btnDOWNLOAD_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg1.Text = "";
        lblMsg2.Text = "";
        FilenameMastName = Server.MapPath("BankFile\\" + "BankTextFile_" + Session["CityCode"] + Session["Month"] + ".Txt").Replace("\\Report", "");
        FileInfo file1 = new FileInfo(FilenameMastName);
        if (file1.Exists)
        {

            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file1.Name);
            Response.WriteFile(file1.FullName);
            Response.End();
        }
    }
    protected void btnCREATION_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg1.Text = "";
        lblMsg2.Text = "";
        lblMsg.CssClass = "";

        plobj = new PL_BankTextFileCreation();
        bool IsValid = btnPreviewValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            if (ddlTxtFileCreation.SelectedIndex == 0)
            {
                ddlTxtFileCreation.Focus();
                lblMsg.Text = "Select Text File Type";
                return;
            }
            if (Convert.ToInt32(ddlBank.SelectedIndex.ToString()) != 0)
            {
                plobj.BnkCd = ddlBank.SelectedValue.ToString();
            }
            else
            {
                plobj.BnkCd = ddlBank.SelectedValue == "0" ? "0" : ddlBank.SelectedValue;
            }
            if (Convert.ToInt32(ddlBranch.SelectedIndex.ToString()) >= 0)
            {
                plobj.BrCd = ddlBranch.SelectedValue == "0" ? "0" : ddlBranch.SelectedValue;
            }
            else
            {
                plobj.BrCd = ddlBranch.SelectedValue;
            }

            if (Convert.ToInt32(ddlDepartment.SelectedIndex.ToString()) != 0)
            {
                plobj.DeptCd = ddlDepartment.SelectedValue.ToString();
            }
            else
            {
                plobj.DeptCd = "0";
            }

            if (txtFromEmp.Text.ToString() != "")
            {
                plobj.LotNoF = txtFromEmp.Text.ToString();
            }
            else
            {
                plobj.LotNoF = "0";
            }
            if (txtToEmp.Text.ToString() != "")
            {
                plobj.LotNoTo = txtToEmp.Text.ToString();
            }
            else
            {
                plobj.LotNoTo = "0";
            }
            if (Convert.ToInt32(ddlLoantype.SelectedIndex.ToString()) != 0)
            {
                plobj.LoanCode = ddlLoantype.SelectedValue.ToString();
            }
            else
            {
                plobj.LoanCode = "";
            }


            if (Convert.ToInt32(ddlClass.SelectedIndex.ToString()) != 0)
            {
                plobj.ClassInd = ddlClass.SelectedValue.ToString();
            }
            else
            {
                plobj.ClassInd = "0";
            }


            if (Convert.ToInt32(ddlEmpType.SelectedIndex.ToString()) != 0)
            {
                plobj.EmpType = ddlEmpType.SelectedValue.ToString();
            }
            else
            {
                plobj.EmpType = "0";
            }

            plobj.Zone = "";
            plobj.Ward = "";
            plobj.SubDeptCd = "";
            plobj.CityCode = Session["CityCode"].ToString();
            plobj.MOnth = Session["Month"].ToString();
            plobj.Flag = 1;
            plobj.TextFileType = Convert.ToInt32(ddlTxtFileCreation.SelectedValue);
            plobj.Narration = txtNarration.Text.Trim();

            dt = new DataTable();
            dt = Salary_CLSCommon.ApiPostDataTable("TaxFileCreation/TaxtFileData", plobj);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    FilenameMastName = Server.MapPath("BankFile\\" + "BankTextFile_" + Session["CityCode"] + Session["Month"] + ".Txt").Replace("\\Report", "");

                    if (File.Exists(FilenameMastName))
                    {
                        File.Delete(FilenameMastName);
                    }

                    StreamWriter txtFile = File.CreateText(FilenameMastName);
                    txtFile.Close();
                    int V = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strV;
                        string str = dt.Rows[i][0].ToString();
                        //string str1 = dt.Rows[i][1].ToString();
                        // string str2 = dt.Rows[i][2].ToString();
                        //  string str3 = dt.Rows[i][3].ToString();
                        //string p;
                        //string p1;
                        //string p2;
                        //if (i == V - 1)
                        //{
                        //    p = "51" + str.PadLeft(17, '0');
                        //}
                        //else
                        //{
                        //    p = "01" + str.PadLeft(17, '0');
                        //}
                        //p1 = str1.PadLeft(14, '0') + "00";

                        //p2 = str2;
                        //str = str + p;
                        // strV = str + str1 + (str2).PadLeft(5, '0') + ".00" + str3;
                        strV = str;
                        File.AppendAllText(FilenameMastName, strV);
                        File.AppendAllText(FilenameMastName, "\n");
                    }
                    clear();
                   
                    lblMsg.Text = "File Created Successfully....";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg1.Text = "Total Record :-" + Convert.ToString(Convert.ToInt32(dt.Rows.Count.ToString()));
                    //lblMsg2.Text = "Total Amount :-" + dt.Rows[V - 1][1].ToString();
                  
                }
                else
                {
                    lblMsg.Text = "No Record Found...";
                    lblMsg1.Text = "";
                    lblMsg2.Text = "";
                }
            }
            else
            {
                lblMsg.Text = "No Record Found...";
                lblMsg1.Text = "";
                lblMsg2.Text = "";
            }
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
                    ddlLoantype.DataSource = ds.Tables[0];
                    ddlLoantype.DataTextField = "LoanDesc";
                    ddlLoantype.DataValueField = "Edcd";
                    ddlLoantype.DataBind();
                    ddlLoantype.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
                }
                else
                {
                    ddlLoantype.Items.Clear();
                    ddlLoantype.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
                }
            }

        }
        else
        {
            ddlLoantype.Items.Clear();
            ddlLoantype.Items.Insert(0, new ListItem(" -- Select Loan Type -- ", "0"));
        }
    }

    protected void ddlTxtFileCreation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelLoanType.Visible = false;
        if(ddlTxtFileCreation.SelectedValue=="6")
        {
            PanelLoanType.Visible = true;
            Fill_TypeofLoan();
        }
        else
        {
            PanelLoanType.Visible = false;
        }
    }
}