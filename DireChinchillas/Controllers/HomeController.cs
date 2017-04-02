using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DireChinchillas.Models;

namespace DireChinchillas.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var chinchillas = db.Chinchillas.Include(c => c.Colour).Include(c => c.Father).Include(c => c.Mother);
            return View(chinchillas.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chinchilla chinchilla = db.Chinchillas.Find(id);
            if (chinchilla == null)
            {
                return HttpNotFound();
            }
            return View(chinchilla);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.ColourId = new SelectList(db.ColorMutations, "ColourId", "Name");
            ViewBag.FatherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name");
            ViewBag.MotherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChinchillaId,Name,Sex,Birthday,DeathDate,Description,ColourId,MotherId,FatherId")] Chinchilla chinchilla)
        {
            if (ModelState.IsValid)
            {
                db.Chinchillas.Add(chinchilla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColourId = new SelectList(db.ColorMutations, "ColourId", "Name", chinchilla.ColourId);
            ViewBag.FatherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name", chinchilla.FatherId);
            ViewBag.MotherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name", chinchilla.MotherId);
            return View(chinchilla);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chinchilla chinchilla = db.Chinchillas.Find(id);
            if (chinchilla == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColourId = new SelectList(db.ColorMutations, "ColourId", "Name", chinchilla.ColourId);
            ViewBag.FatherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name", chinchilla.FatherId);
            ViewBag.MotherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name", chinchilla.MotherId);
            return View(chinchilla);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChinchillaId,Name,Sex,Birthday,DeathDate,Description,ColourId,MotherId,FatherId")] Chinchilla chinchilla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chinchilla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColourId = new SelectList(db.ColorMutations, "ColourId", "Name", chinchilla.ColourId);
            ViewBag.FatherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name", chinchilla.FatherId);
            ViewBag.MotherId = new SelectList(db.Chinchillas, "ChinchillaId", "Name", chinchilla.MotherId);
            return View(chinchilla);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chinchilla chinchilla = db.Chinchillas.Find(id);
            if (chinchilla == null)
            {
                return HttpNotFound();
            }
            return View(chinchilla);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chinchilla chinchilla = db.Chinchillas.Find(id);
            db.Chinchillas.Remove(chinchilla);
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
