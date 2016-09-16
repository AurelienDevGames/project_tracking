using System;
using System.ComponentModel.DataAnnotations;

namespace GET2WORK_.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public DateTime Date { get; set; }

        public string QuestionText { get; set; }
        public string AnswerText { get; set; }

        public virtual Project Project { get; set; }
    }
}