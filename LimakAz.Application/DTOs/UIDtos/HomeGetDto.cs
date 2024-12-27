namespace LimakAz.Application.DTOs;

public class HomeGetDto
{
    public PaginateDto<NewsGetDto> News { get; set; } = new PaginateDto<NewsGetDto>();
}
