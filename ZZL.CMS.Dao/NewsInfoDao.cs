using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.CMS.Common;
using ZZL.CMS.Entity;
namespace ZZL.CMS.Dao
{
    public class NewsInfoDao
    {
        private readonly ISqlHelper sqlHelper;

        public NewsInfoDao()
        {
            sqlHelper = new SqlServerHelper();
        }

        public bool AddNews(NewsInfo news)
        {
            string sql = "INSERT INTO TB_NEWS(Title,Content,CreateDate,Author) VALUES(@Title,@Cotent,@CreateDate,@Author)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("Title",System.Data.SqlDbType.NVarChar),
                new SqlParameter("Content",System.Data.SqlDbType.NVarChar),
                new SqlParameter("CreateDate",System.Data.SqlDbType.DateTime),
                new SqlParameter("Author",System.Data.SqlDbType.Int)
            };

            sqlParameters[0].Value = news.Title;
            sqlParameters[1].Value = news.Content;
            sqlParameters[2].Value = news.CreateDate;
            sqlParameters[3].Value = news.Author;

            return sqlHelper.ExceuteNoneQuery(sql, System.Data.CommandType.Text, sqlParameters) > 0;
        }


        public List<NewsInfo> GetPageList(int pageIndex, int pageSize)
        {
            string sql = "SELECT * FROM TB_NEWS WHERE IsDeleted=0 ORDER BY Id DESC OFFSET (@pageIndex-1)*@pageSize ROWS FETCH NEXT @pageSize ROWS ONLY;";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter() { ParameterName = "pageIndex", SqlDbType = System.Data.SqlDbType.Int, Value = pageIndex });
            sqlParameters.Add(new SqlParameter() { ParameterName = "pageSize", SqlDbType = System.Data.SqlDbType.Int, Value = pageSize });

            var dt = sqlHelper.GetTable(sql, System.Data.CommandType.Text, sqlParameters.ToArray());

            List<NewsInfo> list = new List<NewsInfo>();
            foreach (DataRow item in dt.Rows)
            {
                NewsInfo news = new NewsInfo();
                news.Title = item["Title"]?.ToString();
                news.Id = Convert.ToInt32(item["Id"]);
                news.ScanCount = item["ScanCount"] == DBNull.Value ? 0 : (int)item["ScanCount"];
                news.Content = item["Content"]?.ToString();
                news.IsDeleted = item["IsDeleted"] == null ? false : Convert.ToBoolean(item["IsDeleted"]);

                list.Add(news);
            }

            return list;
        }


        public int GetPageCount(int pageSize,out int totalCount)
        {
            int recordCount = (int)sqlHelper.ExecuteScalar("SELECT COUNT(*) FROM TB_NEWS WHERE IsDeleted=0", CommandType.Text);
            int pageCount = (int)Math.Ceiling(recordCount / (pageSize * 1.0));
            totalCount = recordCount;

            return pageCount;
        }



    }
}
