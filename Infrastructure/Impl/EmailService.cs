using System.Net;
using System.Net.Mail;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Models;
using Portfolio.Shared.DTO;

namespace Portfolio.Infrastructure.Impl;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _fromEmail;

    public EmailService(SmtpClient smtpClient, IConfiguration configuration)
    {
        _smtpClient = smtpClient;
        var host = configuration["CONFIGURATIONS_EMAIL:HOST"];
        var port = configuration.GetValue<int>("CONFIGURATIONS_EMAIL:PORT");
        var email = configuration["CONFIGURATIONS_EMAIL:EMAIL"];
        var password = configuration["CONFIGURATIONS_EMAIL:PASSWORD"];
        _fromEmail = email;
        if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new InvalidOperationException("La configuración SMTP (Host, Email, Password) no puede estar vacía. Revisa tus secretos de usuario o appsettings.");
        }
        _smtpClient.Host = host;
        _smtpClient.Port = port;
        _smtpClient.EnableSsl = true;
        _smtpClient.UseDefaultCredentials = false;
        _smtpClient.Credentials = new NetworkCredential(email, password);
    }

    public async Task Send(MessageEntity message)
    {
        var messageToSend = new MailMessage(
            from: _fromEmail,
            to: _fromEmail,
            subject: $"Contacto desde el portfolio: {message.Name}",
            body: $"De: {message.Name} : {message.Email}\n Mensaje: {message.PlainMessage}"
            );
        await _smtpClient.SendMailAsync(messageToSend);
    }
    
}