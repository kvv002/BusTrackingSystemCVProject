using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusTrackingSystem1.Models;
using BusTrackingSystem1.viewModel;

namespace BusTrackingSystem1.Controllers
{
    public class AdminSearchController : Controller
    {
        //
        // GET: /Search/
        private BusTrackingEntities db = new BusTrackingEntities();
        public ActionResult Index(string source, string destination)
        {

            var route = from r in db.routes
                        select r;
            if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(destination))
            {
                route = route.Where(s => s.destination.Contains(destination) && s.source.Contains(source));
            }
            return View(route);

        }

        public ActionResult AdminSearch(string source, string destination)
        {


            ViewBag.source = new SelectList(db.routes, "source", "source");
            ViewBag.destination = new SelectList(db.routes, "destination", "destination");
            ViewBag.suggestion = "";
            List<searchModel> searching = new List<searchModel>();

            if (source == destination && (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(destination)))
            {
                ViewBag.suggestion = "Source and Destination should not be same";
            }
            else
            {

                if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(destination))
                {

                    var routeInfo = (from r in db.routes
                                     where r.destination == destination && r.source == source
                                     join rt in db.route_trip on r.route_id equals rt.route_id
                                     join bt in db.bus_trip on rt.route_trip_id equals bt.route_trip_id
                                     select new { r.source, r.destination, rt.number_of_trips, bt.start_time, bt.end_time, bt.bus.bus_id, bt.route_trip_id }).ToList();


                    if (!routeInfo.Any())
                    {
                        ViewBag.suggestion = "SUGGESTIONS";
                        var sourceInfo = (from r in db.routes
                                          where r.source == source
                                          join rt in db.route_trip on r.route_id equals rt.route_id
                                          join bt in db.bus_trip on rt.route_trip_id equals bt.route_trip_id
                                          select new { r.source, r.destination, rt.number_of_trips, bt.start_time, bt.end_time, bt.bus.bus_id, bt.route_trip_id }).ToList();

                        searchModel obj = new searchModel();
                        foreach (var item in sourceInfo)
                        {
                            obj.destination = item.destination;

                        }
                        foreach (var item in sourceInfo)
                        {

                            searchModel objSearch = new searchModel(); // ViewModel
                            objSearch.bus_id = item.bus_id;
                            objSearch.source = item.source;
                            objSearch.destination = item.destination;
                            objSearch.number_of_trips = item.number_of_trips;
                            objSearch.arrival_time = item.end_time;
                            objSearch.departure_time = item.start_time;
                            objSearch.route_trip_id = item.route_trip_id;
                            searching.Add(objSearch);
                        }
                        var destinationInfo = (from r in db.routes
                                               where r.source == obj.destination && r.destination == destination
                                               join rt in db.route_trip on r.route_id equals rt.route_id
                                               join bt in db.bus_trip on rt.route_trip_id equals bt.route_trip_id
                                               select new { r.source, r.destination, rt.number_of_trips, bt.start_time, bt.end_time, bt.bus.bus_id, bt.route_trip_id }).ToList();


                        if (!destinationInfo.Any())
                        {
                            searching.Clear();

                        }
                        foreach (var item in destinationInfo)
                        {

                            searchModel objSearch = new searchModel(); // ViewModel
                            objSearch.bus_id = item.bus_id;
                            objSearch.source = item.source;
                            objSearch.destination = item.destination;
                            objSearch.number_of_trips = item.number_of_trips;
                            objSearch.arrival_time = item.end_time;
                            objSearch.departure_time = item.start_time;
                            objSearch.route_trip_id = item.route_trip_id;
                            searching.Add(objSearch);
                        }
                    }
                    else
                    {
                        foreach (var item in routeInfo)
                        {

                            searchModel objSearch = new searchModel(); // ViewModel
                            objSearch.bus_id = item.bus_id;
                            objSearch.source = item.source;
                            objSearch.destination = item.destination;
                            objSearch.number_of_trips = item.number_of_trips;
                            objSearch.arrival_time = item.end_time;
                            objSearch.departure_time = item.start_time;
                            objSearch.route_trip_id = item.route_trip_id;
                            searching.Add(objSearch);
                        }
                    }

                }

                else if (!string.IsNullOrEmpty(source))
                {
                    var routeInfo = (from r in db.routes
                                     where r.source == source
                                     join rt in db.route_trip on r.route_id equals rt.route_id
                                     join bt in db.bus_trip on rt.route_trip_id equals bt.route_trip_id
                                     select new { r.source, r.destination, rt.number_of_trips, bt.start_time, bt.end_time, bt.bus.bus_id, bt.route_trip_id }).ToList();


                    foreach (var item in routeInfo)
                    {

                        searchModel objSearch = new searchModel(); // ViewModel
                        objSearch.bus_id = item.bus_id;
                        objSearch.source = item.source;
                        objSearch.destination = item.destination;
                        objSearch.number_of_trips = item.number_of_trips;
                        objSearch.arrival_time = item.end_time;
                        objSearch.departure_time = item.start_time;
                        objSearch.route_trip_id = item.route_trip_id;
                        searching.Add(objSearch);
                    }
                }

                else if (!string.IsNullOrEmpty(destination))
                {
                    var routeInfo = (from r in db.routes
                                     where r.destination == destination
                                     join rt in db.route_trip on r.route_id equals rt.route_id
                                     join bt in db.bus_trip on rt.route_trip_id equals bt.route_trip_id
                                     select new { r.source, r.destination, rt.number_of_trips, bt.start_time, bt.end_time, bt.bus.bus_id, bt.route_trip_id }).ToList();


                    foreach (var item in routeInfo)
                    {

                        searchModel objSearch = new searchModel(); // ViewModel
                        objSearch.bus_id = item.bus_id;
                        objSearch.source = item.source;
                        objSearch.destination = item.destination;
                        objSearch.number_of_trips = item.number_of_trips;
                        objSearch.arrival_time = item.end_time;
                        objSearch.departure_time = item.start_time;
                        objSearch.route_trip_id = item.route_trip_id;
                        searching.Add(objSearch);
                    }
                }


            }







