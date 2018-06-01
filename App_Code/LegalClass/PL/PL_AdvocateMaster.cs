using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_AdvocateMaster
/// </summary>
public class PL_AdvocateMaster
{
	public PL_AdvocateMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int AdvocateCode { get; set; }
    public string AdvocateNmE { get; set; }
    public string AdvocateNmH { get; set; }
    public string AdvoAddress { get; set; }
    public string AdvoQualification { get; set; }
    public string AdvoPanel { get; set; }
    public string TelNo { get; set; }
    public string MobileNo { get; set; }
    public string AadharNo { get; set; }
    public int ActiveCode { get; set; }
    public int EntryUserCode { get; set; }
    public string AppointmentDt { get; set; }
    public int AdvocateTypeId { get; set; }
}