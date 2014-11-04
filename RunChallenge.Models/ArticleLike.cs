using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class ArticleLike
    {
        [Key, Column(Order = 0)]
        public string UserID { get; set; }

        [Key, Column(Order = 1)]
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
