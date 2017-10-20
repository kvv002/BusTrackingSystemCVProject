using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusTrackingSystem1.Models;

namespace BusTrackingSystem1.Controllers
{
    public class AdminLoginController : Controller
    {
        //
        // GET: /AdminLogin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin adminLogin)
        {
            if (ModelState.IsValid)
            {
                BusTrackingEntities db = new BusTrackingEntities();
                var user = (from userlist in db.admins
                            where userlist.admin_name == adminLogin.admin_name && userlist.admin_password == adminLogin.admin_password
                            select new
                            {
                                userlist.admin_id,
                                userlist.admin_name
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().admin_name;
                    Session["adminId"] = user.FirstOrDefault().admin_id;
                   // return RedirectToAction("LoggedIn");
                    return RedirectToAction("../AdminSearch/AdminSearch");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["adminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult CompanyDetails()
        {
           
            return RedirectToAction("../Company/Index");
        }


        public ActionResult bus_typeDetails()
        {

            return RedirectToAction("../busType/Index");
        }

        public ActionResult busDetails()
        {

            return RedirectToAction("../Bus/Index");
        }

        public ActionResult Locations()
        {

            return RedirectToAction("../Location/Index");
        }


        public ActionResult Route()
        {

            return RedirectToAction("../Route/Index");
        }


        public ActionResult PassesThrough()
        {

            return RedirectToAction("../PassesThrough/Index");
        }

        public ActionResult RouteTrip()
        {

            return RedirectToAction("../RouteTrip/Index");
        }

        public ActionResult Driver()
        {

            return RedirectToAction("../Driver/Index");
        }

        public ActionResult Drives()
        {

            return RedirectToAction("../Drives/Index");
        }
    }
}