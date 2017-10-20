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
    public class RouteTripController : Controller
    {
        private BusTrackingEntities db = new BusTrackingEntities();

        // GET: /RouteTrip/
        public ActionResult Index()
        {
            var route_trip = db.route_trip.Include(r => r.route);
            return View(route_trip.ToList());
        }

        public ActionResult BUSTRIPINDEX()
        {
            var bt = from r in db.bus_trip select r;
            return View(bt.ToList());
        }
        // GET: /RouteTrip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            route_trip route_trip = db.route_trip.Find(id);
            if (route_trip == null)
            {
                return HttpNotFound();
            }
            return View(route_trip);
        }

        // GET: /RouteTrip/Create
        public ActionResult Create()
        {
           // ViewBag.route_id = new SelectList(db.routes, "route_id", "source");

            ViewBag.route_id = from r in db.routes.ToList()
                               select new
                               {
                                   id = r.route_id,
                                   about_route = r.source + " - " + r.destination
                               };

            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id");
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name");
            return View();
        }

        // POST: /RouteTrip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "route_trip_id,route_id,number_of_trips,arrival_time,departure_time")] route_trip route_trip, [Bind(Include = "bus_id")]bus busid, [Bind(Include = "driver_id")]driver driverid)
        {
          //  if (ModelState.IsValid)
           // {
                db.route_trip.Add(route_trip);
                db.SaveChanges();

                bus_trip trip = new bus_trip();
               // ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name", trip.driver_id);
               // ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id", trip.driver_id);
                trip.bus_id=busid.bus_id;
                trip.bus_trip_date = DateTime.Now;
                trip.start_time = route_trip.arrival_time;
                trip.end_time = route_trip.departure_time;
                trip.driver_id=driverid.driver_id;
                trip.route_trip_id = route_trip.route_trip_id;
                db.bus_trip.Add(trip);
                db.SaveChanges();

               
           // }

          //  ViewBag.route_id = new SelectList(db.routes, "route_id", "source", route_trip.route_id);

                ViewBag.route_id = from r in db.routes.ToList()
                                   select new
                                   {
                                       id = r.route_id,
                                       about_route = r.source + " - " + r.destination
                                   };

            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_id");
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "driver_name");

            return RedirectToAction("Index");
           // return View(route_trip);
        }

        // GET: /RouteTrip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            route_trip route_trip = db.route_trip.Find(id);
            if (route_trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.route_id = new SelectList(db.routes, "route_id", "source", route_trip.route_id);
            return View(route_trip);
        }

        // POST: /RouteTrip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="route_trip_id,route_id,number_of_trips,arrival_time,departure_time")] route_trip route_trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route_trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.route_id = new SelectList(db.routes, "route_id", "source", route_trip.route_id);
            return View(route_trip);
        }

        // GET: /RouteTrip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            route_trip route_trip = db.route_trip.Find(id);
            if (route_trip == null)
            {
                return HttpNotFound();
            }
            return View(route_trip);
        }

        // POST: /RouteTrip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            route_trip route_trip = db.route_trip.Find(id);
            db.route_trip.Remove(route_trip);
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
