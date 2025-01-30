
using LimakAz.Persistence.Implementations.Services.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LimakAz.Persistence.Implementations.Services;

internal class MessageService : IMessageService
{
    private readonly IMessageRepository _repository;
    private readonly IChatService _chatService;
    private readonly IHubContext<ChatHub> _chatHub;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    public MessageService(IMessageRepository repository, IChatService chatService, IMapper mapper, IHubContext<ChatHub> chatHub, IAuthService authService)
    {
        _repository = repository;
        _chatService = chatService;
        _mapper = mapper;
        _chatHub = chatHub;
        _authService = authService;
    }

    public async Task<List<MessageDisplayDto>> GetMessagesByChatIdAsync(int chatId)
    {
       
        var messages = _repository.GetAll(x => x.ChatId == chatId, x => x.Include(x => x.User)).OrderBy(x => x.CreatedAt);

        var dtos = _mapper.Map<List<MessageDisplayDto>>(messages);

        return dtos;
    }

    public async Task<MessageDisplayDto> SendMessageAsync(string text, int chatId)
    {
        var chat = await _chatService.GetAsync(chatId);

        if (chat == null)
            throw new NotFoundException();

        var user = await _authService.GetAuthenticatedUserAsync();

        Message message = new()
        {
            Text = text,
            ChatId = chatId,
            UserId = user.Id
        };

        await _repository.CreateAsync(message);
        await _repository.SaveChangesAsync();

        MessageDisplayDto dto = new()
        {
            UserId = message.UserId,
            Text = text,
            Fullname = chat.User?.Firstname + " " + chat.User?.Lastname,
            SendAt = DateTime.UtcNow,
            ChatId = chatId.ToString(),
            ModeratorFullname = "Operator",
        };




        if (user.Id == chat.UserId)
        {
            var MemberConnectionIds = ChatHub.Connections.FirstOrDefault(x => x.UserId == chat.ModeratorId)?.ConnectionIds;

            foreach (var connectionId in MemberConnectionIds ?? [])
            {
                await _chatHub.Clients.Client(connectionId).SendAsync("ReceiveMessage", dto);
            }
        }
        else
        {
            var userConnectionIds = ChatHub.Connections.FirstOrDefault(x => x.UserId == chat.UserId)?.ConnectionIds;

            foreach (var connection in userConnectionIds ?? [])
            {
                await _chatHub.Clients.Client(connection).SendAsync("ReceiveMessage", dto);
            }
        }



        return dto;
    }
}


