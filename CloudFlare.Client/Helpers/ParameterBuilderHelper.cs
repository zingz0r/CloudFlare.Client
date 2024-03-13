using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Helpers
{
    internal class ParameterBuilderHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterBuilderHelper"/> class
        /// </summary>
        public ParameterBuilderHelper()
        {
            ParameterCollection = HttpUtility.ParseQueryString(string.Empty);
        }

        /// <summary>
        /// Property that holds the parameters
        /// </summary>
        public NameValueCollection ParameterCollection { get; set; }

        /// <summary>
        /// Insert parameter in the collection
        /// </summary>
        /// <typeparam name="T">Type of the inserting parameter</typeparam>
        /// <param name="key">Parameter name</param>
        /// <param name="value">Value of the parameter</param>
        /// <returns>ParameterBuilderHelper</returns>
        public ParameterBuilderHelper InsertValue<T>(string key, T value)
        {
            if (!EqualityComparer<T>.Default.Equals(value, default) &&
                ((value is string str && !string.IsNullOrEmpty(str)) || value is not string) &&
                !string.IsNullOrEmpty(key))
            {
                ParameterCollection[key] = HttpUtility.UrlDecode(JsonSerializer.Serialize(value, typeof(T), CloudFlareJsonSerializerContext.Default).Replace("\"", string.Empty));
            }

            return this;
        }
    }
}
