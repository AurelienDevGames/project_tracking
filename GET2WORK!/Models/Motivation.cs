using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GET2WORK_.Models
{
    public class Motivation
    {
        [Key]
        public int MotivationId { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Question MorningQuestion { get; set; }
        public virtual Question AfternoonQuestion { get; set; }
    }
}