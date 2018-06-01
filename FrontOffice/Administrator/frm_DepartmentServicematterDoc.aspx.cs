using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_frm_DepartmentServicematterDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_ddlDepartment();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
        //ddl_ServiceName.Items.Insert(0, new ListItem("--Select Service Name--", "0"));
        //ddl_matterName.Items.Insert(0, new ListItem("--Select Matter Name--", "0"));

    }
    private void Fill_ddlDepartment()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentServiceMatterDoc/Fill_ddlDepartment?Ind=2");

        ddl_DeptName.DataSource = ds.Tables[0];
        ddl_DeptName.DataValueField = "DepartCode";
        ddl_DeptName.DataTextField = "DepartNameE";
        ddl_DeptName.DataBind();
        ddl_DeptName.Items.Insert(0, new ListItem("--Select Department--", "0"));
        

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_DepartmentServiceMatterDoc objpl = new PL_DepartmentServiceMatterDoc();
        objpl.Ind = 1;

        if (ddl_DeptName.SelectedIndex != 0)
        {

            objpl.MatterCode = Convert.ToInt32(ddl_matterName.SelectedValue.ToString());
            objpl.DepartCode = Convert.ToInt32(ddl_DeptName.SelectedValue.ToString());
            objpl.ServiceCode = Convert.ToInt32(ddl_ServiceName.SelectedValue.ToString());

            objpl.DocumentNME = txt_DeptNameEnglish.Text;
            objpl.DocumentNMH = txt_DeptNameHindi.Text;
            objpl.DocumentOtherDesc1 = txt_remark1.Text;
            objpl.DocumentOtherDesc2 = txt_remark2.Text;


            DataTable dt = FO_CLSCommon.CallApiPost("api/DepartmentServiceMatterDoc/SubmitDeptServiceMatterDoc", objpl);


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
    public void ClearData()
    {
        txt_DeptNameEnglish.Text = "";
        txt_DeptNameHindi.Text = "";
        txt_remark1.Text = "";
        txt_remark2.Text = "";
        ddl_DeptName.SelectedIndex = 0;
        ddl_ServiceName.SelectedIndex = 0;
        ddl_matterName.SelectedIndex = 0;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void ddl_DeptName_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillServiceName();
        FillServiceMatterName();
        ddl_ServiceName.Focus();
    }
    public void FillServiceName()
    {

        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentServiceMatterDoc/Fill_ddlServiceName?Ind=3&DepartCode=" + ddl_DeptName.SelectedValue.ToString());
        ddl_ServiceName.DataSource = ds.Tables[0];
        ddl_ServiceName.DataValueField = "ServiceCode";
        ddl_ServiceName.DataTextField = "ServiceDescE";
        ddl_ServiceName.DataBind();
        ddl_ServiceName.Items.Insert(0, new ListItem("--Select Service Name--", "0"));

    }
    public void FillServiceMatterName()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/DepartmentServiceMatterDoc/Fill_ddlMatterName?Ind=4&ServiceCode=" + ddl_ServiceName.SelectedValue.ToString());
        ddl_matterName.DataSource = ds.Tables[0];
        ddl_matterName.DataValueField = "MatterCode";
        ddl_matterName.DataTextField = "MatterDescE";
        ddl_matterName.DataBind();
        ddl_matterName.Items.Insert(0, new ListItem("--Select Matter Name--", "0"));
    }

    protected void ddl_ServiceName_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillServiceMatterName();
        ddl_matterName.Focus();
    }


}