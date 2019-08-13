using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHttp
{
    public class HttpProtocol
    {
        public string body;
        public Dictionary<string, object> headers = new Dictionary<string, object>();
    }

    public class Response : HttpProtocol
    {

    }

    public class Request : HttpProtocol
    {

    }
}

