using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudFlare.Client.Test.Helpers
{
    public static class EnumHelper<T>
         where T : Enum
    {
        public static IEnumerable<object[]> GetValuesOf(IEnumerable<T> excepts)
        {
            foreach (var item in Enum.GetValues(typeof(T)).Cast<T>().Where(x => !excepts.Contains(x)))
            {
                yield return new object[] { item };
            }
        }

        public static IEnumerable<object[]> GetValuesOfWithAttribute(Type attributeType)
        {
            foreach (var item in Enum.GetValues(typeof(T)).Cast<T>().Where(x => typeof(T).GetField(x.ToString()).IsDefined(attributeType, false)))
            {
                yield return new object[] { item };
            }
        }

        public static IEnumerable<object[]> GetValuesOfWithoutAttribute(Type attributeType)
        {
            foreach (var item in Enum.GetValues(typeof(T)).Cast<T>().Where(x => !typeof(T).GetField(x.ToString()).IsDefined(attributeType, false)))
            {
                yield return new object[] { item };
            }
        }
    }
}
