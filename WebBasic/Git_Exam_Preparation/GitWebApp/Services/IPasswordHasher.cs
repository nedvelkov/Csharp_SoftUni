namespace GitWebApp.Services
{
   public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
