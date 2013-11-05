﻿using Damienbod.SignalR.Host.Hubs;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Damienbod.Slab;
using Damienbod.Slab.Services;
using Microsoft.AspNet.SignalR;

namespace Damienbod.SignalR.Host.Service
{
    public class MyHub : IMyHub
    {
        private readonly IHubLogger _slabLogger;
        private readonly IHubContext _hubContext;

        public MyHub(IHubLogger slabLogger)
        {
            _slabLogger = slabLogger;
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<HubSync>(); 
        }
        
        public void AddMessage(string name, string message)
        {
            _hubContext.Clients.All.addMessage("MyHub", "ServerMessage");
            _slabLogger.Log(HubType.HubServerVerbose, "MyHub Sending addMessage");
        }

        public void Heartbeat()
        {
            _hubContext.Clients.All.heartbeat();
            _slabLogger.Log(HubType.HubServerVerbose, "MyHub Sending heartbeat");
        }

        public void SendHelloObject(HelloModel hello)
        {
            _hubContext.Clients.All.sendHelloObject(hello);
            _slabLogger.Log(HubType.HubServerVerbose, "MyHub Sending sendHelloObject");
        }
    }
}
