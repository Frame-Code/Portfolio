using Portfolio.Domain.Models;

namespace Portfolio.Application.Services.Interfaces;

public interface IEmailService
{
    Task Send(MessageEntity message);
}