using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataSpace.Models;

namespace DataSpace.Controllers
{
    public class PlanetsController : Controller
    {
        private PlanetDBContext db = new PlanetDBContext();

        public ActionResult Introduction()
        {
            return View();
        }

        public ActionResult SolarSystem()
        {
            var planets = from m in db.Planets
                          select m;

            return View(planets);
        }

        // GET: Planets
        public ActionResult Index(string searchType, string searchString)
        {
            var TypeList = new List<string>();

            var TypeQry = from d in db.Planets
                           orderby d.PlanetType
                           select d.PlanetType;

            TypeList.AddRange(TypeQry.Distinct());
            ViewBag.searchType = new SelectList(TypeList);

            var planets = from m in db.Planets
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                planets = planets.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchType))
            {
                planets = planets.Where(x => x.PlanetType == searchType);
            }

            return View(planets);
        }

        // GET: Planets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return HttpNotFound();
            }
            return View(planet);
        }

        // GET: Planets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Picture,Name,PlanetType,DistanceFromSun,Diameter,DayLength,YearLength")] Planet planet)
        {
            if (ModelState.IsValid)
            {
                db.Planets.Add(planet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planet);
        }

        // GET: Planets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return HttpNotFound();
            }
            return View(planet);
        }

        // POST: Planets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Picture,Name,PlanetType,DistanceFromSun,Diameter,DayLength,YearLength")] Planet planet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planet);
        }

        // GET: Planets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return HttpNotFound();
            }
            return View(planet);
        }

        // POST: Planets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planet planet = db.Planets.Find(id);
            db.Planets.Remove(planet);
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
