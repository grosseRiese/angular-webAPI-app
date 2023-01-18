namespace ToDoListTask.Interfaces
{
    public interface IToDoRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(Guid id, TEntity entity);
        Task<bool> Delete(Guid id);

    }
}
