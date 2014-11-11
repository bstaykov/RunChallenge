namespace RunChallenge.MVC.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // GET: Administration/Home
        public ActionResult Navigation()
        {
            return View(DateTime.Now);
        }
    }
}