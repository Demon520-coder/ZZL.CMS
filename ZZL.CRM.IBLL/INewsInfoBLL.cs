using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.CMS.Entity;

namespace ZZL.CRM.IBLL
{
    
    public interface INewsInfoBLL
    {
        bool AddNews(NewsInfo news);

        List<NewsInfo> GetPagedList(int pageIndex, int pageSize);

        int GetPageCount(int pageSize, out int totalCount);
    }
}
