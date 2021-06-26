namespace MyWebServer.App.Controllers
{

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class AnimalsController:Controller
    {
        const string nameKey = "Name";

        public AnimalsController(HttpRequest request)
                            : base(request)
        {
        }

        public HttpResponse Cats()
        {

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey) // if 
                                ? query[nameKey]     // true statment   
                                : "the cats";       // false statment   

            var result = $"<h1>Hello from {catName}!<h1>";
            return Html(result);

        }

        public HttpResponse Dogs() 
        {

            var query = this.Request.Query;

            var dogName = query.ContainsKey(nameKey) // if 
                                ? query[nameKey]     // true statment   
                                : "the dogs";       // false statment   

            var result = $"<h1>Hello from {dogName}!<h1>";
            return Html(result);

        }
    }
}
