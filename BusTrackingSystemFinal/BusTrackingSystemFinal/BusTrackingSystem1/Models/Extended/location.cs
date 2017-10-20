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
    [MetadataType(typeof(locationModel))]
    public partial class location
    {
    }

    public class locationModel
    {
       [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int location_id { get; set; }

       [Required(ErrorMessage = "Please enter Location name.")]
       [Display(Name = "Location name")]
       [StringLength(20)]
       public string location_name { get; set; }


       [Required(ErrorMessage = "Please enter Latitude.")]
       [Display(Name = "Latitude")]
      public double latitude { get; set; }

       [Required(ErrorMessage = "Please enter Longitude.")]
       [Display(Name = "Longitude")]
       public double longitude{ get; set; }
    }
}