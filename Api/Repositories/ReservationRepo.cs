using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Repositories
{
    public class ReservationRepo
    {
        private HotelDBEntities entity = new HotelDBEntities();

        public List<Reservation> GetAllReservations()
        {
            return entity.Reservations.ToList();
        }

        public Reservation GetDetails(int ReservationId)
        {
            Reservation reservation = entity.Reservations.Find(ReservationId);
            return reservation;
        }


        public void CreateReservation(Reservation reservation)
        {
            entity.Reservations.Add(reservation);
            entity.SaveChanges();
        }

        public void DeleteReservation(int ReservationId)
        {
            Reservation reservation = entity.Reservations.Find(ReservationId);
            entity.Reservations.Remove(reservation);
            entity.SaveChanges();
        }

        public void UpdateReservation(Reservation reservation)
        {
            entity.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
            entity.SaveChanges();
        }

        public List<Reservation> GetReservationsForGuest(int guestId)
        {
            return entity.Reservations.ToList().FindAll(i => i.Guest_Id == guestId);
        }
    }
}