﻿namespace LimakAz.Application.DTOs;

public class TariffCreateDto : IDto
{
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public decimal Price { get; set; }
    public int CountryId { get; set; } 
}

