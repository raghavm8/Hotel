using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Models
{
    public class Room
    {
        public int Room_Id { get; set; }
        public Nullable<int> Status_Id { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }

        [DisplayName("Type of Room")]
        public List<String> type { get; set; }
        
        public Room()
        {
            List<String> type1 = new List<String>();
            type1.Add("Simple");
            type1.Add("King");
            type1.Add("Queen");
            type1.Add("Twin");
            type1.Add("Villa");
            type1.Add("Suite");

            type = type1;
        }
    }
}