using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunChallenge.Models;
using System.Data.Entity;
using RunChallenge.Data.Migrations;

namespace RunChallenge.Data
{
    public class RunChallengeDbContext : IdentityDbContext<User>
    {
        public RunChallengeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RunChallengeDbContext, Configuration>());
        }

        public static RunChallengeDbContext Create()
        {
            return new RunChallengeDbContext();
        }
    }
}
