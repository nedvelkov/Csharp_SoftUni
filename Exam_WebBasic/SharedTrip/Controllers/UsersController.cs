namespace SharedTrip.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;

    public class UsersController:Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher hasher;
        private readonly IUserServices userServices;
        public UsersController(ApplicationDbContext data,
                                IValidator validator,
                                IPasswordHasher hasher,
                                IUserServices userServices)
        {
            this.data = data;
            this.validator = validator;
            this.hasher = hasher;
            this.userServices = userServices;
        }
        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterViewForm model)
        {
            var errors = this.validator.ValidateUser(model);
            if (this.userServices.UsernameAvailable(model.Username))
            {
                return Redirect("/Users/Register");
              //  return Error($"Username '{model.Username}' is already register.");
            }
            if (this.userServices.EmailAvailable(model.Email))
            {
                return Redirect("/Users/Register");
               // return Error($"Email address '{model.Email}' is already register.");
            }
            if (errors.Any())
            {
                return Redirect("/Users/Register");
               // return Error(errors);
            }

            var hashPassword = this.hasher.HashPassword(model.Password);
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashPassword,
            };
            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginViewForm model)
        {
            var hashPassoword = this.hasher.HashPassword(model.Password);
           if( this.userServices.ValidUserCreditentials(model.Username, hashPassoword) == false)
            {
                return Redirect("/Users/Login");
            }

            var userId = this.userServices.UserId(model.Username, hashPassoword);

            this.SignIn(userId);

            return Redirect("/Trips/All");

        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
