using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_DepartmentServiceMatter
/// </summary>
public class PL_DepartmentServiceMatter
{
	public PL_DepartmentServiceMatter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Ind { get; set; }
    public int MatterCode { get; set; }
    public int DepartCode { get; set; }
    public int ServiceCode { get; set; }
    public int ActiveInd { get; set; }
    public string MatterDescE { get; set; }
    public string MatterDescH { get; set; }
    public string MatterOtherDesc1 { get; set; }
    public string MatterOtherDesc2 { get; set; }
}