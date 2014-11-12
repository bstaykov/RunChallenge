namespace RunChallenge.MVC.Areas.Administration.Models
{
    using RunChallenge.Models;
    using System;
    using System.Linq.Expressions;

    public class UserModel
    {
        public static Expression<Func<User, UserModel>> FromUser
        {
            get
            {
                return user => new UserModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    WorkoutsCount = user.Workouts.Count
                };
            }
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int WorkoutsCount { get; set; }
    }
}