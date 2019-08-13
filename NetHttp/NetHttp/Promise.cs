using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace NetHttp
{

    public class Promise
    {
        object data;

        public Promise(object data)
        {
            this.data = data;
        }

        public Promise Then(Func<object,object> func)
        {
            return new Promise(func(data));
        }
    }
}
