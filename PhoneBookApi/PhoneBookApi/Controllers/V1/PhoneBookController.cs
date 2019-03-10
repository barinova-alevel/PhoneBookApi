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

namespace PhoneBookApi.Controllers.V1

{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/phonebook")]
   // [ApiExceptionFilter]
    //[ValidationFilter]
    //[Authorize]
    public class PhoneBookController : ApiController
    {
        [Route("contacts")]
        public List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact
                {
                    FirstName = "Robin",
                    LastName = "Hood"
                }
            };
        }

//        private readonly ContactRepository contactRepository;
//        public PhoneBookController()
//        {
//            contactRepository = new ContactRepository();
//        }

//        private static List<Contact> contacts = new List<Contact>
//{
//new Contact
//{
//Id = Guid.NewGuid(),
//FirstName = "Mickey",
//LastName = "Mouse",
//PhoneNumbers = new List<string>{"12345678", "12345679"}
//},
//new Contact
//{
//Id = Guid.NewGuid(),
//FirstName = "Lion",
//LastName = "King",
//PhoneNumbers = new List<string>{"77887788", "77887789", "77887780" }
//}
//};


//        // GET: api/PhoneBook
//        public IEnumerable<Contact> Get()
//        {
//            return contactRepository.GetAll();
//        }

//        // GET: api/PhoneBook/5
//        public Contact Get(Guid id)
//        {
//            return contactRepository.Get(id);
//        }

//        // POST: api/PhoneBook
//        public IHttpActionResult Post([FromBody]Contact contact)
//        {
//            contacts.Add(contact);
//            contactRepository.Create(contact);
//            return this.ResponseMessage(Request.CreateResponse(HttpStatusCode.Created));
//        }

//        [Route("api/contacts/search/{name}")]
//        //[AcceptVerbs("GET")]
//        [HttpGet]

//        public IHttpActionResult SearchContacts(string name)
//        {
//            IEnumerable<Contact> contacts = contactRepository.GetAll()
//            ?.Where(c => c.FullName.ToLower().Contains(name.ToLower()));

//            return Ok(contacts);

//        }
    }
}
