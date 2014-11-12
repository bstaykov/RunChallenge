namespace RunChallenge.Data
{
    using RunChallenge.Data.Repository;
    using RunChallenge.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class RunChallengeData : IRunChallengeData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public RunChallengeData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public Repository.IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public Repository.IRepository<Article> Articles
        {
            get { return this.GetRepository<Article>(); }
        }

        public Repository.IRepository<ArticleLike> ArticleLikes
        {
            get { return this.GetRepository<ArticleLike>(); }
        }

        public Repository.IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public Repository.IRepository<CommentLike> CommentLikes
        {
            get { return this.GetRepository<CommentLike>(); }
        }

        public Repository.IRepository<Event> Events
        {
            get { return this.GetRepository<Event>(); }
        }
        public Repository.IRepository<EventUser> EventUsers
        {
            get { return this.GetRepository<EventUser>(); }
        }

        public Repository.IRepository<Target> Targets
        {
            get { return this.GetRepository<Target>(); }
        }

        public Repository.IRepository<Workout> Workouts
        {
            get { return this.GetRepository<Workout>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
