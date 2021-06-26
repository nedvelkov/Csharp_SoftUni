namespace GitWebApp
{
    using System.Threading.Tasks;
    using GitWebApp.Data;
    using GitWebApp.Services;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                .Add<IUsersService, UserService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IValidator,Validator>()
                .Add<GitDbContext>())
                .WithConfiguration<GitDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
