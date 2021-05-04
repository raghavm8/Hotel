using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class Reservation
    {
        public int Reservation_Id { get; set; }
        public int Guest_Id { get; set; }
        public int Room_Id { get; set; }
        public System.DateTime Reservation_Date { get; set; }
        public Nullable<int> Members { get; set; }
        public System.DateTime Check_In_Date { get; set; }
        public System.DateTime Check_Out_Date { get; set; }
    }
}