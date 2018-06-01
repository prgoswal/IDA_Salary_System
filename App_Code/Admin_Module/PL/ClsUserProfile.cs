using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProfile
/// </summary>
public class ClsUserProfile
{
    public int Ind { get; set; }
    public int LevelId { get; set; }
    public string LevelDesc { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public string EntryDate { get; set; }
    public int EntryUserCode { get; set; }
}
public class Response
{
    public int Code { get; set; }
    public string msg { get; set; }
    public string data { get; set; }
}

public class ClsProfileSystem
{
    public int Ind { get; set; }
    public int OrgCode { get; set; }
    public int CityCode { get; set; }
    public int EntryUserCode { get; set; }
    public int SystemCode { get; set; }
}