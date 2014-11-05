namespace RunChallenge.Data
{
    using RunChallenge.Data.Repository;
    using RunChallenge.Models;

    public interface IRunChallengeData
    {
        IRepository<User> Users { get; }

        IRepository<Article> Articles { get; }

        IRepository<ArticleLike> ArticleLikes { get; }

        IRepository<Comment> Comments { get; }

        IRepository<CommentLike> CommentLikes { get; }

        IRepository<Event> Events { get; }

        IRepository<Target> Targets { get; }

        IRepository<Workout> Workouts { get; }

        int SaveChanges();
    }
}
