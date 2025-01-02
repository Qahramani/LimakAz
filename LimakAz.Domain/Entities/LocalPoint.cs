using System.Net;

namespace LimakAz.Domain.Entities;

public class LocalPoint : BaseAuditableEntity
{
    public ICollection<LocalPointDetail> LocalPointDetails { get; set; } = [];
}
