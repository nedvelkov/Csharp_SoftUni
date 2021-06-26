namespace SharedTrip.Services
{
    public interface IUserServices
    {
        public bool ValidUserCreditentials(string username, string password);

        public bool UsernameAvailable(string username);

        public bool EmailAvailable(string email);

        public string UserId(string username, string password);
    }
}
