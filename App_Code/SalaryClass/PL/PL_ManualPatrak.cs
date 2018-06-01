using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PL_ManualPatrak
/// </summary>
public class PL_ManualPatrak
{
    public PL_ManualPatrak()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int flag { get; set; }
    public int CityCode { get; set; }
    public int EmpNo { get; set; }
    public string EffectiveMonth { get; set; }
    public string Month { get; set; }
    public int MonthCd { get; set; }
    public int UserId { get; set; }
    public decimal SuspendLeave { get; set; }
    public decimal TotalNoOfLeave { get; set; }
    public DataTable dt_Grid = new DataTable();
    
}