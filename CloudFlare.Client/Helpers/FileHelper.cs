using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFlare.Client.Helpers
{
    internal static class FileHelper
    {
        internal static async Task<byte[]> ReadAsync(string path, CancellationToken cancellationToken)
        {
            using var sourceStream = File.Open(path, FileMode.Open);
            var result = new byte[sourceStream.Length];

#if NETSTANDARD2_0
            await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length, cancellationToken);
#else
            using var memoryStream = new MemoryStream(result, 0, result.Length, true, true);
            await sourceStream.ReadAsync(memoryStream.GetBuffer(), cancellationToken);
#endif

            return result;
        }
    }
}