using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models;

internal class ParameterBuilder
{
    private readonly NameValueCollection _parameterCollection;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ParameterBuilder"/> class
    /// </summary>
    public ParameterBuilder()
    {
        _parameterCollection = HttpUtility.ParseQueryString(string.Empty);
    }

    /// <summary>
    /// Insert parameter in the collection
    /// </summary>
    /// <typeparam name="T">Type of the inserting parameter</typeparam>
    /// <param name="key">Parameter name</param>
    /// <param name="value">Value of the parameter</param>
    /// <returns>ParameterBuilderHelper</returns>
    public ParameterBuilder InsertValue<T>(string key, T value)
    {
        if (!EqualityComparer<T>.Default.Equals(value, default) &&
            ((value is string str && !string.IsNullOrEmpty(str)) || value is not string) &&
            !string.IsNullOrEmpty(key))
        {
            _parameterCollection[key] = HttpUtility.UrlDecode(JsonConvert.SerializeObject(value).Replace("\"", string.Empty));
        }

        return this;
    }

    public bool Any()
    {
        return _parameterCollection.HasKeys();
    }
    
    public override string ToString()
    {
        return _parameterCollection.ToString();
    }
}
