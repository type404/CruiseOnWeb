using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CruiseWeb.Models;
using Microsoft.AspNet.Identity;

namespace CruiseWeb.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private Cruise_Models db = new Cruise_Models();

        // GET: Bookings
        public ActionResult Index()
        {
            if (User.IsInRole("Customer")){
             var userName = User.Identity.GetUserName();
             var customers = db.Bookings.Where(u => u.Username == userName).ToList();
            return View(customers);
            } else
            {
                return View(db.Bookings.ToList());
            }

        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            var context = new Cruise_Models();
            var cruiseName = (from c in context.Cruises select c.CruiseName).ToList();
            ViewBag.CruiseNames = new SelectList(cruiseName);
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateGoogleCaptcha]
        public ActionResult Create([Bind(Include = "BookingId,Username,CruiseName,StartDate,EndDate,NumberOfPeople,TotalPrice")] Booking booking)
        {
            booking.CruiseName = Request["CruiseName"].ToString();
            if (DateTime.Compare(booking.StartDate, DateTime.UtcNow) < 0)
            {
                TempData["ErrorMessageDate"] = "Please check the date and retry!";
                return RedirectToAction("Create");
            }
            if (booking.NumberOfPeople < 1 || booking.NumberOfPeople > 10)
            {
                TempData["ErrorMessagePeople"] = "Enter people between 1-10!";
                return RedirectToAction("Create");
            }
            var context = new Cruise_Models();
            var tempDuration = (from c in context.Cruises where c.CruiseName == booking.CruiseName select c.Duration).Single();
            var tempCostNight = (from c in context.Cruises where c.CruiseName == booking.CruiseName select c.CostPerNight).Single();
            booking.Username = User.Identity.GetUserName();
            booking.EndDate = booking.StartDate.AddDays(Convert.ToDouble(tempDuration));
            booking.TotalPrice = booking.NumberOfPeople * Convert.ToInt32(tempCostNight);
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Username,CruiseName,StartDate,EndDate,NumberOfPeople,TotalPrice")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}