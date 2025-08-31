using System.Net;
using System.Net.Mail;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Models;
using Portfolio.Shared.DTO;

namespace Portfolio.Application.Services.Impl;

public class EmailService(SmtpClient smtpClient) : IEmailService 
{
    private readonly SmtpClient _smtpClient = smtpClient;
    
    public async Task Send(IConfiguration configuration, MessageEntity message)
    {
        var emailConfiguration = GetConfiguration(configuration);
        InitSmtp(emailConfiguration);
        var messageToSend = new MailMessage(emailConfiguration.Email, emailConfiguration.Email, 
            $"El cliente {message.Name} con correo {message.Email} quiere contactarse contigo!",
            message.PlainMessage);
        await _smtpClient.SendMailAsync(messageToSend);
    }

    private EmailConfiguration GetConfiguration(IConfiguration configuration)
    {
        return new EmailConfiguration(
            configuration.GetValue<string>("CONFIGURATIONS_EMAIL:EMAIL")?? string.Empty,
            configuration.GetValue<string>("CONFIGURATIONS_EMAIL:PASSWORD")?? string.Empty,
            configuration.GetValue<int>("CONFIGURATIONS_EMAIL:PORT"),
            configuration.GetValue<string>("CONFIGURATIONS_EMAIL:HOST")?? string.Empty
        );
    }

    private void InitSmtp(EmailConfiguration configuration)
    {
        _smtpClient.EnableSsl = true;
        _smtpClient.UseDefaultCredentials = false;
        _smtpClient.Credentials = new NetworkCredential(configuration.Email, configuration.Password);
    }
    
}