using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GET2WORK_.Models;

namespace GET2WORK_
{
    public class MotivationContext : System.Data.Entity.DbContext
    {
        public DbSet<Motivation> Motivation { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Question> Question { get; set; }
    }
}