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
    [MetadataType(typeof(driveModel))]
    public partial class drive
    {
    }
      public class driveModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int drives_id { get; set; }


        [ForeignKey("driver_id")]
        [Required(ErrorMessage = "Please select Driver.")]
        [Display(Name = "Driver")]
         public int driver_id { get; set; }

        [ForeignKey("bus_id")]
        [Required(ErrorMessage = "Please select Bus.")]
        [Display(Name = "Bus")]
         public int bus_id { get; set; }

    }
}