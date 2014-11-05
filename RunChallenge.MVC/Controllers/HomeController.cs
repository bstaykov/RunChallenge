﻿using RunChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunChallenge.MVC.Controllers
{
    [OutputCache(Duration = 10)]
    public class HomeController : Controller
    {
        RunChallengeDbContext dbContext;

        public HomeController()
        {
            this.dbContext = new RunChallengeDbContext();
        }

        public ActionResult Index()
        {
            var lastWorkouts = this.dbContext.Workouts
                .OrderByDescending(w => w.Date)
                .Take(3);
            ViewData["LastWorkouts"] = lastWorkouts;

            return View();
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
    }
}