using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBookApi.Controllers
{
    public class VersionController : ApiController
    {
        //Get: api/Version
        public string GetLastVersion()
        {
            return "v2";
        }
    }

}
