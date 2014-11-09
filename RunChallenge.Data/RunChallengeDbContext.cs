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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Event>()
        //        .HasRequired(f => f.User)
        //        .WithMany(b => b.Events)
        //        .HasForeignKey(f => f.UserId);

        //    modelBuilder.Entity<EventUser>()
        //        .HasKey(fb => new { fb.EventId, fb.UserId });

        //    modelBuilder.Entity<EventUser>()
        //        .HasRequired(fb => fb.Event)
        //        .WithMany(f => f.EventUsers)
        //        .HasForeignKey(fb => fb.EventId);

        //    modelBuilder.Entity<EventUser>()
        //        .HasRequired(fb => fb.User)
        //        .WithMany(b => b.EventUsers)
        //        .HasForeignKey(fb => fb.UserId);

        //    base.OnModelCreating(modelBuilder);
        //}

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<ArticleLike> ArticleLikes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<CommentLike> CommentLikes { get; set; }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Target> Targets { get; set; }

        public IDbSet<Workout> Workouts { get; set; }

        public override IDbSet<User> Users { get; set; }

        public IDbSet<EventUser> EventUsers { get; set; }

    }
}
