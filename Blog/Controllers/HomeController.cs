using BlogService;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ArticleOper ao = new ArticleOper();
            ViewBag.hotTech = ao.GetHotArticle(1);
            ViewBag.hotEdit = ao.GetHotArticle(2);
            ViewBag.hotEssay = ao.GetHotArticle(3);
            return View();
        }

        public ActionResult List(string type, string num)
        {
            ArticleOper ao=new ArticleOper();
            ViewBag.type = type;
            ViewBag.list = ao.GetPageArticle(type, num, "20");
            ViewBag.count = ao.GetArticleCount(type);
            ViewBag.index = num;
            return View();
        }

        public ActionResult Content(string type, string num)
        {
            //ViewBag.html = new HtmlOperation().ReadHtml(Server.MapPath("/Articles") + "/2015012021021111.html");
            ViewBag.num = num;
            ViewBag.type = type;
            ViewBag.articleMsg = new ArticleOper().GetArticleMsgByNum(num);
            return View();
        }

        public ActionResult DistributionContent(string num)
        {
            return PartialView("../Articles/"+num);
        }

        public ActionResult About()
        {
            return View();
        }

        public string Joke()
        {
            return Common.Gboal.Joke();
        }

        public string GetCalendarData(int month,int year)
        {
            return new ArticleOper().GetCalendarData(month,year);
        }

        public ActionResult Study()
        {
            return View();
        }

        public ActionResult Dome(string pageIndex)
        {
            return View();
        }

        public PartialViewResult DemoData(string pageIndex)
        {
            ViewBag.demos = new DemoOper().GetListToPage(pageIndex);
            return PartialView();
        }
    }
}
