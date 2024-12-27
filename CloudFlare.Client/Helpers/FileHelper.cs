using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFlare.Client.Helpers;

internal static class FileHelper
{
    internal static async Task<byte[]> ReadAsync(string path, CancellationToken cancellationToken)
    {
        
#if NETSTANDARD2_0
        using var sourceStream = File.Open(path, FileMode.Open);
        var result = new byte[sourceStream.Length];
        await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length, cancellationToken).ConfigureAwait(false);
        return result;
#else
        return await File.ReadAllBytesAsync(path, cancellationToken).ConfigureAwait(false);
#endif
    }
}
