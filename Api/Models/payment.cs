//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment
    {
        public int Payment_Id { get; set; }
        public int Guest_Id { get; set; }
        public int Reservation_Id { get; set; }
        public string Name { get; set; }
    
        public virtual Guest Guest { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
