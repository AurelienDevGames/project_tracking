using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GET2WORK_.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public TimeOfTheDay TimeOfTheDay { get; set; }

        public virtual Project Project { get; set; }
    }
}