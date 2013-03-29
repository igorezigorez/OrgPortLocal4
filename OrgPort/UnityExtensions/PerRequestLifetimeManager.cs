using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.UnityExtensions
{
    public class PerRequestLifetimeManager : LifetimeManager, IDisposable
    {
        private readonly IPerRequestStore store;
        private readonly Guid key = Guid.NewGuid();

        public PerRequestLifetimeManager(IPerRequestStore store)
        {
            this.store = store;
            this.store.EndRequest += EndRequestHandler;
        }

        public override object GetValue()
        {
            return store.GetValue(key);
        }

        public override void SetValue(object newValue)
        {
            store.SetValue(key, newValue);
        }

        public override void RemoveValue()
        {
            var oldValue = store.GetValue(key);
            store.RemoveValue(key);

            if (oldValue is IDisposable)
            {
                ((IDisposable)oldValue).Dispose();
            }
        }

        public void Dispose()
        {
            this.RemoveValue();
            GC.SuppressFinalize(this);
        }

        public void EndRequestHandler(object sender, EventArgs e)
        {
            this.RemoveValue();
        }
    }
}