namespace SharedTrip.Controllers
{
    using System;
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;


    public class TripsController:Controller
    {

        private readonly ApplicationDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher hasher;
        private readonly ITripService tripService;
        public TripsController(ApplicationDbContext data,
                                IValidator validator,
                                IPasswordHasher hasher,
                                ITripService tripService)
        {
            this.data = data;
            this.validator = validator;
            this.hasher = hasher;
            this.tripService = tripService;
        }
            [Authorize]
        public HttpResponse All()
        {
            var viewModel = this.data
                            .Trips
                            .Select(x => new AllTripViewModel
                            {
                                Id = x.Id,
                                StartPoint = x.StartPoint,
                                EndPoint = x.EndPoint,
                                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                                Seats = x.Seats
                            }).ToList();
            return View(viewModel);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripForm model)
        {
            var errors = this.validator.ValidateTrip(model);
            if (errors.Any())
            {
                return Redirect("/Trips/Add");
            }

            var departure = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = departure,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description,
            };

            ;
            var user = this.data.Users.First(x => x.Id == this.User.Id);

            var userTrip = new UserTrip { Trip = trip, User = user };

            trip.UserTrips.Add(userTrip);

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");

        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            if (this.tripService.ValidTrip(tripId) == false)
            {
                return Redirect("/Trips/All");
            }

            var tripViewModel = this.data
                                .Trips
                                .Where(x => x.Id == tripId)
                                .Select(x => new DetailsTripViewFrom
                                {
                                    Id = x.Id,
                                    StartPoint = x.StartPoint,
                                    EndPoint = x.EndPoint,
                                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                                    ImagePath = x.ImagePath,
                                    Seats = x.Seats,
                                    Description = x.Description
                                }).First();

            return View(tripViewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            var userId = this.User.Id;
            var user = this.data.Users.First(x => x.Id == userId);
            ;
            if (this.data.UserTrips.Any(x => x.TripId == tripId && x.UserId==userId))
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }
            var trip = this.data.Trips.First(x => x.Id == tripId);

            var userTrip = new UserTrip { Trip = trip, User = user };

            var userAsQueary = this.data
                                    .Users
                                    .Single(x => x.Id == this.User.Id);
            userAsQueary.UserTrips.Add(userTrip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
