using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZZL.CMS.Common;

namespace ZZL.CMS.Test
{
    [TestClass]
    public class UnitTest1
    {
        ISqlHelper helper = new SqlServerHelper();

        [TestMethod]
        public void SqlServerHelperTest()
        {
            var dt = helper.GetTable("SELECT * FROM TB_USER;SELECT * FROM TB_MESSAGE;");
            Debug.WriteLine(dt.Rows.Count);
            Assert.AreEqual(dt.Rows.Count > 0, true);
        }

        [TestMethod]
        public void SqlServerHelperForProcTest()
        {
            var dt = helper.GetTable("ProcTest", System.Data.CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("NAME", "dfsf") });
        }

        [TestMethod]
        public void SqlServerHelperForScalar()
        {
            var result = helper.ExecuteScalar("SELECT COUNT(*) FROM TB_MESSAGE");

            Assert.AreEqual(Convert.ToInt32(result), 2);
        }

        [TestMethod]
        public void SqlServerHelperForExcueteProcTest()
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter(){ParameterName="NAME",Direction= System.Data.ParameterDirection.Input,Value="dsfd"},
                new SqlParameter(){ParameterName="ReturnValue",Direction= System.Data.ParameterDirection.ReturnValue}
            };

            helper.ExceuteNoneQuery("ProcTest", System.Data.CommandType.StoredProcedure, sqlParameters);

            var result = sqlParameters[1].Value;
        }

        [TestMethod]
        public void SqlServerHelperDataReaderTest()
        {
            var reader = helper.GetReader("SELECT * FROM TB_MESSAGE");
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                builder.Append(reader["Title"] + "|");
            }

            reader.Close();

            Debug.Print(builder.ToString());
        }
    }
}
