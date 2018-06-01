using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_DepartmentService
/// </summary>
public class PL_DepartmentService
{
	public PL_DepartmentService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Ind { get; set; }
    public int ServiceCode { get; set; }
    public int DepartCode { get; set; }
    public string ServiceDescE { get; set; }
    public string ServiceDescH { get; set; }
    public string ServiceOtherDesc1 { get; set; }
    public string ServiceOtherDesc2 { get; set; }
    public int ActiveInd { get; set; }
}