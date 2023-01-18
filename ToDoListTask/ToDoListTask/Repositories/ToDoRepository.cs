using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ToDoListTask.DTOs;
using ToDoListTask.Data;
using ToDoListTask.Interfaces;
using ToDoListTask.Models;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoListTask.Repositories
{
    public class ToDoRepository : IToDoRepository<ToDo>
    {
        private readonly ToDoDbContext _dbContext;
        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDo> Add(ToDo entity)
        {

            await _dbContext.ToDos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            ToDo todo = await _dbContext.ToDos.FindAsync(id);
            if (todo == null)
                return false;
            else
            {
                _dbContext.ToDos.Remove(todo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<ToDo>> GetAll()
        {
            var toListResult = await _dbContext.ToDos.Include(x => x.TodoCategory).ToListAsync();
            return toListResult;

            //return await _dbContext.ToDos.ToListAsync();
        }

        public async Task<ToDo> GetByIdAsync(Guid id)
        {
            var todo = await _dbContext.ToDos.FindAsync(id);
            return todo;
        }

        public async Task<ToDo> Update(Guid id, ToDo entity)
        {
            var result = await _dbContext.ToDos.FindAsync(id);

            if (result != null)
            {
                result.Task = entity.Task;
                result.Description = entity.Description;
                result.IsCompleted = entity.IsCompleted;
                result.ToDoCategoryId = entity.ToDoCategoryId;

                await _dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
