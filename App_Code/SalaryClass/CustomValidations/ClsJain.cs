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

/// <summary>
/// Summary description for ClsJain
/// </summary>
public class ClsJain
{
	public ClsJain()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public object RupeesToWord(object MyNumber)
    {
        object Temp;
        string Rupees;
        string Paisa = "";
        object DecimalPlace;
        object iCount;
        string Hundreds;
        string Words = "";
        string[] place = new string[10];
        place[0] = " Thousand ";
        place[2] = " Lakh ";
        place[4] = " Crore ";
        place[6] = " Arab ";
        place[8] = " Kharab ";

        // Convert MyNumber to a string, trimming extra spaces. 
        MyNumber = (MyNumber.ToString().Trim());

        // Find decimal place. 
        //DecimalPlace = InSt(MyNumber, "."); 
        DecimalPlace = MyNumber.ToString().IndexOf('.');

        // If we find decimal place... 
        if ((Convert.ToDouble(DecimalPlace) + 1) > 0)
        {
            // Convert Paisa                         
            String ABC = (MyNumber.ToString().Substring(Convert.ToInt32(DecimalPlace) + 1) + "00");
            Temp = ABC.Substring(0, 2);
            Paisa = " and " + ConvertTens(Convert.ToString(Temp)) + " Paisa";

            // Strip off paisa from remainder to convert.          
            MyNumber = MyNumber.ToString().Substring(0, (Convert.ToInt32(DecimalPlace) + 1) - 1);
        }

        //=============================================================== 
        string TM;
        // If MyNumber between Rs.1 To 99 Only. 
        int ABHIS = MyNumber.ToString().Length - 3;
        if (ABHIS < 0)
        {
            TM = MyNumber.ToString();
        }
        else
        {
            TM = MyNumber.ToString().Substring(MyNumber.ToString().Length - 3, 2);
        }


        if ((MyNumber.ToString().Length) > 0 && (MyNumber.ToString().Length) <= 2)
        {
            if ((TM.ToString().Length) == 1)
            {
                Words = Convert.ToString(ConvertDigit(TM));
                return "Rupees " + Words + Paisa + " Only";
            }
            else
            {
                if ((TM.ToString().Length) == 2)
                {
                    Words = ConvertTens(TM);
                    return "Rupees " + Words + Paisa + " Only";
                }
            }
        }
        //=============================================================== 


        // Convert last 3 digits of MyNumber to ruppees in word. 
        int ABHISH = MyNumber.ToString().Length - 3;
        if (ABHISH < 0)
        {
            Hundreds = ConvertHundreds("0");
        }
        else
        {
            Hundreds = ConvertHundreds(MyNumber.ToString().Substring(MyNumber.ToString().Length - 3));
        }


        // Strip off last three digits                         
        int ABHISHE = MyNumber.ToString().Length - 3;
        if (ABHISHE < 0)
        {
            MyNumber = MyNumber.ToString();
        }
        else
        {
            MyNumber = MyNumber.ToString().Substring(0, MyNumber.ToString().Length - 3);
        }

        iCount = 0;
        while (MyNumber.ToString() != "")
        {
            //Strip last two digits 
            //Temp = Right(MyNumber, 2); 
            int ABHI = MyNumber.ToString().Length - 2;

            if (ABHI < 0)
            {
                Temp = MyNumber;
            }
            else
            {
                Temp = MyNumber.ToString().Substring(MyNumber.ToString().Length - 2);
            }

            if ((MyNumber.ToString().Length) == 1)
            {
                //if ((Words.Trim()) == "Thousand" || Words.Trim() == "Lakh Thousand" || (Words.Trim()) == "Lakh" || Words.Trim() == "Crore" || Words.Trim() == "Crore Lakh Thousand" || Words.Trim() == "Arab Crore Lakh Thousand" || Words.Trim() == "Arab" || Words.Trim() == "Kharab Arab Crore Lakh Thousand" || Words.Trim() == "Kharab") 
                if ((Words.Trim()) == "Thousand" ||
                     Words.Trim() == "Lakh Thousand" ||
                     (Words.Trim()) == "Lakh" ||
                     Words.Trim() == "Crore" ||
                     Words.Trim() == "Crore Lakh Thousand" ||
                     Words.Trim() == "Arab Crore Lakh Thousand" ||
                     Words.Trim() == "Arab" ||
                     Words.Trim() == "Kharab Arab Crore Lakh Thousand" ||
                     Words.Trim() == "Kharab")
                {
                    Words = ConvertDigit(Convert.ToString(Temp)) + place[Convert.ToInt32(iCount)];
                    MyNumber = MyNumber.ToString().Substring(0, MyNumber.ToString().Length - 1);
                }
                else
                {
                    Words = ConvertDigit(Convert.ToString(Temp)) + place[Convert.ToInt32(iCount)] + Words;
                    MyNumber = MyNumber.ToString().Substring(0, MyNumber.ToString().Length - 1);
                }
            }
            else
            {

                if (Words.Trim() == "Thousand" || Words.Trim() == "Lakh Thousand" || Words.Trim() == "Lakh" || Words.Trim() == "Crore" || Words.Trim() == "Crore Lakh Thousand" || Words.Trim() == "Arab Crore Lakh Thousand" || Words.Trim() == "Arab")
                {
                    Words = ConvertTens(Convert.ToString(Temp)) + place[Convert.ToInt32(iCount)];
                    MyNumber = MyNumber.ToString().Substring(0, MyNumber.ToString().Length - 2);
                }
                else
                {
                    //================================================================= 
                    // if only Lakh, Crore, Arab, Kharab 
                    object F, S;
                    F = ConvertTens(Convert.ToString(Temp)).ToString().Trim();
                    S = place[Convert.ToInt32(iCount)];

                    //if ((ConvertTens(Convert.ToString(Temp)).ToString().Trim() + place[Convert.ToInt32(iCount)]) == "Lakh" || (ConvertTens(Convert.ToString(Convert.ToString(Temp))).ToString().Trim() + place[Convert.ToInt32(iCount)]) == "Crore" || (ConvertTens(Convert.ToString(Temp)).ToString().Trim() + place[Convert.ToInt32(iCount)]) == "Arab")
                    if ((F.ToString() + S.ToString()) == "Lakh" || (F.ToString() + S.ToString()) == "Crore" || (F.ToString() + S.ToString()) == "Arab")
                    {
                        Words = Words.ToString();
                        MyNumber = MyNumber.ToString().Substring(0, MyNumber.ToString().Length - 2);
                    }
                    else
                    {
                        Words = ConvertTens(Convert.ToString(Temp)) + place[Convert.ToInt32(iCount)] + Words;
                        MyNumber = MyNumber.ToString().Substring(0, MyNumber.ToString().Length - 2);
                    }
                }
            }

            iCount = Convert.ToUInt32(iCount) + 2;
        }
        return "Rupees " + Words + Hundreds + Paisa + " Only";

    }


