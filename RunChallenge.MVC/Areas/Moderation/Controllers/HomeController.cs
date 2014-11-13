namespace RunChallenge.MVC.Areas.Moderation.Controllers
{
    using RunChallenge.Common.Repository;
using RunChallenge.Data;
using RunChallenge.Models;
using RunChallenge.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private IRepository<Article> articles;

        public HomeController(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            var articles = this.articles.All();
            return View(articles);
        }
    }
}