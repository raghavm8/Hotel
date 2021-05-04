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

        [DisplayName("Type of Room")]
        public List<SelectListItem> type { get; set; }
        
        public Room()
        {
            List<SelectListItem> type1 = new List<SelectListItem>();
            type1.Add(new SelectListItem { Text = "Simple", Value = "1"  });
            type1.Add(new SelectListItem { Text = "King", Value = "2" });
            type1.Add(new SelectListItem { Text = "Queen", Value = "3" });
            type1.Add(new SelectListItem { Text = "Twin", Value = "4" });
            type1.Add(new SelectListItem { Text = "Villa", Value = "5" });
            type1.Add(new SelectListItem { Text = "Suite", Value = "6" });

            type = type1;
        }
    }
}