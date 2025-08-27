using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<ProjectEntity> ProjectEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-JCACJ06;Database=Portfolio;User Id=myUsername;Password=myPassword;\n");
    }
}