using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CruiseWeb.Models;

namespace CruiseWeb.Controllers
{
    [Authorize]
    public class CruisController : Controller
    {
        private Cruise_Models db = new Cruise_Models();

        // GET: Cruis
        public ActionResult Index()
        {
            return View(db.Cruises.ToList());
        }

        // GET: Cruis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruis cruis = db.Cruises.Find(id);
            if (cruis == null)
            {
                return HttpNotFound();
            }
            return View(cruis);
        }

        // GET: Cruis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cruis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "CruiseId,CruiseName,CruiseDepPortName,CruiseArrPortName,CostPerNight,Duration")] Cruis cruis)
        {
            if (ModelState.IsValid)
            {
                db.Cruises.Add(cruis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cruis);
        }

        // GET: Cruis/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruis cruis = db.Cruises.Find(id);
            if (cruis == null)
            {
                return HttpNotFound();
            }
            return View(cruis);
        }

        // POST: Cruis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "CruiseId,CruiseName,CruiseDepPortName,CruiseArrPortName,CostPerNight,Duration")] Cruis cruis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cruis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cruis);
        }

        // GET: Cruis/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruis cruis = db.Cruises.Find(id);
            if (cruis == null)
            {
                return HttpNotFound();
            }
            return View(cruis);
        }

        // POST: Cruis/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cruis cruis = db.Cruises.Find(id);
            db.Cruises.Remove(cruis);
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
