namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.Models.Users;
    using SharedTrip.Models.Trips;
    public interface IValidator
    {
        public ICollection<string> ValidateUser(RegisterViewForm model);
        public ICollection<string> ValidateTrip(AddTripForm model);
    }
}
