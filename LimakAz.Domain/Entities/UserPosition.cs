namespace LimakAz.Domain.Entities;

public class UserPosition : BaseEntity
{
    public ICollection<UserPositionDetail> UserPositionDetails { get; set; } = [];
}
