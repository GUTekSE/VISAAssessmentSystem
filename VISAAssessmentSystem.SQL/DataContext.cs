using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessmentSystem.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Program> Programs { get; set; }

        public DbSet<Contract> Contracts { get; set; }
    }
}
