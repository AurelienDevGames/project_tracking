using System.ComponentModel.DataAnnotations;

namespace GET2WORK.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string Name { get; set; }

    }
}