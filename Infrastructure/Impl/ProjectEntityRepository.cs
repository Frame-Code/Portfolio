using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.Models;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Impl;

public class ProjectEntityRepository(AppDbContext dbContext) : IProjectEntityRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<ProjectEntity> SaveAsync(ProjectEntity obj)
    {
        _dbContext.Add(obj);
        await _dbContext.SaveChangesAsync();
        return obj;
    }

    public async Task<IEnumerable<ProjectEntity>> SaveAllAsync(IEnumerable<ProjectEntity> objs)
    {
        var list = objs.ToList();
        _dbContext.AddRange(list);
        await _dbContext.SaveChangesAsync();
        return list.ToList();
    }

    public async Task<IEnumerable<ProjectEntity>> FindAllAsync()
    {
        return await _dbContext.ProjectEntities.ToListAsync();
    }

    public async Task<ProjectEntity?> FindByIdAsync(int id)
    {
        return await _dbContext.ProjectEntities.FindAsync(id);
    }

    public void RemoveByIdAsync(int id)
    {
        var project = FindByIdAsync(id);
        _dbContext.Remove(project);
    }
}