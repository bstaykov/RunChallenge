namespace RunChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RunChallenge.Common.Models;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
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
        private ICollection<EventUser> eventusers;

        public User()
        {
            // This will prevent User>manager.CreateAsync from causing exceptions
            this.CreatedOn = DateTime.Now;

            this.comments = new HashSet<Comment>();
            this.articles = new HashSet<Article>();
            this.workouts = new HashSet<Workout>();
            this.targets = new HashSet<Target>();
            this.events = new HashSet<Event>();
            this.eventusers = new HashSet<EventUser>();
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

        public virtual ICollection<EventUser> EventUsers
        {
            get
            {
                return this.eventusers;
            }
            set
            {
                this.eventusers = value;
            }
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
