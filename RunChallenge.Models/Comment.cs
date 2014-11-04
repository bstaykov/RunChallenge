using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class Comment
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
    }
}
