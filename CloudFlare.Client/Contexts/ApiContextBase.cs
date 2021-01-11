using System;
using System.Collections.Generic;
using System.Text;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Contexts
{
    public abstract class ApiContextBase<TConnection> where TConnection : class, IConnection
    {
        protected TConnection Connection { get; }

        protected ApiContextBase(TConnection connection)
        {
            Connection = connection;
        }
    }
}
