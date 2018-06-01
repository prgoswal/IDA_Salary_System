using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PL_SchAreaDetail
/// </summary>
public class PL_SchAreaDetail
{
    public PL_SchAreaDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable dt = new DataTable();
    public int Ind { get; set; }
    public int SchCode { get; set; }
    public string SchName { get; set; }
    public Int32 CityCode { get; set; }
    public int FacilityCode { get; set; }
    public decimal FacilityAreaSqYard { get; set; }
    public decimal FacilityAreaSqMeter { get; set; }
    public string FacilityAreaString { get; set; }
    public int UserID { get; set; }

}