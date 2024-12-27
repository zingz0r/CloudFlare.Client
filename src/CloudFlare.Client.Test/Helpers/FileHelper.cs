using System.IO;

namespace CloudFlare.Client.Test.Helpers;

public static class FileHelper
{
    public static FileInfo CreateTempFile(string fileName)
    {
        var fileInfo = new FileInfo(fileName);

        FileStream fileStream = null;
        try
        {
            fileStream = File.Create(Path.Combine(fileName));
        }
        finally
        {
            fileStream?.Dispose();
        }

        return fileInfo;
    }
}