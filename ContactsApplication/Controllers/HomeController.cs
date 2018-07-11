using ContactsApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

//Home Controller 
namespace ContactsApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {      
            IEnumerable<ContactViewModel> contacts = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51993/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Contacts/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ContactViewModel>>();
                    readTask.Wait();

                    contacts = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    contacts = Enumerable.Empty<ContactViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(contacts);
        }

        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contacts = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51993/api/");  //Web api localhost UEL
                //HTTP GET
                var responseTask = client.GetAsync("Contacts/GetContactsByID?ContactID=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ContactViewModel>();
                    readTask.Wait();

                    contacts = readTask.Result;
                }
            }
            return View(contacts);
        }

        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51993/api/");  //Web api localhost UEL
                    string jsonContact = JsonConvert.SerializeObject(contact, Formatting.Indented);

                    //HTTP Put
                    var putTask = client.PutAsJsonAsync("Contacts/addContacts", jsonContact);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }                
            }
            return View(contact);
        }

        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ContactViewModel contacts = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51993/api/");  //Web api localhost UEL
                //HTTP GET
                var responseTask = client.GetAsync("Contacts/GetContactsByID?ContactID=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ContactViewModel>();
                    readTask.Wait();

                    contacts = readTask.Result;
                }
            }
            return View(contacts);
        }

        //
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51993/api/");  //Web api localhost UEL
                    string jsonContact = JsonConvert.SerializeObject(contact, Formatting.Indented);

                    //HTTP POST
                    var putTask = client.PostAsJsonAsync("Contacts/updateContacts", jsonContact);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(contact);
        }

        //
        // GET: /Home/Delete/5
        [HttpGet, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51993/api/");   //Web api localhost UEL
                //HTTP Delete : delete specific contact by id
                var responseTask = client.DeleteAsync("Contacts/DeleteContactsByID?ContactID=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        //
        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,FormCollection c)
        {
            return View();
        }
    }
}
