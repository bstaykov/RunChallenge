namespace RunChallenge.MVC.Areas.Forum.Controllers
{
    using RunChallenge.Data;
    using RunChallenge.Models;
    using RunChallenge.MVC.Areas.Forum.Models;
    using RunChallenge.MVC.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using System.Net;
    using System.Web.Mvc;
    using RunChallenge.MVC.Filters;

    //[AllowCrossDomain]
    public class ArticleController : BaseController
    {
        IRunChallengeData data;

        public ArticleController()
            :this(new RunChallengeData(new RunChallengeDbContext()))
        {
        }

        public ArticleController(IRunChallengeData data)
        {
            this.data = data;
        }

        [HttpGet]
        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var data = this.data.Articles.All()
                .AsQueryable()
                .Select(ArticleItemModel.FromArticle)
                .ToList();
            return View(data);
        }

        [Authorize]
        [HttpGet]
        public ActionResult InsertArticle()
        {
            return View(new ArticleInputModel());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult InsertArticle(ArticleInputModel article)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                Article newArticle = new Article()
                {
                    UserId = userId,
                    Title = article.Title,
                    Content = article.Content,
                    DateTimePosted = DateTime.Now,
                    Status = ArticleStatus.Visible
                };

                this.data.Articles.Add(newArticle);
                this.data.SaveChanges();

                TempData["Success"] = "Article successfully added...";

                return RedirectToAction("InsertArticle");
            }
            return View(article);
        }

        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 60)]
        public ActionResult ListOfArticles()
        {
            // TODO get articles from db

            var lastArticles = this.data.Articles.All()
                .Where(s => s.Status == ArticleStatus.Visible)
                .OrderByDescending(d => d.DateTimePosted)
                .Take(3)
                .Select(a =>
                    new ArticleItemModel
                    {
                        UserName = a.User.UserName,
                        Title = a.Title,
                        Content = a.Content,
                        DateTimePosted = a.DateTimePosted,
                        Category = ((ArticleCategory)a.Category).ToString()
                    })
                    .ToList();

            return View(lastArticles);
        }

        //[HttpPost]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Search(string query)
        {
            var result = this.data.Articles
                .All()
                .AsQueryable()
                .Where(article => article.Title.ToLower().Contains(query.ToLower()))
                .Select(ArticleItemModel.FromArticle)
                .ToList();

            return this.PartialView("_ArticleResult", result);
        }

        //[HttpPost]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ContentById(int id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var article = this.data.Articles.All().FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Article not found");
            }

            return this.Content(article.Content);
        }
    }
}