using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Repositories
{
    public class StatusRepo
    {
        private HotelDBEntities entity = new HotelDBEntities();

        public List<Status> GetAllStatuss()
        {
            return entity.Status.ToList();
        }

        public Status GetDetails(int StatusId)
        {
            Status Status = entity.Status.Find(StatusId);
            return Status;
        }

        public void CreateStatus(Status St)
        {
            entity.Status.Add(St);
            entity.SaveChanges();
        }

        public void DeleteStatus(int StatusId)
        {
            Status St = entity.Status.Find(StatusId);
            entity.Status.Remove(St);
            entity.SaveChanges();
        }

        public void UpdateStatus(Status St)
        {
            entity.Entry(St).State = System.Data.Entity.EntityState.Modified;
            entity.SaveChanges();
        }
    }
}