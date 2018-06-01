using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_StickerPrint
/// </summary>
public class PL_StickerPrint
{
	public PL_StickerPrint()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Ind { get; set; }
    public int RecvCode { get; set; }
    public string RecvDate { get; set; }
    public decimal IDARefNo { get; set; }
    public decimal ServiceNo { get; set; }
    public int SchCode { get; set; }
    public int EntryUserCode { get; set; }
    public decimal ServiceNoFrom { get; set; }
    public decimal ServiceNoTo { get; set; } 
}