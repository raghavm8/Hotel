using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using App.Models;

namespace voting.Controllers
{
    public class GuestController : Controller
    {
        string BaseAddress = "https://localhost:44371/";

        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            string cookieValue = string.Empty;
            IEnumerable<Guest> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Guest/GetAllGuests");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Guest>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Guest>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(r);
        }

        public ActionResult Details(int id)
        {
            Guest m = null;
            string cookieValue = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Guest/GuestDetails/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Guest>();
                    readTask.Wait();
                    m = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(m);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Guest m)
        {
            using (HttpClient client = new HttpClient())
            {
                string cookieValue = string.Empty;
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var postTask = client.PostAsJsonAsync<Guest>("Guest/AddNewGuest", m);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error!!!!");
            return View(m);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Guest m = null;
            string cookieValue = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var resposneTask = client.GetAsync("Guest/GuestDetails/" + id);
                resposneTask.Wait();

                var result = resposneTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Guest>();
                    readTask.Wait();

                    m = readTask.Result;
                }
            }
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Guest_Id, Name, Email, Phone, City, Aadhar_Number")] Guest m)
        {
            using (HttpClient client = new HttpClient())
            {
                string cookieValue = string.Empty;
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                ////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var putTask = client.PutAsJsonAsync<Guest>("Guest/Editdetails", m);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(m);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Guest m = null;
            using (HttpClient client = new HttpClient())
            {
                string cookieValue = string.Empty;
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var resposneTask = client.GetAsync("Guest/GuestDetails/" + id);
                resposneTask.Wait();

                var result = resposneTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Guest>();
                    readTask.Wait();

                    m = readTask.Result;
                }
            }
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteGuest(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string cookieValue = string.Empty;
                client.BaseAddress = new Uri(BaseAddress);
                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);
                var deleteTask = client.DeleteAsync("Guest/DeleteGuest/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetReservationsForGuest(int id)
        {
            string cookieValue = string.Empty;
            IEnumerable<Reservation> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Reservation/GetReservationsForGuest/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Reservation>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Reservation>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(r);
        }

        public ActionResult CreateReservation()
        {
            return RedirectToAction("Create","Reservation");
        }
    }
}