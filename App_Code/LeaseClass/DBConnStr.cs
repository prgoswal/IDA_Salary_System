using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

namespace LeaseManagementSystemApi.Models
{
    public class DBConnStr
    {
        static SqlConnection con;
        public static SqlConnection setConnString()
        {
            if (Convert.ToInt32(System.Web.HttpContext.Current.Session["ConnDB"]) == 0)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            }
            else if (Convert.ToInt32(System.Web.HttpContext.Current.Session["ConnDB"]) == 1)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connWebSecurity"].ConnectionString);
                System.Web.HttpContext.Current.Session["ConnDB"] = 0;
            }
            if (con != null)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            return con;
        }
    }
    public static class XMLConn
    {
        static FileInfo file;
        public static string Xml_DBFieldsName()
        {
            file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/XML/xml_DBFieldsName.config"));
            return file.FullName;
        }
        public static string Xml_DBParmName()
        {

            file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/XML/xml_DBParmName.config"));
            // file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../XML/xml_DBParmName.config"));
            return file.FullName;
        }
        public static string Xml_LoginPramName()
        {
            file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("./XML/xml_DBParmName.config"));
            return file.FullName;
        }
        public static string Xml_StaticData()
        {
            file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../../XML/xml_StaticData.config"));
            return file.FullName;
        }
        public static string DDMMYY(string Str)
        {

            string[] st = Str.Replace('.', '/').Split('/');

            return st[2] + "/" + st[1] + "/" + st[0];
        }
    }
    //public class XMLMemConn
    //{
    //    static FileInfo file;
    //    public static FileInfo Xml_Member(string UserId)
    //    {
    //        file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../../XMLMember/xml_" + UserId + ".config"));
    //        return file;
    //    }
    //    public static FileInfo Xml_HomeMem(string UserId)
    //    {
    //        file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../XMLMember/xml_" + UserId + ".config"));
    //        return file;
    //    }
    //}
    public class XMLMemConn
    {
        static FileInfo file;
        public static FileInfo Xml_Member(string UserId)
        {
            //file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../../XML_Profile/xml_" + UserId + ".config"));
            //return file;
            file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../XML_Profile/" + UserId + ".config"));
            return file;
        }
        public static FileInfo Xml_HomeMem(string UserId)
        {
            file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../XML_Profile/xml_" + UserId + ".config"));
            return file;
        }
    }
}