using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CruiseOnWeb.Models;

namespace CruiseOnWeb.Controllers
{
    public class CruisController : Controller
    {
        private CruiseOnWeb_Model db = new CruiseOnWeb_Model();

        // GET: Cruis
        //[Authorize]
        //public ActionResult Index()
        //{
        //    var cruises = db.Cruises.Include(c => c.User);
        //    return View(cruises.ToList());
        //}

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
            ViewBag.UsId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Cruis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CruiseId,CruiseName,CruiseDepPortName,CruiseArrPortName,Cost,Duration")] Cruis cruis)
        {
            if (ModelState.IsValid)
            {
                db.Cruises.Add(cruis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UsId = new SelectList(db.Users, "Id", "FirstName", cruis.UsId);
            return View(cruis);
        }

        // GET: Cruis/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cruis cruis = db.Cruises.Find(id);
        //    if (cruis == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //ViewBag.UsId = new SelectList(db.Users, "Id", "FirstName", cruis.UsId);
        //    //return View(cruis);
        //}

        // POST: Cruis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CruiseId,CruiseName,CruiseDepPortName,CruiseArrPortName,Cost,Duration")] Cruis cruis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cruis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UsId = new SelectList(db.Users, "Id", "FirstName", cruis.UsId);
            return View(cruis);
        }

        // GET: Cruis/Delete/5
        [Authorize(Roles ="Administrator")]
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
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
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
