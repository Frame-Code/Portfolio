using Portfolio.Domain.Models;

namespace Portfolio.Shared.DTO;

public class HomeViewModel
{
    public UserEntity User { get; set; }
    public ICollection<ProjectEntity> Projects { get; set; }
}