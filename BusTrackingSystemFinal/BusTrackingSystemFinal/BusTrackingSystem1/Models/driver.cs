//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusTrackingSystem1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class driver
    {
        public driver()
        {
            this.bus_trip = new HashSet<bus_trip>();
            this.drives = new HashSet<drive>();
        }
    
        public int driver_id { get; set; }
        public string driver_name { get; set; }
        public string phone_number { get; set; }
        public string driver_address { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
    
        public virtual ICollection<bus_trip> bus_trip { get; set; }
        public virtual ICollection<drive> drives { get; set; }
    }
}