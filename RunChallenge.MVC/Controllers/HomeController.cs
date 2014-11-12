namespace RunChallenge.MVC.Controllers
{
    using RunChallenge.Data;
    using RunChallenge.MVC.Models.Workouts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI;

    //[OutputCache(Duration = 10)] // cached for 60 sec
    public class HomeController : BaseController
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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(Duration=30, VaryByParam="none")]
        [ChildActionOnly]
        public ActionResult LastInsertedWorkouts()
        {
            var lastWorkouts = this.data.Workouts.All()
                   .Where(d => d.Date < DateTime.Now)
                   .OrderByDescending(w => w.Date)
                   .Take(3)
                   .Select(w =>
                       new WorkoutItemModel
                       {
                           UserName = w.User.UserName,
                           Distance = w.Distance,
                           Time = w.Time,
                           Location = w.Location,
                           Date = w.Date,
                           Comment = w.Comment
                       })
                       .ToList();
            return this.PartialView("_LastInsertedWorkouts", lastWorkouts);
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