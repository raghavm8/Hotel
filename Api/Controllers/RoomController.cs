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
    // owner only
    public class RoomController : ApiController
    {
        private RoomRepo repo = new RoomRepo();

        [HttpGet]
        [Route("Room/GetAllRooms")]
        public IHttpActionResult GetReturnAll()
        {
            try
            {
                return Ok(repo.GetAllRooms());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // owner
        [HttpGet]
        [Route("Room/RoomDetails/{id}")]
        public IHttpActionResult DetailOfParticularRoom(int id)
        {
            Room c = repo.GetDetails(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }

        // owner
        [HttpPost]
        [Route("Room/AddNewRoom")]
        public IHttpActionResult AddNewRoom(Room value)
        {
            if (ModelState.IsValid)
            {
                repo.CreateRoom(value);
                return Ok("Data Entered Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        // owner
        [HttpPut]
        [Route("Room/Editdetails")]
        public IHttpActionResult ModifyExistingRoom(Room c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateRoom(c);
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

        // owner
        [HttpDelete]
        [Route("Room/DeleteRoom/{id}")]
        public IHttpActionResult RemoveRoom(int id)
        {
            try
            {
                repo.DeleteRoom(id);
                return Ok("Room Deleted Successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Room/GetBookedRooms")]
        public IHttpActionResult GetBooked()
        {
            try
            {
                return Ok(repo.GetBookedRooms());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Room/GetVacantRooms")]
        public IHttpActionResult GetVacant()
        {
            try
            {
                return Ok(repo.GetVacantRooms());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Room/GetOccupiedRooms")]
        public IHttpActionResult GetOccupied()
        {
            try
            {
                return Ok(repo.GetOccupiedRooms());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}