using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_Organization
/// </summary>
public class PL_Organization
{
	public PL_Organization()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrganizationCode { get; set; }
    public int CityCode { get; set; }
    public string OrganizationNameE { get; set; }
    public string OrganizationNameH { get; set; }
    public string OrganizationAddress { get; set; }
    public string ContactPer1Name { get; set; }
    public string ContactPer1Mobile { get; set; }
    public string ContactPer1Email { get; set; }
    public string ContactPer1Desg { get; set; }
    public string ContactPer2Name { get; set; }
    public string ContactPer2Mobile { get; set; }
    public string ContactPer2Email { get; set; }
    public string ContactPer2Desg { get; set; }
        
}