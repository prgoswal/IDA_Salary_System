using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_RegisterComplain
/// </summary>
public class PL_RegisterComplain
{
	public PL_RegisterComplain()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set; }
    public int DepartmentCode { get; set; }
    public int ServiceMatterCode { get; set; }
    public int SchemeCode { get; set; }
    public string PlotNo { get; set; }
    public int IdaRefNo { get; set; }
    public int InwardType { get; set; }
    public int ServiceNo { get; set; }
    public int ServiceCode { get; set; }
    public string ComplainerName { get; set; }
    public string MobileNo { get; set; }
    public string AadhaarNo { get; set; }
    public string PhotoPhysicalPath { get; set; }
    public string PhotoHttpPath { get; set; }
    public string PhotoExt { get; set; }
    public int AllDocAttach { get; set; }
    public int EntryUserCode { get; set; }
    public int InwardNo { get; set; }
    public DataTable Dtdocs { get; set; }
    public string Remark { get; set; }

}