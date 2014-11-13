namespace RunChallenge.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RunChallenge.Models;
    using System.Data.Entity;
    using RunChallenge.Data.Migrations;
    using RunChallenge.Common.Models;

    public class RunChallengeDbContext : IdentityDbContext<User>
    {
        public RunChallengeDbContext()
            : base("RunChallenge", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RunChallengeDbContext, Configuration>());
        }

        public static RunChallengeDbContext Create()
        {
            return new RunChallengeDbContext();
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<ArticleLike> ArticleLikes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<CommentLike> CommentLikes { get; set; }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Target> Targets { get; set; }

        public IDbSet<Workout> Workouts { get; set; }

        public override IDbSet<User> Users { get; set; }

        public IDbSet<EventUser> EventUsers { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
