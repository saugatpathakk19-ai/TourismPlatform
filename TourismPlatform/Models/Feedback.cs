using System;
using System.ComponentModel.DataAnnotations;

namespace TourismPlatform.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        // Optional: link feedback to Tour (if you have TourId)
        // public int? TourId { get; set; }

        [Required(ErrorMessage = "Feedback message is required.")]
        [StringLength(500, ErrorMessage = "Feedback must be under 500 characters.")]
        public string Message { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; } = 5;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
