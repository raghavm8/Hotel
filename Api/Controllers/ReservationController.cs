using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using Api.Repositories;

namespace Api.Controllers
{
    public class ReservationController : ApiController
    {
        private ReservationRepo repo = new ReservationRepo();
 
        [HttpGet]
        [Route("Reservation/GetAllReservations")]
        public IHttpActionResult GetReturnAll()
        {
            try
            {
                return Ok(repo.GetAllReservations());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Reservation/ReservationDetails/{id}")]
        public IHttpActionResult DetailOfParticularReservation(int id)
        {
            Reservation c = repo.GetDetails(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }

        [HttpPost]
        [Route("Reservation/AddNewReservation")]
        public IHttpActionResult AddNewReservation(Reservation value)
        {
            if (ModelState.IsValid)
            {
                repo.CreateReservation(value);
                return Ok("Data Entered Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("Reservation/Editdetails")]
        public IHttpActionResult ModifyExistingReservation(Reservation c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateReservation(c);
                    return Ok("data entered successfully");
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("Reservation/DeleteReservation/{id}")]
        public IHttpActionResult RemoveReservation(int id)
        {
            try
            {
                repo.DeleteReservation(id);
                return Ok("Reservation Deleted Successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // get all reservations for a guest
        [HttpGet]
        [Route("Reservation/GetReservationsForGuest/{id}")]
        public IHttpActionResult GetReservationsOfGuest(int id)
        {
            try
            {
                return Ok(repo.GetReservationsForGuest(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    
        [HttpGet]
        [Route("Reservation/Reservation/{id}")]
        public IHttpActionResult GetAvailability(int id)
        {
            try
            {
                return Ok(repo.GetRoomAvailability(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}