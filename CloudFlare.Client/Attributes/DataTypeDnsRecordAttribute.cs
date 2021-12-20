using System;

namespace CloudFlare.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class DataTypeDnsRecordAttribute : Attribute
    {
        public DataTypeDnsRecordAttribute()
        {
        }   
    }
}
