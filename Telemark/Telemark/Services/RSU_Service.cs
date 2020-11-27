using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telemark.Models;

namespace Telemark.Services
{
    public class RSU_Service
    {
        public RSU_Service()
        {

        }

        [HttpGet]
        public async Task<RsuRaces> GetRaces(string apiKey, string apiSecret)
        {
            string url = $"https://runsignup.com/rest/races?api_key={apiKey}&api_secret={apiSecret}&format=JSON&start_date=2020-01-01&only_partner_races=T";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = "";
            RsuRaces races = new RsuRaces();
            if (response.IsSuccessStatusCode)
            {
                jsonResult = await response.Content.ReadAsStringAsync();
                races = JsonConvert.DeserializeObject<RsuRaces>(jsonResult);
               
            }
            return races;
            
        }
    }
}
