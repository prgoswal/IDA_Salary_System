using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_frm_DepartmentService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Fill_ddlDepartment();
        }
        pnlSuccess.Visible = false;
        pnlfailed.Visible = false;
        //checkMessage.Visible = false;

    }
    private void Fill_ddlDepartment()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentService/Fill_ddlDepartment?Ind=2");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_DeptName.DataSource = ds.Tables[0];
                ddl_DeptName.DataValueField = "DepartCode";
                ddl_DeptName.DataTextField = "DepartNameE";                
                ddl_DeptName.DataBind();
                ddl_DeptName.Items.Insert(0, new ListItem("--Select Department--", "0"));
            }
            else
            {
                ds = null;
                ddl_DeptName.Items.Clear();

            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_DepartmentService objpl = new PL_DepartmentService();
        objpl.Ind = 1;

        if (ddl_DeptName.SelectedIndex != 0)
        {

            objpl.ServiceDescE = txt_ServiceDescEnglish.Text;
            objpl.ServiceDescH = txt_ServiceDescHindi.Text;
            objpl.ServiceOtherDesc1 = txt_ServiceRemark1.Text;
            objpl.ServiceOtherDesc2 = txt_ServiceRemark2.Text;
            objpl.DepartCode = Convert.ToInt32(ddl_DeptName.SelectedValue.ToString());
            DataTable dt = FO_CLSCommon.CallApiPost("api/DepartmentService/SubmitDeptService", objpl);


            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["res"].ToString() == "1")
                {
                    pnlSuccess.InnerHtml = "Save Successfully.";
                    ClearField();
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
    private void ClearField()
    {
        txt_ServiceDescEnglish.Text = "";
        txt_ServiceDescHindi.Text = "";
        txt_ServiceRemark1.Text = "";
        txt_ServiceRemark2.Text = "";
        ddl_DeptName.SelectedIndex = 0;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearField();
    }
   
}