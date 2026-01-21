using Microsoft.AspNetCore.Mvc;

namespace TourismPlatform.Controllers
{
    public class TouristController : Controller
    {
        // Default action
        public IActionResult Index()
        {
            return View();
        }

        // STEP 5: Browse Tours
        public IActionResult BrowseTours()
        {
            return View();
        }

        // STEP 6: My Bookings
        public IActionResult MyBookings()
        {
            return View();
        }

        // STEP 7: Tour Details
        public IActionResult TourDetails()
        {
            return View();
        }

        // STEP 8: Feedback
        public IActionResult Feedback()
        {
            return View();
        }
    }
}

