using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DockerWcfDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("The service is starting...");

            // Create the ServiceHost
            ServiceHost host = new ServiceHost(typeof(Service1));

            try
            {
                // Open the ServiceHost to start listening for messages
                host.Open();

                foreach (var uri in host.BaseAddresses)
                {
                    Console.WriteLine("The service is ready at {0}", uri);
                }
            }
            catch (Exception ex)
            {
                try { host?.Close(); }
                catch { }

                Console.WriteLine(ex.ToString());
            }

            // will throw in container: Cannot read keys when either application does not have a console or when console input has been redirected from a file.Try Console.Read
            // Console.ReadKey();

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
