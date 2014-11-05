using RunChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunChallenge.MVC.Controllers
{
    public class WorkoutController : Controller
    {
        RunChallengeDbContext dbContext;

        public WorkoutController()
        {
            this.dbContext = new RunChallengeDbContext();
        }

        // GET: Workout
        public ActionResult Index()
        {
            var lastWorkouts = this.dbContext.Workouts
                .OrderByDescending(w => w.Date)
                .Take(3);
            ViewData["LastWorkouts"] = lastWorkouts;
            return View();
        }
    }
}