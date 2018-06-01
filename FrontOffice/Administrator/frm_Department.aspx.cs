using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Administrator_department : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {        

        PL_Department objpl = new PL_Department();
        objpl.Ind = 1;
        objpl.DepartNameE = txt_DepartmentNameEnglish.Text;
        objpl.DepartNameH = txt_DepartmentNameHindi.Text;

       DataTable dt= FO_CLSCommon.CallApiPost("api/Department/SubmitDepartment", objpl);
      
       if (dt != null)
       {
           if (dt.Rows[0]["res"].ToString() == "1")
           {
               pnlSuccess.InnerHtml = "Save Successfully.";
               ClearData();
               pnlSuccess.Visible=true;
               pnlfailed.Visible = false;
           }
           else if (dt.Rows[0]["res"].ToString() == "2")
           {
               pnlfailed.InnerHtml = "Already Exist";               
               pnlSuccess.Visible = false;
               pnlfailed.Visible = true;
           }
           else
           {
               pnlfailed.InnerHtml = "Data Failed...";
               pnlSuccess.Visible = false;
               pnlfailed.Visible = true;
           }
       }

     
    }
    private void ClearData()
    {
        txt_DepartmentNameHindi.Text = "";
        txt_DepartmentNameEnglish.Text = "";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
   
}