using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RunChallenge.Models
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        private ICollection<Comment> comments;
        private ICollection<Article> articles;
        private ICollection<Workout> workouts;
        private ICollection<Target> targets;
        private ICollection<Event> events;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.articles = new HashSet<Article>();
            this.workouts = new HashSet<Workout>();
            this.targets = new HashSet<Target>();
            this.events = new HashSet<Event>();
        }

        public virtual ICollection<Comment> Comments 
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }

        public virtual ICollection<Workout> Workouts
        {
            get
            {
                return this.workouts;
            }
            set
            {
                this.workouts = value;
            }
        }

        public virtual ICollection<Target> Targets
        {
            get
            {
                return this.targets;
            }
            set
            {
                this.targets = value;
            }
        }

        public virtual ICollection<Event> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
            }
        }
    }
}
