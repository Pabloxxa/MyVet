using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index() {
            List<Country> model = null;
            var client = new HttpClient();
            /*https://restcountries.eu/rest/v2/alpha/col*/
            dynamic response =   "";
            dynamic jsonString = "";
           var task = client.GetAsync("https://restcountries.eu/rest/v2/alpha/col")
              .ContinueWith((taskwithresponse) =>
              {
                  response   = taskwithresponse.Result;
                  jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  model = JsonConvert.DeserializeObject<List<Country>>(jsonString.Result);

              });
            task.Wait();
            return View();
        }

        private class Country
        {
        }
    }
}
