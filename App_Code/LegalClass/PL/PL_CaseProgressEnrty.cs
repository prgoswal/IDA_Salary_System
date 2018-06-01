using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_CaseProgressEnrty
/// </summary>
public class PL_CaseProgressEnrty
{
	public PL_CaseProgressEnrty()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int SchNo { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
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
    public string FirstHDate { get; set; }
    public int DeptCode { get; set; }
    public decimal Amount { get; set; }
    public int ReplyCode { get; set; }
    public string ReplyDate { get; set; }
    public int CaseStageCode { get; set; }
    public string NextHDate { get; set; }
    public int IsReplyYesNo { get; set; }
    public int OrderCode { get; set; }
    public string OrderDesc { get; set; }
    public string OrderDate { get; set; }
    public string LastDesc { get; set; }
    public string Remarks { get; set; }
    public int EntryUserCode { get; set; }
    public string EntryDate { get; set; }
    public string AdvoName { get; set; }
    public string LetterDate { get; set; }
    public int LetterNo { get; set; }
    public string AdvoAddress { get; set; }
    public string SuitNo { get; set; }
    public string SuitDate { get; set; }
    public string OICName { get; set; }
    public string OICAddress { get; set; }
    public DataTable dt = new DataTable();
    public DataSet ds = new DataSet();
    public string LastDate { get; set; }
}