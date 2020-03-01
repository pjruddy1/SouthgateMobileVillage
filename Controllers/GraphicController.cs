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
    public class GraphicController : Controller
    {
        private ResidentContext db = new ResidentContext();

        // GET: Graphic
        public ActionResult Index()
        {
            var graphics = db.Graphics.Include(g => g.Home);
            return View(graphics.ToList());
        }

        // GET: Graphic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // GET: Graphic/Create
        public ActionResult Create()
        {
            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID");
            return View();
        }

        // POST: Graphic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HomeID,Photo,AltText")] Graphic graphic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Graphics.Add(graphic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unaable to save changes. Try again and if the problem persists contact your admin");
                }
                
            }

            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID", graphic.HomeID);
            return View(graphic);
        }

        // GET: Graphic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID", graphic.HomeID);
            return View(graphic);
        }

        // POST: Graphic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HomeID,Photo,AltText")] Graphic graphic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(graphic).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unaable to save changes. Try again and if the problem persists contact your admin");
                }
                
            }
            ViewBag.HomeID = new SelectList(db.Homes, "ID", "ID", graphic.HomeID);
            return View(graphic);
        }

        // GET: Graphic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graphic graphic = db.Graphics.Find(id);
            if (graphic == null)
            {
                return HttpNotFound();
            }
            return View(graphic);
        }

        // POST: Graphic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Graphic graphic = db.Graphics.Find(id);
                db.Graphics.Remove(graphic);
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
