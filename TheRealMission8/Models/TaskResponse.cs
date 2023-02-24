using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRealMission8.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string Task { get; set; }
        public string Due { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }
        //Creating foreign key relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
