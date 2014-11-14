namespace RunChallenge.Models
{
    using RunChallenge.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comment : IAuditInfo, IDeletableEntity
    {
        private ICollection<CommentLike> likes;
        private ICollection<Article> articles;

        public Comment()
        {
            this.likes = new HashSet<CommentLike>();
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string Content { get; set; }

        public DateTime DateTimePosted { get; set; }

        public CommentStatus Status { get; set; }

        public virtual ICollection<CommentLike> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
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

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
