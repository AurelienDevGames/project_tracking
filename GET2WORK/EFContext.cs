using System.Data.Entity;
using GET2WORK.Models;

namespace GET2WORK
{
    public class MotivationContext : System.Data.Entity.DbContext
    {
        public DbSet<Motivation> Motivation { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Question> Question { get; set; }
    }
}