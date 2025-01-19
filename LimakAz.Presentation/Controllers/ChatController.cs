using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Repositories;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class ChatController : Controller
{
    private readonly IChatService _chatService;
    private readonly IMessageService _messageService;
    public ChatController(IChatService chatService, IMessageService messageService)
    {
        _chatService = chatService;
        _messageService = messageService;
    }

    public async Task<IActionResult> Index()
    {
        var chat = await _chatService.GetChatOfAuthenticatedUserAsync();

        return View(chat);
    }

    [HttpPost]
    public async Task<MessageDisplayDto> SendMessage(int chatId, string text)
    {
       var message = await _messageService.SendMessageAsync(text, chatId);

       
        return message;
    }
}
