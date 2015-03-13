using BlogService;
using Common;
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

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (!new UserOper().Login(username, password))
            {
                return View("LoginFailure");
            }
            HttpContext.Session["admin"] = username;
            ViewBag.list = new UserOper().GetUserList();
            return View();
        }

        [UserAuthorization("admin")]
        public ActionResult ArticleManagement(int pageIndex = 1)
        {
            ViewBag.list = new ArticleOper().GetArticleList(pageIndex, 20);
            return View();
        }

        [UserAuthorization("admin")]
        public ActionResult AddArticle()
        {
            return View();
        }

        [UserAuthorization("admin")]
        [ValidateInput(false)]
        public ActionResult AddArticleIn(string title, string brief, string body, string type)
        {
            new ArticleOper().AddArticle(title, brief, body, type, Server.MapPath("/Views/Articles/"));
            return View();
        }

    }
}
