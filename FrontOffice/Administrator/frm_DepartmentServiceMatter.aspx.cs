using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_frm_DepartmentServiceMatter : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_ddlDepartment();
        }
        pnlSuccess.Visible = false;
        pnlfailed.Visible = false;
        //ddl_ServiceName.Items.Insert(0, new ListItem("--Select Service Name--", "0"));
    }

    private void Fill_ddlDepartment()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentServiceMatter/Fill_ddlDepartment?Ind=2");
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
    private void ClearData()
    {
        txt_MatterDescEnglish.Text = "";
        txt_MatterDescHindi.Text = "";
        txt_matterremark1.Text = "";
        txt_Matterremark2.Text = "";
        ddl_DeptName.SelectedValue = "0";
        ddl_ServiceName.SelectedValue = "0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_DepartmentServiceMatter objpl = new PL_DepartmentServiceMatter();
        objpl.Ind = 1;

        if (ddl_DeptName.SelectedIndex != 0)
        {

            objpl.MatterDescE = txt_MatterDescEnglish.Text;
            objpl.MatterDescH = txt_MatterDescHindi.Text;
            objpl.MatterOtherDesc1 = txt_matterremark1.Text;
            objpl.MatterOtherDesc2 = txt_Matterremark2.Text;
            objpl.DepartCode = Convert.ToInt32(ddl_DeptName.SelectedValue.ToString());
            objpl.ServiceCode = Convert.ToInt32(ddl_ServiceName.SelectedValue.ToString());
            DataTable dt = FO_CLSCommon.CallApiPost("api/DepartmentServiceMatter/SubmitDeptServiceMatter", objpl);


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
            // checkMessage.InnerHtml = "Please Select Department Name !!!!";
        }


    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();

    }

    protected void ddl_DeptName_SelectedIndexChanged(object sender, EventArgs e)          // fill DDl_ServiceName  accorgind to DDl_Department
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentServiceMatter/Fill_ddlServiceName?Ind=3&DepartCode=" + ddl_DeptName.SelectedValue.ToString());
        ddl_ServiceName.DataSource = ds.Tables[0];
        ddl_ServiceName.DataValueField = "ServiceCode";
        ddl_ServiceName.DataTextField = "ServiceDescE";
        ddl_ServiceName.DataBind();
        ddl_ServiceName.Items.Insert(0, new ListItem("--Select Service Name--", "0"));
        ddl_ServiceName.Focus();


    }
   
}