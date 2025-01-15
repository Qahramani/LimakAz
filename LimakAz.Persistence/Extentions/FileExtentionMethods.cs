using Microsoft.AspNetCore.Http;

namespace LimakAz.Persistence.Extentions;

public static class FileExtentionMethods
{
    public static bool CheckType(this IFormFile file, string fileType = "image")
    {
        return file.ContentType.Contains(fileType);
    }
    public static bool CheckSize(this IFormFile file, int MB = 2)
    {
        return file.Length <= MB * 1024 * 1024;
    }
}
