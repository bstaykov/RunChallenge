namespace RunChallenge.Data.Migrations
{
    using RunChallenge.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RunChallenge.Data.RunChallengeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO remove in production
            this.AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(RunChallengeDbContext context)
        {
            if (context.Users.Any() && !(context.Workouts.Any()))
            {
                User user1 = context.Users.FirstOrDefault();
                Workout workout = new Workout
                {
                    UserId = user1.Id,
                    Distance = 5.0f,
                    Time = new TimeSpan(0, 22, 33),
                    Location = "Sofia",
                    Date = DateTime.Now,
                    Pace = "5min4sec",
                    KmHour = "14km",
                    TimeInSeconds = 1332,
                    Comment = "It was hard!"
                };
                context.Workouts.Add(workout);
                context.SaveChanges();
            }
        }
    }
}
