using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC25.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            RestClient client = new RestClient("http://localhost:7891/");

            RestRequest request = new RestRequest("/api/token", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", "grant_type=password&username=garry&password=potter", ParameterType.RequestBody);
            var obj = client.Post<object>(request);

            // IRestResponse<List<Group>> response = client.Execute<List<Group>>(request);


            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}