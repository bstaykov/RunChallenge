using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RunChallenge.Models
{
    public class EventUser
    {
        [Key, Column(Order = 0)]
        public int EventId { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
