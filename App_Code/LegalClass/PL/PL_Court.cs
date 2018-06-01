using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_Court
/// </summary>
public class PL_Court
{
	public PL_Court()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int CourtCode { get; set; }
    public int CourtTypeCode { get; set; }
    public string CourtNmE { get; set; }
    public string CourtNmH { get; set; }
    public string CourtJudgeNm { get; set; }
    public string CourtPlace { get; set; }
    public string EntryDate { get; set; }
    public int EntryUserCode { get; set; }
}