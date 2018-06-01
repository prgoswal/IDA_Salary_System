using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salary_TransactionForm_FrmFilterInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Salary_CLSCommon.CommonCheckSession();
            BindAllData();
        }
    }

    public void BindAllData()
    {
        DataSet ds = new DataSet();
        ds = Salary_CLSCommon.CallApiGet("FilterInformation/Bind_Getdata?Ind=1");
        if (ds != null)
        {
            ChkSelectField.DataSource = ds.Tables[0];
            ChkSelectField.DataTextField = "DisplayField";
            ChkSelectField.DataValueField = "ActualField";
            ChkSelectField.DataBind();

            chkFilterField.DataSource = ds.Tables[1];
            chkFilterField.DataTextField = "DeptDisplayField";
            chkFilterField.DataValueField = "DeptActualField";
            chkFilterField.DataBind();

            chkOrderBy.DataSource = ds.Tables[2];
            chkOrderBy.DataTextField = "OrderDisplayField";
            chkOrderBy.DataValueField = "OrderActualField";
            chkOrderBy.DataBind();

            ChkDesignation.DataSource = ds.Tables[3];
            ChkDesignation.DataTextField = "DesgDesc";
            ChkDesignation.DataValueField = "DesgCd";
            ChkDesignation.DataBind();


            ChkDepartment.DataSource = ds.Tables[4];
            ChkDepartment.DataTextField = "DeptName";
            ChkDepartment.DataValueField = "DeptCode";
            ChkDepartment.DataBind();

            ChkClass.DataSource = ds.Tables[5];
            ChkClass.DataTextField = "ClassDesc";
            ChkClass.DataValueField = "Classind";
            ChkClass.DataBind();
            // ChkClass.Items.Insert(0, new ListItem("All", "0"));

            ChkGrad.DataSource = ds.Tables[6];
            ChkGrad.DataTextField = "G";
            ChkGrad.DataValueField = "GrdCd";
            ChkGrad.DataBind();

            chkEmpType.DataSource = ds.Tables[7];
            chkEmpType.DataTextField = "Desc1";
            chkEmpType.DataValueField = "EmpType";
            chkEmpType.DataBind();
            //chkEmpType.Items.Insert(0, new ListItem("All", "0"));

            foreach (ListItem listItem in ChkSelectField.Items)
            {
                if (listItem.Value == " A.Empno as [Emp. No.]")
                {
                    listItem.Selected = true;
                    listItem.Enabled = false;
                    return;
                }

            }
        }
    }

    protected void chkFilterField_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkFilterField.BackColor = System.Drawing.Color.White;

        lblMsg.Text = "";
        lblMsg.CssClass = "";
        //class
        if (chkFilterField.Items[1].Selected == true)
        {
            divClass.Visible = true;
        }
        else
        {
            divClass.Visible = false;
        }

        //Department
        if (chkFilterField.Items[2].Selected == true)
        {
            divDepartment.Visible = true;
        }
        else
        {
            divDepartment.Visible = false;
        }

        //Date Of Joining
        if (chkFilterField.Items[7].Selected == true)
        {
            txtDateOfJoin.Focus();
            divDoj.Visible = true;

        }
        else
        {
            divDoj.Visible = false;
        }

        //Date Of Retirement
        if (chkFilterField.Items[8].Selected == true)
        {
            txtDateOfRetir.Focus();
            divDor.Visible = true;

        }
        else
        {
            divDor.Visible = false;
        }

        //Designation
        if (chkFilterField.Items[3].Selected == true)
        {
            divDesignation.Visible = true;
        }
        else
        {
            divDesignation.Visible = false;
        }

        //Grade
        if (chkFilterField.Items[5].Selected == true)
        {
            divGrade.Visible = true;
        }
        else
        {
            divGrade.Visible = false;
        }

        //Emp No
        if (chkFilterField.Items[6].Selected == true)
        {
            txtEmpNoFrom.Focus();
            divEmpNo.Visible = true;
        }
        else
        {
            divEmpNo.Visible = false;
        }

        //Emp Type
        if (chkFilterField.Items[0].Selected == true)
        {
            ChkAllEmpType.Focus();
            divEmpType.Visible = true;
        }
        else
        {
            divEmpType.Visible = false;
        }

        //Gender
        if (chkFilterField.Items[4].Selected == true)
        {
            chkGender.Focus();
            divGender.Visible = true;
        }
        else
        {
            divGender.Visible = false;
        }
    }


    void ShowMessage(string Message, bool type)
    {
        lblMsg.Text = (type ? "" : "") + Message;
        lblMsg.CssClass = type ? "alertMsg success" : "alertMsg failed";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GvFilterInformation.DataSource = null;
        GvFilterInformation.DataBind();
        lblMsg.Text = "";
        lblMsg.CssClass = "";
        chkOrderBy.BackColor = System.Drawing.Color.White;
        ChkSelectField.BackColor = System.Drawing.Color.White;
        chkFilterField.BackColor = System.Drawing.Color.White;
        BindGrid();
    }


    public void BindGrid()
    {

        //////////////////////////////////////  SELECT FIELD /////////////////////////////////////////////////////////
        string SelectFieldString = null;
        ViewState["SelectFieldString"] = null;
        for (int j = 0; j < ChkSelectField.Items.Count; j++)
        {
            if (ChkSelectField.Items[j].Selected == true)
            {
                if (SelectFieldString == null)
                    SelectFieldString = ChkSelectField.Items[j].Value;
                else
                    SelectFieldString = SelectFieldString + "," + ChkSelectField.Items[j].Value;
            }
        }



        if (SelectFieldString == null)
        {
            ShowMessage(" Please Check At Least One Checkbox In Selection Field", false);
            ChkSelectField.Focus();
            ChkSelectField.BackColor = System.Drawing.Color.LightYellow;
            return;
        }
        else
        {
            ViewState["SelectFieldString"] = SelectFieldString;
        }


        //////////////////////////////////////  ORDER BY FIELD /////////////////////////////////////////////////////////
        string OrderFieldString = null;
        ViewState["OrderFieldString"] = null;
        for (int j = 0; j < chkOrderBy.Items.Count; j++)
        {
            if (chkOrderBy.Items[j].Selected == true)
            {
                if (OrderFieldString == null)
                    OrderFieldString = chkOrderBy.Items[j].Value;
                else
                    OrderFieldString = OrderFieldString + "," + chkOrderBy.Items[j].Value;
            }
        }

        if (OrderFieldString == null)
        {
            chkOrderBy.BackColor = System.Drawing.Color.LightYellow;
            ShowMessage(" Please Check At Least One Checkbox In Order By Field", false);
            return;
        }
        else
        {
            ViewState["OrderFieldString"] = OrderFieldString;
        }


        //////////////////////////////////////  FILTER BY FIELD /////////////////////////////////////////////////////////


        string DepString = null;
        string ClassString = null;
        string DesignationString = null;
        string GradeString = null;
        string EmpType = null;
        string all = null;
        string a1 = null;
        string a2 = null;
        string a3 = null;
        string a4 = "";
        string a5 = "";
        string a6 = "";
        string a7 = "";
        string a8 = "";
        string a9 = "";
        string a10 = "";
        ViewState["FilterFieldString"] = null;

        for (int j = 0; j < chkFilterField.Items.Count; j++)
        {
            if (chkFilterField.Items[j].Selected == true)
            {

                /////////////////////////////////////////////////////  Department  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[j].Value.ToString() == "C.DeptCd")
                {
                    if (ChkAllDepartment.Checked == true)
                    {
                        a1 = DepString = " and A.DeptCd1 <> 0  ";
                    }
                    else
                    {
                        for (int k = 0; k < ChkDepartment.Items.Count; k++)
                        {
                            if (ChkDepartment.Items[k].Selected == true)
                            {
                                if (DepString == null)
                                    DepString = " and DeptCd1 " + " in(" + ChkDepartment.Items[k].Value;
                                else
                                    DepString = DepString + " , " + ChkDepartment.Items[k].Value;
                            }
                        }
                        a1 = DepString + " ) ";
                    }
                }

                /////////////////////////////////////////////////////  Class  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[j].Value.ToString() == "D.ClassInd")
                {
                    if (chkAllClass.Checked == true)
                    {
                        a2 = " and A.ClassInd in (1,2,3,4)";
                    }

                    else
                    {
                        for (int k = 0; k < ChkClass.Items.Count; k++)
                        {
                            if (ChkClass.Items[k].Selected == true)
                            {
                                if (ClassString == null)
                                    ClassString = " and A.ClassInd " + " in(" + ChkClass.Items[k].Value;
                                else
                                    ClassString = ClassString + " , " + ChkClass.Items[k].Value;
                            }
                        }
                        a2 = ClassString + " ) ";

                    }
                }


                /////////////////////////////////////////////////////  Designation  ////////////////////////////////////////////////////////////////
                if (chkAllDesgination.Checked == true)
                {
                    a3 = DesignationString = " and A.DesgCd <> 0  ";
                }
                else
                {
                    if (chkFilterField.Items[j].Value.ToString() == "B.DesgCd")
                    {
                        for (int k = 0; k < ChkDesignation.Items.Count; k++)
                        {
                            if (ChkDesignation.Items[k].Selected == true)
                            {
                                if (DesignationString == null)
                                    DesignationString = " and A.DesgCd " + " in(" + ChkDesignation.Items[k].Value;
                                else
                                    DesignationString = DesignationString + " , " + ChkDesignation.Items[k].Value;
                            }
                        }
                        a3 = DesignationString + " ) ";
                    }
                }
                /////////////////////////////////////////////////////  Grade  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[j].Value.ToString() == "F.Grade")
                {
                    if (chkAllGrade.Checked == true)
                    {
                        a4 = GradeString = " and A.GrdCd<>999  ";
                    }
                    else
                    {

                        for (int k = 0; k < ChkGrad.Items.Count; k++)
                        {
                            if (ChkGrad.Items[k].Selected == true)
                            {
                                if (GradeString == null)
                                    GradeString = " and A.GrdCd " + " in(" + ChkGrad.Items[k].Value;
                                else
                                    GradeString = GradeString + " , " + ChkGrad.Items[k].Value;
                            }
                        }
                        a4 = GradeString + " ) ";
                    }
                }
                /////////////////////////////////////////////////////  Employee Number  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[6].Selected == true)
                {
                    if (txtEmpNoFrom.Text.Trim() == "" || txtEmpNoTo.Text.Trim() == "")
                    {
                        ShowMessage("Please Select Employee No.", false);
                        return;
                    }
                    else
                    {
                        a5 = " and A.Empno between " + txtEmpNoFrom.Text + " and " + txtEmpNoTo.Text;
                    }
                }

                /////////////////////////////////////////////////////  Emp type  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[0].Selected == true)
                {
                    if (ChkAllEmpType.Checked == true)
                    {
                        a6 = " and A.EmpType in (1,2,3,4)";

                    }

                    else
                    {
                        if (chkFilterField.Items[j].Value.ToString() == "A.EmpType")
                        {
                            for (int k = 0; k < chkEmpType.Items.Count; k++)
                            {
                                if (chkEmpType.Items[k].Selected == true)
                                {
                                    if (EmpType == null)
                                        EmpType = " and A.EmpType " + " in(" + chkEmpType.Items[k].Value;
                                    else
                                        EmpType = EmpType + " , " + chkEmpType.Items[k].Value;
                                }
                            }
                            a6 = EmpType + " ) ";
                        }
                    }
                }

                ///////////////////////////////////////////////////// Date Of Joining  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[7].Selected == true)
                {
                    if (txtDateOfJoin.Text.Trim() == "")
                    {
                        ShowMessage("Please Select Date Of Joining", false);
                        txtDateOfJoin.Focus();
                        return;
                    }
                    else
                    {
                        if (rbDateOfJoin.SelectedValue == "0")
                        {
                            a7 = " and A.doj <= '" + Salary_CLSCommon.ConvertToDate(txtDateOfJoin.Text) + "'";
                        }
                        else
                        {
                            a7 = " and A.doj >= '" + Salary_CLSCommon.ConvertToDate(txtDateOfJoin.Text) + "'";
                        }

                    }
                }


                ///////////////////////////////////////////////////// Date Of Retirement  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[8].Selected == true)
                {
                    if (txtDateOfRetir.Text.Trim() == "")
                    {
                        ShowMessage("Please Select Date Of Retirement", false);
                        txtDateOfRetir.Focus();
                        return;
                    }
                    else
                    {
                        if (rbDateOfRetir.SelectedValue == "0")
                        {
                            a8 = " and A.SupRetDt <= '" + Salary_CLSCommon.ConvertToDate(txtDateOfRetir.Text) + "'";
                        }
                        else
                        {
                            a8 = " and A.SupRetDt >= '" + Salary_CLSCommon.ConvertToDate(txtDateOfRetir.Text) + "'";
                        }

                    }
                }


                ///////////////////////////////////////////////////// Gender  ////////////////////////////////////////////////////////////////

                if (chkFilterField.Items[4].Selected == true)
                {
                    if (chkGender.SelectedValue == "0")
                    {
                        a9 = " and A.Sex in(0,1) ";
                    }
                    else if (chkGender.SelectedValue == "1")
                    {
                        a9 = " and A.Sex = 1 ";
                    }
                    else
                    {
                        a9 = " and A.Sex = 0 ";
                    }

                }

                ///////////////////////////////////////////////////// Gross Salary  ////////////////////////////////////////////////////////////////

                //if (ChkSelectField.Items[15].Selected == true)
                //{
                //a10 = ChkSelectField.Items[15].Value;
                //a10 = " ) as AllTable on Sal_TransCalc.Empno=AllTable.[Emp. No.]";
                //}

                ////////////////////////////////////////////////////////////  END ///////////////////////////////////////////////////////////////////////////////////
            }
        }


        all = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9;

        if (all.ToString() == "" || all.ToString() == null)
        {
            chkFilterField.BackColor = System.Drawing.Color.LightYellow;
            ShowMessage(" Please Check At Least One Checkbox In Filter Field", false);
            return;
        }
        if (all.Trim().ToString() == ")")
        {
            ShowMessage(" Please Select At Least One Option", false);
            return;
        }
        PL_FilterInformation plobj = new PL_FilterInformation();
        plobj.Ind = 9;
        plobj.CityCode = Convert.ToInt32(Session["CityCode"]);
        plobj.SelectStringParameter = ViewState["SelectFieldString"].ToString();
        plobj.FilterStringParameter = all;
        plobj.OrderByStringParameter = ViewState["OrderFieldString"].ToString();
        string uri = string.Format("FilterInformation/FilterGetData");
        DataTable dt = Salary_CLSCommon.ApiPostDataTable(uri, plobj);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                GvFilterInformation.DataSource = dt;
                GvFilterInformation.DataBind();
                btndownload.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(document).ready(function(){$('#processed-modal').modal('show');});", true);
            }
            else
            {
                GvFilterInformation.DataSource = null;
                GvFilterInformation.DataBind();
                btndownload.Visible = false;
                ShowMessage("Record Not Available", false);
            }
        }
        else
        {
            GvFilterInformation.DataSource = null;
            GvFilterInformation.DataBind();
            btndownload.Visible = false;
            ShowMessage("Record Not Available", false);
        }
    }

    protected void btndownload_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=EmployeeInfo_ExcelSheet.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        Response.ContentType.ToString();
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        for (int i = 0; i < GvFilterInformation.Rows.Count; i++)
        {
            GridViewRow row = GvFilterInformation.Rows[i];
            row.Attributes.Add("class", "textmode");
        }
        GvFilterInformation.RenderControl(htw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.ContentType = "application/text";
        Response.Write(sw.ToString());
        Response.End();


        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=EmployeeInfo_ExcelSheet.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //using (StringWriter sw = new StringWriter())
        //{
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GvFilterInformation.AllowPaging = false;
        //    this.BindGrid();
        //    GvFilterInformation.HeaderRow.BackColor = Color.White;
        //    foreach (TableCell cell in GvFilterInformation.HeaderRow.Cells)
        //    {
        //        cell.BackColor = GvFilterInformation.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in GvFilterInformation.Rows)
        //    {
        //        row.BackColor = Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = GvFilterInformation.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = GvFilterInformation.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //        }
        //    }
        //    GvFilterInformation.RenderControl(hw);
        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();

        //}
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    //protected void ChkSelectField_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblMsg.Text = "";
    //    lblMsg.CssClass = "";
    //    chkOrderBy.BackColor = System.Drawing.Color.White;
    //    ChkSelectField.BackColor = System.Drawing.Color.White;
    //}
    //protected void chkOrderBy_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblMsg.Text = "";
    //    lblMsg.CssClass = "";
    //    chkOrderBy.BackColor = System.Drawing.Color.White;
    //    ChkSelectField.BackColor = System.Drawing.Color.White;
    //}
    protected void txtEmpNoFrom_TextChanged(object sender, EventArgs e)
    {
        if ((txtEmpNoFrom.Text.Trim() != ""))
        {
            txtEmpNoTo.Text = txtEmpNoFrom.Text;
            txtEmpNoTo.Focus();
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void chkGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = chkGender.Items.Count;
        for (int i = 0; i < count; i++)
        {
            if (chkGender.Items[1].Selected == true || chkGender.Items[2].Selected == true)
            {
                chkGender.Items[0].Selected = false;
            }
            else
            {
                chkGender.Items[0].Selected = true;
            }
        }

    }
    //protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (ListItem listItem in ChkSelectField.Items)
    //    {
    //        if (chkSelectAll.Checked == true)
    //        {
    //            listItem.Selected = true;
    //        }
    //        else
    //        {
    //            listItem.Selected = false;
    //        }
    //    }
    //}
}