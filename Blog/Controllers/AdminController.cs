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

        public ActionResult ArticleManagement()
        {
            ViewBag.list = new UserOper().GetUserList();
            return View();
        }

    }
}
