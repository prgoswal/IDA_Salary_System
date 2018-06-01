using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PL_PlotNoAllotment
/// </summary>
public class PL_PlotNoAllotment
{
	public PL_PlotNoAllotment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet AllDs = new DataSet();

    public DataTable dt = new DataTable();
    public DataTable dtfeat = new DataTable();

    public int Ind { get; set; }
    public int SchCode { get; set; }    
    public int PlotTypeCode { get; set; }
    public int PlotSizeCode { get; set; }
    public int SectorCode { get; set; }
    public int EntryUserCode { get; set; }
    public string PlotSize { get; set; }
}