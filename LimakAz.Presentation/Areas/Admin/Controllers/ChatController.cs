﻿using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]

public class ChatController : Controller
{
    private readonly IChatService _chatService;
    private readonly IMessageService _messageService;
    private readonly ICookieService _cookieService;

    public ChatController(IChatService chatService, IMessageService messageService, ICookieService cookieService)
    {
        _chatService = chatService;
        _messageService = messageService;
        _cookieService = cookieService;
    }

    public  IActionResult Index()
    {
        var chats =  _chatService.GetAll();

        return View(chats);
    }

    public async Task<IActionResult> GetMessages(int chatId)
    {
        var messages = await _messageService.GetMessagesByChatIdAsync(chatId);

        ViewData["CurrentUserId"] = _cookieService.GetUserId();

        return Json(messages);
    }


    [HttpPost]
    public async Task<MessageDisplayDto> SendMessage(int chatId, string text)
    {
        var message = await _messageService.SendMessageAsync(text, chatId);
        
        return message;
    }
}
