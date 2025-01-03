using LimakAz.Domain.Enums;
using System.Net.Mime;

namespace LimakAz.Domain.Entities;

public class Content : BaseAuditableEntity
{
    public PageType PageType { get; set; }
    public ICollection<ContentDetail> ContentDetails { get; set; } = [];
}
