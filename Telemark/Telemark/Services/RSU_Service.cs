using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telemark.Data;
using Telemark.Models;

namespace Telemark.Services
{
    public class RSU_Service
    {
        private readonly ApplicationDbContext _context;

        public RSU_Service(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<RsuRaces> GetRaces(string apiKey, string apiSecret)
        {
            string url = $"https://runsignup.com/rest/races?api_key={apiKey}&api_secret={apiSecret}&format=JSON&start_date=2020-07-07&only_partner_races=T";
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

        [HttpGet]
        public async Task<RaceObject> GetRace(string apiKey, string apiSecret, int id)
        {
            string url = $"https://runsignup.com/rest/race/{id}?format=JSON&api_key={apiKey}&api_secret={apiSecret}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = "";
            RaceObject race = new RaceObject();
            if (response.IsSuccessStatusCode)
            {
                jsonResult = await response.Content.ReadAsStringAsync();
                race = JsonConvert.DeserializeObject<RaceObject>(jsonResult);

            }
            return race;
        }

        [HttpGet]
        public async Task<int> GetParticipantCount(string apiKey, string apiSecret, int raceId, int eventId)
        {
            string url = $"https://runsignup.com/Rest/race/{raceId}/participant-counts?event_id={eventId}&format=JSON&api_key={apiKey}&api_secret={apiSecret}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            int count = 0;
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                var rsuCount = JsonConvert.DeserializeObject<RsuEventCount>(jsonResult);
                count = rsuCount.participant_counts[0].num_participants;
            }
            return count;
        }

        [HttpGet]
        public async Task<List<ParticipantObject>> GetParticipants(string apiKey, string apiSecret, int raceId, int eventId)
        {
            string url = $"https://runsignup.com/Rest/race/{raceId}/participants?event_id={eventId}&page=1&results_per_page=2500&format=JSON&api_key={apiKey}&api_secret={apiSecret}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            List<ParticipantObject> po = new List<ParticipantObject>();
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                dynamic obj = JsonConvert.DeserializeObject(jsonResult);
                //var obj = JsonConvert.DeserializeObject<List<ExpandoObject>>(jsonResult, new ExpandoObjectConverter());
                //var results = JArray.Parse(jsonResult);
                JArray participantsArray = new JArray();
                participantsArray = obj;
                JObject jo = new JObject();
                jo = (JObject)participantsArray[0];
                participantsArray = (JArray)jo["participants"];
                if(participantsArray != null)
                {
                    po = participantsArray.ToObject<List<ParticipantObject>>();
                }
                
                //List<ParticipantObject> participants = (List<ParticipantObject>)obj[0].ElementAt(1).Value;


                //Console.WriteLine(participants.Count);

                //RsuParticipant rsuParticipants = JsonConvert.DeserializeObject<RsuParticipant>(jsonResult);

            }
            return po;
        }

        [HttpGet]
        public async Task<string> GetParticipantResultsURL(int raceId, int eventId, int bib)
        {
            var director_id = _context.Races.Where(r => r.race_id == raceId).Select(r => r.director_id).FirstOrDefault();
            var director = _context.Directors.Where(d => d.Id == director_id).FirstOrDefault();
            string apiKey = director.RSU_API_Key;
            string apiSecret = director.RSU_API_Secret;
            string url = $"https://runsignup.com/Rest/race/{raceId}/results/get-results?format=json&event_id={eventId}&bib_num={bib}&api_key={apiKey}&api_secret={apiSecret}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string certUrl = "";
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                JObject jo = new JObject();
                jo = JObject.Parse(jsonResult);
                int rs = (int)jo["individual_results_sets"][0]["individual_result_set_id"];
                int rid = (int)jo["individual_results_sets"][0]["results"][0]["result_id"];
                certUrl = $"https://runsignup.com/Race/Results/{raceId}/FinishersCert?resultSetId={rs}&resultId={rid}#certificate";
            }
            return certUrl;
        }

        [HttpGet]
        public async Task<string> ScrapeCertificatePage(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var pageContents = await response.Content.ReadAsStringAsync();
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);
            var headlineText = pageDocument.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[7]/div[3]/div[3]/div[1]/div[1]/div[1]/div[2]/img[1]/@src[1]").Attributes;

            string result = headlineText[0].Value;
            return result;
        }


    }
}
