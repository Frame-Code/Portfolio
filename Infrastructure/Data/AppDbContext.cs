using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> ProjectEntities { get; set; }
}