namespace GitWebApp.Services
{

using GitWebApp.Data;
    using System.Linq;

    class UserService : IUsersService
    {
        private readonly GitDbContext data;
        public UserService(GitDbContext data)
        {
            this.data = data;
        }

        public string GetUserId(string username, string password)
            => this.data
                .GitUsers
                .FirstOrDefault(x => x.Username == username && x.Password == password)
                .Id;

        public bool IsEmailAvailable(string email)
            => this.data
                .GitUsers
                .Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username)
            => this.data
                .GitUsers
                .Any(x => x.Username == username);
    }
}
