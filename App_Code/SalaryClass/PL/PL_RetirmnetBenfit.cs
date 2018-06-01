using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_RetirmnetBenfit
/// </summary>
public class PL_RetirmnetBenfit
{
    public PL_RetirmnetBenfit()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Ind { set; get; }
    public string CityCode { set; get; }
    public string Month { set; get; }
    public int GraduityTotalMonth { set; get; }
    public string EmpNo { set; get; }
    public decimal BasicAmt { set; get; }
    public decimal GradePayAmt { set; get; }
    public int SelectType { set; get; }
    public string DOJ { set; get; }
    public string DOR { set; get; }
    public int NoOfLeave { set; get; }
    public decimal DaPer { set; get; }
    public decimal PayableAmt { set; get; }
    public decimal DaAmt { set; get; }
    public int NoOfYears { set; get; }
    public int NoOfMonths { set; get; }
    public int NoOfDays { set; get; }
    public string Status { set; get; }

}