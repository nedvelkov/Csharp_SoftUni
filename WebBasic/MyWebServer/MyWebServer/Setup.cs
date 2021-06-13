namespace MyWebServer
{
    using System.Threading.Tasks;
    using MyWebServer.Server;
    using MyWebServer.Server.Responses;

    public class SetUp
    {
        public static async Task Main()
           => await new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from Ned!"))
                .MapGet("/Cats", new TextResponse("Hello from cats!"))
                .MapGet("/Dogs", new TextResponse("Hello from dogs")))
                .Start();

    }
}
