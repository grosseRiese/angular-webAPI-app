using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListTask.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; }
        public string Task { get; set; } 
        public DateTime DueDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        [MinLength(100)]
        public string Description { get; set; }
        public int ToDoCategoryId { get; set; }
        public ToDoCategory TodoCategory { get; set; }
      
        public ToDo()
        {
           
        }
    }
}
