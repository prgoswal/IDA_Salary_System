using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BL_DisplayImage
/// </summary>
public class BL_DisplayImage
{
	public BL_DisplayImage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    DL_DisplayImage objdl = new DL_DisplayImage();
    public DataTable GetScanningFile(int Ind, decimal ServiceNo)
    {
        DataTable dt = new DataTable();
        dt = objdl.GetScanningFile(Ind, ServiceNo);
        return dt;
    }
    public DataTable ddlFillDocumentType(int Ind)
    {
        DataTable dt = new DataTable();
        dt = objdl.ddlFillDocumentType(Ind);
        return dt;
    }
}