using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public float Distance { get; set; }

        public TimeSpan Time { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Pace { get; set; }

        public string KmHour { get; set; }

        public int TimeInSeconds { get; set; }

        public string Comment { get; set; }
    }
}
