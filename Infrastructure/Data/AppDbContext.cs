using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> ProjectEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectEntity>().ToTable("Projects");
        modelBuilder.Entity<MessageEntity>().ToTable("Messages");
    }
}