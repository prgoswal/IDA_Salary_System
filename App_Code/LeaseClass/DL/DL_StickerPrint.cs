using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DL_StickerPrint
/// </summary>
public class DL_StickerPrint
{
	public DL_StickerPrint()
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
    internal DataTable GetServiceNo(PL_StickerPrint objpl) 
    {
        try
        {
            con = new SqlConnection();
            da = new SqlDataAdapter();
            //  Ds = new DataSet();
            dt = new DataTable();
            con = DBConnection.SQLConn();
            cmd = new SqlCommand("SpStickerPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpl.Ind);
            cmd.Parameters.AddWithValue("@ServiceNo", objpl.ServiceNo);
            cmd.Parameters.AddWithValue("@ServiceNoFrom", objpl.ServiceNoFrom);
            cmd.Parameters.AddWithValue("@ServiceNoTo", objpl.ServiceNoTo);
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

    internal DataTable GetMultiServiceNo(PL_StickerPrint objpl)
    {
        try
        {
            con = new SqlConnection();
            da = new SqlDataAdapter();
            //  Ds = new DataSet();
            dt = new DataTable();
            con = DBConnection.SQLConn();
            cmd = new SqlCommand("SpStickerPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpl.Ind);
            cmd.Parameters.AddWithValue("@ServiceNoFrom", objpl.ServiceNoFrom);
            cmd.Parameters.AddWithValue("@ServiceNoTo", objpl.ServiceNoTo);

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