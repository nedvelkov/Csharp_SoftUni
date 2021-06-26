namespace GitWebApp.Controllers
{
    using GitWebApp.Data;
    using GitWebApp.Data.Models;
    using GitWebApp.Models;
    using GitWebApp.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly GitDbContext data;
        private readonly IValidator validator;
        private readonly IUsersService usersService;
        private readonly IPasswordHasher passwordHasher;
        
        public UsersController(GitDbContext data,
            IValidator validator,
            IUsersService usersService,
            IPasswordHasher passwordHasher
            )
        {
            this.data = data;
            this.validator = validator;
            this.usersService = usersService;
            this.passwordHasher = passwordHasher;
        }
        public HttpResponse Login() => this.View();
        
        [HttpPost]
        public HttpResponse Login(UserLogInModel model)
        {
            var hashPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = usersService.GetUserId(model.Username, hashPassword);
            if (userId == null)
            {
                if (usersService.IsUsernameAvailable(model.Username))
                {
                    return Error("Password is wrong!");
                }

                return Error($"Username '{model.Username}' is not register!");
            }

            this.SignIn(userId);


            return Redirect("/Repositories/All");
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterUserModel model)
        {
            var errors = this.validator.ValidateUser(model);
            if (usersService.IsEmailAvailable(model.Email))
            {
                errors.Add($"Email '{model.Email}' is already register!");
            }
            if (usersService.IsUsernameAvailable(model.Username))
            {
                errors.Add($"Username '{model.Email}' is already register!");
            }
            if (errors.Any())
            {
                return Error(string.Join(".", errors));
            }

            var hashPassword = this.passwordHasher.HashPassword(model.Password);
            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashPassword
            };

            this.data.GitUsers.Add(newUser);
            this.data.SaveChanges();


            return Redirect("/Repositories/All");
        }
    }
}
