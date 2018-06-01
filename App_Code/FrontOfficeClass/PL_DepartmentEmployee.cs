using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_DepartmentEmployee
/// </summary>
public class PL_DepartmentEmployee
{
	public PL_DepartmentEmployee()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Ind { get; set; }
    public int EmpDepCode { get; set; }
    public int EmpCode { get; set; }
    public string EmpNameE { get; set; }
    public string EmpNameH { get; set; }
    public int EmpHeadInd { get; set; }
    public int EmpHierarchyCode { get; set; }
    public string EmpHierarchyDesc { get; set; }
    public string EmpMobile { get; set; }
    public string EmpEmail { get; set; }
    public int EmpDesigCD { get; set; }
    public string EmpDesigDescE { get; set; }
    public string EmpDesigDescH { get; set; }
    public int ActiveInd { get; set; }
}