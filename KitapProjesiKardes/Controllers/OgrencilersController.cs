using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KitapProjesiKardes.Models;

namespace KitapProjesiKardes.Controllers
{
    public class OgrencilersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ogrencilers
        public ActionResult Index()
        {
            return View(db.Ogrencilers.ToList());
        }

        // GET: Ogrencilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenciler ogrenciler = db.Ogrencilers.Find(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        // GET: Ogrencilers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogrencilers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciID,Name,Address,Contact")] Ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                db.Ogrencilers.Add(ogrenciler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenciler);
        }

        // GET: Ogrencilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenciler ogrenciler = db.Ogrencilers.Find(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        // POST: Ogrencilers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciID,Name,Address,Contact")] Ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenciler);
        }

        // GET: Ogrencilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenciler ogrenciler = db.Ogrencilers.Find(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        // POST: Ogrencilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenciler ogrenciler = db.Ogrencilers.Find(id);
            db.Ogrencilers.Remove(ogrenciler);
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
