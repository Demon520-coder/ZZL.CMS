using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.CMS.Dao;
using ZZL.CMS.Entity;
using ZZL.CRM.IBLL;

namespace ZZL.CMS.BLL
{
    [Export(typeof(INewsInfoBLL))]
    public class NewsInfoBll : INewsInfoBLL
    {
        ///private readonly NewsInfoDao newsInfoDao;

        public NewsInfoBll()
        {
            ///newsInfoDao = new NewsInfoDao();
        }



        public bool AddNews(NewsInfo news)
        {
           var  newsInfoDao = new NewsInfoDao();
            return newsInfoDao.AddNews(news);
        }

        public List<NewsInfo> GetPagedList(int pageIndex, int pageSize)
        {
            var newsInfoDao = new NewsInfoDao();
            return newsInfoDao.GetPageList(pageIndex, pageSize);
        }

        public int GetPageCount(int pageSize, out int totalCount)
        {
            var newsInfoDao = new NewsInfoDao();
            return newsInfoDao.GetPageCount(pageSize, out totalCount);
        }
    }
}
