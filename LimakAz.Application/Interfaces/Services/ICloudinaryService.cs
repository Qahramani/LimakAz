using Microsoft.AspNetCore.Http;

namespace LimakAz.Application.Interfaces.Services;

public interface ICloudinaryService
{
    Task<bool> FileDeleteAsync(string filePath);
    Task<string> FileCreateAsync(IFormFile file);
}
