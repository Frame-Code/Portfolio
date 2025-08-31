namespace Portfolio.Shared.DTO;

public record EmailConfiguration(
    string Email,
    string Password,
    int Port,
    string Host
    );