using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_frm_RegisterComplain : System.Web.UI.Page
{
    HttpClient HClient = new HttpClient();  
    PL_RegisterComplain objpl = new PL_RegisterComplain();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["InwardType"] != null)
            {
                Fillddl(Request.QueryString["InwardType"].ToString());
            }
            else
            {

                Response.Redirect("~/FrontOffice/Administrator/frm_InwardApplication.aspx");
               
            }

        }

    }

    public void Fillddl(string InwardType)
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/RegisterComplain/Fillddl?Ind=1");
        if (ds != null)
        {

            ddlInwardType.DataSource = ds.Tables[0];
            ddlInwardType.DataValueField = "LetterCateCode";
            ddlInwardType.DataTextField = "LettercateDescE";
            ddlInwardType.DataBind();
            ddlInwardType.Items.Insert(0, new ListItem("--Select Inward Type--", "0"));
            ddlInwardType.SelectedValue = InwardType;


            ddlDepartment.DataSource = ds.Tables[1];
            ddlDepartment.DataValueField = "DepartCode";
            ddlDepartment.DataTextField = "DepartNameE";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("--Select Department Name--", "0"));

            ddlSearchScheme.DataSource = ds.Tables[2];
            ddlSearchScheme.DataValueField = "SchCode";
            ddlSearchScheme.DataTextField = "SchNameE";
            ddlSearchScheme.DataBind();
            ddlSearchScheme.Items.Insert(0, new ListItem("--Select Scheme Name--", "0"));

            ddlScheme.DataSource = ds.Tables[2];
            ddlScheme.DataValueField = "SchCode";
            ddlScheme.DataTextField = "SchNameE";
            ddlScheme.DataBind();
            ddlScheme.Items.Insert(0, new ListItem("--Select Scheme Name--", "0"));
        }
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlServices();
        FillddlMatter();
        GetDocuments();
    }
    public void FillddlServices()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/RegisterComplain/FillddlService?Ind=2&DepartmentCode=" + ddlDepartment.SelectedValue + "");
        ddlServices.DataSource = ds.Tables[0];
        ddlServices.DataValueField = "ServiceCode";
        ddlServices.DataTextField = "ServiceDescE";
        ddlServices.DataBind();
        ddlServices.Items.Insert(0, new ListItem("--Select Service--", "0"));
    }

    protected void ddlServices_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlMatter();
        GetDocuments();

    }
    public void FillddlMatter()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/RegisterComplain/FillddlMatter?Ind=3&ServiceCode=" + ddlServices.SelectedValue + "");
        ddlMatter.DataSource = ds.Tables[0];
        ddlMatter.DataValueField = "MatterCode";
        ddlMatter.DataTextField = "MatterDescE";
        ddlMatter.DataBind();
        ddlMatter.Items.Insert(0, new ListItem("--Select Matter--", "0"));
    }

    public void GetDocuments()
    {
        DataSet ds = FO_CLSCommon.CallApiGet("api/RegisterComplain/GetDocuments?Ind=4&MatterCode=" + ddlMatter.SelectedValue + "");
        if (ddlMatter.SelectedValue != "0")
        {
            grdDocuments.DataSource = ds.Tables[0];
            grdDocuments.DataBind();
            pnldocuments.Attributes.Add("style", "display:block");
            //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "chk();", true);

        }
        else
        {
            grdDocuments.DataSource = ds.Tables[0];
            grdDocuments.DataBind();
            pnldocuments.Attributes.Add("style", "display:none");
        }

    }
    protected void ddlMatter_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDocuments();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        int SearchRefno = 0;
        if (txtSearchRefNo.Text != "")
        {
            SearchRefno = Convert.ToInt32(txtSearchRefNo.Text.Trim());
        }

        DataSet ds = FO_CLSCommon.CallApiGet("api/RegisterComplain/GetSearch?Ind=5&RefNo=" + SearchRefno + "&SchCode=" + ddlSearchScheme.SelectedValue + "&PlotNo=" + txtSearchPlotNo.Text.Trim() + " ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtRefNo.Text = ds.Tables[0].Rows[0]["RefNo"].ToString();
            txtServiceNo.Text = ds.Tables[0].Rows[0]["ServiceNo"].ToString();
            txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
            txtPropPlaceHolder.Text = ds.Tables[0].Rows[0]["PlotHolderNameE"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["Schemecode"].ToString();
        }
        else
        {

            lblmsg.Text = "No record Found ";
            txtRefNo.Text = "";
            txtServiceNo.Text = "";
            txtPlotNo.Text = "";
            txtPropPlaceHolder.Text = "";
            txtAddress.Text = "";
            ddlScheme.SelectedValue = "0";

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedValue == "0")
        {
            pnlfailed.InnerText = "department se";
            pnlfailed.Style.Add("Display", "block");
            return;
        }

        string ImageUrl = ConfigurationManager.AppSettings["ImageUrl"].ToString();
        string PhotoName = "";
        string PhotoPhysicalpath = "";
        string Photohttppath = "";
        string photoExt = "";
        if (fuPicture.FileName != "")
        {
            photoExt = System.IO.Path.GetExtension(this.fuPicture.PostedFile.FileName);
            if (photoExt != ".jpg" && photoExt != ".png" && photoExt != ".jpeg")
            {
                pnlfailed.InnerHtml = "Please  choose only .jpg, .png and .jpeg image types ";
                pnlfailed.Style.Add("display", "inline-block");
                return;
            }
            PhotoName = Path.GetFileNameWithoutExtension(fuPicture.PostedFile.FileName);
            //fuPicture.PostedFile.SaveAs(Server.MapPath("~/Photos/") + PhotoName);
            PhotoPhysicalpath = "FrontOffice/Photos/" + PhotoName;
            Photohttppath = ImageUrl + "FrontOffice/Photos/" + PhotoName;
                //HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Photos/" + PhotoName;
        }

        List<Imagefile> Images = new List<Imagefile> { };

        DataTable Dtdocs = new DataTable();
        Dtdocs.Columns.Add("DocumentCode");
        Dtdocs.Columns.Add("DocumentAttachInd");
        Dtdocs.Columns.Add("DocumentPhysicalpath");
        Dtdocs.Columns.Add("DocumentHttppath");
        Dtdocs.Columns.Add("DocumentExt");
        for (int i = 0; i < grdDocuments.Rows.Count; i++)
        {
            DataRow dr = Dtdocs.NewRow();
            int Documentcode = Convert.ToInt32(((HiddenField)grdDocuments.Rows[i].FindControl("hdnDocumentcode")).Value);
            int Attachind = Convert.ToInt32(((HiddenField)grdDocuments.Rows[i].FindControl("hdnStatus")).Value);
            string DocBase64string = ((HiddenField)grdDocuments.Rows[i].FindControl("hdnimg")).Value;
            if (DocBase64string != "")
            {
                string filename = txtServiceNo.Text + "-" + Documentcode;
                Images = new List<Imagefile>{
                   new Imagefile(){ImageFileName=filename,Base64Str=DocBase64string }
                };

                string docPhysicalpath = "FrontOffice/Documents/" + filename;
                string dochttppath = ImageUrl + "FrontOffice/Documents/" + filename;
                    //HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Documents/" + filename;
                dr["DocumentCode"] = Documentcode;
                dr["DocumentAttachInd"] = Attachind;
                dr["DocumentPhysicalpath"] = docPhysicalpath;
                dr["DocumentHttppath"] = dochttppath;
                dr["DocumentExt"] = ".png";
            }
            else
            {
                dr["DocumentCode"] = Documentcode;
                dr["DocumentAttachInd"] = Attachind;
                dr["DocumentPhysicalpath"] = "";
                dr["DocumentHttppath"] = "";
                dr["DocumentExt"] = "";
            }
            Dtdocs.Rows.Add(dr);
        }

        objpl.Ind = 6;
        objpl.DepartmentCode = Convert.ToInt32(ddlDepartment.SelectedValue);
        objpl.SchemeCode = Convert.ToInt32(ddlScheme.SelectedValue);
        objpl.PlotNo = txtPlotNo.Text.Trim();
        objpl.IdaRefNo = Convert.ToInt32(txtRefNo.Text.Trim());
        objpl.InwardType = Convert.ToInt32(ddlInwardType.SelectedValue);
        objpl.ServiceNo = Convert.ToInt32(txtServiceNo.Text.Trim());
        objpl.ServiceCode = Convert.ToInt32(ddlServices.SelectedValue);
        objpl.ServiceMatterCode = Convert.ToInt32(ddlMatter.SelectedValue);
        objpl.ComplainerName = txtComplainer.Text.Trim();
        objpl.MobileNo = txtMobileNo.Text.Trim();
        objpl.AadhaarNo = txtAadharNo.Text.Trim();
        objpl.PhotoPhysicalPath = PhotoPhysicalpath;
        objpl.PhotoHttpPath = Photohttppath;
        objpl.PhotoExt = photoExt;
        objpl.AllDocAttach = 0;
        objpl.EntryUserCode = 1;
        objpl.Remark = txtOtherRemark.Text.Trim();
        objpl.Dtdocs = Dtdocs;
        DataTable dt = FO_CLSCommon.CallApiPost("api/RegisterComplain/SaveInwardData", objpl);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["res"].ToString() == "1")
            {
                if (PhotoName != "")
                {
                    fuPicture.PostedFile.SaveAs(Server.MapPath("~/FrontOffice/Photos/" + PhotoName + "-" + dt.Rows[0]["InwardNo"].ToString() + photoExt));
                }
                foreach (Imagefile img in Images)
                {
                    File.WriteAllBytes(Server.MapPath("~/FrontOffice/Documents/" + img.ImageFileName + "-" + dt.Rows[0]["InwardNo"].ToString() + ".png"), Convert.FromBase64String(img.Base64Str));
                }

                pnlSuccess.InnerHtml = "Save Successfully.";
                Clear();
                pnlSuccess.Style.Add("display", "inline-block");
                pnlfailed.Style.Add("display", "none");

            }
            else
            {
                pnlfailed.InnerHtml = "Data Failed...";

                pnlSuccess.Style.Add("display", "none");
                pnlfailed.Style.Add("display", "inline-block");
            }
        }

    }
    protected void btnSearchClear_Click(object sender, EventArgs e)
    {
        ddlSearchScheme.SelectedValue = "0";
        txtSearchPlotNo.Text = "";
        txtSearchRefNo.Text = "";

    }



    public void Clear()
    {
        ddlDepartment.SelectedValue = "0";
        //ddlInwardType.SelectedValue = "0";
        //ddlSearchScheme.SelectedValue = "0";
        FillddlServices();
        ddlServices.SelectedValue = "0";
        FillddlMatter();
        ddlMatter.SelectedValue = "0";
        GetDocuments();

        txtRefNo.Text = "";
        txtServiceNo.Text = "";
        txtPlotNo.Text = "";
        txtPropPlaceHolder.Text = "";
        txtAddress.Text = "";
        ddlScheme.SelectedValue = "0";


        ddlMatter.SelectedValue = "0";
        txtComplainer.Text = "";
        txtMobileNo.Text = "";
        txtAadharNo.Text = "";
        txtOtherRemark.Text = "";

        ddlSearchScheme.SelectedValue = "0";
        txtSearchPlotNo.Text = "";
        txtSearchRefNo.Text = "";

    }


    //for (int i = 0; i < grdDocuments.Rows.Count; i++)
    //    {
    //        string DocBase64string = ((HiddenField)grdDocuments.Rows[i].FindControl("hdnimg")).Value;
    //        string DocPhypath ="~/Documents/scan" + i + ".png";
    //        HttpClient HClient = new HttpClient();
    //        HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString());

    //    http://localhost:61096/Documents/
    //        string dochttppath = HClient.BaseAddress + "/Documents/scan" + i + ".png";
    //            string a= Request.Url.AbsoluteUri + "~/Documents/scan" + i+".png"; ;
    //        File.WriteAllBytes(Server.MapPath("~/Documents/scan" + i + ".png"), Convert.FromBase64String(DocBase64string));

    //    }
}

class Imagefile
{
    // Auto-implemented properties.
    public string ImageFileName { get; set; }
    public string Base64Str { get; set; }




}

