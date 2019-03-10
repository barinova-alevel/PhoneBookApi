using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBookApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        //// POST api/values
        //public string Post([FromBody]CheckReturnValue value)
        //{
        //    var task = this.Request.Content.ReadAsStringAsync();
        //    task.Wait();
        //    string rawData = task.Result;
        //    return value.Value;
        //}
       
            // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
    //public class CheckReturnValue
    //{
    //    public string Value { get; set; }
    //} 
}
