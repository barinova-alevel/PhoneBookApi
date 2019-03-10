using PhoneBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookApi.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>
    {
       
        public override string ServerPath => "~/Contacts";
    }
}