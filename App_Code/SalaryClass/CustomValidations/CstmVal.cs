﻿using System;
using System.Data;
using System.Configuration;
//using System.Data.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Text;

/// <summary>
/// Summary description for Validation
/// </summary>CstmVal.decimal2(
public static class CstmVal
{ // Function is used to convert numeric into decimal
    public static string decimal2(string num)
    {
        if (num != "")
        {
            string[] s;
            s = num.Split('.');
            if (s.Length == 0)
                num = "0.00";
            else if (s.Length > 1)
            {
                if (s[0].Trim().Trim('_').TrimStart('0').Length == 0)
                    s[0] = "0";
                else
                    s[0] = s[0].Trim().Trim('_').TrimStart('0');

                if (s[1].Trim().Trim('_').Length > 2)
                    num = s[0] + "." + s[1].Substring(0, 2);
                else if (s[1].Trim().Trim('_').Length == 1)
                    //  num = s[0] + "0";
                    num = s[0] + "." + s[1] + "0";
                else if (s[1].Trim().Trim('_').Length == 0)
                    // num = s[0] + ".00";
                    num = s[0] + ".00";
            }
            else
                num = s[0] + ".00";
        }
        return num;
    }
 public static string ConvertToAscii(string str)
    {
        string strnew;
        int i, AscChar = 0, NewAsc;
        Byte[] ByteAscChar;
        strnew = "";
        for (i = 0; i < str.Length; i++)
        {
            ByteAscChar = Encoding.ASCII.GetBytes(((str.Substring(i, 1)) + i * 5));//[0];
            for (int bit = 0; bit < ByteAscChar.Length; bit++)
                AscChar = AscChar + Convert.ToInt32(ByteAscChar[bit]);
            if (AscChar < 10)
                NewAsc = Convert.ToInt32("00" + AscChar);
            else if (AscChar < 100)
                NewAsc = Convert.ToInt32("0" + AscChar);
            else
                NewAsc = AscChar;

            strnew = strnew + Convert.ToString(NewAsc);
        }
        return strnew;
    }
    // Function is used to convert string into its Ascii value
    //public static string ConvertToAscii(string str)
    //{
    //    string strnew;
    //    int i, AscChar = 0, NewAsc;
    //    Byte[] ByteAscChar;
    //    strnew = "";
    //    for (i = 0; i < str.Length; i++)
    //    {
    //        ByteAscChar = Encoding.ASCII.GetBytes(((str.Substring(i, 1)) + i * 5));//[0];
    //        for (int bit = 0; bit < ByteAscChar.Length; bit++)
    //            AscChar = AscChar + Convert.ToInt32(ByteAscChar[bit]);
    //        if (AscChar < 10)
    //            NewAsc = Convert.ToInt32("00" + AscChar);
    //        else if (AscChar < 100)
    //            NewAsc = Convert.ToInt32("0" + AscChar);
    //        else
    //            NewAsc = AscChar;

    //        strnew = strnew + Convert.ToString(NewAsc);
    //    }
    //    return strnew;
    //}

    public static string GetCodeString(ListBox list)   // function is to create string form value codes of list passed
    {
        string strCode = null;
        for (int i = 0; i < list.Items.Count; i++)
        {
            if (i == 0)
                strCode = list.Items[i].Value;
            else
                strCode += "," + list.Items[i].Value;
        }
        return strCode;
    }

