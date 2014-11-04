using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunChallenge.Models
{
    public class Target
    {
        public int Id { get; set; }

        public Guid UserId{ get; set; }

        public virtual User User { get; set; }

        public TimeSpan TimeFiveKm { get; set; }
        
        public TimeSpan TimeTenKm { get; set; }

        public float MontlyKm { get; set; }

    }
}
