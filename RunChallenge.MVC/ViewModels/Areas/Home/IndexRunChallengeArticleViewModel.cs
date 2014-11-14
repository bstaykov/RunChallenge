namespace RunChallenge.MVC.ViewModels.Areas.Home
{
    using RunChallenge.Models;
    using RunChallenge.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class IndexRunChallengeArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ArticleCategory Category { get; set; }
    }
}