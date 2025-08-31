using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models;

public class ProjectEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
    
    [StringLength(1000)]
    public string? Description { get; set; }
    
    [StringLength(500)]
    public string? ImageUrl { get; set; }
    
    [StringLength(500)]
    public string? Link { get; set; }
}