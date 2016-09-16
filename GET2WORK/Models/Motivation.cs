using System;
using System.ComponentModel.DataAnnotations;

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