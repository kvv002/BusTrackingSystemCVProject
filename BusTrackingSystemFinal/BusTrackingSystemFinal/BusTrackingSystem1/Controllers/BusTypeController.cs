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
    public class BusTypeController : Controller
    {
        private BusTrackingEntities db = new BusTrackingEntities();

        // GET: /BusType/
        public ActionResult Index()
        {
            return View(db.bus_type.ToList());
        }

        // GET: /BusType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus_type bus_type = db.bus_type.Find(id);
            if (bus_type == null)
            {
                return HttpNotFound();
            }
            return View(bus_type);
        }

        // GET: /BusType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BusType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="bus_type_id,bus_type_name")] bus_type bus_type)
        {
            if (ModelState.IsValid)
            {
                db.bus_type.Add(bus_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bus_type);
        }

        // GET: /BusType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus_type bus_type = db.bus_type.Find(id);
            if (bus_type == null)
            {
                return HttpNotFound();
            }
            return View(bus_type);
        }

        // POST: /BusType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="bus_type_id,bus_type_name")] bus_type bus_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bus_type);
        }

        // GET: /BusType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus_type bus_type = db.bus_type.Find(id);
            if (bus_type == null)
            {
                return HttpNotFound();
            }
            return View(bus_type);
        }

        // POST: /BusType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bus_type bus_type = db.bus_type.Find(id);
            db.bus_type.Remove(bus_type);
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
