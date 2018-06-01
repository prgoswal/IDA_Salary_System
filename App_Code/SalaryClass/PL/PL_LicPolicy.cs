using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class PL_LicPolicy
{
    public int Ind { get; set; }
    public decimal EmpNo { get; set; }
    public decimal PolicyNo { get; set; }
    public decimal PolicyAmt { get; set; }
    public Int32 PolicyType { get; set; }
    public string PolicyTypeDese { get; set; }
    public decimal Installment { get; set; }
    public string StartDate { get; set; }
    public string MaturityDate { get; set; }
    public Int32 AutoNo { get; set; }
    public Int32 DivCode { get; set; }
    public string DivCodeDese { get; set; }
    public Int32 Stop { get; set; }
    public Int32 Edcd { get; set; }
    public string EDDesc { get; set; }
    public string Month { get; set; }
    public Int32 citycode { get; set; }
}