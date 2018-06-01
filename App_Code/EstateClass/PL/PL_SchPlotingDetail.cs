using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PL_SchPlotingDetail
/// </summary>
public class PL_SchPlotingDetail
{
	public PL_SchPlotingDetail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public  DataTable dt = new DataTable();

    public int Ind { get; set; }
    public int SchCode { get; set;}
    public int EntryUserCode { get; set; }
}