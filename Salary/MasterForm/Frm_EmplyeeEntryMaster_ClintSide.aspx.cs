using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterForm_Frm_EmplyeeEntryMaster : System.Web.UI.Page
{
    DataSet ds;
    DataTable dt;
    PL_EmpMaster plobj;
    DataTable dtGvomnee = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CityCode"] = 1001001;
        Session["Month"] = "012018";
        Session["UserId"] = 101;

        if (!IsPostBack)
        {
            BindAllDropDown();
        }
    }


    void BindAllDropDown()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("EmployeeMaster/BindAll?Ind=1");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlEmpType.DataSource = ds.Tables[0];
                    ddlEmpType.DataTextField = "Desc1";
                    ddlEmpType.DataValueField = "EmpType";
                    ddlEmpType.DataBind();
                    ddlEmpType.Items.Insert(0, new ListItem("-- Select Employee Type --- ", "0"));
                }
                else
                {
                    ddlEmpType.Items.Insert(0, new ListItem("-- Select Employee Type --- ", "0"));
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlEmpCtg.DataSource = ds.Tables[1];
                    ddlEmpCtg.DataTextField = "SalaryTypeDesc";
                    ddlEmpCtg.DataValueField = "SalaryTypeInd";
                    ddlEmpCtg.DataBind();
                    ddlEmpCtg.Items.Insert(0, new ListItem("-- Select Employee Category --- ", "0"));
                }
                else
                {
                    ddlEmpCtg.Items.Insert(0, new ListItem("-- Select Employee Category --- ", "0"));
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlSubSection.DataSource = ds.Tables[2];
                    ddlSubSection.DataTextField = "SubSectionName";
                    ddlSubSection.DataValueField = "SubSectionId";
                    ddlSubSection.DataBind();
                    ddlSubSection.Items.Insert(0, new ListItem("-- Select Sub Section --- ", "0"));
                }
                else
                {
                    ddlSubSection.Items.Insert(0, new ListItem("-- Select Sub Section --- ", "0"));
                }


                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlDesignation.DataSource = ds.Tables[3];
                    ddlDesignation.DataTextField = "DesgDesc";
                    ddlDesignation.DataValueField = "DesgCd";
                    ddlDesignation.DataBind();
                    ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation--- ", "0"));
                }
                else
                {
                    ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation--- ", "0"));
                }


                if (ds.Tables[4].Rows.Count > 0)
                {
                    ddlCastCtg.DataSource = ds.Tables[4];
                    ddlCastCtg.DataTextField = "CatgDesc";
                    ddlCastCtg.DataValueField = "CatgID";
                    ddlCastCtg.DataBind();
                    ddlCastCtg.Items.Insert(0, new ListItem("-- Select Category --- ", "0"));
                }
                else
                {
                    ddlCastCtg.Items.Insert(0, new ListItem("-- Select Category --- ", "0"));
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    ddlQualification.DataSource = ds.Tables[5];
                    ddlQualification.DataTextField = "Qualification";
                    ddlQualification.DataValueField = "QualiId";
                    ddlQualification.DataBind();
                    ddlQualification.Items.Insert(0, new ListItem("-- Select Qualification --- ", "0"));
                }
                else
                {
                    ddlQualification.Items.Insert(0, new ListItem("-- Select Qualification --- ", "0"));
                }

                if (ds.Tables[6].Rows.Count > 0)
                {
                    ddlBank.DataSource = ds.Tables[6];
                    ddlBank.DataTextField = "BankName";
                    ddlBank.DataValueField = "BnkCd";
                    ddlBank.DataBind();
                    ddlBank.Items.Insert(0, new ListItem("-- Select Bank --- ", "0"));

                    ViewState["VS_BankTable"] = ds.Tables[6];
                }
                else
                {
                    ddlBank.Items.Insert(0, new ListItem("-- Select Bank --- ", "0"));
                }


                if (ds.Tables[7].Rows.Count > 0)
                {
                    ddlGrade.DataSource = ds.Tables[7];
                    ddlGrade.DataTextField = "GrdDesc";
                    ddlGrade.DataValueField = "GrdCd";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, new ListItem("-- Select Grade --- ", "000"));
                }
                else
                {
                    ddlGrade.Items.Insert(0, new ListItem("-- Select Grade --- ", "000"));
                }

                if (ds.Tables[8].Rows.Count > 0)
                {
                    ddlRelation_Nom.DataSource = ds.Tables[8];
                    ddlRelation_Nom.DataTextField = "Relation";
                    ddlRelation_Nom.DataValueField = "RelationCd";
                    ddlRelation_Nom.DataBind();
                    ddlRelation_Nom.Items.Insert(0, new ListItem("-- Select Relation --- ", "0"));
                }
                else
                {
                    ddlRelation_Nom.Items.Insert(0, new ListItem("-- Select Relation --- ", "0"));
                }

                if (ds.Tables[9].Rows.Count > 0)
                {
                    ddlTitalE.DataSource = ds.Tables[9];
                    ddlTitalE.DataTextField = "titalNameEnglish";
                    ddlTitalE.DataValueField = "titalCode";
                    ddlTitalE.DataBind();
                    ddlTitalE.Items.Insert(0, new ListItem("-Select- ", "0"));

                    ddlTitalH.DataSource = ds.Tables[9];
                    ddlTitalH.DataTextField = "titalNameHindi";
                    ddlTitalH.DataValueField = "titalCode";
                    ddlTitalH.DataBind();
                    ddlTitalH.Items.Insert(0, new ListItem("-Select- ", "0"));
                }
                else
                {
                    ddlTitalE.Items.Insert(0, new ListItem("-Select- ", "0"));
                    ddlTitalH.Items.Insert(0, new ListItem("-Select- ", "0"));
                }
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        //if (Regex.IsMatch(txtDepuDate.Text, "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
        //{
        //    lblMsg.Text = "Invalid Date Format";
        //    return;
        //}

        
        btnSave.Enabled = false;
        plobj = new PL_EmpMaster();
        plobj.Ind = 2;
        plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        plobj.FormNo = 0;
        plobj.Zone = 0;
        plobj.WardNo = 0;
        plobj.Empno = 0;
        plobj.Sex = Convert.ToInt32(ddlGender.SelectedValue);
        plobj.EmpType = Convert.ToInt32(ddlEmpType.SelectedValue);
        plobj.SalaryTypeInd = Convert.ToInt32(ddlEmpCtg.SelectedValue);
        plobj.Init = ddlTitalE.SelectedValue;
        plobj.LastUpdDt = "";
        plobj.FirstName = txtFirstName.Text.Trim();
        plobj.LastName = txtLastName.Text.Trim();
        plobj.FHName = txtFname.Text.Trim();
        plobj.FirstNameH = txtFirstNameH.Text.Trim();
        plobj.LastNameH = txtLastNameH.Text.Trim();
        plobj.FhnameH = txtFnameH.Text.Trim();
        plobj.NomineeName = "";
        plobj.NomineeRel = "";
        plobj.NomineePer = 0;
        plobj.GPFNomineeName = "";
        plobj.GPFNomineeRel = "";
        plobj.GPFNomineePer = 0;
        plobj.RefNo = "";
        plobj.SrNo = 0;
        plobj.SubSrNo = "";
        plobj.DesgCd = Convert.ToInt32(ddlDesignation.SelectedValue);
        plobj.GrdCd = Convert.ToInt32(ddlGrade.SelectedValue);
        plobj.DeptCd1 = 0;
        plobj.DeptCd2 = 0;

        plobj.ClassInd = Convert.ToInt32(hflblClassId.Value);

        plobj.aadhaarno = txtAadhaarNo.Text.Trim() == "" ? 0 : Convert.ToInt64(txtAadhaarNo.Text.Trim());
        plobj.VoterId = (txtVoterId.Text.Trim());
        plobj.Ctg = ddlCastCtg.SelectedValue;
        plobj.Dob = txtBirthDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtBirthDate.Text);
        plobj.Doj = txtJoiningDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtJoiningDate.Text);
        plobj.Doc = txtConfiromDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtConfiromDate.Text);
        plobj.Dop = "";
        plobj.IncrDt = txtBasicIncDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtBasicIncDate.Text);
        plobj.IstIncremtDesg = "0";
        plobj.IncrDueDt = "";
        plobj.Add1 = txtPermanentAdd.Text.Trim();
        plobj.Add2 = txtPrsentAdd.Text.Trim();
        plobj.Place1 = txtPermanentPlace.Text.Trim();
        plobj.Place2 = txtPrsentPlace.Text.Trim();
        plobj.Phone1 = txtPermanentMobileNo.Text.Trim();
        plobj.Phone2 = txtPrsentMobileNo.Text.Trim();
        plobj.BnkCd = Convert.ToInt32(ddlBank.SelectedValue);
        plobj.BrCd = ddlBranch.SelectedValue == "" ? 0 : Convert.ToInt32(ddlBranch.SelectedValue);
        plobj.BnkAcNo = txtBankAcNo.Text.Trim();
        plobj.IFSCCODE = txtIFSCCode.Text.Trim();
        plobj.MStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
        plobj.FamPlan = Convert.ToInt32(ddlFamilyPlaning.SelectedValue);
        plobj.NoOfChild = 0;
        plobj.FemalChild = 0;
        plobj.BGroup = ddlBloodGroup.SelectedValue;
        plobj.Handicapped = Convert.ToInt32(ddlHandicapped.SelectedValue);
        plobj.HandiPercent = txtHandPercentage.Text == "" ? 0 : Convert.ToInt32(txtHandPercentage.Text.Trim());
        plobj.Deputation = Convert.ToInt32(ddlDeputation.SelectedValue);
        plobj.DepuDt = txtDepuDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtDepuDate.Text);
        plobj.RrdtInd = 0;
        plobj.RrdtDt = "";
        plobj.GpfAcNo = txtGPFAco.Text.Trim();
        plobj.ESICAcNo = txtESICACNo.Text.Trim();
        plobj.UANNO = txtUANNo.Text.Trim();
        plobj.Qualification = ddlQualification.SelectedValue;
        plobj.Basic = Convert.ToInt64(txtBasic.Text.Trim());
        plobj.SupRetDt = lblRetirmentDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(lblRetirmentDate.Text);
        plobj.Month = (Session["Month"]).ToString();
        plobj.NoPtax = 0;
        plobj.NoGpf = 0;
        plobj.AddlGpf = 0;
        plobj.GpfLpDt = 0;
        plobj.GpfRefNo = "";
        plobj.Schno = 0;
        plobj.SubSchno = 0;
        plobj.RecordNo = 0;
        plobj.OldPay = 0;
        plobj.FesInd = 0;
        plobj.GrihaJila = "";
        plobj.DepuFrom = txtDepuDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtDepuDate.Text);
        plobj.PayBillNo = 0;
        plobj.QualifiDetail = "";
        plobj.DeputationPlace = txtDepuPlace.Text.Trim();
        plobj.PanNo = txtPanNo.Text.Trim();
        plobj.PrivilegeLeave = txtTotalPvlLeave.Text.Trim() == "" ? 0 : Convert.ToInt32(txtTotalPvlLeave.Text.Trim());
        plobj.HafePayLeave = txtTotalHalfPayLeve.Text.Trim() == "" ? 0 : Convert.ToInt32(txtTotalHalfPayLeve.Text.Trim());
        plobj.AditionalInfor = "";
        plobj.ApplicationDate = "";
        plobj.BasicIncrDt = txtBasicIncDate.Text == "" ? "" : Salary_CLSCommon.ConvertToDate(txtBasicIncDate.Text);
        plobj.FixPay = Convert.ToInt32(rbFixPayee.SelectedValue);
        plobj.PF12 = 0;
        plobj.GPFIND = 0;
        plobj.Pfind = 0;
        plobj.FPFind = 0;
        plobj.AdminChargeind = 0;
        plobj.PFhigpen = 0;
        if (gvNomnee.Rows.Count > 0)
        {
            plobj.dtTemp = (DataTable)ViewState["dtGvNomnee"];
        }
        else
        {
            plobj.dtTemp = CreatNomneeGrid();
        }


        DataTable dt = new DataTable();
        dt = Salary_CLSCommon.ApiPostDataTable("EmployeeMaster/SaveAllInformation", plobj);
        if (dt.Rows.Count > 0)
        {
            Bank_info.Attributes.Add("class", "panel-collapse collapse");
            Nominee.Attributes.Add("class", "panel-collapse collapse");
            other_info.Attributes.Add("class", "panel-collapse collapse");

            if (dt.Rows[0][0].ToString() == "Save")
            {
                lblMsg.Text = "Record Save Successfully..!!!";
                lblMsg.CssClass = "alertMsg success";
                ClearAllPageControll();
                // Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                lblMsg.Text = "Recored Not Save";
                lblMsg.CssClass = "alertMsg failed";
            }
        }
        else
        {
            lblMsg.Text = "Recored Not Save";
            lblMsg.CssClass = "alertMsg failed";
        }

    }
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbFixPayee.SelectedValue == "1")
        {
            ddlGrade.Enabled = false;
        }
        else
        {
            ddlGrade.Enabled = true;
        }
        if (ddlBank.SelectedValue != "0")
        {
            DataTable dt_BankTable = (DataTable)ViewState["VS_BankTable"];
            DataRow[] dr = dt_BankTable.Select("BnkCd=" + ddlBank.SelectedValue.ToString());
            DataTable BranchTable = dr.CopyToDataTable();

            if (BranchTable.Rows.Count > 0)
            {
                ddlBranch.DataSource = BranchTable;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BrCd";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));

                ddlBranch.Enabled = true;
                txtBankAcNo.Enabled = true;
                txtIFSCCode.Enabled = true;

            }
            else
            {
                ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));
                ddlBranch.Enabled = false;
                txtBankAcNo.Enabled = false;
                txtIFSCCode.Enabled = false;
            }
        }
        else
        {
            ddlBranch.Items.Clear();
            ddlBranch.Enabled = false;
            txtBankAcNo.Enabled = false;
            txtIFSCCode.Enabled = false;
        }
        //  ddlBranch.Focus();
        Bank_info.Attributes.Add("class", "panel-collapse collapse in");
    }

    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbFixPayee.SelectedValue == "1")
        {
            ddlGrade.Enabled = false;
        }
        else
        {
            ddlGrade.Enabled = true;
        }
        //if (txtPermanentAdd.Text.ToString() == txtPrsentAdd.Text.ToString() && txtPermanentMobileNo.Text == txtPrsentMobileNo.Text && txtPrsentPlace.Text == txtPermanentPlace.Text)
        //{
        //    chkPermanentSame.Checked = true;
        //}

        if (Convert.ToInt32(ddlDesignation.SelectedValue) != 0)
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillClassDesc?Ind=3&DesgCd=" + ddlDesignation.SelectedValue + "");
            if (dt.Rows.Count > 0)
            {
                lblClassDesc.Text = dt.Rows[0]["ClassDesc"].ToString();
                hflblClassId.Value = dt.Rows[0]["Classind"].ToString();
                hfRetirmentYear.Value = dt.Rows[0]["RetirementAge"].ToString();
            }
            else
            {
                lblClassDesc.Text = "";
                hflblClassId.Value = "0";
                hfRetirmentYear.Value = "0";
            }
        }
        else
        {
            lblClassDesc.Text = "";
            hflblClassId.Value = "0";
            hfRetirmentYear.Value = "0";
        }
        // rbFixPayee.Focus();
    }


    DataTable VsdtNomneeDetails
    {
        get { return (DataTable)ViewState["dtGvNomnee"]; }
        set { ViewState["dtGvNomnee"] = value; }
    }

    DataTable CreatNomneeGrid()
    {
        DataTable gvNom = new DataTable();
        //gvNom.Columns.Add("NomneeTypeId", typeof(int));
        //gvNom.Columns.Add("NomneeTypeDesc", typeof(string));
        gvNom.Columns.Add("NomneeName", typeof(string));
        gvNom.Columns.Add("NomneeRelationId", typeof(int));
        gvNom.Columns.Add("NomneeRelationDesc", typeof(string));
        gvNom.Columns.Add("NomneeParsentage", typeof(int));
        return gvNom;
    }

    void BindGvItemDetail()
    {

        if (VsdtNomneeDetails == null)
        {
            dtGvomnee = CreatNomneeGrid();
        }
        else
        {
            dtGvomnee = VsdtNomneeDetails;
            ViewState["dtGvNomnee"] = dtGvomnee;
        }

        DataRow dr = dtGvomnee.NewRow();
        //dr["NomneeTypeId"] = ddlNomineeType_Nom.SelectedValue;
        //dr["NomneeTypeDesc"] = ddlNomineeType_Nom.SelectedItem.Text;
        dr["NomneeName"] = txtName_Nom.Text;
        dr["NomneeRelationId"] = ddlRelation_Nom.SelectedValue;
        dr["NomneeRelationDesc"] = ddlRelation_Nom.SelectedItem.Text;
        dr["NomneeParsentage"] = txtPercentage_Nom.Text.Trim();

        dtGvomnee.Rows.Add(dr);
        gvNomnee.DataSource = VsdtNomneeDetails = dtGvomnee;
        gvNomnee.DataBind();
        ViewState["dtGvNomnee"] = dtGvomnee;
    }

    public void ClearAllGridControll()
    {
        gvNomnee.DataSource = null;
        gvNomnee.DataBind();
    }


    public void ClearAllPageControll()
    {
        ddlEmpType.ClearSelection();
        ddlEmpCtg.ClearSelection();
        ddlSubSection.ClearSelection();
        lblSection.Text = "";
        ddlDeputation.ClearSelection();
        txtDepuDate.Text = "";
        txtDepuPlace.Text = "";
        ddlDesignation.ClearSelection();
        lblClassDesc.Text = "";
        hflblClassId.Value = "0";
        rbFixPayee.SelectedValue = "0";
        ddlTitalE.ClearSelection();
        txtFirstName.Text = "";
        ddlTitalH.ClearSelection();
        txtFirstNameH.Text = "";
        txtLastName.Text = "";
        txtLastNameH.Text = "";
        txtFname.Text = "";
        txtFnameH.Text = "";
        ddlGender.ClearSelection();
        ddlCastCtg.ClearSelection();
        ddlQualification.ClearSelection();
        ddlBloodGroup.ClearSelection();
        txtAadhaarNo.Text = "";
        txtVoterId.Text = "";
        ddlMaritalStatus.ClearSelection();
        ddlFamilyPlaning.ClearSelection();
        ddlHandicapped.ClearSelection();
        txtHandPercentage.Text = "";
        txtPermanentAdd.Text = "";
        txtPermanentPlace.Text = "";
        txtPermanentMobileNo.Text = "";
        chkPermanentSame.Checked = false;
        txtPrsentAdd.Text = "";
        txtPrsentPlace.Text = "";
        txtPrsentMobileNo.Text = "";
        ddlBank.ClearSelection();
        ddlBranch.Items.Clear();
        txtBankAcNo.Text = "";
        txtIFSCCode.Text = "";
        txtGPFAco.Text = "";
        txtPanNo.Text = "";
        txtESICACNo.Text = "";
        txtUANNo.Text = "";
        ddlGrade.ClearSelection();
        txtBasic.Text = "";
        txtBirthDate.Text = "";
        txtJoiningDate.Text = "";
        lblRetirmentDate.Text = "";
        txtConfiromDate.Text = "";
        txtBasicIncDate.Text = "";
        txtTotalPvlLeave.Text = "";
        txtTotalHalfPayLeve.Text = "";
        gvNomnee.DataSource = null;
        gvNomnee.DataBind();

    }

    protected void btnAddNomeenee_Click(object sender, EventArgs e)
    {
        if (txtName_Nom.Text.Trim() == "")
        {
            txtName_Nom.Focus();
            lblMsg.Text = "Please Enter Name";
            lblMsg.CssClass = "alertMsg failed";
            Nominee.Attributes.Add("class", "panel-collapse collapse in");
            return;
        }

        BindGvItemDetail();
        ClarNomneeGrid();
        Nominee.Attributes.Add("class", "panel-collapse collapse in");

    }
    public void ClarNomneeGrid()
    {
        //ddlNomineeType_Nom.ClearSelection();
        txtName_Nom.Text = "";
        ddlRelation_Nom.ClearSelection();
        txtPercentage_Nom.Text = "";
    }

    protected void gvNomnee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if ((e.CommandName == "DeleteRow") || (e.CommandName == "Select"))
            {
                dtGvomnee = VsdtNomneeDetails;
                dtGvomnee.Rows[rowIndex].Delete();
                VsdtNomneeDetails = dtGvomnee;
                gvNomnee.DataSource = dtGvomnee;
                gvNomnee.DataBind();
            }

        }
        catch (Exception ex)
        {

        }
        Nominee.Attributes.Add("class", "panel-collapse collapse in");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;

        int rowindex = gvr.RowIndex;
        // Label NomineeType_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeTypeId");
        Label Name_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeName");
        Label Relation_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeRelationId");
        Label Percentage_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeParsentage");

        //  ddlNomineeType_Nom.SelectedValue = NomineeType_Nom.Text;
        txtName_Nom.Text = Name_Nom.Text;
        ddlRelation_Nom.Text = Relation_Nom.Text;
        txtPercentage_Nom.Text = Percentage_Nom.Text;
        hfFocus.Focus();


        Nominee.Attributes.Add("class", "panel-collapse collapse in");
    }

    protected void txtBirthDate_TextChanged(object sender, EventArgs e)
    {
        if (Regex.IsMatch(txtBirthDate.Text, "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
        {
            if (txtBirthDate.Text.Trim() != "")
            {
                string CurrentDate = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0');
                if (Convert.ToDateTime(txtBirthDate.Text.Substring(6, 4) + "/" + txtBirthDate.Text.Substring(3, 2) + "/" + txtBirthDate.Text.Substring(0, 2)) > Convert.ToDateTime(CurrentDate))
                {
                    lblMsg.Text = "Birth Date is not greater than today date ";
                    lblMsg.CssClass = "alertMsg failed";
                    txtBirthDate.Text = "";
                    txtBirthDate.BorderColor = System.Drawing.Color.Red;

                    hfFocus.Focus();
                    return;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    txtBirthDate.BorderColor = System.Drawing.Color.LightGray;
                }
            }
        }
        other_info.Attributes.Add("class", "panel-collapse collapse in");
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}

