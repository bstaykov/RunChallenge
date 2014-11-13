namespace RunChallenge.Models
{
    using RunChallenge.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article : AuditInfo, IDeletableEntity
    {
        private ICollection<ArticleLike> likes;
        private ICollection<Comment> comments;

        public Article()
        {
            this.likes = new HashSet<ArticleLike>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateTimePosted { get; set; }

        public ArticleCategory Category { get; set; }

        public ArticleStatus Status { get; set; }

        public virtual ICollection<ArticleLike> Likes
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

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
