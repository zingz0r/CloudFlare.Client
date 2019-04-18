using System.Text;
using System.Web;

namespace CloudFlare.Client.Helpers
{
    public static class ParameterBuilderHelper
    {
        /// <summary>
        /// Inserts value into the referenced string builder.
        /// </summary>
        /// <typeparam name="T">Generic type of incoming data</typeparam>
        /// <param name="parameterBuilder">String builder reference</param>
        /// <param name="key">Key string</param>
        /// <param name="value">Value</param>
        public static StringBuilder InsertValue<T>(StringBuilder parameterBuilder, string key, T value)
        {
            if (value == null)
                return parameterBuilder;

            if (typeof(T) == typeof(string) && string.IsNullOrEmpty((string)(object)value))
                return parameterBuilder;

            parameterBuilder.Append("&");
            parameterBuilder.Append(key);
            parameterBuilder.Append("=");
            parameterBuilder.Append(HttpUtility.UrlEncode(value.ToString()));

            return parameterBuilder;
        }
    }
}