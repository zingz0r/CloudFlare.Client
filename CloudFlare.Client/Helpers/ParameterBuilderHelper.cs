using System.Text;
using System.Web;

namespace CloudFlare.Client.Helpers
{
    public static class ParameterBuilderHelper
    {
        public static void InsertValue<T>(ref StringBuilder parameterBuilder, string key, T value)
        {
            if (value == null)
                return;

            if (typeof(T) == typeof(string) && string.IsNullOrEmpty((string)(object)value))
                return;

            parameterBuilder.Append("&");
            parameterBuilder.Append(key);
            parameterBuilder.Append("=");
            parameterBuilder.Append(HttpUtility.UrlEncode(value.ToString()));
        }
    }
}