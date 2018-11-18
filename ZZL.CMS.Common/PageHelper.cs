using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.CMS.Common
{
    public class PageHelper
    {
        public static string GetPager(int pageIndex, int pageCount)
        {
            if (pageCount <= 1)
            {
                return string.Empty;
            }
            int start = (pageIndex - 3) < 1 ? 1 : pageIndex - 3;

            if (start <= 1)
            {
                start = 1;
            }

            int end = (start + 3) > pageCount ? pageCount : start + 3;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    strBuilder.Append(i);
                }
                else
                {
                    strBuilder.Append($"<a href='?pageIndex={i}'>{i}</a>");
                }
            }

            return strBuilder.ToString();
        }

        public static string GetPager2(int pageIndex, int pageCount)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }

            StringBuilder builder = new StringBuilder();
            if (pageCount == 1)
            {
                builder.Append($"<a>{pageCount}</a>");
            }
            else
            {
                if (pageIndex != 1)
                {
                    builder.Append("<a href='?pageIndex=1'>首页</a>");
                    builder.Append($"<a href='?pageIndex={(pageIndex - 1 == 0 ? pageIndex : pageIndex - 1)}'>上一页</a>");
                }
               
                if (pageIndex != pageCount)
                {
                    builder.Append($"<a href='?pageIndex={(pageIndex + 1 > pageCount ? pageCount : pageIndex + 1)}'>下一页</a>");
                    builder.Append($"<a href='?pageIndex={pageCount}'>尾页</a>");                  
                }

            }

            return builder.ToString();
        }
    }
}
