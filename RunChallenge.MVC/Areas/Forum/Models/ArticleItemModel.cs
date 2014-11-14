namespace RunChallenge.MVC.Areas.Forum.Models
{
    using RunChallenge.Models;
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public class ArticleItemModel
    {
        public static Expression<Func<Article, ArticleItemModel>> FromArticle
        {
            get
            {
                return article => new ArticleItemModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    UserName = article.User.UserName,
                    Content = article.Content,
                    Category = ((ArticleCategory)article.Category).ToString(),
                    DateTimePosted = article.DateTimePosted
                };
            }
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateTimePosted { get; set; }
    }
}