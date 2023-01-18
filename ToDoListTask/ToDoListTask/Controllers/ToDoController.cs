using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListTask.Data;
using ToDoListTask.DTOs;
using ToDoListTask.Models;

namespace ToDoListTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
        {
            var result = await _context.ToDos.ToListAsync();
            return Ok(result); 
        }

        // GET: api/ToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(Guid id)
        {
            var toDo = await _context.ToDos.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        // PUT: api/ToDo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ToDo>> PutToDo([FromRoute] Guid id,ToDoDto toDo)
        {
            var result = await _context.ToDos.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result.Task =       toDo.Task;
            result.Description =      toDo.Description;
            result.IsCompleted =      toDo.IsCompleted;
            result.ToDoCategoryId =     toDo.ToDoCategoryId;
            

            await _context.SaveChangesAsync();

            return Ok(result);

        }

        // POST: api/ToDo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo([FromBody] ToDoDto toDo)
        {
            //List<ToDoCategory> categories = _context.ToDoCategories.ToList();
            //toDo.todoCategories = new SelectList(categories, "Id", "Name");
           
            toDo.Id = Guid.NewGuid();

            await _context.ToDos.AddAsync(new ToDo
           {
               Task = toDo.Task,
               Description = toDo.Description,
               IsCompleted = toDo.IsCompleted,
               ToDoCategoryId = toDo.ToDoCategoryId,

           });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDo), new {id = toDo.Id }, toDo);
        }

        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] Guid id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
