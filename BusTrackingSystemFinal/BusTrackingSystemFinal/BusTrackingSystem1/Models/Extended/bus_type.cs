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
     [MetadataType(typeof(busTypeModel))]
    public partial class bus_type
    {
    }

    public class busTypeModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Please enter BUS TYPE ID.")]
        public int bus_type_id { get; set; }

        [Required(ErrorMessage = "Please enter bus type.")]
        [Display(Name = "Bus Type")]
        [StringLength(10)]
        public string bus_type_name { get; set; }
    }
}