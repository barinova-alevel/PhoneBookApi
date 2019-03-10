using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC25.DataModel;
using MVC25.Exceptions;
using MVC25.Helper;
using MVC25.Models;
using RestSharp;

namespace MVC25.Controllers
{
    public class ContactController : Controller
    {
        
        // GET: Contact
        public ActionResult Index()
        {
            //temporary code
            //RestClient client = new RestClient("http://localhost:7891/");
            //RestRequest request = new RestRequest("/api/contacts", Method.GET);

            //IRestResponse<List<Contact>> response = client.Execute<List<Contact>>(request);
            //List<Contact> contacts = response.Data;
            RestSharpHelper restSharpHelper = new RestSharpHelper();

            List<Contact> contacts = restSharpHelper.Execute<List<Contact>>(
                RestServiceNames.GetContacts, Method.GET, null, true).Data;

            return View(contacts);
        }


       
        
        // GET: Contact/Details/5
        public ActionResult Details(Guid id)
        {
            RestSharpHelper restSharpHelper = new RestSharpHelper();
            Contact contact = restSharpHelper.Execute<Contact>(
               RestServiceNames.GetContactById, Method.GET,
               new Dictionary<string, object> { { "id", id } }, true).Data;

            return View(contact);
        }


        // GET: Contact/Create
        public ActionResult Create()
        {
            var contact = new Contact();
            return View(contact);
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                RestSharpHelper restSharpHelper = new RestSharpHelper();
                var result = restSharpHelper.Execute(RestServiceNames.CreateContact, Method.POST, new Dictionary<string, object>() { { "body", contact } }, true);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    ModelState.AddModelError("", result.Content);
                }
                else
                    return RedirectToAction("Index");
            }
            catch (MVC25Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(Guid id)
        {
            RestSharpHelper restSharpHelper = new RestSharpHelper();
            Contact contact = restSharpHelper.Execute<Contact>(
               RestServiceNames.GetContactById, Method.GET,
               new Dictionary<string, object> { { "id", id } }, true).Data;

            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Contact contact)
        {
            try
            {
                RestSharpHelper restSharpHelper = new RestSharpHelper();
          var result = restSharpHelper.Execute(RestServiceNames.UpdateContact, Method.PUT, new Dictionary<string, object>() { { "body", contact } }, true);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    ModelState.AddModelError("", result.Content);
                }
                else
                    return RedirectToAction("Index");
            }
            catch (MVC25Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(contact);

        }

        // GET: Contact/Delete/5
        public ActionResult Delete(Guid id)
        {
            RestSharpHelper restSharpHelper = new RestSharpHelper();
            Contact contact = restSharpHelper.Execute<Contact>(
               RestServiceNames.GetContactById, Method.GET,
               new Dictionary<string, object> { { "id", id } }, true).Data;

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, Contact contact)
        {
            try
            {
                RestSharpHelper restSharpHelper = new RestSharpHelper();
                restSharpHelper.Execute(RestServiceNames.DeleteContact, Method.DELETE, new Dictionary<string, object>() { { "id", id } }, true);

                return RedirectToAction("Index");
            }
            catch (MVC25Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(contact);
        }
    }
}