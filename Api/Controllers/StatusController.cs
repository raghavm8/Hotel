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
    public class StatusController : ApiController
    {
        private StatusRepo repo = new StatusRepo();

        [HttpGet]
        [Route("Status/GetAllStatus")]
        public IHttpActionResult GetReturnAll()
        {
            try
            {
                return Ok(repo.GetAllStatuss());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Status/StatusDetails/{id}")]
        public IHttpActionResult DetailOfParticularStatus(int id)
        {
            Status c = repo.GetDetails(id);
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
        [Route("Status/AddNewStatus")]
        public IHttpActionResult AddNewStatus(Status value)
        {
            if (ModelState.IsValid)
            {
                repo.CreateStatus(value);
                return Ok("Data Entered Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("Status/Editdetails")]
        public IHttpActionResult ModifyExistingStatus(Status c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateStatus(c);
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
        [Route("Status/DeleteStatus/{id}")]
        public IHttpActionResult RemoveStatus(int id)
        {
            try
            {
                repo.DeleteStatus(id);
                return Ok("Status Deleted Successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}