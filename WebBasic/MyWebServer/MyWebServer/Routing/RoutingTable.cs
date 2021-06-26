
namespace MyWebServer.Routing
{
    using System;
    using System.Collections.Generic;

    using MyWebServer.Common;
    using MyWebServer.Http;
    using MyWebServer.Responses;

    public class RoutingTable : IRoutingTable
    {
        //Dictionary of HttpResposnses based on HttpRequests
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new() //short syntax for initilize 
            {
                [HttpMethod.Get] = new(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new(),
            };
        }

        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            Guard.AgaintsNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgaintsNull(path, nameof(path));
            Guard.AgaintsNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;
            return this;
        }


        public IRoutingTable MapGet(string path, HttpResponse response)
                          => MapGet(path, request => response);


        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
                => Map(HttpMethod.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, HttpResponse response)
                         => MapPost(path, request => response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
                        => Map(HttpMethod.Post, path, responseFunction);


        public IRoutingTable MapPut(string path, HttpResponse response)
                         => Map(HttpMethod.Put, path, response);
        public IRoutingTable MapDelete(string path, HttpResponse response)
                         => Map(HttpMethod.Delete, path, response);

        public HttpResponse ExecuteResponse(HttpRequest request)
        {
            
            var requestMethod = request.HttpMethod;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            //return HttpResposne based on Request
            return responseFunction(request);
        }


    }
}
