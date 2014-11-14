namespace RunChallenge.Models
{
    using RunChallenge.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event : IAuditInfo, IDeletableEntity
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

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
