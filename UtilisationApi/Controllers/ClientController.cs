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
using UtilisationApi.ModelView;

namespace UtilisationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _Config;
        private string URLBase
        {
            get
            {
                return _Config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }
        public ClientController(IConfiguration Config)
        {
            _Config = Config;
        }
       

        public async Task<IActionResult> AddClient()
        {
            var clientview = new Client();
            List<ClientModel> clientList = new List<ClientModel>();

            using (var httpClient = new HttpClient())
            {
                using (var respense = await httpClient.GetAsync(URLBase + "Client"))
                {
                    string apiResponse = await respense.Content.ReadAsStringAsync();

                    clientList = JsonConvert.DeserializeObject<List<ClientModel>>(apiResponse);
                }
            }
            clientview = new SelectList(clientList, "Nom", "Prenom");
            return (IActionResult)clientview;

        }

    }
}
