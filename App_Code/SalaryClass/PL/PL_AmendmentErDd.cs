using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OdpERPSystem.Salary.App_Code
{
    public class PL_AmendmentErDd
    {
        public int Ind { get; set; }
        public Int64 CityCode { get; set; }

        public int DeptCode { get; set; }
        public int DesiCode { get; set; }
        public int ClassCode { get; set; }
        public int EmpType { get; set; }

        public int EmpNo { get; set; }
        public int Edcd { get; set; }
        public string Desc { get; set; }
        public decimal OldAmt { get; set; }
        public decimal NewAmt { get; set; }
        public string Month { get; set; }
        public string NewYN { get; set; }
        public int CarryCode { get; set; }
        public int Posted { get; set; }
        public int ParCur { get; set; }
        public DataTable dt = new DataTable();

    }
}