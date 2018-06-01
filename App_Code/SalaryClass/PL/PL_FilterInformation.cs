using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class PL_FilterInformation
{


    public string SelectStringParameter { set; get; }
    public string FilterStringParameter { set; get; }
    public string OrderByStringParameter { set; get; }

    
    public int Ind { set; get; }
    public int CityCode { set; get; }
    public int MonthCd { set; get; }
    public string SelectField { set; get; }
    public string Designation { set; get; }
    public string Grade { set; get; }
    public string Department { set; get; }
    public string Class { set; get; }
    public string Desgcd { set; get; }
    public string DOJ { set; get; }
    public int BefoAft { set; get; }
    public string SuspDFr { set; get; }
    public string SuspDTo { set; get; }
    public int BothFema { set; get; }
    public int Female { set; get; }
    public int Male { set; get; }
    public int Amount { set; get; }
    public int FemaleAmt { set; get; }
    public int MaleAmt { set; get; }
}