﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ThoughtBubbles.Models;

namespace ThoughtBubbles
{
    public class MotivationContext : System.Data.Entity.DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}