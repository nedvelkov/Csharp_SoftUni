namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using System.Linq;

    public class TripService : ITripService
    {
        private readonly ApplicationDbContext data;
        public TripService(ApplicationDbContext data) => this.data = data;
        public bool ValidTrip(string id)
            => this.data
                    .Trips
                    .Any(x => x.Id == id);
    }
}
