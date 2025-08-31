using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models;

public class MessageEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
    
    [Required]
    [StringLength(150)]
    [EmailAddress]
    public required string Email { get; set; }
    
    
    [Required]
    [StringLength(100)]
    public required string PlainMessage { get; set; }
}