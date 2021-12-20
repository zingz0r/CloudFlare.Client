using System;

namespace CloudFlare.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DataTypeDnsRecordAttribute : Attribute
    {
        public DataTypeDnsRecordAttribute()
        {
        }   
    }
}
