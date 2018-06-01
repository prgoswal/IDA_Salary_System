using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_ReplyMaster
/// </summary>
public class PL_ReplyMaster
{
	public PL_ReplyMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int ReplyTypeCode { get; set; }
    public string ReplyTypeDescE { get; set; }
    public string ReplyTypeDescH { get; set; }
    public string EntryDate { get; set; }
    public int EntryUserCode { get; set; }
}