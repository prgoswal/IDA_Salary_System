using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;


    public class DBConnection
    {
        static SqlConnection sqlcon = new SqlConnection();
        static SqlConnection sqlCommoncon = new SqlConnection(); 
        //static SqlConnection sqlcon = new SqlConnection();
        public static FileInfo file;
        public static SqlConnection SQLConn()
        {
            sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            return sqlcon;
        }

        public static SqlConnection SQLCommonCon()
        {
            sqlCommoncon = new SqlConnection(ConfigurationManager.ConnectionStrings["common"].ConnectionString);
            if (sqlCommoncon.State == ConnectionState.Closed)
            {
                sqlCommoncon.Open();
            }
            return sqlCommoncon;
        }
    }
