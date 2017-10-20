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
 [MetadataType(typeof(companyModel))]
    public partial class company
    {
    }

    public class companyModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Company ID")]
        public int company_id { get; set; }

        [Required(ErrorMessage = "Please enter company name.")]
        [Display(Name = "Company Name")]
        [StringLength(20)]
        public string company_name { get; set; }


        [Required(ErrorMessage = "Please enter company address.")]
        [Display(Name = "Company Address")]
        [StringLength(50)]
        public string company_address { get; set; }

        [Required(ErrorMessage = "Please enter company phone number.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Company Phone No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [StringLength(12)]
        public string company_phone_number { get; set; }
    }
}