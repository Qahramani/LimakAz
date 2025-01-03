namespace LimakAz.Application.DTOs;

public class HomeGetDto
{
    public PaginateDto<NewsGetDto> News { get; set; } = new PaginateDto<NewsGetDto>();
    public PaginateDto<CertificateGetDto> Certificates { get; set; } = new PaginateDto<CertificateGetDto>();
    public PaginateDto<ShopGetDto> Shops { get; set; } = new PaginateDto<ShopGetDto>();
    public PaginateDto<SliderGetDto> Sliders { get; set; } = new PaginateDto<SliderGetDto>();
    public List<TariffUiGetDto> Tariffs = new List<TariffUiGetDto>();   
}
