using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BL_StickerPrint
/// </summary>
public class BL_StickerPrint
{
	public BL_StickerPrint()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    DL_StickerPrint objdl = new DL_StickerPrint();
    public DataTable GetServiceNo(PL_StickerPrint objpl) 
    {
        DataTable dt = new DataTable();
        dt = objdl.GetServiceNo(objpl);
        return dt;
    }

    public DataTable GetMultiServiceNo(PL_StickerPrint objpl) 
    {
        DataTable dt = new DataTable();
        dt = objdl.GetMultiServiceNo(objpl);
        return dt;
    }
}