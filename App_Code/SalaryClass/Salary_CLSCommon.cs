using System;
using OdpERPSystem.Salary.App_Code;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;




/// <summary>
/// Summary description for CLSCommon
/// </summary>
public class Salary_CLSCommon
{
    public Salary_CLSCommon()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static String EncodePassword(String Pwd)
    {
        int Calc = 0; String FnlStr = "";
        for (int i = 1; i <= Pwd.Length; i++)
        {
            if (i < 2)
            {
                Calc = 100;
            }
            else if (i < 4)
            {
                Calc = 200;
            }
            else if (i < 6)
            {
                Calc = 300;
            }
            else if (i < 8)
            {
                Calc = 400;
            }
            else if (i < 10)
            {
                Calc = 500;
            }
            byte[] bt = Encoding.ASCII.GetBytes(Pwd.ToString().Substring(i - 1, 1));
            FnlStr = FnlStr + Convert.ToInt32(bt[0] + Calc + i).ToString();
        }
        return FnlStr;
    }

    public static String DecodePassword(String Pwd)
    {
        int Calc = 0; String FnlStr = "";
        int i = 1; int j = 1; int A = 0; byte[] bt; String Str = ""; ;
        while (i <= Pwd.Length)
        {
            if (j < 2)
            {
                Calc = 100;
            }
            else if (j < 4)
            {
                Calc = 200;
            }
            else if (j < 6)
            {
                Calc = 300;
            }
            else if (j < 8)
            {
                Calc = 400;
            }
            else if (j < 10)
            {
                Calc = 500;
            }
            A = Convert.ToInt32(Pwd.ToString().Substring(i - 1, 3)) - Calc - j;
            bt = new byte[1];
            bt[0] = (byte)A;
            Str = Encoding.ASCII.GetString(bt);
            FnlStr = FnlStr + Str;
            i = i + 3;
            j++;
        }
        return FnlStr;
    }

