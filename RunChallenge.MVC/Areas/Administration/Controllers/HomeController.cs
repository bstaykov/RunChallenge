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
    using System.Web.Security;

    public class HomeController : AdminController
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

        [HttpGet]
        public ActionResult MakeModerator(string id)
        {
            //var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
            var user = this.data.Users.All().Where(userID => userID.Id == id).FirstOrDefault();
            Roles.AddUserToRole(user.UserName, "Moderator");
            this.data.SaveChanges();
            return RedirectToAction("GetUsers", "Administration");
        }
    }
}