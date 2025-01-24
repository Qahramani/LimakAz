namespace LimakAz.Persistence.Helpers;

public static class Helper
{   
    public static string GetSolutionRoot()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        while (Directory.GetParent(currentDirectory) != null)
        {
            if (Directory.GetFiles(currentDirectory, "*.sln").Length > 0)
            {
                return currentDirectory;
            }       
            currentDirectory = Directory.GetParent(currentDirectory)?.FullName ?? "";
        }
        throw new Exception("Solution file (.sln) not found.");
    }

    public static string GenerateUserCode()
    {
        var timestamp = DateTime.UtcNow.Ticks.ToString().Substring(10,7);
        var random = new Random();
        var randomDigits = random.Next(1000, 9999);

        var uniquuCode = timestamp + randomDigits.ToString();

        return uniquuCode;
    }
    public static string GenerateOrderNO()
    {
        var timestamp = DateTime.UtcNow.Ticks.ToString().Substring(10,7);
        var orderNo = "LMK00" + timestamp;

        return orderNo;
    }
}
