using Portfolio.Models;

namespace Portfolio.DTO;

public class HomeViewModel
{
    public UserEntity User { get; set; }
    public ICollection<ProjectEntity> Projects { get; set; }
}