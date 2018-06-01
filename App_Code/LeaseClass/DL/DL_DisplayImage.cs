using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DL_DisplayImage
/// </summary>
public class DL_DisplayImage
{
	public DL_DisplayImage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    DataTable dt;
    DataSet Ds;
    SqlDataAdapter da;
    SqlCommand cmd;
    SqlConnection con;
    SqlConnection Commoncon;
    internal DataTable GetScanningFile(int Ind, decimal ServiceNo)
    {
        try
        {
            con = new SqlConnection();
            da = new SqlDataAdapter();
            //  Ds = new DataSet();
            dt = new DataTable();
            con = DBConnection.SQLConn();
            cmd = new SqlCommand("SpDisplayImage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", Ind);
            cmd.Parameters.AddWithValue("@ServiceNo", ServiceNo);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {

                }
                else
                {

                    dt = null;
                }
            }
            else
            {

                dt = null;
            }
        }

        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Dispose();
                con.Close();
            }
        }
        return dt;
    }
    internal DataTable ddlFillDocumentType(int Ind)
    {
        try
        {
            con = new SqlConnection();
            da = new SqlDataAdapter();
            //  Ds = new DataSet();
            dt = new DataTable();
            con = DBConnection.SQLConn();
            cmd = new SqlCommand("SpDisplayImage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", Ind);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {

                }
                else
                {

                    dt = null;
                }
            }
            else
            {

                dt = null;
            }
        }

        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Dispose();
                con.Close();
            }
        }
        return dt;
    }
}