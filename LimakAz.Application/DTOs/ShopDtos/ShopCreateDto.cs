﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimakAz.Application.DTOs;

public class ShopCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile{ get; set; }
    public string? Link { get; set; }
    public int CountryId { get; set; }
    public List<CountryGetDto> Countries { get; set; } = [];
    public List<int> SelectedCategoryIds { get; set; } = [];
    public List<SelectListItem> Categories { get; set; } = [];
}
