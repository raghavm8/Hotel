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
    public class GuestController : ApiController
    {
        private GuestRepo repo = new GuestRepo();

        // only for admin
        [HttpGet]
        [Route("Guest/GetAllGuests")]
        public IHttpActionResult GetReturnAll()
        {
            try
            {
                return Ok(repo.GetAllGuests());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // owner, guest himself
        [HttpGet]
        [Route("Guest/GuestDetails/{id}")]
        public IHttpActionResult DetailOfParticularGuest(int id)
        {
            Guest c = repo.GetDetails(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }

        // no authentication
        [HttpPost]
        [Route("Guest/AddNewGuest")]
        public IHttpActionResult AddNewGuest(Guest value)
        {
            if (ModelState.IsValid)
            {
                repo.CreateGuest(value);
                return Ok("Data Entered Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        // guest himself
        [HttpPut]
        [Route("Guest/Editdetails")]
        public IHttpActionResult ModifyExistingGuest(Guest c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateGuest(c);
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

        // owner, guest himself
        [HttpDelete]
        [Route("Guest/DeleteGuest/{id}")]
        public IHttpActionResult RemoveGuest(int id)
        {
            try
            {
                repo.DeleteGuest(id);
                return Ok("Guest Deleted Successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}