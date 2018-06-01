using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_GenerateServiceNo
/// </summary>
public class PL_GenerateServiceNo
{
	public PL_GenerateServiceNo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CityCode { get; set; }
    public string PostFix2 { get; set; }
    public int Ind { get; set; }
    public int Useid { get; set; }
    public int AscciPre { get; set; }
    public int AscciPost { get; set; }
    public int NPlotNo { get; set; }
    public int PassId { get; set; }
    public String PreFix { get; set; }
    public String PostFix { get; set; }
    public String PlotNo { get; set; }
    public int Zoneid { get; set; }
    public int Diff { get; set; }
    public int SchDevTypeid { get; set; }
    public int Schid { get; set; }
    public int Sectorid { get; set; }
    public int EffectedRows { get; set; }
    public Int64 ServiceNo { get; set; }
    public Int16 PlotUseId { get; set; }
    public Int64 OutPutVal { get; set; }
}