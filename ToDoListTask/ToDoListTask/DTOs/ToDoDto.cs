using ToDoListTask.Models;
using ToDoListTask.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoListTask.DTOs
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public int ToDoCategoryId { get; set; }
    }

}