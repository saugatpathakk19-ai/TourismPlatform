using Microsoft.EntityFrameworkCore;

namespace TourismPlatform.Models
{
    public class TourismDbContext : DbContext
    {
        public TourismDbContext(DbContextOptions<TourismDbContext> options)
            : base(options)
        {
        }

        // =========================
        // TABLES
        // =========================

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}

