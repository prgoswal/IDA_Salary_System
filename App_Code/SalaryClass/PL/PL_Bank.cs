using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_Bank
/// </summary>
public class PL_Bank
{
	public PL_Bank()
	{
		//
		// TODO: Add constructor logic here
		//
	}

       public int Ind { get; set; }
       public Int64 CityCode {get;set;}
       public int BnkCd {get;set;}
       public int BrCd {get;set;}
       public string BankName {get;set;}
       public string BranchName {get;set;}
       public string IFSCCode {get;set;}
       public Int64 AutoNo { get; set; }
}