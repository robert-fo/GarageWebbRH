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
        public ActionResult Index(string searchRegNr, string SearchAgare, string FordonsTyp, bool? bTodaysDate)
        {
            //return View(db.Fordon.ToList());

            Boolean Searched = false;
            ViewBag.bTodaysDate = false;

            FordonsHandler fHand = new FordonsHandler();

            ViewBag.FordonsTyp = fHand.GetSelectListItems();

            List<Fordon> fordonList = new List<Fordon>();

            var fordon = from f in db.Fordon
                         select f;

            var groupedFordon = from f in db.Fordon
                                group f by f.fTyp into g
                                orderby g.FirstOrDefault().pDatum
                                select g;

            if (!String.IsNullOrEmpty(searchRegNr))
            {
                //fordon = fordon.Where(f => f.regNr.Contains(searchRegNr));
                Searched = true;
                foreach (var group in groupedFordon.ToList())
                {
                    foreach (var item in group)
                    {
                        if (item.regNr == searchRegNr)
                        {
                            fordonList.Add(item);
                        }
                    }
                }

            }

            if (!String.IsNullOrEmpty(SearchAgare))
            {
                //fordon = fordon.Where(f => f.agare.Contains(SearchAgare));
                Searched = true;
                foreach (var group in groupedFordon.ToList())
                {
                    foreach (var item in group)
                    {
                        if (item.agare == SearchAgare)
                        {
                            fordonList.Add(item);
                        }
                    }
                }
            }

            if (!String.IsNullOrEmpty(FordonsTyp))
            {
                //fordon = fordon.Where(f => f.agare.Contains(SearchAgare));
                
                if (FordonsTyp != "Alla")
                {
                    fordonsTyp fTyp = fordonsTyp.Bil;
                    Searched = true;

                    switch (FordonsTyp){
                        case "Bil":
                            fTyp = fordonsTyp.Bil;
                            break;
                        case "MC":
                            fTyp = fordonsTyp.MC;
                            break;
                        case "Buss":
                            fTyp = fordonsTyp.Buss;
                            break;
                        case "Lastbil":
                            fTyp = fordonsTyp.Lastbil;
                            break;
                    }

                    foreach (var group in groupedFordon.ToList())
                    {
                        foreach (var item in group)
                        {
                            if (item.fTyp == fTyp)
                            {
                                fordonList.Add(item);
                            }
                        }
                    }
                }
            }

            if (bTodaysDate == true)
            {
                //fordon = fordon.Where(f => f.agare.Contains(SearchAgare));
                Searched = true;
                ViewBag.bTodaysDate = true;
                DateTime tempDate;

                foreach (var group in groupedFordon.ToList())
                {
                    foreach (var item in group)
                    {
                        tempDate = (DateTime)item.pDatum;
                        if (tempDate.Date == DateTime.Now.Date)
                        {
                            fordonList.Add(item);
                        }
                    }
                }
            }

            if (Searched == true)
            {
                return View(fordonList.ToList());
            }
            else
            {
                foreach (var group in groupedFordon.ToList())
                {
                    foreach (var item in group)
                    {
                        fordonList.Add(item);
                    }
                }
                return View(fordonList.ToList());
            }

            //return View(fordon);
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
            ViewBag.Date = DateTime.Now;
            return View();
        }

        // POST: Fordons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FordonId,regNr,agare,fTyp,pDatum,pPlatsNr,startDatum,slutDatum,garageId")] Fordon fordon)
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
            return View(fordon);
        }

        // POST: Fordons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FordonId,regNr,agare,fTyp,pDatum,pPlatsNr,startDatum,slutDatum,garageId")] Fordon fordon)
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
