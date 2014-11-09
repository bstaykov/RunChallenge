namespace RunChallenge.MVC.Areas.Forum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using RunChallenge.Models;
    using System.Collections.Generic;

    public class ArticleInputModel
    {

        [Required(ErrorMessage = "Title is required!")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters!")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required!")]
        [MinLength(5, ErrorMessage = "Minimum 100 characters!")]
        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        public ArticleCategory Category { get; set; }
    }
}