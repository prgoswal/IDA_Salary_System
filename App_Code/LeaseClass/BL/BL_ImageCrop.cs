using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BL_ImageCrop
/// </summary>
public class BL_ImageCrop
{
	public BL_ImageCrop()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    DL_ImageCrop objdl = new DL_ImageCrop();
    public DataTable GetScanningFile(int Ind, decimal ServiceNo)
    {
        DataTable dt = new DataTable();
       dt= objdl.GetScanningFile(Ind, ServiceNo);
       return dt;
    }
    public DataTable ddlFillDocumentType(int Ind)
    {
        DataTable dt = new DataTable();
        dt = objdl.ddlFillDocumentType(Ind);
        return dt;
    }
}