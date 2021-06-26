namespace MyWebServer.App
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.App.Controllers;

    public class SetUp
    {
        public static async Task Main()
           => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/softuni", c => c.ToSoftUni())
                .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                .MapGet<AnimalsController>("/Cats", c => c.Cats())
                .MapGet<AnimalsController>("/Dogs", c => c.Dogs()))
                //.MapGet("/Cats", request => new AnimalsController(request).Cats())
                //.MapGet("/Dogs", request => new AnimalsController(request).Dogs()))
                .Start();

    }
}
