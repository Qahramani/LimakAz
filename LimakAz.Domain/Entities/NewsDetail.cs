﻿namespace LimakAz.Domain.Entities;

public class NewsDetail : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int NewsId { get; set; }
    public News? News { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}