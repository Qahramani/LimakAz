﻿using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class BasketController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;
    public BasketController(IOrderService orderService, IPaymentService paymentService)
    {
        _orderService = orderService;
        _paymentService = paymentService;
    }

    public async Task<IActionResult> Index(int countryId = 4)
    {
        var basket = await _orderService.GetOrderBasketByCountryIdAsync(countryId);

        return View(basket);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFromBasket(int itemId)
    {
        await _orderService.DeleteAsync(itemId);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<JsonResult> IncreaseCount(int itemId)
    {
        var result = await _orderService.IncreaseOrderCountAsync(itemId);

        return Json(result);
    }

    [HttpPost]
    public async Task<JsonResult> DecreaseCount(int itemId)
    {
        var result = await _orderService.DecreaseOrderCountAsync(itemId);

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitOrderIds(OrderBasketDto model)
    {
        decimal totalCount = await _orderService.PayOrdersAsync(model.SelectedOrderIds);

        var result = await _paymentService.CreateAsync(new()
        {
            Amount = totalCount,
            Description = "Limak odenis"
        });

        string url = $"{result.Order.HppUrl}?id={result.Order.Id}&password={result.Order.Password}";
        
        return Redirect(url);
    }


    
}
