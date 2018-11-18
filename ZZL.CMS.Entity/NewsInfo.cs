using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.CMS.Entity
{
    /// <summary>
    /// 新闻实体
    /// </summary>
    public class NewsInfo : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int Author { get; set; }

        public int? ScanCount { get; set; }
    }
}
