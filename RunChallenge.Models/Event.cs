using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class Event
    {
        // may need to delete
        private ICollection<EventUser> eventusers;

        public Event()
        {
            this.eventusers = new HashSet<EventUser>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public EventVisibilityStatus VisibilityStatus { get; set; }

        public EventScheduleStatus ScheduleStatus { get; set; }

        public ICollection<EventUser> EventUsers
        {
            get
            {
                return this.eventusers;
            }
            set
            {
                this.eventusers = value;
            }
        }

    }
}
