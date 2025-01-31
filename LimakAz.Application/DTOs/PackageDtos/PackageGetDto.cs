namespace LimakAz.Application.DTOs;

public class PackageGetDto : IDto
{
    public int Id { get; set; }
    public string? NO { get; set; }
    public decimal TotalWeigth { get; set; }
    public decimal TotalCargoPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public int PaymentId { get; set; }
    public PaymentGetDto? Payment { get; set; }
    public int LocalPointId { get; set; }
    public int ShopId { get; set; }
    public ShopGetDto? Shop { get; set; }
    public LocalPointGetDto? LocalPoint { get; set; }
    public int StatusId { get; set; }
    public StatusGetDto? Status { get; set; }
    public List<OrderItemGetDto> OrderItems { get; set; } = []; 
    public DateTime CreatedAt { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}

public class PackageGetUserDto
{
    public List<StatusGetDto> Statuses { get; set; } = [];
    public List<PackageGetDto> Packages { get; set; } = [];
    public int SelectedStatusId { get; set; }
}

public class PackageGetAdminDto
{
    public int SelectedStatusId { get; set; }
    public List<PackageGetDto> Packages { get; set; } = [];
}