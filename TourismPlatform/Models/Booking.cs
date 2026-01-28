using System;
using System.ComponentModel.DataAnnotations;

namespace TourismPlatform.Models
{
    public class Booking
    {
        public int Id { get; set; }

        // ✅ Fix CS8618 warning too
        public string TourName { get; set; } = string.Empty;

        // ✅ Add these two (this fixes your 4 errors)
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        public int NumberOfPeople { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}


