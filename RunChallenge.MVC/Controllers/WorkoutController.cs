using RunChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.IdentityExtensions;


namespace RunChallenge.MVC.Controllers
{
    public class WorkoutController : Controller
    {
        IRunChallengeData data;

        public WorkoutController()
            :this(new RunChallengeData(new RunChallengeDbContext()))
        {
        }

        public WorkoutController(IRunChallengeData data)
        {
            this.data = data;
        }

        // GET: Workout
        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var lastWorkouts = this.data.Workouts.All()
                .Where(u => u.UserId == currentUserId && u.Date < DateTime.Now)
                .OrderByDescending(w => w.Date)
                .Take(3);
            ViewData["LastWorkouts"] = lastWorkouts;
            return View();
        }
    }
}