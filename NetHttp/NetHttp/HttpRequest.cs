using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NetHttp
{
    public enum HttpMethodType
    {
        POST,
        GET,
        DELETE,
        PUT,
        PATCH,
        OPTION
    }

    public enum MediaType
    {
        JSON,
        XML
    }

    public class HttpRequest
    {

        private string mediaType;

        public HttpRequest(MediaType mediaType = MediaType.JSON)
        {
            switch (mediaType)
            {
                case MediaType.JSON:
                    this.mediaType = "application/json";
                    break;
                case MediaType.XML:
                    this.mediaType = "application/xml";
                    break;
            }
        }

        public async Task<Response> Get(string url)
        {
            return await Execute(url, HttpMethodType.GET);
        }

        public async Task<Response> Post(string url,string body)
        {
            return await Execute(url, HttpMethodType.POST, body);
        }

        public async Task<Response> Delete(string url)
        {
            return await Execute(url, HttpMethodType.DELETE);
        }

        public async Task<Response> Put(string url, string body)
        {
            return await Execute(url, HttpMethodType.PUT, body);
        }

        private async Task<Response> Execute(string url, HttpMethodType method, string body = "")
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaType));

            using (HttpResponseMessage res = await GetHttpMethod(url,method,body))
            {
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();

                    Response response = new Response();
                    response.body = data;

                    HttpHeaders h = content.Headers;

                    foreach (var header in h)
                    {
                        response.headers.Add(header.Key, header.Value);
                    }

                    return response;
                }
            }

        }

        private async Task<HttpResponseMessage> GetHttpMethod(string url, HttpMethodType method, string body = "")
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaType));

            switch (method)
            {
                case HttpMethodType.POST:
                    return await client.PostAsync(url, new StringContent(body));
                case HttpMethodType.GET:
                    return await client.GetAsync(url);
                case HttpMethodType.DELETE:
                    return await client.DeleteAsync(url);
                case HttpMethodType.PUT:
                    return await client.PutAsync(url, new StringContent(body));
                default:
                    throw new Exception("This http method doesn't exist or it's currently not supported");
            }
        }
    }
}
