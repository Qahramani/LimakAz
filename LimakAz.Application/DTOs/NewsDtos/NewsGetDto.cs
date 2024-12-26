using LimakAz.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.DTOs;

//public class NewsGetDto : IDto
//{
//    public int Id { get; set; }
//    public string? ImagePath { get; set; }
//    public string? Title { get; set; }
//    public string? Description { get; set; }
//    public DateTime CreatedAt { get; set; }
//}
//public class NewsCreateDto : IDto
//{
//    public int Id { get; set; }
//    public string? ImagePath { get; set; } 
//    public IFormFile ImageFile { get; set; } = null!;
//    public string Title { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    public int LanguageId { get; set; }
//}

//public class NewsUpdateDto : IDto
//{
//    public int Id { get; set; }
//    public string? ImagePath { get; set; }
//    public IFormFile? ImageFile { get; set; }
//    public string Title { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    public int LanguageId { get; set; }
//}


public class NewsGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public DateTime CreatedAt { get; set; } 
    public List<NewsDetailGetDto> NewsDetails { get; set; } = [];
}
public class NewsCreateDto : IDto
{
    public string? ImagePath { get; set; }
    public IFormFile ImageFile { get; set; } = null!;
    public List<NewsDetailCreateDto> NewsDetails { get; set; } = [];
}

public class NewsUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public List<NewsDetailUpdateDto> NewsDetails { get; set; } = [];
}