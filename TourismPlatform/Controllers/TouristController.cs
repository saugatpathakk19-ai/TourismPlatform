using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismPlatform.Models;
using System;
using System.Linq;

namespace TourismPlatform.Controllers
{
    public class TouristController : Controller
    {
        private readonly TourismDbContext _db;

        public TouristController(TourismDbContext db)
        {
            _db = db;
        }

        // =========================
        // Dashboard
        // =========================
        // GET: /Tourist
        public IActionResult Index()
        {
            return View();
        }

        // =========================
        // Browse Tours (demo page)
        // =========================
        // GET: /Tourist/BrowseTours
        public IActionResult BrowseTours()
        {
            return View();
        }

        // =========================
        // Tour Details (demo page)
        // =========================
        // GET: /Tourist/TourDetails
        public IActionResult TourDetails()
        {
            return View();
        }

        // =========================
        // BOOKING (Create + History)
        // =========================

        // GET: /Tourist/BookTour
        public IActionResult BookTour()
        {
            return View(new Booking());
        }

        // POST: /Tourist/BookTour
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookTour(Booking booking)
        {
            if (!ModelState.IsValid)
                return View(booking);

            // auto set if your model has CreatedAt
            if (booking.CreatedAt == default)
                booking.CreatedAt = DateTime.Now;

            // auto set if your model has Status
            if (string.IsNullOrWhiteSpace(booking.Status))
                booking.Status = "Pending";

            _db.Bookings.Add(booking);
            _db.SaveChanges();

            TempData["BookingSuccess"] = "Booking created successfully!";
            return RedirectToAction(nameof(MyBookings));
        }

        // GET: /Tourist/MyBookings
        public IActionResult MyBookings()
        {
            var list = _db.Bookings
                          .OrderByDescending(b => b.CreatedAt)
                          .ToList();

            return View(list);
        }

        // =========================
        // EDIT BOOKING
        // =========================

        // GET: /Tourist/EditBooking/5
        public IActionResult EditBooking(int id)
        {
            var booking = _db.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: /Tourist/EditBooking/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBooking(int id, Booking booking)
        {
            if (id != booking.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(booking);

            var existing = _db.Bookings.FirstOrDefault(b => b.Id == id);
            if (existing == null)
                return NotFound();

            // Update fields
            existing.TourName = booking.TourName;
            existing.BookingDate = booking.BookingDate;
            existing.NumberOfPeople = booking.NumberOfPeople;
            existing.Status = booking.Status;

            _db.SaveChanges();

            TempData["BookingSuccess"] = "Booking updated successfully!";
            return RedirectToAction(nameof(MyBookings));
        }

        // =========================
        // FEEDBACK (Create + List)
        // =========================

        // GET: /Tourist/Feedback
        public IActionResult Feedback()
        {
            return View(new Feedback());
        }

        // POST: /Tourist/Feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(Feedback feedback)
        {
            if (!ModelState.IsValid)
                return View(feedback);

            // auto set if your model has CreatedAt
            if (feedback.CreatedAt == default)
                feedback.CreatedAt = DateTime.Now;

            _db.Feedbacks.Add(feedback);
            _db.SaveChanges();

            TempData["FeedbackSuccess"] = "Feedback submitted successfully!";
            return RedirectToAction(nameof(FeedbackList));
        }

        // GET: /Tourist/FeedbackList
        public IActionResult FeedbackList()
        {
            var list = _db.Feedbacks
                          .OrderByDescending(f => f.CreatedAt)
                          .ToList();

            return View(list);
        }
    }
}


