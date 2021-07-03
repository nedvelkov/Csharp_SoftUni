using SharedTrip.Data;
using System.Linq;

namespace SharedTrip.Services
{
    public class UserTripService : IUserTripService
    {
        private readonly ApplicationDbContext data;

        public UserTripService(ApplicationDbContext data) => this.data = data;

        public int FreeSeatTrip(string userId, string tripId)
        {
            var tripSeats = this.data.Trips.First(x => x.Id == tripId).Seats;

            var allPassengers = this.data.UserTrips.Where(x => x.TripId == tripId).Count();

            return tripSeats - allPassengers;
        }
    }
}
