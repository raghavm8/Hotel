using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Repositories
{
    public class paymentRepo
    {
        private HotelDBEntities entity = new HotelDBEntities();

        public List<payment> GetAllpayments()
        {
            return entity.payments.ToList();
        }

        public payment GetDetails(int paymentId)
        {
            payment payment = entity.payments.Find(paymentId);
            return payment;
        }

        public void Createpayment(payment pay)
        {
            entity.payments.Add(pay);
            entity.SaveChanges();
        }

        public void Deletepayment(int paymentId)
        {
            payment pay = entity.payments.Find(paymentId);
            entity.payments.Remove(pay);
            entity.SaveChanges();
        }

        public void Updatepayment(payment pay)
        {
            entity.Entry(pay).State = System.Data.Entity.EntityState.Modified;
            entity.SaveChanges();
        }
    }
}