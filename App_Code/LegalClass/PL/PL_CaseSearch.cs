using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_CaseSearch
/// </summary>
public class PL_CaseSearch
{
	public PL_CaseSearch()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int SearchTypeId { get; set; }
    public string SearchDesc { get; set; }
    public int CityCode { get; set; }
    public string AdvoName { get; set; }
    public int AdvocateCode { get; set; }
    public string PartyName { get; set; }
    public string OICName { get; set; }
    public int EmpNo { get; set; }
    public string FirstHDate { get; set; }

    public int CaseNo { get; set; }
    public int CaseNoOdp { get; set; }
    public string NoticeNo { get; set; }
    public string NoticeDate { get; set; }
    public string SuitRegNo { get; set; }
    public string SuitRegDate { get; set; }
    public int CourtCode { get; set; }
    public string OldSuitRegNo { get; set; }
    public int OldCaseNo { get; set; }
    public string CaseTitle { get; set; }
    public int CaseTypeCode { get; set; }
    public string CaseDesc { get; set; }    
    public int DeptCode { get; set; }
    public decimal Amount { get; set; }
    public int ReplyCode { get; set; }
    public string ReplyDate { get; set; }
    public int CaseStageCode { get; set; }
    public string NextHDate { get; set; }
    public string CourtPlace { get; set; }
    public string fromDate { get; set; }
    public string ToDate { get; set; }
}