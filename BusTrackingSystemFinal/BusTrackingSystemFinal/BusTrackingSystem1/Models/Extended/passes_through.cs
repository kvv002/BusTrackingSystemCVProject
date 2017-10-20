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
    [MetadataType(typeof(passesThroughModel))]
    public partial class passes_through
    {
    }

    public class passesThroughModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int passes_through_id { get; set; }

        [ForeignKey("route_id")]
        [Required(ErrorMessage = "Please select route.")]
        [Display(Name = "route")]

        public int route_id { get; set; }


        [ForeignKey("location_id")]
        [Required(ErrorMessage = "Please select location")]
        [Display(Name = "location")]
        public int location_id { get; set; }

        [Required(ErrorMessage = "Please enter location sequence number.")]
        [Display(Name = "Location sequence number")]
        public short order_no { get; set; }


        [Required(ErrorMessage = "Please enter Time to reach.")]
        [Display(Name = "time to reach")]
        [DataType(DataType.Time)]
        public DateTime time_to_reach { get; set; }

    }
}