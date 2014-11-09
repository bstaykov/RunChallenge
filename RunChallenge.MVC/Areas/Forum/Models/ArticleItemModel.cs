using System;
namespace RunChallenge.MVC.Areas.Forum.Models
{
    public class ArticleItemModel
    {
        public string UserName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateTimePosted { get; set; }
    }
}