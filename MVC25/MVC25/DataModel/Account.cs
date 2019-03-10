using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC25.DataModel
{
    public class Account
    {
        public string UserName { get; internal set; }
        public string Login { get; internal set; }
        public string Password { get; internal set; }
    }
}