
using Microsoft.Web.Http;

using PhoneBookApi.Filters;
using PhoneBookApi.Models;
using PhoneBookApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPhoneBookApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/phonebook")]
    [ValidationFilter]
    [ApiExceptionFilter]
    [Authorize]
    public class PhoneBookController : ApiController
    {
        private readonly ContactRepository contactRepository;

        public PhoneBookController()
        {
            contactRepository = new ContactRepository();
        }

        [Route("contacts")]
        public IHttpActionResult GetContacts()
        {
            IEnumerable<Contact> contacts = contactRepository.GetAll();
            return contacts != null && contacts.Any()
                ? CreateResponse(HttpStatusCode.OK, contacts)
                : CreateErrorResponse(HttpStatusCode.NoContent, "No contacts found");
        }

        [Route("contacts/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            Contact contact = contactRepository.Get(id);
            return contact != null
               ? CreateResponse(HttpStatusCode.OK, contact)
               : CreateErrorResponse(HttpStatusCode.NotFound, "No contact found");
        }

        [Route("contacts/search/{name}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchContacts(string name)
        {
            IEnumerable<Contact> contacts = contactRepository.GetAll()
                ?.Where(c => c.FullName.ToLower().Contains(name.ToLower()));

            return contacts != null && contacts.Any()
               ? CreateResponse(HttpStatusCode.OK, contacts)
               : CreateErrorResponse(HttpStatusCode.NoContent, "No contacts found");
        }

        [Route("contacts")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateContact([FromBody]Contact contact)
        {
            contactRepository.Create(contact);
            return CreateResponse(HttpStatusCode.Created);
        }

        [Route("contacts")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateContact([FromBody]Contact contact)
        {
            contactRepository.Edit(contact);
            return CreateResponse(HttpStatusCode.OK);
        }

        [Route("contacts/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(Guid id)
        {
            contactRepository.Delete(id);
            return CreateResponse(HttpStatusCode.OK);
        }

        private IHttpActionResult CreateResponse(HttpStatusCode statusCode)
        {
            HttpResponseMessage responseMsg = Request.CreateResponse(statusCode);
            return ResponseMessage(responseMsg);
        }

        private IHttpActionResult CreateResponse<T>(HttpStatusCode statusCode, T value)
        {
            HttpResponseMessage responseMsg = Request.CreateResponse(statusCode, value);
            return ResponseMessage(responseMsg);
        }

        private IHttpActionResult CreateErrorResponse(HttpStatusCode statusCode, string message)
        {
            HttpResponseMessage responseMsg = Request.CreateErrorResponse(statusCode, message);
            return ResponseMessage(responseMsg);
        }
    }
}
