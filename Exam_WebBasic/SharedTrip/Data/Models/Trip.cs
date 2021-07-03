namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        [Required]
        public DateTime DepartureTime { get; init; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public string Description { get; init; }

        public string ImagePath { get; init; }

        public ICollection<UserTrip> UserTrips { get; set; } = new HashSet<UserTrip>();
    }
}