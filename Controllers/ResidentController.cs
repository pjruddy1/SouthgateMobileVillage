using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SouthgateMobileVillage.DAL;
using SouthgateMobileVillage.Models;

namespace SouthgateMobileVillage.Controllers
{
    public class ResidentController : Controller
    {
        private ResidentContext db = new ResidentContext();

        // GET: Resident
        public ActionResult Index()
        {
            var residents = db.Residents.Include(r => r.Home);
            return View(residents.ToList());
        }

        // GET: Resident/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // GET: Resident/Create
        public ActionResult Create()
        {
            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID");
            return View();
        }

        // POST: Resident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HomeID,FirstName,LastName")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Residents.Add(resident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID", resident.HomeID);
            return View(resident);
        }

        // GET: Resident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID", resident.HomeID);
            return View(resident);
        }

        // POST: Resident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HomeID,FirstName,LastName")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID", resident.HomeID);
            return View(resident);
        }

        // GET: Resident/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // POST: Resident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resident resident = db.Residents.Find(id);
            db.Residents.Remove(resident);
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
