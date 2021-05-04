using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Repositories
{
    public class GuestRepo
    {
        private HotelDBEntities entity = new HotelDBEntities();

        public List<Guest> GetAllGuests()
        {
            return entity.Guests.ToList();
        }

        public Guest GetDetails(int GuestId)
        {
            Guest guest = entity.Guests.Find(GuestId);
            return guest;
        }

        public void CreateGuest(Guest guest)
        {
            entity.Guests.Add(guest);
            entity.SaveChanges();
        }

        public void DeleteGuest(int GuestId)
        {
            Guest guest = entity.Guests.Find(GuestId);
            entity.Guests.Remove(guest);
            entity.SaveChanges();
        }

        public void UpdateGuest(Guest guest)
        {
            entity.Entry(guest).State = System.Data.Entity.EntityState.Modified;
            entity.SaveChanges();
        }
    }
}