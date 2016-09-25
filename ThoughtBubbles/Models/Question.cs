using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace ThoughtBubbles.Models
{
    public class Question
    {

        [PrimaryKey][AutoIncrement]
        public int QuestionId { get; set; }

        public DateTime Date { get; set; }

        public string QuestionText { get; set; }
        public string AnswerText { get; set; }

        [Reference]
        public int ProjectId { get; set; }
    }
}