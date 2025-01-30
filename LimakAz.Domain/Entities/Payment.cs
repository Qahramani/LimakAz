namespace LimakAz.Domain.Entities;

using LimakAz.Domain.Enums;
public class Payment:BaseAuditableEntity
{
    public int ReceptId { get; set; }
    public string SecretId { get; set; }
    public string? ConfirmToken { get; set; }
    public PaymentStatuses PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public int PackageId { get; set; }
    public Package? Package { get; set; }

}
