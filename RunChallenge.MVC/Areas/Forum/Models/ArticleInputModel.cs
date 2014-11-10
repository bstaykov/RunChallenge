namespace RunChallenge.MVC.Areas.Forum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using RunChallenge.Models;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ArticleInputModel
    {
        private const string DEFAULT_TITLE = "Title...";
        private const string DEFAULT_CONTENT = "Content...";
        private const ArticleCategory DEFAULT_CATEGORY = ArticleCategory.Event;

        public ArticleInputModel()
        {
            this.Title = DEFAULT_TITLE;
            this.Content = DEFAULT_CONTENT;
            this.Category = DEFAULT_CATEGORY;
        }

        [Required(ErrorMessage = "Title is required!")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters!")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required!")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters!")]
        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [EnumDataType(typeof(ArticleCategory))]
        public ArticleCategory Category { get; set; }
    }
}