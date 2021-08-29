using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UtilisationApi.Models;


namespace UtilisationApi.Controllers
{
    
    public class ClientController : Controller
    {
        
        public  IActionResult GetAll()
        {
            string re = "";
            string URL = "https://localhost:44396/api/Client";
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync(URL);
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    re =  result.Content.ReadAsStringAsync().Result;
                }
            }
            var f = JsonConvert.DeserializeObject<ClientModel[]>(re);

            return View(f);

        }

    }
}
