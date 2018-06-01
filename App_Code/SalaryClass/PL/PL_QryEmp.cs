using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class PL_QryEmp
{
    public int Ind { get; set; }
    public string FirstName { get; set; }
    public string FHName { get; set; }
    public int EmpNo { get; set; }
    public int DeptCd { get; set; }
    public int SrNo { get; set; }
    public string Dob { get; set; }
    public int DesignationCD { get; set; }
    public int CityCode { get; set; }
    public int SubSrNo { get; set; }
    public string month { get; set; }
    public DataTable dt = new DataTable();
}