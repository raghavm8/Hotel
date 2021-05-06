using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Repositories
{
    public class RoomRepo
    {
        private HotelDBEntities entity = new HotelDBEntities();

        public List<Room> GetAllRooms()
        {
            return entity.Rooms.ToList();
        }

        public Room GetDetails(int roomId)
        {
            Room room = entity.Rooms.Find(roomId);
            return room;
        }

        public void CreateRoom(Room room)
        {
            entity.Rooms.Add(room);
            entity.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            Room room = entity.Rooms.Find(roomId);
            entity.Rooms.Remove(room);
            entity.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            entity.Entry(room).State = System.Data.Entity.EntityState.Modified;
            entity.SaveChanges();
        }

        public List<Room> GetBookedRooms()
        {
            return entity.Rooms.ToList().FindAll(i => i.Status_Id == 5);
        }

        public List<Room> GetVacantRooms()
        {
            return entity.Rooms.ToList().FindAll(i => i.Status_Id == 1);
        }

        public List<Room> GetOccupiedRooms()
        {
            return entity.Rooms.ToList().FindAll(i => i.Status_Id == 3);
        }

        // only for admin
        public List<Room> GetAvailableWithCount()
        {
            return this.GetVacantRooms();
        }
    }
}