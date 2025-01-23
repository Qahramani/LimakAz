namespace LimakAz.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto);
    Task<bool> ConfirmPaymentAsync(PaymentCheckDto dto);
}
