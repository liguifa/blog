using BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string username,string password)
        {
            if (!new UserOper().Login(username, password))
            {
                return View("LoginFailure");
            }
            ViewBag.list = new UserOper().GetUserList();
            return View();
        }

        public ActionResult ArticleManagement(int pageIndex=1)
        {
            ViewBag.list = new ArticleOper().GetArticleList(pageIndex,20);
            return View();
        }

        public ActionResult AddArticle()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult AddArticleIn(string title,string brief,string body,string type)
        {
            new ArticleOper().AddArticle(title, brief, body,type, Server.MapPath("/Views/Articles/"));
            return View();
        }

    }
}
