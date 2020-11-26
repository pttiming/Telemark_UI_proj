using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<RSU_Races> GetRaces(string apiKey, string apiSecret)
        {
            RSU_Races rsu_Races = new RSU_Races() { Error = "API Error" };
            string url = $"https://runsignup.com/rest/races?api_key={apiKey}&api_secret={apiSecret}&format=JSON&start_date=2020-01-01&only_partner_races=T";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                rsu_Races = JsonConvert.DeserializeObject<RSU_Races>(jsonResult);
                return rsu_Races;
            }
            rsu_Races = new RSU_Races() { Error = "API Error" };
            return rsu_Races;
        }
    }
}
