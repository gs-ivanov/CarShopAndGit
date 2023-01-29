namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Trip
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; } = DateTime.UtcNow;

        [MaxLength(TripMaxSeats)]
        public int Searts { get; set; }


        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public IEnumerable<User> UserTrips { get; set; } = new List<User>();

    }
}
