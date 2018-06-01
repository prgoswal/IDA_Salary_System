using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsMenus
/// </summary>
public class ClsMenus
{
    public List<MainMenu> MenusDetails { get; set; }
}

public class Sml2
{
    public int SubMenuL2Code { get; set; }
    public int SubMenuL1Code { get; set; }
    public int MenuCode { get; set; }
    public int CityCode { get; set; }
    public int OrgCode { get; set; }
    public int Systemcode { get; set; }
    public string SubMenuL2Name { get; set; }
    public string LinkUrl { get; set; }
}

public class Sml1
{
    public int SubMenuL1Code { get; set; }
    public int MenuCode { get; set; }
    public int CityCode { get; set; }
    public int OrgCode { get; set; }
    public int Systemcode { get; set; }
    public string SubMenuL1Name { get; set; }
    public string LinkUrl { get; set; }
    public List<Sml2> sml2 { get; set; }
}

public class MainMenu
{
    public int MenuCode { get; set; }
    public int CityCode { get; set; }
    public int OrgCode { get; set; }
    public int Systemcode { get; set; }
    public string MenuName { get; set; }
    public string LinkUrl { get; set; }
    public List<Sml1> sml1 { get; set; }
}