//using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forms_frmServiceNoRpt : System.Web.UI.Page
{
    PL_StickerPrint objpl = null;
   BL_StickerPrint objbl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        objbl = new BL_StickerPrint();
        objpl = new PL_StickerPrint();
        int Ind = 0;
        DataTable dt=new DataTable();
        ErrorDiv.Style.Add("display", "none");
        ErrorMsg.InnerText = string.Empty;

        if (rbnSingleServiceNo.Checked && txtServiceNo.Text == "")
        {
            ErrorDiv.Style.Add("display", "block");
            ErrorMsg.InnerText = "File Service No is required.";
            txtServiceNo.Focus();
            return;
        }
        if (rbnMultiServiceNo.Checked)
        {
            if (txtServiceNoFrom.Text == "")
            {
                ErrorDiv.Style.Add("display", "block");
                ErrorMsg.InnerText = "File Service No is required.";
                txtServiceNoFrom.Focus();
                return;
            }
            else if (txtServiceNoTo.Text == "")
            {
                ErrorDiv.Style.Add("display", "block");
                ErrorMsg.InnerText = "File Service No is required.";
                txtServiceNoTo.Focus();
                return;
            }
        }
        if (rbnSingleServiceNo.Checked)
        {
           objpl.Ind = 1;
           objpl.ServiceNo = Convert.ToDecimal(txtServiceNo.Text.Trim());
        }
        else if (rbnMultiServiceNo.Checked)
        {
             objpl.Ind = 2;
             objpl.ServiceNoFrom =Convert.ToDecimal( txtServiceNoFrom.Text.Trim());
             objpl.ServiceNoTo = Convert.ToDecimal(txtServiceNoTo.Text.Trim());
        }
       
      
       //// DataAccessObj = new DL_SteckerPrint();
       // DataAccessObj.GetSteckerPrint(plSteckerPrint);
      dt = objbl.GetServiceNo(objpl);
      int i = 0;
      if (dt != null)
      {
          StringBuilder sb = new StringBuilder();

          if (dt.Rows.Count > 0)
          {
              string pad = "7";
              foreach (DataRow row in dt.Rows)
              {
                  sb.Append("<table style='border: 1px solid #848484; width: 100%;'>");
                  sb.Append("<tr>");
                  sb.Append("<th colspan='4' style='border-bottom: 1px solid #848484; padding: 8px'>Indore Development Authority,Indore,&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Document Scanning SYSTEM</th>");
                  sb.Append("</tr>");
                  sb.Append("<tr>");
                  sb.Append("<th style='padding: "+pad+"px; width: 15%; border-right: 1px solid #848484'>Scheme Name</th>");
                  sb.Append("<td style='padding: "+pad+"px; width: 45%; border-right: 1px solid #848484'>" + row["SchemeName"].ToString() + "</td>");
                  sb.Append("<th style='padding: "+pad+"px; width: 15%; border-right: 1px solid #848484'>Scheme No.</th>");
                  sb.Append("<td style='padding: "+pad+"px; width: 25%'>" + row["SchCode"].ToString() + "</td>");
                  sb.Append("</tr>");            
                  sb.Append("<tr>");             
                  sb.Append("<th style='padding: "+pad+"px; border-right: 1px solid #848484'>Plot No.</th>");
                  sb.Append("<td style='padding: "+pad+"px; border-right: 1px solid #848484'>" + row["PlotNo"].ToString() + "</td>");
                  sb.Append("<th style='padding: "+pad+"px; border-right: 1px solid #848484; border-bottom: 1px solid #848484'>Plot Holder Name.</th>");
                  sb.Append("<td style='padding: "+pad+"px; border-bottom: 1px solid #848484'>" + row["PlotHolderNameE"].ToString() + "</td>");
                  sb.Append("</tr>");           
                  sb.Append("<tr>");            
                  sb.Append("<th style='padding: "+pad+"px; border-right: 1px solid #848484'>Address</th>");
                  sb.Append("<td style='padding: "+pad+"px;' colspan='3'>" + row["Address"].ToString() + "</td>");
                  sb.Append("</tr>");           
                  sb.Append("<tr>");            
                  sb.Append("<th style='padding: "+pad+"px; border-right: 1px solid #848484'>Service No.</th>");
                  sb.Append("<td style='padding: "+pad+"px;' colspan='3' class='hindi'>" + row["ServiceNo"].ToString() + "</td>");
                  sb.Append("</tr>");            
                  sb.Append("<tr>");             
                  sb.Append("<th style='padding: "+pad+"px; border-right: 1px solid #848484'>Ref. No.</th>");
                  sb.Append("<td style='padding: "+pad+"px;' colspan='3'>" + row["IdaRefNo"].ToString() + "</td>");
                  sb.Append("</tr>");
                 // sb.Append("<tr>");
                //  sb.Append("<th style='padding: 8px; border-right: 1px solid #848484'>Lease Description</th>");

                  //string hno = row["HouseNo"].ToString() == null ? " " : row["HouseNo"].ToString();
                  //string applicName = row["ApplicantName"].ToString() == null ? " " : row["ApplicantName"].ToString();
                  //string schName = row["SchName"].ToString() == null ? " " : row["SchName"].ToString();

                  //string address = "H. No.: " + hno + ", " + schName + ", " + applicName;
                //  sb.Append("<td style='padding: 8px;' colspan='3'>" + address + "</td>");
                  //sb.Append("</tr>");

                  sb.Append("</table>");
                  if (dt.Rows.Count > 1)
                  {
                      sb.Append("<div style='border-bottom:1px dashed #000;width:100%;height:2px;margin-top:7px;margin-bottom:7px'></div>");
                  }
              }
              divHtmlReport.InnerHtml = sb.ToString();
              divHtmlReport.Style.Add("display", "block");
          }
          else
          {
              divHtmlReport.Style.Add("display", "none");
              ErrorDiv.Style.Add("display", "block");
              ErrorMsg.InnerText = "There is no data for printing.";
              txtServiceNo.Focus();
              return;
          }

          //if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
          //{
          //    //DivReport.Style.Add("display", "block");
          //    //rv.ProcessingMode = ProcessingMode.Local;
          //    //rv.LocalReport.ReportPath = Server.MapPath("~/Reports/rptSteckerPrint.rdlc");
          //    //ReportDataSource datasource = new ReportDataSource("dsSteckerPrint", dt.Tables[0]);
          //    //rv.LocalReport.DataSources.Clear();
          //    //rv.LocalReport.DataSources.Add(datasource);
          //}
          //else
          //{
          //    //DivReport.Style.Add("display", "none");
          //    ErrorDiv.Style.Add("display", "block");
          //    ErrorMsg.InnerText = "There is no data for printing.";
          //    txtServiceNo.Focus();
          //    return;
          //}
      }
      else
      {
          //DivReport.Style.Add("display", "none");
          ErrorDiv.Style.Add("display", "block");
          ErrorMsg.InnerText = "Data not found.";
          txtServiceNo.Focus();
          return;
      }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFileds();
    }

    private void ClearFileds()
    {
        txtServiceNo.Text = "";
        txtServiceNoFrom.Text = "";
        txtServiceNoTo.Text = "";
        rbnSingleServiceNo.Checked = true;
        //rv.LocalReport.DataSources.Clear();
        ErrorDiv.Style.Add("display", "none");
        ErrorMsg.InnerText = string.Empty;
        //DivReport.Style.Add("display", "none");
        divHtmlReport.Style.Add("display", "none");
    }
}