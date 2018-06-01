using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_Scheme
/// </summary>
public class PL_Scheme
{
	public PL_Scheme()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      public  int Ind{get;set;}
      public Int64 CityCode { get; set; }
      public int SchCodeOdp{get;set;}
      public string SchNameE{get;set;}
      public string SchNameH {get;set;}
      public string Location{get;set;}
      public int SchUseCode{get;set;}
      public string SchNoDesc{get;set;}
      public int DevCtyID{get;set;}
      public int DevloperID{get;set;}
      public string Aprno{get;set;}
     public string AprDate{get;set;}
     public string AprName{get;set;}
     public int ActiveInd{get;set;}
     public int EntryUserID { get; set; }
     public decimal TotalSchAreaSqYard{get;set;}
     public decimal TotalSchAreaSqMeter{get;set;}
     public string TotalSchAreaString{get;set;}
      public decimal TotalPlotingAreaSqyard{get;set;}
     public decimal TotalPlotingAreaSqMeter{get;set;}
     public string TotalPlotingAreaString { get; set; }
     public int SectorAval { get; set; }
     public int PlotAval { get; set; }
     public int IDASchNo { get;set; }
}