using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class Event
    {

        private ICollection<User> users;

        public Event()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string FounderId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public EventVisibilityStatus VisibilityStatus { get; set; }

        public EventScheduleStatus ScheduleStatus { get; set; }

        public ICollection<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }
    }
}
