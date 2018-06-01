using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterForm_FrmEdit_EmplyeeEntryMaster : System.Web.UI.Page
{
    DataSet ds;
    DataTable dt;
    PL_EmpMaster plobj;
    DataTable dtGvomnee = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAllDropDown();
        }
    }

    void BindAllDropDown()
    {
        ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("EmployeeMaster/BindAll?Ind=1&CityCode=" + Session["CityCode"] + "");
        if (ds != null)
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
                ddlSubSection.DataTextField = "CCName";
                ddlSubSection.DataValueField = "CCCode";
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

                //ViewState["VS_BankTable"] = ds.Tables[6];
            }

            //if (ds.Tables[6].Rows.Count > 0)
            //{
            //    ddlBranch.DataSource = ds.Tables[6];
            //    ddlBranch.DataTextField = "BranchName";
            //    ddlBranch.DataValueField = "BrCd";
            //    ddlBranch.DataBind();
            //    ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));

            //}
            //else
            //{
            //    ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));
            //}


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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblSearchError.Text = "";
        lblSearchError.CssClass = "";
        txtEmpNo.Enabled = true;
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        if (txtEmpNo.Text.Trim() == "")
        {
            lblSearchError.Text = "Please Enter Employee No. ";
            lblSearchError.CssClass = "alertMsg failed";
            lblSearchError.Visible = true;
            txtEmpNo.Focus();
            txtEmpNo.BorderColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            ds = new DataSet();
            ds = Salary_CLSCommon.CallApiGet("EmployeeMaster/SearchEmpInformation?Ind=4&EmpNo=" + txtEmpNo.Text + "&CityCode=" + Session["CityCode"] + "");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblSearchError.Text = "";
                    lblSearchError.CssClass = "";
                    lblSearchError.Visible = false;
                    pnlGridInfo.Visible = true;
                    txtEmpNo.BorderColor = System.Drawing.Color.LightGray;
                    btnSave.Visible = true;
                    ddlBranch.Enabled = true;
                    txtBankAcNo.Enabled = true;
                    txtIFSCCode.Enabled = true;
                    txtEmpNo.Enabled = false;

                    ddlGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                    ddlEmpType.SelectedValue = ds.Tables[0].Rows[0]["EmpType"].ToString();
                    ddlEmpCtg.SelectedValue = ds.Tables[0].Rows[0]["SalaryTypeInd"].ToString();

                    ddlSubSection.SelectedValue = ds.Tables[0].Rows[0]["CCCode"].ToString();
                    lblSection.Text = ds.Tables[0].Rows[0]["DeptName"].ToString();
                    hfSectionId.Value = ds.Tables[0].Rows[0]["DeptCode"].ToString();


                    ddlTitalE.SelectedValue = ds.Tables[0].Rows[0]["Init"].ToString();
                    ddlTitalH.SelectedValue = ds.Tables[0].Rows[0]["Init"].ToString();
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtFname.Text = ds.Tables[0].Rows[0]["FHName"].ToString();
                    txtFirstNameH.Text = ds.Tables[0].Rows[0]["FirstNameH"].ToString();
                    txtLastNameH.Text = ds.Tables[0].Rows[0]["LastNameH"].ToString();
                    txtFnameH.Text = ds.Tables[0].Rows[0]["FhnameH"].ToString();
                    ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["DesgCd"].ToString();
                    ddlGrade.SelectedValue = ds.Tables[0].Rows[0]["GrdCd"].ToString();
                    hflblClassId.Value = ds.Tables[0].Rows[0]["ClassInd"].ToString();
                    lblClassDesc.Text = ds.Tables[0].Rows[0]["ClassDesc"].ToString();
                    txtAadhaarNo.Text = ds.Tables[0].Rows[0]["aadhaarno"].ToString();
                    txtVoterId.Text = ds.Tables[0].Rows[0]["VoterID"].ToString();
                    ddlCastCtg.SelectedValue = ds.Tables[0].Rows[0]["Ctg"].ToString();
                    txtBirthDate.Text = ds.Tables[0].Rows[0]["Dob"].ToString();
                    txtJoiningDate.Text = ds.Tables[0].Rows[0]["Doj"].ToString();
                    txtConfiromDate.Text = ds.Tables[0].Rows[0]["Doc"].ToString();
                    txtBasicIncDate.Text = ds.Tables[0].Rows[0]["BasicIncrDt"].ToString();
                    txtPermanentAdd.Text = ds.Tables[0].Rows[0]["Add1"].ToString();
                    txtPrsentAdd.Text = ds.Tables[0].Rows[0]["Add2"].ToString();
                    txtPermanentPlace.Text = ds.Tables[0].Rows[0]["Place1"].ToString();
                    txtPrsentPlace.Text = ds.Tables[0].Rows[0]["Place2"].ToString();
                    txtPermanentMobileNo.Text = ds.Tables[0].Rows[0]["Phone1"].ToString();
                    txtPrsentMobileNo.Text = ds.Tables[0].Rows[0]["Phone2"].ToString();
                    ddlBank.SelectedValue = ds.Tables[0].Rows[0]["BnkCd"].ToString();

                    dt = new DataTable();
                    dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillBranchAndIFSC?Ind=8&BankCd=" + ddlBank.SelectedValue + "&BranchCd=0");

                    if (dt.Rows.Count > 0)
                    {
                        ddlBranch.DataSource = dt;
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

                    ddlBranch.SelectedValue = ds.Tables[0].Rows[0]["BrCd"].ToString();

                    txtBankAcNo.Text = ds.Tables[0].Rows[0]["BnkAcNo"].ToString();
                    txtIFSCCode.Text = ds.Tables[0].Rows[0]["IFSCCODE"].ToString();
                    ddlMaritalStatus.SelectedValue = ds.Tables[0].Rows[0]["MStatus"].ToString();
                    ddlFamilyPlaning.SelectedValue = ds.Tables[0].Rows[0]["FamPlan"].ToString();

                    ddlBloodGroup.SelectedValue = ds.Tables[0].Rows[0]["BGroup"] == "" ? "--Select--" : ds.Tables[0].Rows[0]["BGroup"].ToString();
                    ddlHandicapped.SelectedValue = ds.Tables[0].Rows[0]["Handicapped"].ToString();
                    txtHandPercentage.Text = ds.Tables[0].Rows[0]["HandiPercent"].ToString();
                    ddlDeputation.SelectedValue = ds.Tables[0].Rows[0]["Deputation"].ToString();
                    txtDepuDate.Text = ds.Tables[0].Rows[0]["DepuDt"].ToString();
                    txtGPFAco.Text = ds.Tables[0].Rows[0]["GpfAcNo"].ToString();
                    txtESICACNo.Text = ds.Tables[0].Rows[0]["ESICAcNo"].ToString();
                    txtUANNo.Text = ds.Tables[0].Rows[0]["UANNO"].ToString();
                    ddlQualification.SelectedValue = ds.Tables[0].Rows[0]["Qualification"].ToString();
                    txtBasic.Text = ds.Tables[0].Rows[0]["Basic"].ToString();
                    lblRetirmentDate.Text = ds.Tables[0].Rows[0]["SupRetDt"].ToString();
                    txtDepuDate.Text = ds.Tables[0].Rows[0]["DepuFrom"].ToString();
                    txtDepuPlace.Text = ds.Tables[0].Rows[0]["DeputationPlace"].ToString();
                    txtPanNo.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                    txtTotalPvlLeave.Text = ds.Tables[0].Rows[0]["PrivilegeLeave"].ToString();
                    txtTotalHalfPayLeve.Text = ds.Tables[0].Rows[0]["HafePayLeave"].ToString();
                    rbFixPayee.SelectedValue = ds.Tables[0].Rows[0]["FixPay"].ToString();

                    if (rbFixPayee.SelectedValue == "1")//yes
                    {
                        ddlGrade.Enabled = false;
                    }
                    else
                    {
                        ddlGrade.Enabled = true;
                    }
                    if (txtPermanentAdd.Text.ToString() == txtPrsentAdd.Text.ToString() && txtPermanentMobileNo.Text == txtPrsentMobileNo.Text && txtPrsentPlace.Text == txtPermanentPlace.Text)
                    {
                        chkPermanentSame.Checked = true;
                        txtPrsentAdd.Enabled = false;
                        txtPrsentMobileNo.Enabled = false;
                        txtPrsentPlace.Enabled = false;
                    }
                }
                else
                {
                    lblSearchError.Text = "No Record Found..!!! ";
                    lblSearchError.CssClass = "alertMsg failed";
                    txtEmpNo.Focus();
                    // btnSearch.Attributes.Remove("disabled");
                    lblSearchError.Visible = true;
                    pnlGridInfo.Visible = false;
                    btnSave.Visible = false;

                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvNomnee.DataSource = ds.Tables[1];
                gvNomnee.DataBind();
                ViewState["dtGvNomnee"] = ds.Tables[1];
            }
            // For Fill Retirmnet Year Designation Select Index Change
            if (Convert.ToInt32(ddlDesignation.SelectedValue) != 0)
            {
                dt = new DataTable();
                dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillClassDesc?Ind=3&DesgCd=" + ddlDesignation.SelectedValue + "");
                if (dt.Rows.Count > 0)
                {
                    lblClassDesc.Text = dt.Rows[0]["ClassDesc"].ToString();
                    hflblClassId.Value = dt.Rows[0]["Classind"].ToString();
                    hfRetirmentYear.Value = dt.Rows[0]["RetirementAge"].ToString();
                    getRetirmentYear();
                }
                else
                {
                    lblClassDesc.Text = "";
                    hflblClassId.Value = "0";
                    hfRetirmentYear.Value = "0";
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ddlEmpType.SelectedValue == "0")
        {
            ddlEmpType.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Employee Type";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlEmpType.Focus();
            return;
        }
        else
        {
            ddlEmpType.Style.Add("border-color", "lightgray");
        }
        
        if (ddlEmpCtg.SelectedValue == "0")
        {
            ddlEmpCtg.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Employee Category";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlEmpCtg.Focus();
            return;
        }
        else
        {
            ddlEmpCtg.Style.Add("border-color", "lightgray");
        }

        if (ddlSubSection.SelectedValue == "0")
        {
            ddlSubSection.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Employee Sub Section";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlSubSection.Focus();
            return;
        }
        else
        {
            ddlSubSection.Style.Add("border-color", "lightgray");
        }

        if (ddlDeputation.SelectedValue == "000")
        {
            ddlDeputation.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Deputation";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlDeputation.Focus();
            return;
        }
        else
        {
            ddlDeputation.Style.Add("border-color", "lightgray");
        }
        if (ddlDeputation.SelectedValue == "1")
        {
            if (txtDepuDate.Text.Trim() == "")
            {
                txtDepuDate.Style.Add("border-color", "red");
                lblMsg.Text = "Please Select Deputation Date";
                lblMsg.CssClass = "alertMsg failed";
                lblMsg.Attributes.Remove("style");
                txtDepuDate.Focus();
                return;
            }
            else
            {
                txtDepuDate.Style.Add("border-color", "lightgray");
            }

            if (txtDepuPlace.Text.Trim() == "")
            {
                txtDepuPlace.Style.Add("border-color", "red");
                lblMsg.Text = "Please Select Deputation Place";
                lblMsg.CssClass = "alertMsg failed";
                lblMsg.Attributes.Remove("style");
                txtDepuPlace.Focus();
                return;
            }
            else
            {
                txtDepuPlace.Style.Add("border-color", "lightgray");
            }
        }

        if (ddlDesignation.SelectedValue == "0")
        {
            ddlDesignation.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Designation";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlDesignation.Focus();
            return;
        }
        else
        {
            ddlDesignation.Style.Add("border-color", "lightgray");
        }

        if (ddlTitalE.SelectedValue == "0")
        {
            ddlTitalE.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Tital";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlTitalE.Focus();
            return;
        }
        else
        {
            ddlTitalE.Style.Add("border-color", "lightgray");
        }

        if (txtFirstName.Text.Trim() == "")
        {
            txtFirstName.Style.Add("border-color", "red");
            lblMsg.Text = "Please Enter First Name";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            txtFirstName.Focus();
            return;
        }
        else
        {
            txtFirstName.Style.Add("border-color", "lightgray");
        }

        //if (txtLastName.Text.Trim() == "")
        //{
        //    txtLastName.Style.Add("border-color", "red");
        //    lblMsg.Text = "Please Enter Last Name";
        //    lblMsg.CssClass = "alertMsg failed";
        //    lblMsg.Attributes.Remove("style");
        //    txtLastName.Focus();
        //    return;
        //}
        //else
        //{
        //    txtLastName.Style.Add("border-color", "lightgray");
        //}

        if (txtFname.Text.Trim() == "")
        {
            txtFname.Style.Add("border-color", "red");
            lblMsg.Text = " Please Enter Father Name";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            txtFname.Focus();
            return;
        }
        else
        {
            txtFname.Style.Add("border-color", "lightgray");
        }

        if (ddlGender.SelectedValue == "0")
        {
            ddlGender.Style.Add("border-color", "red");
            lblMsg.Text = "  Please Select Gender";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlGender.Focus();
            return;
        }
        else
        {
            ddlGender.Style.Add("border-color", "lightgray");
        }

        if (ddlCastCtg.SelectedValue == "0")
        {
            ddlCastCtg.Style.Add("border-color", "red");
            lblMsg.Text = "   Please Select Category";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlCastCtg.Focus();
            return;
        }
        else
        {
            ddlCastCtg.Style.Add("border-color", "lightgray");
        }

        //if (ddlQualification.SelectedValue == "0")
        //{
        //    ddlQualification.Style.Add("border-color", "red");
        //    lblMsg.Text = " Please Select Qualification ";
        //    lblMsg.CssClass = "alertMsg failed";
        //    lblMsg.Attributes.Remove("style");
        //    ddlQualification.Focus();
        //    return;
        //}
        //else
        //{
        //    ddlQualification.Style.Add("border-color", "lightgray");
        //}

        //if (ddlBloodGroup.SelectedValue == "0")
        //{
        //    ddlBloodGroup.Style.Add("border-color", "red");
        //    lblMsg.Text = " Please Select Blood Group";
        //    lblMsg.CssClass = "alertMsg failed";
        //    lblMsg.Attributes.Remove("style");
        //    ddlBloodGroup.Focus();
        //    return;
        //}
        //else
        //{
        //    ddlBloodGroup.Style.Add("border-color", "lightgray");
        //}
        if (ddlHandicapped.SelectedValue == "000")
        {
            ddlHandicapped.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Handicapped Yes/No ";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlHandicapped.Focus();
            return;
        }
        else
        {
            ddlHandicapped.Style.Add("border-color", "lightgray");
        }

        if (ddlHandicapped.SelectedValue == "1")
        {
            if (txtHandPercentage.Text.Trim() == "")
            {
                txtHandPercentage.Style.Add("border-color", "red");
                lblMsg.Text = "Please Select Handicapped Percentage ";
                lblMsg.CssClass = "alertMsg failed";
                lblMsg.Attributes.Remove("style");
                txtHandPercentage.Focus();
                return;
            }
            else
            {
                txtHandPercentage.Style.Add("border-color", "lightgray");
            }
        }

        if (ddlGrade.SelectedValue == "000")
        {
            ddlGrade.Style.Add("border-color", "red");
            lblMsg.Text = "Please Select Grade ";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            ddlGrade.Focus();

            return;
        }
        else
        {
            ddlGrade.Style.Add("border-color", "lightgray");
        }



        if (txtBasic.Text.Trim() == "")
        {
            txtBasic.Style.Add("border-color", "red");
            lblMsg.Text = " Please Enter Basic ";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            txtBasic.Focus();

            return;
        }
        else
        {
            txtBasic.Style.Add("border-color", "lightgray");
        }


        if (txtBirthDate.Text.Trim() == "")
        {
            txtBirthDate.Style.Add("border-color", "red");
            lblMsg.Text = " Please Enter Date Of Birth ";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            txtBirthDate.Focus();

            return;
        }
        else
        {
            txtBirthDate.Style.Add("border-color", "lightgray");
        }

        if (txtJoiningDate.Text.Trim() == "")
        {
            txtJoiningDate.Style.Add("border-color", "red");
            lblMsg.Text = " Please Enter Joining Date ";
            lblMsg.CssClass = "alertMsg failed";
            lblMsg.Attributes.Remove("style");
            txtJoiningDate.Focus();

            return;
        }
        else
        {
            txtJoiningDate.Style.Add("border-color", "lightgray");
        }

        string CurrentDate = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0');
        if (Convert.ToDateTime(lblRetirmentDate.Text.Substring(6, 4) + "/" + lblRetirmentDate.Text.Substring(3, 2) + "/" + lblRetirmentDate.Text.Substring(0, 2)) <= Convert.ToDateTime(CurrentDate))
        {
            lblMsg.Text = "Retirment date shold not be less than current date";
            lblMsg.CssClass = "alertMsg failed";
            return;
        }



        if (txtEmpNo.Text == "")
        {
            lblMsg.Text = "Please Enter Employee No.";
            lblMsg.CssClass = "alertMsg failed";
            return;
        }

        plobj = new PL_EmpMaster();
        plobj.Ind = 5;
        plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        plobj.FormNo = 0;
        plobj.Zone = 0;
        plobj.WardNo = 0;
        plobj.Empno = Convert.ToInt32(txtEmpNo.Text);
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
        plobj.DeptCd1 = Convert.ToInt32(hfSectionId.Value);
        plobj.DeptCd2 = Convert.ToInt32(ddlSubSection.SelectedValue);

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
        plobj.BGroup = ddlBloodGroup.SelectedItem.Text;
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
            if (dt.Rows[0][0].ToString() == "Update")
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully..!!!')", true);
                ClearAllPageControll();
                lblMsg.Text = "Record Updated Successfully  Employee No Is :-  " + dt.Rows[0]["LastEmpNo"].ToString();
                lblMsg.CssClass = "alertMsg success";
                txtEmpNo.Enabled = true;
                txtEmpNo.Text = "";
                txtEmpNo.Focus();
                pnlGridInfo.Visible = false;
                btnSearch.Enabled = true;
                btnSearch.Attributes.Remove("disabled");
                btnSave.Visible = false;
            }
            else
            {
                lblMsg.Text = "Record Not Update";
                lblMsg.CssClass = "alertMsg failed";
            }
        }
        else
        {
            lblMsg.Text = "Record Not Update";
            lblMsg.CssClass = "alertMsg failed";
        }

    }
    //protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlBank.SelectedValue != "0")
    //    {
    //        DataTable dt_BankTable = (DataTable)ViewState["VS_BankTable"];
    //        DataRow[] dr = dt_BankTable.Select("BnkCd=" + ddlBank.SelectedValue.ToString());
    //        DataTable BranchTable = dr.CopyToDataTable();

    //        if (BranchTable.Rows.Count > 0)
    //        {
    //            ddlBranch.DataSource = BranchTable;
    //            ddlBranch.DataTextField = "BranchName";
    //            ddlBranch.DataValueField = "BrCd";
    //            ddlBranch.DataBind();
    //            ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));

    //            ddlBranch.Enabled = true;
    //            txtBankAcNo.Enabled = true;
    //            txtIFSCCode.Enabled = true;

    //        }
    //        else
    //        {
    //            ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --- ", "0"));
    //            ddlBranch.Enabled = false;
    //            txtBankAcNo.Enabled = false;
    //            txtIFSCCode.Enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        ddlBranch.Items.Clear();
    //        ddlBranch.Enabled = false;
    //        txtBankAcNo.Enabled = false;
    //        txtIFSCCode.Enabled = false;
    //    }
    //    //  ddlBranch.Focus();
    //    // Bank_info.Attributes.Add("class", "panel-collapse collapse in");
    //}

    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtIFSCCode.Text = "";
        if (ddlBank.SelectedValue != "0")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillBranchAndIFSC?Ind=8&BankCd=" + ddlBank.SelectedValue + "&BranchCd=0");

            if (dt.Rows.Count > 0)
            {
                ddlBranch.DataSource = dt;
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

        // Bank_info.Attributes.Add("class", "panel-collapse collapse in");

    }

    protected void ddlBranch_SelectedIndexChanged1(object sender, EventArgs e)
    {
        txtBankAcNo.Enabled = false;
        txtIFSCCode.Text = "";

        if (ddlBranch.SelectedValue != "0" && ddlBank.SelectedValue != "0")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillBranchAndIFSC?Ind=9&BankCd=" + ddlBank.SelectedValue + "" + "&BranchCd=" + ddlBranch.SelectedValue + "");

            if (dt.Rows.Count > 0)
            {
                txtBankAcNo.Enabled = true;
                txtIFSCCode.Text = dt.Rows[0]["IFSCCode"].ToString();
                txtIFSCCode.Enabled = false;
                txtBankAcNo.Enabled = true;

            }
            else
            {
                txtIFSCCode.Text = "";
            }

        }

        // Bank_info.Attributes.Add("class", "panel-collapse collapse in");

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
        if (Convert.ToInt32(ddlDesignation.SelectedValue) != 0)
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillClassDesc?Ind=3&DesgCd=" + ddlDesignation.SelectedValue + "");
            if (dt.Rows.Count > 0)
            {
                lblClassDesc.Text = dt.Rows[0]["ClassDesc"].ToString();
                hflblClassId.Value = dt.Rows[0]["Classind"].ToString();
                hfRetirmentYear.Value = dt.Rows[0]["RetirementAge"].ToString();
                getRetirmentYear();
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
        //rbFixPayee.Focus();

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "FunJoiningDate()", true);
    }


    DataTable VsdtNomneeDetails
    {
        get { return (DataTable)ViewState["dtGvNomnee"]; }
        set { ViewState["dtGvNomnee"] = value; }
    }

    DataTable CreatNomneeGrid()
    {
        DataTable gvNom = new DataTable();
        // gvNom.Columns.Add("NomneeTypeId", typeof(int));
        //   gvNom.Columns.Add("NomneeTypeDesc", typeof(string));
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
        //  dr["NomneeTypeDesc"] = ddlNomineeType_Nom.SelectedItem.Text;
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

    protected void btnAddNomeenee_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        btnAddNomeenee.Text = "Add";
        Var_dubRecord = 0;

        BindGvItemDetail();
        ClarNomneeGrid();
        // Nominee.Attributes.Add("class", "panel-collapse collapse in");

    }
    public void ClarNomneeGrid()
    {
        //ddlNomineeType_Nom.ClearSelection();
        txtName_Nom.Text = "";
        ddlRelation_Nom.ClearSelection();
        txtPercentage_Nom.Text = "";
    }

    //protected void gvNomnee_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        int rowIndex = Convert.ToInt32(e.CommandArgument);
    //        if (e.CommandName == "DeleteRow" || e.CommandName == "Select1")
    //        {
    //            dtGvomnee = VsdtNomneeDetails;
    //            dtGvomnee.Rows[rowIndex].Delete();
    //            VsdtNomneeDetails = dtGvomnee;
    //            gvNomnee.DataSource = dtGvomnee;
    //            gvNomnee.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    //Nominee.Attributes.Add("class", "panel-collapse collapse in");
    //}

    static int Var_dubRecord = 0;
    protected void gvNomnee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if ((e.CommandName == "DeleteRow") || (e.CommandName == "Select1"))
            {
                if (e.CommandName == "Select1")
                {
                    if (Var_dubRecord == 0)
                    {
                        Var_dubRecord = 1;
                        dtGvomnee = VsdtNomneeDetails;
                        dtGvomnee.Rows[rowIndex].Delete();
                        VsdtNomneeDetails = dtGvomnee;
                        gvNomnee.DataSource = dtGvomnee;
                        gvNomnee.DataBind();

                    }
                    else
                    {
                        lblMsg.Text = "Yor are already click edit button.firstly update record";
                        lblMsg.CssClass = "alertMsg failed";
                        lblMsg.Attributes.Remove("style");
                        return;
                    }
                }
                else
                {
                    dtGvomnee = VsdtNomneeDetails;
                    dtGvomnee.Rows[rowIndex].Delete();
                    VsdtNomneeDetails = dtGvomnee;
                    gvNomnee.DataSource = dtGvomnee;
                    gvNomnee.DataBind();
                }

            }

        }
        catch (Exception ex)
        {

        }
    }

    //protected void btnEdit_Click(object sender, EventArgs e)
    //{
    //    LinkButton btn = (LinkButton)sender;
    //    GridViewRow gvr = (GridViewRow)btn.NamingContainer;

    //    int rowindex = gvr.RowIndex;
    //    //  Label NomineeType_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeTypeId");
    //    Label Name_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeName");
    //    Label Relation_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeRelationId");
    //    Label Percentage_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeParsentage");

    //    //  ddlNomineeType_Nom.SelectedValue = NomineeType_Nom.Text;
    //    txtName_Nom.Text = Name_Nom.Text;
    //    ddlRelation_Nom.Text = Relation_Nom.Text;
    //    txtPercentage_Nom.Text = Percentage_Nom.Text;
    //    hfFocus.Focus();
    //    // Nominee.Attributes.Add("class", "panel-collapse collapse in");
    //}

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (Var_dubRecord == 0)
        {
            btnAddNomeenee.Text = "Update";
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            Label Name_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeName");
            Label Relation_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeRelationId");
            Label Percentage_Nom = (Label)gvNomnee.Rows[rowindex].FindControl("lblNomneeParsentage");

            txtName_Nom.Text = Name_Nom.Text;
            ddlRelation_Nom.Text = Relation_Nom.Text;
            txtPercentage_Nom.Text = Percentage_Nom.Text;
            hfFocus.Focus();
        }
    }



    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Salary/MasterForm/FrmEdit_EmplyeeEntryMaster.aspx");
        // btnSearch.Enabled = true;
        // btnSearch.Attributes.Remove("disabled");
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

    protected void ddlSubSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbFixPayee.SelectedValue == "1")
        {
            ddlGrade.Enabled = false;
        }
        else
        {
            ddlGrade.Enabled = true;
        }

        if (ddlSubSection.SelectedValue != "0")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillSection?Ind=6&CityCode=" + Session["CityCode"] + "&CCCode=" + ddlSubSection.SelectedValue + "");
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lblSection.Text = dt.Rows[0]["DeptName"].ToString();
                        hfSectionId.Value = dt.Rows[0]["DeptCode"].ToString();
                    }
                }
            }
        }
        else
        {
            lblSection.Text = "";
            hfSectionId.Value = "0";
        }
    }
    protected void ddlEmpCtg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmpCtg.SelectedValue != "0")
        {
            dt = new DataTable();
            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/FillGrade?Ind=7&CityCode=" + Session["CityCode"] + "&SalaryTypeInd=" + ddlEmpCtg.SelectedValue + "");
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            ddlGrade.DataSource = dt;
                            ddlGrade.DataTextField = "GrdDesc";
                            ddlGrade.DataValueField = "GrdCd";
                            ddlGrade.DataBind();
                            ddlGrade.Items.Insert(0, new ListItem("-- Select Grade --- ", "000"));
                        }
                        else
                        {
                            ddlGrade.Items.Insert(0, new ListItem("-- Select Grade --- ", "000"));
                        }
                    }
                }
            }
        }
        else
        {
            ddlGrade.Items.Clear();
            ddlGrade.Items.Insert(0, new ListItem("-- Select Grade --- ", "000"));
        }
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
            getRetirmentYear();
        }
        // 
    }

    protected void txtJoiningDate_TextChanged(object sender, EventArgs e)
    {
        if (Regex.IsMatch(txtJoiningDate.Text, "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
        {
            if (txtJoiningDate.Text.Trim() != "")
            {
                string CurrentDate = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0');
                if (Convert.ToDateTime(txtJoiningDate.Text.Substring(6, 4) + "/" + txtJoiningDate.Text.Substring(3, 2) + "/" + txtJoiningDate.Text.Substring(0, 2)) > Convert.ToDateTime(CurrentDate))
                {
                    lblMsg.Text = "Joining Date is not greater than today date ";
                    lblMsg.CssClass = "alertMsg failed";
                    lblMsg.Attributes.Remove("style");
                    txtJoiningDate.Text = "";
                    txtJoiningDate.BorderColor = System.Drawing.Color.Red;
                    txtJoiningDate.Focus();
                    return;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    txtJoiningDate.BorderColor = System.Drawing.Color.LightGray;
                }
            }
        }

        if (Regex.IsMatch(txtJoiningDate.Text, "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$") && Regex.IsMatch(txtBirthDate.Text, "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
        {
            if (txtJoiningDate.Text.Trim() != "" && txtBirthDate.Text.Trim() != "")
            {
                DateTime BirthDate = Convert.ToDateTime(txtBirthDate.Text.Substring(6, 4) + "/" + txtBirthDate.Text.Substring(3, 2) + "/" + txtBirthDate.Text.Substring(0, 2));
                DateTime JoiningDate = Convert.ToDateTime(txtJoiningDate.Text.Substring(6, 4) + "/" + txtJoiningDate.Text.Substring(3, 2) + "/" + txtJoiningDate.Text.Substring(0, 2));

                int BirthYear = Convert.ToInt32(txtBirthDate.Text.Substring(6, 4));
                int JoininYear = Convert.ToInt32(txtJoiningDate.Text.Substring(6, 4));


                if (BirthDate > JoiningDate)
                {
                    lblMsg.Text = "Joining Date sholud not be less than Birth Date  ";
                    lblMsg.CssClass = "alertMsg failed";
                    lblMsg.Attributes.Remove("style");
                    txtJoiningDate.Text = "";
                    txtJoiningDate.BorderColor = System.Drawing.Color.Red;
                    txtJoiningDate.Focus();
                    return;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    txtJoiningDate.BorderColor = System.Drawing.Color.LightGray;
                }

                if (JoininYear - BirthYear < 18)
                {
                    lblMsg.Text = "You are not eligible your age should have above 18 year ";
                    lblMsg.CssClass = "alertMsg failed";
                    lblMsg.Attributes.Remove("style");
                    txtJoiningDate.Text = "";
                    txtJoiningDate.BorderColor = System.Drawing.Color.Red;
                    txtJoiningDate.Focus();
                    return;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.CssClass = "";
                    txtJoiningDate.BorderColor = System.Drawing.Color.LightGray;
                }
            }
        }
        getRetirmentYear();
    }
    void getRetirmentYear()
    {
        if ((txtJoiningDate.Text != "") && (lblClassDesc.Text != "") && (txtBirthDate.Text != ""))
        {
            dt = new DataTable();

            dt = Salary_CLSCommon.CallApiGetdt("EmployeeMaster/GetRetirmentDate?Ind=10&RetirmentYear=" + hfRetirmentYear.Value + "&Dob=" + Salary_CLSCommon.ConvertToDate(txtBirthDate.Text) + "");

            if (dt.Rows.Count > 0)
            {
                lblRetirmentDate.Text = dt.Rows[0]["RetitmentDt"].ToString();
            }
            else
            {
                lblRetirmentDate.Text = "";
            }
        }
    }
}