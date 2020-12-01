using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Telemark.Data;
using Telemark.Services;

namespace Telemark.Hubs
{
    public class ResultsHub : Hub
    {
        public RSU_Service _rsu;

        public ApplicationDbContext _context;

        public ResultsHub(RSU_Service rsu, ApplicationDbContext context)
        {
            _rsu = rsu;
            _context = context;
        }
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }

        public Task SendResult(string mid, string message)
        {
            return Clients.Group(mid).SendAsync("GetResult", message);
        }

        public Task DecodeResult(string mid, string message)
        {
            
            return Clients.Group(mid).SendAsync("GetResult", message);
        }

        public async Task SelfieResult(string mid, string message)
        {
            int bib = int.Parse(message);
            int rid = 76;
            var eventId = _context.Participants.Where(p => p.bib_num == bib).Select(p => p.event_id).FirstOrDefault();
            var rsu_eid = _context.Events.Where(e => e.id == eventId).Select(e => e.event_id).FirstOrDefault();
            var rsu_rid = _context.Races.Where(r => r.id == rid).Select(r => r.race_id).FirstOrDefault();
            var output =  await _rsu.GetResultCertificate(rsu_rid, rsu_eid, bib);
            await SendSelfieResult(mid, output.ToString());

            //return Clients.Group(mid).SendAsync("GetResult", output);
        }

        public Task SendSelfieResult(string mid, string message)
        {
            return Clients.Group(mid).SendAsync("GetSelfie", message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Console.WriteLine("JOINED GROUP:" + Context.ConnectionId + " - " + groupName);
            //await Clients.Groups(groupName).SendAsync(Context.ConnectionId, groupName);
            //await Clients.Group(groupName).InvokeAsync("Send", $"{Context.ConnectionId} joined {groupName}");
        }
    }
}
