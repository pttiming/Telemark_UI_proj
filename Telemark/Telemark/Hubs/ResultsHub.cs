using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Telemark.Hubs
{

    public class ResultData
    {
        public int bib;
        public string time;
        public string name;
    }

    public class ResultsHub : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }

        public Task SendResult(string mid, string message)
        {
            return Clients.Group(mid).SendAsync("GetResult", message);
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