    private String ConvertHundreds(String MyNumber)
    {
        string Result = "";

        // Exit if there is nothing to convert. 
        if (Convert.ToDouble(MyNumber) == 0)
            return "";

        // Append leading zeros to number. 
        String XYZ = ("000" + MyNumber);
        MyNumber = XYZ.Substring(XYZ.Length - 3);


        // Do we have a hundreds place digit to convert? 
        if (MyNumber.Substring(0, 1) != "0")
        {
            Result = ConvertDigit(MyNumber.ToString().Substring(0, 1)) + " Hundreds ";
        }


        // Do we have a tens place digit to convert? 
        if (MyNumber.ToString().Substring(2, 1) != "0")
        {
            Result = Result + ConvertTens(MyNumber.ToString().Substring(1, 2));
        }
        else
        {
            // If not, then convert the ones place digit. 
            Result = Result + ConvertDigit(MyNumber.ToString().Substring(MyNumber.ToString().Length - 3));
        }

        //return Strings.Trim(Result); 
        return Result.ToString().Trim();
    }


    private String ConvertTens(String MyTens)
    {
        string Result = "";

        // Is value between 10 and 19? 
        if (Convert.ToDouble(MyTens.ToString().Substring(0, 1)) == 1)
        {
            switch (Convert.ToInt32(MyTens))
            {
                case 10:
                    Result = "Ten";
                    break;
                case 11:
                    Result = "Eleven";
                    break;
                case 12:
                    Result = "Twelve";
                    break;
                case 13:
                    Result = "Thirteen";
                    break;
                case 14:
                    Result = "Fourteen";
                    break;
                case 15:
                    Result = "Fifteen";
                    break;
                case 16:
                    Result = "Sixteen";
                    break;
                case 17:
                    Result = "Seventeen";
                    break;
                case 18:
                    Result = "Eighteen";
                    break;
                case 19:
                    Result = "Nineteen";
                    break;
                default:
                    break;
            }
        }
        else
        {
            // .. otherwise it's between 20 and 99. 
            switch (Convert.ToInt32(MyTens.ToString().Substring(0, 1)))
            {
                case 2:
                    Result = "Twenty ";
                    break;
                case 3:
                    Result = "Thirty ";
                    break;
                case 4:
                    Result = "Forty ";
                    break;
                case 5:
                    Result = "Fifty ";
                    break;
                case 6:
                    Result = "Sixty ";
                    break;
                case 7:
                    Result = "Seventy ";
                    break;
                case 8:
                    Result = "Eighty ";
                    break;
                case 9:
                    Result = "Ninety ";
                    break;
                default:
                    break;
            }

            // Convert ones place digit. 
            Result = Result + ConvertDigit(MyTens.ToString().Substring(MyTens.ToString().Length - 1, 1));

        }
        return Result;

    }

    private object ConvertDigit(String MyDigit)
    {
        object functionReturnValue = null;
        switch (Convert.ToInt32(MyDigit))
        {
            case 1:
                functionReturnValue = "One";
                break;
            case 2:
                functionReturnValue = "Two";
                break;
            case 3:
                functionReturnValue = "Three";
                break;
            case 4:
                functionReturnValue = "Four";
                break;
            case 5:
                functionReturnValue = "Five";
                break;
            case 6:
                functionReturnValue = "Six";
                break;
            case 7:
                functionReturnValue = "Seven";
                break;
            case 8:
                functionReturnValue = "Eight";
                break;
            case 9:
                functionReturnValue = "Nine";
                break;
            default:
                functionReturnValue = "";
                break;
        }
        return functionReturnValue;
    }

}
