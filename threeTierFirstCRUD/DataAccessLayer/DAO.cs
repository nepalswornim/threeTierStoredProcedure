using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class DAO
    {
        public static AppSettingsReader aps = new AppSettingsReader();
        public static string connStr = "";

        static DAO()
        {

            connStr = aps.GetValue("myconnection", typeof(string)).ToString();
        }
        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(connStr);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }


        public static int IDU(string sql, SqlParameter[] param, CommandType cmdTpye)
        {

            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdTpye;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        return i;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }

            }
        }

        public static DataTable SelectUser(string sql, SqlParameter[] param, CommandType cmdType)
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdType;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;


                }
            }

        }




    }
}




