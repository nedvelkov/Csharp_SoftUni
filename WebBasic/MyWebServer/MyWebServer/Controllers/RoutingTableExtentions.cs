
namespace MyWebServer.Controllers
{
    using System;

    using MyWebServer.Http;
    using MyWebServer.Routing;

    public static class RoutingTableExtentions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path, Func<TController, HttpResponse> controlenFunction)
             where TController : Controller
            => routingTable.MapGet(path, request =>
            {
                var controller = CreteControler<TController>(request);
                return controlenFunction(controller);
            });

        public static IRoutingTable MapPost<TController>(
    this IRoutingTable routingTable,
    string path, Func<TController, HttpResponse> controlenFunction)
     where TController : Controller
           => routingTable.MapPost(path, request =>
           {
               var controller = CreteControler<TController>(request);
               return controlenFunction(controller);
           });


        private static TController CreteControler<TController>(HttpRequest request)
        => (TController)Activator.CreateInstance(typeof(TController), new[] { request });
    }
}
