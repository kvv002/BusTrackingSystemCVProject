using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusTrackingSystem1.Models;


namespace BusTrackingSystem1.viewModel
{
    public class routeViewModel
    {
        public int bus_id { get; set; }
        public int route_trip_id { get; set; }

        public int route_id { get; set; }

        public Nullable<System.TimeSpan> time_to_reach { get; set; }
        public string location_name { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public int location_id { get; set; }
        public Nullable<double> latitude { get; set; }
        public Nullable<double> longitude { get; set; }
        public Nullable<short> location_sequence { get; set; }


    }
}