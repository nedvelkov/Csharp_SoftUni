namespace MyWebServer.App.Controllers
{
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using MyWebServer.Responses;

    public class HomeController:Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index() => Text("Hello from Ned!");

        public HttpResponse LocalRedirect() => Redirect("/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://https://softuni.bg");

    }
}
