using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_MstUse
/// </summary>
public class PL_MstUse
{
	public PL_MstUse()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CityCode { get; set; } 
    public int Ind { get; set; }
    public int UseCode { get; set; }
    public string UseDescE { get; set; }
    public string UseDescH { get; set; }
    public string UseShortName { get; set; }
}