using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC25.Models
{
    public class ContactVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }

}