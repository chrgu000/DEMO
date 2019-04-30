using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;

    /// <summary>
/// Sqls 的摘要说明
    /// </summary>
public class Sqls
{
    public Sqls()
    {
    }

    public static bool Exec(ArrayList arr)
    {
        bool b = true;
        SqlConnection con = new SqlConnection(Conn.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            for (int i = 0; i < arr.Count; i++)
            {
                cmd.CommandText = arr[i].ToString();
                cmd.ExecuteNonQuery();
            }
            trans.Commit();
        }
        catch (Exception e)
        {
            trans.Rollback();
            b = false;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        return b;
    }

}
