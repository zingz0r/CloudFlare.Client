using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Parameters.Data
{
    /// <summary>
    /// Tlsa
    /// </summary>
    public class TlsA : IData
    {
        /// <summary>
        /// The certificate.
        /// </summary>
        [JsonPropertyName("certificate")]
        public string Certificate { get; set; }

        /// <summary>
        /// The matching type.
        /// <para>
        /// Value must be &gt;= 0 and &lt;= 255
        /// </para>
        /// </summary>
        [JsonPropertyName("matching_type")]
        public int MatchingType { get; set; }

        /// <summary>
        /// The selector.
        /// <para>
        /// Value must be &gt;= 0 and &lt;= 255
        /// </para>
        /// </summary>
        [JsonPropertyName("selector")]
        public int Selector { get; set; }

        /// <summary>
        /// The usage.
        /// <para>
        /// Value must be &gt;= 0 and &lt;= 255
        /// </para>
        /// </summary>
        [JsonPropertyName("usage")]
        public int Usage { get; set; }
    }
}
