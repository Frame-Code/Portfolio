namespace Portfolio.Application.Services.Interfaces;

public interface IService<TEntity, TKey>
    where TEntity : class
    where TKey : struct
{
    Task<TEntity> SaveAsync(TEntity obj);
    Task<IEnumerable<TEntity>> SaveAllAsync(IEnumerable<TEntity> objs);
    Task<IEnumerable<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(TKey id);
    void RemoveByIdAsync(TKey id);
}