using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_frm_DepartmentEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_ddlDepartment();
            Fill_ddlEmpLevel();
            Fill_ddlDesignation();
        }

        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_EmployeeNameEng.Text = "";
        txt_EmployeenameHindi.Text = "";
        ddl_DepartmentName.SelectedIndex = 0;
        ddl_EmpLevel.SelectedIndex = 0;
        txt_EmpMobNo.Text = "";
        txt_EmpEmail.Text = "";
        ddl_EmpDesignation.SelectedIndex = 0;

        Rdb_EmpDepHaed.SelectedIndex = 1;
    }
    private void Fill_ddlDepartment()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentEmployee/Fill_ddlDepartment?Ind=2");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddl_DepartmentName.DataSource = ds.Tables[0];
                ddl_DepartmentName.DataValueField = "DepartCode";
                ddl_DepartmentName.DataTextField = "DepartNameE";
                ddl_DepartmentName.DataBind();
                ddl_DepartmentName.Items.Insert(0, new ListItem("--Select Department--", "0"));
            }
            else
            {
                ds = null;
                ddl_DepartmentName.Items.Clear();

            }
        }
    }

    private void Fill_ddlEmpLevel()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentEmployee/Fill_ddlEmpLevel?Ind=3");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddl_EmpLevel.DataSource = ds.Tables[0];
                ddl_EmpLevel.DataValueField = "HierarchyCode";
                ddl_EmpLevel.DataTextField = "HierarchyDescE";
                ddl_EmpLevel.DataBind();
                ddl_EmpLevel.Items.Insert(0, new ListItem("--Select Employee Level--", "0"));
            }
            else
            {
                ds = null;
                ddl_EmpLevel.Items.Clear();

            }
        }
    }

    private void Fill_ddlDesignation()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentEmployee/Fill_ddlDesignation?Ind=4");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddl_EmpDesignation.DataSource = ds.Tables[0];
                ddl_EmpDesignation.DataValueField = "DesignCode";
                ddl_EmpDesignation.DataTextField = "DesignDescE";
                ddl_EmpDesignation.DataBind();
                ddl_EmpDesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));
            }
            else
            {
                ds = null;
                ddl_EmpDesignation.Items.Clear();

            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_DepartmentEmployee objpl = new PL_DepartmentEmployee();

        if (ddl_DepartmentName.SelectedIndex != 0)
        {
            objpl.Ind = 1;
            objpl.EmpHeadInd =Convert.ToInt32(Rdb_EmpDepHaed.SelectedValue.ToString()); 
            objpl.EmpNameE = txt_EmployeeNameEng.Text;
            objpl.EmpNameH = txt_EmployeenameHindi.Text;
            objpl.EmpDepCode = Convert.ToInt32(ddl_DepartmentName.SelectedValue.ToString());
            objpl.EmpHierarchyCode = Convert.ToInt32(ddl_EmpLevel.SelectedValue.ToString());
            objpl.EmpMobile = txt_EmpMobNo.Text;
            objpl.EmpEmail = txt_EmpEmail.Text;
            objpl.EmpDesigCD = Convert.ToInt32(ddl_EmpDesignation.SelectedValue.ToString());
            objpl.EmpDesigDescE = (ddl_EmpDesignation.SelectedItem.ToString());
            objpl.EmpHierarchyDesc = (ddl_EmpLevel.SelectedItem.ToString());
            //objpl.DepartCode = Convert.ToInt32(ddl_DeptName.SelectedValue.ToString());
            DataTable dt = FO_CLSCommon.CallApiPost("api/DepartmentEmployee/SubmitDepartmentEmployee", objpl);


            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.InnerHtml = "Save Successfully.";
                    ClearData();
                    pnlSuccess.Visible = true;
                    pnlfailed.Visible = false;
                }
                else
                {
                    pnlfailed.InnerHtml = "Data Failed...";
                    pnlSuccess.Visible = false;
                    pnlfailed.Visible = true;
                }
            }
        }
        else
        {
            //checkMessage.InnerHtml = "Please Select Department Name !!!!";
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}