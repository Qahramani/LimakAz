namespace LimakAz.Application.DTOs;

public class PaginateDto<T> where T : IDto
{
    public List<T> Items { get; set; } = [];
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
}
