using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgPort.UnityExtensions
{
    public class HttpContextPerRequestStore:IPerRequestStore
    {
        public event EventHandler EndRequest;

        public HttpContextPerRequestStore()
        {
            //HttpContext.Current.ApplicationInstance.EndRequest += EndRequestHandler;
        }

        public void EndRequestHandler(object sender, EventArgs e)
        {
            EventHandler handler = this.EndRequest;
            if (handler != null) handler(this, e);
        }

        public object GetValue(object key)
        {
            return HttpContext.Current.Items[key];
        }

        public void SetValue(object key, object value)
        {
            HttpContext.Current.Items[key] = value;
        }

        public void RemoveValue(object key)
        {
            HttpContext.Current.Items.Remove(key);
        }
    }
}