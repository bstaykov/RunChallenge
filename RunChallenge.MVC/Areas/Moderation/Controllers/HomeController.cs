namespace RunChallenge.MVC.Areas.Moderation.Controllers
{
    using RunChallenge.Common.Repository;
    using RunChallenge.Data;
    using RunChallenge.Models;
    using RunChallenge.MVC.Controllers;
    using RunChallenge.MVC.ViewModels.Areas.Home;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        private IRepository<Article> articles;

        public HomeController(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            var articles = this.articles.All()
                .Project().To<IndexRunChallengeArticleViewModel>();
            return View(articles);
        }
    }
}