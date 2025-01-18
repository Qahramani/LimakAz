﻿namespace LimakAz.Application.DTOs;

public class AddressLineGetDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; } 
    public string? Value { get; set; } 
    public int CountryId { get; set; }
}

public class AddressLineCreateDto : IDto
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int CountryId { get; set; }
}

public class AddressLineUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int CountryId { get; set; }
}



