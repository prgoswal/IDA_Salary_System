using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_CaseHistory
/// </summary>
public class PL_CaseHistory
{
	public PL_CaseHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public string CaseStageDescH { get; set; }
    public int DeptCode { get; set; }
    public string SuitRegNo { get; set; }
    public string SuitRegDate { get; set; }
    public int CityCode { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}