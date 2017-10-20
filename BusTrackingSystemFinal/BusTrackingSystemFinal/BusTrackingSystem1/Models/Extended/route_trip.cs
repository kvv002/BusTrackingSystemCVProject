using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusTrackingSystem1.Models
{
    [MetadataType(typeof(routeTripModel))]
    public partial class route_trip
    {

    }
   

    public class routeTripModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int route_trip_id { get; set; }

        [ForeignKey("route_id")]
        [Required(ErrorMessage = "Please select route.")]
        [Display(Name = "Route ")]
        public int  route_id { get; set; }


        [Required(ErrorMessage = "Please enter number of trips ")]
        [Display(Name = "Number of Trips")]
        public int  number_of_trips { get; set; }

        [Required(ErrorMessage = "Please enter Arrival Time.")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        public  DateTime arrival_time { get; set; }

        [Required(ErrorMessage = "Please enter Departure Time.")]
        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        public DateTime departure_time { get; set; }


    }
}