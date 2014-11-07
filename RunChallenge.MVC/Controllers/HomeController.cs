using RunChallenge.Data;
using RunChallenge.MVC.Models.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunChallenge.MVC.Controllers
{
    [OutputCache(Duration = 10)] // cached for 60 sec
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
                .Take(3)
                .Select(w =>
                    new WorkoutItem
                    {
                        UserName = w.User.UserName,
                        Distance = w.Distance,
                        Time = w.Time,
                        Location = w.Location,
                        Date = w.Date,
                        Comment = w.Comment
                    })
                    .ToList();

            return View(lastWorkouts);
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