using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Estate_frmMasterUpdate : System.Web.UI.Page
{
    PL_MasterUpdate objpl = new PL_MasterUpdate();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if(!IsPostBack )
        {
            pnlfailed.Visible = false;
            pnlSuccess.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            pnlSuccess.Visible = false;
            if (txtRefNo.Text == "")
            {
                pnlfailed.Visible = true;
                pnlfailed.InnerText = "Enter Ref No.";
                return;
            }
            objpl = new PL_MasterUpdate()
            {
                Ind = 1,
               IDARefNo =Convert.ToInt32(txtRefNo.Text)
            };
            DataSet ds = Estate_CLSCommon.CallApiPostDS("MasterUpdate/GetData", objpl);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ServiceNo"].ToString() != "")
                    {
                        txtRefNo.Enabled = false;
                        txtServiceNo.Text = ds.Tables[0].Rows[0]["ServiceNo"].ToString();
                        txtPlotHolderName.Text = ds.Tables[0].Rows[0]["PlotHolderNameE"].ToString();
                        txtPropertyNo.Text = ds.Tables[0].Rows[0]["PropUseCode"].ToString();
                        txtTotNoInst.Text = ds.Tables[0].Rows[0]["TotNoOfInst"].ToString();
                        txtTotPaidInst.Text = ds.Tables[0].Rows[0]["TotNoOfPaidInst"].ToString();
                        txtPropCost.Text = ds.Tables[0].Rows[0]["PropCost"].ToString();
                        txtDownPer.Text = ds.Tables[0].Rows[0]["DownPayPer"].ToString();
                        txtDownAmt.Text = ds.Tables[0].Rows[0]["DownPayAmount"].ToString();
                        txtLoanAmt.Text = ds.Tables[0].Rows[0]["InstLoanBalAmt"].ToString();
                        txtEmdAmt.Text = ds.Tables[0].Rows[0]["EmdAmt"].ToString();
                        //  string value =  ds.Tables[0].Rows[0]["InstRegInterestRate"].ToString();
                        // double rate = Convert.ToDouble(value);
                        txtIntRate.Text = ds.Tables[0].Rows[0]["InstRegInterestRate"].ToString();//Math.Truncate(rate).ToString(); 
                        txtStartDate.Text = ds.Tables[0].Rows[0]["InstStartDate"].ToString();

                        pnlfailed.Visible = false;
                    }
                }
                else
                {
                    pnlfailed.Visible = true;
                    pnlfailed.InnerText = "Record Not Found";
                    return;
                }
            }           
        }
        catch(Exception ex)
        {

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objpl = new PL_MasterUpdate()
        {
            Ind = 2,
            IDARefNo = txtRefNo.Text=="" ? 0 :  Convert.ToInt32(txtRefNo.Text),
            ServiceNo =txtServiceNo.Text == "" ? 0 : Convert.ToInt32(txtServiceNo.Text),
            PropCost = txtPropCost.Text == "" ? 0 : Convert.ToDecimal(txtPropCost.Text),
            DownPayPer =txtDownPer.Text == "" ? 0 : Convert.ToDecimal(txtDownPer.Text),
            DownPayAmount = txtDownAmt.Text == "" ? 0 : Convert.ToDecimal(txtDownAmt.Text),
            InstLoanBalAmt =txtLoanAmt.Text == "" ? 0 : Convert.ToDecimal(txtLoanAmt.Text),
            EmdAmt = txtEmdAmt.Text == "" ? 0 : Convert.ToDecimal(txtEmdAmt.Text),
            InstRegInterestRate = txtIntRate.Text == "" ? 0 : Convert.ToDecimal(txtIntRate.Text),
            InstStartDate = txtStartDate.Text == "" ? "" : Estate_CLSCommon.DateFormat(txtStartDate.Text)
        };
        DataSet ds = Estate_CLSCommon.CallApiPostDS("MasterUpdate/UpdateData", objpl);
        if (ds != null)
        {
            if (ds.Tables[0].Rows[0]["res"].ToString() == "1")
            {
                pnlSuccess.Visible = true;
                pnlSuccess.InnerText = "Record Updated Successfully";                
                Clear();
                txtRefNo.Enabled = true;
                return;
            }
        }
    }

    public void Clear()
    {
        txtServiceNo.Text = "";
        txtRefNo.Text = "";
        txtPlotHolderName.Text = "";
        txtPropertyNo.Text = "";
        txtTotNoInst.Text = "";
        txtTotPaidInst.Text = "";
        txtPropCost.Text = "";
        txtDownPer.Text = "";
        txtDownAmt.Text = "";
        txtLoanAmt.Text = "";
        txtEmdAmt.Text = "";
        txtIntRate.Text = "";
        txtStartDate.Text = "";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
        pnlSuccess.Visible = false;
        pnlfailed.Visible = false;
        txtRefNo.Enabled = true;
    }
}