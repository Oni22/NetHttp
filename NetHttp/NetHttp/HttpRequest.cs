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

        /// <summary>
        /// Http get request
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Promise</returns>
        public async Task<Response> Get(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaType));

            using (HttpResponseMessage res = await client.GetAsync(url))
            {
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();

                    Response response = new Response();
                    response.body = data;
                    response.headers = content.Headers.ContentEncoding.ToList();
                    return response;
                }
            }
        }

        public async Task<Response> Post(string url,string body)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaType));

            using (HttpResponseMessage res = await client.PostAsync(url, new StringContent(body)))
            {
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();

                    Response response = new Response();
                    response.body = data;
                    response.headers = content.Headers.ContentEncoding.ToList();
                    return response;
                }
            }
        }
    }
}
