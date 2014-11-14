namespace RunChallenge.MVC.Areas.Mod.Models
{
    using RunChallenge.Models;
    using RunChallenge.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ArticleModerateModel : IMapFrom<Article>
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters!")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters!")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Content is required!")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters!")]
        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [EnumDataType(typeof(ArticleCategory))]
        public ArticleCategory Category { get; set; }
    }
}