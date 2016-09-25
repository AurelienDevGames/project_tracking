using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace ThoughtBubbles.Models
{
    public class Project
    {
        [PrimaryKey][AutoIncrement]
        public int ProjectId { get; set; }

        public string Name { get; set; }
        
        [Reference]
        public int CategoryId { get; set; }

        [Ignore]
        public virtual List<Question> Questions { get; set; } = new List<Question>();
    }
}