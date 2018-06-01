using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterForm_Frm_QryEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {          
           txtname.Enabled = false;
           txtfhname.Enabled = false;
           txtEmpNo.Enabled = false;
           ddlSection.Enabled = false;
           txtLotNo.Enabled = false;
           txtDOB.Enabled = false;
           ddlDesignation.Enabled = false;
           Divgrid.Visible = false;
           //txtRRD.Enabled = false;
       }
    }
    protected void Chkname_CheckedChanged(object sender, EventArgs e)
    {
        if (Chkname.Checked == true)
        {
            Page.SetFocus(txtname);
            txtname.Enabled = true;
        }
        else
        {
            txtname.Text = "";
            txtname.Enabled = false;
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void chkFHname_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFHname.Checked == true)
        {
            Page.SetFocus(txtfhname);
            txtfhname.Enabled = true;
        }
        else
        {
            txtfhname.Text = "";
            txtfhname.Enabled = false;
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void chkEmpNo_CheckedChanged(object sender, EventArgs e)
    {
        if (chkEmpNo.Checked == true)
        {
            Page.SetFocus(txtEmpNo);
            txtEmpNo.Enabled = true;
        }
        else
        {
            txtEmpNo.Text = "";
            txtEmpNo.Enabled = false;
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void chkSection_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSection.Checked == true)
        {
            Page.SetFocus(ddlSection);
            ddlSection.Enabled = true;
            FillSection();
        }
        else
        {
            ddlSection.Enabled = false;
            ddlSection.Items.Clear();
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
  
    protected void ChkSrLotNo_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkSrLotNo.Checked == true)
        {
            Page.SetFocus(txtLotNo);
            txtLotNo.Enabled = true;
        }
        else
        {
            txtLotNo.Text = "";
            txtLotNo.Enabled = false;
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void chkDOB_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDOB.Checked == true)
        {
            //Page.SetFocus(txtDOB);
            txtDOB.Enabled = true;
        }
        else
        {
            txtDOB.Text = "";
            txtDOB.Enabled = false;
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void chkDesignation_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDesignation.Checked == true)
        {
            Page.SetFocus(ddlDesignation);
            ddlDesignation.Enabled = true;
            FillDesignation();
        }
        else
        {
            ddlDesignation.Enabled = false;
            ddlDesignation.Items.Clear();
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void chkRRD_CheckedChanged(object sender, EventArgs e)
    {
        //if (chkRRD.Checked == true)
        //{
        //    Page.SetFocus(txtRRD);
        //    txtRRD.Enabled = true;
           
        //}
        //else
        //{
        //    txtRRD.Enabled = false;
        //    txtRRD.Text = "";
        //    GvQtyEmp.DataSource = null;
        //    GvQtyEmp.DataBind();
        //}
    }
    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }


    public void FillSection()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("QryEmp/Bind_Section?Ind=4");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlSection.DataSource = dt;
                ddlSection.DataValueField = "DeptCode";
                ddlSection.DataTextField = "DeptName";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            ddlSection.Items.Clear();
        }
    }

    public void FillDesignation()
    {
        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.CallApiGetdt("QryEmp/Bind_Designation?Ind=5&CityCode=" + Convert.ToInt32(Session["CityCode"]) + "");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlDesignation.DataSource = dt;
                ddlDesignation.DataValueField = "DesgCd";
                ddlDesignation.DataTextField = "DesgDesc";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            ddlDesignation.Items.Clear();
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (Chkname.Checked == false && chkFHname.Checked == false && chkEmpNo.Checked == false && chkDesignation.Checked == false && chkDOB.Checked == false && ChkSrLotNo.Checked == false && chkSection.Checked == false && chkRRD.Checked == false)
        {
            ShowMessage("Checked any Checkbok...", false);
            return;
        }
        else
        {
            Bindgrid();
        }
    }


    public void Bindgrid()
    {
        PL_QryEmp objpropQueryEmp = new PL_QryEmp();
        if (Chkname.Checked == false)
        {
            objpropQueryEmp.FirstName = "";
        }
        else
        {
            if (txtname.Text == "")
            {
                ShowMessage("Please Enter Name", false);
                Page.SetFocus(txtname);
                return;
            }
            if (Convert.ToInt32(txtname.Text.Length.ToString()) < 3)
            {
                ShowMessage("Enter At Least 3 Char...", false);
                Page.SetFocus(txtname);
                txtname.Text = "";
                return;
            }
            objpropQueryEmp.FirstName = txtname.Text;
        }
        if (chkFHname.Checked == false)/////////////2
        {
            objpropQueryEmp.FHName = "";
        }
        else
        {
            if (txtfhname.Text == "")
            {
                ShowMessage("Please Enter Father Name", false);
                Page.SetFocus(txtfhname);
                return;
            }
            if (Convert.ToInt32(txtfhname.Text.Length.ToString()) < 3)
            {
                ShowMessage("Enter At Least 3 Char...", false);
                txtfhname.Text = "";
                Page.SetFocus(txtfhname);
                return;
            }
            objpropQueryEmp.FHName = txtfhname.Text;
        }
        if (chkEmpNo.Checked == false)/////////3
        {
            objpropQueryEmp.EmpNo = 0;
        }
        else
        {
            if (txtEmpNo.Text == "")
            {
                ShowMessage("Please Enter Employee No", false);
                Page.SetFocus(txtEmpNo);
                return;
            }
            objpropQueryEmp.EmpNo = Convert.ToInt32(txtEmpNo.Text);
        }


        if (chkSection.Checked == false)////////////4
        {
            objpropQueryEmp.DeptCd = 0;
        }
        else
        {
            if (ddlSection.SelectedIndex == 0)
            {
                ShowMessage("Please Select Section", false);
                Page.SetFocus(ddlSection);
                return;
            }
            objpropQueryEmp.DeptCd = Convert.ToInt32(ddlSection.SelectedValue);
        }


        if (ChkSrLotNo.Checked == false)////////////5
        {
            objpropQueryEmp.SrNo = 0;
        }
        else
        {
            if (txtLotNo.Text == "")
            {
                ShowMessage("Please Enter Lot No.", false);
                Page.SetFocus(txtLotNo);
                return;
            }
            objpropQueryEmp.SrNo = Convert.ToInt32(txtLotNo.Text);
        }


        if (chkDOB.Checked == false)/////////////6
        {
            objpropQueryEmp.Dob = "";
        }
        else
        {
            if (txtDOB.Text.ToString() == "")
            {
                ShowMessage("Please Enter DOB", false);
                Page.SetFocus(txtDOB);
                return;
            }
            objpropQueryEmp.Dob = Salary_CLSCommon.ConvertToDate(txtDOB.Text.ToString());
        }
        if (chkDesignation.Checked == false)////////////7
        {
            objpropQueryEmp.DesignationCD = 0;
        }
        else
        {
            if (ddlDesignation.SelectedIndex == 0)
            {
                ShowMessage("Please Select Designation", false);
                Page.SetFocus(ddlDesignation);
                return;
            }
            objpropQueryEmp.DesignationCD = Convert.ToInt32(ddlDesignation.SelectedValue);
        }

        objpropQueryEmp.Ind = 1;
        objpropQueryEmp.CityCode = Convert.ToInt32(Session["CityCode"]);
        if (chkRRD.Checked == true)///////////9
        {
            objpropQueryEmp.SubSrNo = 1;
        }
        if (chkRRD.Checked == false)
        {
            objpropQueryEmp.SubSrNo = 0;
        }
        objpropQueryEmp.month = Session["Month"].ToString();
        string uri = string.Format("QryEmp/Get_QtyDetails");
        DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, objpropQueryEmp);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                GvQtyEmp.DataSource = dt;
                GvQtyEmp.DataBind();
                Divgrid.Visible = true;
            }
            else
            {
                GvQtyEmp.DataSource = null;
                GvQtyEmp.DataBind();
                ShowMessage("Data Not Found...", false);
                return;
            }
        }
        else
        {
            GvQtyEmp.DataSource = null;
            GvQtyEmp.DataBind();
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Chkname.Checked = false;
        txtname.Text = "";
        txtname.Enabled = false;
        chkFHname.Checked = false;
        txtfhname.Text = "";
        txtfhname.Enabled = false;
        chkEmpNo.Checked = false;
        txtEmpNo.Text = "";
        txtEmpNo.Enabled = false;
        chkSection.Checked = false;
        ddlSection.ClearSelection();
        ddlSection.Enabled = false;
        ChkSrLotNo.Checked = false;
        txtLotNo.Text = "";
        txtLotNo.Enabled = false;
        chkDOB.Checked = false;
        txtDOB.Text = "";
        txtDOB.Enabled = false;
        chkDesignation.Checked = false;
        ddlDesignation.ClearSelection();
        ddlDesignation.Enabled = false;
        chkRRD.Checked = false;
        GvQtyEmp.DataSource = null;
        GvQtyEmp.DataBind();
        Divgrid.Visible = false;
    }
}