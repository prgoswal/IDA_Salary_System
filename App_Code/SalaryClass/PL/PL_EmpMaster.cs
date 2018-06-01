using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PL_EmpMaster
/// </summary>
public class PL_EmpMaster
{
    public PL_EmpMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Ind { set; get; }
    public int CityCode { set; get; }
    public int FormNo { set; get; }
    public int Zone { set; get; }
    public int WardNo { set; get; }
    public int Empno { set; get; }
    public int Sex { set; get; }
    public int EmpType { set; get; }
    public int SalaryTypeInd { set; get; }
    public string Init { set; get; }
    public string LastUpdDt { set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public string FHName { set; get; }
    public string FirstNameH { set; get; }
    public string LastNameH { set; get; }
    public string FhnameH { set; get; }
    public string NomineeName { set; get; }
    public string NomineeRel { set; get; }
    public decimal NomineePer { set; get; }
    public string GPFNomineeName { set; get; }
    public string GPFNomineeRel { set; get; }
    public decimal GPFNomineePer { set; get; }
    public string RefNo { set; get; }
    public int SrNo { set; get; }
    public string SubSrNo { set; get; }
    public int DesgCd { set; get; }
    public int GrdCd { set; get; }
    public int DeptCd1 { set; get; }
    public int DeptCd2 { set; get; }
    public int ClassInd { set; get; }
    public Int64 aadhaarno { set; get; }
    public string VoterId { set; get; }
    public string Ctg { set; get; }
    public string Dob { set; get; }
    public string Doj { set; get; }
    public string Doc { set; get; }
    public string Dop { set; get; }
    public string IncrDt { set; get; }
    public string IstIncremtDesg { set; get; }
    public string IncrDueDt { set; get; }
    public string Add1 { set; get; }
    public string Add2 { set; get; }
    public string Place1 { set; get; }
    public string Place2 { set; get; }
    public string Phone1 { set; get; }
    public string Phone2 { set; get; }
    public int BnkCd { set; get; }
    public int BrCd { set; get; }
    public string BnkAcNo { set; get; }
    public string IFSCCODE { set; get; }
    public int MStatus { set; get; }
    public int FamPlan { set; get; }
    public int NoOfChild { set; get; }
    public int FemalChild { set; get; }
    public string BGroup { set; get; }
    public int Handicapped { set; get; }
    public int HandiPercent { set; get; }
    public int Deputation { set; get; }
    public string DepuDt { set; get; }
    public int RrdtInd { set; get; }
    public string RrdtDt { set; get; }
    public string GpfAcNo { set; get; }
    public string ESICAcNo { set; get; }
    public string UANNO { set; get; }
    public string Qualification { set; get; }
    public Int64 Basic { set; get; }
    public string SupRetDt { set; get; }
    public string Month { set; get; }
    public int NoPtax { set; get; }
    public int NoGpf { set; get; }
    public int AddlGpf { set; get; }
    public int GpfLpDt { set; get; }
    public string GpfRefNo { set; get; }
    public int Schno { set; get; }
    public int SubSchno { set; get; }
    public int RecordNo { set; get; }
    public int OldPay { set; get; }
    public int FesInd { set; get; }
    public string GrihaJila { set; get; }
    public string DepuFrom { set; get; }
    public int PayBillNo { set; get; }
    public string QualifiDetail { set; get; }
    public string DeputationPlace { set; get; }
    public string PanNo { set; get; }
    public int PrivilegeLeave { set; get; }
    public int HafePayLeave { set; get; }
    public string AditionalInfor { set; get; }
    public string ApplicationDate { set; get; }
    public string BasicIncrDt { set; get; }
    public int FixPay { set; get; }
    public int PF12 { set; get; }
    public int GPFIND { set; get; }
    public int Pfind { set; get; }
    public int FPFind { set; get; }
    public int AdminChargeind { set; get; }
    public int PFhigpen { set; get; }
    public DataTable dtTemp = new DataTable(); 
    
}