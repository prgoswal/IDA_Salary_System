using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
//using Prop_Property;

/// <summary>
/// Summary description for CstmDate
/// </summary>
public static class CstmDate
{
    public static string ddMMyyyyDate(string passedDate)           // from yyyy/mm/dd formet
    {
        string[] s = passedDate.Split('/');
        DateTime date = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
        return (Convert.ToString(date.Month).PadLeft(2, '0') + "/" + Convert.ToString(date.Day).PadLeft(2, '0') + "/" + Convert.ToString(date.Year));
    }
    public static bool cstm_DateValidation(object source, ServerValidateEventArgs value, Page sourcePage)
    {
        ContentPlaceHolder cnt1 = new ContentPlaceHolder();
        cnt1 = (System.Web.UI.WebControls.ContentPlaceHolder)sourcePage.Form.FindControl("ContentPlaceHolder1");

        string ControlName = ((System.Web.UI.WebControls.BaseValidator)source).ControlToValidate;
        string ValidatorName = ((System.Web.UI.Control)source).ID;

        TextBox txtControl = ((System.Web.UI.WebControls.TextBox)cnt1.FindControl(ControlName));
        CustomValidator cstmValidator = ((System.Web.UI.WebControls.CustomValidator)cnt1.FindControl(ValidatorName));
        //var ControlName = source.controltovalidate;
        //var ControlValidatorName = source.id;
        var DateValue = value.Value.Trim().Trim('_').Trim('/').Trim('_');
        if (DateValue.Length == 0)
        {

            txtControl.BackColor = Color.Wheat;
            sourcePage.SetFocus(txtControl);
            cstmValidator.ErrorMessage = "Required";
            value.IsValid = false;
        }
        else if (DateValue.Length < 10)
        {
            value.IsValid = false;
            txtControl.BackColor = Color.Wheat;
            sourcePage.SetFocus(txtControl);
            cstmValidator.ErrorMessage = "Invalid Date";
        }
        else
        {
            if (IsDateValid(DateValue))
            {
                if (ControlName == "txtDueDt")
                {
                    txtControl.BackColor = Color.White;
                    value.IsValid = true;
                }
                else if (ControlName == "txtEndDt")
                {
                    if (IsCurrentDate(DateValue) || !IsDatePassed(DateValue))
                    {
                        txtControl.BackColor = Color.White;
                        value.IsValid = true;
                    }
                    else
                    {
                        txtControl.BackColor = Color.Wheat;
                        sourcePage.SetFocus(txtControl);
                        cstmValidator.ErrorMessage = "Should be < or = to Current Date ( " + Convert.ToString(System.Web.HttpContext.Current.Session["CurrentDate"]) + ")";
                        value.IsValid = false;
                    }
                }
                else
                {
                    if (IsDatePassed(DateValue))
                    {
                        //    if (ControlName == "txtVouchDate")
                        //    {
                        //        string lastLockDate = chkLastLockDate(DateValue, ((System.Web.UI.WebControls.TextBox)cnt1.FindControl("txtVouchNo")).Visible == false ? true : false);
                        //        if (lastLockDate == null)
                        //        {
                        //            txtControl.BackColor = Color.White;
                        //            value.IsValid = true;
                        //        }
                        //        else
                        //        {
                        //            txtControl.BackColor = Color.Wheat;
                        //            sourcePage.SetFocus(txtControl);
                        //            cstmValidator.ErrorMessage = "Voucher data should be greater then last lock date - " + lastLockDate;
                        //            value.IsValid = false;
                        //        }
                        //    }
                        //    else
                        //    {
                        txtControl.BackColor = Color.White;
                        value.IsValid = true;
                        //}
                    }
                    else
                    {
                        txtControl.BackColor = Color.Wheat;
                        sourcePage.SetFocus(txtControl);
                        cstmValidator.ErrorMessage = "Should be < or = to Current Date ( " + Convert.ToString(System.Web.HttpContext.Current.Session["CurrentDate"]) + ")";
                        value.IsValid = false;
                    }
                }
            }
            else
            {
                txtControl.BackColor = Color.Wheat;
                sourcePage.SetFocus(txtControl);
                cstmValidator.ErrorMessage = "Invalid Date Format";
                value.IsValid = false;
            }
        }
        return value.IsValid;
    }
    public static string yyyyMMddDate(string passedDate)          // from dd/mm/yyyy formet
    {
        if (passedDate == "" || passedDate == null)
        {
            return "";
        }
        {
            string[] s = passedDate.Split('/');
            DateTime date = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
            return (Convert.ToString(date.Year) + "/" + Convert.ToString(date.Month).PadLeft(2, '0') + "/" + Convert.ToString(date.Day).PadLeft(2, '0'));
        }
    }
    public static string MMddyyyyDate(string passedDate)          // from dd/mm/yyyy formet
    {
        string[] s = passedDate.Split('/');
        DateTime date = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
        return (Convert.ToString(date.Month).PadLeft(2, '0') + "/" + Convert.ToString(date.Day).PadLeft(2, '0') + "/" + Convert.ToString(date.Year));
    }
    public static string ddMMyyyy(string passedDate)          // from mm/dd/yyyy formet
    {
        string[] s = passedDate.Split('/');
        DateTime date = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[0]), Convert.ToInt32(s[1]));
        return (Convert.ToString(date.Day).PadLeft(2, '0') + "/" + Convert.ToString(date.Month).PadLeft(2, '0') + "/" + Convert.ToString(date.Year));
    }
    public static string currentDate(string passedDate)           // from yyyy/mm/dd formet
    {
        DateTime date = Convert.ToDateTime(passedDate);
        return (Convert.ToString(date.Day).PadLeft(2, '0') + "/" + Convert.ToString(date.Month).PadLeft(2, '0') + "/" + Convert.ToString(date.Year));
    }

    //public static bool cstm_DateValidation(object source, ServerValidateEventArgs value, Page sourcePage)
    //{
    //    ContentPlaceHolder cnt1 = new ContentPlaceHolder();
    //    cnt1 = (System.Web.UI.WebControls.ContentPlaceHolder)sourcePage.Form.FindControl("ContentPlaceHolder1");

    //    string ControlName = ((System.Web.UI.WebControls.BaseValidator)source).ControlToValidate;
    //    string ValidatorName = ((System.Web.UI.Control)source).ID;

    //    TextBox txtControl = ((System.Web.UI.WebControls.TextBox)cnt1.FindControl(ControlName));
    //    CustomValidator cstmValidator = ((System.Web.UI.WebControls.CustomValidator)cnt1.FindControl(ValidatorName));
    //    //var ControlName = source.controltovalidate;
    //    //var ControlValidatorName = source.id;
    //    var DateValue = value.Value.Trim().Trim('_').Trim('/').Trim('_');
    //    if (DateValue.Length == 0)
    //    {

    //        txtControl.BackColor = Color.Wheat;
    //        sourcePage.SetFocus(txtControl);
    //        cstmValidator.ErrorMessage = "Required";
    //        value.IsValid = false;
    //    }
    //    else if (DateValue.Length < 10)
    //    {
    //        value.IsValid = false;
    //        txtControl.BackColor = Color.Wheat;
    //        sourcePage.SetFocus(txtControl);
    //        cstmValidator.ErrorMessage = "Invalid Date";
    //    }
    //    else
    //    {
    //        if (IsDateValid(DateValue))
    //        {
    //            if (ControlName == "txtDueDt")
    //            {
    //                txtControl.BackColor = Color.White;
    //                value.IsValid = true;
    //            }
    //            else if (ControlName == "txtEndDt")
    //            {
    //                if (IsCurrentDate(DateValue) || !IsDatePassed(DateValue))
    //                {
    //                    txtControl.BackColor = Color.White;
    //                    value.IsValid = true;
    //                }
    //                else
    //                {
    //                    txtControl.BackColor = Color.Wheat;
    //                    sourcePage.SetFocus(txtControl);
    //                    cstmValidator.ErrorMessage = "Should be < or = to Current Date ( " + Convert.ToString(System.Web.HttpContext.Current.Session["CurrentDate"]) + ")";
    //                    value.IsValid = false;
    //                }
    //            }
    //            else
    //            {
    //                if (IsDatePassed(DateValue))
    //                {
    //                    if (ControlName == "txtVouchDate")
    //                    {
    //                       // string lastLockDate = chkLastLockDate(DateValue, ((System.Web.UI.WebControls.TextBox)cnt1.FindControl("txtVouchNo")).Visible == false ? true : false);
    //                        if (lastLockDate == null)
    //                        {
    //                            txtControl.BackColor = Color.White;
    //                            value.IsValid = true;
    //                        }
    //                        else
    //                        {
    //                            txtControl.BackColor = Color.Wheat;
    //                            sourcePage.SetFocus(txtControl);
    //                            cstmValidator.ErrorMessage = "Voucher data should be greater then last lock date - " + lastLockDate;
    //                            value.IsValid = false;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        txtControl.BackColor = Color.White;
    //                        value.IsValid = true;
    //                    }
    //                }
    //                else
    //                {
    //                    txtControl.BackColor = Color.Wheat;
    //                    sourcePage.SetFocus(txtControl);
    //                    cstmValidator.ErrorMessage = "Should be < or = to Current Date ( " + Convert.ToString(System.Web.HttpContext.Current.Session["CurrentDate"]) + ")";
    //                    value.IsValid = false;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            txtControl.BackColor = Color.Wheat;
    //            sourcePage.SetFocus(txtControl);
    //            cstmValidator.ErrorMessage = "Invalid Date Format";
    //            value.IsValid = false;
    //        }
    //    }
    //    return value.IsValid;
    //}
    public static bool IsDateValid(string value)
    {
        int iDay;
        int iMonth;
        int iYear;
        string[] sDateArray = new string[3];
        // parse into 3 elements
        sDateArray = value.Split('/');
        iDay = Convert.ToInt32(sDateArray[0]);
        iMonth = Convert.ToInt32(sDateArray[1]);
        iYear = Convert.ToInt32(sDateArray[2]);
        // make sure values fall into numercial domains

        if ((iMonth == 0 || iMonth > 12) || (iDay == 0 || iDay > 31) || (iYear == 0 || iYear < 1000))
        {
            return false;
        }
        // handle February and Leap year
        if (iMonth == 2)
        {
            if (LeapYear(iYear))
            {
                if (iDay > 29)
                {
                    return false;
                }
            }
            else
            {
                if (iDay > 28)
                {
                    return false;
                }
            }
        }
        // Check to make sure value is not 31 in 30 day months
        if ((iMonth == 4) || (iMonth == 6) || (iMonth == 9) || (iMonth == 11))
        {
            if (iDay > 30)
            {
                return false;
            }
        }
        return true;
    }
    public static bool LeapYear(int intYear)
    {
        if (intYear % 100 == 0)
        {
            if (intYear % 400 == 0)
            {
                return true;
            }
        }
        else
        {
            if ((intYear % 4) == 0)
            {
                return true;
            }
        }
        return false;
    }
    // Date validation function for greater then current date
    public static bool IsDatePassed(string value)
    {
        int iElement;
        string[] sDateArray = new string[3];
        int iDay;
        int iMonth;
        int iYear;

        int iCurrentDay;
        int iCurrentMonth;
        int iCurrentYear;

        // parse into 3 elements
        sDateArray = value.Split('/');

        // get Current Date
        DateTime dCurrentDate = new DateTime();
        dCurrentDate = DateTime.Today;
        iCurrentDay = dCurrentDate.Day;
        iCurrentMonth = dCurrentDate.Month;
        iCurrentYear = dCurrentDate.Year;

        iDay = Convert.ToInt32(sDateArray[0]);
        iMonth = Convert.ToInt32(sDateArray[1]);
        iYear = Convert.ToInt32(sDateArray[2]);

        // handle 2 digit year

        if (Convert.ToString(iYear).Length < 3)
        {
            string iTemp = Convert.ToString(iCurrentYear);
            iCurrentYear = Convert.ToInt32(iTemp.Substring(2, 4));
            iCurrentYear = Convert.ToInt32(iCurrentYear);
        }

        iYear = Convert.ToInt32(iYear);

        if (iYear == iCurrentYear)
        {
            if (iMonth == iCurrentMonth)
            {
                if (iDay > iCurrentDay)
                {
                    return false;
                }
                else
                {
                    if (iDay <= iCurrentDay)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (iMonth < iCurrentMonth)
                {
                    return true;
                }
            }
        }
        else
        {
            if (iYear < iCurrentYear)
            {
                return true;
            }
        }
        return false;
    }
    // Date validation function for Equal to current date
    public static bool IsCurrentDate(string value)
    {
        int iElement;
        string[] sDateArray = new string[3];
        int iDay;
        int iMonth;
        int iYear;

        int iCurrentDay;
        int iCurrentMonth;
        int iCurrentYear;

        // parse into 3 elements
        sDateArray = value.Split('/');

        // get Current Date
        DateTime dCurrentDate = new DateTime();
        dCurrentDate = DateTime.Today;
        iCurrentDay = dCurrentDate.Day;
        iCurrentMonth = dCurrentDate.Month;
        iCurrentYear = dCurrentDate.Year;

        iDay = Convert.ToInt32(sDateArray[0]);
        iMonth = Convert.ToInt32(sDateArray[1]);
        iYear = Convert.ToInt32(sDateArray[2]);

        // handle 2 digit year

        if (Convert.ToString(iYear).Length < 3)
        {
            var iTemp = Convert.ToString(iCurrentYear);
            iCurrentYear = Convert.ToInt32(iTemp.Substring(2, 4));
            iCurrentYear = Convert.ToInt32(iCurrentYear);
        }

        iYear = Convert.ToInt32(iYear);

        if (iYear == iCurrentYear)
        {
            if (iMonth == iCurrentMonth)
            {
                if (iDay > iCurrentDay)
                {
                    return false;
                }
                else if (iDay < iCurrentDay)
                {
                    return false;
                }
                else
                {
                    if (iDay == iCurrentDay)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (iMonth == iCurrentMonth)
                {
                    return true;
                }

            }
        }
        else
        {
            if (iYear == iCurrentYear)
            {
                return true;
            }
        }

        return false;
    }

    //public static string chkLastLockDate(string VDate, bool val)
    //{
    //    if (val)
    //    {
    //        BL_Lock BL_Lock = new BL_Lock();
    //        Prop_Lock LockProperty = new Prop_Lock();
    //        LockProperty.Ind = "5";
    //        LockProperty.CoCode = Convert.ToString(System.Web.HttpContext.Current.Session["CoCode"]);
    //        LockProperty.YrCode = Convert.ToString(System.Web.HttpContext.Current.Session["YrCode"]);
    //        DataSet myds = new DataSet();
    //        myds = BL_Lock.MaxDate(LockProperty);
    //        if (myds != null)
    //        {
    //            if (myds.Tables.Count > 0)
    //            {
    //                if (myds.Tables[0].Rows.Count > 0)
    //                {
    //                   // string lstlockDate = (CstmDate.ddMMyyyy(Convert.ToDateTime(myds.Tables[0].Rows[0]["LockDate"]).ToShortDateString()));
    //                    string lstlockDate = ((Convert.ToDateTime(myds.Tables[0].Rows[0]["LockDate"]).ToShortDateString()));
    //                    //lblLockDateHead.Text = "Last Locked Date   -   " + lstlockDate;
    //                    //DateTime d1 = Convert.ToDateTime(CstmDate.MMddyyyyDate(lstlockDate));
    //                    //DateTime d2 = Convert.ToDateTime(CstmDate.MMddyyyyDate(VDate));
    //                    DateTime d1 = Convert.ToDateTime((lstlockDate));
    //                    DateTime d2 = Convert.ToDateTime((VDate));
    //                    int diff = d2.CompareTo(d1);
    //                    if (diff <= 0)
    //                    {
    //                        return lstlockDate;
    //                    }
    //                    else
    //                    {
    //                        return null;
    //                    }
    //                }
    //                else
    //                    return null;
    //            }
    //            else
    //                return null;
    //        }
    //        else
    //            return null;
    //    }
    //    else
    //        return null;

    //}
}
