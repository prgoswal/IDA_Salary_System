using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_frm_EmpServicesAssign : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            Fill_ddlDepartment();
        }

    }

    private void Fill_ddlDepartment()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentWiseEmployeeServices/Fill_ddlDepartment?Ind=1");
        if (ds != null)
        {
            ddl_DeptName.DataSource = ds.Tables[0];
            ddl_DeptName.DataValueField = "DepartCode";
            ddl_DeptName.DataTextField = "DepartNameE";
            ddl_DeptName.DataBind();
            ddl_DeptName.Items.Insert(0, new ListItem("--Select Department--", "0"));
        }
    }

    private void Fill_ddlEmployee()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentWiseEmployeeServices/Fill_ddlEmployeeName?Ind=2&DepartCode=" + ddl_DeptName.SelectedValue.ToString());
        if (ds != null)
        {
            ddl_EmpName.DataSource = ds.Tables[0];
            ddl_EmpName.DataValueField = "EmpCode";
            ddl_EmpName.DataTextField = "EmpName";
            ddl_EmpName.DataBind();
            ddl_EmpName.Items.Insert(0, new ListItem("--Select Employee Name - Designation--", "0"));
        }
    }

    protected void ddl_DeptName_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Fill_ddlEmployee();
    }
}