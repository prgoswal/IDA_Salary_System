using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_SchSector
/// </summary>
public class PL_SchSector
{
	public PL_SchSector()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int SchCode{get;set;}
    public string SectorDesc{get;set;}
    public int ActiveInd{get;set;}
    public int EntryUser { get; set; }

}
