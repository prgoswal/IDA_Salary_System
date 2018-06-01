using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_CaseMaster
/// </summary>
public class PL_CaseMaster
{
	public PL_CaseMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int CaseTypeCode { get; set; }
    public string CaseTypeNmE { get; set; }
    public string CaseTypeNmH { get; set; }
    public int EntryUserCode { get; set; }
}