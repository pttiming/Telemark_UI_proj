using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telemark.Models;

namespace Telemark.Services
{
    public class GoogleService
    {
        public async Task<Director> GetGeoCode(Director director)
        {
            string address = GoogleAddressParser(director);
            Uri geocodeURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + API_KEYS.googleMapsApi);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(geocodeURL);

            if (response.IsSuccessStatusCode)
            {
                var task = response.Content.ReadAsStringAsync().Result;
                JObject mapsData = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(task);
                director.Latitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lat"]);
                director.Longitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lng"]);
            }

            return director;
        }

        //public async Task<Models.Event> GetGeoCode(Models.Event groupChatEvent)
        //{
        //    string address = GoogleAddressParser(groupChatEvent);
        //    Uri geocodeURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + API_KEYS.googleMapsApi);
        //    HttpClient httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync(geocodeURL);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var task = response.Content.ReadAsStringAsync().Result;
        //        JObject mapsData = JsonConvert.DeserializeObject<JObject>(task);
        //        groupChatEvent.Latitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lat"]);
        //        groupChatEvent.Longitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lng"]);
        //    }

        //    return groupChatEvent;
        //}

        private string GoogleAddressParser(Director director)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < director.Address1.Length; i++)
            {
                if (director.Address1[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(director.Address1[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < director.City.Length; i++)
            {
                if (director.City[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(director.City[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < director.State.Length; i++)
            {
                if (director.State[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(director.State[i]);
                }
            }
            return sb.ToString();
        }

        //private string GoogleAddressParser(Models.Event groupChatEvent)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < groupChatEvent.Address1.Length; i++)
        //    {
        //        if (groupChatEvent.Address1[i] == ' ')
        //        {
        //            sb.Append("+");
        //        }
        //        else
        //        {
        //            sb.Append(groupChatEvent.Address1[i]);
        //        }
        //    }
        //    sb.Append(",+");
        //    for (int i = 0; i < groupChatEvent.City.Length; i++)
        //    {
        //        if (groupChatEvent.City[i] == ' ')
        //        {
        //            sb.Append("+");
        //        }
        //        else
        //        {
        //            sb.Append(groupChatEvent.City[i]);
        //        }
        //    }
        //    sb.Append(",+");
        //    for (int i = 0; i < groupChatEvent.State.Length; i++)
        //    {
        //        if (groupChatEvent.State[i] == ' ')
        //        {
        //            sb.Append("+");
        //        }
        //        else
        //        {
        //            sb.Append(groupChatEvent.State[i]);
        //        }
        //    }
        //    return sb.ToString();
        //}
    }
}
