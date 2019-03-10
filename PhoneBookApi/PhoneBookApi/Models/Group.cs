using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PhoneBookApi.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public List<Contact> Contacts { get; set; }
    }
}