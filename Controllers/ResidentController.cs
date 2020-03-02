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
using PagedList;

namespace SouthgateMobileVillage.Controllers
{
    public class ResidentController : Controller
    {
        private ResidentContext db = new ResidentContext();

        // GET: Resident
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LNameSortParm = string.IsNullOrEmpty(sortOrder) ? "l_name_desc" : "";
            ViewBag.FNameSortParm = string.IsNullOrEmpty(sortOrder) ? "f_name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var res = from r in db.Residents select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                res = res.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "l_name_desc":
                    res = res.OrderByDescending(s => s.LastName);
                    break;
                case "f_name_desc":
                    res = res.OrderByDescending(s => s.FirstName);
                    break;
               
                default:
                    res = res.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(res.ToPagedList(pageNumber, pageSize));
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
                try
                {
                    db.Residents.Add(resident);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unaable to save changes. Try again and if the problem persists contact your admin");
                }
                
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
                try
                {
                    db.Entry(resident).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system admin");
                }
               
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
            try
            {
                Resident resident = db.Residents.Find(id);
                db.Residents.Remove(resident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            
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
