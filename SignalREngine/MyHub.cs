using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SignalREngine.Dto;

namespace SignalREngine
{
    public class MyHub : Hub
    {
        public void AddMessage(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public void Heartbeat()
        {
            Clients.All.heartbeat();
        }

        public void SendHelloObject(HelloModel hello)
        {
            Clients.All.sendHelloObject(hello);
        }

        public override Task OnConnected()
        {
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            return (base.OnDisconnected());
        }
    }
}