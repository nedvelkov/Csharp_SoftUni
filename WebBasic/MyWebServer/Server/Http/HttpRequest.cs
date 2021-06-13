
namespace MyWebServer.Server.Http
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class HttpRequest
    {
        private const string NewLine = "\r\n";
        public HttpMethod HttpMethod { get; init; }

        public string Url { get; private set; }

        public HttpHeaderCollection Headers { get; private set; } = new HttpHeaderCollection();

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            ;
            var lines = request.Split(NewLine);


            var starLine = lines[0].Split(" ");

            var method = ParseHttpMethod(starLine[0]);
            var url = starLine[1];

            var headers = ParseHttpHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(2 + headers.Count);

            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest
            {
                HttpMethod = method,
                Url = url,
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