    public static bool cstm_ClientValidate(object source, ServerValidateEventArgs args, Page sourcePage)
    {
        //Page p = new Page();
        //p = sourcePage;
        //string clientId = p.ClientID;
        ContentPlaceHolder cnt1 = new ContentPlaceHolder();
        cnt1 = (System.Web.UI.WebControls.ContentPlaceHolder)sourcePage.Form.FindControl("ContentPlaceHolder1");

        string ControlName = ((System.Web.UI.WebControls.BaseValidator)source).ControlToValidate;
        string ValidatorName = ((System.Web.UI.Control)source).ID;
        TextBox txtControl = ((System.Web.UI.WebControls.TextBox)cnt1.FindControl(ControlName));
        CustomValidator cstmValidator = ((System.Web.UI.WebControls.CustomValidator)cnt1.FindControl(ValidatorName));

        if (args.Value.Trim().Trim('_').Trim('.').Length == 0)
        {
            // Page p = new Page();
            txtControl.BackColor = Color.Wheat;
            sourcePage.SetFocus(txtControl);
            cstmValidator.ErrorMessage = "Required";
            args.IsValid = false;
        }
        else if (args.Value.Trim().Trim('_') == "0")
        {
            args.IsValid = false;
            txtControl.BackColor = Color.Wheat;
            sourcePage.SetFocus(txtControl);
            cstmValidator.ErrorMessage = "Invalid";
        }
        else if (Convert.ToDecimal(args.Value.Trim().Trim('_')) == 0)
        {
            if (ControlName == "txtOpnAmt" || ControlName == "txtUpdOpnAmt")      // opening Amount (txtOpnAmt) can be zero
            {
                txtControl.BackColor = Color.White;
                args.IsValid = true;
            }
            else                                                         // closing balance (txtClsAmt) can not be zero
            {
                args.IsValid = false;
                //   txtControl.BackColor = Color.Wheat;
                sourcePage.SetFocus(txtControl);
                cstmValidator.ErrorMessage = "Invalid";
            }
        }
        else
        {
            if (ControlName == "txtEntYr")   //harvinder - Security Deposit Entry
            {
                if (args.Value.Trim().Trim('_').Length < 4)
                {
                    args.IsValid = false;
                    txtControl.BackColor = Color.Wheat;
                    sourcePage.SetFocus(txtControl);
                    cstmValidator.ErrorMessage = "Invalid";
                }
                else
                {
                    txtControl.BackColor = Color.White;
                    args.IsValid = true;
                }
            }
            else if (ControlName == "txtVouchNo" || ControlName == "txtRefVouchNo")   // harvinder -  Security Deposit Updation
            {
                if (args.Value.Trim().Trim('_').Length < 7)
                {
                    args.IsValid = false;
                    txtControl.BackColor = Color.Wheat;
                    sourcePage.SetFocus(txtControl);
                    cstmValidator.ErrorMessage = "Invalid";
                }
                else
                {
                    txtControl.BackColor = Color.White;
                    args.IsValid = true;
                }
            }
            else if (ControlName == "txtToDt")
            {
                if (args.Value.Trim().Trim('_').Length < 6)
                {
                    args.IsValid = false;
                    txtControl.BackColor = Color.Wheat;
                    sourcePage.SetFocus(txtControl);
                    cstmValidator.ErrorMessage = "Cheque No should be of 6 to 8 chars";
                }
                else
                {
                    TextBox txtFrom = new TextBox();
                    txtFrom = (System.Web.UI.WebControls.TextBox)cnt1.FindControl("txtFromDt");
                    TextBox txtTo = new TextBox();
                    txtTo = (System.Web.UI.WebControls.TextBox)cnt1.FindControl("txtToDt");

                    int valFrom, valTo;

                    if (txtFrom.Text.Trim().Trim('_') != "")
                        valFrom = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)cnt1.FindControl("txtFromDt")).Text.Trim().Trim('_'));// Convert.ToInt32(txtFromDt.Text.Trim('_'));
                    else
                        valFrom = 0;
                    if (txtTo.Text.Trim().Trim('_') != "")
                        valTo = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)cnt1.FindControl("txtToDt")).Text.Trim().Trim('_'));// Convert.ToInt32(txtToDt.Text.Trim('_'));
                    else
                        valTo = 0;

                    if (valFrom == valTo)
                    {
                        args.IsValid = false;
                        txtControl.BackColor = Color.Wheat;
                        cstmValidator.ErrorMessage = "Chq No From can not equal Chq No To";
                        sourcePage.SetFocus(txtControl);
                    }
                    else if (valFrom >= valTo)
                    {
                        args.IsValid = false;
                        txtControl.BackColor = Color.Wheat;
                        cstmValidator.ErrorMessage = "Chq No From shoud be less then Chq No To";
                        sourcePage.SetFocus(txtControl);
                    }
                    else if (valFrom < valTo)
                    {
                        int diff = valTo - valFrom;
                        if (diff == 9 || diff == 19 || diff == 24 || diff == 49 || diff == 99 || diff == 399)
                        {
                            args.IsValid = true;
                            txtControl.BackColor = Color.White;
                        }
                        else
                        {
                            args.IsValid = false;
                            txtControl.BackColor = Color.Wheat;
                            cstmValidator.ErrorMessage = "Difference b/w From and To Chq No should be 10,20,25,50,100 or 400";
                            sourcePage.SetFocus(txtControl);

                        }
                    }
                }
            }
            else if (ControlName == "txtFromDt")
            {
                if (args.Value.Trim().Trim('_').Length < 6)
                {
                    args.IsValid = false;
                    txtControl.BackColor = Color.Wheat;
                    sourcePage.SetFocus(txtControl);
                    cstmValidator.ErrorMessage = "Cheque No should be of 6 to 8 chars";
                }
                else
                {
                    txtControl.BackColor = Color.White;
                    args.IsValid = true;
                }
            }
            else if (ControlName == "txtChqNo")
            {
                if (args.Value.Trim().Trim('_').Length < 6)
                {
                    args.IsValid = false;
                    sourcePage.SetFocus(txtControl);
                    cstmValidator.ErrorMessage = "Cheque No should be of 6 to 8 chars";
                }
                else
                {
                    txtControl.BackColor = Color.White;
                    args.IsValid = true;
                }
            }
            else
            {
                txtControl.BackColor = Color.White;
                args.IsValid = true;
            }
        }
        return args.IsValid;
    }

    public static bool cstm_RegExp(object source, ServerValidateEventArgs args, Page sourcePage)
    {
        //Page p = new Page();
        //p = sourcePage;
        //string clientId = p.ClientID;
        ContentPlaceHolder cnt1 = new ContentPlaceHolder();
        cnt1 = (System.Web.UI.WebControls.ContentPlaceHolder)sourcePage.Form.FindControl("ContentPlaceHolder1");

        string ControlName = ((System.Web.UI.WebControls.BaseValidator)source).ControlToValidate;
        string ValidatorName = ((System.Web.UI.Control)source).ID;
        TextBox txtControl = ((System.Web.UI.WebControls.TextBox)cnt1.FindControl(ControlName));
        CustomValidator cstmValidator = ((System.Web.UI.WebControls.CustomValidator)cnt1.FindControl(ValidatorName));

        // get control that called this
        //var ControlName = source.controltovalidate;
        // get custom validator name
        //var ControlValidatorName = source.id;
        string TextValue = txtControl.Text;
        int len, i, key, chk;
        len = TextValue.Length;
        //  alert (TextValue.length);
        if (len == 0)
        {
            args.IsValid = false;
            txtControl.BackColor = Color.Wheat;
            sourcePage.SetFocus(txtControl);
            cstmValidator.ErrorMessage = "Required";
        }
        else if (len > 0)
        {
            chk = 0;
            for (i = 0; i < len; i++)
            {
                key = (int)Encoding.ASCII.GetBytes(TextValue.Substring(i, i + 1))[0];
                if ((key > 64 && key < 91) || (key > 96 && key < 123))
                {
                    break;
                }
                else if (key >= 0 && key <= 9)
                {
                    chk = chk + 1;
                }
            }
            if (chk == len)
            {
                args.IsValid = false;
                txtControl.BackColor = Color.Wheat;
                sourcePage.SetFocus(txtControl);
                cstmValidator.ErrorMessage = "Invalid";
            }
            else
            {
                args.IsValid = true;
                txtControl.BackColor = Color.White;
                cstmValidator.ErrorMessage = "";
            }
        }
        else
        {
            args.IsValid = true;
            txtControl.BackColor = Color.White;
            cstmValidator.ErrorMessage = "";
        }
        return args.IsValid;
    }
}
