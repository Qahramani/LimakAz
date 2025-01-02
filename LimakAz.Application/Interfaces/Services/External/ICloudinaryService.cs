using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.Interfaces.Services.External;

public interface ICloudinaryService
{
    Task<bool> FileDeleteAsync(string filePath);
    Task<string> FileCreateAsync(IFormFile file);
}