    public static DataSet CallApiGet(string URL)
    {
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlSalary"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var uri = URL;
            var response = HClient.GetAsync(URL).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
            DataSet ds = new DataSet();
            ds = JsonConvert.DeserializeObject<DataSet>(a);
            //ds.ReadXml(new XmlTextReader(new StringReader(a)));
            //DataTable dt = JsonConvert.DeserializeObject<DataTable>(a);
            return ds;
        }
        catch
        {
            DataSet ds;
            return ds = null;
        }
    }

    public static DataTable ApiPostDataTable(string URL, object obj)
    {
        DataTable dt;

        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlSalary"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = URL;
            var response = HClient.PostAsJsonAsync(uri, obj).Result;

            var resData = response.Content.ReadAsStringAsync().Result.ToString();
            dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(resData);
            return dt;
        }

        catch
        {
            dt = new DataTable();
            return dt;
        }
    }

    public static DataTable NewApiPostDataTable(string URL, object obj)
    {
        DataTable dt;

        try
        {
            HttpClient HClient = new HttpClient();
            //HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlSalary"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = URL;
            var response = HClient.PostAsJsonAsync(uri, obj).Result;

            var resData = response.Content.ReadAsStringAsync().Result.ToString();
            dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(resData);
            return dt;
        }

        catch
        {
            dt = new DataTable();
            return dt;
        }
    }

    public static DataTable CallApiGetdt(string URL)
    {
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlSalary"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var uri = URL;
            var response = HClient.GetAsync(URL).Result;
            var a = response.Content.ReadAsStringAsync().Result.ToString();
            DataTable dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(a);
            //ds.ReadXml(new XmlTextReader(new StringReader(a)));
            //DataTable dt = JsonConvert.DeserializeObject<DataTable>(a);
            return dt;
        }
        catch
        {
            DataTable dt;
            return dt = null;
        }
    }




    public static DataSet ApiPostDataSet(string URL, object obj)
    {
        DataSet ds;
        try
        {
            HttpClient HClient = new HttpClient();
            HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlSalary"].ToString());
            HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = URL;
            var response = HClient.PostAsJsonAsync(uri, obj).Result;

            var resData = response.Content.ReadAsStringAsync().Result.ToString();
            ds = new DataSet();
            ds = JsonConvert.DeserializeObject<DataSet>(resData);
            return ds;
        }
        catch (Exception)
        {
            ds = new DataSet();
            return ds;
        }
    }

    public static void CommonCheckSession()
    {
        if (HttpContext.Current.Session["UserCode"] == null || HttpContext.Current.Session["UserCode"] == "" || HttpContext.Current.Session["UserCode"] == "0" ||
             HttpContext.Current.Session["CityCode"] == null || HttpContext.Current.Session["CityCode"] == "" || HttpContext.Current.Session["CityCode"] == "0" ||
            HttpContext.Current.Session["OrgCode"] == null || HttpContext.Current.Session["OrgCode"] == "" || HttpContext.Current.Session["OrgCode"] == "0"

            )
        {
            HttpContext.Current.Response.Redirect("~/Login.aspx");
        }
    }

    public static bool CheckFinancialYrDate(string selectedDate, string startDate, string endDate)
    {
        try
        {
            DateTime EndDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", null);
            DateTime StartDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", null);
            DateTime SelectDate = DateTime.ParseExact(selectedDate, "dd/MM/yyyy", null);
            DateTime CurrentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (SelectDate > EndDate || SelectDate < StartDate || SelectDate > CurrentDate)
            {
                return false;
            }
            else return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string ConvertToDate(string Date)
    {
        try
        {
            return Date.Substring(6, 4) + "/" + Date.Substring(3, 2) + "/" + Date.Substring(0, 2);
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public static string ConvertDateDB(string Date)
    {
        try
        {
            if (Date.Substring(0, 10) == "01-01-1900" || Date.Substring(0, 10) == "01/01/1900")
            {
                return "";
            }
            Date = Convert.ToDateTime(Date).ToString("dd/MM/yyyy");
            Date = Date.Replace("-", "/");
            return Date;
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public static decimal ConvertDecimalZero(string val)
    {
        decimal convertTo;
        try
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            convertTo = Convert.ToDecimal(val);
            return convertTo;
        }
        catch
        {
            return 0;
        }
    }

    public static int ConvertIntZero(object val)
    {
        int convertTo;
        try
        {
            if (val == string.Empty)
            {
                return 0;
            }
            convertTo = Convert.ToInt32(val);
            return convertTo;
        }
        catch
        {
            return 0;
        }
    }

    #region : Add for Profile Creation

    public static String GSTINFORMAT_REGEX = "[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Z]{1}[0-9a-zA-Z]{1}";
    public static String GSTN_CODEPOINT_CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    Regex r = new Regex(GSTINFORMAT_REGEX, RegexOptions.IgnoreCase);
    public static Boolean checkPattern(String inputval, String regxpatrn)
    {
        Regex r = new Regex(GSTINFORMAT_REGEX, RegexOptions.IgnoreCase);
        // Match the regular expression pattern against a text string.
        Match m = r.Match(inputval);
        return m.Success;

    }
    private static Boolean verifyCheckDigit(String gstinWCheckDigit)
    {
        Boolean isCDValid = false;
        String newGstninWCheckDigit = getGSTINWithCheckDigit(gstinWCheckDigit.Substring(0, gstinWCheckDigit.Length - 1));

        if (gstinWCheckDigit.Trim().Equals(newGstninWCheckDigit))
        {
            isCDValid = true;
        }
        return isCDValid;
    }
    public static Boolean validGSTIN(String gstin)
    {
        Boolean isValidFormat = false;
        if (checkPattern(gstin, GSTINFORMAT_REGEX))
        {

            isValidFormat = verifyCheckDigit(gstin);
        }
        return isValidFormat;

    }

    public static bool gstinvalid(string GSTIN, string stateid, string PANNo)
    {
        string statevalue;
        if (GSTIN.Count() == 15)
        {
            if (stateid.Length == 1)
            {
                statevalue = "0" + Convert.ToString(stateid);
            }
            else
            {
                statevalue = Convert.ToString(stateid);
            }
            if (!string.IsNullOrEmpty(GSTIN))
            {
                string firsttwo = GSTIN.Substring(0, 2);
                string nextten = GSTIN.Substring(2, 10).ToUpper();

                if (statevalue != firsttwo)
                {

                    return false;
                }
                if (!string.IsNullOrEmpty(PANNo))
                {
                    if (PANNo != nextten)
                    {
                        return false;
                    }
                }
                else
                {

                }
            }
        }
        else
        {

            return false;
        }
        return true;
    }

    public static String getGSTINWithCheckDigit(String gstinWOCheckDigit)
    {
        int factor = 2;
        int sum = 0;
        int checkCodePoint = 0;
        char[] cpChars;
        char[] inputChars;

        try
        {
            if (gstinWOCheckDigit == null)
            {
                throw new Exception("GSTIN supplied for checkdigit calculation is null");
            }
            cpChars = GSTN_CODEPOINT_CHARS.ToCharArray();
            inputChars = gstinWOCheckDigit.Trim().ToUpper().ToCharArray();

            int mod = cpChars.Length;
            for (int i = inputChars.Length - 1; i >= 0; i--)
            {
                int codePoint = -1;
                for (int j = 0; j < cpChars.Length; j++)
                {
                    if (cpChars[j] == inputChars[i])
                    {
                        codePoint = j;
                    }
                }
                int digit = factor * codePoint;
                factor = (factor == 2) ? 1 : 2;
                digit = (digit / mod) + (digit % mod);
                sum += digit;
            }
            checkCodePoint = (mod - (sum % mod)) % mod;
            String str = gstinWOCheckDigit + cpChars[checkCodePoint];
            return gstinWOCheckDigit + cpChars[checkCodePoint];
        }
        finally
        {
            inputChars = null;
            cpChars = null;
        }
    }

    #endregion

    public static decimal NewConvertDecimalZero(object val)
    {
        decimal convertTo;
        try
        {
            if (val == string.Empty)
            {
                return 0;
            }
            convertTo = Convert.ToDecimal(val);
            return convertTo;
        }
        catch
        {
            return 0;
        }
    }
}