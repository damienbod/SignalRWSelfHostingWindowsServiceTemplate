using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using SignalREngine;

[assembly: OwinStartup(typeof(Startup))]

namespace SignalREngine
{
    public class Startup
    {
        static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        // Your startup logic
        public static void StartServer()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(RunSignalRServer, TaskCreationOptions.LongRunning
                                  , cancellationTokenSource.Token);  
        }

        private static void RunSignalRServer(object task)
        {
            string url = "http://localhost:8089";
            WebApp.Start(url);
        }

        public static void StopServer()
        {
            _cancellationTokenSource.Cancel();
        }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                };

                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
