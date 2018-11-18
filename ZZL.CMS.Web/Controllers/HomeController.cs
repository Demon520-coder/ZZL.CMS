using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZL.CMS.Entity;
using ZZL.CMS.Common;
using ZZL.CRM.IBLL;
using System.ComponentModel.Composition;

namespace ZZL.CMS.Web.Controllers
{
    [Export]  
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        [Import]
        public INewsInfoBLL NewsInfoBll { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <returns></returns>
        public ActionResult News(int? pageIndex = 1)
        {
            int totalCount;
            int pageCount = NewsInfoBll.GetPageCount(2, out totalCount);
            pageIndex = pageIndex > pageCount ? pageCount : (pageIndex <= 0 ? 1 : pageIndex);
            var list = NewsInfoBll.GetPagedList(pageIndex.Value, 2);
            ViewBag.pageIndex = pageIndex.Value;
            ViewBag.pageCount = pageCount;
            ViewBag.totalCount = totalCount;

            return View(list);
        }
    }
}