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
   
    public partial class admin
    {
    }

    public class adminLogin
    {

        [Required(ErrorMessage = "Please enter admin name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Admin name")]
        [StringLength(20)]

        public string admin_name { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(15)]

        public string admin_password { get; set; }
    }
}