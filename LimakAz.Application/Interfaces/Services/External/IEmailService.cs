namespace LimakAz.Application.Interfaces.Services.External;

public interface IEmailService 
{
    Task SendEmailAsync(EmailSendDto dto);
}
