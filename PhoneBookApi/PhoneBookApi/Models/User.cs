﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookApi.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}