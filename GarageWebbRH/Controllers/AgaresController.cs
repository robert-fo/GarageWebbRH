using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageWebbRH.DataAccessLayer;
using GarageWebbRH.Models;
using GarageWebbRH.Repository;

namespace GarageWebbRH.Controllers
{
    public class AgaresController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: Agares
        public ActionResult Index()
        {
            return View(db.Agare.ToList());
        }

        // GET: Agares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agare agare = db.Agare.Find(id);
            if (agare == null)
            {
                return HttpNotFound();
            }
            return View(agare);
        }

        // GET: Agares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgareId,Fnamn,Enamn,TelefonNr")] Agare agare)
        {
            if (ModelState.IsValid)
            {
                db.Agare.Add(agare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agare);
        }

        // GET: Agares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agare agare = db.Agare.Find(id);
            if (agare == null)
            {
                return HttpNotFound();
            }
            return View(agare);
        }

        // POST: Agares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgareId,Fnamn,Enamn,TelefonNr")] Agare agare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agare);
        }

        // GET: Agares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agare agare = db.Agare.Find(id);
            if (agare == null)
            {
                return HttpNotFound();
            }
            return View(agare);
        }

        // POST: Agares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agare agare = db.Agare.Find(id);
            db.Agare.Remove(agare);
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
