namespace SharedTrip.Services
{
    using System.Linq;
    using SharedTrip.Data;

    public class UserServices : IUserServices
    {
        public readonly ApplicationDbContext data;
        public UserServices(ApplicationDbContext data) => this.data = data;

        public bool ValidUserCreditentials(string username, string password)
            => this.data
                  .Users
                  .Any(u => u.Username == username && u.Password == password);

        public bool UsernameAvailable(string username)
            => this.data
                   .Users
                   .Any(u => u.Username == username);
        public bool EmailAvailable(string email)
            => this.data
                   .Users
                   .Any(u => u.Email == email);

        public string UserId(string username, string password)
           => this.data
                  .Users
                  .First(u => u.Username == username && u.Password == password).Id;
    }
}
