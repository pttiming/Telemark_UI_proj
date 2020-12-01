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
        public async Task<Location> GetGeoCode(Location location)
        {
            string address = GoogleAddressParser(location);
            Uri geocodeURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + API_KEYS.googleMapsApi);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(geocodeURL);

            if (response.IsSuccessStatusCode)
            {
                var task = response.Content.ReadAsStringAsync().Result;
                JObject mapsData = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(task);
                location.Latitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lat"]);
                location.Longitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lng"]);
            }

            return location;
        }

        public async Task<RaceAddress> GetGeoCode(RaceAddress raceAddress)
        {
            string address = GoogleAddressParser(raceAddress);
            Uri geocodeURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + API_KEYS.googleMapsApi);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(geocodeURL);

            if (response.IsSuccessStatusCode)
            {
                var task = response.Content.ReadAsStringAsync().Result;
                JObject mapsData = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(task);
                raceAddress.Latitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lat"]);
                raceAddress.Longitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lng"]);
            }

            return raceAddress;
        }


        private string GoogleAddressParser(Location location)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < location.Address1.Length; i++)
            {
                if (location.Address1[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(location.Address1[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < location.City.Length; i++)
            {
                if (location.City[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(location.City[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < location.State.Length; i++)
            {
                if (location.State[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(location.State[i]);
                }
            }
            return sb.ToString();
        }

        private string GoogleAddressParser(RaceAddress location)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < location.street.Length; i++)
            {
                if (location.street[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(location.street[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < location.city.Length; i++)
            {
                if (location.city[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(location.city[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < location.state.Length; i++)
            {
                if (location.state[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(location.state[i]);
                }
            }
            return sb.ToString();
        }


    }
}
