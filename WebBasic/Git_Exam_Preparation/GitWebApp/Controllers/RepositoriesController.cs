namespace GitWebApp.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class RepositoriesController : Controller
    {
        public HttpResponse All()
        {
            ;
            return View();
        }

        [Authorize]
        public HttpResponse Create() => View();
        
        [Authorize]
        [HttpPost]
        public HttpResponse Create(object obj)
        {
            return Redirect("/Repositories/All");
        }
    }
}
