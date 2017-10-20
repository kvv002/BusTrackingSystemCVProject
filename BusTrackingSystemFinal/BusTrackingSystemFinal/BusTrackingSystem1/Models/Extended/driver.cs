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
    [MetadataType(typeof(driverModel))]
    public partial class driver
    {
    }

    public class driverModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int driver_id { get; set; }
        
        

        [Required(ErrorMessage = "Please enter Driver name.")]
        [Display(Name = "Driver name")]
        [StringLength(20)]
        public string driver_name { get; set; }


        [Required(ErrorMessage = "Please enter phone number.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [StringLength(12)]
        public string phone_number { get; set; }

         [Required(ErrorMessage = "Please enter address.")]
        [Display(Name = "Address")]
        [StringLength(50)]
        public string driver_address { get; set; }

        [Required(ErrorMessage = "Please enter Birthdate")]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime date_of_birth{ get; set; }


        [Required(ErrorMessage = "Please select")]
        [Display(Name = "Gender")]
        public string gender { get; set; }

    }
}