using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FrmReplyType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          ShowAllDevCateCode();
        }
        pnlfailed.Visible = false;
        pnlSuccess.Visible = false;
    }
    private void ClearData()
    {
        txt_ReplyTypeE.Text = "";
        txt_ReplyTypeH.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PL_ReplyMaster objpl = new PL_ReplyMaster();
        if(txt_ReplyTypeE.Text=="")
        {
             pnlfailed.InnerHtml = "Enter Reply Type English..";
                    pnlSuccess.Visible = false;
                    pnlfailed.Visible = true;
            return;
        }
        if (txt_ReplyTypeH.Text == "")
        {
            pnlfailed.InnerHtml = "Enter Reply Type Hindi..";
            pnlSuccess.Visible = false;
            pnlfailed.Visible = true;
            return;
        }
        else
        {
            objpl.Ind = 1;
            objpl.ReplyTypeDescE = txt_ReplyTypeE.Text;
            objpl.ReplyTypeDescH = txt_ReplyTypeH.Text;
            if (btnSave.Text == "Update")
            {
                objpl.Ind = 2;
                objpl.ReplyTypeCode = Convert.ToInt32(Session["replyTypeCode"]);
                objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
                DataSet ds = Legal_CLSCommon.CallApiPostDS("ReplyType/EditReplyType", objpl);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                    {
                        pnlSuccess.InnerHtml = "Edit Successfully Complete.";
                        Session["replyTypeCode"] = null;
                        ClearData();
                        btnSave.Text = "Save";
                        ShowAllDevCateCode();
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
                objpl.CityCode = Convert.ToInt32(Session["CityCode"]);
                objpl.EntryUserCode = Convert.ToInt32(Session["UserCode"]);
                objpl.OrgCode = Convert.ToInt32(Session["OrgCode"]);
                DataSet ds = Legal_CLSCommon.CallApiPostDS("ReplyType/SubmitReplyType", objpl);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
                    {
                        pnlSuccess.InnerHtml = "Save Successfully.";
                        ClearData();
                        ShowAllDevCateCode();
                        pnlSuccess.Visible = true;
                        pnlfailed.Visible = false;
                    }
                    else if (ds.Tables[0].Rows[0]["res"].ToString() == "2")
                    {
                        pnlfailed.InnerHtml = "Allready Exist.";                        
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
        }
    }
    private void ShowAllDevCateCode()
    {
        PL_ReplyMaster objpl = new PL_ReplyMaster();
        objpl.Ind = 5;
        objpl.CityCode =Convert.ToInt32( Session["CityCode"]);
        DataSet ds = Legal_CLSCommon.CallApiGet("ReplyType/GetAllReplyType?Ind=" + objpl.Ind + "&CityCode=" + objpl.CityCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            GridReplyType.DataSource = ds.Tables[0];
            GridReplyType.DataBind();
        }
        else
        {
            ds = null;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void GridReplyType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        PL_ReplyMaster objpl = new PL_ReplyMaster();
        if (e.CommandName == "DelRecord")
        {
            int ReplyTypeCode = Convert.ToInt32(e.CommandArgument.ToString());
            objpl.Ind = 3;
            objpl.ReplyTypeCode = ReplyTypeCode;
            DataSet ds = Legal_CLSCommon.CallApiPostDS("ReplyType/DeleteReplyType", objpl);
            if (ds != null && ds.Tables.Count > 0)
            {
                ShowAllDevCateCode();
                pnlSuccess.Visible = true;
                pnlSuccess.InnerHtml = "Record Deleted Successfully";
            }
            else
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerHtml = "Record Not Deleted ";
            }
        }

        else if (e.CommandName == "EditRecord")
        {         
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            int ReplyTypeCode = Convert.ToInt32(GridReplyType.DataKeys[rowindex].Value);
            HiddenField field = GridReplyType.Rows[rowindex].FindControl("lblReplyTypeCode") as HiddenField;          
            Label lblReplyTypeE = (Label)GridReplyType.Rows[rowindex].FindControl("lblReplyTypeDescE");
            Label lblReplyTypeH = (Label)GridReplyType.Rows[rowindex].FindControl("lblReplyTypeDescH");
            txt_ReplyTypeE.Text = lblReplyTypeE.Text;
            txt_ReplyTypeH.Text = lblReplyTypeH.Text;
            Session["replyTypeCode"] = ReplyTypeCode;
            btnSave.Text = "Update";
        }
    }
}