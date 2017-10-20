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
    [MetadataType(typeof(routeModel))]
    public partial class route
    {
    }

    public class routeModel
    {
         [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int route_id { get; set; }

       [Required(ErrorMessage = "Please enter Source name.")]
       [Display(Name = "Source name")]
       [StringLength(15)]
       public string source { get; set; }


       [Required(ErrorMessage = "Please enter Destination.")]
       [Display(Name = "Destination name")]
       [StringLength(15)]
      public string destination { get; set; }

   
    }
}