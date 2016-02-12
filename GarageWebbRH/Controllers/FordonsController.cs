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

namespace GarageWebbRH.Controllers
{
    public class FordonsController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: Fordons
        public ActionResult Index()
        {
            return View(db.Fordon.ToList());
        }

        // GET: Fordons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordon.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // GET: Fordons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fordons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "regNr,agare,fTyp,pDatum,pPlatsNr,startDatum,slutDatum,garageId")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Fordon.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fordon);
        }

        // GET: Fordons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordon.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "regNr,agare,fTyp,pDatum,pPlatsNr,startDatum,slutDatum,garageId")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fordon);
        }

        // GET: Fordons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordon.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Fordon fordon = db.Fordon.Find(id);
            db.Fordon.Remove(fordon);
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
