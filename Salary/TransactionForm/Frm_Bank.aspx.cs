using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Transaction_Frm_Bank : System.Web.UI.Page
{
    PL_Bank plobj = new PL_Bank();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            Filldddl();
        }
    }

    public void Filldddl()
    {
        plobj.Ind = 1;
        plobj.CityCode = 1001001;
        DataTable dt = Salary_CLSCommon.ApiPostDataTable("Bank/FillddlBank", plobj);
        if (dt.Rows.Count > 0)
        {
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BnkCd";
            ddlBankName.DataSource = dt;
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem(" ----- Select Bank Name ----- ", "0"));
        }
    }

    protected void rdbbank_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (rdbbank.SelectedValue == "1")
        {
            ddlBankName.Visible = true;
            txtBankName.Visible = false;
            txtBankName.Text = "";
            txtBranchName.Text = "";
            txtIFSCCode.Text = "";
            Filldddl();
        }
        else
        {
            ddlBankName.Visible = false;
            txtBankName.Visible = true;
            ddlBankName.ClearSelection();
            txtBranchName.Text = "";
            txtIFSCCode.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (rdbbank.SelectedValue == "0")
        {
            if (txtBankName.Text == "")
            {
                ShowMessage("Enter Bank Name", false);
                txtBankName.Focus();
                return;
            }
        }
        else
        {
            if (ddlBankName.SelectedIndex == 0)
            {
                ShowMessage("Select Bank Name", false);
                ddlBankName.Focus();
                return;

            }
        }
        if (txtBranchName.Text == "")
        {
            ShowMessage("Enter Branch Name", false);
            txtBranchName.Focus();
            return;
        }
        if (txtIFSCCode.Text == "")
        {
            ShowMessage("Enter IFSC Code", false);
            txtIFSCCode.Focus();
            return;
        }
        if (btnSave.Text == "<i class=\"fa r fa-save\"></i>Save")
        {
            plobj.Ind = 2;
        }
        if (btnSave.Text == "Update")
        {
            plobj.Ind = 4;
        }
        plobj.CityCode = 1001001;
        plobj.BankName = txtBankName.Text.Trim();
        plobj.BranchName = txtBranchName.Text.Trim();
        plobj.IFSCCode = txtIFSCCode.Text.Trim();
        plobj.AutoNo = Convert.ToInt32(ViewState["AutoNo"]);
        if (rdbbank.SelectedValue == "1")
        {
            plobj.BnkCd = Convert.ToInt32(ddlBankName.SelectedValue);
            plobj.BankName = ddlBankName.SelectedItem.Text;
        }
        DataTable dt = Salary_CLSCommon.ApiPostDataTable("Bank/SaveData", plobj);
        if (dt.Rows.Count > 0)
        {
            if (btnSave.Text == "<i class=\"fa r fa-save\"></i>Save")
            {
                if (dt.Rows[0]["LastNo"].ToString() == "1")
                {
                    ShowMessage("Record Save Successfully", true);
                    BindGrid();
                    Clear();
                    return;
                }
            }
            if (btnSave.Text == "Update")
            {
                if (dt.Rows[0]["LastNo"].ToString() == "2")
                {
                    ShowMessage("Record Updated Successfully", true);
                    BindGrid();
                    Clear();
                    return;
                }
            }
        }
    }

    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    public void Clear()
    {
        txtBankName.Text = "";
        txtBranchName.Text = "";
        txtIFSCCode.Text = "";
        rdbbank.SelectedValue = "0";
        btnSave.Text = "Save";
        txtBankName.Visible = true;
        ddlBankName.Visible = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        Clear();
    }
  

    public void BindGrid()
    {
        plobj = new PL_Bank()
        {
            Ind = 3,
            CityCode = 1001001,
        };
        DataTable dt = Salary_CLSCommon.ApiPostDataTable("Bank/BindGrid", plobj);
        if (dt.Rows.Count > 0)
        {
            GvBank.DataSource = dt;
            GvBank.DataBind();
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        Label autono = (Label)GvBank.Rows[rowindex].FindControl("lblautono");
        Label BnkCD = (Label)GvBank.Rows[rowindex].FindControl("lblBnkCd");
        Label BankName = (Label)GvBank.Rows[rowindex].FindControl("lblBankName");
        Label BranchName = (Label)GvBank.Rows[rowindex].FindControl("lblBranchName");
        Label IfscCode = (Label)GvBank.Rows[rowindex].FindControl("lblIFSCCode");
        if (rdbbank.SelectedValue == "1")
        {
            ddlBankName.SelectedValue = BnkCD.Text;
        }
        txtBankName.Text = BankName.Text;
        txtBranchName.Text = BranchName.Text;
        txtIFSCCode.Text = IfscCode.Text;
        ViewState["AutoNo"] = autono.Text;
        btnSave.Text = "Update";
    }
    protected void txtIFSCCode_TextChanged(object sender, EventArgs e)
    {
       
    }
}