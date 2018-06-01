using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IDACommonAdminAPI.Models
{
    public class Connection
    {
        static SqlConnection con;
       public static SqlCommand cmd;
       public static SqlDataAdapter da;

        public static SqlConnection SetConnection()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch
            {
                con.Close();
                return con;
            }
        }
    }
}