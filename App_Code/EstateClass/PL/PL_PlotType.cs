using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_PlotType
/// </summary>
public class PL_PlotType
{
	public PL_PlotType()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Ind { get; set;}
    public string PlotTypeDesc{get;set;}
    public string PlotTypeShortDesc{get;set;}
    public int ActiveInd { get; set; }
}