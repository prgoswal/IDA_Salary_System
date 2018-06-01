using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_SCHMaster
/// </summary>
public class PL_SCHMaster
{
	public PL_SCHMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CCCode { get; set; }
    public int WardNo { get; set; }
    public int city_id { get; set; }
    public string user_id { get; set; }
    public int developer_name_id { get; set; }
    public int zone_id { get; set; }
    public int developer_id { get; set; }
    public int seheme_id { get; set; }
    public int unit_id { get; set; }
    public int unit_id2 { get; set; }
    public int unit_id3 { get; set; }
    public int unit_id4 { get; set; }
    public int ind { get; set; }
    public string SchName { get; set; }
    public string SchShortName { get; set; }
  
    public string schemelocation { get; set; }
    public string approvalno { get; set; }
    public string approval_date { get; set; }
    public string total_area { get; set; }
    public string residental_area { get; set; }
    public string commersial_area { get; set; }
    public string internal_area { get; set; }
}