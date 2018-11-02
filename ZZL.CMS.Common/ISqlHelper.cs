using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.CMS.Common
{
    public interface ISqlHelper
    {
        string ConnString { get; }

        DataTable GetTable(string sql, CommandType type = CommandType.Text, params SqlParameter[] sqlParams);

        int ExceuteNoneQuery(string sql, CommandType type = CommandType.Text, params SqlParameter[] sqlParams);

        object ExecuteScalar(string sql, CommandType type = CommandType.Text, params SqlParameter[] sqlParams);

        IDataReader GetReader(string sql, params SqlParameter[] sqlParams);
    }
}
