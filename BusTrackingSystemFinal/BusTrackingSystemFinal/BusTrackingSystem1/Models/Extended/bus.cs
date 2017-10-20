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
    [MetadataType(typeof(busModel))]
    public partial class bus
    {
    }

    public class busModel

    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int bus_id { get; set; }

  
        [ForeignKey("bus_type_id")]
        [Required(ErrorMessage = "Please enter bus.")]
        [Display(Name = "Bus Type")]
        public int  bus_type_id { get; set; }

        [ForeignKey("company_id")]
        [Required(ErrorMessage = "Please enter company.")]
        [Display(Name = "company")]
 
        public int company_id { get; set; }
    }
}