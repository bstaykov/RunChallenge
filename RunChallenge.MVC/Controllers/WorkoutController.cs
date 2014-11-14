namespace RunChallenge.MVC.Controllers
{
    using RunChallenge.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using RunChallenge.MVC.Models.Workouts;
    using System.Text;
    using RunChallenge.Models;
    using System.Globalization;
    using RunChallenge.MVC.Areas.Forum.Models;
    using System.Net;
    using System.Web.UI;
    //using Microsoft.AspNet.Identity.IdentityExtensions;

    public class WorkoutController : BaseController
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

        [OutputCache(Duration=10, Location=OutputCacheLocation.Any)]
        [HttpGet]
        public ActionResult LastWorkouts()
        {
            var currentUserId = this.User.Identity.GetUserId();
            //List<WorkoutItem> lastWorkouts = this.data.Workouts.All()
            //    .Where(u => u.UserId == currentUserId && u.Date < DateTime.Now)
            //    .Select(w => new{ w.Distance ,w.Time ,w.Location, w.Date , w.Comment})
            //    .Cast<WorkoutItem>()
            //    .OrderByDescending(w => w.Date)
            //    .Take(3)
            //    .ToList();

            var userW = this.data.Workouts.All()
                .Where(w => w.UserId == currentUserId)
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


            return View(userW);
        }

        [Authorize]
        [HttpGet]
        public ActionResult InsertWorkout()
        {
            return View(new WorkoutInputModel());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertWorkout(WorkoutInputModel workout)
        {
            // custom error message
            if (workout.Day == (DateTime.Now.Day + 1))
            {
                ModelState.AddModelError(string.Empty, "Tommorow CUSTOM ERROR!");
            }

            DateTime date;
            string dataString = workout.Month + "/" + workout.Day + "/" + workout.Year;
            string format = "M/d/yyyy";
            if (DateTime.TryParseExact(dataString, format, new CultureInfo("en-US"), DateTimeStyles.None, out date) 
                && (DateTime.Now.Year == workout.Year && DateTime.Now.Month == workout.Month && DateTime.Now.Day == workout.Day))
            {
                date = DateTime.Now;
            }

            if (ModelState.IsValid)
            {
                float distance = Distance(workout.Km, workout.Meters);
                TimeSpan time = new TimeSpan(workout.Hours, workout.Minutes, workout.Seconds);
                int timeInSeconds = TimeInSeconds(workout.Hours, workout.Minutes, workout.Seconds);
                string pace = CalcPace(timeInSeconds, distance);
                string kmHour = KmPerHour(timeInSeconds, distance);
                Workout newWorkout = new Workout() { 
                    UserId = this.User.Identity.GetUserId(),
                    Distance = distance,
                    Time = time,
                    Location = workout.Location,
                    Date = date,
                    Pace = pace,
                    KmHour = kmHour,
                    TimeInSeconds = timeInSeconds,
                    Comment = workout.Comment
                };

                this.data.Workouts.Add(newWorkout);
                this.data.SaveChanges();

                TempData["Success"] = "Workout successfully added...";

                return RedirectToAction("LastWorkouts");
            }
            return View(workout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DelleteAllWorkouts()
        {
            var curentUserId = this.User.Identity.GetUserId();
            var workouts = this.data.Workouts.All()
                .Where(user => user.UserId == curentUserId);
            if (workouts == null)
            {
                return RedirectToAction("LastWorkouts");
            }
            foreach (var item in workouts)
            {
                var id = item.Id;
                this.data.Workouts.Delete(id);
            }
            this.data.SaveChanges();
            return RedirectToAction("LastWorkouts");
        }

        [NonAction]
        private float Distance(float km, float m)
        {
            float distance = km + m / 1000;
            return distance;
        }

        [NonAction]
        private String CalcPace(int timeInSeconds, float distance)
        {
            StringBuilder sb = new StringBuilder();
            int kmPace = (int)(timeInSeconds / distance);
            if (kmPace >= 3600)
            {
                sb.Append(kmPace / 3600);
                if (timeInSeconds < 7200)
                {
                    sb.Append(" hour ");
                }
                else
                {
                    sb.Append(" hours ");
                }
                kmPace = kmPace % 3600;
            }
            if (kmPace >= 60)
            {
                sb.Append(kmPace / 60);
                sb.Append(" min ");
                sb.Append(kmPace % 60);
                sb.Append(" sec ");
            }
            else
            {
                sb.Append(kmPace % 60);
                sb.Append(" sec");
            }
            return sb.ToString();
        }

        [NonAction]
        private int TimeInSeconds(int hours, int minutes, int seconds)
        {
            return hours * 3600 + minutes * 60 + seconds;
        }

        [NonAction]
        private String KmPerHour(int timeInSeconds, float distance)
        {
            String kmPerH = String
                    .Format("{0:F2}", CultureInfo.InvariantCulture, (distance * 3600) / timeInSeconds);
            return kmPerH;
        }

    }
}