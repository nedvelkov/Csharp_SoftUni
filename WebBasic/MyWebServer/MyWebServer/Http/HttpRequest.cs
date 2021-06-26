
namespace MyWebServer.Http
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class HttpRequest
    {
        private const string NewLine = "\r\n";
        public HttpMethod HttpMethod { get; init; }

        public string Path { get; private set; }

        public Dictionary<string, string> Query { get; private set; }

        public HttpHeaderCollection Headers { get; private set; } = new HttpHeaderCollection();

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {

            var lines = request.Split(NewLine);


            var starLine = lines[0].Split(" ");

            var method = ParseHttpMethod(starLine[0]);
            var url = starLine[1];

            var (path, query) = ParseUrl(url);

            var headers = ParseHttpHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(2 + headers.Count);

            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest
            {
                HttpMethod = method,
                Path = path,
                Query=query,
                Headers = headers,
                Body = body,
            };


        }


        private static HttpMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Method {method} is not supported."),
            };
        }
        private static (string Path, Dictionary<string, string> Query) ParseUrl(string url) // the tupul can be left without naming objects
        {
            var urlParts = url.Split('?',2);

            var path = urlParts[0];
            var query = urlParts.Length > 1
                ? ParseQuery(urlParts[1])
                : new Dictionary<string, string>();

            return (path, query);
        }

        private static Dictionary<string, string> ParseQuery(string querySting)
            => querySting
                .Split('&')
                .Select(p => p.Split('='))
                .Where(p => p.Length == 2)
                .ToDictionary(p => p[0], p => p[1]);

        private static HttpHeaderCollection ParseHttpHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headeLine in headerLines)
            {
                if (headeLine == string.Empty)
                {
                    break;
                }
                ;
                var headerParts = headeLine.Split(':', 2);
                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);

            }

            return headerCollection;
        }

    }
}
