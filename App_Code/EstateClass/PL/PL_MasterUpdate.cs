using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_MasterUpdate
/// </summary>
public class PL_MasterUpdate
{
	public PL_MasterUpdate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Ind { get; set;}
    public int IDARefNo { get; set;}
    public int ServiceNo { get; set;}
    public decimal PropCost { get; set; }
    public decimal DownPayPer { get; set; }
    public decimal DownPayAmount { get; set; }
    public decimal InstLoanBalAmt { get; set; }
    public decimal EmdAmt { get; set; }
    public decimal InstRegInterestRate { get; set; }
    public string InstStartDate { get; set; }  
}