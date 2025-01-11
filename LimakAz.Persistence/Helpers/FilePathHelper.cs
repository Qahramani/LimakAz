using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Persistence.Helpers;

internal class FilePathHelper : IFilePathHelper
{
    public string GetSolutionRoot()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        while (Directory.GetParent(currentDirectory) != null)
        {
            if (Directory.GetFiles(currentDirectory, "*.sln").Length > 0)
            {
                return currentDirectory;
            }
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }
        throw new Exception("Solution file (.sln) not found.");
    }

    public string GetStaticFilesPath()
    {
        var solutionRoot = GetSolutionRoot();

        return Path.Combine(solutionRoot, "Infrastructure", "LimakAz.Infrastructure", "StaticFiles");
    }
}
