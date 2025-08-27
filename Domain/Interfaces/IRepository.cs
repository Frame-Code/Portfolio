using Portfolio.Domain.Models;

namespace Portfolio.Domain.Interfaces;

public interface IRepository<TEntity, TKey> 
    where TEntity : class
    where TKey : struct
{
    Task<TEntity> SaveAsync(TEntity obj);
    Task<IEnumerable<ProjectEntity>> SaveAllAsync(IEnumerable<TEntity> objs);
    Task<IEnumerable<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(TKey id);
    void RemoveByIdAsync(TKey id);
}