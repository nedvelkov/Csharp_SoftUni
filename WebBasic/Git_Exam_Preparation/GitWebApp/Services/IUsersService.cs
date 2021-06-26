namespace GitWebApp.Services
{
    public interface IUsersService
    {
        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}
