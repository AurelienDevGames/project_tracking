using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThoughtBubbles.Models
{
    public class Question
    {

        [Key]
        public int QuestionId { get; set; }

        public DateTime Date { get; set; }

        public string QuestionText { get; set; }
        public string AnswerText { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}