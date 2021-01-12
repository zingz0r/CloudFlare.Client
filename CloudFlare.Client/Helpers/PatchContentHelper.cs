using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace CloudFlare.Client.Helpers
{
    public static class PatchContentHelper
    {
        /// <summary>
        /// Creates StringContent which can be sent with PatchAsync
        /// </summary>
        /// <typeparam name="T">Type of the incoming value</typeparam>
        /// <param name="value">Content to convert to sendable object</param>
        /// <returns></returns>
        public static StringContent Create<T>(T value)
        {
            return new(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
        }
    }
}