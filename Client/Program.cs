using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {

        private static int _errors = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Pass input to send message");
            var input = Console.ReadLine();

            //CallForHost("192.168.1.102", input);
            Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (i) =>
            {
                CallForHost("{hostname}", i.ToString());
            });

            Console.WriteLine($"Total Errors: {_errors}");

            Console.ReadKey();
        }

        private static void CallForHost(string hostPath, string input)
        {
            Console.WriteLine($"====== Service Host: {hostPath} Thread: {Task.CurrentId} ======", hostPath);

            CallViaHttp(hostPath, input);
            //CallViaNetTcp(input);

            Console.WriteLine();
        }

        static void CallViaHttp(string hostPath, string input)
        {
            try
            {
                var address = string.Format("http://{0}/Service1.svc", hostPath);
                var binding = new BasicHttpBinding();
                var factory = new ChannelFactory<IService1>(binding, address);
                var channel = factory.CreateChannel();

                var res = channel.Hello(input);

                Console.WriteLine($"{ Environment.NewLine } { nameof(Program.CallViaHttp) } response: { Environment.NewLine } { res }");
            }
            catch (Exception ex)
            {
                Console.WriteLine(Environment.NewLine + "Error: " + ex.ToString());
                _errors++;
            }
        }

        static void CallViaNetTcp(string hostPath, string input)
        {
            try
            {
                var address = string.Format("net.tcp://{0}/Service1.svc", hostPath);
                var binding = new NetTcpBinding(SecurityMode.None);
                var factory = new ChannelFactory<IService1>(binding, address);
                var channel = factory.CreateChannel();

                var res = channel.Hello(input);

                Console.WriteLine($"{ Environment.NewLine } { nameof(Program.CallViaNetTcp) } response: { Environment.NewLine } { res }");
            }
            catch (Exception ex)
            {
                Console.WriteLine(Environment.NewLine + "Error: " + ex.ToString());
                _errors++;
            }
        }
    }
}
