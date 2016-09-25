using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace ThoughtBubbles.Models
{
    public class Category
    {
        [PrimaryKey][AutoIncrement]
        public int CategoryId { get; set; }

        public string CategoryLabel { get; set; }
    }
}