using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class Article
    {
        private ICollection<ArticleLike> likes;
        private ICollection<Comment> comments;

        public Article()
        {
            this.likes = new HashSet<ArticleLike>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateTimePosted { get; set; }

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
    }
}
