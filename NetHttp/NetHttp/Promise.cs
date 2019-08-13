using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace NetHttp
{

    public class Promise
    {
        private object data;
        private Exception err;

        public Promise(object data)
        {
            this.data = data;
        }

        public Promise Then(Func<object, object> func)
        {
            data = (func(data));
            return this;
        }

        public void Then(Action<object> func)
        {
            func(data);
        }

    }
}
