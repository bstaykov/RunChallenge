using RunChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunChallenge.MVC.Controllers
{
    [OutputCache(Duration = 60)] // cached for 60 sec
    public class HomeController : Controller
    {
        IRunChallengeData data;

        public HomeController()
            :this(new RunChallengeData(new RunChallengeDbContext()))
        {
        }

        public HomeController(IRunChallengeData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            var lastWorkouts = this.data.Workouts.All()
                .Where(d => d.Date < DateTime.Now)
                .OrderByDescending(w => w.Date)
                .Take(3);

            return View(lastWorkouts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReturnJson()
        {
            var data = new {
                name = "Ivan",
                age = 12
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}