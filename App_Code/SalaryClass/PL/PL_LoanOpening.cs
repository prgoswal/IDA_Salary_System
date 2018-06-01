using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class PL_LoanOpening
{
    public DataTable dtEmp = new DataTable();
    public int ind { set; get; }
    public int CityCode { set; get; }
    public int MonthCd { set; get; }
    public int FinYear { set; get; }
    public int EmpNo { set; get; }
    public int LoanCd { set; get; }
    public string LoanSenctionDate { set; get; }
    public decimal ActualLoanAmt { set; get; }
  
    public decimal IntrestRate { set; get; }
    public decimal InterstAmt { set; get; }
    public decimal MonthlyInstalment { set; get; }
    public decimal NoOfInstalment { set; get; }
    public string Month { set; get; }
    public string UserId { set; get; }
    public int Vno { set; get; }
    public string RefNo { set; get; }
  
    public string Narration { set; get; }
    public int DeductionMonth { set; get; }
}