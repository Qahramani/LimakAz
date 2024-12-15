﻿namespace LimakAz.Application.DTOs.SettingDtos;

public class SettingUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public List<SettingDetailUpdateDto> SettingDetails { get; set; } = [];
}