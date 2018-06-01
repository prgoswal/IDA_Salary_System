using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_CaseStage
/// </summary>
public class PL_CaseStage
{
	public PL_CaseStage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int CaseStageCode { get; set; }
    public string CaseStageDescE { get; set; }
    public string CaseStageDescH { get; set; }
    public string EntryDate { get; set; }
    public int EntryUserCode { get; set; }
}