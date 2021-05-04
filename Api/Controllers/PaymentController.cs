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
    public class PaymentController : ApiController
    {
        private paymentRepo repo = new paymentRepo();

        // admin
        [HttpGet]
        [Route("payment/GetAllpayments")]
        public IHttpActionResult GetReturnAll()
        {
            try
            {
                return Ok(repo.GetAllpayments());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // admin
        [HttpGet]
        [Route("payment/paymentDetails/{id}")]
        public IHttpActionResult DetailOfParticularpayment(int id)
        {
            payment c = repo.GetDetails(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }

        // admin
        [HttpPost]
        [Route("payment/AddNewpayment")]
        public IHttpActionResult AddNewpayment(payment value)
        {
            if (ModelState.IsValid)
            {
                repo.Createpayment(value);
                return Ok("Data Entered Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        //admin
        [HttpPut]
        [Route("payment/Editdetails")]
        public IHttpActionResult ModifyExistingpayment(payment c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.Updatepayment(c);
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

        //admin
        [HttpDelete]
        [Route("payment/Deletepayment/{id}")]
        public IHttpActionResult Removepayment(int id)
        {
            try
            {
                repo.Deletepayment(id);
                return Ok("payment Deleted Successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}