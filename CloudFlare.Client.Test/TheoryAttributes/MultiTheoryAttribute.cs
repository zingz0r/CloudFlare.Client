using System;
using System.Linq;
using Xunit;

namespace CloudFlare.Client.Test.TheoryAttributes
{
    public sealed class MultiTheoryAttribute : TheoryAttribute
    {
        public MultiTheoryAttribute(params Type[] types)
        {
            var result = types.Select(Activator.CreateInstance).Cast<FactAttribute>().ToList();

            if (result.Any(x => !string.IsNullOrEmpty(x.Skip)))
            {
                Skip = string.Join(", ", result.Where(y => !string.IsNullOrEmpty(y.Skip)).Select(z => z.Skip));
            }
        }
    }
}