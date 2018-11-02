using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.CMS.Common
{
    public class SqlServerHelper : ISqlHelper
    {
        public string ConnString => ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public int ExceuteNoneQuery(string sql, CommandType type = CommandType.Text, params SqlParameter[] sqlParams)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = type
                };
                cmd.Parameters.AddRange(sqlParams);
                
                return cmd.ExecuteNonQuery();
            }
        }

     

        public object ExecuteScalar(string sql, CommandType type = CommandType.Text, params SqlParameter[] sqlParams)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = type
                };

                return cmd.ExecuteScalar();
            }
        }

        public IDataReader GetReader(string sql, params SqlParameter[] sqlParams)
        {
            SqlConnection con = new SqlConnection(ConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(sqlParams);

            return  cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataTable GetTable(string sql, CommandType type = CommandType.Text, params SqlParameter[] sqlParams)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                {
                    DataTable table = new DataTable();
                    adapter.SelectCommand.CommandType = type;
                    adapter.SelectCommand.Parameters.AddRange(sqlParams);
                    adapter.Fill(table);

                    return table;
                }
            }
        }
    }
}
