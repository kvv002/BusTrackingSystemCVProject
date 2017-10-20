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
    public class PassesThroughController : Controller
    {
        private BusTrackingEntities db = new BusTrackingEntities();

        // GET: /PassesThrough/
        public ActionResult Index()
        {
            var passes_through = db.passes_through.Include(p => p.location).Include(p => p.route);
            return View(passes_through.ToList());
        }

        // GET: /PassesThrough/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            passes_through passes_through = db.passes_through.Find(id);
            if (passes_through == null)
            {
                return HttpNotFound();
            }
            return View(passes_through);
        }

        // GET: /PassesThrough/Create
        public ActionResult Create()
        {
            ViewBag.location_id = new SelectList(db.locations, "location_id", "location_name");
           // ViewBag.route_id = new SelectList(db.routes, "route_id", "source");

            ViewBag.route_id = from r in db.routes.ToList()
                               select new
                               {
                                   id = r.route_id,
                                   about_route = r.source + " - " + r.destination
                               };
            return View();
        }

        // POST: /PassesThrough/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="passes_through_id,route_id,location_id,order_no,time_to_reach")] passes_through passes_through)
        {
            if (ModelState.IsValid)
            {
                db.passes_through.Add(passes_through);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.location_id = new SelectList(db.locations, "location_id", "location_name", passes_through.location_id);
           // ViewBag.route_id = new SelectList(db.routes, "route_id", "source", passes_through.route_id);
            ViewBag.route_id = from r in db.routes.ToList()
                               select new
                               {
                                   id = r.route_id,
                                   about_route = r.source + " - " + r.destination
                               };
            return View(passes_through);
        }

        // GET: /PassesThrough/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            passes_through passes_through = db.passes_through.Find(id);
            if (passes_through == null)
            {
                return HttpNotFound();
            }
            ViewBag.location_id = new SelectList(db.locations, "location_id", "location_name", passes_through.location_id);
            ViewBag.route_id = new SelectList(db.routes, "route_id", "source", passes_through.route_id);
            return View(passes_through);
        }

        // POST: /PassesThrough/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="passes_through_id,route_id,location_id,order_no,time_to_reach")] passes_through passes_through)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passes_through).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          /*  ViewBag.location_id = new SelectList(db.locations, "location_id", "location_name", passes_through.location_id);
            ViewBag.route_id = new SelectList(db.routes, "route_id", "source", passes_through.route_id);*/
            var sad = db.routes
.Select(s => new
{

    Description = string.Format("{0}-- £{1}", s.source, s.destination)
})
.ToList();

            ViewBag.location_id = new SelectList(db.locations, "location_id", "location_name");
            ViewBag.route_id = new SelectList(sad, "route_id", "Description");
            return View(passes_through);
        }

        // GET: /PassesThrough/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            passes_through passes_through = db.passes_through.Find(id);
            if (passes_through == null)
            {
                return HttpNotFound();
            }
            return View(passes_through);
        }

        // POST: /PassesThrough/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            passes_through passes_through = db.passes_through.Find(id);
            db.passes_through.Remove(passes_through);
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
