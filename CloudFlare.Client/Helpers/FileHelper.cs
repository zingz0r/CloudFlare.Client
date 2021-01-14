using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFlare.Client.Helpers
{
    public static class FileHelper
    {
        public static async Task<byte[]> ReadAsync(string path, CancellationToken cancellationToken)
        {
            using var sourceStream = File.Open(path, FileMode.Open);
            var result = new byte[sourceStream.Length];

            await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length, cancellationToken);

            return result;
        }
    }
}