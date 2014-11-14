namespace RunChallenge.MVC.Areas.Administration.Models
{
    using RunChallenge.Models;
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Security;
    using Microsoft.AspNet.Identity;

    public class UserModel
    {
        //public UserModel()
        //{
        //    Roles = "User";
        //}

        public static Expression<Func<User, UserModel>> FromUser
        {
            get
            {
                return user => new UserModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    WorkoutsCount = user.Workouts.Count,
                    ArticlesCount = user.Articles.Count,
                    //Roles = user.Roles.Count == 0 ? "User" : user.Roles.ToString()
                };
            }
        }

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int WorkoutsCount { get; set; }

        public int ArticlesCount { get; set; }

        //public string Roles { get; set; }
    }
}