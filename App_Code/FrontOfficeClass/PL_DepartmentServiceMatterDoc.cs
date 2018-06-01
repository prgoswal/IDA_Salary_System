using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_DepartmentServiceMatterDoc
/// </summary>
public class PL_DepartmentServiceMatterDoc
{
	public PL_DepartmentServiceMatterDoc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int DocumentCode { get; set; }
    public int DepartCode { get; set; }
    public int ServiceCode { get; set; }
    public int MatterCode { get; set; }
    public string DocumentNME { get; set; }
    public string DocumentNMH { get; set; }
    public string DocumentOtherDesc1 { get; set; }
    public string DocumentOtherDesc2 { get; set; }
    public int ActiveInd { get; set; }



}