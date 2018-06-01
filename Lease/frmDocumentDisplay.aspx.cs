using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forms_frmDocumentDisplay : System.Web.UI.Page
{
    List<DispImgDetail> images;
    List<DispImgDetail> imagesList;
    DataTable dtDocType;

    //ModelDocDisplay plDocDisplay;
    //DL_DocDisplay DataAccessObj;

    string _fileTrackNo;
    string _LeaseNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FillDropdown();

        }
    }

    void SetMessage(string Message, bool Issuccess)
    {
        IdaCustomAlert.Visible = true;
       // icons.Attributes.Remove("class");
        IdaCustomAlert.Attributes.Remove("class");
        if (Issuccess)
        {
            //icons.Attributes.Add("class", "fa fa-check");
            IdaCustomAlert.Attributes.Add("class", "IdaCustomAlert success");
        }
        else
        {
           // icons.Attributes.Add("class", "fa fa-exclamation-triangle");
            IdaCustomAlert.Attributes.Add("class", "IdaCustomAlert failed");
        }
        IdaCustomAlertMsg.InnerHtml = Message;
    }
    public void clearSearch()
    {
        lblPlotHolderName.Text = "";
        lblPlotNo.Text = "";
        lblSchName.Text = "";
        txtServiceNo.Text = "";
        txtServiceNo.Enabled = true;
        MainImgDiv.Style.Add("display", "none");

        IdaCustomAlert.Visible = false;
        pnlDocType.Visible = false;
        
    }

    BL_DisplayImage objbl = new BL_DisplayImage();
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       // Div2.Style.Add("display", "none");
        try
        {
            if (txtServiceNo.Text == "")
            {
                //IdaCustomAlert.Style.Add("display", "block");
                //ErrorMsg.InnerText = "Sevice Number is required.";
                txtServiceNo.Focus();
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                int Ind = 1;
                decimal ServiceNo = Convert.ToDecimal(txtServiceNo.Text.Trim());
                dt = objbl.GetScanningFile(Ind, ServiceNo);
                if (dt != null)
                {

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Columns.Count == 1)
                        {
                            SetMessage("Entry Not Found", false);
                            IdaCustomAlert.Visible = true;
                            //ErrorMsg.InnerText = "Entry Not Found";
                        }
                        else
                        {   schCode.Value = Convert.ToString(dt.Rows[0]["SchCode"]);
                            lblPlotHolderName.Text = Convert.ToString(dt.Rows[0]["PlotHolderNameE"]);
                            lblPlotNo.Text = Convert.ToString(dt.Rows[0]["PlotNo"]);
                            lblSchName.Text = Convert.ToString(dt.Rows[0]["SchemeName"]);
                            txtServiceNo.Enabled = false;
                            FillImageGrid();
                            pnlDocType.Visible = true;
                            SearchDetails.Style.Add("display", "block");
                            IdaCustomAlert.Visible = false;
                        }
                    }

                }
            }

        }
        catch (Exception ex)
        {
            //FillImageGrid(images);
            //IdaCustomAlert.Style.Add("display", "block");
            //ErrorMsg.InnerText = ex.Message + " , Image Count : " + indexCount + ", Path : " + Showpath + ", Error Line No. : " + ErrorlineNo;
        }
    }


    DataTable dt;
    public DataTable GetImagePath()
    {
        //plDocDisplay = new ModelDocDisplay();
        //plDocDisplay.Ind = 3;
        //DataAccessObj = new DL_DocDisplay();
        //DataAccessObj.GetImagePath(plDocDisplay);
        //if (plDocDisplay.dt != null && plDocDisplay.dt.Rows.Count > 0)
        //{
        //    dt = new DataTable();
        //    dt = plDocDisplay.dt;

        //}

        return dt;
    }

    DataTable tempdt;
    private DataTable FillDocType()
    {

        // Fill Document Type
        //plDocDisplay = new ModelDocDisplay();
        //plDocDisplay.Ind = 4;
        //DataAccessObj = new DL_DocDisplay();
        //DataAccessObj.GetDocType(plDocDisplay);
        //if (plDocDisplay.dt != null && plDocDisplay.dt.Rows.Count > 0)
        //{
        //    Session["DocType"] = new DataTable();
        //    Session["DocType"] = plDocDisplay.dt;
        //    tempdt = new DataTable();
        //    tempdt = plDocDisplay.dt;

        //}
        return tempdt;
    }
    DataTable ImgDT;
    // protected void btnSearch_Click(object sender, EventArgs e)
    // {
    //_fileTrackNo = string.Empty;
    //_LeaseNo = string.Empty;
    //try
    //{
    //    if (rbnFileTrackNo.Checked && txtFileTrackNo.Text == "")
    //    {
    //        IdaCustomAlert.Style.Add("display", "block");
    //        ErrorMsg.InnerText = "File Number is required.";
    //        txtFileTrackNo.Focus();
    //        return;
    //    }
    //    else if (rbnSysUniqueNo.Checked && txtSysUniqueNo.Text == "")
    //    {
    //        IdaCustomAlert.Style.Add("display", "block");
    //        ErrorMsg.InnerText = "Lease Number is required.";
    //        txtSysUniqueNo.Focus();
    //        return;
    //    }
    //    else
    //    {
    //        IdaCustomAlert.Style.Add("display", "none");
    //        ErrorMsg.InnerText = string.Empty;

    //        plDocDisplay = new ModelDocDisplay();
    //        DataAccessObj = new DL_DocDisplay();
    //        if (txtFileTrackNo.Text != "")
    //        {
    //            plDocDisplay.Ind = 1;
    //            plDocDisplay.FileTrackNo = txtFileTrackNo.Text.Trim();
    //            DataAccessObj.GetDataByFileNo(plDocDisplay);
    //        }
    //        else
    //        {
    //            plDocDisplay.Ind = 2;
    //            plDocDisplay.SysUniqueNo = txtSysUniqueNo.Text.Trim();
    //            DataAccessObj.GetDataBySysNo(plDocDisplay);
    //        }
    //        if (plDocDisplay.dt != null && plDocDisplay.dt.Rows.Count > 0)
    //        {
    //            _fileTrackNo = plDocDisplay.dt.Rows[0]["FileTrackNo"].ToString();
    //            _LeaseNo = plDocDisplay.dt.Rows[0]["SystemUniqueNo"].ToString();

    //            txtSFileNo.Text = plDocDisplay.dt.Rows[0]["FileTrackNo"].ToString();
    //            txtSFileDesc.Text = plDocDisplay.dt.Rows[0]["FileTrackDesc"].ToString();
    //            txtSSysNo.Text = plDocDisplay.dt.Rows[0]["SystemUniqueNo"].ToString();
    //            txtSSysDesc.Text = plDocDisplay.dt.Rows[0]["SystemDesc"].ToString().ToUpper();
    //            txtSSubEng.Text = plDocDisplay.dt.Rows[0]["FileSubNameEng"].ToString().ToUpper(); ;
    //            txtSSubHindi.Text = plDocDisplay.dt.Rows[0]["FileSubNameHindi"].ToString();
    //            hfSchemeCode.Value = plDocDisplay.dt.Rows[0]["SchCode"].ToString();
    //        }

    //        FillImageGrid();
    //        SearchDetails.Style.Add("display", "block");
    //    }
    //}
    //catch (Exception ex)
    //{
    //    IdaCustomAlert.Style.Add("display", "block");
    //    ErrorMsg.InnerText = ex.Message;
    //    txtSysUniqueNo.Focus();
    //    return;
    //}
    //  }

    private DataTable FillDropdown()
    {
        DataTable dt = new DataTable();
        int ind = 2;
        dt = objbl.ddlFillDocumentType(ind);

        if (dt != null && dt.Rows.Count > 0)
        {
            //ddlDocType.DataSource = dt;
            //ddlDocType.DataTextField = "DocDesc";
            //ddlDocType.DataValueField = "DocTypeID";
            //ddlDocType.Items.Insert(0, "-Select-");
            //ddlDocType.DataBind();
        }
        else
        {
             dt = null;
        }
        return dt;

    }

    int cnt = 0;
    int tFCount = 0;
    int lineno = 0;
    string _ext = string.Empty;
    private void FillImageGrid()
    {
        ImgDT = new DataTable();
        ImgDT = GetImagePath();
        //if (ImgDT == null)
        //{
        //    return;
        //}
        try
        {
            // string ImgDispPath = ImgDT.Rows[3]["ImagePath"].ToString() + hfSchemeCode.Value + "//";
            string ImgDispPath = ConfigurationManager.AppSettings["FinalImageVirtualPath"].ToString() + "\\" + schCode.Value + "\\";
           // string OrignalPath = ImgDT.Rows[1]["ImagePath"].ToString() + hfSchemeCode.Value + "//";
            string OrignalPath = ConfigurationManager.AppSettings["FinalImagePhysicalPath"].ToString() + "\\" + schCode.Value + "\\";
            string[] filesindirectory = Directory.GetFiles(OrignalPath, "" + txtServiceNo.Text.Trim() + "*");

            dtDocType = FillDropdown();
            if (dtDocType.Rows.Count <= 0)
            {
                return;
            }
            if (filesindirectory.Count() > 0)
            {
                images = new List<DispImgDetail>();
                string fileName = string.Empty;
                foreach (string item in filesindirectory)
                {

                    _ext = System.IO.Path.GetExtension(item);
                    if (_ext == ".jpg" || _ext == ".JPG" || _ext == ".jpeg" || _ext == ".JPEG" || _ext == ".png" || _ext == ".PNG")
                    {

                        fileName = string.Empty;
                        fileName = System.IO.Path.GetFileName(item);
                        string[] splitFileName = fileName.Split('_');
                        int getDocType = Convert.ToInt32(splitFileName[2].Split('.')[0]);                      
                                            
                       
                        DataRow[] dr = dtDocType.Select("DocTypeId = '" + getDocType + "'");
                      
                        string showImagePath = ImgDispPath + fileName;
                        if (dr.Count() > 0)
                        {
                            foreach (DataRow row in dr)
                            {
                                if (txtServiceNo.Text.Trim() != string.Empty && splitFileName[0].ToString() == txtServiceNo.Text.Trim())
                                {
                                    images.Add(new DispImgDetail()
                                    {
                                        ImageID = "box-img" + Convert.ToInt32(splitFileName[1].ToString()),
                                        ImgType = row["DocDesc"].ToString(),
                                        Index = Convert.ToInt32(splitFileName[1].ToString()),
                                        ImagePath = ImgDispPath + fileName,
                                        OrignalImgPath = item.ToString()
                                    });
                                }
                            }

                            StringBuilder sb = new StringBuilder();
                            if (images.Count > 0)
                            {
                                sb.Append("<table><tr>");
                                foreach (DispImgDetail img in images)
                                {
                                    sb.Append("<td>");
                                    sb.Append("<img class='box-img' src='" + img.ImagePath + "' />");
                                    sb.Append("<label>" + img.ImgType + "</label>");
                                    sb.Append("</td>");
                                }
                                sb.Append("</tr></table>");
                                ImgDiv.InnerHtml = sb.ToString();
                                MainImgDiv.Style.Add("display", "block");
                            }

                        }

                       
                    }

                }
            }
            else
            {
                SetMessage("There is no images of this File Track Number.", false);
                IdaCustomAlert.Visible = true;
             //   ErrorMsg.InnerText = "There is no images of this File Track Number.";
                return;
            }

           
        }
        catch (Exception ex)
        {
            IdaCustomAlert.Visible = true;
           // ErrorMsg.InnerText = "Exception : " + ex.Message + ", File Count : " + tFCount;
            //  txtSysUniqueNo.Focus();
            return;
        }
        //gvThumbnail.DataSource = images;
        //gvThumbnail.DataBind();
    }
    protected void btnClearsearch_Click(object sender, EventArgs e)
    {
        clearSearch();
    }
}



public class DispImgDetail
{
    public int Index { get; set; }
    public string ImgType { get; set; }
    public string ImageID { get; set; }
    public string ImagePath { get; set; }
    public string OrignalImgPath { get; set; }
}