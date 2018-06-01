using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_BankTextFileCreation
/// </summary>
public class PL_BankTextFileCreation
{
    public PL_BankTextFileCreation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //string _ErrorMsg;
    //DataSet _Ds;
    //DataTable _Dt;
    //int _Flag;
    //int _TextFileType;
    //string _MOnth;
    //string _CityCode;
    //string _BnkCd;
    //string _BrCd;
    //string _LotNoF;
    //string _LotNoTo;
    //string _Zone;
    //string _Ward;
    //string _DeptCd;
    //string _SubDeptCd;
    //public string ErrorMsg
    //{
    //    get { return _ErrorMsg; }
    //    set { _ErrorMsg = value; }
    //}
    //public DataSet Ds_global
    //{
    //    get { return _Ds; }
    //    set { _Ds = value; }
    //}

    //public DataTable Dt_global
    //{
    //    get { return _Dt; }
    //    set { _Dt = value; }
    //}

    public int TextFileType { get; set; }
    public string Narration { get; set; }

    public int Flag { get; set; }
  
    public string MOnth  { get; set;  }
    public string CityCode
    {
        get;
        set;
    }
    public string BnkCd
    {
        get;
        set;
    }
    public string BrCd
    {
        get;
        set;
    }
    public string LotNoF
    {
        get;
        set;
    }
    public string LotNoTo
    {
        get;
        set;
    }
    public string Zone
    {
        get;
        set;
    }
    public string Ward
    {
        get;
        set;
    }
    public string DeptCd
    {
        get;
        set;
    }
    public string SubDeptCd
    {
        get;
        set;
    }
    public string LoanCode
    {
        get;
        set;
    }

    public string ClassInd
    {
        get;
        set;
    }

    public string EmpType
    {
        get;
        set;
    }
}
