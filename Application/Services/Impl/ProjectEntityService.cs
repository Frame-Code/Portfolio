using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Services.Impl;

public class ProjectEntityService(IProjectEntityRepository repository) : IProjectEntityService
{
    private readonly IProjectEntityRepository _repository = repository;
        
    public async Task<ProjectEntity> SaveAsync(ProjectEntity obj)
    {
        return await _repository.SaveAsync(obj);
    }

    public async Task<IEnumerable<ProjectEntity>> SaveAllAsync(IEnumerable<ProjectEntity> objs)
    {
        return await _repository.SaveAllAsync(objs);
    }

    public async Task<IEnumerable<ProjectEntity>> FindAllAsync()
    {
        return await _repository.FindAllAsync();
    }

    public async Task<ProjectEntity?> FindByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public void RemoveByIdAsync(int id)
    {
        _repository.RemoveByIdAsync(id);
    }
}