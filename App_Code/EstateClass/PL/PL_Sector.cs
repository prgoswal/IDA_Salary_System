using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PL_Sector
/// </summary>
public class PL_Sector
{
	public PL_Sector()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable dt = new DataTable();
    public int Ind { get; set;}
    public Int64 CityCode { get; set;}
    public int SchCode{get;set;}
    public int PlotTypeCode{get;set;}
    public string Sector{get;set;}
    public Int64 UserID { get; set;}   
}