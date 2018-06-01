using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class PL_PFCharges
{
    public int Ind { set; get; }
    public int CityCode { set; get; }
    public string month { set; get; }
    public int EmpNo { set; get; }
    public decimal Basic { set; get; }
    public decimal Grade { set; get; }
    public decimal DA { set; get; }
    public decimal PF { set; get; }
    public decimal AdminCharge { set; get; }
    public int SalTypeInd { set; get; }
}