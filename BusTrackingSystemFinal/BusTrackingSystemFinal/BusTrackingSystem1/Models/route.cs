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
    
    public partial class route
    {
        public route()
        {
            this.passes_through = new HashSet<passes_through>();
            this.route_trip = new HashSet<route_trip>();
        }
    
        public int route_id { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
    
        public virtual ICollection<passes_through> passes_through { get; set; }
        public virtual ICollection<route_trip> route_trip { get; set; }
    }
}
