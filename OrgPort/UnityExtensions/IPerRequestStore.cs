using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.UnityExtensions
{
    public interface IPerRequestStore
    {
        object GetValue(object key);
        void SetValue(object key, object value);
        void RemoveValue(object key);

        event EventHandler EndRequest;
    }
}