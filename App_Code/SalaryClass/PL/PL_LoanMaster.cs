using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class PL_LoanMaster
{
    public int Ind { get; set; }
    public Int64 CityCode { get; set; }
    public Int64 LoanCd { get; set; }
    public Int32 Edcd { get; set; }
    public string LoanDesc { get; set; }
    public string Avrdesc { get; set; }
    public decimal IntRate { get; set; }
    public int NoOfInst { get; set; }
    public decimal LoanAmtRange1 { get; set; }
    public decimal LoanAmtRange2 { get; set; }
}