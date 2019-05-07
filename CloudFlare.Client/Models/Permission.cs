using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class Permission
    {
        /// <summary>
        /// Permission read property
        /// </summary>
        [JsonProperty("read")]
        public bool Read { get; set; }

        /// <summary>
        /// Permission Write property
        /// </summary>
        [JsonProperty("write")]
        public bool Write { get; set; }
    }
}
