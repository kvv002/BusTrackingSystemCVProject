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
    public class searchModel
    {
        public int bus_id { get; set; }

        public Nullable<int> route_trip_id { get; set; }
        public string location_name { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public Nullable<short> number_of_trips { get; set; }
        public Nullable<System.TimeSpan> arrival_time { get; set; }
        public Nullable<System.TimeSpan> departure_time { get; set; }


    }
}