using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunChallenge.MVC.Areas.Forum.Controllers
{
    public class HomeController : Controller
    {
        // GET: Forum/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}