namespace LimakAz.Application.DTOs;

public class OrderGetDto : IDto
{
    public int Id { get; set; }
    public string? Link { get; set; } 
    public decimal ItemPrice { get; set; }
    public bool IsLocalCargoFree { get; set; }
    public decimal LocalCargoPrice { get; set; } = 0;
    public decimal TotalCargoPrice { get; set; }
    public decimal Weight { get; set; }
    public int Count { get; set; }
    public string? Color { get; set; } 
    public string? Size { get; set; } 
    public string? Notes { get; set; } 
    public bool IsCancel { get; set; } = false;
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public int CountryId { get; set; }
    public CountryGetDto? Country { get; set; }
    public int? ShopId { get; set; }
    public ShopGetDto? Shop { get; set; }
    public int LocalPointId { get; set; }
    public LocalPointGetDto? LocalPoint { get; set; }
    public int StatusId { get; set; }
    public StatusGetDto? Status { get; set; }
}

public class OrderCreateDto : IDto
{
    public string? Link { get; set; }
    public decimal ItemPrice { get; set; }
    public bool IsLocalCargoFree { get; set; }
    public decimal LocalCargoPrice { get; set; } = 0;
    public decimal OrderTotalPrice { get; set; }
    public int Count { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Notes { get; set; }
    public int CountryId { get; set; }
    public List<CountryGetDto> Countries { get; set; } = [];
    public int LocalPointId { get; set; }
    public int SelectedLocalPointId { get; set; }

    public List<LocalPointGetDto> LocalPoints { get; set; } = [];
}

public class OrderUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Link { get; set; }
    public decimal ItemPrice { get; set; }
    public bool IsLocalCargoFree { get; set; }
    public decimal LocalCargoPrice { get; set; } = 0;
    public decimal TotalCargoPrice { get; set; }
    public int Count { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Notes { get; set; }
    public int CountryId { get; set; }
    public List<CountryGetDto> Countries { get; set; } = [];
    public int LocalPointId { get; set; }
    public List<LocalPointGetDto> LocalPoints { get; set; } = [];
}