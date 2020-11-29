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
    public class OduncsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Oduncs
        public ActionResult Index()
        {
            var oduncs = db.Oduncs.Include(o => o.Kitaplar).Include(o => o.Ogrenciler);
            return View(oduncs.ToList());
        }

        // GET: Oduncs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odunc odunc = db.Oduncs.Find(id);
            if (odunc == null)
            {
                return HttpNotFound();
            }
            return View(odunc);
        }

        // GET: Oduncs/Create
        public ActionResult Create()
        {
            ViewBag.KitapID = new SelectList(db.Kitaplars, "KitapID", "KitapAdi");
            ViewBag.OgrenciID = new SelectList(db.Ogrencilers, "OgrenciID", "Name");
            return View();
        }

        // POST: Oduncs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OduncId,OduncAlinmaTarihi,TeslimEdilmeTarihi,OgrenciID,KitapID")] Odunc odunc)
        {
            if (ModelState.IsValid)
            {
                db.Oduncs.Add(odunc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KitapID = new SelectList(db.Kitaplars, "KitapID", "KitapAdi", odunc.KitapID);
            ViewBag.OgrenciID = new SelectList(db.Ogrencilers, "OgrenciID", "Name", odunc.OgrenciID);
            return View(odunc);
        }

        // GET: Oduncs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odunc odunc = db.Oduncs.Find(id);
            if (odunc == null)
            {
                return HttpNotFound();
            }
            ViewBag.KitapID = new SelectList(db.Kitaplars, "KitapID", "KitapAdi", odunc.KitapID);
            ViewBag.OgrenciID = new SelectList(db.Ogrencilers, "OgrenciID", "Name", odunc.OgrenciID);
            return View(odunc);
        }

        // POST: Oduncs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OduncId,OduncAlinmaTarihi,TeslimEdilmeTarihi,OgrenciID,KitapID")] Odunc odunc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odunc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KitapID = new SelectList(db.Kitaplars, "KitapID", "KitapAdi", odunc.KitapID);
            ViewBag.OgrenciID = new SelectList(db.Ogrencilers, "OgrenciID", "Name", odunc.OgrenciID);
            return View(odunc);
        }

        // GET: Oduncs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odunc odunc = db.Oduncs.Find(id);
            if (odunc == null)
            {
                return HttpNotFound();
            }
            return View(odunc);
        }

        // POST: Oduncs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odunc odunc = db.Oduncs.Find(id);
            db.Oduncs.Remove(odunc);
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
