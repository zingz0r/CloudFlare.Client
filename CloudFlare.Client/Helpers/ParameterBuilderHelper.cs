using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Newtonsoft.Json;

namespace CloudFlare.Client.Helpers
{
    public class ParameterBuilderHelper
    {
        /// <summary>
        /// Property that holds the parameters
        /// </summary>
        public NameValueCollection ParameterCollection { get; set; }

        /// <summary>
        /// ParameterBuilderHelper constructor
        /// </summary>
        public ParameterBuilderHelper()
        {
            ParameterCollection = HttpUtility.ParseQueryString(string.Empty);
        }

        /// <summary>
        /// Insert parameter in the collection
        /// </summary>
        /// <typeparam name="T">Type of the inserting parameter</typeparam>
        /// <param name="key">Parameter name</param>
        /// <param name="value">Value of the parameter</param>
        /// <returns></returns>
        public ParameterBuilderHelper InsertValue<T>(string key, T value)
        {
            if (!EqualityComparer<T>.Default.Equals(value, default) &&
                (value is string str && !string.IsNullOrEmpty(str) || !(value is string)) &&
                !string.IsNullOrEmpty(key))
            {
                ParameterCollection[key] = HttpUtility.UrlDecode(JsonConvert.SerializeObject(value).Replace("\"", ""));
            }

            return this;
        }
    }
}