namespace LimakAz.Application.Interfaces.Services;

public interface IMessageService 
{
    Task<MessageDisplayDto> SendMessageAsync(string text, int chatId);
    Task<List<MessageDisplayDto>> GetMessagesByChatIdAsync(int chatId);
}
