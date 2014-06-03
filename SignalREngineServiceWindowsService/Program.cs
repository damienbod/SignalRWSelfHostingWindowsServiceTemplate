using System;
using System.ServiceProcess;
using SignalREngine;

namespace SignalREngineServiceWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Remove this if you want to test as a console application and add an arg
			ServiceBase.Run(new SignalREngineServiceWindowsService());

            if (args != null)
            {
                try
                {
                    Startup.StartServer();
                    Console.ReadKey();
                }
                finally
                {
                    Startup.StopServer();
                }
            }
        }
    }
}
