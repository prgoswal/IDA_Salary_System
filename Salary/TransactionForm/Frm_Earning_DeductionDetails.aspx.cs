using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transaction_Frm_Earning_DeductionDetails : System.Web.UI.Page
{
    PL_EarDed plobj = new PL_EarDed();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindGridView();
            FillddlGlCode();
        }
    }

    public void FillddlGlCode()
    {
        plobj = new PL_EarDed()
        {
            Ind = 2,
            CityCode = 1001001
        };
        DataTable dt = Salary_CLSCommon.ApiPostDataTable("EarDed/FillddlGlCode", plobj);
        if (dt.Rows.Count > 0)
        {
            ddlGlCode.DataTextField = "GLName";
            ddlGlCode.DataValueField = "GLCode";
            ddlGlCode.DataSource = dt;
            ddlGlCode.DataBind();
            ddlGlCode.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    public void BindGridView()
    {
        plobj = new PL_EarDed()
        {
            Ind = 1,
            CityCode = 1001001
        };
        if (ddlSelect.SelectedValue == "1")
        {
            plobj.Edcdind = 1;
        }
        if (ddlSelect.SelectedValue == "2")
        {
            if (ddlDedType.SelectedValue == "1")
            {
                plobj.Edcdind = 2;
            }
            if (ddlDedType.SelectedValue == "2")
            {
                plobj.Edcdind = 3;
            }
        }
        DataTable dt = Salary_CLSCommon.ApiPostDataTable("EarDed/BindGrid", plobj);
        if (dt.Rows.Count > 0)
        {
            GvEdcd.DataSource = dt;
            GvEdcd.DataBind();
        }
        else
        {
            GvEdcd.DataSource = null;
            GvEdcd.DataBind();
        }
    }

    protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (ddlSelect.SelectedValue == "1")
        {
            divglcode.Visible = true;
            ddlDedType.Enabled = false;
            ddlDedType.ClearSelection();
        }
        else if (ddlSelect.SelectedValue == "2")
        {
            divglcode.Visible = true;
            ddlDedType.Enabled = true;
        }
        else
        {
            ddlDedType.ClearSelection();
        }
        BindGridView();
        RdbAmt.ClearSelection();
        txtAmt.Text = "";
        RdbAmt.SelectedValue = "2";
    }

    public void Clear()
    {
        ddlSelect.ClearSelection();
        txtAmt.Text = "";
        txtDesc.Text = "";
        txtAbrDesc.Text = "";
        ddlGlCode.ClearSelection();
        btnSave.Text = "Save";
        RdbAmt.ClearSelection();
        txtAmt.Text = "";
        divglcode.Visible = true;
        txtAmt.Attributes.Add("Placeholder", " ");
        GvEdcd.DataSource = null;
        GvEdcd.DataBind();
        ddlDedType.ClearSelection();
        RbpayAmount.ClearSelection();
        RdbAmt.SelectedValue = "2";
    }

    bool btnSaveValidation()
    {

        if (ddlSelect.SelectedItem.Value == "0")
        {
            ddlSelect.Focus();
            ShowMessage(" Please Select Select Type ", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtDesc.Text.Trim()))
        {
            txtDesc.Focus();
            ShowMessage("Please Enter Description", false);
            return false;
        }
        else if (string.IsNullOrEmpty(txtAbrDesc.Text.Trim()))
        {
            txtAbrDesc.Focus();
            ShowMessage("Please Enter Abbreviated Description", false);
            return false;
        }
        else if (RbpayAmount.SelectedValue == "")
        {
            RbpayAmount.Focus();
            ShowMessage(" Please Select Payment Type ", false);
            return false;
        }
        else if (ddlGlCode.SelectedItem.Value == "0")
        {
            ddlGlCode.Focus();
            ShowMessage(" Please Select SGL Code ", false);
            return false;
        }


        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool IsValid = btnSaveValidation();
        if (!IsValid)
        {
            return;
        }
        else
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "";
            plobj = new PL_EarDed();
            if (btnSave.Text == "Save")
            {
                plobj.Ind = 2;
            }
            if (btnSave.Text == "Update")
            {
                plobj.Ind = 3;
                plobj.AutoNo = Convert.ToInt32(ViewState["AutoNo"]);
                plobj.Edcd = Convert.ToInt32(ViewState["EDCD"]);
            }
            plobj.CityCode = 1001001;
            plobj.Desc = txtDesc.Text.Trim();
            plobj.AbrDesc = txtAbrDesc.Text.Trim();
            plobj.Priority = 0;
            if (ddlSelect.SelectedValue == "1")
            {
                plobj.Edcdind = 1;
            }
            if (ddlSelect.SelectedValue == "2")
            {
                if (ddlDedType.SelectedValue == "1")
                {
                    plobj.Edcdind = 2;
                }
                if (ddlDedType.SelectedValue == "2")
                {
                    plobj.Edcdind = 3;
                }
            }
            if (RbpayAmount.SelectedValue == "0")
            {
                if (RdbAmt.SelectedValue == "0")
                {
                    plobj.Fixamt = Convert.ToInt32(txtAmt.Text);
                    plobj.PerValue = Convert.ToInt32(ViewState["perval"]);
                    //plobj.Fixamt = Convert.ToInt32(ViewState["FixAmt"]);
                    plobj.PerValue7 = Convert.ToInt32(ViewState["perval7"]);
                    plobj.Fixamt7 = Convert.ToInt32(ViewState["FixAmt7"]);
                }
                if (RdbAmt.SelectedValue == "1")
                {
                    plobj.PerValue = Convert.ToInt32(txtAmt.Text);
                    //plobj.PerValue = Convert.ToInt32(ViewState["perval"]);
                    plobj.Fixamt = Convert.ToInt32(ViewState["FixAmt"]);
                    plobj.PerValue7 = Convert.ToInt32(ViewState["perval7"]);
                    plobj.Fixamt7 = Convert.ToInt32(ViewState["FixAmt7"]);
                }
                if (RdbAmt.SelectedValue == "2")
                {
                    plobj.Fixamt = 0;
                    plobj.PerValue = 0;
                    plobj.PerValue7 = 0;
                    plobj.Fixamt7 = 0;

                }
                plobj.PayInd = 0;
            }
            else
            {
                if (RdbAmt.SelectedValue == "0")
                {
                    plobj.Fixamt7 = Convert.ToInt32(txtAmt.Text);
                    plobj.PerValue = Convert.ToInt32(ViewState["perval"]);
                    plobj.Fixamt = Convert.ToInt32(ViewState["FixAmt"]);
                    plobj.PerValue7 = Convert.ToInt32(ViewState["perval7"]);
                    //plobj.Fixamt7 = Convert.ToInt32(ViewState["FixAmt7"]);
                }
                if (RdbAmt.SelectedValue == "1")
                {
                    plobj.PerValue7 = Convert.ToInt32(txtAmt.Text);
                    plobj.PerValue = Convert.ToInt32(ViewState["perval"]);
                    plobj.Fixamt = Convert.ToInt32(ViewState["FixAmt"]);
                    //plobj.PerValue7 = Convert.ToInt32(ViewState["perval7"]);
                    plobj.Fixamt7 = Convert.ToInt32(ViewState["FixAmt7"]);
                }
                if (RdbAmt.SelectedValue == "2")
                {
                    plobj.Fixamt = 0;
                    plobj.PerValue = 0;
                    plobj.PerValue7 = 0;
                    plobj.Fixamt7 = 0;

                }

                plobj.PayInd = 1;
            }
            plobj.GlCode = Convert.ToInt32(ddlGlCode.SelectedValue);
            plobj.CarryCode = 0;
            plobj.Rangeind = 0;
            plobj.GROUPCODE = 0;
            DataTable dt = Salary_CLSCommon.ApiPostDataTable("EarDed/SaveData", plobj);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["LastNo"].ToString() == "1")
                {
                    ShowMessage("Record Save Successfully", true);
                    BindGridView();
                    Clear();
                    return;
                }
                if (dt.Rows[0]["LastNo"].ToString() == "2")
                {
                    ShowMessage("Record Updated Successfully", true);
                    BindGridView();
                    Clear();
                    return;
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        Clear();
    }
    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    protected void ddlDedType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        BindGridView();
        //  RdbAmt.ClearSelection();
        txtAmt.Text = "";

    }
    protected void RdbAmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["FixAmt"] == null || ViewState["perval"] == null || ViewState["FixAmt7"] == null || ViewState["perval7"] == null)
        {
            if (RdbAmt.SelectedValue == "0")
            {
                txtAmt.Text = "";
                txtAmt.Attributes.Add("Placeholder", "Fix Amount");
            }
            else if (RdbAmt.SelectedValue == "1")
            {
                txtAmt.Text = "";
                txtAmt.Attributes.Add("Placeholder", "Percent %");
            }
            else
            {
                txtAmt.Text = "";
                txtAmt.Attributes.Add("Placeholder", "Other");
            }
        }
        else
        {
            if (RbpayAmount.SelectedValue == "0" && RdbAmt.SelectedValue == "0")
            {
                txtAmt.Text = ViewState["FixAmt"].ToString();
            }
            else if (RbpayAmount.SelectedValue == "0" && RdbAmt.SelectedValue == "1")
            {
                txtAmt.Text = ViewState["perval"].ToString();
            }

            else if (RbpayAmount.SelectedValue == "0" && RdbAmt.SelectedValue == "2")
            {
                txtAmt.Text = "0";
            }

            else if (RbpayAmount.SelectedValue == "1" && RdbAmt.SelectedValue == "0")
            {
                txtAmt.Text = ViewState["FixAmt7"].ToString();
            }
            else if (RbpayAmount.SelectedValue == "1" && RdbAmt.SelectedValue == "1")
            {
                txtAmt.Text = ViewState["perval7"].ToString();
            }
            else if (RbpayAmount.SelectedValue == "1" && RdbAmt.SelectedValue == "2")
            {
                txtAmt.Text = "0";
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowindex = gvr.RowIndex;
        Label autono = (Label)GvEdcd.Rows[rowindex].FindControl("lblautono");
        Label EDCD = (Label)GvEdcd.Rows[rowindex].FindControl("lblEdcd");
        Label Desc = (Label)GvEdcd.Rows[rowindex].FindControl("lbldesc");
        Label AbrDesc = (Label)GvEdcd.Rows[rowindex].FindControl("lblAbrDesc");
        Label FixAmt = (Label)GvEdcd.Rows[rowindex].FindControl("lblFixamt");
        Label perval = (Label)GvEdcd.Rows[rowindex].FindControl("lblPerValue");
        Label FixAmt7 = (Label)GvEdcd.Rows[rowindex].FindControl("lblFixamt7");
        Label perval7 = (Label)GvEdcd.Rows[rowindex].FindControl("lblPerValue7");
        Label GLCode = (Label)GvEdcd.Rows[rowindex].FindControl("lblGlCode");
        Label PayInd = (Label)GvEdcd.Rows[rowindex].FindControl("lblPayInd");

        ViewState["FixAmt"] = FixAmt.Text;
        ViewState["perval"] = perval.Text;
        ViewState["FixAmt7"] = FixAmt7.Text;
        ViewState["perval7"] = perval7.Text;

        RbpayAmount.SelectedValue = PayInd.Text;

        if (RbpayAmount.SelectedValue == "0")
        {
            if (Convert.ToInt32(FixAmt.Text) > 0)
            {
                RdbAmt.SelectedIndex = 0;
                txtAmt.Text = FixAmt.Text;
            }
            else if (Convert.ToInt32(perval.Text) > 0)
            {
                RdbAmt.SelectedIndex = 1;
                txtAmt.Text = perval.Text;

            }
            else
            {
                RdbAmt.SelectedIndex = 2;
                txtAmt.Text = "0";
            }
        }

        if (RbpayAmount.SelectedValue == "1")
        {
            if (Convert.ToInt32(FixAmt7.Text) > 0)
            {
                RdbAmt.SelectedIndex = 0;
                txtAmt.Text = FixAmt7.Text;
            }
            else if (Convert.ToInt32(perval7.Text) > 0)
            {
                RdbAmt.SelectedIndex = 1;
                txtAmt.Text = perval7.Text;

            }
            else
            {
                RdbAmt.SelectedIndex = 2;
                txtAmt.Text = "0";
            }
        }

        //if (PayInd.Text == "1")
        //{
        //    if (FixAmt7.Text == "0" || perval7.Text == "0")
        //    {
        //        if (FixAmt7.Text != "0")
        //        {
        //            txtAmt.Text = FixAmt7.Text;
        //            RdbAmt.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            txtAmt.Text = perval7.Text;
        //            RdbAmt.SelectedIndex = 1;
        //        }
        //        RbpayAmount.SelectedIndex = 1;
        //    }
        //    else
        //    {
        //        txtAmt.Text = "";
        //    }
        //}
        //else
        //{
        //    if (FixAmt.Text == "0" || perval.Text == "0")
        //    {
        //        if (FixAmt.Text != "0")
        //        {
        //            txtAmt.Text = FixAmt.Text;
        //            RdbAmt.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            txtAmt.Text = perval.Text;
        //            RdbAmt.SelectedIndex = 1;
        //        }
        //    }
        //    else
        //    {
        //        txtAmt.Text = "";
        //    }
        //    RbpayAmount.SelectedIndex = 0;
        //}



        txtDesc.Text = Desc.Text;
        txtAbrDesc.Text = AbrDesc.Text;
        ddlGlCode.SelectedValue = GLCode.Text;
        ViewState["EDCD"] = EDCD.Text;
        ViewState["AutoNo"] = autono.Text;
        btnSave.Text = "Update";
    }
    protected void RbpayAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        //RdbAmt.ClearSelection();
        txtAmt.Text = "";

    }
}