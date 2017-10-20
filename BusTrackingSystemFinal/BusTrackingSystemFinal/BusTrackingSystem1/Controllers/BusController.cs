using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusTrackingSystem1.Models;

namespace BusTrackingSystem1.Controllers
{
    public class BusController : Controller
    {
        private BusTrackingEntities db = new BusTrackingEntities();

        // GET: /Bus/
        public ActionResult Index()
        {
            var buses = db.buses.Include(b => b.bus_type).Include(b => b.company);
            return View(buses.ToList());
        }

        // GET: /Bus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: /Bus/Create
        public ActionResult Create()
        {
            ViewBag.bus_type_id = new SelectList(db.bus_type, "bus_type_id", "bus_type_name");
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company_name");
            return View();
        }

        // POST: /Bus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="bus_id,bus_type_id,company_id")] bus bus)
        {
            if (ModelState.IsValid)
            {
                db.buses.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bus_type_id = new SelectList(db.bus_type, "bus_type_id", "bus_type_name", bus.bus_type_id);
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company_name", bus.company_id);
            return View(bus);
        }

        // GET: /Bus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.bus_type_id = new SelectList(db.bus_type, "bus_type_id", "bus_type_name", bus.bus_type_id);
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company_name", bus.company_id);
            return View(bus);
        }

        // POST: /Bus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="bus_id,bus_type_id,company_id")] bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bus_type_id = new SelectList(db.bus_type, "bus_type_id", "bus_type_name", bus.bus_type_id);
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company_name", bus.company_id);
            return View(bus);
        }

        // GET: /Bus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: /Bus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bus bus = db.buses.Find(id);
            db.buses.Remove(bus);
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
