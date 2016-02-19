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
    public class FordonsController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: Fordons
        public ActionResult Index()
        {
            var fordon = db.Fordon.Include(f => f.agare).Include(f => f.fordontyp);
            return View(fordon.ToList());
        }

        // GET: Fordons
        public ActionResult Index2()
        {
            var fordon = db.Fordon.Include(f => f.agare).Include(f => f.fordontyp);
            return View(fordon.ToList());
        }

        // GET: Fordons/Details/5
        public ActionResult Details(int? id)
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
            FordonsHandler fHandler = new FordonsHandler();

            ViewBag.PplatsNr = fHandler.GetSelectListLedigaPlatser();
            DateTime date1 = DateTime.Now;
            ViewBag.Pdatum = date1; //.ToString("yyyy-MM-dd hh:mm");
            ViewBag.AgareID = fHandler.GetSelectListAgarNamn();
            ViewBag.FtypID = new SelectList(db.Fordonstyp, "FtypId", "Namn");
            return View();
        }

        // POST: Fordons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FordonId,RegNr,AgareID,FtypID,Pdatum,PplatsNr,StartDatum,SlutDatum")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Fordon.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgareID = new SelectList(db.Agare, "AgareId", "Fnamn", fordon.AgareID);
            ViewBag.FtypID = new SelectList(db.Fordonstyp, "FtypId", "Namn", fordon.FtypID);
            return View(fordon);
        }

        // GET: Fordons/Edit/5
        public ActionResult Edit(int? id)
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

            FordonsHandler fHandler = new FordonsHandler();

            ViewBag.PplatsNr = fHandler.GetSelectListLedigaPlatser(fordon.PplatsNr);
            ViewBag.AgareID = fHandler.GetSelectListAgarNamn(fordon.AgareID);
            ViewBag.FtypID = new SelectList(db.Fordonstyp, "FtypId", "Namn", fordon.FtypID);
            return View(fordon);
        }

        // POST: Fordons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FordonId,RegNr,AgareID,FtypID,Pdatum,PplatsNr,StartDatum,SlutDatum")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgareID = new SelectList(db.Agare, "AgareId", "Fnamn", fordon.AgareID);
            ViewBag.FtypID = new SelectList(db.Fordonstyp, "FtypId", "Namn", fordon.FtypID);
            return View(fordon);
        }

        // GET: Fordons/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
