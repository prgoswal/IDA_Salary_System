using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSystem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserCode"] != null)
            {
                Admin_CommonCls.CommonCheckSession();
                GetSystem();
                GetSalaryMonth();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    public void GetSystem()
    {
        DataSet ds = Admin_CommonCls.CallApiGet("UserSystem/GetUserSystem?Ind=1&UserCode=" + Session["UserCode"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "101")
                {
                    PnlSalarySystem.Visible = true;
                }
                else if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "102")
                {
                    PnlLegalSystem.Visible = true;
                }
                else if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "103")
                {
                    PnlEstateSystem.Visible = true;
                }
                else if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "104")
                {
                    PnlLeaseSystem.Visible = true;
                }
                else if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "105")
                {
                    PnlFrontOfficeSystem.Visible = true;
                }
                else if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "106")
                {
                    PnlDocumentScanning.Visible = true;
                }
                else if (ds.Tables[0].Rows[i]["SystemCode"].ToString() == "109")
                {
                    pnlDemandSystem.Visible = true;
                }
            }

        }
    }
    protected void btnSalarySystem_Click(object sender, EventArgs e)
    {       
        Session["CorpName"] = Session["OrgName"];
        Session["UserId"] = Session["UserCode"];       
        Session["LevelId"] = Session["UserLevel"];          
        Session["MonthCd"] = ddlMonthSalary.SelectedValue;     
        Session["MonthDesc"] = ddlMonthSalary.SelectedItem.Text;
        Response.Redirect("~/Salary/Dashboard.aspx");
    }
    


    public void GetSalaryMonth()
    {
        DataTable dtSal = new DataTable();
        dtSal = Salary_CLSCommon.CallApiGetdt("Login/FillMonth?Ind=3&CityCode=" + Session["CityCode"] + "");
        if (dtSal.Rows.Count > 0)
        {
            ddlMonthSalary.DataSource = dtSal;
            ddlMonthSalary.DataValueField = "monthcd";
            ddlMonthSalary.DataTextField = "MOnthDesc";
            ddlMonthSalary.DataBind();
            ddlMonthSalary.Items.Insert(0, new ListItem("-- Select Month -- ", "0"));            
        }
    }

   
}