            return View(searching);

        }

        public ActionResult display_route(int bus_id, int trip_id)
        {


            List<double?> lat = new List<double?>();
            List<double?> longi = new List<double?>();
            List<string> location_name = new List<string>();
            List<routeViewModel> routeView = new List<routeViewModel>();

            var route = (from b in db.buses
                         join bt in db.bus_trip on b.bus_id equals bt.bus_id
                         join rt in db.route_trip.Where(a => a.route_trip_id == trip_id) on bt.route_trip_id equals rt.route_trip_id
                         join r in db.routes on rt.route_id equals r.route_id
                         join pt in db.passes_through on r.route_id equals pt.route_id
                         join loc in db.locations on pt.location_id equals loc.location_id
                         select new
                         {
                             b.bus_id,
                             rt.route_trip_id,
                             r.route_id,
                             loc.location_name,
                             loc.latitude,
                             loc.longitude,
                             loc.location_id,
                             r.source,
                             r.destination,
                             pt.order_no,
                             pt.time_to_reach

                         }).OrderBy(g => g.order_no).ToList();

            foreach (var item in route)
            {

                routeViewModel objRoute = new routeViewModel(); // ViewModel
                objRoute.bus_id = item.bus_id;
                objRoute.destination = item.destination;
                objRoute.location_name = item.location_name;
                objRoute.location_sequence = item.order_no;
                objRoute.route_id = item.route_id;
                objRoute.route_trip_id = item.route_trip_id;
                objRoute.source = item.source;
                objRoute.latitude = item.latitude;
                objRoute.longitude = item.longitude;
                objRoute.location_id = item.location_id;
                objRoute.time_to_reach = item.time_to_reach;

                ViewBag.bus_id = objRoute.bus_id;



                routeView.Add(objRoute);
                lat.Add(objRoute.latitude);
                longi.Add(objRoute.longitude);

                location_name.Add(objRoute.location_name);

            }

            //ViewBag.latitude = new SelectList(routeView, "latitude", "latitude");
            //ViewBag.longitude = new SelectList(routeView, "longitude", "longitude");
            ViewBag.latitude = lat;
            ViewBag.longitude = longi;
            ViewBag.location_name = location_name;
            /*  where r.destination == destination && r.source == source
              join rt in db.route_trip on r.route_id equals rt.route_id
              join bt in db.bus_trip on rt.route_trip_id equals bt.route_trip_id
              select new { r.source, r.destination, rt.number_of_trips, bt.start_time, bt.end_time, bt.bus.bus_id }).ToList();*/

            return View(routeView);
        }
        public ActionResult Maps()
        {
            return View();
        }
    }
}