namespace RunChallenge.MVC.Areas.Administration.Controllers
{
    using RunChallenge.Data;
    using RunChallenge.MVC.Controllers;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using RunChallenge.Models;
    using RunChallenge.MVC.Areas.Administration.Models;
    using System.Linq;
    using System.Web;

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

        // GET: Administration/Home
        public ActionResult Navigation()
        {
            return View(DateTime.Now);
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var usersList = this.data.Users.All()
                .AsQueryable()
                .OrderByDescending(u => u.Workouts.Count())
                .Select(UserModel.FromUser)
                .ToList();

            return View(usersList);
        }
    }
}