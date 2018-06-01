using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class forms_frmImgCrop : System.Web.UI.Page
{
    //ModelImageCropping plImageCrop;
    //ModelImagePath plImagePath;
    //DL_ImageCropping DataAccessObj;
    int i;
    int j;
    string _fileNo = string.Empty;
    List<ImageDetail> images;
    List<ImageDetail> imagesList;

    protected void Page_Load(object sender, EventArgs e)
    {

        IdaCustomAlert.Visible = false;
        if (!Page.IsPostBack)
        {
            FillDropdown();
            //GetImagePath();
        }

    }



    private void FillDropdown()
    {
        DataTable dt = new DataTable();
        int ind = 2;
        dt = objbl.ddlFillDocumentType(ind);

        if (dt != null && dt.Rows.Count > 0)
        {
            ddlDocType.DataSource = dt;
            ddlDocType.DataTextField = "DocDesc";
            ddlDocType.DataValueField = "DocTypeID";
            ddlDocType.Items.Insert(0, "-Select-");
            ddlDocType.DataBind();
        }

    }


    public void clearSearch()
    {
        lblPlotHolderName.Text = "";
        lblPlotNo.Text = "";
        lblSchName.Text = "";
        txtServiceNo.Text = "";
        txtServiceNo.Enabled = true;

    }
    void SetMessage(string Message, bool Issuccess)
    {

        IdaCustomAlert.Visible = true;

        IdaCustomAlert.Attributes.Remove("class");
        if (Issuccess)
        {

            IdaCustomAlert.Attributes.Add("class", "IdaCustomAlert success");
        }
        else
        {

            IdaCustomAlert.Attributes.Add("class", "IdaCustomAlert failed");
        }
        IdaCustomAlertMsg.InnerHtml = Message;
    }

    int indexCount = 0;
    string Showpath = string.Empty;
    int ErrorlineNo = 0;
    string _ext = string.Empty;
    BL_ImageCrop objbl = new BL_ImageCrop();
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtServiceNo.Text == "")
            {
                //ErrorDiv.Style.Add("display", "block");
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
                            //ErrorDiv.Style.Add("display", "block");
                            //ErrorMsg.InnerText = "Entry Not Found";

                        }
                        else
                        {

                            schCode.Value = Convert.ToString(dt.Rows[0]["SchCode"]);
                            lblPlotHolderName.Text = Convert.ToString(dt.Rows[0]["PlotHolderNameE"]);
                            lblPlotNo.Text = Convert.ToString(dt.Rows[0]["PlotNo"]);
                            lblSchName.Text = Convert.ToString(dt.Rows[0]["SchemeName"]);
                            txtServiceNo.Enabled = false;
                            //ErrorDiv.Style.Add("display", "none");
                            //ErrorMsg.InnerText = string.Empty;
                            FillGrid();

                        }
                    }

                }
            }




        }
        catch (Exception ex)
        {
            //FillImageGrid(images);
            //ErrorDiv.Style.Add("display", "block");
            //ErrorMsg.InnerText = ex.Message + " , Image Count : " + indexCount + ", Path : " + Showpath + ", Error Line No. : " + ErrorlineNo;
        }
    }

    void FillGrid()
    {
        string PhyPath = ConfigurationManager.AppSettings["rowImagePhysicalPath"].ToString() + "\\" + schCode.Value + "\\";//plImagePath.ImagePathDT.Rows[2]["ImagePath"].ToString() + ddlSchemeName.SelectedValue + "//";// +ddlSubSectionName.SelectedValue + "//";
        string path = ConfigurationManager.AppSettings["rowImageVirtualPath"].ToString() + "\\" + schCode.Value + "\\";//plImagePath.ImagePathDT.Rows[0]["ImagePath"].ToString() + ddlSchemeName.SelectedValue + "//";// +ddlSubSectionName.SelectedValue + "//";

        ////_fileNo = ddlFileTrackNo.SelectedItem.Text;
        string[] filesindirectory = Directory.GetFiles(PhyPath, "" + txtServiceNo.Text.Trim() + "*");

        indexCount = filesindirectory.Count();
        Showpath = PhyPath;
        if (filesindirectory.Count() > 0)
        {
            MainImgDiv.Style.Add("display", "block");

            images = new List<ImageDetail>();
            string fileName = string.Empty;
            foreach (string item in filesindirectory)
            {
                _ext = System.IO.Path.GetExtension(item);
                if (_ext == ".jpg" || _ext == ".JPG" || _ext == ".jpeg" || _ext == ".JPEG" || _ext == ".png" || _ext == ".PNG")
                {
                    Showpath = item.ToString();
                    fileName = string.Empty;
                    fileName = System.IO.Path.GetFileName(item);
                    string[] splitFileName = fileName.Split('_');
                    string[] indexing = splitFileName[1].Split('.');
                    if (splitFileName[0].ToString() == txtServiceNo.Text.Trim())
                    {
                        images.Add(new ImageDetail()
                        {
                            ImageID = "box-img" + Convert.ToInt32(indexing[0].ToString()),
                            Index = Convert.ToInt32(indexing[0].ToString()),
                            ImagePath = path + fileName,
                            OrignalImgPath = item.ToString()
                        });
                    }
                }
                ErrorlineNo++;
            }
            //  ViewState["SList"] = images;
            gvThumbnail.DataSource = images;
            gvThumbnail.DataBind();
            // FillImageGrid(images);
        }
        else
        {
            gvThumbnail.DataSource = null;
            gvThumbnail.DataBind();
            MainImgDiv.Style.Add("display", "none");
            SetMessage("There is no images of this Service Number.", false);
            // ErrorDiv.Style.Add("display", "block");
            // ErrorMsg.InnerText = "There is no images of this Service Number.";

        }
    }

    //private void FillImageGrid(List<ImageDetail> images)
    //{
    //        i = 0;
    //        i = images.Count();
    //        j = i;

    //        gvThumbnail.DataSource = images;
    //        gvThumbnail.DataBind();

    //        hfImageCount.Value = i.ToString();
    //        if (images.Count > 0)
    //        {
    //            MainImgDiv.Style.Add("display", "block");
    //        }
    //        else
    //        {
    //            ErrorDiv.Style.Add("display", "block");
    //            ErrorMsg.InnerText = "There is no images of this File Track Number.";
    //            //ddlFileTrackNo.SelectedIndex = 0;
    //            //ddlSectionName.Items.Clear();
    //            //ddlSubSectionName.Items.Clear();
    //            //ddlFileTrackNo.Focus();
    //        }
    //        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Slider", "<script type='text/javascript'>Slider();</script>", false);
    //        //ViewState["SList"] = new List<ImageDetail>(images);
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string TargetPath = string.Empty;
        string FileMoveblePath = string.Empty;
        string SourcePath = string.Empty;

        IdaCustomAlert.Visible = false;
        IdaCustomAlertMsg.InnerText = string.Empty;

        // ErrorDiv.Style.Add("display", "none");
        // ErrorMsg.InnerText = string.Empty;


        if (ddlDocType.SelectedIndex == 0)
        {
            //   ErrorDiv.Style.Add("display", "block");
            //   ErrorMsg.InnerText = "Documnet Type is required.";
            ddlDocType.Focus();
            return;
        }
        else
        {
            // ErrorDiv.Style.Add("display", "none");
            // ErrorMsg.InnerText = string.Empty;



            FileMoveblePath = ConfigurationManager.AppSettings["FinalImagePhysicalPath"].ToString() + "\\" + schCode.Value + "\\"; // plImagePath.ImagePathDT.Rows[1]["ImagePath"].ToString() + ddlSchemeName.SelectedValue + "//";

            if (!Directory.Exists(FileMoveblePath))
            {
                Directory.CreateDirectory(FileMoveblePath);
            }
            int i = 0;
            imagesList = new List<ImageDetail>();
            // imagesList = (List<ImageDetail>)ViewState["SList"];
            for (i = 0; i < gvThumbnail.Rows.Count; i++)
            {
                CheckBox chkImgGrid = (CheckBox)gvThumbnail.Rows[i].FindControl("chkImg");
                if (chkImgGrid.Checked == true)
                {
                    HiddenField hfOrignalPathGrid = (HiddenField)gvThumbnail.Rows[i].FindControl("hfOrignalPath");
                    //HiddenField hfTempImgPathGrid = (HiddenField)gvThumbnail.Rows[i].FindControl("hfTempImgPath");hfIndex
                    HiddenField hfIndexGrid = (HiddenField)gvThumbnail.Rows[i].FindControl("hfIndex");
                    string OrignalfileName = System.IO.Path.GetFileName(hfOrignalPathGrid.Value);
                    string[] splitFileName = OrignalfileName.Split('.');

                    string TempfileName = splitFileName[0] + "_" + ddlDocType.SelectedValue + "." + splitFileName[1];
                    TargetPath = FileMoveblePath + TempfileName;

                    if (File.Exists(TargetPath))
                    {
                        //ErrorDiv.Style.Add("display", "block");
                        //ErrorMsg.InnerText = "Image already exist in the folder.";
                        return;
                    }
                    else
                    {
                        //var itemToRemove = imagesList.Single(r => r.Index == Convert.ToInt32(hfIndexGrid.Value));
                        //imagesList.Remove(itemToRemove);
                        File.Move(hfOrignalPathGrid.Value, TargetPath);

                    }
                }
                else
                {
                    //break;
                }
            }
            FillGrid();
            //if(imagesList.Count <= 0)
            //{
            //    MainImgDiv.Style.Add("display", "none");
            //}
            ddlDocType.SelectedIndex = 0;
            SetMessage("File Moved Successfully.", true);
            //IdaCustomAlert.Style.Add("display", "block");
            //IdaCustomAlertMsg.InnerText = "File Moved Successfully.";
        }
    }

    private void ClearAllFields()
    {
        //  SelectedImgDiv.InnerHtml = "";
        imagesList = null;
        //ddlFileTrackNo.SelectedIndex = 0;
        //ddlSectionName.Items.Clear();
        //ddlSubSectionName.Items.Clear();
        //ddlSchemeName.Items.Clear();
        ddlDocType.SelectedIndex = 0;
        MainImgDiv.Style.Add("display", "none");

        IdaCustomAlert.Visible = false;
        IdaCustomAlertMsg.InnerText = string.Empty;

        //  ErrorDiv.Style.Add("display", "none");
        //  ErrorDiv.InnerText = string.Empty;
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearAllFields();
    }

    protected void btnClearsearch_Click(object sender, EventArgs e)
    {
        clearSearch();
        btnClear_Click(sender, e);
    }
}

public class ImageDetail
{
    public int Index { get; set; }
    public string ImageID { get; set; }
    public string ImagePath { get; set; }
    public string OrignalImgPath { get; set; }
}

