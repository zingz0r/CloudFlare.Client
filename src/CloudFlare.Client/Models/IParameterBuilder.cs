namespace CloudFlare.Client.Models;

internal interface IParameterBuilder
{
    /// <summary>
    /// Insert parameter in the collection
    /// </summary>
    /// <typeparam name="T">Type of the inserting parameter</typeparam>
    /// <param name="key">Parameter name</param>
    /// <param name="value">Value of the parameter</param>
    /// <returns>ParameterBuilderHelper</returns>
    IParameterBuilder InsertValue<T>(string key, T value);

    /// <summary>
    /// Whether there are any parameter
    /// </summary>
    /// <returns></returns>
    bool Any();
    
    /// <summary>
    /// Converts the parameters to a string
    /// </summary>
    /// <returns>The parameters as string</returns>
    string ToString();
}
