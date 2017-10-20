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
    public class DrivesController : Controller
    {
        private BusTrackingEntities db = new BusTrackingEntities();

        // GET: /Drives/
        public ActionResult Index()
        {
            var drives = db.drives.Include(d => d.bus).Include(d => d.driver);
            return View(drives.ToList());
        }

        // GET: /Drives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drive drive = db.drives.Find(id);
            if (drive == null)
            {
                return HttpNotFound();
            }
            return View(drive);
        }

        // GET: /Drives/Create
        public ActionResult Create()
        {
            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id");
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name");
            return View();
        }

        // POST: /Drives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="drives_id,driver_id,bus_id")] drive drive)
        {
            if (ModelState.IsValid)
            {
                db.drives.Add(drive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id", drive.bus_id);
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name", drive.driver_id);
            return View(drive);
        }

        // GET: /Drives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drive drive = db.drives.Find(id);
            if (drive == null)
            {
                return HttpNotFound();
            }
            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id", drive.bus_id);
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name", drive.driver_id);
            return View(drive);
        }

        // POST: /Drives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="drives_id,driver_id,bus_id")] drive drive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id", drive.bus_id);
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name", drive.driver_id);
            return View(drive);
        }

        // GET: /Drives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drive drive = db.drives.Find(id);
            if (drive == null)
            {
                return HttpNotFound();
            }
            return View(drive);
        }

        // POST: /Drives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            drive drive = db.drives.Find(id);
            db.drives.Remove(drive);
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
