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
    public class ComplaintController : Controller
    {
        private BusTrackingEntities db = new BusTrackingEntities();

        // GET: /Complaint/
        public ActionResult Index()
        {
            return View(db.complaints.ToList());
        }

        // GET: /Complaint/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complaint complaint = db.complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: /Complaint/Create
        public ActionResult Create()
        {
            ViewBag.route_id = from r in db.routes.ToList()
                               select new
                               {
                                   id = r.route_id,
                                   about_route = r.source + " - " + r.destination
                               };
            return View();
        }

        // POST: /Complaint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "complaint_id,complaint1,route_id")] complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.route_id = from r in db.routes.ToList()
                               select new
                               {
                                   id = r.route_id,
                                   about_route = r.source + " - " + r.destination
                               };

            return View(complaint);
        }

        // GET: /Complaint/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complaint complaint = db.complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: /Complaint/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "complaint_id,complaint1,route_id")] complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaint);
        }

        // GET: /Complaint/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complaint complaint = db.complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: /Complaint/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            complaint complaint = db.complaints.Find(id);
            db.complaints.Remove(complaint);
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
