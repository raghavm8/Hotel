using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using App.Models;
using App.repositories;
using App.ViewModel;

namespace App.Controllers
{
    public class RoomController : Controller
    {
        string BaseAddress = "https://localhost:44371/";

        public ActionResult Index()
        {
            return RedirectToAction("GetVacant");
        }

        public ActionResult GetAll()
        {
            string cookieValue = string.Empty;
            IEnumerable<Room> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/GetAllRooms");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(r);
        }

        public ActionResult Details(int id)
        {
            Room m = null;
            string cookieValue = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/RoomDetails/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Room>();
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

        public ActionResult Create()
        {
            Room t = new Room();
            ViewBag.values = t.type;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room m)
        {
            using (HttpClient client = new HttpClient())
            {
                string cookieValue = string.Empty;
                client.BaseAddress = new Uri(BaseAddress);
                
                m.Status_Id = 1;
                m.Available = true;

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var postTask = client.PostAsJsonAsync<Room>("Room/AddNewRoom", m);
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

        public ActionResult Edit(int id)
        {
            Room m = null;
            string cookieValue = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var resposneTask = client.GetAsync("Room/RoomDetails/" + id);
                resposneTask.Wait();

                var result = resposneTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Room>();
                    readTask.Wait();

                    m = readTask.Result;
                }
            }
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Room_Id, Status_Id, RoomType, Price")] Room m)
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

                var putTask = client.PutAsJsonAsync<Room>("Room/Editdetails", m);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(m);
        }
        
        public ActionResult Delete(int id)
        {
            Room m = null;
            using (HttpClient client = new HttpClient())
            {
                string cookieValue = string.Empty;
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var resposneTask = client.GetAsync("Room/RoomDetails/" + id);
                resposneTask.Wait();

                var result = resposneTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Room>();
                    readTask.Wait();

                    m = readTask.Result;
                }
            }
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRoom(int id)
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
                var deleteTask = client.DeleteAsync("Room/DeleteRoom/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetVacant()
        {
            string cookieValue = string.Empty;
            IEnumerable<Room> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/GetVacantRooms");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(r);
        }

        public ActionResult GetBooked()
        {
            string cookieValue = string.Empty;
            IEnumerable<Room> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/GetBookedRooms");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(r);
        }

        public ActionResult GetOccupied()
        {
            string cookieValue = string.Empty;
            IEnumerable<Room> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/GetOccupiedRooms");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(r);
        }

        public ActionResult CountOfEachType()
        {
            string cookieValue = string.Empty;
            IEnumerable<Room> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/GetTypeCount");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
           
            RoomRepo rep = new RoomRepo();
            var counter = rep.GetCountOfType(r);
            ViewBag.dict = counter;
            return View();
        }

        public ActionResult CountOfAvailableType()
        {
            string cookieValue = string.Empty;
            IEnumerable<Room> r = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);

                /*if (Request.Cookies["access_token"] != null)
                {
                    cookieValue = Request.Cookies["access_token"].Value;
                }*/

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookieValue);

                var responseTask = client.GetAsync("Room/Available/GetTypeCount");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();
                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            RoomRepo rep = new RoomRepo();
            var counter = rep.GetCountOfType(r);
            ViewBag.dict = counter;
            return View();
        }
    }
}