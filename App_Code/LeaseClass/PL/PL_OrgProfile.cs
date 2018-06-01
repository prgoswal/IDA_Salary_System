using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_OrgProfile
/// </summary>
public class PL_OrgProfile
{
	public PL_OrgProfile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int ZoneAppliInd { get; set; }
    public int WardAppliInd { get; set; }
    public int DevCateInd { get; set; }
    public int DevNameAppliInd { get; set; }
    public int EntryUserId { get; set; }
}