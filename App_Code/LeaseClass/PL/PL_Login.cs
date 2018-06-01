using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PL_Login
/// </summary>
public class PL_Login
{
    public PL_Login()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    string _user_id;
    int _city_id;
    string _City_name;
    string _User_name;
    string _Password;

    public string user_id
    {
        get { return _user_id; }
        set { _user_id = value; }
    }
    public int city_id
    {
        get { return _city_id; }
        set { _city_id = value; }
    }
    public string City_name
    {
        get { return _City_name; }
        set { _City_name = value; }
    }
    public string User_name
    {
        get { return _User_name; }
        set { _User_name = value; }
    }
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
}