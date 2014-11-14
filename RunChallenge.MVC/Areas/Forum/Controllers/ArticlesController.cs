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
    using RunChallenge.Web.Infrastructure;

    //[AllowCrossDomain]
    public class ArticlesController : BaseController
    {
        private readonly IRunChallengeData data;

        private readonly ISanitizer sanitizer;

        public ArticlesController()
            :this(new RunChallengeData(new RunChallengeDbContext()), new HtmlSanitizerAdapter())
        {
        }

        public ArticlesController(IRunChallengeData data, ISanitizer sanitizer)
        {
            this.data = data;
            this.sanitizer = sanitizer;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = this.data.Articles.All()
                .AsQueryable()
                .Where(a => a.IsDeleted == false && a.Status == ArticleStatus.Visible)
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
            //var art = this.data.Articles.All();
            //foreach (var item in art)
            //{
            //    this.data.Articles.Delete(item);
            //}
            //this.data.SaveChanges();

            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                Article newArticle = new Article()
                {
                    UserId = userId,
                    Title = article.Title,
                    Content = sanitizer.Sanitize(article.Content),
                    DateTimePosted = DateTime.Now,
                    Status = ArticleStatus.Moderate
                };

                this.data.Articles.Add(newArticle);
                this.data.SaveChanges();

                TempData["Success"] = "Article successfully added and will ve visible after moderation.";

                return RedirectToAction("InsertArticle");

                //return RedirectToAction("Display", new { id = newArticle.Id, url = "url" });
            }
            return View(article);
        }

        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 60)]
        public ActionResult ListOfArticles()
        {
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

        public ActionResult Search(string query)
        {
            var result = this.data.Articles
                .All()
                .AsQueryable()
                .Where(article => article.Title.ToLower().Contains(query.ToLower()) && article.IsDeleted == false && article.Status == ArticleStatus.Visible)
                .Select(ArticleItemModel.FromArticle)
                .ToList();

            return this.PartialView("_ArticleResult", result);
        }

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

        public ActionResult Display(int id, string url, int? page)
        {
            return Content(id + " " + url);
        }

        public ActionResult GetByCategory(string category)
        {
            return Content(category);
        }
    }
}