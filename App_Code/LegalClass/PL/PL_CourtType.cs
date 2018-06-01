using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_CourtType
/// </summary>
public class PL_CourtType
{
	public PL_CourtType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int CourtTypeCode { get; set; }
    public string CourtTypeNameE { get; set; }
    public string CourtTypeNameH { get; set; }
    public string EntryDate { get; set; }
    public int EntryUserCode { get; set; }
}